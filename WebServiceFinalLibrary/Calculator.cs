using System;
namespace WebServiceFinalLibrary
{
    public class Calculator
    {
        
            static public double addition(double value1, double value2)
            {
                return value1 + value2;
            }

            static public double subtraction(double value1, double value2)
            {
                return value1 - value2;
            }

            static public double multipication(double value1, double value2)
            {
                return value1 * value2;
            }

            static public double division(double value1, double value2)
            {
                if (value2 == 0.0)
                    throw new DivideByZeroException("Cannot divide by Zero");
                return value1 / value2;

            
        }
    }
}
