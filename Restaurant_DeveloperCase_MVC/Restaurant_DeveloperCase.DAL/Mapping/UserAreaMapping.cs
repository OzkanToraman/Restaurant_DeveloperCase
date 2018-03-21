using Restaurant_DeveloperCase.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Mapping
{
    public class UserAreaMapping : _BaseMapping<UserArea>
    {
        public UserAreaMapping()
        {
            Property(x => x.UserName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();
            Property(x => x.Email)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Password)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();
            Property(x => x.PasswordConfirm)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();
            Property(x => x.IsDeleted)
                .HasColumnType("bit")
                .IsRequired();
            Property(x => x.RoleId)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
