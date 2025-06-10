using System.Runtime.CompilerServices;
using System.Text.Json;
using Dsw2025Ej14.Api.Domain;
using Dsw2025Ej14.Api.Interfaces;

namespace Dsw2025Ej14.Api.Data
{
    public class PersistenciaEnMemoria : IPersistencia
    {
        private List<Product> _products = [];

        public PersistenciaEnMemoria()
        {
            LoadProducts();
        }

        public Product GetProduct(string sku)
        {
            return _products.FirstOrDefault(p => p.Sku == sku);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products.Where(p => p.IsActive);
        }

        private void LoadProducts()
        {
            var json = File.ReadAllText("../../products.json");
            _products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? [];

        }
    }
}
