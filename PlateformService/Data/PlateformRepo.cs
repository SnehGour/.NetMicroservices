using PlateformService.Models;

namespace PlateformService.Data
{
    public class PlateformRepo : IPlateformRepo
    {
        private readonly AppDbContext _context;

        public PlateformRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePlateform(Plateform plat)
        {
            if(plat ==null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Plateforms.Add(plat);
        }

        public IEnumerable<Plateform> GetAllPlateforms()
        {
            return _context.Plateforms.ToList();
        }

        public Plateform GetPlateformById(int Id)
        {
            return _context.Plateforms.FirstOrDefault(x=> x.Id == Id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}