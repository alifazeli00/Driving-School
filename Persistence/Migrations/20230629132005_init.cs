﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coachs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coachs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatesTeory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatesTeory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatesDrivigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoachsId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatesDrivigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatesDrivigs_Coachs_CoachsId",
                        column: x => x.CoachsId,
                        principalTable: "Coachs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoachsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Coachs_CoachsId",
                        column: x => x.CoachsId,
                        principalTable: "Coachs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListDatesTeory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameTeacher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<int>(type: "int", nullable: false),
                    DatesTeoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListDatesTeory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListDatesTeory_DatesTeory_DatesTeoryId",
                        column: x => x.DatesTeoryId,
                        principalTable: "DatesTeory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeMeli = table.Column<int>(type: "int", nullable: false),
                    StatosCoachs = table.Column<bool>(type: "bit", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    DatesTeoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_DatesTeory_DatesTeoryId",
                        column: x => x.DatesTeoryId,
                        principalTable: "DatesTeory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BisnesCoachs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BisnesCoachs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BisnesCoachs_Coachs_CoachsId",
                        column: x => x.CoachsId,
                        principalTable: "Coachs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BisnesCoachs_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BisnesUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    DatesDrivigsId = table.Column<int>(type: "int", nullable: true),
                    StatusAiname = table.Column<bool>(type: "bit", nullable: false),
                    StatusAmali = table.Column<bool>(type: "bit", nullable: false),
                    StatusLerningAmali = table.Column<bool>(type: "bit", nullable: false),
                    StatusLerningAiname = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BisnesUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BisnesUsers_DatesDrivigs_DatesDrivigsId",
                        column: x => x.DatesDrivigsId,
                        principalTable: "DatesDrivigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BisnesUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BisnesCoachs_CoachsId",
                table: "BisnesCoachs",
                column: "CoachsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BisnesCoachs_UsersId",
                table: "BisnesCoachs",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_BisnesUsers_DatesDrivigsId",
                table: "BisnesUsers",
                column: "DatesDrivigsId",
                unique: true,
                filter: "[DatesDrivigsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BisnesUsers_UsersId",
                table: "BisnesUsers",
                column: "UsersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatesDrivigs_CoachsId",
                table: "DatesDrivigs",
                column: "CoachsId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CoachsId",
                table: "Image",
                column: "CoachsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListDatesTeory_DatesTeoryId",
                table: "ListDatesTeory",
                column: "DatesTeoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DatesTeoryId",
                table: "Users",
                column: "DatesTeoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BisnesCoachs");

            migrationBuilder.DropTable(
                name: "BisnesUsers");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "ListDatesTeory");

            migrationBuilder.DropTable(
                name: "DatesDrivigs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Coachs");

            migrationBuilder.DropTable(
                name: "DatesTeory");
        }
    }
}
