using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12.Model
{
    public class Calculation
    {
        public double First { get; set; }
        public double Second { get; set; }
        public string Operation { get; set; }

        public Calculation() { }

        public Calculation(double first, double second, string operation)
        {
            First = first;
            Console.WriteLine(first + second + operation);
            Second = second;
            Operation = operation;
        }

        public string Calculate()
        {
            Console.WriteLine(Operation);
            var result = Operation switch
            {
                "+" => $"{First} + {Second} = {First + Second}",
                "-" => $"{First} - {Second} = {First - Second}",
                "*" => $"{First} * {Second} = {First * Second}",
                "/" => Second != 0 ? $"{First} / {Second} = {First / Second}" : "Division by 0",
                _ => "Invalid operation."
            };
            return result;
        }
    }

}
