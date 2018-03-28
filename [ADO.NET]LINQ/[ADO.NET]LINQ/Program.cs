using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ADO.NET_LINQ
{
    public class Persona
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public Persona(string name,int age,string city)
        {
            Name = name;
            Age = age;
            City = city;
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            List<Persona> persons = new List<Persona>()
            {
                new Persona("Andrey",24,"Kyiv"),
                new Persona("Liza",18,"Moscow"),
                new Persona("Oleg",15,"London"),
                new Persona("Sergey",55,"Kyiv"),
                new Persona("Alex",32,"Kyiv")
            };

            var res1 = from item in persons where item.Age > 25 select item;
            var res2 = from item in persons where item.City !="Kyiv" select item;
            var res3 = from item in persons where item.City == "Kyiv" select item.Name;

            var res4 = from item in persons where item.Age >= 35 && item.City == "Kyiv" select item;
            var res5 = from item in persons where item.City == "Moscow" select item;

            foreach (var item in res5)
            {
                Console.WriteLine(item.Name + " " + item.Age + " " + item.City);
            }
        }
    }
}
