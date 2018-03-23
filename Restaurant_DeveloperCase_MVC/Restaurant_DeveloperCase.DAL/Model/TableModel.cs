using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Model
{
    public class TableModel
    {
        public DateTime Tarih { get; set; }
        public string TableName { get; set; }
        public string baslangicSaat { get; set; }
        public string bitisSaat { get; set; }
    }
}
