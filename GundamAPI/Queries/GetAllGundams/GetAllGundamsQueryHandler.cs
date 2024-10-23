using GundamAPI.Interfaces;
using GundamAPI.Mapper;
using GundamAPI.Models;
using MediatR;

namespace GundamAPI.Queries.GetAllGundams
{
    public class GetAllGundamsQueryHandler(IGundamRepository repository) : IRequestHandler<GetAllGundamsQuery, IEnumerable<Gundam>>
    {
        private readonly IGundamRepository _repository = repository;

        public async Task<IEnumerable<Gundam>> Handle(GetAllGundamsQuery request, CancellationToken cancellationToken)
        {
            var gundams = await _repository.GetAllGundamsAsync();
            return gundams;
        }
    }
}
