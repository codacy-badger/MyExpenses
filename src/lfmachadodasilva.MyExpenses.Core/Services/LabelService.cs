using AutoMapper;
using lfmachadodasilva.MyExpenses.Core.Models;
using lfmachadodasilva.MyExpenses.Core.Models.Dtos;
using lfmachadodasilva.MyExpenses.Core.Repositories;

namespace lfmachadodasilva.MyExpenses.Core.Services
{
    internal class LabelService : ServiceBase<LabelDto, LabelModel>, ILabelService
    {
        internal LabelService(ILabelRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
