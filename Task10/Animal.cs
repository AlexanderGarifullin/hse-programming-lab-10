using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    public class Animal: IInit, ICloneable
    {
        static Random rnd = new Random();
        static string[] Names = { "Кошка", "Собака", "Мышь", "Еж", "Лошадь", "Волк", "Лиса", "Медведь" };
        public string Name { get; set; }
        public IdNumber id;
        int age;
        public int Age
        {
            get => age;
            set
            {
                if (value > 0 && value < 30)
                    age = value;
                else
                {
                    Console.WriteLine("Error!");
                    age = 1;
                }
            }
        }
        public Animal()
        {
            Name = "NoName";
            Age = 1;
            id = new IdNumber(1);
        }
        public Animal(int num, string name, int age)
        {
            Name = name;
            Age = age;
            id = new IdNumber(num);
        }
        public override string ToString()
        {
            return id.number + ": " + Name + ", " + Age;
        }
        public override bool Equals(object obj)
        {
            if (obj is Animal Animal)
                return this.Age == Animal.Age && String.Compare(this.Name, Animal.Name) == 0
                    && this.id.number == Animal.id.number;
            return false;
        }
        public void Init()
        {
            Name = Names[rnd.Next(Names.Length)];
            Age = rnd.Next(1, 30);
            id = new IdNumber(rnd.Next(2, 100));
        }

        public object Clone() // глубокое копирование
        {
            return new Animal(this.id.number, this.Name, this.Age);
        }
        public object ShallowCopy() // поверхностное копирование, скопирутет только ссылку
        {
            return this.MemberwiseClone();
        }
    }
}
