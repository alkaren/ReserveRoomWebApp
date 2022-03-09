using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ReserveRoomMeetingWebApp.Models
{
    public partial class ReserveModel : DbContext
    {
        public ReserveModel()
            : base("name=ReserveModel")
        {
        }

        public virtual DbSet<tblM_Ruangan> tblM_Ruangan { get; set; }
        public virtual DbSet<tblM_Status> tblM_Status { get; set; }
        public virtual DbSet<tblT_Reservasi> tblT_Reservasi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
