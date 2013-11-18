using Machine.Specifications;
using ShoppingBasket.Domain;

namespace ShoppingBasket.ConsoleApplication.ProgramSpecs
{
    public class When_the_user_checkout_and_selects_less_then_threshold : ApplyVoucherSpecification
    {
        private Establish context = () =>
        {
            the_shopping_cart = new ShoppingCart();
            the_shopping_cart.Items.Add(new Item()
            {
                Product = new GiftVoucher() {Cost = 10},
                Id = 3,
                Quantity = 2
            });
            the_voucher = new Voucher()
            {
                Code = "YYY-YYYY",
                DiscountCost = 5M,
                VoucherType =
                    VoucherType.
                        AppliedOnlyForProductsExcludingGiftVouchers
            };
        };
        Because of = () => subject.ApplyVoucherOnBasket(the_shopping_cart, the_voucher);
        It should_not_apply_any_voucher_as_the_threshold_is_not_met = () => the_shopping_cart.TotalCostAfterDiscount.ShouldEqual(the_shopping_cart.TotalCost);
    }
}