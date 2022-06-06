using Domain.Model.InputModel;
using Domain.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Interface
{
    public interface IEventService
    {
        Model.ViewModel.Event Create(Model.InputModel.Event payload);
        void Update(Guid id, Model.InputModel.Event payload);
        Model.ViewModel.Event Read(Guid id);
        void Delete(Guid id);
        IEnumerable<Model.ViewModel.Event> List();
        IEnumerable<Dashboard> Dashboard();
    }
}
