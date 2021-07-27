using Domain.Model.Entity;
using System;
using System.Collections.Generic;

namespace Infra.Repository.Context.Data
{
    public static class GuestData
    {
        public static IEnumerable<Guest> Itens { get; set; } = new List<Guest>()
        {
            new Guest()
                {
                    Id = Guid.Parse("7df2d51f-7f53-4f84-865a-bd27a3f9323d"),
                    EventId = Guid.Parse("41fc88fd-849e-49d1-bd39-e251d872cb90"),
                    Name = "Participante teste"
                }     

        };
    }
}
