using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.InputModel;
using Domain.Model.ViewModel;

namespace Application.Interface
{
    public interface IEventApplication
    {
        Domain.Model.ViewModel.Event Create(Domain.Model.InputModel.Event payload);
        Domain.Model.ViewModel.Event Read(Guid id);
        void Update(Guid id, Domain.Model.InputModel.Event payload);
        void Delete(Guid id);
        IEnumerable<Domain.Model.ViewModel.Event> List();
        IEnumerable<Dashboard> Dashboard();
    }
}
