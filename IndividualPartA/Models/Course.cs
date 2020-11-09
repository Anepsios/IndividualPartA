using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualPartA.Models
{
	class Course
	{
		private string _title;
		private string _stream;
		private string _type;
		private DateTime _start_date;
		private DateTime _end_date;

		public string Title
		{
			get { return (this._title); }
			set { this._title = value; }
		}

		public string Stream
		{
			get { return (this._stream); }
			set { this._stream = value; }
		}

		public string Type
		{
			get { return (this._type); }
			set { this._type = value; }
		}

		public DateTime StartDate
		{
			get { return (this._start_date); }
			set { this._start_date = value; }
		}

		public DateTime EndDate
		{
			get { return (this._end_date); }
			set { this._end_date = value; }
		}

		public Course()
		{
		}
		public Course(string Title, string Stream, string Type, string StartDate, string EndDate)
		{
			this._title = Title;
			this._stream = Stream;
			this._type = Type;
			this._start_date = DateTime.Parse(StartDate);
			this._end_date = DateTime.Parse(EndDate);
		}

		public override string ToString()
		{
			return ($"Title: {this._title}\tStream: {this._stream}\tType: {this._type}\n" +
					$"Start Date: {this._start_date.ToString("dd/MM/yyyy")}\tEnd Date: {this._end_date.ToString("dd/MM/yyyy")}");
		}
	}
}
