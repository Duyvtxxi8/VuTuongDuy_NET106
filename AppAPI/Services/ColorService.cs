using AppAPI.IServices;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Services
{
	public class ColorService : IColorService
	{
		public readonly AppDbContext _dbContext;
		public ColorService()
		{
			_dbContext = new AppDbContext();
		}
		public async Task<Color> AddColor(Color color)
		{
			await _dbContext.AddAsync(color);
			await _dbContext.SaveChangesAsync();
			return color;
		}

		public async Task DeleteColor(Guid id)
		{
			var colorID = await _dbContext.FindAsync<Color>(id);
			_dbContext.Remove(colorID);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<List<Color>> GetAllColors()
		{
			return await _dbContext.Colors.ToListAsync();
		}

		public async Task UpdateColor(Color color)
		{
			var objColor = await _dbContext.FindAsync<Color>(color.Id);
			objColor.ColorName = color.ColorName;
			objColor.Description = color.Description;
			objColor.Status = color.Status;
			_dbContext.Update(objColor);
			await _dbContext.SaveChangesAsync();
		}
	}
}
