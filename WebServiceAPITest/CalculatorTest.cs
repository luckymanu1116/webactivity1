using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebServiceFinalLibrary;
namespace WebServiceAPITest
{
    [TestClass]
    public class CalculatorTest
    {


        public class SimpleCalculatorTest
        {
            [TestMethod]
            [DataRow(2, 4)]
            [DataRow(8, 1)]
            [DataRow(0, 8)]

            // Add v1 + v2 = v1 + v2
            public void Addition(double v1, double v2)
            {
                double v1Addv2 = Calculator.addition(v1, v2);
                double v2Addv1 = Calculator.addition(v2, v1);
                Assert.AreEqual(v1Addv2, v2Addv1);
            }

            [TestMethod]
            [DataRow(1, 6)]
            [DataRow(0, 2)]
            [DataRow(8, 3)]

            // Subtract v1 - v2 = v1 - v2
            public void Subtraction(double v1, double v2)
            {
                double v1Subv2 = Calculator.addition(v1, v2);
                double v2Subv1 = Calculator.addition(v2, v1);
                Assert.AreEqual(v1Subv2, v2Subv1);
            }

            [TestMethod]
            [DataRow(4, 0)]
            [DataRow(0, 8)]
            // Test Case Addition with Zero is equivalent to none zero value
            //  v1 + 0 = v1 and  0 + v2 = v2
            public void AdditionWithZero(double v1, double v2)
            {
                if (v1 == 0)
                {
                    Assert.AreEqual(v2, Calculator.addition(v1, v2));
                }
                else if (v2 == 0)
                {
                    Assert.AreEqual(v2, Calculator.addition(v1, v2));
                }
            }

            [TestMethod]
            [DataRow(6, 0)]
            [DataRow(0, 5)]
            // Test Case Subtraction with Zero
            //  v1 - 0 = v1 and 0 - v2 != -v2
            public void SubtractionWithZero(double v1, double v2)
            {
                if (v1 == 0)
                {
                    Assert.AreNotEqual(v2, Calculator.subtraction(v1, v2));
                    //Assert.Negative(Calculator.subtraction(v1, v2));
                }
                else if (v2 == 0)
                {
                    Assert.AreEqual(v1, Calculator.addition(v1, v2));
                }
            }

            [TestMethod]
            [DataRow(4, 8)]
            [DataRow(8, 8)]
            [DataRow(45, 12)]
            // Test Case v1 - v2 is not equal to v2 - v1, until and unless both values are the same.
            public void SubrtractionCommutative(double v1, double v2)
            {
                if (v1 != v2)
                {
                    Assert.AreNotEqual(Calculator.subtraction(v1, v2), Calculator.subtraction(v1, v2));
                }
            }


            [TestMethod]
            [DataRow(4, 7)]
            [DataRow(8, 8)]
            [DataRow(42, 13)]
            // Test Case v1 / v2 is not equal to v2 / v1, unless both values are the same.
            public void DivisionCommutative(double v1, double v2)
            {
                if (v1 != v2)
                {
                    Assert.AreNotEqual(Calculator.division(v1, v2), Calculator.division(v2, v1));
                }
            }


            [TestMethod]
            [DataRow(1, 5)]
            [DataRow(45, 1)]
            // Test Case multipication with one:
            // a * 1 = 1 * a = a
            public void MultiplicationIdentity(double v1, double v2)
            {
                if (v1 == 1)
                {
                    Assert.AreEqual(v2, Calculator.multipication(v1, v2));
                }
                else if (v2 == 1)
                {
                    Assert.AreEqual(v1, Calculator.multipication(v1, v2));
                }
            }


            [DataTestMethod]
            [DataRow(8)]
            // multiplicatication inverse of a is 1/v1, for 6 it's 1/6 which means 6 of 1/6 = 1
            public void MultiplicatipicationInverseIsReciprocal(double v1)
            {
                Assert.AreEqual(Calculator.multipication(v1, 1 / v1), 1);
            }

            [TestMethod]
            [DataRow(6)]
            [DataRow(1)]
            [DataRow(2344)]
            // Test Case Zero divide by any number:  0 / v1 = 0
            public void DivisionOfZeroByAnyNumberIsZero(double v1)
            {
                if (v1 != 0)
                    Assert.IsTrue(Calculator.division(0, v1) == 0);
            }

            [DataTestMethod]
            [DataRow(6, 0)]
            // Test case Any number divide by zero throws divide by zero exception : 4/0

            public void DivisionByZeroIsHandledByException(double v1, double v2)
            {
                Assert.ThrowsException<DivideByZeroException>(() => Calculator.division(v1, v2));
            }



            [TestMethod]
            [DataRow(5, 9)]
            [DataRow(3, 3)]
            [DataRow(4, 7)]
            // Adding two odd numbers is even: 3+5 = 8
            public void AddingTwoOddNumbersIsEven(int v1, int v2)
            {
                if (isOdd(v1) && isOdd(v2))
                {
                    Assert.IsTrue(isEven(Convert.ToInt32(Calculator.addition(v1, v2))));
                }
            }

            [DataTestMethod]
            [DataRow(3, 3)]
            [DataRow(7, 15)]
            // Multiplying two odd number is odd : 3*1=3
            public void MultiplyingTwoOddNumberResultsInOddNumber(int v1, int v2)
            {
                if (isOdd(v1) && isOdd(v2))
                {
                    Assert.IsTrue(isOdd(Convert.ToInt32(Calculator.multipication(v1, v2))));
                }
            }

            [TestMethod]
            [DataRow(2, 4)]
            // Adding two even numbers is even :2 + 2 = 4
            public void AddingTwoEvenNumbersIsEven(int v1, int v2)
            {

                if (isEven(v1) && isEven(v2))
                {
                    Assert.IsTrue(isEven(Convert.ToInt32(Calculator.addition(v1, v2))));
                }
            }



            public bool isOdd(int number) => number % 2 != 0;

            public bool isEven(int number) => number % 2 == 0;



        }
    }
}
