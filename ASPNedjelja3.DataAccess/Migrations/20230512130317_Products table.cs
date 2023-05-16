﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNedjelja3Vjezbe.DataAccess.Migrations
{
    public partial class Productstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_specificationValues_Specifications_SpecificationId",
                table: "specificationValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_specificationValues",
                table: "specificationValues");

            migrationBuilder.RenameTable(
                name: "specificationValues",
                newName: "SpecificationValues");

            migrationBuilder.RenameIndex(
                name: "IX_specificationValues_SpecificationId",
                table: "SpecificationValues",
                newName: "IX_SpecificationValues_SpecificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecificationValues",
                table: "SpecificationValues",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageProduct",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageProduct", x => new { x.ImagesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ImageProduct_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageProduct_ProductsId",
                table: "ImageProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationValues_Specifications_SpecificationId",
                table: "SpecificationValues",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationValues_Specifications_SpecificationId",
                table: "SpecificationValues");

            migrationBuilder.DropTable(
                name: "ImageProduct");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecificationValues",
                table: "SpecificationValues");

            migrationBuilder.RenameTable(
                name: "SpecificationValues",
                newName: "specificationValues");

            migrationBuilder.RenameIndex(
                name: "IX_SpecificationValues_SpecificationId",
                table: "specificationValues",
                newName: "IX_specificationValues_SpecificationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_specificationValues",
                table: "specificationValues",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_specificationValues_Specifications_SpecificationId",
                table: "specificationValues",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
