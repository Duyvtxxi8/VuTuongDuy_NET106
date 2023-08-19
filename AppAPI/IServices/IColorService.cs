using AppData.Models;

namespace AppAPI.IServices
{
	public interface IColorService
	{
		Task<Color> AddColor(Color color);
		Task UpdateColor(Color color);
		Task<List<Color>> GetAllColors();
		Task DeleteColor(Guid id);
	}
}
