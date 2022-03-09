USE [MDKAReservasi]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[InsertUpdateDeleteReserve]
		@Reservasi_PK = NULL,
		@Ruangan_FK = 4,
		@SubjectReservasi = N'2',
		@TanggalReservasi = '2022-03-09',
		@JamMulai = '14:00',
		@JamSelesai = '20:00',
		@CreatedBy = NULL,
		@CreatedDate = NULL,
		@UpdatedBy = NULL,
		@UpdatedDate = NULL,
		@StatementType = N'Insert'

SELECT	'Return Value' = @return_value
SELECT * FROM [tblT_Reservasi]

GO
