using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypesResponse>>
    {
        private readonly ITypesRepository _typesRepository;
        private readonly IMapper _mapper;

        public GetAllTypesHandler(ITypesRepository typesRepository,IMapper mapper)
        {
            _typesRepository = typesRepository;
            _mapper = mapper;
        }

        public async Task<IList<TypesResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typeList = await _typesRepository.GetAllTypes();
            var typesResponseList = _mapper.Map<IList<TypesResponse>>(typeList);
            return typesResponseList;
        }

    }
}
