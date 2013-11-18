using Machine.Specifications;
using ShoppingBasket.Domain;

namespace ShoppingBasket.ConsoleApplication.ProgramSpecs
{
    public class when_the_user_adds_the_products_and_gift_vouchers_to_shopping_cart : ApplyVoucherSpecification
    {
        private Establish context = () =>
        {
            the_shopping_cart = new ShoppingCart();
            the_shopping_cart.Items.Add(new Item() { Product = new GiftVoucher() { Cost = 30 }, Id = 3, Quantity = 2 });
            the_shopping_cart.Items.Add(new Item() { Product = new Product() { Cost = 40 }, Id = 3, Quantity = 2 });
            the_voucher = new Voucher() { Code = "YYY-YYYY", DiscountCost = 5M, VoucherType = VoucherType.AppliedOnlyForProductsExcludingGiftVouchers };
        };

        private Because of = () => subject.ApplyVoucherOnBasket(the_shopping_cart, the_voucher);
        It should_apply_the_voucher_as_the_threshold_is_not_met = () => the_shopping_cart.TotalCostAfterDiscount.ShouldEqual(130);
    }
}