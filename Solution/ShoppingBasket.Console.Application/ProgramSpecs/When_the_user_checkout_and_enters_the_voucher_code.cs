using Machine.Specifications;
using ShoppingBasket.Domain;

namespace ShoppingBasket.ConsoleApplication.ProgramSpecs
{
    public class When_the_user_checkout_and_enters_the_voucher_code : ApplyVoucherSpecification
    {
        private Establish context = () =>
        {
            the_voucher = new Voucher(){Code = "XXX-XXXX", DiscountCost = 5M, VoucherType = VoucherType.AppliedForBasketTotal};
        };
        Because of = () => subject.ApplyVoucherOnBasket(the_shopping_cart, the_voucher);        
        private It should_apply_discount_on_total_amount_if_threshold_is_met = () => the_shopping_cart.TotalCostAfterDiscount.ShouldEqual(90M);
    }
}