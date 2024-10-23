using GundamAPI.Interfaces;
using GundamAPI.Mapper;
using GundamAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GundamAPI.Queries.GetGundamById
{
    public class GetGundamByIdQueryHandler(IGundamRepository repository) : IRequestHandler<GetGundamByIdQuery, Gundam>
    {
        private readonly IGundamRepository _repository = repository;

        public async Task<Gundam> Handle(GetGundamByIdQuery request, CancellationToken cancellationToken)
        {
            var gundam = await _repository.GetGundamByIdAsync(request.Id);

            return gundam ?? throw new KeyNotFoundException($"Id {request.Id} not found");
        }
    }
}
