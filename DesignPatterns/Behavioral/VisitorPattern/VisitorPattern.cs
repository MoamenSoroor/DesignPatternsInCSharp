using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral.VisitorPattern
{
    public class VisitorPattern
    {
        public static void Test()
        {
            List<Item> items = new List<Item>
            {
                new Book(12345, 11.99),
                new Book(78910, 22.79),
                new Vinyl(11198, 17.99),
                new Book(63254, 9.79)
            };

            var store = new Store(items);

            IVisitor discountVisitor = new DiscountVisitor();


            store.ApplyVisitor(discountVisitor);
            discountVisitor.Print();

            IVisitor salesVisitor = new SalesVisitor();
            store.ApplyVisitor(salesVisitor);
            salesVisitor.Print();


        }
    }


    // Object Structure
    public class Store
    {
        private readonly List<Item> items;

        public Store(List<Item> items)
        {
            this.items = items;
        }

        

        public void ApplyVisitor(IVisitor visitor)
        {
            items.OfType<IVisitableElement>()
                .ToList()
                .ForEach(item => item.Accept(visitor));
        }


    }


    public interface IVisitor
    {
        void VisitBook(Book book);
        void VisitVinyl(Vinyl vin);
        void Print();
    }


    public interface IVisitableElement
    {
        void Accept(IVisitor visitor);
    }


    public class Item
    {
        public int ID;
        public double Price;

        public Item(int id, double price)
        {
            this.ID = id;
            this.Price = price;
        }

        
        public double GetDiscount(double percentage)
        {
            return Math.Round(Price * percentage, 2);
        }




    }

    public class Book : Item, IVisitableElement
    {
        public Book(int id, double price) : base(id, price) { }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitBook(this);
        }
    }

    public class Vinyl : Item, IVisitableElement
    {
        public Vinyl(int id, double price) : base(id, price) { }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitVinyl(this);
        }
    }


    // visitors

    public class DiscountVisitor : IVisitor
    {
        private double _savings;

        public void VisitBook(Book book)
        {
            var discount = 0.0;

            if (book.Price < 20.00)
            {
                discount = book.GetDiscount(0.10);
                Console.WriteLine($"DISCOUNTED: Book #{book.ID} is now ${Math.Round(book.Price - discount, 2)}");
            }
            else
            {
                Console.WriteLine($"FULL PRICE: Book #{book.ID} is ${book.Price}");
            }

            _savings += discount;
        }

        public void VisitVinyl(Vinyl vinyl)
        {
            var discount = vinyl.GetDiscount(0.15);
            Console.WriteLine($"SUPER SAVINGS: Vinyl #{vinyl.ID} is now ${Math.Round(vinyl.Price - discount, 2)}");

            _savings += discount;
        }

        public void Print()
        {
            Console.WriteLine($"\nYou saved a total of ${Math.Round(_savings, 2)} on today's order!");
        }

        public void Reset()
        {
            _savings = 0.0;
        }
    }


    public class SalesVisitor : IVisitor
    {
        private int BookCount = 0;
        private int VinylCount = 0;

        public void VisitBook(Book book)
        {
            BookCount++;
        }

        public void VisitVinyl(Vinyl vinyl)
        {
            VinylCount++;
        }

        public void Print()
        {
            Console.WriteLine($"Books sold: {BookCount} \nVinyl sold: {VinylCount}");
            Console.WriteLine($"The store sold {BookCount + VinylCount} units today!");
        }
    }
}