using CommandService.Models;

namespace CommandService.Data.Repository
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        // Plateform
        IEnumerable<Plateform> GetAllPlateforms();
        void CreatePlateform(Plateform plat);
        bool PlateformExists(int plateformId);


        // Commands
        IEnumerable<Command> GetCommandFromPlateform(int plateformId);
        Command GetCommand(int plateformId, int commandId);
        void CreateCommand(int plateformId, Command command);
    }
}