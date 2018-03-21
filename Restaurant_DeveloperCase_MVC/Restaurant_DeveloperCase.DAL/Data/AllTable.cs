using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Data
{
    public class AllTable
    {
        public AllTable()
        {
            IsFill = false;
        }

        public int Id { get; set; }
        public int TableId { get; set; }
        public int ModId { get; set; }
        public bool IsFill { get; set; }

        public virtual Table Table { get; set; }
        public virtual Mod Mod{ get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }

}
