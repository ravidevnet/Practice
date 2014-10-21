using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DDD.SharedKernel.Tasks
{
    public interface IRunAtStartup
    {
        void Execute();
    }
}
