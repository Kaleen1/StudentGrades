using System;
using System.Collections.Generic;

namespace StudentGrades
{
    class Program
    {
        static Dictionary<string, List<int>> studentGrades = new Dictionary<string, List<int>>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Student Grades Application!");

            while (true)
            {
                Console.WriteLine("Enter 1 to add a student, 2 to assign a grade, 3 to view a student's average grade, 4 to view all of a student's grades, or 5 to exit to application: ");
                string input = Console.ReadLine() ?? string.Empty;

                switch (input)
                {
                    case "1":
                        addStudent();
                        break;
                    case "2":
                        assignGrades();
                        break;
                    case "3":
                        averageGrade();
                        break;
                    case "4":
                        viewGrades();                     
                        break;                     
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void addStudent()
        {
            Console.WriteLine("Enter the student's name: ");
            string studentName = Console.ReadLine();
            if (!string.IsNullOrEmpty(studentName))
            {
                if (!studentGrades.ContainsKey(studentName))
                {
                    studentGrades[studentName] = new List<int>();
                    Console.WriteLine($"{studentName} added successfully.");
                }
                else
                {
                    Console.WriteLine("Student already exists.");
                }
            }
            else
            {
                Console.WriteLine("Invalid name.");
            }
        }

        static void assignGrades()
        {
            Console.WriteLine("Enter the student's name: ");
            string studentName = Console.ReadLine();
            if (studentGrades.ContainsKey(studentName))
            {
                Console.WriteLine("Enter the student's grade: ");
                if (int.TryParse(Console.ReadLine(), out int studentGrade))
                {
                    studentGrades[studentName].Add(studentGrade);
                    Console.WriteLine($"{studentName}'s grade of {studentGrade} added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid grade.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void averageGrade()
        {
            Console.WriteLine("Enter the student's name: ");
            string studentName = Console.ReadLine();
            if (studentGrades.ContainsKey(studentName))
            {
                double average = studentGrades[studentName].Count > 0 ? studentGrades[studentName].Average() : 0;
                Console.WriteLine($"{studentName}'s average grade: {average}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void viewGrades()
        {
            Console.WriteLine("Enter the student's name: ");
            string studentName = Console.ReadLine();
            if (studentGrades.ContainsKey(studentName))
            {
                Console.WriteLine($"{studentName}'s grades: {string.Join(", ", studentGrades[studentName])}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}