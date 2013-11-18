using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using ShoppingBasket.Domain;
using ShoppingBasket.Tasks;
using ShoppingBasket.Tasks.Contracts;

namespace ShoppingBasket.Tests.Tasks
{
    public class When_vourcher_tasks_is_asked_to_get_the_list_of_vouchers : Specification<VoucherTasks>
    {
        private const int CountOfVouchers = 1;
        private static IVoucherRepository the_voucher_repository;

        private static List<Voucher> the_vouchers;

        private Establish context = () =>
                                        {
                                            the_voucher_repository = DependencyOf<IVoucherRepository>();
                                            the_vouchers = new List<Voucher> {new Voucher(){VoucherType = VoucherType.AppliedForBasketTotal}};
                                            the_voucher_repository.Stub(x => x.GetAll()).Return(the_vouchers);
                                        };

        private Because of = () => the_vouchers = subject.GetAllVouchers();
        private It should_ask_voucher_repository_to_get_list_of_vouchers = () => the_vouchers.ShouldNotBeEmpty();
        private It should_return_only_one_item = () => the_vouchers.Count.ShouldEqual(CountOfVouchers);
        private It should_return_voucher_of_type_AppliedForBasketTotal =
            () => the_vouchers[0].VoucherType.ShouldEqual(VoucherType.AppliedForBasketTotal);
    }

    public class when_voucher_tasks_is_asked_to_Return_voucher_by_code : Specification<VoucherTasks>
    {
        private const string the_voucher_code = "XXX-XXXX";

        private static IVoucherRepository the_voucher_repository;

        private static Voucher the_voucher;

        private Establish context = () =>
                                        {
                                            the_voucher_repository = DependencyOf<IVoucherRepository>();
                                            the_voucher = new Voucher(){Code = the_voucher_code};
                                            the_voucher_repository.Stub(x => x.GetVoucherByVoucherCode(the_voucher_code)).Return(the_voucher);
                                        };

        private Because of = () => subject.GetVoucherByCode(the_voucher_code);
        private It should_ask_repository_to_return_the_voucher = () => the_voucher.ShouldNotBeNull();
        private It should_have_the_same_voucher_Code = () => the_voucher.Code.Equals(the_voucher_code);
    }
}
