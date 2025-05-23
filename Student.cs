using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class Student
    {
        private string indexNumber;
        private string name;
        private double gpa;
        private string admissionYear;
        private string nic;
        public Student Next;

        public string IndexNumber { get => indexNumber; set => indexNumber = value; }
        public string Name { get => name; set => name = value; }
        public double GPA { get => gpa; set => gpa = value; }
        public string AdmissionYear { get => admissionYear; set => admissionYear = value; }
        public string Nic { get => nic; set => nic = value; }

        public Student(string indexNumber, string name, double gpa, string admissionYear, string nic)
        {
            IndexNumber = indexNumber;
            Name = name;
            GPA = gpa;
            AdmissionYear = admissionYear;
            Nic = nic;
            Next = null;
        }

        public void Display()
        {
            Console.WriteLine($"Index Number.{IndexNumber}");
            Console.WriteLine($"Name.{Name}");
            Console.WriteLine($"GPA.{GPA}");
            Console.WriteLine($"AdmissionYear.{AdmissionYear}");
            Console.WriteLine($"NIC.{Nic}");
        }
    }
    public class StudentLinkedList
    {
        private Student head;

        public StudentLinkedList()
        {
            head = null;
        }

        public bool Insert(string indexNumber, string name, double gpa, string admissionYear, string nic)
        {
            if (Search(indexNumber) != null)
            {
                Console.WriteLine($"Student with index number {indexNumber} already exists!");
                return false;
            }
            Student newStudent = new Student(indexNumber, name, gpa, admissionYear, nic);
            if (head == null || string.Compare(head.IndexNumber, indexNumber) > 0)
            {
                newStudent.Next = head;
                head = newStudent;
                return true;
            }
            Student current = head;
            while (current.Next != null && string.Compare(current.Next.IndexNumber, indexNumber) < 0)
            {
                current = current.Next;
            }

            newStudent.Next = current.Next;
            current.Next = newStudent;
            return true;
        }
        public Student Search(string indexNumber)
        {
            Student current = head;
            while (current != null)
            {
                if (current.IndexNumber == indexNumber)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }
        public bool Remove(string indexNumber)
        {
            // If list is empty
            if (head == null)
            {
                Console.WriteLine("List is empty!");
                return false;
            }
            if (head.IndexNumber == indexNumber)
            {
                head = head.Next;
                Console.WriteLine($"Student with index number {indexNumber} removed successfully!");
                return true;
            }
            Student current = head;
            while (current.Next != null && current.Next.IndexNumber != indexNumber)
            {
                current = current.Next;
            }
            if (current.Next != null && current.Next.IndexNumber == indexNumber)
            {
                current.Next = current.Next.Next;
                Console.WriteLine($"Student with index number {indexNumber} removed successfully!");
                return true;
            }
            else
            {
                Console.WriteLine($"Student with index number {indexNumber} not found!");
                return false;
            }
        }
        public void DisplayAll()
        {
            if (head == null)
            {
                Console.WriteLine("No students in the list!");
                return;
            }

            Console.WriteLine("\nList of all students:");
            Console.WriteLine("{0,-15} {1,-20} {2,-8} {3,-10} {4,-15}",
                "Index Number", "Name", "GPA", "Adm Year", "NIC");
            Console.WriteLine(new string('-', 70));

            Student current = head;
            while (current != null)
            {
                Console.WriteLine("{0,-15} {1,-20} {2,-8:F2} {3,-10} {4,-15}",
                current.IndexNumber, current.Name, current.GPA,
                current.AdmissionYear, current.Nic);
                current = current.Next;

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StudentLinkedList studentList = new StudentLinkedList();

            while (true)
            {
                Console.WriteLine("\nStudent Management System");
                Console.WriteLine("1. Add a new student");
                Console.WriteLine("2. Search for a student");
                Console.WriteLine("3. Remove a student");
                Console.WriteLine("4. Display all students");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nAdd New Student");
                        Console.Write("Enter index number (e.g., 2025123): ");
                        string indexNumber = Console.ReadLine();
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter GPA: ");
                        double gpa = double.Parse(Console.ReadLine());
                        Console.Write("Enter admission year: ");
                        string admissionYear = Console.ReadLine();
                        Console.Write("Enter NIC: ");
                        string nic = Console.ReadLine();

                        if (studentList.Insert(indexNumber, name, gpa, admissionYear, nic))
                        {
                            Console.WriteLine("Student added successfully!");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nSearch Student");
                        Console.Write("Enter index number to search: ");
                        string searchIndex = Console.ReadLine();
                        Student foundStudent = studentList.Search(searchIndex);

                        if (foundStudent != null)
                        {
                            Console.WriteLine("\nStudent found:");
                            foundStudent.Display();

                        }
                        else
                        {
                            Console.WriteLine("Student not found!");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nRemove Student");
                        Console.Write("Enter index number to remove: ");
                        string removeIndex = Console.ReadLine();
                        studentList.Remove(removeIndex);
                        break;

                    case "4":
                        studentList.DisplayAll();
                        break;

                    case "5":
                        Console.WriteLine("Exiting the program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}


