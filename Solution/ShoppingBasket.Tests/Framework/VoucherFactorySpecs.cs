using System.Collections.Generic;
using Machine.Specifications;
using ShoppingBasket.Domain;
using ShoppingBasket.Framework.Factories;

namespace ShoppingBasket.Tests.Framework
{
    public class when_voucher_factory_is_asked_to_Return_static_vouchers
    {
        private static List<Voucher> the_vouchers;

        private Establish context = () =>
                                        {
                                            the_vouchers = new List<Voucher>();
                                        };
        private Because of = () => the_vouchers = VoucherFactory.Vouchers;
        private It should_return_the_list_of_vouchers = () => the_vouchers.Count.ShouldEqual(2);
        private It should_get_the_first_voucher_as_XXX = () => the_vouchers[0].Code.ShouldEqual("XXX-XXXX");
        private It should_get_the_second_voucher_as_YYY = () => the_vouchers[1].Code.ShouldEqual("YYY-YYYY");
    }
}
