using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MaratonaXamarin
{
    public class Repository
    {
        public async Task<List<Cat>> GetCats()
        {
            AzureService<Cat> service = new AzureService<Cat>();
            IEnumerable<Cat> items = await service.GetTable();
            return items.ToList();
        }
    }
}
