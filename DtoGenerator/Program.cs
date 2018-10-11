using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorDTO.Generators;
using GeneratorDTO;
using System.Reflection;

namespace DtoGenerator
{
    public class A
    {
        public B b;
        public C c;
    }

    public class B
    {
        public C c;
    }

    public class C
    {
        public int a;
    }
    public class MoreSimple
    {
        public char a;
        public string b;
    }
    public class Simple
    {
        public int a;
        public uint b;
        public string c;
        public byte d;
        public char e;
        public double f;
        public float g;
        public bool h;
        public List<MoreSimple> list;
    }
    class Program
    {
        static void Main(string[] args)
        {

            Faker faker = new Faker();
            Simple c = faker.Create<Simple>();
            Console.WriteLine(c.a);
            Console.WriteLine(c.h);
            Console.ReadKey();
        }
    }
}
