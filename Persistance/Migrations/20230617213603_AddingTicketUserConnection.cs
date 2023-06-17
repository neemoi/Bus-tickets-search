using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddingTicketUserConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Shedules_FkSheduleNavigationSheduleId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Transports_FkTransportNavigationTransportId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_driver_FkDriverNavigationDriverId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Routes_FkRouteTNavigationRouteId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_user_FkUserNavigationId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transports",
                table: "Transports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FkRouteTNavigationRouteId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FkUserNavigationId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shedules",
                table: "Shedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routes",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_FkDriverNavigationDriverId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_FkSheduleNavigationSheduleId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_FkTransportNavigationTransportId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "FkRouteTNavigationRouteId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FkUser",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FkUserNavigationId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "FkDriverNavigationDriverId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "FkSheduleNavigationSheduleId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "FkTransportNavigationTransportId",
                table: "Routes");

            migrationBuilder.RenameTable(
                name: "Transports",
                newName: "transport");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "ticket");

            migrationBuilder.RenameTable(
                name: "Shedules",
                newName: "shedule");

            migrationBuilder.RenameTable(
                name: "Routes",
                newName: "route");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "transport",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "transport",
                newName: "model");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "transport",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "TransportId",
                table: "transport",
                newName: "transport_id");

            migrationBuilder.RenameColumn(
                name: "Seat",
                table: "ticket",
                newName: "seat");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ticket",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "FkRouteT",
                table: "ticket",
                newName: "fk_route_t");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "ticket",
                newName: "ticket_id");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "shedule",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "shedule",
                newName: "departure_time");

            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "shedule",
                newName: "arrival_time");

            migrationBuilder.RenameColumn(
                name: "SheduleId",
                table: "shedule",
                newName: "shedule_id");

            migrationBuilder.RenameColumn(
                name: "Distance",
                table: "route",
                newName: "distance");

            migrationBuilder.RenameColumn(
                name: "StartLocation",
                table: "route",
                newName: "start_location");

            migrationBuilder.RenameColumn(
                name: "FkTransport",
                table: "route",
                newName: "fk_transport");

            migrationBuilder.RenameColumn(
                name: "FkShedule",
                table: "route",
                newName: "fk_shedule");

            migrationBuilder.RenameColumn(
                name: "FkDriver",
                table: "route",
                newName: "fk_driver");

            migrationBuilder.RenameColumn(
                name: "EndLocation",
                table: "route",
                newName: "end_location");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "route",
                newName: "route_id");

            migrationBuilder.AlterColumn<string>(
                name: "number",
                table: "transport",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "model",
                table: "transport",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "color",
                table: "transport",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "ticket",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "departure_time",
                table: "shedule",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(6)");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "arrival_time",
                table: "shedule",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(6)");

            migrationBuilder.AlterColumn<string>(
                name: "start_location",
                table: "route",
                type: "varchar(45)",
                maxLength: 45,
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "end_location",
                table: "route",
                type: "varchar(45)",
                maxLength: 45,
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "transport",
                column: "transport_id");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "ticket",
                column: "ticket_id");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "shedule",
                column: "shedule_id");

            migrationBuilder.AddPrimaryKey(
                name: "PRIMARY",
                table: "route",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "number_UNIQUE",
                table: "transport",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "transport_id_UNIQUE",
                table: "transport",
                column: "transport_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_route_idx",
                table: "ticket",
                column: "fk_route_t");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_user_id",
                table: "ticket",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ticket_id_UNIQUE",
                table: "ticket",
                column: "ticket_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "shedule_id_UNIQUE",
                table: "shedule",
                column: "shedule_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "driver_id_idx",
                table: "route",
                column: "fk_driver");

            migrationBuilder.CreateIndex(
                name: "fk_shedule_idx",
                table: "route",
                column: "fk_shedule");

            migrationBuilder.CreateIndex(
                name: "transport_id_idx",
                table: "route",
                column: "fk_transport");

            migrationBuilder.AddForeignKey(
                name: "fk_driver",
                table: "route",
                column: "fk_driver",
                principalTable: "driver",
                principalColumn: "driver_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_shedule",
                table: "route",
                column: "fk_shedule",
                principalTable: "shedule",
                principalColumn: "shedule_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_transport",
                table: "route",
                column: "fk_transport",
                principalTable: "transport",
                principalColumn: "transport_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_route_t",
                table: "ticket",
                column: "fk_route_t",
                principalTable: "route",
                principalColumn: "route_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_id",
                table: "ticket",
                column: "user_id",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_driver",
                table: "route");

            migrationBuilder.DropForeignKey(
                name: "fk_shedule",
                table: "route");

            migrationBuilder.DropForeignKey(
                name: "fk_transport",
                table: "route");

            migrationBuilder.DropForeignKey(
                name: "fk_route_t",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "fk_user_id",
                table: "ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "transport");

            migrationBuilder.DropIndex(
                name: "number_UNIQUE",
                table: "transport");

            migrationBuilder.DropIndex(
                name: "transport_id_UNIQUE",
                table: "transport");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "fk_route_idx",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_ticket_user_id",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "ticket_id_UNIQUE",
                table: "ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "shedule");

            migrationBuilder.DropIndex(
                name: "shedule_id_UNIQUE",
                table: "shedule");

            migrationBuilder.DropPrimaryKey(
                name: "PRIMARY",
                table: "route");

            migrationBuilder.DropIndex(
                name: "driver_id_idx",
                table: "route");

            migrationBuilder.DropIndex(
                name: "fk_shedule_idx",
                table: "route");

            migrationBuilder.DropIndex(
                name: "transport_id_idx",
                table: "route");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "ticket");

            migrationBuilder.RenameTable(
                name: "transport",
                newName: "Transports");

            migrationBuilder.RenameTable(
                name: "ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "shedule",
                newName: "Shedules");

            migrationBuilder.RenameTable(
                name: "route",
                newName: "Routes");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Transports",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "model",
                table: "Transports",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "color",
                table: "Transports",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "transport_id",
                table: "Transports",
                newName: "TransportId");

            migrationBuilder.RenameColumn(
                name: "seat",
                table: "Tickets",
                newName: "Seat");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Tickets",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "fk_route_t",
                table: "Tickets",
                newName: "FkRouteT");

            migrationBuilder.RenameColumn(
                name: "ticket_id",
                table: "Tickets",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Shedules",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "departure_time",
                table: "Shedules",
                newName: "DepartureTime");

            migrationBuilder.RenameColumn(
                name: "arrival_time",
                table: "Shedules",
                newName: "ArrivalTime");

            migrationBuilder.RenameColumn(
                name: "shedule_id",
                table: "Shedules",
                newName: "SheduleId");

            migrationBuilder.RenameColumn(
                name: "distance",
                table: "Routes",
                newName: "Distance");

            migrationBuilder.RenameColumn(
                name: "start_location",
                table: "Routes",
                newName: "StartLocation");

            migrationBuilder.RenameColumn(
                name: "fk_transport",
                table: "Routes",
                newName: "FkTransport");

            migrationBuilder.RenameColumn(
                name: "fk_shedule",
                table: "Routes",
                newName: "FkShedule");

            migrationBuilder.RenameColumn(
                name: "fk_driver",
                table: "Routes",
                newName: "FkDriver");

            migrationBuilder.RenameColumn(
                name: "end_location",
                table: "Routes",
                newName: "EndLocation");

            migrationBuilder.RenameColumn(
                name: "route_id",
                table: "Routes",
                newName: "RouteId");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Transports",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Transports",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Transports",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddColumn<int>(
                name: "FkRouteTNavigationRouteId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<uint>(
                name: "FkUser",
                table: "Tickets",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<string>(
                name: "FkUserNavigationId",
                table: "Tickets",
                type: "varchar(255)",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "DepartureTime",
                table: "Shedules",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "ArrivalTime",
                table: "Shedules",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "StartLocation",
                table: "Routes",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AlterColumn<string>(
                name: "EndLocation",
                table: "Routes",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldMaxLength: 45)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.AddColumn<uint>(
                name: "FkDriverNavigationDriverId",
                table: "Routes",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "FkSheduleNavigationSheduleId",
                table: "Routes",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "FkTransportNavigationTransportId",
                table: "Routes",
                type: "int unsigned",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transports",
                table: "Transports",
                column: "TransportId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "TicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shedules",
                table: "Shedules",
                column: "SheduleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routes",
                table: "Routes",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FkRouteTNavigationRouteId",
                table: "Tickets",
                column: "FkRouteTNavigationRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FkUserNavigationId",
                table: "Tickets",
                column: "FkUserNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_FkDriverNavigationDriverId",
                table: "Routes",
                column: "FkDriverNavigationDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_FkSheduleNavigationSheduleId",
                table: "Routes",
                column: "FkSheduleNavigationSheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_FkTransportNavigationTransportId",
                table: "Routes",
                column: "FkTransportNavigationTransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Shedules_FkSheduleNavigationSheduleId",
                table: "Routes",
                column: "FkSheduleNavigationSheduleId",
                principalTable: "Shedules",
                principalColumn: "SheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Transports_FkTransportNavigationTransportId",
                table: "Routes",
                column: "FkTransportNavigationTransportId",
                principalTable: "Transports",
                principalColumn: "TransportId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_driver_FkDriverNavigationDriverId",
                table: "Routes",
                column: "FkDriverNavigationDriverId",
                principalTable: "driver",
                principalColumn: "driver_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Routes_FkRouteTNavigationRouteId",
                table: "Tickets",
                column: "FkRouteTNavigationRouteId",
                principalTable: "Routes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_user_FkUserNavigationId",
                table: "Tickets",
                column: "FkUserNavigationId",
                principalTable: "user",
                principalColumn: "user_id");
        }
    }
}
