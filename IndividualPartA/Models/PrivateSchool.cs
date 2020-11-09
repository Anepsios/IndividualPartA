using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualPartA.BussinessLogic;
using IndividualPartA.Models;

namespace IndividualPartA.Models
{
    class PrivateSchool
    {
        static internal bool syntheticData;

        private List<Course> _courses = new List<Course>();
        public List<Course> Courses
        {
            get { return this._courses; }
            set { this._courses = value;}
        }

        private List<Trainer> _trainers = new List<Trainer>();
        public List<Trainer> Trainers
        {
            get { return this._trainers; }
            set { this._trainers = value; }
        }

        private List<CourseClass> _courseclasses = new List<CourseClass>();
        public List<CourseClass> CourseClasses
        {
            get { return this.CourseClasses; }
            set { this.CourseClasses = value; }
        }

        

        public PrivateSchool()
        {
            Console.WriteLine("Welcome to private School PC Education\n");
            syntheticData = CommandPromtUtilities.SyntheticData();
            this._courses = Initialisation.SetUpCourses();
            this._trainers = Initialisation.SetUpTrainers();
            this._courseclasses = Initialisation.SetUpClasses(this._courses, this._trainers);
            Console.WriteLine("\nSemester was organised succesfully!\n");
            CommandPromtOutput.OutputMenu(this._courses, this._trainers, this._courseclasses);
        }
    }
}
