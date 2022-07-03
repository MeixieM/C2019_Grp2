namespace DentaPix_Clinic.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ListCart { get; set; }

        public OrderHeader OrderHeader { get; set; }

    }
}
