using IndividualPartA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualPartA.BussinessLogic
{
    class TrainerData
    {
		static internal List<Trainer> GetData(List<Trainer> trainers)
		{
			if (!PrivateSchool.syntheticData)
			{
				Console.WriteLine("Number of trainers to input: ");
				int numOfItems = int.Parse(Console.ReadLine());
				for (int i = 0; i < numOfItems; i++)
				{
					Console.WriteLine("Trainer " + (i + 1) + ":");
					trainers.Add(GetTrainerDetails());
				}
			}
			else
				trainers = GenerateTrainerDetails(trainers);
			return (trainers);
		}

		static internal Trainer GetTrainerDetails()
		{
			List<string> subjects = new List<string> { "C#", "Java", "Python", "Javascript" };
			Trainer trainer = new Trainer();
			trainer.FirstName = CommandPromtUtilities.AskDetails("First name");
			trainer.LastName = CommandPromtUtilities.AskDetails("Last name");
			trainer.Subject = CommandPromtUtilities.AskDetails("Choose a subject from the following list", subjects);
			return (trainer);
		}

		static internal List<Trainer> GenerateTrainerDetails(List<Trainer> trainers)
		{
			trainers.Add(new Trainer("Akis", "White", "C#"));
			trainers.Add(new Trainer("Pakis", "Brown", "C#"));
			trainers.Add(new Trainer("Makis", "Green", "Java"));
			trainers.Add(new Trainer("Takis", "Color", "Java"));
			trainers.Add(new Trainer("Sakis", "Black", "Java"));
			return (trainers);
		}

		static internal List<Trainer> AutoAssignTrainers(List<Trainer> trainers, string subject, string type)
        {
			List<Trainer> courseTrainers = new List<Trainer>();
			if (subject == "C#")
			{
				if (type == "Full Time")
					courseTrainers.Add(trainers[0]);
				else
					courseTrainers.Add(trainers[1]);
			}
			else
			{
				if (type == "Full Time")
					courseTrainers.Add(trainers[2]);
				else
				{
					courseTrainers.Add(trainers[3]);
					courseTrainers.Add(trainers[4]);
				}
			}
			return (courseTrainers);
		}

		static internal List<Trainer> ManuallyAssignTrainers(List<Trainer> trainers, string subject, string type)
        {
			List<Trainer> courseTrainers = new List<Trainer>();
			bool assigning = true;
			List<Trainer> selections = new List<Trainer>();
			foreach (var item in trainers)
			{
				if (item.Subject == subject)
				{
					selections.Add(item);
				}
			}
			if (selections.Count > 0)
			{
				int i = 0;
				while (assigning)
				{
					Console.WriteLine("Please assign a trainer for the course from the following list of available teachers:");
					courseTrainers.Add(CommandPromtUtilities.SelectFromList(selections));
					selections.Remove(courseTrainers[i]);
					i++;
					if (selections.Count > 0)
						assigning = CommandPromtUtilities.YesOrNo("Would you like to add another trainer on the same class?");
					else
						assigning = false;
				}
			}
			return (courseTrainers);
		}

		static internal void PrintList(List<Trainer> trainers)
		{
			int i = 1;
			foreach (var item in trainers)
			{
				Console.WriteLine("Trainer_" + i + ": \n" + item + "\n");
				i++;
			}
		}
	}
}
