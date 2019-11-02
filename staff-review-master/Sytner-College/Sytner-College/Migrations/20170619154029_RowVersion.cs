﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SytnerCollege.Migrations
{
    public partial class RowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Lecturer",
                maxLength: 254,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 254);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Department",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Department");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Lecturer",
                maxLength: 254,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 254,
                oldNullable: true);
        }
    }
}
