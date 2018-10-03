using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO.Generators
{
    public class DoubleGenerator : IGenerator
    {
        Random random;

        public DoubleGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return random.NextDouble()*double.MaxValue;
        }
    }
}
