using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualPartA.Models
{
	class Student
	{
		private string _firstname;
		private string _lastname;
		private DateTime _dateofbirth;
		private double _tuitionfees;
		private string _subject;
		List<Assignment> _assignments = new List<Assignment>();

		public string FirstName
		{
			get { return (this._firstname); }
			set { this._firstname = value; }
		}

		public string LastName
		{
			get { return (this._firstname); }
			set { this._lastname = value; }
		}

		public DateTime DateOfBirth
		{
			get { return (this._dateofbirth); }
			set { this._dateofbirth = value; }
		}

		public double TuitionFees
		{
			get { return (this._tuitionfees); }
			set { this._tuitionfees = value; }
		}

		public string Subject
		{
			get { return (this._subject); }
			set { this._subject = value; }
		}

		public List<Assignment> Assignments
        {
			get { return (this._assignments); }
			set { this._assignments = value; }
        }

		public Student()
		{
		}
		public Student(string FirstName, string LastName, string DateOfBirth, double TuitionFees)
		{
			this._firstname = FirstName;
			this._lastname = LastName;
			this._dateofbirth = DateTime.Parse(DateOfBirth);
			this._tuitionfees = TuitionFees;
			this._subject = Subject;
		}

		public override string ToString()
		{
			return ($"First Name: {this._firstname}\tLast Name: {this._lastname}\nDate Of Birth: " +
					$"{this._dateofbirth.ToString("dd/MM/yyyy")}\tTuition Fees: {this._tuitionfees}");
		}
	}
}
