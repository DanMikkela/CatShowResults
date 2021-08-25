using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;

namespace Cat_Show_Results.Models
{
    public class CatRepository : ICatRepository
    {
        private readonly AppDbContext _appDbContext;

        public CatRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Cat> GetAll { get {  return _appDbContext.Cats; } }

        public IEnumerable<Cat> FeaturedCats
        {
            get
            {
                return _appDbContext.Cats.Include(c => c.ClassNr).Where(p => p.IsFeatured);
            }
        }

        public Cat GetCatById(int catId)
        {
            return _appDbContext.Cats.FirstOrDefault(p => p.CatId == catId);
        }

    }
}
