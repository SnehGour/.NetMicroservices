using PlateformService.DTOs;

namespace PlateformService.SyncDataService.Http
{
    public interface ICommandDataClient
    {
        Task SendPlateformToCommand(PlateformReadDTO plat);
    }
}