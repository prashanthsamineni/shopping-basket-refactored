using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using ShoppingBasket.Client.Contracts;
using ShoppingBasket.Domain;

namespace ShoppingBasket.ConsoleApplication.ProgramSpecs
{
    public class when_the_voucher_tasks_is_asked_to_verify_if_it_exists : Specification<Program>
    {
        private const string the_voucher_code = "XXX-XXXX";

        private static IVoucherTasks the_voucher_tasks;
        private static Voucher the_voucher;

        private Establish context = () =>
        {
            the_voucher = new Voucher();
            the_voucher_tasks = DependencyOf<IVoucherTasks>();
            the_voucher_tasks.Stub(x => x.GetVoucherByCode(the_voucher_code)).Return(the_voucher);
        };

        private Because of = () => subject.CheckIfExists(the_voucher_code);
        private It should_ask_voucher_tasks_to_Return_a_specific_voucher = () => { };
    }
}