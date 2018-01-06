using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new MyUser();

            var type = s.GetType();
            var fx = type.GetGenericArguments();
            foreach(var item in fx)
            {
                Console.WriteLine(item.Name);
            }

            var fx2 = type.GetGenericParameterConstraints();
            foreach (var item in fx2)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadKey();

        }
    }



    class Base<T> 
    {

    }

    class MyUser : Base<Demo>
    {
        private List<Demo> list = new List<Demo>();

    }



    public class Demo : IEntity<String>
    {
        public Demo()
        {

        }

        public string name { get; set; }

        public String item { get; set; }
    }




    public class IEntity<T>
    {

    }

}
