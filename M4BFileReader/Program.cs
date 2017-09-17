using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4BFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            M4BReader reader = new M4BReader();
            var filePath = @"w1z01n020.m4b";

            Console.WriteLine("Opening " + System.IO.Path.GetFileName(filePath) + "\r\n");
            reader.OpenM4B(filePath);
            Console.ReadLine();
        }
    }
}
