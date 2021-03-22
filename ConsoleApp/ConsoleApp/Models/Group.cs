using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
    partial class Group
    {
        public string Name { get; set; }
        public int MaxCount { get; set; }
        private List<Student> _studentList;
        public int Id { get; set; }
        private static int _count = 1;

        public Group()
        {
            Id = _count++;
            _studentList = new List<Student>();
        }

        public Group(string groupName, int maxCount ):this()
        {
            Name = groupName;
            MaxCount = maxCount;
        }
    }
}
