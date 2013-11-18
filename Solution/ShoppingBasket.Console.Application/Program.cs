using System;
using System.Collections.Generic;
using ShoppingBasket.Client.Contracts;
using ShoppingBasket.ConsoleApplication.Contracts;
using ShoppingBasket.Domain;
using ShoppingBasket.Domain.Shared;

namespace ShoppingBasket.ConsoleApplication
{
    public class Program
    {
        private const string CheckoutUserInput = "0";

        private IProductTasks productTasks;

        private IShoppingCartTasks shoppingCartTasks;

        private IVoucherTasks voucherTasks;

        private static DefaultConsole defaultConsole;

        /// <summary>
        /// Initializes a new instance of the <see cref="Program"/> class.
        /// </summary>
        /// <param name="defaultConsole">The default console.</param>
        /// <param name="productTasks">The product tasks.</param>
        /// <param name="shoppingCartTasks">The shopping cart tasks.</param>
        /// <param name="voucherTasks">The voucher tasks.</param>
        public Program(DefaultConsole defaultConsole, IProductTasks productTasks, IShoppingCartTasks shoppingCartTasks, IVoucherTasks voucherTasks)
        {
            this.productTasks = productTasks;
            this.shoppingCartTasks = shoppingCartTasks;
            this.voucherTasks = voucherTasks;
            Program.defaultConsole = (DefaultConsole) defaultConsole;
        }

        /// <summary>
        /// The application entry point.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            try
            {
                var program = ProgramBuilder.Build(args);

                var exitCode = program == null
                               ? ExitCode.InitializationFailure
                               : program.Run();

                Environment.Exit((int)exitCode);
            }
            catch (Exception e)
            {
                defaultConsole.WriteLine(e.ToString());
                Environment.Exit((int)ExitCode.UnexpectedException);
            }
        }

        private ExitCode Run()
        {
            defaultConsole.WriteLine(Messages.ProductsTitle);
            DisplayAllProducts();
            var shoppingCart = new ShoppingCart();
            while(true)
            {
                var userInput = Console.ReadLine();
                if (!Equals(userInput, CheckoutUserInput))
                {
                    shoppingCart = AddToShoppingCart(userInput);
                }
                else if(Equals(userInput, CheckoutUserInput))
                {
                    ProcessCheckout(shoppingCart);
                }
                else
                {
                    break;
                }
            }
            return ExitCode.Success;
        }

        /// <summary>
        /// Processes the checkout.
        /// </summary>
        private void ProcessCheckout(ShoppingCart shoppingCart)
        {
            while (true)
            {
                defaultConsole.WriteLine(Messages.EnterVoucherCode);
                var voucherCode = Console.ReadLine();
                var voucher = CheckIfExists(voucherCode);
                if(voucher != null)
                {
                    ApplyVoucherOnBasket(shoppingCart, voucher);
                }
                else
                {
                    defaultConsole.WriteLine(Messages.VoucherNotVallid);
                    break;
                }
            }    
        }

        /// <summary>
        /// Applies the voucher on basket.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        /// <param name="voucher">The voucher.</param>
        public void ApplyVoucherOnBasket(ShoppingCart shoppingCart, Voucher voucher)
        {
            shoppingCart.Voucher = voucher;
            defaultConsole.WriteLine(Messages.TotalCostAfterDiscount, shoppingCart.TotalCostAfterDiscount);
            defaultConsole.WriteLine(Messages.VoucherCodeStatusMessage, shoppingCart.Message);
        }

        /// <summary>
        /// Checks if exists.
        /// </summary>
        /// <param name="voucherCode">The voucher code.</param>
        /// <returns>True if the voucher exists</returns>
        public Voucher CheckIfExists(string voucherCode)
        {
            return voucherTasks.GetVoucherByCode(voucherCode);
        }

