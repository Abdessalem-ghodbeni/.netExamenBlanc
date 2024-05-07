using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    public partial class ghodbeny : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banques",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banques", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "dABs",
                columns: table => new
                {
                    DABid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dABs", x => x.DABid);
                });

            migrationBuilder.CreateTable(
                name: "Comptes",
                columns: table => new
                {
                    NumeroCompte = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Proprietaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solde = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BanqueFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comptes", x => x.NumeroCompte);
                    table.ForeignKey(
                        name: "FK_Comptes_Banques_BanqueFk",
                        column: x => x.BanqueFk,
                        principalTable: "Banques",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DABFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroCompteFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Montant = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => new { x.DABFk, x.NumeroCompteFk, x.Date });
                    table.ForeignKey(
                        name: "FK_transactions_Comptes_NumeroCompteFk",
                        column: x => x.NumeroCompteFk,
                        principalTable: "Comptes",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_dABs_DABFk",
                        column: x => x.DABFk,
                        principalTable: "dABs",
                        principalColumn: "DABid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionRetrait",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DABFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroCompteFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AutreAgence = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRetrait", x => new { x.DABFk, x.NumeroCompteFk, x.Date });
                    table.ForeignKey(
                        name: "FK_TransactionRetrait_Comptes_NumeroCompteFk",
                        column: x => x.NumeroCompteFk,
                        principalTable: "Comptes",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionRetrait_dABs_DABFk",
                        column: x => x.DABFk,
                        principalTable: "dABs",
                        principalColumn: "DABid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionRetrait_transactions_DABFk_NumeroCompteFk_Date",
                        columns: x => new { x.DABFk, x.NumeroCompteFk, x.Date },
                        principalTable: "transactions",
                        principalColumns: new[] { "DABFk", "NumeroCompteFk", "Date" });
                });

            migrationBuilder.CreateTable(
                name: "TransactionTransfert",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DABFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroCompteFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroCompte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTransfert", x => new { x.DABFk, x.NumeroCompteFk, x.Date });
                    table.ForeignKey(
                        name: "FK_TransactionTransfert_Comptes_NumeroCompteFk",
                        column: x => x.NumeroCompteFk,
                        principalTable: "Comptes",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionTransfert_dABs_DABFk",
                        column: x => x.DABFk,
                        principalTable: "dABs",
                        principalColumn: "DABid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionTransfert_transactions_DABFk_NumeroCompteFk_Date",
                        columns: x => new { x.DABFk, x.NumeroCompteFk, x.Date },
                        principalTable: "transactions",
                        principalColumns: new[] { "DABFk", "NumeroCompteFk", "Date" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comptes_BanqueFk",
                table: "Comptes",
                column: "BanqueFk");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRetrait_NumeroCompteFk",
                table: "TransactionRetrait",
                column: "NumeroCompteFk");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_NumeroCompteFk",
                table: "transactions",
                column: "NumeroCompteFk");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTransfert_NumeroCompteFk",
                table: "TransactionTransfert",
                column: "NumeroCompteFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionRetrait");

            migrationBuilder.DropTable(
                name: "TransactionTransfert");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "Comptes");

            migrationBuilder.DropTable(
                name: "dABs");

            migrationBuilder.DropTable(
                name: "Banques");
        }
    }
}
