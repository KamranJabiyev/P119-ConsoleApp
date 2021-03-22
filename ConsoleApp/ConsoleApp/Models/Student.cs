using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get;}
        private static int _count = 1;
        public Student()
        {
            Id = _count++;
        }
        public Student(string name, string surname):this()
        {
            Name = name;
            Surname = surname;
        }
        public override string ToString()
        {
            return $"{Id} - {Name} {Surname}"; 
        }

    }
}
