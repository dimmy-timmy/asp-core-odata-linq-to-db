using System;
using LinqToDB.Mapping;

namespace asp_core_odata_linq_to_db
{
    [Table]
    public class Event
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        
        [LinqToDB.Mapping.Column]
        public DateTime Date { get; set; }

        [LinqToDB.Mapping.Column]
        public string Name { get; set; }
    }
}
