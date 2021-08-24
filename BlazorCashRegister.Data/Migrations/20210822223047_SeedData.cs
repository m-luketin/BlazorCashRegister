using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorCashRegister.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"USE [CashRegister]
                GO
                SET IDENTITY_INSERT[dbo].[Articles] ON

                INSERT[dbo].[Articles]([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(3, N'Banana', N'fd27f38b-9ff8-41fb-bb21-35465f401a34', 50, 5, 1)
                INSERT[dbo].[Articles]([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(4, N'Apple', N'b387eea2-8291-4c4b-8940-d24f1a0e38bb', 27, 10, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(5, N'Hell', N'2c716221-e1d6-474e-91cf-7a225bd1c608', 4, 20, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(6, N'Bread', N'654347bd-c010-476d-9539-011f7d1aad8d', 108, 10, 1)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(8, N'Water', N'884bc448-4055-4adb-ad2f-321a824ab592', 5, 5, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(9, N'Coffee', N'7711d4f9-7304-484a-8452-2df3321bb74c', 5, 30, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(10, N'Chewing gum', N'db2b89b3-cff8-42ec-a051-5513b6082ab8', 200, 3, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(11, N'Ice cream', N'0124cb43-0d0f-4a01-8b22-58d4f6d22192', 20, 10, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(12, N'Apple juice', N'ca49050b-d2a0-4507-970a-dd320a3a4799', 2, 10, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(13, N'Banana juice', N'33c8bbc5-b25e-4ac0-829f-0b5eca620f74', 3, 10, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(14, N'Orange', N'6007af63-25e7-4388-928e-dd12c6dcb729', 50, 5, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(15, N'Orange juice', N'774c9aeb-03fb-4fdf-b95c-fea39827e53e', 24, 10, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(16, N'Grapes', N'55f2f9d4-93fa-4ff8-9c77-43809d958d33', 50, 2, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(17, N'Grape juice', N'5a4285f0-3b1d-481a-b8aa-9e164889a3fb', 14, 10, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(18, N'Milk', N'f00ebb85-2697-4769-9dfa-324b475b014d', 85, 5, 1)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(19, N'Toast', N'3bc0b78a-00a7-4089-9a17-db9b92e5e50f', 30, 10, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(20, N'Cereal', N'e0dab940-9266-4268-8fa1-aedb87762b37', 8, 50, 0)
                INSERT[dbo].[Articles]
                        ([ArticleId], [Name], [Barcode], [UnitsInStock], [Price], [IsTaxRateReduced]) VALUES(21, N'Cigarettes', N'676bd88a-1a6b-4976-b4b9-64af98219e3c', 3, 50, 0)
                SET IDENTITY_INSERT[dbo].[Articles]
                        OFF
                SET IDENTITY_INSERT[dbo].[CashRegisters]
                        ON

                INSERT[dbo].[CashRegisters]
                        ([CashRegisterId]) VALUES(1)
                INSERT[dbo].[CashRegisters]
                        ([CashRegisterId]) VALUES(2)
                INSERT[dbo].[CashRegisters]
                        ([CashRegisterId]) VALUES(3)
                INSERT[dbo].[CashRegisters]
                        ([CashRegisterId]) VALUES(4)
                INSERT[dbo].[CashRegisters]
                        ([CashRegisterId]) VALUES(5)
                SET IDENTITY_INSERT[dbo].[CashRegisters]
                        OFF
                SET IDENTITY_INSERT[dbo].[Employees]
                        ON

                INSERT[dbo].[Employees]
                        ([EmployeeId], [Name], [Password], [Token]) VALUES(1, N'123123', N'123123', NULL)
                INSERT[dbo].[Employees]
                        ([EmployeeId], [Name], [Password], [Token]) VALUES(2, N'Matija', N'boyo', NULL)
                INSERT[dbo].[Employees]
                        ([EmployeeId], [Name], [Password], [Token]) VALUES(3, N'1', N'1', NULL)
                INSERT[dbo].[Employees]
                        ([EmployeeId], [Name], [Password], [Token]) VALUES(4, NULL, NULL, NULL)
                SET IDENTITY_INSERT[dbo].[Employees]
                        OFF
                SET IDENTITY_INSERT[dbo].[Receipts]
                        ON

                INSERT[dbo].[Receipts] ([ReceiptId], [SerialNumber], [EmployeeId], [RegisterCashRegisterId], [TimeStamp]) VALUES(25, N'ef0c7c60-10d2-4537-b668-3ca3a3bd5b16', 3, 3, CAST(N'2019-07-13T22:27:30.3405968' AS DateTime2))
                INSERT[dbo].[Receipts] ([ReceiptId], [SerialNumber], [EmployeeId], [RegisterCashRegisterId], [TimeStamp]) VALUES(26, N'e3cab0d4-040b-40c5-85db-e7735bb0e5c2', 3, 3, CAST(N'2019-07-13T22:37:26.3614421' AS DateTime2))
                INSERT[dbo].[Receipts] ([ReceiptId], [SerialNumber], [EmployeeId], [RegisterCashRegisterId], [TimeStamp]) VALUES(27, N'07a40bf9-a3cb-47c8-b086-579aa2c18bbd', 3, 3, CAST(N'2019-07-13T22:37:45.4628033' AS DateTime2))
                INSERT[dbo].[Receipts] ([ReceiptId], [SerialNumber], [EmployeeId], [RegisterCashRegisterId], [TimeStamp]) VALUES(28, N'424c1cbf-7d8e-4a9a-89ed-2981b51d55a7', 3, 3, CAST(N'2019-07-13T22:38:06.5255398' AS DateTime2))
                SET IDENTITY_INSERT[dbo].[Receipts]
                        OFF
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(5, 28, 3)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(6, 25, 4)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(8, 25, 4)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(8, 27, 4)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(8, 28, 4)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(13, 25, 4)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(15, 27, 3)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(15, 28, 3)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(18, 27, 5)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(18, 28, 5)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(20, 26, 3)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(20, 27, 3)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(20, 28, 3)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(21, 25, 5)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(21, 26, 2)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(21, 27, 2)
                INSERT[dbo].[ArticleReceipts]
                        ([ArticleId], [ReceiptId], [Quantity]) VALUES(21, 28, 2)
                INSERT[dbo].[__EFMigrationsHistory]
                        ([MigrationId], [ProductVersion]) VALUES(N'20190622100142_InitialMigration', N'2.2.4-servicing-10062')
                INSERT[dbo].[__EFMigrationsHistory]
                        ([MigrationId], [ProductVersion]) VALUES(N'20190627184011_TaxAndEmployeeNameChanged', N'2.2.4-servicing-10062')
                INSERT[dbo].[__EFMigrationsHistory]
                        ([MigrationId], [ProductVersion]) VALUES(N'20190627200751_AddedEmployeePassword', N'2.2.4-servicing-10062')
                INSERT[dbo].[__EFMigrationsHistory]
                        ([MigrationId], [ProductVersion]) VALUES(N'20190629152307_AddedEmployees', N'2.2.4-servicing-10062')
                INSERT[dbo].[__EFMigrationsHistory]
                        ([MigrationId], [ProductVersion]) VALUES(N'20190702084718_EmployeeToken', N'2.2.4-servicing-10062')
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
