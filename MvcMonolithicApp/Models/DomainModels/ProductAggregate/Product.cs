namespace MvcMonolithicApp.Models.DomainModels.ProductAggregate;

public class Product
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string DescriptionRecord { get; set; }
    public decimal UnitPrice { get; set; }
}