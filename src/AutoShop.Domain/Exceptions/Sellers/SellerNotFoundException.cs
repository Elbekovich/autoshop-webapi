namespace AutoShop.Domain.Exceptions.Sellers;

public class SellerNotFoundException : NotFoundException
{
    public SellerNotFoundException()
    {
        this.TitleMessage = "Seller not found ";
    }
}
