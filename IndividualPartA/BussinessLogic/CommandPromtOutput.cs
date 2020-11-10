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
				"Print list of students who need to submit one or more assignments on the same calendar week as the date input"
			};
			List<Assignment> allAssignents = new List<Assignment>();
			while (true)
			{
                Console.WriteLine("\nSelect an option from the following list:\n");
				answer = CommandPromtUtilities.SelectFromList(selections, true);
				switch (answer)
				{
					case 1:
						Console.WriteLine("\n\t\t <Listing all enrolled students this semester>\n");
						List<Student> allStudents = StudentData.MergeStudentLists(courseClasses);
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
						List<Student> multipleCourseStudents = StudentData.MultipleCourseStudents(courseClasses);
						StudentData.PrintList(multipleCourseStudents);
						break;
					case 10:
						DateTime[] weekToOutput = CommandPromtUtilities.WeekToCheck();
						List<Student> studentsWithAssignment = StudentData.GetStudentsWithAssignment(courseClasses, weekToOutput);
						StudentData.PrintList(studentsWithAssignment);
						break;
					default:
						break;
				}
			}
		}
	}
}
