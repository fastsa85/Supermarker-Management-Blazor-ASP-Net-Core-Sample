using CoreBusiness.Models;

namespace UseCases.ProductsUseCases.UseCaseInterfaces
{
    public interface IEditProductUseCase
    {
        void Execute(Product product);
    }
}