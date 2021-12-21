using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_19
/*1. Модель компьютера характеризуется кодом и  названием  марки компьютера,  типом  процессора,  
 * частотой  работы  процессора,  объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты,
 * стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии. Создать список, 
 * содержащий 6-10 записей с различным набором значений характеристик.

Определить:
- все компьютеры с указанным процессором. Название процессора запросить у пользователя;
- все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
- вывести весь список, отсортированный по увеличению стоимости;
- вывести весь список, сгруппированный по типу процессора;
- найти самый дорогой и самый бюджетный компьютер;
- есть ли хотя бы один компьютер в количестве не менее 30 штук?*/
{
    class Компьютер
    {
        public int Код;
        public string Модель = string.Empty;
        public string Типпроцессора = string.Empty;
        public int Память;
        public int Цена;
        public int Количесво;


        public static void Main(string[] args)
        {
            {
                List<Компьютер> listКомпьютер = new List<Компьютер>()
                {
                   new Компьютер{ Код=1, Модель = "Аsus" ,Типпроцессора="Intel" ,
                   Память=4, Цена=30000, Количесво=5},
                   new Компьютер{ Код= 2, Модель = "HP" ,Типпроцессора="Intel",
                   Память=5, Цена=40000, Количесво=10},
                   new Компьютер{ Код= 3, Модель = "Аser" ,Типпроцессора="Pentium",
                   Память=6, Цена=50000, Количесво=15},
                   new Компьютер{ Код= 4, Модель = "Lenovo" ,Типпроцессора="Pentium",
                   Память=5, Цена=60000, Количесво=20},
                   new Компьютер{ Код= 5, Модель = "Apple imac" ,Типпроцессора="Pentium",
                   Память=5, Цена=100000, Количесво=20},
                   new Компьютер{ Код= 6, Модель = "Sony" ,Типпроцессора="Intel",
                   Память=8, Цена=110000, Количесво=35},
               };
                Console.WriteLine("Типпроцессора = Pentium");
                IEnumerable<Компьютер> компьютерs = (from d in listКомпьютер

                                                     where d.Типпроцессора == "Pentium"
                                                     select d).ToList();
                foreach (Компьютер d in компьютерs)
                {
                    Console.WriteLine($"{d.Код} {d.Типпроцессора}");
                }
                Console.WriteLine();
                Console.WriteLine("память >4");
                List<Компьютер> компьютерs2 = (from d in listКомпьютер
                                               where d.Память > 4
                                               select d).ToList();
                foreach (Компьютер d in компьютерs2)
                    Console.WriteLine($"{d.Код},{d.Память}");
                Console.WriteLine();
                Console.WriteLine("список по увеличению стоимости");
                List<Компьютер> компьютерs3 = (from d in listКомпьютер
                                               orderby d.Цена
                                               select d).ToList();

                foreach (Компьютер d in компьютерs3)
                {
                    Console.WriteLine($"{d.Код},{d.Модель},{d.Типпроцессора},{d.Память},{d.Цена},{d.Количесво}");
                }

                Console.WriteLine();
                Console.WriteLine("вывести весь список, сгруппированный по типу процессора");
                var КомпьютерGroups = from Компьютер in listКомпьютер
                                      group Компьютер by Компьютер.Типпроцессора;

                foreach (IGrouping<string, Компьютер> g in КомпьютерGroups)
                {
                    Console.WriteLine(g.Key);
                    foreach (var t in g)
                        Console.WriteLine(t.Модель);

                }
                Console.WriteLine();
                Console.WriteLine("найти самый бюджетный и самый дорогой  компьютер");

         
                int[] цена = { 30000, 40000, 50000, 60000, 100000, 110000 };
         
                int min = цена.Min();
                Console.WriteLine(min);

                int Max = цена.Max();
                Console.WriteLine(Max);

                Console.WriteLine();
                Console.WriteLine("есть ли хотя бы один компьютер в количестве не менее 30 штук?");
                bool result1 = listКомпьютер.Any(u => u.Количесво>=30); 
                if (result1)
                    Console.WriteLine("Есть компьютер в количестве больше 30"); 
                else
                    Console.WriteLine("компьютер в количестве меньше 30");

                Console.ReadKey();
                }
            }


        }
    }


