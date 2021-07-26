using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository.Context.Base
{
    public interface IModelBuilderConfiguration
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
