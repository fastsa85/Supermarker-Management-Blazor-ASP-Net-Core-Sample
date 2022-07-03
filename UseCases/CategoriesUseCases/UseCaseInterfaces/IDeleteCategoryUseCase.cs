using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.CategoriesUseCases.UseCaseInterfaces
{
    public interface IDeleteCategoryUseCase
    {
        void Execute(int categoryId);
    }
}
