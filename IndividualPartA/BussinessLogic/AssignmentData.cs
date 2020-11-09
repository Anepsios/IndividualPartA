using IndividualPartA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualPartA.BussinessLogic
{
    class AssignmentData
    {
		static internal List<Assignment> GetData(List<Assignment> assignments, string type)
		{
			if (!PrivateSchool.syntheticData)
			{
				Console.WriteLine("Number of assignments to add: ");
				int numOfItems = int.Parse(Console.ReadLine());
				for (int i = 0; i < numOfItems; i++)
				{
					Console.WriteLine("Assignment " + (i + 1) + ":");
					assignments.Add(GetAssignmentDetails());
				}
			}
			else
			{
				if (type == "Full Time")
					assignments = GenerateAssignmentDetails1(assignments);
				else
					assignments = GenerateAssignmentDetails2(assignments);
			}
			return (assignments);
		}

		static internal Assignment GetAssignmentDetails()
		{
			Assignment assignment = new Assignment();
			assignment.Title = CommandPromtUtilities.AskDetails("Assignment title");
			assignment.Description = CommandPromtUtilities.AskDetails("Assignment description");
			assignment.SubDateTime = DateTime.Parse(CommandPromtUtilities.AskDetails("Assignment submision date"));
			assignment.OralMark = float.Parse(CommandPromtUtilities.AskDetails("Assignment oral mark"));
			assignment.TotalMark = float.Parse(CommandPromtUtilities.AskDetails("Assignment total mark"));
			return (assignment);
		}

		static internal List<Assignment> GenerateAssignmentDetails1(List<Assignment> assignments)
		{
			assignments.Add(new Assignment("Individual1", "An individual assignment", "10/11/2020", 20, 80));
			assignments.Add(new Assignment("Individual2", "An individual assignment", "13/11/2020", 20, 80));
			assignments.Add(new Assignment("Individual3", "An individual assignment", "19/11/2020", 20, 80));
			assignments.Add(new Assignment("Individual4", "An individual assignment", "25/11/2020", 20, 80));
			assignments.Add(new Assignment("Individual5", "An individual assignment", "2/12/2020", 20, 80));
			assignments.Add(new Assignment("Individual6", "An individual assignment", "8/12/2020", 20, 80));
			assignments.Add(new Assignment("Individual Project", "An individual project", "17/12/2020", 20, 80));
			assignments.Add(new Assignment("Group Project", "A group project", "8/1/2021", 20, 80));
			return (assignments);
		}

		static internal List<Assignment> GenerateAssignmentDetails2(List<Assignment> assignments)
		{
			assignments.Add(new Assignment("Individual1", "An individual assignment", "12/11/2020", 20, 80));
			assignments.Add(new Assignment("Individual2", "An individual assignment", "25/11/2020", 20, 80));
			assignments.Add(new Assignment("Individual3", "An individual assignment", "11/12/2020", 20, 80));
			assignments.Add(new Assignment("Individual4", "An individual assignment", "4/1/2020", 20, 80));
			assignments.Add(new Assignment("Individual5", "An individual assignment", "21/1/2021", 20, 80));
			assignments.Add(new Assignment("Individual6", "An individual assignment", "15/2/2021", 20, 80));
			assignments.Add(new Assignment("Individual Project", "An individual project", "4/3/2021", 20, 80));
			assignments.Add(new Assignment("Group Project", "A group project", "8/4/2021", 20, 80));
			return (assignments);
		}

		static internal void PrintList(List<Assignment> assignments)
		{
			int i = 1;
			foreach (var item in assignments)
			{
				Console.WriteLine("Assignment_" + i + ": \n" + item + "\n");
				i++;
			}
		}
	}
}
