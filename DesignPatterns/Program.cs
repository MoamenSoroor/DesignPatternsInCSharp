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
using Patterns.Behavioral.TemplateMethodPattern;
using Patterns.Structural.ProxyPattern;

namespace Patterns
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(" ------------------- Design Patterns Tester! -------------------");

			// Creational Patterns
			// -------------------------------------------------
			//SimpleFactoryPattern.Test();
			//FactoryMethodPattern.Test();
			//AbstractFactoryPattern.Test();


			// Structural Patterns
			// -------------------------------------------------
			//DecoratorPattern.Test();
			CachingProxy.Test();


			// Behavioral patterns
			// -------------------------------------------------
			//StrategyPattern.Test();
			//TemplateMethodPattern.Test();
			//VisitorPattern.Test();
			//RuleBasedEnginePattern.Test();

		}
	}



}
