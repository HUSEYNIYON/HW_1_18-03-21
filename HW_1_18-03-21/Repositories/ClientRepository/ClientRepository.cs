using Dapper;
using HW_1_18_03_21.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HW_1_18_03_21.Repositories.ClientRepository
{
    class ClientRepository:RepositoryBase<Client>
    {
        public ClientRepository():base()
        {

        }
        public void Create()
        {
            Client client = new Client();
            Console.Write("LastName: "); client.LastName = Console.ReadLine();
            Console.Write("FirstName: "); client.FirstName = Console.ReadLine();
            Console.Write("BirthYear: "); 
            client.BirthDate = DateTime.Parse(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(conString))
                {
                    var command = $"INSERT INTO Clients([LastName],[FirstName],[BirthDate]) VALUES('{client.LastName}','{client.FirstName}',{client.BirthDate}); SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    db.Query<int>(command, client);
                    Console.WriteLine("Успешно добавлен!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void Read()
        {
            foreach (var item in SelectAll())
            {
                Console.WriteLine($"Id: {item.Id} |  LastName: {item.LastName} |  FirstName: {item.FirstName} |  BirthDate: {item.BirthDate}");
            }
        }
        public void Update()
        {
            Read();
            Console.WriteLine("Введите ID человека каторый вы хотели изменит его данны!!!");
            Console.Write("ID: ");
            int ID = int.Parse(Console.ReadLine()); Console.Clear();
            Client person = new Client();
            Console.Write("LastName: "); person.LastName = Console.ReadLine();
            Console.Write("FirstName: "); person.FirstName = Console.ReadLine();
            Console.Write("BirthYear: "); person.BirthDate = DateTime.Parse(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(conString))
                {
                    var command = $"UPDATE CLients SET LastName = '{person.LastName}', FirstName = '{person.FirstName}',BirthDate ={person.BirthDate} WHERE Id = {ID}";
                    db.Execute(command, person);
                    Console.WriteLine("Успешно изменено!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void Delete()
        {
            Read();
            DeleteById();
        }
    }
}
