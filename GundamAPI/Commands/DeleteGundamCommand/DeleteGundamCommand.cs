using GundamAPI.Models;
using MediatR;

namespace GundamAPI.Commands.DeleteGundamCommand
{
    public class DeleteGundamCommand(int id) : IRequest<bool>
    {
        public int Id { get; } = id;
    }
}
