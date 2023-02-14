using Bakerbots.Configuration;
using Bakerbots.DTOs;
using Bakerbots.Models;
//using Microsoft.Extensions.Internal;

namespace Bakerbots.CommandHandler
{
    public class AddProductCommandHandler : ICommandHandler<ProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CommandResult Execute(ProductDTO product)
        {
            var newProduct = new Product()
            {
                Id = product.Id,
                Category_ID = product.Category_ID,
                Product_Name = product.Product_Name,
                Product_Description = product.Product_Description,
                Product_Price = product.Product_Price,
                Product_Image = product.Product_Image,
            };
            _unitOfWork.ProductRepository.Add(newProduct);
            _unitOfWork.Commit();
            return new CommandResult { Order_Status = true, Message = "Product added" };
        }
    }
}
