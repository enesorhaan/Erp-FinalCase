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
            VALUES ('info@orhan.com' ,'vakifbank' ,'Orhan Teknolojileri San. ve Tic. A.S.' ,0 ,'2023-10-30' ,0 ,'2023-10-30' ,'2023-10-30' ,1)
            
            INSERT INTO [dbo].[Dealer] ([CompanyId] ,[CurrentAccountId] ,[Email] ,[Password] ,[DealerName] ,[Address] ,[BillingAddress] ,[TaxOffice] ,[TaxNumber] ,[MarginPercentage] ,[Role] ,[LastActivityDate] ,[PasswordRetryCount] ,[InsertDate] ,[UpdateDate] ,[IsActive])
            VALUES (1 ,null ,'info@abc.com' ,'patika' ,'ABC A.S.' ,'Istanbul/Turkey' ,'Istanbul/Turkey' ,'Istanbul' ,111111 ,10 ,1 ,'2023-10-30' ,0 ,'2023-10-30' ,'2023-10-30' ,1)

            INSERT INTO [dbo].[Dealer] ([CompanyId] ,[CurrentAccountId] ,[Email] ,[Password] ,[DealerName] ,[Address] ,[BillingAddress] ,[TaxOffice] ,[TaxNumber] ,[MarginPercentage] ,[Role] ,[LastActivityDate] ,[PasswordRetryCount] ,[InsertDate] ,[UpdateDate] ,[IsActive])
            VALUES (1 ,null ,'info@def.com' ,'patika' ,'DEF A.S.' ,'Istanbul/Turkey' ,'Istanbul/Turkey' ,'Istanbul' ,111112 ,15 ,1 ,'2023-10-30' ,0 ,'2023-10-30' ,'2023-10-30' ,1)

            INSERT INTO [dbo].[CurrentAccount] ([DealerId] ,[CompanyId] ,[CreditLimit] ,[InsertDate] ,[UpdateDate] ,[IsActive]) 
            VALUES (1 ,1 ,NULL ,'2023-10-30' ,NULL ,1)

            INSERT INTO [dbo].[CurrentAccount] ([DealerId] ,[CompanyId] ,[CreditLimit] ,[InsertDate] ,[UpdateDate] ,[IsActive]) 
            VALUES (2 ,1 ,NULL ,'2023-10-30' ,NULL ,1)

            INSERT INTO [dbo].[Product] ([CompanyId] ,[ProductName] ,[ProductPrice] ,[ProductStock] ,[InsertDate] ,[UpdateDate] ,[IsActive]) 
            VALUES (1 ,'Step Motor' ,500 ,100 ,'2023-10-30' ,NULL ,1)

            INSERT INTO [dbo].[Product] ([CompanyId] ,[ProductName] ,[ProductPrice] ,[ProductStock] ,[InsertDate] ,[UpdateDate] ,[IsActive]) 
            VALUES (1 ,'Motor Driver' ,750 ,20 ,'2023-10-30' ,NULL ,1)

            INSERT INTO [dbo].[Product] ([CompanyId] ,[ProductName] ,[ProductPrice] ,[ProductStock] ,[InsertDate] ,[UpdateDate] ,[IsActive]) 
            VALUES (1 ,'Controller' ,1050 ,5 ,'2023-10-30' ,NULL ,1)
            
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
