using FluentAssertions;
using NUnit.Framework;

namespace StringCalculatorKata.Test
{
    public class StringCalculatorShould {
        [Test]
        public void return_0_for_empty_string() {
            var numbers = string.Empty;

            var  output = StringCalculator.Add(numbers);

            output.Should().Be(0);
        }
        
        [TestCase("1",1)]
        [TestCase("2",2)]
        public void return_same_number_as_int(string numbers, int expected) {
            var  output = StringCalculator.Add(numbers);

            output.Should().Be(expected);
        }
        [TestCase("1,2",3)]
        [TestCase("2,2",4)]
        [TestCase("3,3",6)]
        public void return_sum_numbers_separated_by_commas(string numbers, int expected) {
            var  output = StringCalculator.Add(numbers);

            output.Should().Be(expected);
        }

        [Test]
        public void sum_three_numbers_separated_by_commas() {
            var numbers = "1,2,3";
            var expected = 6;

            var output = StringCalculator.Add(numbers);

            output.Should().Be(expected);
        }
        
        [Test]
        public void sum_four_numbers_separated_by_commas() {
            var numbers = "1,2,3,4";
            var expected = 10;

            var output = StringCalculator.Add(numbers);

            output.Should().Be(expected);
        }
        
        [Test]
        public void sum_five_numbers_separated_by_commas() {
            var numbers = "1,2,3,4,5";
            var expected = 15;

            var output = StringCalculator.Add(numbers);

            output.Should().Be(expected);
        }


    }

    public class StringCalculator {
        private static string Separator = ",";

        public static int Add(string numbers) {
            if (string.IsNullOrEmpty(numbers))return 0;
            if(!numbers.Contains(Separator))return int.Parse(numbers);
            var splitedNumbers = numbers.Split(Separator);
            if (splitedNumbers.Length==2)return int.Parse(splitedNumbers[0]) + int.Parse(splitedNumbers[1]);
            if (splitedNumbers.Length == 3) return int.Parse(splitedNumbers[0]) + int.Parse(splitedNumbers[1]) + int.Parse(splitedNumbers[2]);
            return int.Parse(splitedNumbers[0]) + int.Parse(splitedNumbers[1]) + int.Parse(splitedNumbers[2]) + int.Parse(splitedNumbers[3]);
        }
    }
}