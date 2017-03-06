using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MaratonaXamarin
{
    public class AzureService<T>
    {
        private const string APP_SERVICE_URL = "https://xamarinoberdan.azurewebsites.net";
        private readonly IMobileServiceClient client;
        private readonly IMobileServiceTable<T> table;

        public AzureService()
        {
            this.client = new MobileServiceClient(APP_SERVICE_URL);
            this.table = this.client.GetTable<T>();
        }

        public Task<IEnumerable<T>> GetTable()
        {
            return this.table.ToEnumerableAsync();
        }
    }
}
