using Domain.Model.InputModel;
using Domain.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Interface
{
    public interface IGuestService
    {
        Model.ViewModel.Guest Create(Model.InputModel.Guest payload);
        void Update(Guid id, Model.InputModel.Guest payload);
        Model.ViewModel.Guest Read(Guid id);
        void Delete(Guid id);
        IEnumerable<Model.ViewModel.Guest> List();
    }
}
