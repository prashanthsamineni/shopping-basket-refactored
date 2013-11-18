using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.AutoMocking.Rhino;
using Rhino.Mocks;
using ShoppingBasket.Domain;
using ShoppingBasket.Domain.Shared;
using ShoppingBasket.Tasks;
using ShoppingBasket.Tasks.Contracts;

namespace ShoppingBasket.Tests.Tasks
{
    public class When_product_tasks_is_asked_to_get_all_products : Specification<ProductTasks>
    {
        private static IProductRepository productRepository;
        private static List<GenericProduct> products;
        Establish context = () =>
                                        {
                                            productRepository = DependencyOf<IProductRepository>();
                                            products = new List<GenericProduct> {new Product()};
                                            productRepository.Stub(pr => pr.GetAll()).Return(products);
                                        };
        Because of = () => subject.GetAllProducts();
        It should_get_all_products = () => products.Count.ShouldEqual(1);
    }

    public class When_product_tasks_is_asked_to_get_a_product_by_id : Specification<ProductTasks>
    {
        private static IProductRepository the_product_repository;
        private static GenericProduct the_product;

        private Establish context = () =>
                                        {
                                            the_product_repository = DependencyOf<IProductRepository>();
                                            the_product = new GenericProduct();
                                            the_product_repository.Stub(x => x.GetById(1)).Return(the_product);
                                        };

        private Because of = () => subject.GetProductById(1);
        private It should_get_the_product = () => the_product.ShouldNotBeNull();
    }
}
