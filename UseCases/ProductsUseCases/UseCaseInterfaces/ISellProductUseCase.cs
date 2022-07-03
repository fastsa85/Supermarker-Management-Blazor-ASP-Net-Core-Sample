using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCases.UseCaseInterfaces
{
    public interface ISellProductUseCase
    {
        public void Execute(int productId, int quantityToSell, string cashierName);
    }
}
