using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListModelByDynamic;

public class GetListModelByDynamicQuery : IRequest<ModelListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListModelByDynamicQueryHandler : IRequestHandler<GetListModelByDynamicQuery, ModelListModel>
    {
        private readonly IMapper mapper;
        private readonly IModelRepository modelRepository;

        public GetListModelByDynamicQueryHandler(IMapper mapper, IModelRepository modelRepository)
        {
            this.mapper = mapper;
            this.modelRepository = modelRepository;
        }

        public async Task<ModelListModel> Handle(GetListModelByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Model> models = await modelRepository.GetListByDynamicAsync(
                                                            dynamic: request.Dynamic,
                                                            include:
                                                            m => m.Include(c => c.Brand),
                                                            index: request.PageRequest.Page,
                                                            size: request.PageRequest.PageSize
                                                            );

            ModelListModel mappedModels = mapper.Map<ModelListModel>(models);
            return mappedModels;
        }
    }
}
