using AutoMapper;
using Discount.Application.Commands;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Handlers;

public class CreateDiscountHandler(IDiscountRepository discountRepository, IMapper mapper) 
    : IRequestHandler<CreateDiscountCommand, CouponModel>
{
    public async Task<CouponModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var coupon = mapper.Map<Coupon>(request);
        await discountRepository.CreateDiscount(coupon);
        return mapper.Map<CouponModel>(coupon);
    }
}
