using Microsoft.EntityFrameworkCore.Migrations;

namespace DbCard.Context.Migrations
{
    public partial class AddPartnerStatisticView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE VIEW PartnerStatisticView as 
            SELECT DATEPART(WEEKDAY, TH.DateTime) as [DayOfWeek],
            TH.DateTime,
            TH.FilialId,
            F.PartnerId,
            TH.PartnerName,
            TH.Address,
            TH.CustomerId
            from TransactionHistory TH
            INNER JOIN Filials F on F.Id = TH.FilialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
