using IMS.CoreBusiness;
using IMS.UseCases.PluginInterface;
using System.Security.Cryptography.X509Certificates;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;
        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory{InventoryId = 1, InventoryName = "Wood Pallet", Price = 6.98, Quantity = 10 },
                new Inventory{InventoryId = 2, InventoryName = "Wood Chair", Price = 12.48, Quantity = 10 },
                new Inventory{InventoryId = 3, InventoryName = "Wood Desk", Price = 66.88, Quantity = 10 },
                new Inventory{InventoryId = 4, InventoryName = "Wood Table", Price = 5.28, Quantity = 10 },
            };
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);
            return _inventories.Where(x => x.InventoryName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}