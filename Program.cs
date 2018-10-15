using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace РИС_Лаб_1
{
    class SweetFactory
    {

        private String sweet;
        private long price;
        private long quantity;

        public SweetFactory(String sweet, long price, long quantity){
            this.sweet = sweet;
            this.price = price;
            this.quantity = quantity;
        }

        public String toString
        {
            get
            {
                return this.sweet + " " + this.price + " " + this.quantity;
            }
        }

        public static void PrintArray(string[] sweets){
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|            Название| Цена| Количество|");
            Console.WriteLine("----------------------------------------");
            foreach (string sweet in sweets)
            {
                string[] sweetNew = sweet.Split(' ');
                Console.WriteLine(String.Format("|{0,20}|{1,5}|{2,11}|", sweetNew[0], sweetNew[1], sweetNew[2]));
                Console.WriteLine("----------------------------------------");
            }
        }

        static void Main(string[] args)
        {
            String choice;
            do
            {
                Console.WriteLine("Выберите пункт:\n" +
                                  " 1 - Ввести новый пункт\n" +
                                  " 2 - Посмотреть продажи конфет\n" +
                                  " 3 - Поиск конфет по названию\n" +
                                  " 4 - Удалить наименование конфет\n" +
                                  " 5 - Редактировать наименование конфет\n" +
                                  " 6 - Сортировать по наименованиям\n" +
                                  " 7 - Выход");
                choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите название конфет: ");
                            String sweet = Console.ReadLine();
                            Console.WriteLine("Введите цену: ");
                            long price = System.Int64.Parse(Console.ReadLine());
                            Console.WriteLine("Введите количество: ");
                            long quantity = System.Int64.Parse(Console.ReadLine());
                            SweetFactory sweetFactory = new SweetFactory(sweet, price, quantity);
                            //открытие файла с данными на запись
                            FileStream fileStream = new FileStream("file.txt", FileMode.OpenOrCreate, FileAccess.Write);
                            fileStream.Seek(0, SeekOrigin.End);
                            StreamWriter streamWriter = new StreamWriter(fileStream);
                            //запись в файл
                            streamWriter.WriteLine(sweetFactory.toString); 
                            streamWriter.Close();
                            fileStream.Close();
                            Console.Clear();
                            Console.WriteLine("Конфеты успешно добавлены в ассортимент фабрики\n");
                            break;
                        }
                    case "2":
                        {
                            string[] sweets = File.ReadAllLines("file.txt");
                            SweetFactory.PrintArray(sweets);
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Введите название конфет: ");
                            String sweetSearch = Console.ReadLine();
                            string[] sweets = File.ReadAllLines("file.txt");
                            ArrayList sweetArray = new ArrayList();
                            foreach(string sweet in sweets) {
                                string[] sweetNew = sweet.Split(' ');
                                if (sweetNew[0] == sweetSearch) {
                                    sweetArray.Add(sweet);
                                }
                            }
                            SweetFactory.PrintArray((string[])sweetArray.ToArray(typeof(string)));
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Введите наименование конфет для удаления");
                            String sweetDelete = Console.ReadLine();
                            string[] sweets = File.ReadAllLines("file.txt");

                            FileStream fileStream = File.Open("file.txt", FileMode.Create);
                            StreamWriter streamWriter = new StreamWriter(fileStream);

                            foreach (string sweet in sweets)
                            {
                                string[] sweetNew = sweet.Split(' ');
                                if (sweetNew[0] != sweetDelete)
                                {
                                    streamWriter.WriteLine(sweet);
                                }
                            }

                            streamWriter.Close();
                            fileStream.Close();
                            Console.Clear();
                            Console.WriteLine("Наименование конфет успешно удалено\n");
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Введите наименование конфет для редактирования");
                            String sweetEditing = Console.ReadLine();
                            string[] sweets = File.ReadAllLines("file.txt");

                            FileStream fileStream = File.Open("file.txt", FileMode.Create);
                            StreamWriter streamWriter = new StreamWriter(fileStream);

                            foreach (string sweet in sweets)
                            {
                                string[] sweetNew = sweet.Split(' ');
                                if (sweetNew[0] == sweetEditing)
                                {
                                    Console.WriteLine("Введите название конфет: ");
                                    String sweetName = Console.ReadLine();
                                    Console.WriteLine("Введите цену: ");
                                    long price = System.Int64.Parse(Console.ReadLine());
                                    Console.WriteLine("Введите количество: ");
                                    long quantity = System.Int64.Parse(Console.ReadLine());
                                    streamWriter.WriteLine(sweetName + " " + price + " " + quantity);
                                    Console.Clear();
                                    Console.WriteLine("Наименование конфет успешно отредактировано\n");
                                } else {
                                    streamWriter.WriteLine(sweet);
                                }
                            }
                            streamWriter.Close();
                            fileStream.Close();
                            break;
                        }
                    case "6": 
                        {
                            string[] sweets = File.ReadAllLines("file.txt");
                            Array.Sort(sweets);
                            SweetFactory.PrintArray(sweets);
                            break;
                        }
                    case "7": Environment.Exit(0); break;
                }
            } while (choice != "7");
        }
    }
}
