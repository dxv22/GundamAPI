using GundamAPI.Interfaces;
using GundamAPI.Models;
using MediatR;

namespace GundamAPI.Commands.UpdateGundamCommand
{
    public class UpdateGundamCommandHandler(IGundamRepository repository) : IRequestHandler<UpdateGundamCommand, Gundam>
    {
        private readonly IGundamRepository _repository = repository;

        public async Task<Gundam> Handle(UpdateGundamCommand request, CancellationToken cancellationToken)
        {
            var existingGundam = await _repository.GetGundamByIdAsync(request.Id);
            
            if (existingGundam == null)
            {
                throw new KeyNotFoundException($"Id{request.Id} not found");
            } else
            {
                // Update existing properties
                existingGundam.Title = request.GundamDto.Title;
                existingGundam.Pilot = request.GundamDto.Pilot;
                existingGundam.ReleaseDate = request.GundamDto.ReleaseDate;

                await _repository.UpdateGundamAsync(existingGundam);

                return existingGundam;

            }
        }
    }
}
