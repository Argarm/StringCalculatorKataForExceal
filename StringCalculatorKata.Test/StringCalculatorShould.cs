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
    }

    public class StringCalculator {
        public static int Add(string numbers) {
            if (string.IsNullOrEmpty(numbers))return 0;
            return 1;
        }
    }
}