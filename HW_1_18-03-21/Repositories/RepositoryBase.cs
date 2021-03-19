using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HW_1_18_03_21.Repositories
{
    public class RepositoryBase<T>
    {
        public string conString { get; private set; }
        public RepositoryBase()
        {
            conString = "Data source=DESKTOP-G6SLUNJ; Initial catalog=TNU; Integrated security=true;";
        }
        public List<T> SelectAll()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(conString))
                {
                    return db.Query<T>($"SELECT * FROM Clients").ToList();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                return null;
            }
        }
        public void DeleteById()
        {
            Console.WriteLine("Введите ID человека каторый вы хотели удалить его данны!!!");
            Console.Write("ID: "); int ID = int.Parse(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(conString))
                {
                    var command = $"DELETE FROM Clients WHERE Id ={ID}";
                    db.Execute(command, new { ID });
                    Console.WriteLine("Успешно удален!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
       
    }
}
