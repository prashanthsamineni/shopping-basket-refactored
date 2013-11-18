using Machine.Specifications;
using ShoppingBasket.Framework;

namespace ShoppingBasket.Tests.Framework
{
    public class when_utilities_is_asked_to_generate_random_number
    {
        private static int the_integer;

        private Establish context = () =>
                                        {
                                            the_integer = 0;
                                        };

        private Because of = () => the_integer = Utilities.GenerateRandomNumber();
        private It should_return_a_random_integer_less_than_100 = () => the_integer.ShouldBeLessThan(100);
        private It should_return_a_random_integer_greater_than_1 = () => the_integer.ShouldBeGreaterThan(1);
    }
}
