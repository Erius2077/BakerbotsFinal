using Bakerbots.Commands;
using Bakerbots.Configuration;

namespace Bakerbots.CommandHandler
{
    public class RemoveProductCommandHandler : ICommandHandler<RemoveByIdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CommandResult Execute(RemoveByIdCommand product)
        {
            _unitOfWork.ProductRepository.Delete(product.Id);
            _unitOfWork.Commit();
            return new CommandResult { Order_Status = true, Message = "Product added" };
        }
    }
}
