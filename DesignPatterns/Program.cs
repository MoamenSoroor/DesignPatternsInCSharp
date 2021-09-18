using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Patterns;
using Patterns.Structural;
using Patterns.Structural.DecoratorPattern;
using Patterns.Behavioral.StrategyPattern;
using Patterns.Creational.FactoryMethodPattern;
using Patterns.Creational.SimpleFactoryPattern;
using Patterns.Creational.AbstractFactoryPattern;
using Patterns.Behavioral.VisitorPattern;
using Patterns.Behavioral.RuleBasedEnginePattern;

namespace Patterns
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello Design Patterns!");

			//DecoratorPattern.Test();
			//StrategyPattern.Test();
			//SimpleFactoryPattern.Test();
			//FactoryMethodPattern.Test();
			//AbstractFactoryPattern.Test();


			// Behavioral patterns
			//VisitorPattern.Test();
			RuleBasedEnginePattern.Test();

		}
	}



}
