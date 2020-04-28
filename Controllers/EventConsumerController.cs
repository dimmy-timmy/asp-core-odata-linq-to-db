using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.OData.Client;

namespace asp_core_odata_linq_to_db.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventConsumerController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Event>> Get()
        {
            var client = new ODataClient(new ODataClientSettings()
            {
                BaseUri = new Uri("https://localhost:5001/odata"),
                OnApplyClientHandler = (handler =>
                {
                    handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, errors) => true;
                })
            });
            var targetDate = DateTime.Now.AddDays(-2);
            var events = await client.For<Event>().Filter(e => e.Date >= targetDate)
                .Skip(2).Top(8).FindEntriesAsync();
            return events;
        }
    }
}