using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace asp_core_odata_linq_to_db.Controllers
{
    public class EventController : ControllerBase
    {
        private static DataConnection _connection;
        static EventController()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            DataConnection.AddConfiguration("default", "Data Source=:memory:", new LinqToDB.DataProvider.SQLite.SQLiteDataProvider());
            DataConnection.DefaultConfiguration = "default";
            _connection = new DataConnection();
            _connection.CreateTable<Event>();
            for (var i = 0; i < 10; i++)
            {
                _connection.Insert(new Event()
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now.AddDays(rnd.Next(-i, i)),
                    Name = $"Event {i}"
                });
            }
        }
        
        [EnableQuery()]
        public IQueryable<Event> Get()
        {
            return _connection.GetTable<Event>();
        }
    }
}
