using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using ShoppingBasket.Client.Contracts;
using ShoppingBasket.Domain;
using ShoppingBasket.Domain.Shared;

namespace ShoppingBasket.ConsoleApplication.ProgramSpecs
{
    public class when_a_user_selects_a_product_and_quantity_to_add_to_shoppingcart : Specification<Program>
    {
        private static IProductTasks the_product_tasks;
        private static GenericProduct the_product;
        private static IShoppingCartTasks the_shopping_cart_tasks;
        private static Item the_shopping_cart_item;
        private static GenericProduct the_gift_voucher;
        private static ShoppingCart the_shopping_cart;

        private const int PRODUCT_ID = 1;
        private const int QUANTITY = 1;
        private const string Description = "TestProduct";
        private const decimal ProductCost = 10M;

        private const decimal TotalBasketCost = 20M;

        private Establish context = () =>
        {
            the_shopping_cart_tasks = DependencyOf<IShoppingCartTasks>();
            the_product_tasks = DependencyOf<IProductTasks>();
            the_product = new Product(){ Cost = ProductCost, Description=Description,Id = PRODUCT_ID, Name=Description };
            the_gift_voucher = new GiftVoucher() { Cost = ProductCost, Description = Description, Id = PRODUCT_ID, Name = Description };
            the_shopping_cart = new ShoppingCart() { Items = new List<Item>() 
            { new Item() { Id=1, Product = the_product, Quantity = QUANTITY },
                new Item() { Id=2, Product = the_gift_voucher, Quantity = QUANTITY }} 
            };

            the_product_tasks.Stub(x => x.GetProductById(PRODUCT_ID)).Return(the_product);
            the_shopping_cart_item = new Item(){Product = the_product, Quantity = QUANTITY};
            the_shopping_cart_tasks.Stub(x => x.AddToShoppingCart(the_shopping_cart_item)).IgnoreArguments().Return(the_shopping_cart);
        };

        private Because of = () => subject.AddToShoppingCart(PRODUCT_ID.ToString());
        private It should_check_if_the_product_exists = () => the_product.ShouldNotBeNull();
        private It should_then_be_added_to_shopping_cart_get_total_cost_of_basket = () => the_shopping_cart.TotalCost.ShouldEqual(TotalBasketCost);
        private It should_return_the_basket_cost_excluding_gift_vouchers =
            () => the_shopping_cart.TotalCostExcludingGiftVouchers.ShouldEqual(ProductCost);
    }
}