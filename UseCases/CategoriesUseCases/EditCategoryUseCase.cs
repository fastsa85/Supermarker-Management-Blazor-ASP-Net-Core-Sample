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
    public class EditCategoryUseCase : IEditCategoryUseCase
    {
        private readonly ICategoriesRepository _categoryRepository;
        public EditCategoryUseCase(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Execute(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }
    }
}
