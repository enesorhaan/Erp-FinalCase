using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            
            INSERT INTO [dbo].[Company] ([Email] ,[Password] ,[CompanyName] ,[Role] ,[LastActivityDate] ,[PasswordRetryCount] ,[InsertDate] ,[UpdateDate] ,[IsActive])
             VALUES ('info@orhan.com' ,'fd234f234234234' ,'Orhan Teknolojileri San. ve Tic. A.S.' ,0 ,'2023-07-07' ,0 ,'2023-07-07' ,'2023-07-07' ,1)
            
            INSERT INTO [dbo].[Dealer] ([CompanyId] ,[CurrentAccountId] ,[Email] ,[Password] ,[DealerName] ,[Address] ,[BillingAddress] ,[TaxOffice] ,[TaxNumber] ,[MarginPercentage] ,[Role] ,[LastActivityDate] ,[PasswordRetryCount] ,[InsertDate] ,[UpdateDate] ,[IsActive])
            VALUES (1 ,null ,'info@abc.com' ,'fd234f234234234' ,'ABC A.S.' ,'Istanbul/Turkey' ,'Istanbul/Turkey' ,'Istanbul' ,111111 ,null ,1 ,'2023-07-08' ,0 ,'2023-07-08' ,'2023-07-08' ,1)

            INSERT INTO [dbo].[Dealer] ([CompanyId] ,[CurrentAccountId] ,[Email] ,[Password] ,[DealerName] ,[Address] ,[BillingAddress] ,[TaxOffice] ,[TaxNumber] ,[MarginPercentage] ,[Role] ,[LastActivityDate] ,[PasswordRetryCount] ,[InsertDate] ,[UpdateDate] ,[IsActive])
            VALUES (1 ,null ,'info@def.com' ,'fd234f234234234' ,'DEF A.S.' ,'Istanbul/Turkey' ,'Istanbul/Turkey' ,'Istanbul' ,111112 ,null ,1 ,'2023-07-08' ,0 ,'2023-07-08' ,'2023-07-08' ,1)
            

            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
