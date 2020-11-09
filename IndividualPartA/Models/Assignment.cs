using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualPartA.Models
{
	class Assignment
	{
		private string _title;
		private string _description;
		private DateTime _subdatetime;
		private float _oralmark;
		private float _totalmark;

		public string Title
		{
			get { return (this._title); }
			set { this._title = value; }
		}

		public string Description
		{
			get { return (this._description); }
			set { this._description = value; }
		}

		public DateTime SubDateTime
		{
			get { return (this._subdatetime); }
			set { this._subdatetime = value; }
		}

		public float OralMark
		{
			get { return (this._oralmark); }
			set { this._oralmark = value; }
		}

		public float TotalMark
		{
			get { return (this._totalmark); }
			set { this._totalmark = value; }
		}

		public Assignment()
		{
		}
		public Assignment(string Title, string Description, string SubDateTime, float OralMark, float TotalMark)
		{
			this._title = Title;
			this._description = Description;
			this._subdatetime = DateTime.Parse(SubDateTime);
			this._oralmark = OralMark;
			this._totalmark = TotalMark;
		}

		public override string ToString()
		{
			return ($"Title: {this._title}\tDescription: {this._description}\tSubmission Date: " +
					$"{this._subdatetime.ToString("dd/MM/yyyy")}\nOral Mark: {this._oralmark}\tTotal Mark: {this._totalmark}");
		}
	}
}
