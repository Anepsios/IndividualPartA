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

		static internal List<Student> MergeStudentLists(List<CourseClass> courseClass)
		{
			List<Student> allStudents = new List<Student>();
			bool alreadyinside;
			foreach (var item in courseClass)
			{
				foreach (var item2 in item.Students)
				{
					alreadyinside = false;
					foreach (var item3 in allStudents)
					{
						if (item2.FirstName == item3.FirstName && item2.LastName == item3.LastName)
							alreadyinside = true;
					}
					if (!alreadyinside)
					{
						allStudents.Add(item2);
						continue;
					}
				}
			}
			return (allStudents);
		}

		static internal List<Student> MultipleCourseStudents(List<CourseClass> courseClass)
		{
			List<Student> multipleCourseStudents = new List<Student>();
			bool alreadyinside;
			for (int i = 0; i < courseClass.Count - 1; i++)
			{
				for (int j = i + 1; j < courseClass.Count; j++)
				{
					foreach (var item in courseClass[i].Students)
					{
						foreach (var item2 in courseClass[j].Students)
						{
							alreadyinside = false;
							if (item.FirstName == item2.FirstName && item.LastName == item2.LastName)
							{
								foreach (var item3 in multipleCourseStudents)
								{
									if (item.FirstName == item3.FirstName && item.LastName == item3.LastName)
										alreadyinside = true;
								}
								if (!alreadyinside)
								{
									multipleCourseStudents.Add(item);
									continue;
								}
							}
						}
					}
				}
			}
			return (multipleCourseStudents);
		}

		static internal List<Student> GetStudentsWithAssignment(List<CourseClass> courseClasses, DateTime[] weektoOutput)
		{
			List<Student> studentsWithAssignment = new List<Student>();
			bool alreadyInside = false;
			foreach (var item in courseClasses)
			{
				for (int i = 0; i < weektoOutput.Length; i++)
				{
					foreach (var item2 in item.Students)
					{
						foreach (var item3 in item2.Assignments)
						{
							if (DateTime.Compare(weektoOutput[i], item3.SubDateTime) == 0)
							{
								foreach (var item4 in studentsWithAssignment)
								{
									if (item2.FirstName.Equals(item4.FirstName) && item2.LastName.Equals(item4.LastName))
									{
										alreadyInside = true;
										break;
									}
								}
								if (!alreadyInside)
									studentsWithAssignment.Add(item2);
								else
									break;
							}
						}
						alreadyInside = false;
					}
				}
			}
			return (studentsWithAssignment);
		}
	}
}
