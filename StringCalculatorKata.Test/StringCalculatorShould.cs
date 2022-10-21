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
    }

    public class StringCalculator {
        public static int Add(string numbers) {
            return 0;
        }
    }
}