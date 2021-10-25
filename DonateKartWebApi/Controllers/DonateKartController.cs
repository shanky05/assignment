using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DonateKartWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DonateKartController : ControllerBase
    {
        private readonly ILogger<DonateKartController> _logger;

        public DonateKartController(ILogger<DonateKartController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<CampaignShortData>> GetCampaign()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://testapi.donatekart.com/api/campaign"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<List<CampaignShortData>>(apiResponse);
                    return res;
                }
            }
        }

        [HttpGet]
        [Route("active")]
        public async Task<List<Campaign>> GetActiveCampaignCreatedInLastOneMonth()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://testapi.donatekart.com/api/campaign"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<List<Campaign>>(apiResponse);
                    res = res.Where(i => i.EndDate > DateTime.Now && i.Created > DateTime.Today.AddDays(-30)).ToList();
                    return res;
                }
            }
        }

        [HttpGet]
        [Route("inactive")]
        public async Task<List<Campaign>> GetAllInactiveCampaign()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://testapi.donatekart.com/api/campaign"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<List<Campaign>>(apiResponse);
                    res = res.Where(i => i.EndDate < DateTime.Now || i.ProcuredAmount >= i.TotalAmount ).ToList();
                    return res;
                }
            }
        }
    }
}
