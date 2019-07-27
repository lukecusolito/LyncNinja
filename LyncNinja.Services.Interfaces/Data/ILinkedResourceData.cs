using LyncNinja.Domain.Models.Dto;

namespace LyncNinja.Services.Interfaces.Data
{
    public interface ILinkedResourceData
    {
        LinkedResourceDto Get(long linkedResourceId);
        LinkedResourceDto Get(string linkedResourceUrl);
        LinkedResourceDto Save(LinkedResourceDto dto);
    }
}
