using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD_Walkthrough.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {      
        [TestMethod]
        public void Add_WhenAnEmptyStringIsUsedThenZeroIsReturned()
        {
            StringCalculator sc = new StringCalculator();
            string emptyParameter = string.Empty;

            var result = sc.Add(emptyParameter);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_WhenOneNumberIsUsedThenThatNumberIsReturned()
        {
            StringCalculator sc = new StringCalculator();
            string oneNumberParameter = "1";

            var result = sc.Add(oneNumberParameter);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Add_WhenTwoNumbersAreUsedThenTheSumOfTheNumbersIsReturned()
        {
            StringCalculator sc = new StringCalculator();
            string twoNumberParameter = "1,2";

            var result = sc.Add(twoNumberParameter);
            Assert.AreEqual(1+2, result);
        }

        [TestMethod]
        public void Add_WhenAnyNumbersofNumbersAreUsedThenTheSumOfTheNumbersIsReturned()
        {
            StringCalculator sc = new StringCalculator();
            string twoNumberParameter = "1,2,3,4,5";

            var result = sc.Add(twoNumberParameter);
            Assert.AreEqual(1 + 2 + 3 + 4 + 5, result);
        }

        [TestMethod]
        public void Add_WhenANewLineCharacterIsUsedThenItIsTreatedAsADelimiterAndTheSumOfTheNumbersIsReturned()
        {
            StringCalculator sc = new StringCalculator();
            string twoNumberParameter = "1,2\n3,4,5";

            var result = sc.Add(twoNumberParameter);
            Assert.AreEqual(1 + 2 + 3 + 4 + 5, result);
        }

        [TestMethod]
        public void Add_WhenADelimiterParameterIsSpecfiedThenItIsUsedToSeparateTheNumbers()
        {
            StringCalculator sc = new StringCalculator();
            string twoNumberParameter = "1;2;3;4;5";
            string[] delimiters = new string[] { ";" };

            var result = sc.Add(twoNumberParameter, delimiters);
            Assert.AreEqual(1 + 2 + 3 + 4 + 5, result);
        }

        [TestMethod]
        public void Add_WhenASingleCharacterDelimiterIsSpecfiedInTheNumberParameterThenItIsUsedToSeparateTheNumbers()
        {
            StringCalculator sc = new StringCalculator();
            string numbersParameter = "//;\n1;2;3;4;5";

            var result = sc.Add(numbersParameter);
            Assert.AreEqual(1 + 2 + 3 + 4 + 5, result);
        }

        [TestMethod]
        public void Add_WhenAMultipleCharacterDelimiterIsSpecfiedInTheNumberParameterThenItIsUsedToSeparateTheNumbers()
        {
            StringCalculator sc = new StringCalculator();
            string numbersParameter = "//[---]\n1---2---3---4---5";

            var result = sc.Add(numbersParameter);
            Assert.AreEqual(1 + 2 + 3 + 4 + 5, result);
        }

        [TestMethod]
        public void Add_WhenManySingleCharacterDelimitersAreSpecfiedInTheNumberParameterThenTheyAreUsedToSeparateTheNumbers()
        {
            StringCalculator sc = new StringCalculator();
            string numbersParameter = "//[-][%]\n1-2-3%4%5";

            var result = sc.Add(numbersParameter);
            Assert.AreEqual(1 + 2 + 3 + 4 + 5, result);
        }

        [TestMethod]
        public void Add_WhenManyMultipleCharacterDelimitersAreSpecfiedInTheNumberParameterThenTheyAreUsedToSeparateTheNumbers()
        {
            StringCalculator sc = new StringCalculator();
            string numbersParameter = "//[--][%%]\n1--2--3%%4%%5";

            var result = sc.Add(numbersParameter);
            Assert.AreEqual(1 + 2 + 3 + 4 + 5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Add_WhenAnyNonNumberIsUsedThenAnExceptionIsThrown()
        {
            StringCalculator sc = new StringCalculator();
            string invalidNumberParameter = "1,X";

            sc.Add(invalidNumberParameter);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Add_WhenAnyNegativeNumberIsUsedThenAnExceptionIsThrown()
        {
            StringCalculator sc = new StringCalculator();
            string negativeNumbersParameter = "1,-2,3,4,-5";

            sc.Add(negativeNumbersParameter);
        }

        [TestMethod]
        public void Add_WhenAnyNegativeNumberIsUsedThenAnNegativeNumbersAreReturnedInTheThrownException()
        {
            Exception exception = null;
            try
            {
                StringCalculator sc = new StringCalculator();
                string negativeNumbersParameter = "1,-2,3,4,-5";

                sc.Add(negativeNumbersParameter);
            }
            catch(Exception e)
            {
                exception = e;
            }
            Assert.IsNotNull(exception);
            Assert.AreEqual("Negatives not allowed: [-2,-5]", exception.Message);
        }

        [TestMethod]
        public void Add_WhenAnyNumbersGreaterThan1000AreUsedThenTheseAreExcludedFromTheSum()
        {
            StringCalculator sc = new StringCalculator();
            string numbersParameter = "1,2,3000,4,5";

            var result = sc.Add(numbersParameter);
            Assert.AreEqual(1 + 2 + 4 + 5, result);
        }

        //[TestMethod]
        //[ExpectedException(typeof(Exception))]
        //public void Add_WhenMoreThanTwoNumberAreUsedThenAnExceptionIsThrown()
        //{
        //    StringCalculator sc = new StringCalculator();
        //    string manyNumbersParameter = "1,2,4";

        //    sc.Add(manyNumbersParameter);
        //}

    }
}
