using Restaurant_DeveloperCase.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_DeveloperCase.DAL.Mapping
{
    public class ReservationMapping : _BaseMapping<Reservation>
    {
        public ReservationMapping()
        {
            Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsUnicode()
                .IsOptional();

            Property(x => x.LastName)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsUnicode()
                .IsOptional();

            Property(x => x.ReservationDate)
                .HasColumnType("Datetime")
                .IsOptional();

            Property(x => x.StartTime)
                .HasColumnType("datetime")
                .IsOptional();

            Property(x => x.FinishTime)
                .HasColumnType("datetime")
                .IsOptional();
            Property(x => x.AllTableId)
                .HasColumnType("int")
                .IsRequired();
            Property(x => x.UserAreaId)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
