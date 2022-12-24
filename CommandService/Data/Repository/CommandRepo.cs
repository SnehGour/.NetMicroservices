using CommandService.Models;

namespace CommandService.Data.Repository
{
    public class CommandRepo : ICommandRepo
    {
        private readonly ApplicationDbContext _context;

        public CommandRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateCommand(int plateformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            command.PlateformId = plateformId;
            _context.Commands.Add(command);
        }

        public void CreatePlateform(Plateform plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Plateforms.Add(plat);
        }

        public IEnumerable<Plateform> GetAllPlateforms()
        {
            return _context.Plateforms.ToList();
        }

        public Command GetCommand(int plateformId, int commandId)
        {
            return _context.Commands
                .Where(c => c.PlateformId == plateformId && c.Id == commandId)
                .FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandFromPlateform(int plateformId)
        {
            return _context.Commands
                .Where(c => c.PlateformId == plateformId)
                .OrderBy(c => c.Plateform.Name);
        }

        public bool PlateformExists(int plateformId)
        {
            return _context.Plateforms.Any(x => x.Id.Equals(plateformId));
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}