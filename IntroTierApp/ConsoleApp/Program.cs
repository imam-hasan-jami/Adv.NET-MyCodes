using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data1 = PersonService.GetAll();
            foreach (var item in data1)
            {
                Console.WriteLine(item.Name + " " + item.Id);
            }

            var data2 = PersonService.Get(154);
            Console.WriteLine(data2.Name + " " + data2.Id);
        }
    }
}
