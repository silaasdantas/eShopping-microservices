﻿using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

internal class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IList<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var productList = await _productRepository.GetProducts();
        var productsResponseList = ProductMapper.Mapper.Map<IList<ProductResponse>>(productList.ToList());
        return productsResponseList;
    }
}
