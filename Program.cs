using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace School
{

    public class Student
    {
        public int ID;
        public string FirstName;
        public string LastName;
        public int Age;

        public Student(int id, string firstName, string lastName, int age)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
    public class School
    {
        public string Name;
        public List<Student> Students;

        public School(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public void AddNewStudent(Student new_student)
        {
            Console.Clear();
            Students.Add(new_student);
            Console.WriteLine($"Студент {new_student.FirstName} добавлен в школу {Name}");
            Console.WriteLine("\n \nДля продолжения нажмите Enter");
            Console.ReadLine();
            Console.Clear();
        }

        public void PrintStudents()
        {
            Console.Clear();
            Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-10}", "ID", "Имя", "Фамилия", "Возраст");

            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine("\n{0, -10} {1, -10} {2, -10} {3 , -10}", Students[i].ID, Students[i].FirstName, Students[i].LastName, Students[i].Age);
            }

            Console.WriteLine("\n\nДля продолжения нажмите Enter.");
            Console.ReadLine();
            Console.Clear();
        }
        public void DeleteStudent()
        {
            Console.Clear();
            Console.WriteLine($"Укажите ID студента для удаления");
            int id = 0;
            string id1 = Console.ReadLine();

            while (int.TryParse(id1, out id) == false)
            {
                Console.WriteLine("Необходимо ввести целое число!");
                id1 = Console.ReadLine();
            }
            id = int.Parse(id1);

            if ((id > Students.Count - 1) || (id < 0))
            {
                Console.WriteLine("Такого индекса не существует! \n\nНажмите Enter для возврата в меню.");
                Console.ReadLine();
                Console.Clear();
                return;              
            }



                Console.WriteLine($"Студент ID:{Students[id].ID} успешно удалён. \n\nНажмите Enter для возврата в меню.");
            Students.RemoveAt(id);
            Console.ReadLine();
            Console.Clear();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Введите название школы:");
            string school_name = Console.ReadLine();
            School school = new School(school_name);
            Console.Clear();
            int id = 0;




            while (true)
            {
                Console.WriteLine($"Меню \n\n1. Добавить \n2. Список студентов \n3. Удалить \n4. Выход");
                string answer = Console.ReadLine();

                if (answer == "1")
                {
                    Console.Clear();
                    Console.WriteLine($"Введите имя:");
                    string FistName = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"Введите фамилию:");
                    string LastName = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"Введите возраст:");
                    string age1 = Console.ReadLine();
                    int age = 0;

                    while (int.TryParse(age1, out age) == false)
                    {
                        Console.WriteLine("Необходимо ввести целое число!");
                        age1 = Console.ReadLine();
                    }


                    age = int.Parse(age1);
                    Student new_student = new Student(id++, FistName, LastName, age); // создали объект нового студента
                    school.AddNewStudent(new_student);
                    continue;
                }

                if (answer == "2")
                {
                    school.PrintStudents();
                    continue;
                }

                if (answer == "3")
                {
                    Console.Clear();
                    school.DeleteStudent();
                    continue;
                }

                if (answer == "4")
                {
                    Environment.Exit(0);
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Введено неизвестное значение...\nДля продолжения нажмите Enter.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }




            }





        }
    }
}