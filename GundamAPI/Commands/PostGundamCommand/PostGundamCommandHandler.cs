using GundamAPI.Interfaces;
using GundamAPI.Models;
using MediatR;

namespace GundamAPI.Commands.PostGundamCommand
{
    public class PostGundamCommandHandler(IGundamRepository repository) : IRequestHandler<PostGundamCommand, Gundam>
    {
        private readonly IGundamRepository _repository = repository;

        public async Task<Gundam> Handle(PostGundamCommand request, CancellationToken cancellationToken)
        {
            var gundam = new Gundam
            {
                Title = request.GundamDto.Title,
                Pilot = request.GundamDto.Pilot,
                ReleaseDate = request.GundamDto.ReleaseDate
            };

            await _repository.AddGundamAsync(gundam);

            return gundam;
        }
    }
}
