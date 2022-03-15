using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorBoilerplate.Storage.Migrations.ApplicationDb
{
    public partial class EXERCISE_ID_DEFAULT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Exercises",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ddaf2c4c-5cc4-4b7f-852f-6e561ee8d620"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Exercises",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ddaf2c4c-5cc4-4b7f-852f-6e561ee8d620"));
        }
    }
}
