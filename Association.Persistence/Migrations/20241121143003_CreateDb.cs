using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Association.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonationGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntentionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntentionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonationCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonationGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationCategories_DonationGroups_DonationGroupId",
                        column: x => x.DonationGroupId,
                        principalTable: "DonationGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonationForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonationCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationForms_DonationCategories_DonationCategoryId",
                        column: x => x.DonationCategoryId,
                        principalTable: "DonationCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonationForms_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonationOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonationCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationOptions_DonationCategories_DonationCategoryId",
                        column: x => x.DonationCategoryId,
                        principalTable: "DonationCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonationShares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonationFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonationOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntentionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShareAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationShares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonationShares_DonationForms_DonationFormId",
                        column: x => x.DonationFormId,
                        principalTable: "DonationForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonationShares_DonationOptions_DonationOptionId",
                        column: x => x.DonationOptionId,
                        principalTable: "DonationOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonationShares_IntentionTypes_IntentionTypeId",
                        column: x => x.IntentionTypeId,
                        principalTable: "IntentionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonationCategories_DonationGroupId",
                table: "DonationCategories",
                column: "DonationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationCategories_Name",
                table: "DonationCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonationForms_DonationCategoryId",
                table: "DonationForms",
                column: "DonationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationForms_DonorId",
                table: "DonationForms",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationGroups_Name",
                table: "DonationGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonationOptions_DonationCategoryId",
                table: "DonationOptions",
                column: "DonationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationOptions_Name",
                table: "DonationOptions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_DonationShares_DonationFormId",
                table: "DonationShares",
                column: "DonationFormId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationShares_DonationOptionId",
                table: "DonationShares",
                column: "DonationOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationShares_IntentionTypeId",
                table: "DonationShares",
                column: "IntentionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IntentionTypes_Name",
                table: "IntentionTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationShares");

            migrationBuilder.DropTable(
                name: "DonationForms");

            migrationBuilder.DropTable(
                name: "DonationOptions");

            migrationBuilder.DropTable(
                name: "IntentionTypes");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "DonationCategories");

            migrationBuilder.DropTable(
                name: "DonationGroups");
        }
    }
}
