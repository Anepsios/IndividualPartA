using IndividualPartA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualPartA.BussinessLogic
{
    class CommandPromtOutput
    {
		static internal void OutputMenu(List<Course> courses, List<Trainer> trainers, List<CourseClass> courseClasses)
		{
			int answer;
			List<string> selections = new List<string>()
			{
				"Print a list of all the students", "Print a list of all the trainers", "Print a list of all the assignments", "Print a list of all the courses",
				"Print all the students per course" , "Print all the trainers per course", "Print all the assignments per course", "Print all the assignments per student",
				"Print a list of students that belong to more than one courses",
				"Print list of students who need to submit one or more assignments on the same calendar week as the date that will be given"
			};
			List<Assignment> allAssignents = new List<Assignment>();
			while (true)
			{
				answer = CommandPromtUtilities.SelectFromList(selections, true);
				switch (answer)
				{
					case 1:
						Console.WriteLine("\n\t\t <Listing all enrolled students this semester>\n");
						List<Student> allStudents = MergeStudentLists(courseClasses);
						StudentData.PrintList(allStudents);
						break;
					case 2:
						Console.WriteLine("\n\t\t <Listing all the school teachers>\n");
						TrainerData.PrintList(trainers);
						break;
					case 3:
						Console.WriteLine("\n\t\t <Listing all the assignments of this semester>\n");
						foreach (var item in courseClasses)
						{
							foreach (var item2 in item.Assignments)
							{
								allAssignents.Add(item2);
							}
						}
						AssignmentData.PrintList(allAssignents);
						break;
					case 4:
						Console.WriteLine("\n\t\t<Listing all the active courses of this semester>\n");
						CourseData.PrintList(courses);
						break;
					case 5:
						Console.WriteLine("\n\t\t<Listing all the students in each course>\n");
						foreach (var item in courseClasses)
						{
							Console.WriteLine("\n\t\t" + item.Title);
							StudentData.PrintList(item.Students);
						}
						break;
					case 6:
						Console.WriteLine("\n\t\t<Listing all the trainers in each course>\n");
						foreach (var item in courseClasses)
						{
							Console.WriteLine("\n\t\t" + item.Title);
							TrainerData.PrintList(item.Trainers);
						}
						break;
					case 7:
						Console.WriteLine("\n\t\t<Listing all the assignments in each course>\n");
						foreach (var item in courseClasses)
						{
							Console.WriteLine("\n\t\t" + item.Title);
							AssignmentData.PrintList(item.Assignments);
						}
						break;
					case 8:
						Console.WriteLine("\n\t\t<Listing all the assignments each student has per course>\n");
						foreach (var item in courseClasses)
						{
                            Console.WriteLine("\n\t\t" + item.Title);
							foreach (var item2 in item.Students)
							{
								Console.WriteLine("\n\n" + item2 + "\n\n");
								AssignmentData.PrintList(item.Assignments);
							}
						}
						break;
					case 9:
                        Console.WriteLine("\n\t\t<Listing students who have enrolled on more than one course>\n");
						List<Student> multipleCourseStudents = MultipleCourseStudents(courseClasses);
						StudentData.PrintList(multipleCourseStudents);
						break;
					case 10:
						DateTime[] weekToOutput = WeekToCheck();
						PrintStudentsWithAssignment(courseClasses, weekToOutput);
						break;
					default:
						break;
				}
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

		static internal DateTime[] WeekToCheck()
        {
			DateTime dayToCheck;
			DateTime[] weekToOutput = new DateTime[7];
			Console.WriteLine("\nPlease input date of week you want to check");
			dayToCheck = DateTime.Parse(Console.ReadLine());
			Console.WriteLine("Day of date picked: " + dayToCheck.DayOfWeek);
			int x = (int)dayToCheck.DayOfWeek;
			if (x == 0)
			{
				for (int i = 0; i < 7; i++)
				{
					weekToOutput[i] = dayToCheck.AddDays(-(i + 1));
				}
				weekToOutput = ReverseArray(weekToOutput);
				Console.WriteLine($"Checking week {weekToOutput[1].ToString("dd/MM/yyyy")} - {weekToOutput[5].ToString("dd/MM/yyyy")}\n");
			}
			else
			{
				int count = 0;
				for (int i = x; i >= 0; i--)
				{
					weekToOutput[count] = dayToCheck.AddDays(-i);
					count++;
				}
				int count2 = 1;
				for (int i = x + 1; i < 7; i++)
				{
					weekToOutput[count] = dayToCheck.AddDays(count2);
					count++;
					count2++;
				}
				Console.WriteLine($"Checking week {weekToOutput[1].ToString("dd/MM/yyyy")} - {weekToOutput[5].ToString("dd/MM/yyyy")}\n");
			}
			return (weekToOutput);
		}

		static internal DateTime[] ReverseArray(DateTime[] array)
        {
			DateTime[] result = new DateTime[array.Length];
			int count = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
				result[count] = array[i];
				count++;
            }
			return (result);
        }

		static internal void PrintStudentsWithAssignment(List<CourseClass> courseClasses, DateTime[] weektoOutput)
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
				StudentData.PrintList(studentsWithAssignment);
        }
	}
}
