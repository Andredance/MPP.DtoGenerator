using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO.Generators
{
    public class ByteGenerator: IGenerator
    {
        Random random;

        public ByteGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return (byte)random.Next(0, 255);
        }
    }
}
