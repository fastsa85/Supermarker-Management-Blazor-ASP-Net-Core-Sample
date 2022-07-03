using UseCases.CategoriesUseCases.UseCaseInterfaces;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCases
{
    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
    {
        private readonly ICategoriesRepository _categoryRepository;

        public DeleteCategoryUseCase(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Execute(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }
    }
}
