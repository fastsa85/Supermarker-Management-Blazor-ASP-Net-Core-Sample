using CoreBusiness.Models;

namespace UseCases.CategoriesUseCases.UseCaseInterfaces
{
    public interface IAddCategoryUseCase
    {
        void Execute(Category category);
    }
}
