using Entities;

namespace WebUI.ViewModels
{
    public class CartVM
    {
        public List<Product> CartItems { get; set; }

        public List<int> ProIds { get; set; }
    }
}
