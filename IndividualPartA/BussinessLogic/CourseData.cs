using IndividualPartA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualPartA.BussinessLogic
{
    class CourseData
    {
		static internal List<Course> GetData(List<Course> courses)
		{
			if (!PrivateSchool.syntheticData)
			{
				Console.WriteLine("Number of courses to input: ");
				int numOfItems = int.Parse(Console.ReadLine());
				for (int i = 0; i < numOfItems; i++)
				{
					Console.WriteLine("Course " + (i + 1) + ":");
					courses.Add(GetCourseDetails());
				}
			}
			else
				courses = GenerateCourseDetails(courses);
			return (courses);
		}

		static internal Course GetCourseDetails()
		{
			List<string> streams = new List<string> { "C#", "Java", "Javascript", "Python" };
			List<string> types = new List<string> { "Full Time", "Part Time" };
			Course course = new Course();
			string title = CommandPromtUtilities.AskDetails("Course title");
			course.Stream = CommandPromtUtilities.AskDetails("Choose the course's stream from the following list", streams);
			course.Type = CommandPromtUtilities.AskDetails("Choose the course's type from the following list", types);
			course.Title = title + " " + course.Type + " " + course.Stream;
			course.StartDate = DateTime.Parse(CommandPromtUtilities.AskDetails("Course start date"));
			course.EndDate = DateTime.Parse(CommandPromtUtilities.AskDetails("Course end date"));
			return (course);
		}

		static internal List<Course> GenerateCourseDetails(List<Course> courses)
		{
			courses.Add(new Course("CB12 Full Time C#", "C#", "Full Time", "9/10/2020", "8/1/2021"));
			courses.Add(new Course("CB11 Part Time C#", "C#", "Part Time", "6/10/2020", "8/4/2021"));
			courses.Add(new Course("CB12 Full Time Java", "Java", "Full Time", "9/10/2020", "8/1/2021"));
			courses.Add(new Course("CB11 Part Time Java", "Java", "Part Time", "6/10/2020", "8/4/2021"));
			return (courses);
		}

		static internal void PrintList(List<Course> courses)
		{
			int i = 1;
			foreach (var item in courses)
			{
				Console.WriteLine("Course_" + i + ": \n" + item + "\n");
				i++;
			}
		}
	}
}
