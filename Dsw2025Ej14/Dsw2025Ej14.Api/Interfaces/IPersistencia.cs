using Dsw2025Ej14.Api.Domain;

namespace Dsw2025Ej14.Api.Interfaces
{
    public interface IPersistencia
    {
        Product GetProduct(string sku);
        IEnumerable<Product> GetProducts();
    }
}