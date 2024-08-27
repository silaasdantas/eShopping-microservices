using Discount.Application.Queries;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers;

public class GetDiscountHandler(IDiscountRepository discountRepository) : IRequestHandler<GetDiscountQuery, CouponModel>
{
    public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var coupon = await discountRepository.GetDiscount(request.ProductName) ?? throw new RpcException(new Status(StatusCode.NotFound, $"Discount for the Product Name = {request.ProductName} not found"));
        return new CouponModel
        {
            Id = coupon.Id,
            ProductName = coupon.ProductName,
            Amount = coupon.Amount,
            Description = coupon.Description
        };
    }
}
