using System.Data.Entity.Migrations;
 
namespace TaxReturn.Repository.Migrations
{   
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTransactions",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Account = c.String(),
                        Description = c.String(),
                        CurrencyCode = c.String(),
                        Amount = c.String(),
                    })
                .PrimaryKey(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountTransactions");
        }
    }
}
