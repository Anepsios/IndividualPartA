using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private List<Trainer> _trainers = new List<Trainer>();
        private List<CourseClass> _courseclasses = new List<CourseClass>();

        public List<Course> Courses
        {
            get { return this._courses; }
            set { this._courses = value;}
        }

        public List<Trainer> Trainers
        {
            get { return this._trainers; }
            set { this._trainers = value; }
        }

        public List<CourseClass> CourseClasses
        {
            get { return this.CourseClasses; }
            set { this.CourseClasses = value; }
        }

        public PrivateSchool()
        {
            Console.WriteLine("Welcome to private school PC Education\nLet's get the data for this semester");

            syntheticData = CommandPromtUtilities.SyntheticData();     
            
            this._courses = Initialisation.SetUpCourses();
            this._trainers = Initialisation.SetUpTrainers();
            this._courseclasses = Initialisation.SetUpClasses(this._courses, this._trainers);

            Console.WriteLine("\nSemester was organised succesfully!\n");

            CommandPromtOutput.OutputMenu(this._courses, this._trainers, this._courseclasses);
        }
    }
}
