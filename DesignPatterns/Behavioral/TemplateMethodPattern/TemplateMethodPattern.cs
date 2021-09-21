using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.TemplateMethodPattern
{
	public class TemplateMethodPattern
	{
		public static void Test()
		{
			var tea = new Tea();
			tea.Prepare();
			Console.WriteLine("".PadLeft(40, '='));
			var coffee = new Coffee();
			coffee.Prepare();

		}
	}


	public abstract class Beverage
	{

		// template method
		public void Prepare()
		{
			BoilWater();
			AddMainComponent();
			AddWaterToCup();
			AddMilk();
			AddSuger();
			AddMoreThings();
		}

		private void BoilWater()
		{
			Console.WriteLine("Boil Water.");
		}

		private void AddSuger()
		{
			Console.WriteLine("Add Suger.");

		}


		private void AddWaterToCup()
		{
			Console.WriteLine("Add water to Cup.");

		}

		protected abstract void AddMainComponent();


		// hook
		protected void AddMoreThings()
		{
		}

		//hook
		protected void AddMilk()
		{
		}



	}



	public class Tea : Beverage
	{
		protected override void AddMainComponent()
		{
			Console.WriteLine("Add Tea...");
		}
	}

	public class Coffee : Beverage
	{
		protected override void AddMainComponent()
		{
			Console.WriteLine("Add Coffee...");
		}
	}



}