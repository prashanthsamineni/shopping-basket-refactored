using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using ShoppingBasket.Client.Contracts;
using ShoppingBasket.Domain;

namespace ShoppingBasket.ConsoleApplication.ProgramSpecs
{
    public class when_voucher_tasks_is_asked_to_display_the_list_of_vouchers : Specification<Program>
    {
        private static IVoucherTasks the_voucher_tasks;

        private static List<Voucher> the_vouchers;

        private Establish context = () =>
        {
            the_vouchers = new List<Voucher>(){new Voucher()};
            the_voucher_tasks = DependencyOf<IVoucherTasks>();
            the_voucher_tasks.Stub(x => x.GetAllVouchers()).Return(the_vouchers);
        };

        private Because of = () => subject.GetListOfVouchers();
        private It should_ask_voucher_tasks_to_return_the_list_of_vouchers = () => the_vouchers.ShouldNotBeEmpty();
    }
}