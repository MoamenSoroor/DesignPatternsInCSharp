using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.RuleBasedEnginePattern
{
    class RuleBasedEnginePattern
    {
        public static void Test()
        {
            Customer customer = new Customer()
            {
                Id=200,
                Name = "Moamen",
                 TotalPurchases=21_000m,
                 FirstPurchase=DateTime.Now.AddYears(-15)
            };

            DiscountCalculator calculator = new DiscountCalculator();


            var discount = calculator.CalculateDiscountPercentage(customer);

            Console.WriteLine($"discount is {discount}");

        }
    }

    public class Customer
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public decimal TotalPurchases { get; init; }

        public DateTime? FirstPurchase { get; init; }


    }


    public interface IDiscountRule
    {
        decimal CalculateDiscount(Customer customer, decimal currentDiscount);
    }


    public class EmptyRule : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            return currentDiscount;
        }

    }

    public class Rule1 : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            return customer.Name == "Moamen" ? currentDiscount + 2.0m:currentDiscount;
        }
    }

    public class Rule2 : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            return customer.TotalPurchases > 20000 ? currentDiscount + 3m : currentDiscount;
        }
    }


    public class Rule3 : IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount)
        {
            if (!customer.FirstPurchase.HasValue)
                return currentDiscount;

            return customer.FirstPurchase.Value < DateTime.Now.AddYears(-10)
                ? currentDiscount + 7.0m : currentDiscount;                
        }
    }

    public class DiscountRuleEngine
    {
        private List<IDiscountRule> rules;

        public DiscountRuleEngine(List<IDiscountRule> rules)
        {
            this.rules = rules ?? new List<IDiscountRule>();
        }

        public decimal CalculateDiscountPercentage(Customer customer)
        {
            decimal discount = 0.0m;

            rules.ForEach(rule =>
                discount = Math.Max(discount,rule.CalculateDiscount(customer,discount))
            );
            return discount;
        }
    }



    public class DiscountCalculator
    {

        public DiscountCalculator()
        { }

        public decimal CalculateDiscountPercentage(Customer customer)
        {
            List<IDiscountRule> rules = new List<IDiscountRule>()
            {
                new Rule1(),new Rule2(), new Rule3()
            };

            var engine = new DiscountRuleEngine(rules);

            return engine.CalculateDiscountPercentage(customer);
        }
    }
















}
