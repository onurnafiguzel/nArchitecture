using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Model> models = await modelRepository.GetListAsync(include:
                                                                          m => m.Include(c => c.Brand),
                                                                          index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize
                                                                          );

            ModelListModel mappedModels = mapper.Map<ModelListModel>(models);
            return mappedModels;
        }
    }
}
