using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaratonaXamarin
{
    public class Repository
    {
        public async Task<List<Cat>> GetCats()
        {
            List<Cat> cats;
            var webApiUrl = "http://demos.ticapacitacion.com/cats";
            using (var client = new System.Net.Http.HttpClient())
            {
                var json = await client.GetStringAsync(webApiUrl);
                cats = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cat>>(json);
            }
            return cats;
        }
    }
}
