namespace ReserveRoomMeetingWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblM_Ruangan
    {
        [Key]
        public int Ruangan_PK { get; set; }

        [StringLength(200)]
        public string NamaRuangan { get; set; }

        public int? Lantai { get; set; }

        public int? DayaTampung { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? Status_FK { get; set; }
    }
}
