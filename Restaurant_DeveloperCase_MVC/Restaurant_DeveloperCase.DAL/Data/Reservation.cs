using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int AllTableId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime ReservationDate { get; set; }

        public virtual AllTable AllTable { get; set; }
    }
}
