using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson19
{
    internal class Computer
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string CPU { get; set; }
        public int CPUFrequency { get; set; }
        public int RAM { get; set; }
        public int HDD { get; set; }
        public int GPU { get; set; }
        public double Price{ get; set; }
        public int InStock { get; set; }

        public Computer (int code, string name, string cpu, int cpuFrequency, 
                        int ram, int hdd, int gpu, double price, int inStock)
        {
            Code = code;
            Name = name;
            CPU = cpu;
            CPUFrequency = cpuFrequency;
            RAM = ram;
            HDD = hdd;
            GPU = gpu;
            Price = price;
            InStock = inStock;
        }
    }
}
