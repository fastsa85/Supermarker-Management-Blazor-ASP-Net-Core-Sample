using CoreBusiness.Models;
using System.Collections.Generic;

namespace UseCases.CategoriesUseCases.UseCaseInterfaces
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}