using System;
using System.Globalization;
using System.Collections.Generic;
using WorkerSpace;

namespace WorkerSpace
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Write ("Enter Department's name: ");
			string deptName = Console.ReadLine ();
			Console.WriteLine ("Enter worker data");
			Console.Write ("Name: ");
			string name = Console.ReadLine ();
			int lvl;
			WorkerLevel level = 0;
			do {
				Console.Write ("Level (1-Junior/2-MidLevel/3-Senior): ");
				lvl = int.Parse (Console.ReadLine ());
				switch (lvl) {
				case 1:
					level = WorkerLevel.Junior;
					break;
				case 2:
					level = WorkerLevel.MidLevel;
					break;
				case 3:
					level = WorkerLevel.Senior;
					break;
				default:
					Console.WriteLine (" * invalid number *");
					break;
				}
			} while(lvl < 1 || lvl > 3);
			
			Console.Write ("Base salary: ");
			double baseSalary = double.Parse(Console.ReadLine (), CultureInfo.InvariantCulture);

			Department dept = new Department (deptName);
			Worker worker = new Worker (name, level, baseSalary, dept);

			Console.Write ("How many contracts for this worker? ");
			int n = int.Parse (Console.ReadLine ());

			for(int i=0; i<n; i++)
			{
				Console.WriteLine ("Enter the #{0} contract data: ", i+1);
				Console.Write ("Date (DD/MM/YYYY): ");
				DateTime date = DateTime.Parse(Console.ReadLine());
				Console.Write ("Value per hour: ");
				double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
				Console.Write ("Duration (hours): ");
				int hours = int.Parse(Console.ReadLine());

				HourContract contract = new HourContract(date, valuePerHour, hours);
				worker.AddContract(contract);
			}

			Console.WriteLine ();
			Console.Write ("Enter month and year to calculate income(MM/YYYY): ");
			string monthAndYear = Console.ReadLine ();
			int month = int.Parse (monthAndYear.Substring (0, 2));
			int year = int.Parse (monthAndYear.Substring (3));
			Console.WriteLine ();
			Console.WriteLine ("Name: "+ worker.Name);
			Console.WriteLine ("Department: "+ worker.Department.Name);
			Console.WriteLine ("Income for " + monthAndYear + ": "  + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

			Console.ReadLine ();
		}
	}
}