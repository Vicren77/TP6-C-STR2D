
using System;
using System.Collections.Generic;

namespace TP6_Ren_VICTOR_STR2D
{
  
    public interface IBuilderPizza
    {
        void AddTomato();

        void AddAnanas();

        void AddShrimp();
    }

    
    public class PizzaHouseBuilder: IBuilderPizza
    {
        private Product _product = new Product();

        public PizzaHouseBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        // All production steps work with the same product instance.
        public void AddTomato()
        {
            this._product.Add("TOMATOES");
        }

        public void AddAnanas()
        {
            this._product.Add("ANANAS OMG");
        }

        public void AddShrimp()
        {
            this._product.Add("SHRIMP SIMP");
        }

        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }

  
    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); 

            return "A Pizza with: " + str + "\n";
        }
    }

    public class Director
    {
        private IBuilderPizza _builder;

        public IBuilderPizza Builder
        {
            set { _builder = value; }
        }

        public void AddOneToppings()
        {
            this._builder.AddTomato();
        }

        public void AddAllToppings()
        {
            this._builder.AddTomato();
            this._builder.AddAnanas();
            this._builder.AddShrimp();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The client code creates a builder object, passes it to the
            // director and then initiates the construction process. The end
            // result is retrieved from the builder object.
            var director = new Director();
            var builder = new PizzaHouseBuilder();
            director.Builder = builder;

            Console.WriteLine("Classic Pizza:");
            director.AddOneToppings();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Deluxe Pizza:");
            director.AddAllToppings();
            Console.WriteLine(builder.GetProduct().ListParts());

            // Remember, the Builder pattern can be used without a Director
            // class.
            Console.WriteLine("Custom PIZZA:");
            builder.AddTomato();
            builder.AddShrimp();
            Console.Write(builder.GetProduct().ListParts());
        }
    }
}
