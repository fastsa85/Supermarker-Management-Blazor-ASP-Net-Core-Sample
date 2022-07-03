using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.CategoriesUseCases.UseCaseInterfaces;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCases
{
    public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
    {
        private readonly ICategoriesRepository _categoryRepository;

        public GetCategoryByIdUseCase(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category Execute(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }
    }
}
