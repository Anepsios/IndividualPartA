using IndividualPartA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualPartA.BussinessLogic
{
    class StudentData
    {
		static internal List<Student> GetData(List<Student> students, string subject, string type)
		{
			if (!PrivateSchool.syntheticData)
			{
				Console.WriteLine("Number of students to input: ");
				int numOfItems = int.Parse(Console.ReadLine());
				for (int i = 0; i < numOfItems; i++)
				{
					Console.WriteLine("Student " + (i + 1) + ":");
					students.Add(GetStudentDetails());
				}
			}
			else
			{
				if (subject.Equals("C#"))
				{
					if (type.Equals("Full Time"))
						students = GenerateStudentDetails1(students);
					else
						students = GenerateStudentDetails2(students);
				}
				else
				{
					if (type.Equals("Full Time"))
						students = GenerateStudentDetails3(students);
					else
						students = GenerateStudentDetails4(students);
				}
			}
			return (students);
		}

		static internal Student GetStudentDetails()
		{
			Student student = new Student();
			student.FirstName = CommandPromtUtilities.AskDetails("First name");
			student.LastName = CommandPromtUtilities.AskDetails("Last name");
			student.DateOfBirth = DateTime.Parse(CommandPromtUtilities.AskDetails("Date of birth"));
			student.TuitionFees = double.Parse(CommandPromtUtilities.AskDetails("Tuition fees"));
			return (student);
		}

		static internal List<Student> GenerateStudentDetails1(List<Student> students)
		{
			students.Add(new Student("Bob", "Marley", "5/4/1992", 2500));
			students.Add(new Student("Ted", "Bundy", "17/2/1996", 2500));
			students.Add(new Student("Phil", "Philibuster", "24/7/1992", 2500));
			students.Add(new Student("Mpampis", "Sougias", "2/11/1993", 5000));
			students.Add(new Student("Vlasis", "Tsohatzopoulos", "15/8/1990", 2000));
			return (students);
		}

		static internal List<Student> GenerateStudentDetails2(List<Student> students)
		{
			students.Add(new Student("Weird", "Name", "19/4/1980", 5000));
			students.Add(new Student("John", "Doe", "22/6/1991", 2250));
			students.Add(new Student("Din", "Viezel", "25/5/1985", 2500));
			students.Add(new Student("Mike", "Portnoy", "9/10/1993", 2250));
			students.Add(new Student("Jane", "Doe", "28/8/1997", 2500));
			students.Add(new Student("Mpampis", "Sougias", "2/11/1993", 5000));
			return (students);
		}

		static internal List<Student> GenerateStudentDetails3(List<Student> students)
		{
			students.Add(new Student("George", "Papadopoulos", "7/10/1995", 2500));
			students.Add(new Student("Yannis", "Papadopoulos", "14/4/1999", 2500));
			students.Add(new Student("Prodromos", "Sifatsis", "16/7/1994", 2250));
			students.Add(new Student("Kapoios", "Kapoiou", "24/12/2000", 2500));
			students.Add(new Student("Giorgos", "Georgiou", "27/4/1992", 2500));
			students.Add(new Student("Apostolos", "Apostolakis", "14/1/1995", 2500));
			return (students);
		}

		static internal List<Student> GenerateStudentDetails4(List<Student> students)
		{
			students.Add(new Student("Mpampis", "Sougias", "2/11/1993", 5000));
			students.Add(new Student("Joe", "Black", "22/6/1994", 2500));
			students.Add(new Student("Ben", "Solo", "8/2/2001", 2500));
			students.Add(new Student("Vrasidas", "Dickinson", "13/9/1989", 2500));
			students.Add(new Student("Kirk", "Hametis", "30/6/1998", 2500));
			students.Add(new Student("Bethany", "Carver", "21/5/1996", 2500));
			students.Add(new Student("Weird", "Name", "19/4/1980", 5000));
			return (students);
		}

		static internal void PrintList(List<Student> students)
		{
			int i = 1;
			foreach (var item in students)
			{
				Console.WriteLine("Student_" + i + ": \n" + item + "\n");
				i++;
			}
		}
	}
}
