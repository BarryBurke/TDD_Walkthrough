using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Walkthrough
{
    public class StringCalculator
    {
        private const string DELIMITER_IDENTIFIER = "//";
        private const string MULTIPLE_CHARACTER_STARTING_DELIMITER_IDENTIFIER = "[";
        private const string MULTIPLE_CHARACTER_ENDING_DELIMITER_IDENTIFIER = "]";
     
        public List<string> Delimiters { get; private set; }

        public StringCalculator()
        {
            Delimiters = new List<string>();
            Delimiters.Add(",");
            Delimiters.Add("\n");
        }
     
        public int Add(string numbers, string[] delimiters)
        {
            Delimiters.AddRange(delimiters.ToList());

            return Add(numbers);
        }

        public int Add(string numbers)
        {
            int result = 0;

            if (numbers.StartsWith(DELIMITER_IDENTIFIER))
            {
                var delimiterIndex = numbers.IndexOf("\n");
                string newDelimiters = numbers.Substring(DELIMITER_IDENTIFIER.Length, delimiterIndex - 2);
              
                if(newDelimiters.Contains(MULTIPLE_CHARACTER_STARTING_DELIMITER_IDENTIFIER) && newDelimiters.Contains(MULTIPLE_CHARACTER_ENDING_DELIMITER_IDENTIFIER))
                {
                    string[] multipleDelimiters = newDelimiters.Split(MULTIPLE_CHARACTER_ENDING_DELIMITER_IDENTIFIER.ToArray(), StringSplitOptions.RemoveEmptyEntries);

                    foreach(var md in multipleDelimiters)
                    {                        
                        Delimiters.Add(md.TrimStart(MULTIPLE_CHARACTER_STARTING_DELIMITER_IDENTIFIER.ToCharArray()));
                    }
                }
                else
                {
                    Delimiters.Add(newDelimiters);
                }
                               
                numbers = numbers.Substring(delimiterIndex + 1); // remove delimiter from string
            }

            string[] nums = numbers.Split(Delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
           
            List<int> negativeNumbers = new List<int>();
            foreach(var n in nums)
            {
                if (string.IsNullOrEmpty(n) == false)
                {
                    int number = int.Parse(n);
                    if(number < 0)
                    {
                        negativeNumbers.Add(number);
                    }
                    else if (number <= 1000)
                    {
                        result += number;
                    } 
                }
            }

            if (negativeNumbers.Count() > 0)
            {
                string message = "Negatives not allowed: [";

                foreach (var n in negativeNumbers)
                    message += n.ToString() + ",";

                message = message.TrimEnd(',');
                message += "]";

                throw new Exception(message);
            }

            return result;
        }
    }
}
