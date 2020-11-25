using System;
using System.Collections.Generic;
using System.Text;
using Lab12;

namespace Lab12
{
	public enum TroopType
	{
		Human,
		Transformer
	}

	public struct Troop
	{
		public TroopType TypeOfTroop;
		public int Price;
		public int Year;
		public string Power;

		public Troop(TroopType TypeOfTroop, int Price, int Year, string Power)
		{
			this.TypeOfTroop = TypeOfTroop;
			this.Price = Price;
			this.Year = Year;
			this.Power = Power;
		}

		public override string ToString()
		{
			return $"Power: {Power}, Price: {Price}, Year: {Year}, Type: {TypeOfTroop}";
		}
	}
	partial class Army: IController
    {
		List<Troop> Elements;

		public Army()
		{
			Elements = new List<Troop>();
		}

		public Army(params Troop[] Elements)
		{
			this.Elements = new List<Troop>();
			for (int i = 0; i < Elements.Length; i++)
				this.Elements.Add(Elements[i]);
		}
	}

}
