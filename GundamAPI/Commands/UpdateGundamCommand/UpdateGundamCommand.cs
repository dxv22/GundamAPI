using GundamAPI.Models;
using MediatR;

namespace GundamAPI.Commands.UpdateGundamCommand
{
    public class UpdateGundamCommand(int id, GundamDto gundamDto) : IRequest<Gundam>
    {
        public int Id { get; } = id;
        public GundamDto GundamDto { get; } = gundamDto;
    }
}
