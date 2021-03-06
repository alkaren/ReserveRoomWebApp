USE [MDKAReservasi]
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateDeleteReserve]    Script Date: 3/9/2022 4:16:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[InsertUpdateDeleteReserve]
	@Reservasi_PK int,
	@Ruangan_FK int,
	@SubjectReservasi NVARCHAR(MAX),
	@TanggalReservasi date,
	@JamMulai time(7),
	@JamSelesai time(7),
	@CreatedBy NVARCHAR(50),
	@CreatedDate datetime,
	@UpdatedBy NVARCHAR(50),
	@UpdatedDate datetime,
	@StatementType NVARCHAR(20) = ''
AS
BEGIN
      IF @StatementType = 'Insert'
        BEGIN
            INSERT INTO tblT_Reservasi
                        (	Ruangan_FK,
							SubjectReservasi,
							TanggalReservasi,
							JamMulai,
							JamSelesai,
							CreatedBy,
							CreatedDate,
							UpdatedBy,
							UpdatedDate)
            VALUES     (	@Ruangan_FK,
							@SubjectReservasi,
							@TanggalReservasi,
							@JamMulai,
							@JamSelesai,
							@CreatedBy,
							@CreatedDate,
							@UpdatedBy,
							@UpdatedDate)
        END

      IF @StatementType = 'Select'
        BEGIN
            SELECT *
            FROM   tblT_Reservasi
        END

      IF @StatementType = 'Update'
        BEGIN
            UPDATE tblT_Reservasi
            SET		Ruangan_FK = @Ruangan_FK,
					SubjectReservasi = @SubjectReservasi,
					TanggalReservasi = @TanggalReservasi,
					JamMulai = @JamMulai,
					JamSelesai = @JamSelesai,
					CreatedBy = @CreatedBy,
					CreatedDate = @CreatedDate,
					UpdatedBy = @UpdatedBy,
					UpdatedDate = @UpdatedDate
            WHERE  Reservasi_PK = @Reservasi_PK
        END
      ELSE IF @StatementType = 'Delete'
        BEGIN
            DELETE FROM tblT_Reservasi
            WHERE  Reservasi_PK = @Reservasi_PK
        END
  END