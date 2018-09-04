using System;
using System.Collections.Generic;
using System.IO;

namespace РИС_Лаб_1
{
    class Program
    {

        private String sweet;
        private String factory;
        private long price;


        public Program(String sweet, String factory, long price){
            this.sweet = sweet;
            this.factory = factory;
            this.price = price;
        }


        static void Main(string[] args)
        {
            String choice;
            do
            {
                Console.WriteLine("Выберите пункт:\n" +
                                  " 1 - Ввести новый пункт\n" +
                                  " 2 - Посмотреть продажи конфет\n" +
                                  " 3 - Посмотреть конкретную фабрику\n" +
                                  " 4 - Удалить запись\n" +
                                  " 5 - Редактировать запись\n" +
                                  " 6 - Сортировать по фабрикам\n" +
                                  " 7 - Выход");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите название конфет, цену и количество:"); //чтение вводимых данных
                            String sweet = Console.ReadLine();
                            String factory = Console.ReadLine();
                            long price = System.Int64.Parse(Console.ReadLine());
                            Program obj = new Program(sweet, factory, price);
                            //открытие файла с данными на запись
                            FileStream fileStream = new FileStream("file.txt", FileMode.OpenOrCreate, FileAccess.Write);
                            fileStream.Seek(0, SeekOrigin.End);
                            StreamWriter streamWriter = new StreamWriter(fileStream);
                            //запись в файл
                            streamWriter.WriteLine(obj.sweet + " " + obj.factory + " " + obj.price.ToString() + " "); 
                            streamWriter.Close();
                            fileStream.Close();
                            break;
                        }
                    case "2":
                        {
                            string[] lines = File.ReadAllLines("file.txt");
                            foreach (string sweet in lines)
                            {
                                Console.WriteLine(sweet + '\n');
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Введите название кондитерской фабрики");
                            String sweetFactory = Console.ReadLine();
                            string[] sweetFactoryData = File.ReadAllLines("file.txt");
                            foreach (string sweet in sweetFactoryData)
                            {
                                String sweetData = sweet.Substring(0, sweet.IndexOf(" "));
                                if (sweetData == sweetFactory)
                                {
                                    Console.WriteLine(sweet);
                                }
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Введите название конфет и фабрику для удаления записи");
                            String sweet = Console.ReadLine();
                            String factory = Console.ReadLine();
                            string[] sweetFactoryData = File.ReadAllLines("file.txt");

                            List<String> list = new List<String>();
                            foreach(string abc in sweetFactoryData){
                                string[] sweetData = abc.Split(" ");
                                if(sweetData[0]!=sweet && sweetData[1]!=factory){
                                    list.Add(abc);
                                }
                            }
                            list.ToArray();
                            FileStream fcreate = File.Open("file.txt", FileMode.Create);
                            foreach(string abd in list){
                                
                            }
                            break;
                        }
                    case "5": break;
                    case "6": break;
                    case "7": Environment.Exit(0); break;
                }
            } while (choice != "7");
        }
    }
}
