using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat_Show_Results.Models
{
    public class JudgeRepository : IJudgeRepository
    {
        private readonly AppDbContext _appDbContext;

        public JudgeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Judge> AllJudges => _appDbContext.Judges;
    }
}
