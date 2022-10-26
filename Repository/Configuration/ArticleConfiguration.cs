using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasData
            (
                new Article
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "A Weak Convergence Theorem for Common Fixed Points of Two Nonlinear Mappings in Hilbert Spaces",
                    Description = "In this paper, by using properties of attractive points, we study an iteration scheme combining simplified Baillon type and Mann type to find a common fixed point of commutative two nonlinear mappings in Hilbert spaces. Then, we apply the obtained results to prove a new weak convergence theorem.",
                    JournalId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                },

                new Article
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Name = "Stability Results for Enriched Contraction Mappings in Convex Metric Spaces",
                    Description = "In this paper, we obtain some stability results of fixed point sets for a sequence of enriched contraction mappings in the setting of convex metric spaces. In particular, two types of convergence of mappings, namely, -convergence and -convergence are considered. We also illustrate our results by an application to an initial value problem for an ordinary differential equation.",
                    JournalId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                },

                new Article
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    Name = "Investigation of Soil Physiochemical Properties Effects on Soil Compaction for a Long Year Tilled Farmland",
                    Description = "This article addressed the causes and effects of soil compaction, operating parameters, and soil physicochemical properties in the Bishoftu long year tilled farmland of Ethiopia.",
                    JournalId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                }
            );
    }
}