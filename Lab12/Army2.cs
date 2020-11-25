using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12
{
    partial class Army : IController
	{
		public void Print()
		{
			for (int j = 0; j < Elements.Count; j++)
			{
				Console.WriteLine(Elements[j]);
			}
		}

		public void DateFind()
		{
			Console.WriteLine();
			Console.WriteLine("Введите дату рождения: ");
			int date = Convert.ToInt32(Console.ReadLine());
			for (int j = 0; j < Elements.Count; j++)
			{
				if(Elements[j].Year == date)
				Console.WriteLine(Elements[j]);
			}
			Console.WriteLine();
		}

		public void TransformerPowerFind()
		{
			Console.WriteLine("Введите мощность трансформера: ");
			string power = Console.ReadLine();
			for (int j = 0; j < Elements.Count; j++)
			{
				if (Elements[j].Power == power && Elements[j].TypeOfTroop == TroopType.Transformer)
					Console.WriteLine(Elements[j]);
			}
			Console.WriteLine();
		}

		public void Count()
		{
			Console.WriteLine($"Количество боевых единиц: {Elements.Count}");
		}
	}
}
