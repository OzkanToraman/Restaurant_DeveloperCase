using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Data
{
    public class Mod
    {
        public int Id { get; set; }
        public string ModName { get; set; }

        public virtual ICollection<AllTable> AllTables { get; set; }
    }
}
