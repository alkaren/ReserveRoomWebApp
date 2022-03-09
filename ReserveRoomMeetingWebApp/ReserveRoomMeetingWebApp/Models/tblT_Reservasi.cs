namespace ReserveRoomMeetingWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblT_Reservasi
    {
        [Key]
        public int Reservasi_PK { get; set; }

        public int? Ruangan_FK { get; set; }

        public string SubjectReservasi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TanggalReservasi { get; set; }

        public TimeSpan? JamMulai { get; set; }

        public TimeSpan? JamSelesai { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
