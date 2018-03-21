using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Data
{
    public class Table
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AllTable> AllTables { get; set; }
    }
}
