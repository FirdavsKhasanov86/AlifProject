using System;
using System.Data.SqlClient;
using System.Data;

namespace AlifProject
{
    class Program
    {
       
        static void Main(string[] args)
        {
           
            string conString = @"Data source=192.168.103.137; Initial catalog=AlifProject; user id=sa; password=Sa123.";
            SqlConnection con = new SqlConnection(conString);
            Console.Clear();
            System.Console.WriteLine("Выберите свою роль Клиент/Администратор:");
            System.Console.WriteLine("Роль Администратор нажмите - 1");
            System.Console.WriteLine("Роль Клиент нажмите - 2");

         
           

          
        }            

            
        
     
    }
}
    

