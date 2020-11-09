using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualPartA.Models;

namespace IndividualPartA.BussinessLogic
{
    class Initialisation
    {
        static internal List<Course> SetUpCourses()
        {
            List<Course> courses = new List<Course>();
			courses = CourseData.GetData(courses);
			return (courses);
        }

		static internal List<Trainer> SetUpTrainers()
        {
			List<Trainer> trainers = new List<Trainer>();
			trainers = TrainerData.GetData(trainers);
			return (trainers);
        }

		static internal List<CourseClass> SetUpClasses(List<Course> courses, List<Trainer> trainers)
        {
			List<CourseClass> courseClasses = new List<CourseClass>();
            foreach (var item in courses)
            {
				if (!PrivateSchool.syntheticData)
					Console.WriteLine($"Data for " + item.Title);
				courseClasses.Add(new CourseClass(item, trainers));
            }
			return (courseClasses);
        }

		static internal List<Trainer> AssignTrainers(List<Trainer> trainers, string subject, string type)
        {
			List<Trainer> courseTrainers = new List<Trainer>();
			if (PrivateSchool.syntheticData)
				courseTrainers = TrainerData.AutoAssignTrainers(trainers, subject, type);
            else
				courseTrainers = TrainerData.ManuallyAssignTrainers(trainers, subject, type);
            return (courseTrainers);
        }

		static internal List<Assignment> SetUpAssignments(string type)
		{
			List<Assignment> assignments = new List<Assignment>();
			assignments = AssignmentData.GetData(assignments, type);
			return (assignments);
		}

		static internal List<Student> SetUpStudents(string subject, string type)
		{
			List<Student> students = new List<Student>();
			students = StudentData.GetData(students, subject, type);
			return (students);
		}
	}
}
