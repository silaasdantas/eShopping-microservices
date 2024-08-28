using Discount.Application.Commands;
using Discount.Core.Repositories;
using MediatR;

namespace Discount.Application.Handlers;

public class DeleteDiscountHandler(IDiscountRepository discountRepository)
    : IRequestHandler<DeleteDiscountCommand, bool>
{
    public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
    {
        return await discountRepository.DeleteDiscount(request.ProductName);
    }
}