        /// <summary>
        /// Adds to shopping cart.
        /// </summary>
        /// <param name="userInput">The user input.</param>
        ////NOTE: TOO MANY CONDITIONS BUT THOUGHT TO VALIDATE SOME USER INPUTS.
        public ShoppingCart AddToShoppingCart(string userInput)
        {
            var shoppingCart = new ShoppingCart();

            if (!Validate(userInput)) return shoppingCart;

            var product = productTasks.GetProductById(Convert.ToInt32(userInput));

            if (product != null)
            {
                return ProcessShoppingCart(product, shoppingCart);
            }

            defaultConsole.WriteLine(Messages.ProductDoesnotExist);

            return shoppingCart;
        }

        private ShoppingCart ProcessShoppingCart(GenericProduct product, ShoppingCart shoppingCart)
        {
            defaultConsole.WriteLine(Messages.EnterQuantity);
            while (true)
            {
                var quantityInput = Console.ReadLine();
                if (Validate(quantityInput))
                {
                    var shoppingCartItem = MapUserInputToDomain(product, quantityInput);
                    shoppingCart = this.shoppingCartTasks.AddToShoppingCart(shoppingCartItem);
                    DisplayCartInformation(shoppingCart);
                    break;
                }
            }
            return shoppingCart;
        }

        /// <summary>
        /// Displays the cart information.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart.</param>
        private void DisplayCartInformation(ShoppingCart shoppingCart)
        {
            defaultConsole.WriteLine(Messages.YourBasketContains);
            foreach (var item in shoppingCart.Items)
            {
                defaultConsole.WriteLine(Messages.ShoppingCartItems, item.Id, item.Product.Name, item.Quantity, item.Product.Cost, item.TotalCost);
            }

            defaultConsole.WriteLine(Messages.YourTotalBasketCost,shoppingCart.TotalCost);
            defaultConsole.WriteLine(Messages.TotalBasketCostWithoutGiftVouchers, shoppingCart.TotalCostExcludingGiftVouchers);
            defaultConsole.WriteLine(Messages.SelectAnotherProduct);        
        }

        /// <summary>
        /// Maps the user input to domain.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <param name="quantityInput">The quantity input.</param>
        /// <returns>Shopping cart item.</returns>
        ////NOTE: THIS IS THE FUNCTIONALITY OF AUTOMAPPER TO MAP TO THE VIEWMODEL.
        public Item MapUserInputToDomain(GenericProduct product, string quantityInput)
        {
            var shoppingCartItem = new Item {Product = product, Quantity = Convert.ToInt32(quantityInput)};
            return shoppingCartItem;
        }

        /// <summary>
        /// Validates the specified user input.
        /// </summary>
        /// <param name="userInput">The user input.</param>
        /// <returns></returns>
        private static bool Validate(string userInput)
        {
            try
            {
                Convert.ToInt32(userInput);
                return true;
            }
            catch (Exception)
            {
                defaultConsole.WriteLine(ExitCode.InputFormatException + Messages.InvalidFormatException);
            }
            return false;
        }

        /// <summary>
        /// Displays all products.
        /// </summary>
        public void DisplayAllProducts()
        {
            var products = GetAllProducts();
            foreach (var genericProduct in products)
            {
                defaultConsole.WriteLine(genericProduct.Id + Messages.ProductIdAndTitleSeparator + genericProduct.Name + Messages.ProductDescription + genericProduct.Cost);
            }
            GetListOfVouchers();
            defaultConsole.WriteLine(Messages.AddProductToShoppingCart);
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GenericProduct> GetAllProducts()
        {
            return productTasks.GetAllProducts();
        }

        /// <summary>
        /// Gets the list of vouchers.
        /// </summary>
        public void GetListOfVouchers()
        {
            var vouchers = this.voucherTasks.GetAllVouchers();
            defaultConsole.WriteLine(Messages.ApplyBelowVoucherCodesAtTheTimeOfCheckout);
            foreach(var voucher in vouchers)
            {
                defaultConsole.WriteLine(Messages.VoucherCodeAndVoucherReason, voucher.Code, voucher.Reason);
            }
        }
    }
}
