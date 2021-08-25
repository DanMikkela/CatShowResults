using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;

namespace Cat_Show_Results.Models
{
        public interface ICatRepository
        {
            //IEnumerable<Cat> FeaturedCats { get; }
            //Cat GetCatById(int catId);
            IEnumerable<Cat> GetAll { get; }  
        }
}
