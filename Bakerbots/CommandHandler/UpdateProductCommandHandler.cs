using Bakerbots.Configuration;
using Bakerbots.Models;

namespace Bakerbots.CommandHandler
{
    public class UpdateProductCommandHandler : ICommandHandler<Product>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CommandResult Execute(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.Commit();
            return new CommandResult { Order_Status = true, Message = "Updated" };
        }
    }
}
