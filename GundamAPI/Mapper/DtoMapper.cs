using GundamAPI.Models;

namespace GundamAPI.Mapper
{
    public static class DtoMapper
    {
        public static GundamDto MapToDto(Gundam gundam)
        {
            return new GundamDto
            {
                //Id = gundam.Id,
                Title = gundam.Title,
                Pilot = gundam.Pilot,
                ReleaseDate = gundam.ReleaseDate,
            };
        }

        public static Gundam MapToEntity(GundamDto dto)
        {
            return new Gundam
            {
                //Id = dto.Id,
                Title = dto.Title,
                Pilot = dto.Pilot,
                ReleaseDate = dto.ReleaseDate,
            };
        }
    }
}
