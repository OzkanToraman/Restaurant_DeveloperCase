using Restaurant_DeveloperCase.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Mapping
{
    public class TableMapping : _BaseMapping<Table>
    {
        public TableMapping()
        {
            Property(x => x.TableName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();
            Property(x => x.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsUnicode()
                .IsOptional();
        }
    }
}
