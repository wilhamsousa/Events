﻿using Domain.Model.Entity;
using System;
using System.Collections.Generic;

namespace Infra.Repository.Context.Data
{
    public static class EventData
    {
        public static IEnumerable<Event> Itens { get; set; } = new List<Event>()
        {
            new Event()
                {
                    Id = Guid.Parse("41fc88fd-849e-49d1-bd39-e251d872cb90"),
                    Description = "Churrasco de aniversariantes do mês",
                    PriceWithDrink = 100,
                    PriceWithoutDrink = 50
                }     

        };
    }
}
