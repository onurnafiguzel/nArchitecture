using Application.Features.Models.Models;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Models.Queries.GetListModel;

public class GetListModelQuery : IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
    {
        public Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
