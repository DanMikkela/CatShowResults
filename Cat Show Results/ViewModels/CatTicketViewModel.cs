using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cat_Show_Results.Models;

namespace Cat_Show_Results.ViewModels
{
    public class CatListViewModel
    {
        public IEnumerable<Cat> Cats { get; set; }
        public string CurrentCategory { get; set; }
    }
}
