using GundamAPI.Models;
using MediatR;

namespace GundamAPI.Commands.PostGundamCommand
{
    public class PostGundamCommand(GundamDto gundamDto) : IRequest<Gundam>
    {
        public GundamDto GundamDto { get; } = gundamDto;

    }
}
