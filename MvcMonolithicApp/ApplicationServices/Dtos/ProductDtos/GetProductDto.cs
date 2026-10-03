namespace MvcMonolithicApp.ApplicationServices.Dtos.ProductDtos;

public class GetProductDto
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal UnitPrice { get; set; }
}