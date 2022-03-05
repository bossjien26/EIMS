using System.Linq;
using System.Threading.Tasks;
using DbEntity;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Middlewares.Authentication;
using RestApi.Models.Requests;
using Services;
using Services.Interface;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly ILogger<WarehouseController> _logger;

        private IWarehouseService _warehouseService;

        public WarehouseController(DbContextEntity context, ILogger<WarehouseController> logger)
        {
            _warehouseService = new WarehouseService(context);
            _logger = logger;
        }

        [Authorize()]
        [HttpGet]
        [Route("{perPage}")]
        public IActionResult ShowWarehouses(int perPage)
        => Ok(_warehouseService.GetMany(perPage, 10).ToList());

        [Authorize()]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetWarehouse(int id)
        => Ok(await _warehouseService.GetById(id));

        [Authorize()]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(CreateWarehouseRequest request)
        => Ok(await CreateWarehouse(request));

        [Authorize()]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, UpdateWarehouseRequest request)
        {
            var warehouse = await _warehouseService.GetById(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            return Ok(await UpdateWarehouse(warehouse, request));
        }

        private async Task<Warehouse> UpdateWarehouse(Warehouse warehouse, UpdateWarehouseRequest request)
        {
            warehouse.Name = request.Name;
            warehouse.Type = request.Type;
            warehouse.Address = request.Address;
            await _warehouseService.Update(warehouse);

            return warehouse;
        }

        private async Task<Warehouse> CreateWarehouse(CreateWarehouseRequest request)
        {
            var warehouse = new Warehouse()
            {
                Name = request.Name,
                Type = request.Type,
                Address = request.Address
            };
            await _warehouseService.Insert(warehouse);
            return warehouse;
        }
    }
}