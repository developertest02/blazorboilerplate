using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Shared.Dto.Db
{
    public partial class Exercise
    {
        public Exercise()
        {
            Id = Guid.NewGuid();
        }
    }
}
