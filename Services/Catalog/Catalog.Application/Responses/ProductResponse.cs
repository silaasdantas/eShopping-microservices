﻿
using Catalog.Core.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Catalog.Application.Responses;

public class ProductResponse
{
    public string Id { get; set; }
    [BsonElement("Name")]
    public string Name { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public ProductBrand Brands { get; set; }
    public ProductType Types { get; set; }
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
}
