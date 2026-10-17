namespace MvcMonolithicApp.ApplicationServices.Dtos.ProductDtos;

public class EditProductDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string DescriptionRecord { get; set; }
    public decimal UnitPrice { get; set; }
}