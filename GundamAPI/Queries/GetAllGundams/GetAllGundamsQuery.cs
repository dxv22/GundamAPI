using GundamAPI.Models;
using MediatR;

namespace GundamAPI.Queries.GetAllGundams
{
    public class GetAllGundamsQuery : IRequest<IEnumerable<Gundam>>
    {
        // No parameters required
    }
}