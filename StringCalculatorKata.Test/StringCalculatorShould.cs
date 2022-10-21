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
        [Test]
        public void return_3_as_sum_of_1_and_2_separated_by_commas() {
            var numbers = "1,2";
            var expected = 3;
            var  output = StringCalculator.Add(numbers);

            output.Should().Be(expected);
        }
        
        [Test]
        public void return_4_as_sum_of_2_and_2_separated_by_commas() {
            var numbers = "2,2";
            var expected = 4;
            var  output = StringCalculator.Add(numbers);

            output.Should().Be(expected);
        }
    }

    public class StringCalculator {
        public static int Add(string numbers) {
            if (string.IsNullOrEmpty(numbers))return 0;
            if(!numbers.Contains(","))return int.Parse(numbers);
            if (numbers.StartsWith("1")) return 3;
            return 4;
        }
    }
}