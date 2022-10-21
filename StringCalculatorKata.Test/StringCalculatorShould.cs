using FluentAssertions;
using FluentAssertions.Specialized;
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

        [TestCase("1,2,3",6)]
        [TestCase("1,2,3,4",10)]
        [TestCase("1,2,3,4,5",15)]
        public void sum_more_than_two_numbers_separated_by_commas(string numbers, int expected) {
            var output = StringCalculator.Add(numbers);

            output.Should().Be(expected);
        }

        [Test]
        public void sum_numbers_with_new_line_and_commas_as_separators() {
            var numbers = "1\n2,3";

            var output = StringCalculator.Add(numbers);

            output.Should().Be(6);
        }

        [Test]
        public void sum_numbers_with_new_line_at_the_start_and_commas_as_separators() {
            var numbers = "\n1,2,3";

            var output = StringCalculator.Add(numbers);

            output.Should().Be(6);
        }

        [Test]
        public void support_different_separator() {
            var numbers = "//;\n1;2;3";

            var output = StringCalculator.Add(numbers);

            output.Should().Be(6);
        }
        
        [Test]
        public void do_not_allow_a_negative_numbers() {
            var numbers = "-1";

            Action act = () => StringCalculator.Add(numbers);

            act.Should().Throw<NegativeNotAllowedException>().WithMessage("Negatives not allowed -1");
        }

    }

    public class NegativeNotAllowedException : Exception {
        public NegativeNotAllowedException(string numbers) : base($"Negatives not allowed {numbers}") {

        }
    }

    public class StringCalculator {
        private static string Separator = ",";

        public static int Add(string numbers) {
            if (string.IsNullOrEmpty(numbers))return 0;
            if (HasDifferentSeparator(numbers)) {
                SetDifferentSeparator(numbers);
                numbers = numbers.Substring(3);
            }
            var normalizedNumbers = Normalize(numbers);
            var splitedNumbers = Split(normalizedNumbers);
            var parsedNumbers = splitedNumbers.Select(int.Parse);
            return parsedNumbers.Sum();
        }

        private static string SetDifferentSeparator(string numbers) {
            return Separator = numbers.Substring(2, 1);
        }

        private static bool HasDifferentSeparator(string numbers) {
            return numbers.StartsWith("//");
        }

        private static List<string> Split(string normalizedNumbers) {
            return normalizedNumbers.Split(Separator).ToList();
        }

        private static string Normalize(string numbers) {
            return numbers.Trim().Replace("\n", ",");
        }
    }
}