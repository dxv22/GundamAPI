using GundamAPI.Models;
using MediatR;

namespace GundamAPI.Queries.GetGundamById
{
    public class GetGundamByIdQuery(int id) : IRequest<Gundam>
    {
        public int Id { get; set; } = id;
    }
}
