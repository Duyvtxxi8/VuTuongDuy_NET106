using AppData.Models;

namespace AppClient.IServices
{
    public interface IColorService
    {
        Task<Color> AddColor(Color color);
        Task<List<Color>> GetAllColors();
        Task DeleteColor(Guid id);
    }
}
