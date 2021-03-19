using Dapper;
using HW_1_18_03_21.Repositories.ClientRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HW_1_18_03_21
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ClientRepository client = new ClientRepository();
            while (true)
            {
                Console.Clear();
                Console.Write("1.Create\n2.Read\n3.Update\n4.Delete\nВаш выбор: ");
                switch (Console.ReadLine())
                {
                    case "1": { client.Create(); Console.ReadKey(); } break;
                    case "2": { client.Read(); Console.ReadKey(); } break;
                    case "3": { client.Update(); Console.ReadKey(); } break;
                    case "4": { client.Delete(); Console.ReadKey(); } break;
                    default:
                        break;
                }
            }
        }
       

    }
}
