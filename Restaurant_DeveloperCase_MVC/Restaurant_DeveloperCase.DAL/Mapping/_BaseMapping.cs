using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Mapping
{
    public abstract class _BaseMapping<T> : EntityTypeConfiguration<T> 
        where T : class,new()
    {
    }
}
