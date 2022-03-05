using Enum;

namespace RestApi.Models.Requests
{
    public class CreateWarehouseRequest
    {
        public WarehouseEnum Type { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}