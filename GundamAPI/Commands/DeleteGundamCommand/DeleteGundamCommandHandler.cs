using GundamAPI.Interfaces;
using MediatR;

namespace GundamAPI.Commands.DeleteGundamCommand
{
    public class DeleteGundamCommandHandler(IGundamRepository repository) : IRequestHandler<DeleteGundamCommand, bool>
    {
        private readonly IGundamRepository _repository = repository;

        public async Task<bool> Handle(DeleteGundamCommand request, CancellationToken cancellationToken)
        {
            var gundam = await _repository.GetGundamByIdAsync(request.Id);

            if (gundam == null)
            {
                throw new KeyNotFoundException($"Id{request.Id} not found");
            } else
            {
                return await _repository.DeleteGundamAsync(gundam);
            }
        }
    }
}
