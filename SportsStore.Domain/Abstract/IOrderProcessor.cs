using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessorOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
