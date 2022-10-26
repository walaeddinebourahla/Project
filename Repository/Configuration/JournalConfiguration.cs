using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class JournalConfiguration : IEntityTypeConfiguration<Journal>
{
    public void Configure(EntityTypeBuilder<Journal> builder)
    {
        builder.HasData
            (
                new Journal
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Abstract and Applied Analysis",
                    Description = "Abstract and Applied Analysis publishes research with an emphasis on important developments in classical analysis, linear and nonlinear functional analysis, ordinary and partial differential equations, optimisation theory, and control theory."
                },

                new Journal
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Applied and Environmental Soil Science",
                    Description = "Applied and Environmental Soil Science publishes research in the field of soil science. Its focus reflects the multidisciplinary nature of soil science, especially the dynamics and spatial heterogeneity of processes in soil."
                }
            );
    }
}
