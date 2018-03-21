using Restaurant_DeveloperCase.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Mapping
{
    public class RoleMapping:_BaseMapping<Role>
    {
        public RoleMapping()
        {
            Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();
        }
    }
}
