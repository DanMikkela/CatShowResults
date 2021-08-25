using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat_Show_Results.Models
{
    public interface IClassRepository
    {
        IEnumerable<Class> AllClasses { get; }
    }
}
