using System;
using System.Linq;
using DataLayer;

namespace ConsoleApp
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			GetCustomers();
		}

		private static void GetCustomers()
		{
			using (var context = new ModelContext())
			{
				var divisions = context.Divisions.ToList();
				foreach (var division in divisions)
				{
					Console.WriteLine(division.Name);
				}
			}
		}
	}
}
