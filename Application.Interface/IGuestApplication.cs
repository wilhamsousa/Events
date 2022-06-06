using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.InputModel;
using Domain.Model.ViewModel;

namespace Application.Interface
{
    public interface IGuestApplication
    {
        Domain.Model.ViewModel.Guest Create(Domain.Model.InputModel.Guest payload);
        Domain.Model.ViewModel.Guest Read(Guid id);
        void Update(Guid id, Domain.Model.InputModel.Guest payload);
        void Delete(Guid id);
        IEnumerable<Domain.Model.ViewModel.Guest> List();
    }
}
