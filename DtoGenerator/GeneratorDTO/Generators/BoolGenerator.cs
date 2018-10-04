using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO.Generators
{
    public class BoolGenerator : IGenerator
    {
        Random random;

        public BoolGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return random.Next(1) == 1 ? true : false;
        }
    }
}
