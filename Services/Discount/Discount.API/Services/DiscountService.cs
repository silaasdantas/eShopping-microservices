using Discount.Application.Commands;
using Discount.Application.Queries;
using Discount.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.API.Services;

public class DiscountService(IMediator mediator)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var query = new GetDiscountQuery(request.ProductName);
        return await mediator.Send(query);
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var command = new CreateDiscountCommand
        {
            ProductName = request.Coupon.ProductName,
            Amount = request.Coupon.Amount,
            Description = request.Coupon.Description,
        };
        return await mediator.Send(command);
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var command = new UpdateDiscountCommand
        {
            Id = request.Coupon.Id,
            ProductName = request.Coupon.ProductName,
            Amount = request.Coupon.Amount,
            Description = request.Coupon.Description,
        };
        return await mediator.Send(command);
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var command = new DeleteDiscountCommand(request.ProductName);
        var deleted = await mediator.Send(command);
        var response = new DeleteDiscountResponse { Success = deleted };
        return response;
    }
}
