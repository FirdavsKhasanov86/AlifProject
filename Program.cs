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

         
           //User
            string user = (Console.ReadLine());
            if (user =="2")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                 System.Console.WriteLine("Добро поджаловать в клиенткое окно:");
                 System.Console.WriteLine("===============================================");
                 Console.ForegroundColor = ConsoleColor.White;
               bool circle = true;
               while (circle){
                System.Console.WriteLine("1.Регистрация");
                System.Console.WriteLine("2.Вход");
                System.Console.WriteLine("3.Выход");
                string choise = Console.ReadLine();
                
                switch (choise){
                    
                    case "1": Registration(con); break; 
                    case "2": 
                                 Console.Write("Введите свой ранее введеный логин (номер телефон):");
                                 int login=int.Parse(Console.ReadLine());
                                 Console.Write("Введите свой ранее введеный пароль:");
                                 string pass=Console.ReadLine();
                                 SignIN(login, pass, con); circle = false;
                                 break;
                                  
               

                     case "3": circle = false; break;             
                }

               }
                      
                System.Console.WriteLine("Заполните анкету!");   
                System.Console.WriteLine("1.Aнкетa");         
                string app = Console.ReadLine();
                
                switch (app){
                    
                            case "1": AppRegistration(con); break;           
                           }

           }
           
         
        }            

            
        static void Registration(SqlConnection con)
        {
            Console.Clear();
            Console.Write("Введите свое имя:");
            string name = Console.ReadLine();
            Console.Write("Введите свою фамилию:");
            string last = Console.ReadLine();
            Console.Write("Введите свою отчество:");
            string mid = Console.ReadLine();
            Console.Write("Ввелите свой ИНН:");
            int inn=int.Parse(Console.ReadLine());
             Console.Write("Введите дату рождения:");
            string birth=Console.ReadLine();
            Console.Write("Вместо логина введите свой номер телефона:");
            int login=int.Parse(Console.ReadLine());
            Console.Write("Введите новый пароль:");
            string pass=Console.ReadLine();
            Console.Write("Повторите введенный пароль:");
            string pass2=Console.ReadLine();
            if (pass==pass2)
            {

            InsertRegistration(name,last, mid,inn,birth,login, pass, con);
            }
            else 
            {
                Console.WriteLine("Ваш пароль не совподаеть");
            }


        }



        static void InsertRegistration(string name, string last, string mid, int inn, string birth, int login, string pass, SqlConnection con)
        {
            con.Open();
            string insertSqlCommand = string.Format($"insert into Registration([Login],[Password],[FistName],[LastName],[MiddleName],[CustomerID],[BirthDate] ) Values('{login}','{pass}','{name}','{last}','{mid}','{inn}','{birth}')");
            SqlCommand command = new SqlCommand(insertSqlCommand, con);
            command = new SqlCommand(insertSqlCommand, con);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.Clear();
                Console.WriteLine("Регистрация успешно завершена.");
                Console.WriteLine("============================");
                Console.WriteLine("Зделайте вход для заполнение анкеты: ");
            }
            else 
            {
                Console.WriteLine("Неудачаный регистрация");
            }
                      
            con.Close();

            }

        static void SignIN(int login, string pass, SqlConnection con){
           con.Open();
           string textcommand = string.Format($"select * from Registration where Login='{login}' AND Password='{pass}' ");
              
            SqlCommand cm= new SqlCommand(textcommand,con);
            SqlDataReader rd = cm.ExecuteReader();
            int x=0;
            while(rd.Read())
            {
               x++;
                Console.Clear();
                Console.WriteLine("Ваши логин и пароль корректны");
            }
            if(x == 0)
            {
                Console.WriteLine("Логин или пароль был введён неверно");
                Console.WriteLine("Попробуйте ввести логин и пароль заново");
                Console.WriteLine("============================================");
                Console.Write("Введите свой ранее введеный логин (номер телефон):");
                
                                 int login1=int.Parse(Console.ReadLine());
                                 Console.Write("Введите свой ранее введеный пароль:");
                                 string pass1=Console.ReadLine();
                                 SignINrepeat(login1, pass1, con); 
            }
             
            con.Close();
        }
        
        static void SignINrepeat(int login1, string pass1, SqlConnection con){
           con.Close();
           con.Open();
           string textcommand = string.Format($"select * from Registration where Login='{login1}' AND Password='{pass1}' ");
              
            SqlCommand cm= new SqlCommand(textcommand,con);
            SqlDataReader rd = cm.ExecuteReader();
            int x=0;
            while(rd.Read())
            {
               x++;
                Console.Clear();
                Console.WriteLine("Ваши логин и пароль корректны");
            }
            
            if(x == 0)
            {
                Console.WriteLine("Логин или пароль был введён неверно");
                
            }
             
            con.Close();
        } 


         static void AppRegistration(SqlConnection con)
        {
            Console.Clear();
            Console.Write("Введите свое имя:");
            string name = Console.ReadLine();
            Console.Write("Введите свою фамилию:");
            string last = Console.ReadLine();
            Console.Write("Введите свою отчество:");
            string mid = Console.ReadLine();
            Console.WriteLine("Введите свой пол - если мужской то нажмите - 1:");
            Console.WriteLine("Введите свой пол - если женское то нажмите - 2:");
            
            int pol =int.Parse(Console.ReadLine());
            if( pol == 1){
                 pol = 1;
            }
            else if(pol == 2){
                pol = 2;
            }
            
            Console.WriteLine("Семейный статус:");
            Console.WriteLine("Если холост то наберте - 1");
            Console.WriteLine("Если семянин то наберте - 2");
            Console.WriteLine("Если вразводе то наберте - 3");
            Console.WriteLine("Если вдовец/вдова то наберте - 4");
            int stat =int.Parse(Console.ReadLine());
            if( stat == 1){
                 stat = 1;
            }
            else if(stat == 2){
                stat = 2;
            }
            else if(stat == 3){
                stat = 3;
            }
            else if(stat == 4){
                stat = 4;
            }
            Console.WriteLine("Укажите свой возраст:");
            int age =int.Parse(Console.ReadLine());
            Console.WriteLine("Если Вы гражданин Таджикистана то наберте - 1:");
            Console.WriteLine("Если Вы гражданин другой страны то наберте - 2:");
            int city =int.Parse(Console.ReadLine());
            
            InsertAppRegistration(name,last,mid,pol,stat,age,city, con);

             static void InsertAppRegistration(string name, string last, string mid, int pol, int stat, int age, int city, SqlConnection con)
           {
            con.Open();
            string insertSqlCommand = string.Format($"insert into UserInformation([FirstName],[LastName],[MiddleName],[Gender_id],[FamilyStatus_id],[Age],[Citizen_id]) Values('{name}','{last}','{mid}',{pol},{stat},{age},'{city}')");
            SqlCommand command = new SqlCommand(insertSqlCommand, con);
            command = new SqlCommand(insertSqlCommand, con);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.Clear();
                Console.WriteLine("Ваша анкeта успешно создана");
                Console.WriteLine("============================");
               // Console.WriteLine("Зделайте вход для заполнение анкеты: ");
            }
            else 
            {
                Console.WriteLine("Упс что то пошло не так!!!");

            }
                      
            con.Close();

            }


        }


        
     
    }
}
    

