using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>
            {
                new Computer(1, "Dell Inspiron 15", "Intel i5", 2500, 8, 500, 2, 1000.0, 10),
                new Computer(2, "HP Pavilion 14", "Intel i7", 3200, 16, 1000, 4, 1500.0, 5),
                new Computer(3, "Lenovo ThinkPad X1", "AMD Ryzen 5", 3000, 8, 750, 3, 1200.0, 7),
                new Computer(4, "Acer Aspire 5", "Intel i3", 2000, 4, 250, 1, 800.0, 15),
                new Computer(5, "Asus ROG Strix", "AMD Ryzen 7", 3500, 16, 1000, 4, 1600.0, 3),
                new Computer(6, "Apple MacBook Pro", "Intel i9", 4000, 32, 2000, 8, 2500.0, 2),
                new Computer(7, "Microsoft Surface Laptop", "AMD Ryzen 3", 2200, 4, 500, 2, 900.0, 12),
                new Computer(8, "MSI GF63 Thin", "Intel i5", 2500, 8, 500, 2, 1000.0, 8),
                new Computer(9, "Razer Blade 15", "Intel i7", 3200, 16, 1000, 4, 1500.0, 5),
                new Computer(10, "Huawei MateBook X Pro", "AMD Ryzen 5", 3000, 8, 750, 3, 1200.0, 6)
            };

            //Все компьютеры с указанным процессором
            Console.WriteLine("Введите итересующую модель процессора");
            string cpu = Console.ReadLine();

            List<Computer> computers1 = computers.Where(x=>x.CPU == cpu).ToList();
            Print(computers1);
            Console.ReadKey();

            //Все компьютеры с объемом ОЗУ не ниже, чем указано
            Console.WriteLine("Введите минимальный объем ОЗУ(RAM)");
            int ram = Convert.ToInt32(Console.ReadLine());

            List<Computer> computers2 = computers.Where(x => x.RAM >= ram).ToList();
            Print(computers2);
            Console.ReadKey();

            //весь список, отсортированный по увеличению стоимости
            List<Computer> computers3 = computers.OrderByDescending(x=>x.Price).ToList();
            Print(computers3);
            Console.ReadKey();

            //весь список, сгруппированный по типу процессора
            IEnumerable<IGrouping<string, Computer>> computers4 = computers.OrderByDescending(x => x.CPU).GroupBy(x=>x.CPU);
            foreach (IGrouping<string, Computer> gr in computers4)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer comp in gr)
                {
                    Console.WriteLine($"Code: {comp.Code}, Name: {comp.Name}, CPU: {comp.CPU} " +
                                                      $"({comp.CPUFrequency} MHz), RAM: {comp.RAM} GB, " +
                                                      $"HDD: {comp.HDD} GB, GPU: {comp.GPU} GB, ${comp.Price}, " +
                                                      $"In Stock: {comp.InStock}");
                }
            }
            Console.WriteLine("----------------------------------\n");
            Console.ReadKey();

            //Самый дорогой и самый бюджетный компьютер
            Computer computerMostExpensive = computers.OrderByDescending(x => x.Price).First();
            Computer computerCheapest = computers.OrderBy(x => x.Price).First();
            Console.WriteLine($"Самый дорогой компьютер:\nCode: {computerMostExpensive.Code}, Name: {computerMostExpensive.Name}, " +
                $"CPU: {computerMostExpensive.CPU} ({computerMostExpensive.CPUFrequency} MHz), RAM: {computerMostExpensive.RAM} GB, " +
                $"HDD: {computerMostExpensive.HDD} GB, GPU: {computerMostExpensive.GPU} GB, ${computerMostExpensive.Price}, " +
                $"In Stock: {computerMostExpensive.InStock}");
            Console.WriteLine($"Самый дешевый компьютер:\nCode: {computerCheapest.Code}, Name: {computerCheapest.Name}, " +
                $"CPU: {computerCheapest.CPU} ({computerCheapest.CPUFrequency} MHz), RAM: {computerCheapest.RAM} GB, " +
                $"HDD: {computerCheapest.HDD} GB, GPU: {computerCheapest.GPU} GB, ${computerCheapest.Price}, " +
                $"In Stock: {computerCheapest.InStock}");
            Console.WriteLine("----------------------------------\n");
            Console.ReadKey();

            //есть ли хотя бы один компьютер в количестве не менее 30 штук?
            bool isAvailable = computers.Any(x => x.InStock >= 30);
            if (isAvailable)
                Console.WriteLine("Имеется компьютер в количестве 30 шт");
            else
                Console.WriteLine("Нет доступных компьютеров в количестве 30 шт");
            Console.WriteLine("----------------------------------\n");
            Console.ReadKey();
        }

        static void Print (List<Computer> comps)
        {
            foreach (Computer comp in comps)
            {
                Console.WriteLine($"Code: {comp.Code}, Name: {comp.Name}, CPU: {comp.CPU} " +
                                  $"({comp.CPUFrequency} MHz), RAM: {comp.RAM} GB, " +
                                  $"HDD: {comp.HDD} GB, GPU: {comp.GPU} GB, ${comp.Price}, " +
                                  $"In Stock: {comp.InStock}");
            }
            Console.WriteLine("----------------------------------\n");
        }
    }
}
