using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cat_Show_Results.Models
{
    public interface IJudgeRepository
    {
        IEnumerable<Judge> AllJudges { get; }
    }
}