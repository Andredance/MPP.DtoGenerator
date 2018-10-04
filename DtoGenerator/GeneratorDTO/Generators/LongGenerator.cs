using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO.Generators
{
    public class LongGenerator : IGenerator
    {
        Random random;

        public LongGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return random.Next(int.MinValue, int.MaxValue) + random.Next(int.MinValue, int.MaxValue);
        }
    }
}
