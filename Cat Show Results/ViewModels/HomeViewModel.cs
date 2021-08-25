using Cat_Show_Results.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat_Show_Results.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Cat> AllCats { get; set; }

    }
}
