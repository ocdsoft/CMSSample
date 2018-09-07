using Benefits.Shared.Configuration;
using Benefits.Shared.Interfaces;
using Benefits.Shared.Models.Repository;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Benefits.Shared.Infrastructure
{
    public class DocLocRepository : IDocumentManagementRepository
    {
        private readonly ConnectionStrings _connections;

        public DocLocRepository(IOptions<ConnectionStrings> connections)
        {
            _connections = connections.Value;
        }

        public List<Publication> GetPublications(string publicationName)
        {
            var publications = new List<Publication>();

            using (var conn = new SqlConnection(_connections.DocumentManagement))
            {
                var sql = @"SELECT [ObjectID] as ID, [PublicationName] as Name, 
                    [PublishDate], [ArticleDescription] as Description FROM [vwPublications]
                    WHERE ([PublicationName] = @PublicationName) AND ([PublishDate] != '')
                    ORDER BY PublishDate DESC";

                var param = new { PublicationName = publicationName };
                //publications = conn.Query<Publication>(sql, param).AsList();
            }
            publications.AddRange(new List<Publication>
                                {
                                    new Publication
                                    {
                                        Name = "Nullam porttitor turpis at arcu",
                                        Description = @"Quisque sapien purus,
                                        commodo sed nunc elementum, aliquam ultrices lorem.In at aliquet enim.Aenean varius ac dolor quis egestas.Nunc interdum rutrum porta.Etiam commodo massa sed massa laoreet efficitur vitae blandit mauris.Vestibulum convallis pretium tellus in tempus.Nunc at quam sapien.",
                                         ID = "#",
                                         PublishDate = DateTime.Now
                                    },
                                    new Publication
                                    {
                                        Name = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet",
                                        Description = @"Suspendisse odio purus, blandit ut commodo a, semper nec nunc. Phasellus ipsum erat, vehicula eu euismod sit amet, pellentesque sit amet ipsum. Nullam eleifend sapien et egestas viverra. Integer sodales dictum dignissim. Phasellus enim augue, ornare nec mollis eu, iaculis non nulla. Integer imperdiet, sem sit amet dignissim fringilla, lorem justo laoreet est, quis suscipit odio lectus ac justo. Nulla fermentum aliquam lectus, vitae iaculis nulla hendrerit sed",
                                        ID = "#",
                                        PublishDate = DateTime.Now.AddMonths(-1)
                                    }
                                }
                            );
            return publications;
        }
    }
}