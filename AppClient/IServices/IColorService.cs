using AppData.Models;

namespace AppClient.IServices
{
    public interface IColorService
    {
        Task<Color> AddColor(Color color);
        Task UpdateColor(Guid id);
        Task<List<Color>> GetAllColors();
        Task DeleteColor(Guid id);
    }
}
