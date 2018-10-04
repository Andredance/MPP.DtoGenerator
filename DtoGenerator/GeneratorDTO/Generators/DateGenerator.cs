using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO.Generators
{
    public class DateGenerator : IGenerator
    {
        public object Generate()
        {
            return DateTime.Now;
        }
    }
}
