using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Models.Queries.GetListModel;

public class GetListModelQuery : IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
    {
        private readonly IMapper mapper;
        private readonly IModelRepository modelRepository;

        public GetListModelQueryHandler(IMapper mapper, IModelRepository modelRepository)
        {
            this.mapper = mapper;
            this.modelRepository = modelRepository;
        }

        public Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
