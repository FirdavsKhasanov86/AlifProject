﻿using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

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
            if (user == "2")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("Добро поджаловать в клиенткое окно:");
                System.Console.WriteLine("===============================================");
                Console.ForegroundColor = ConsoleColor.White;
                bool circle = true;
                while (circle)
                {
                    System.Console.WriteLine("1.Регистрация");
                    System.Console.WriteLine("2.Вход");
                    System.Console.WriteLine("3.Выход");
                    string choise = Console.ReadLine();

                    switch (choise)
                    {

                        case "1": Registration(con); break;
                        case "2":
                            Console.Write("Введите свой ранее введеный логин (номер телефон):");
                            int login = int.Parse(Console.ReadLine());
                            Console.Write("Введите свой ранее введеный пароль:");
                            string pass = Console.ReadLine();
                            SignIN(login, pass, con); circle = false;
                            break;



                        case "3": circle = false; break;
                    }

                }

                System.Console.WriteLine("Заполните анкету!");
                System.Console.WriteLine("1.Aнкетa");
                string app = Console.ReadLine();

                switch (app)
                {

                    case "1": AppRegistration(con); break;
                }

            }
            //Admin
            if (user == "1")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("Добро поджаловать в Aдминистративное окно:");
                System.Console.WriteLine("===============================================");
                Console.ForegroundColor = ConsoleColor.White;
                bool circle = true;
                while (circle)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Выберите из ниже следующих функции:");
                    Console.WriteLine("1.Посмотреть все информации о всех клиентах");
                    Console.WriteLine("2.Выбрать клиента по ID - индентификационный номер клиента");
                    Console.WriteLine("3.Добавить нового клиента");
                    Console.WriteLine("4.Обновить (добавить) информацию о клиенте по ID");
                    Console.WriteLine("5.Удалить информацию о клиенте по ID");
                    // Console.ForegroundColor = ConsoleColor.White;
                    string choise = Console.ReadLine();

                    switch (choise)
                    {

                        case "1": SelectAllUsers(con); break;
                        case "2":
                            {


                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("Выберите любого клиента по номеру - ID:");
                                int num = int.Parse(Console.ReadLine());
                                SelectUserBy(num, con);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }
                        case "3": AppRegistration(con); break;
                        case "4":
                            {
                                Console.Write("Выберите для обнавление номер ID клиента:");
                                int num = int.Parse(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("Введите имя клиента:");
                                string Name = Console.ReadLine();
                                Console.Write("Введите фамилию клиента:");
                                string SureName = Console.ReadLine();
                                Console.Write("Введите отчество клиента:");
                                string MiddleName = Console.ReadLine();
                                Console.WriteLine("Введите свой пол - если мужской то нажмите - 1:");
                                Console.WriteLine("Введите свой пол - если женское то нажмите - 2:");

                                int pol = int.Parse(Console.ReadLine());
                                if (pol == 1)
                                {
                                    pol = 1;
                                }
                                else if (pol == 2)
                                {
                                    pol = 2;
                                }

                                Console.WriteLine("Семейный статус:");
                                Console.WriteLine("Если холост то наберте - 1");
                                Console.WriteLine("Если семянин то наберте - 2");
                                Console.WriteLine("Если вразводе то наберте - 3");
                                Console.WriteLine("Если вдовец/вдова то наберте - 4");
                                int stat = int.Parse(Console.ReadLine());
                                if (stat == 1)
                                {
                                    stat = 1;
                                }
                                else if (stat == 2)
                                {
                                    stat = 2;
                                }
                                else if (stat == 3)
                                {
                                    stat = 3;
                                }
                                else if (stat == 4)
                                {
                                    stat = 4;
                                }
                                Console.WriteLine("Укажите свой возраст:");
                                int age = int.Parse(Console.ReadLine());
                                Console.WriteLine("Если Вы гражданин Таджикистана то наберте - 1:");
                                Console.WriteLine("Если Вы гражданин другой страны то наберте - 2:");
                                int city = int.Parse(Console.ReadLine());



                                UpdateUserInfo(Name, SureName, MiddleName, pol, stat, age, city, num, con);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            }

                        case "5":
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("Введите id клиента для удаление из базы данных:");
                                int num = int.Parse(Console.ReadLine());
                                DeleteUserById(num, con);
                                Console.ForegroundColor = ConsoleColor.White; break;
                            }



                        case "6": circle = false; break;
                    }

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
            int inn = int.Parse(Console.ReadLine());
            Console.Write("Введите дату рождения:");
            string birth = Console.ReadLine();
            Console.Write("Вместо логина введите свой номер телефона:");
            int login = int.Parse(Console.ReadLine());
            Console.Write("Введите новый пароль:");
            string pass = Console.ReadLine();
            Console.Write("Повторите введенный пароль:");
            string pass2 = Console.ReadLine();
            if (pass == pass2)
            {

                InsertRegistration(name, last, mid, inn, birth, login, pass, con);
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

        static void SignIN(int login, string pass, SqlConnection con)
        {
            con.Open();
            string textcommand = string.Format($"select * from Registration where Login='{login}' AND Password='{pass}' ");

            SqlCommand cm = new SqlCommand(textcommand, con);
            SqlDataReader rd = cm.ExecuteReader();
            int x = 0;
            while (rd.Read())
            {
                x++;
                Console.Clear();
                Console.WriteLine("Ваши логин и пароль корректны");
            }
            if (x == 0)
            {
                Console.WriteLine("Логин или пароль был введён неверно");
                Console.WriteLine("Попробуйте ввести логин и пароль заново");
                Console.WriteLine("============================================");
                Console.Write("Введите свой ранее введеный логин (номер телефон):");

                int login1 = int.Parse(Console.ReadLine());
                Console.Write("Введите свой ранее введеный пароль:");
                string pass1 = Console.ReadLine();
                SignINrepeat(login1, pass1, con);
            }

            con.Close();
        }

        static void SignINrepeat(int login1, string pass1, SqlConnection con)
        {
            con.Close();
            con.Open();
            string textcommand = string.Format($"select * from Registration where Login='{login1}' AND Password='{pass1}' ");

            SqlCommand cm = new SqlCommand(textcommand, con);
            SqlDataReader rd = cm.ExecuteReader();
            int x = 0;
            while (rd.Read())
            {
                x++;
                Console.Clear();
                Console.WriteLine("Ваши логин и пароль корректны");
            }

            if (x == 0)
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

            int pol = int.Parse(Console.ReadLine());
            if (pol == 1)
            {
                pol = 1;
            }
            else if (pol == 2)
            {
                pol = 2;
            }

            Console.WriteLine("Семейный статус:");
            Console.WriteLine("Если холост то наберте - 1");
            Console.WriteLine("Если семянин то наберте - 2");
            Console.WriteLine("Если вразводе то наберте - 3");
            Console.WriteLine("Если вдовец/вдова то наберте - 4");
            int stat = int.Parse(Console.ReadLine());
            if (stat == 1)
            {
                stat = 1;
            }
            else if (stat == 2)
            {
                stat = 2;
            }
            else if (stat == 3)
            {
                stat = 3;
            }
            else if (stat == 4)
            {
                stat = 4;
            }
            Console.WriteLine("Укажите свой возраст:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Если Вы гражданин Таджикистана то наберте - 1:");
            Console.WriteLine("Если Вы гражданин другой страны то наберте - 2:");
            int city = int.Parse(Console.ReadLine());

            InsertAppRegistration(name, last, mid, pol, stat, age, city, con);

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


        //admin method
        //selectAll
        static void SelectAllUsers(SqlConnection con)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            con.Open();
           // string commandText = "Select * from UserInformation";
            string commandText = $"SELECT * FROM [UserInformation] O  JOIN [Gender] I ON O.Gender_id = I.Id  JOIN [FamilyStat] P ON O.FamilyStatus_id = P.Id Join [Citizen] C On C.Id = O.Citizen_id";
            SqlCommand command = new SqlCommand(commandText, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                System.Console.WriteLine($"ID:{reader.GetValue("Id")}, FirstName:{reader.GetValue("FirstName")}, LastName:{reader.GetValue("LastName")}, MiddleName:{reader.GetValue("MiddleName")},Gender_id:{reader.GetValue("Gender_id")}, FamilyStatus_id:{reader.GetValue("FamilyStatus_id")},Age:{reader.GetValue("Age")},Citizen_id:{reader.GetValue("Citizen_id")}");
            }
            reader.Close();
            Console.ForegroundColor = ConsoleColor.White;
        }

        //selectById
        static void SelectUserBy(int num, SqlConnection con)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            con.Open();
            string commandText1 = ($"Select * from UserInformation where id = {num}");
            SqlCommand command = new SqlCommand(commandText1, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                System.Console.WriteLine($"ID:{reader.GetValue(0)}, FirstName:{reader.GetValue(2)}, LastName:{reader.GetValue(3)}, MiddleName:{reader.GetValue(4)},Gender_id:{reader.GetValue(5)}, FamilyStatus_id:{reader.GetValue(6)},Age:{reader.GetValue(7)},Citizen_id:{reader.GetValue(8)}");
            }
            reader.Close();
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Update
        static void UpdateUserInfo(string Name, string SureName, string MiddleName, int pol, int stat, int age, int city, int num, SqlConnection con)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            con.Open();
            string commandText1 = ($"Update UserInformation set FirstName='{Name}',LastName='{SureName}',MiddleName='{MiddleName}',Gender_id={pol},FamilyStatus_id={stat},Age={age},Citizen_id={city} where id = {num}");
            SqlCommand command = new SqlCommand(commandText1, con);
            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                System.Console.WriteLine("Информация о клиенте обновлена!!!");
            }
            con.Close();
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Delete
        static void DeleteUserById(int num, SqlConnection con)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            con.Open();
            string commandText1 = ($"Delete from UserInformation where id = {num}");
            SqlCommand command = new SqlCommand(commandText1, con);

            var result = command.ExecuteNonQuery();
            if (result > 0)
            {
                System.Console.WriteLine("Информация о клиенте удалена!!");
            }
            con.Close();
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
    
}


