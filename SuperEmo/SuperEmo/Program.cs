using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperEmo
{
    class Program
    {
        static void Main(string[] args)
        {
            Enviroment env = new Enviroment();
            Agent nevena = new Agent();
            nevena.save("C:\\Users\\stef\\Downloads\\nevena.txt");
            Console.WriteLine("test\n sea klikni neso");
        }
    }
}
