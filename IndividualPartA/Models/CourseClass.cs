using IndividualPartA.BussinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualPartA.Models
{
    class CourseClass : Course
    {
        private List<Trainer> _trainers;

        public List<Trainer> Trainers
        {
            get { return this._trainers; }
            set { this._trainers = value; }
        }

        private List<Student> _students;

        public List<Student> Students
        {
            get { return this._students; }
            set { this._students = value; }
        }

        private List<Assignment> _assignments;
        public List<Assignment> Assignments
        {
            get { return this._assignments; }
            set { this._assignments = value; }
        }

        public CourseClass(Course course, List<Trainer> trainers)
        {
            this.Title = course.Title;
            this.Stream = course.Stream;
            this.Type = course.Type;
            this.StartDate = course.StartDate;
            this.EndDate = course.EndDate;
            this._trainers = Initialisation.AssignTrainers(trainers, this.Stream, this.Type);
            this._assignments = Initialisation.SetUpAssignments(this.Type);
            this._students = Initialisation.SetUpStudents(this.Stream, this.Type);

            foreach (var item in this._students)
            {
                foreach (var item2 in this._assignments)
                {
                    item.Assignments.Add(item2);
                }
            }
        }
    }
}
