using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Journals",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Applied and Environmental Soil Science publishes research in the field of soil science. Its focus reflects the multidisciplinary nature of soil science, especially the dynamics and spatial heterogeneity of processes in soil.", "Applied and Environmental Soil Science" });

            migrationBuilder.InsertData(
                table: "Journals",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Abstract and Applied Analysis publishes research with an emphasis on important developments in classical analysis, linear and nonlinear functional analysis, ordinary and partial differential equations, optimisation theory, and control theory.", "Abstract and Applied Analysis" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "JournalId", "Name" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "This article addressed the causes and effects of soil compaction, operating parameters, and soil physicochemical properties in the Bishoftu long year tilled farmland of Ethiopia.", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Investigation of Soil Physiochemical Properties Effects on Soil Compaction for a Long Year Tilled Farmland" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "JournalId", "Name" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "In this paper, by using properties of attractive points, we study an iteration scheme combining simplified Baillon type and Mann type to find a common fixed point of commutative two nonlinear mappings in Hilbert spaces. Then, we apply the obtained results to prove a new weak convergence theorem.", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "A Weak Convergence Theorem for Common Fixed Points of Two Nonlinear Mappings in Hilbert Spaces" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "JournalId", "Name" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "In this paper, we obtain some stability results of fixed point sets for a sequence of enriched contraction mappings in the setting of convex metric spaces. In particular, two types of convergence of mappings, namely, -convergence and -convergence are considered. We also illustrate our results by an application to an initial value problem for an ordinary differential equation.", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Stability Results for Enriched Contraction Mappings in Convex Metric Spaces" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Journals",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
