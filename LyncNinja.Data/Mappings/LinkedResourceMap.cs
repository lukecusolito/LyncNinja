using LyncNinja.Data.EntityModels;
using LyncNinja.Domain.Models.Dto;

namespace LyncNinja.Data.Mappings
{
    public static partial class Mappings
    {
        public static LinkedResourceDto Map(LinkedResource entity)
        {
            return new LinkedResourceDto
            {
                Id = entity.UID,
                Url = entity.Url,
                Created = entity.Created
            };
        }

        public static void Map(ref LinkedResource entity, LinkedResourceDto dto)
        {
            if (dto.Id > 0)
                entity.UID = dto.Id;

            entity.Url = dto.Url;
            entity.Created = dto.Created;
        }
    }
}
