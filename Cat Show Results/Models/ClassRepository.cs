using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat_Show_Results.Models
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClassRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Class> AllClasses => _appDbContext.Classes;
    }
}
