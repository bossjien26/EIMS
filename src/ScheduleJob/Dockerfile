FROM redis

#COPY redis.conf /usr/local/etc/redis/redis.conf
#CMD [ "redis-server", "/usr/local/etc/redis/redis.conf" ]
FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
# EXPOSE 5000
WORKDIR /app

RUN apk add libgdiplus --update-cache --repository http://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted && \
    apk add terminus-font


FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build

WORKDIR /src

COPY ["src/ScheduleJob/ScheduleJob.csproj","src/ScheduleJob/"]
COPY ["src/Services/Services.csproj","src/Services/"]
COPY ["src/Entities/Entities.csproj","src/Entities/"]
COPY ["src/Repositories/Repositories.csproj","src/Repositories/"]
COPY ["src/Helpers/Helpers.csproj","src/Helpers/"]
# COPY ["src/Enum/Enum.csproj","src/Enum/"]
RUN dotnet restore "src/ScheduleJob/ReScheduleJobstApi.csproj"
COPY . .
WORKDIR "/src/src/ScheduleJob"
RUN dotnet build "ScheduleJob.csproj" -c Release -o /app/build

FROM build As publish
RUN dotnet publish "ScheduleJob.csproj" -c Release -o /app/publish

FROM base As final
WORKDIR /app
COPY --from=publish /app/publish .
RUN apk add --no-cache tzdata
ENV TZ Asia/Taipei
# ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "ScheduleJob.dll"]
# RUN dotnet ef database update

#RUN dotnet ef database update

