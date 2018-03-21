using Restaurant_DeveloperCase.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Mapping
{
    public class AllTableMapping:_BaseMapping<AllTable>
    {
        public AllTableMapping()
        {
            Property(x => x.ModId)
                .HasColumnType("int")
                .IsRequired();
            Property(x => x.TableId)
                .HasColumnType("int")
                .IsRequired();
            Property(x => x.IsFill)
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
