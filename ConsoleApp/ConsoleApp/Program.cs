using ConsoleApp.Helpers;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        public enum Menu { CreateGroup=1,CreateStu,DeleteStu,ShowAllStu,SearchForName}
        static void Main(string[] args)
        {
            List<Group> groups = new List<Group>();
            while (true)
            {
                Helper.Print(ConsoleColor.Green,"Qrup yarat - 1,Telebe elave et - 2," +
                    "Telebe sil - 3,Telebelerin siyahisi - 4,Ada gore telebe axtar - 5, Chixish - 6");
                string result = Console.ReadLine();
                int menu;
                bool isInt = int.TryParse(result, out menu);

                if (isInt && menu>=1 && menu<=6)
                {
                    if (menu == 6)
                    {
                        break;
                    }

                    switch (menu)
                    {
                        case (int)Menu.CreateGroup:

                            Helper.Print(ConsoleColor.Blue, "Qrup adi daxil edin:");
                            string groupName = Console.ReadLine();
                            Group isExistGroup = groups.Find(g => g.Name.ToLower() == groupName.ToLower());
                            if (isExistGroup != null)
                            {
                                Helper.Print(ConsoleColor.Red, $"{groupName} adli qrup movcuddur");
                                goto case (int)Menu.CreateGroup;
                            }
                            writeMaxStuCount:
                            Helper.Print(ConsoleColor.Blue, "Maksimum telebe sayini daxil edin:");
                            result = Console.ReadLine();
                            int maxCount;
                            isInt = int.TryParse(result, out maxCount);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Zehmet olmasa eded daxil edin");
                                goto writeMaxStuCount;
                            }
                            Group newGroup = new Group(groupName, maxCount);
                            groups.Add(newGroup);
                            Helper.Print(ConsoleColor.Green, $"{groupName} adli qrup yaradildi!!!");

                            break;
                        case (int)Menu.CreateStu:

                            Helper.Print(ConsoleColor.Blue, "Telebe adi daxil edin:");
                            string name = Console.ReadLine().Trim();
                            Helper.Print(ConsoleColor.Blue, "Telebe soyadi daxil edin:");
                            string surname = Console.ReadLine().Trim();
                            SelectStudentGroup:
                            Helper.Print(ConsoleColor.Blue, "Qrup sechin:");
                            foreach (Group group in groups)
                            {
                                Helper.Print(ConsoleColor.Magenta, group.ToString());
                            }
                            string addGroup = Console.ReadLine().Trim();
                            isExistGroup = groups.Find(gr => gr.Name.ToLower() == addGroup.ToLower());
                            if (isExistGroup == null)
                            {
                                Helper.Print(ConsoleColor.Red, "Movcud qruplardan sechin!!!");
                                goto SelectStudentGroup;
                            }

                            Student newStudent = new Student(name, surname);
                            bool isAdded=isExistGroup.AddStu(newStudent);

                            if (isAdded)
                            {
                                Helper.Print(ConsoleColor.Green, "Telebe elave olundu");
                            }
                            else
                            {
                                Helper.Print(ConsoleColor.Red, $"{addGroup} adli qrup artiq doludur");
                                goto SelectStudentGroup;
                            }
                            break;
                        case (int)Menu.DeleteStu:
                            Helper.Print(ConsoleColor.Blue, "Silmek istediyiniz telebe 'Id'-ni sechin:");
                            foreach (Group group in groups)
                            {
                                group.ShowAllStu();
                            }

                            int id;
                            result = Console.ReadLine().Trim();
                            bool isId = int.TryParse(result, out id);
                            if (!isId)
                            {
                                Helper.Print(ConsoleColor.Red, $"Eded daxil edin!!!");
                                goto case (int)Menu.DeleteStu;
                            }

                            bool isDeleted=false;
                            foreach (Group group in groups)
                            {
                                isDeleted=group.RemoveStu(id);
                                if (isDeleted)
                                {
                                    break;
                                }
                            }
                            if (isDeleted)
                            {
                                Helper.Print(ConsoleColor.Green, $"{id} id-li telebe silindi");
                            }
                            else
                            {
                                Helper.Print(ConsoleColor.Red, "Daxil etdiyin 'Id' tapilmadi");
                                goto case (int)Menu.DeleteStu;
                            }
                            break;
                        case (int)Menu.ShowAllStu:
                            foreach(Group group in groups)
                            {
                                group.ShowAllStu();
                            }
                            break;
                        case (int)Menu.SearchForName:

                            Helper.Print(ConsoleColor.Blue, "Axtardiginiz telebe adini daxil edin:");
                            string search = Console.ReadLine().Trim();
                            foreach (Group group in groups)
                            {
                                foreach (Student stu in group.Search(search))
                                {
                                    Helper.Print(ConsoleColor.DarkYellow, stu.ToString());
                                }
                            }

                            break;
                    }
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "Zehmet olmasa gosterilen ededlerden sechin");
                }
            }
        }
    }
}
