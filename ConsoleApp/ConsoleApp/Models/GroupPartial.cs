using ConsoleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
    partial class Group
    {
        public override string ToString()
        {
            return Name;
        }

        public bool AddStu(Student student)
        {
            if (_studentList.Count < MaxCount)
            {
                _studentList.Add(student);
                return true;
            }
            return false;
        }

        public bool RemoveStu(int id)
        {
            Student isExistStu = _studentList.Find(s => s.Id == id);
            if (isExistStu != null)
            {
                _studentList.Remove(isExistStu);
                return true;
            }
            return false;
        }

        public void ShowAllStu()
        {
            Helper.Print(ConsoleColor.Blue, $"{Name}-un siyahisi:");
            foreach (Student stu in _studentList)
            {
                Helper.Print(ConsoleColor.Cyan, stu.ToString());
            }
        }

        public List<Student> Search(string name)
        {
             return _studentList.FindAll(s => s.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
