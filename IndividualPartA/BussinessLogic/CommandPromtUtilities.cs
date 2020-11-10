using IndividualPartA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualPartA.BussinessLogic
{
    class CommandPromtUtilities
    {
		static internal bool SyntheticData()
		{
			bool syntheticData = !YesOrNo("Would you like to input data manually?");
			return (syntheticData);
		}

		static internal bool YesOrNo(string message)
        {
			bool yes = false;
			bool answerGiven = false;
			while (!answerGiven)
			{
				Console.WriteLine(message + " (Y/N)");
				string input = (Console.ReadLine());
				string answer = input.ToUpper();
				if (answer == "Y")
				{
					answerGiven = true;
					yes = true;
				}
				else if (answer == "N")
				{
					answerGiven = true;
					yes = false;
				}
				else
					Console.WriteLine("Invalid Answer");
			}
			return (yes);
        }

		static internal string AskDetails(string message, List<string> selections = null)
		{
			string result = "";

			if (selections != null)
			{
				Console.WriteLine(message + ": ");
				result = SelectFromList(selections);
			}
			else
			{
				Console.Write(message + ": ");
				result = Console.ReadLine();
			}
			return (result);
		}

		static internal string SelectFromList(List<string> selections)
		{
			int count = 1;
			bool given = false;
			int choise;
			bool isnumber;
			string result = "";
			foreach (var item in selections)
			{
				Console.WriteLine($"{count++}. {item}");
			}
			while (!given)
			{
                if (isnumber = Int32.TryParse(Console.ReadLine(), out choise))
				{
					if (choise >= 1 && choise <= selections.Count())
					{
						result = selections[choise - 1];
						given = true;
					}
					else
					{
						Console.WriteLine("Invalid Selection");
						continue;
					}
				}
				else
                {
                    Console.WriteLine("Invalid Selection");
					continue;
                }
			}
			return (result);
		}

		static internal int SelectFromList(List<string> selections, bool overide)
		{
			int count = 1;
			bool given = false;
			int choise = 0;
			bool isnumber;
			foreach (var item in selections)
			{
				Console.WriteLine($"{count++}. {item}");
			}
			while (!given)
			{
				if (isnumber = Int32.TryParse(Console.ReadLine(), out choise))
				{
					if (choise >= 1 && choise <= selections.Count())
					{
						given = true;
					}
					else
						Console.WriteLine("Invalid Selection");
				}
				else
                {
					Console.WriteLine("Invalid Selection");
					continue;
                }
			}
			return (choise);
		}

		static internal Trainer SelectFromList(List<Trainer> selections)
		{
			int count = 1;
			bool given = false;
			int choise;
			bool isnumber;
			Trainer result = new Trainer();
			foreach (var item in selections)
			{
				Console.WriteLine($"{count++}. {item}");
			}
			while (!given)
			{
				if (isnumber = Int32.TryParse(Console.ReadLine(), out choise))
				{
					if (choise >= 1 && choise <= selections.Count())
					{
						result = selections[choise - 1];
						given = true;
					}
					else
						Console.WriteLine("Invalid Selection");
				}
                else
                {
					Console.WriteLine("Invalid Selection");
					continue;
                }
			}
			return (result);
		}
	}
}
