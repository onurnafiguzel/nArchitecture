using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetByIdBrand
{
    public class GetByIdBrandQuery : IRequest<BrandGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
        {
            private readonly IBrandRepository brandRepository;
            private readonly IMapper mapper;
            private readonly BrandBusinessRules brandBusinessRules;

            public GetByIdBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                this.brandRepository = brandRepository;
                this.mapper = mapper;
                this.brandBusinessRules = brandBusinessRules;
            }

            public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                Brand? brand = await brandRepository.GetAsync(b => b.Id == request.Id);
                brandBusinessRules.BrandShouldExistWhenRequested(brand);
                BrandGetByIdDto brandGetByIdDto = mapper.Map<BrandGetByIdDto>(brand);
                return brandGetByIdDto;
            }
        }
    }
}
