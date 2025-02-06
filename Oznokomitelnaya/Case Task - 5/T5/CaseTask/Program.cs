using System;
using System.Collections.Generic;

namespace CaseTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool canRun
            StudentList studentList = new StudentList();

            StartingStudents(studentList);
            ShowStudentList(studentList);
            Console.WriteLine("Для списка команд напишите [-help]");
            ReciveCommand(studentList);

            
        }

        static void StartingStudents(StudentList studentList)
        {
            Student student1 = new Student("Dmitriy", 18, 3.4, "1A");
            Student student2 = new Student("Mikhail", 17, 4.3, "1A");
            Student student3 = new Student("Danil", 18, 3.1, "1B");
            Student student4 = new Student("Aleksandr", 20, 3.7, "2A");
            Student student5 = new Student("Ivan", 21, 2.5, "2B");
            Student student6 = new Student("Kiril", 21, 2.4, "2B");
            Student student7 = new Student("Daria", 20, 4.5, "2A");

            studentList.AddStudent(student1);
            studentList.AddStudent(student2);
            studentList.AddStudent(student3);
            studentList.AddStudent(student4);
            studentList.AddStudent(student5);
            studentList.AddStudent(student6);
            studentList.AddStudent(student7);
        }

        static void ShowStudentList(StudentList studentList)
        {
            //Console.Clear();
            Console.WriteLine("[Ученики]");

            foreach (var student in studentList.students)
            {
                Console.WriteLine($"- {student.Name} | {student.Age} | {student.Grade} | {student.Group}");
            }
        }

        static void ReciveCommand(StudentList studentList){
            bool endProgram = false;
            string commandPrompt = Console.ReadLine();
            string[] subParts = commandPrompt.Split(' ');

            switch (subParts[0]){
                case "-list":
                    //Console.Clear();
                    ShowStudentList(studentList);
                    
                break;
                case "-find":
                    //Console.Clear();
                    FindStudent(studentList, subParts);
                    
                break;
                case "-group":
                    //Console.Clear();
                    FindGroup(studentList, subParts);
                    
                break;
                case "-add":
                    //Console.Clear();
                    AddStudentToList(studentList, subParts);

                break;
                case "-grade":
                    //Console.Clear();
                    GradeStudent(studentList, subParts);
                   
                break;
                case "-gradeAll":
                    //Console.Clear();
                    GradeEveryone(studentList, subParts);
                   
                break;
                case "-help":
                    //Console.Clear();
                    Console.WriteLine("[Команды]");
                    Console.WriteLine("[-list] - Показывает список со всеми студентами");
                    Console.WriteLine("[-add (Имя) (Возраст) (Баллы) (Группа|eng)] - Добавляет студента в список (без скобок)");
                    Console.WriteLine("[-find (Имя)] - Находит студента по имени");
                    Console.WriteLine("[-group (Номер)] - Находит всех студентов этой группы");
                    Console.WriteLine("[-grade (Имя)] - Оценивает баллы студента");
                    Console.WriteLine("[-gradeAll] - Оценивает баллы всех студентов");
                    Console.WriteLine("[-end] - Заканчивает программу");
                    
                break;
                case "-end":
                    //Console.Clear();
                    endProgram = true;
                    Console.WriteLine("Конец");
                break;
                default:
                    //Console.Clear();
                    Console.WriteLine("Ошибка. Неопознанная команда, попробуйте снова. [-help] - Лист команд");
                    
                break;
            }
            if (!endProgram){
                ReciveCommand(studentList);
            }
        }

        static void AddStudentToList(StudentList studentList, string[] subParts){
            bool anyError = false;
            string studentName;
            int studentAge;
            double studentGrade;
            string studentGroup;

            studentName = subParts[1];
            if (!Int32.TryParse(subParts[2], out studentAge)){
                anyError = true;
            }
            if (!Double.TryParse(subParts[3], out studentGrade)){
                anyError = true;
            }
            studentGroup = subParts[4];
            
            if(!anyError){
                Console.WriteLine(studentName + " " + studentAge + " " + studentGrade + " " + studentGrade);
                studentList.AddStudent(new Student(studentName, studentAge, studentGrade, studentGroup));
            } else {
                Console.WriteLine("Ошибка. Неподходящие значение(-я) в команде, попробуйте снова.");
            }
        }
        
        static void FindStudent(StudentList studentList, string[] subParts){
            var FirstMatch = studentList.students.FirstOrDefault(elem => elem.Name == subParts[1]);
            if (FirstMatch != null){
                Console.WriteLine($"- {FirstMatch.Name} | {FirstMatch.Age} | {FirstMatch.Grade} | {FirstMatch.Group}");
            } else {
                Console.WriteLine("Ошибка. Студента с таким именем не существует.");
            }
        }

        static void FindGroup(StudentList studentList, string[] subParts){
            var FirstMatch = studentList.students.Where(elem => elem.Group == subParts[1]);
            if (FirstMatch != null){
                foreach (var student in FirstMatch){
                    Console.WriteLine($"- {student.Name} | {student.Age} | {student.Grade} | {student.Group}");
                }
            } else {
                Console.WriteLine("Ошибка. Студентов с такой группой не существует.");
                ;
            }
        }

        static void GradeStudent(StudentList studentList, string[] subParts){
            string GradeName = "null";
            var FirstMatch = studentList.students.FirstOrDefault(elem => elem.Name == subParts[1]);

            if (FirstMatch != null){
                switch (FirstMatch.Grade){
                    case >=4.5:
                        GradeName = "Отлично";
                    break;
                    case >=3.5:
                        GradeName = "Хорошо";                    
                    break;
                    case >=2.5:
                        GradeName = "Удовлитворительно";
                    break;
                    case <2.5:
                        GradeName = "Не зачет";
                    break;
                }

                Console.WriteLine($"- {FirstMatch.Name} | {FirstMatch.Grade} = {GradeName} | {FirstMatch.Group}");
            } else {
                Console.WriteLine("Ошибка. Студента с таким именем не существует.");
            }
        }

        static void GradeEveryone(StudentList studentList, string[] subParts){
            string GradeName = "null";

            Console.WriteLine("[Оценки]");

            foreach (var student in studentList.students) {   
                switch (student.Grade){
                    case >=4.5:
                        GradeName = "Отлично";
                    break;
                    case >=3.5:
                        GradeName = "Хорошо";                    
                    break;
                    case >=2.5:
                        GradeName = "Удовлитворительно";
                    break;
                    case <2.5:
                        GradeName = "Не зачет";
                    break;
                }
                
                Console.WriteLine($"- {student.Name} | {student.Grade} = {GradeName} | {student.Group}");
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
        public string Group { get; set; }

        public Student(string name, int age, double grade, string group)
        {
            Name = name;
            Age = age;
            Grade = grade;
            Group = group;
        }
    }

    public class StudentList
    {
        public List<Student> students;

        public StudentList()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
    }
}