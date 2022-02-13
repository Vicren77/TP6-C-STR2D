using System;
using System.Collections.Generic;
using System.Text;


namespace TP6_Ren_VICTOR_STR2D
{
   
    public sealed class DesignSingleton
    {
        
        private DesignSingleton() { }
    
        private static DesignSingleton instance;

        public static void LogicBusiness()
        {
        }
        public static DesignSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DesignSingleton();
            }
            return instance;
        }

      
        
    }

    class exo4
    {
        static void Main(string[] args)
        {
            DesignSingleton variable1 = DesignSingleton.GetInstance();
            DesignSingleton variable2 = DesignSingleton.GetInstance();

            if (variable1 == variable2)
            {
                Console.WriteLine("Desgin pattern singleton succes, the singleton are in the same instance");
            }
            else
            {
                Console.WriteLine("Desgin pattern singleton failed, variables contain different instances.");
            }
        }
    }
}