using AppClient.IServices;
using AppData.Models;
using Microsoft.AspNetCore.Components;

namespace AppClient.Pages
{
    public class GetAllColorBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IColorService ColorService { get; set; }
        public List<Color> Colors { get; set; }
        public Guid editingColorId = Guid.Empty;


        protected override async Task OnInitializedAsync()
        {
            Colors = (await ColorService.GetAllColors()).ToList();
        }
        public async Task DeleteColor(Guid id)
        {
            await ColorService.DeleteColor(id);
            NavigationManager.NavigateTo("/list", forceLoad: true);
        }
        public void StartEditing(Guid id)
        {
            editingColorId = id;
        }
        public async Task SaveChanges(Guid id)
        {
            var color = Colors.FirstOrDefault(c => c.Id == id);
            if (color != null)
            {
                await ColorService.UpdateColor(color.Id);
                editingColorId = Guid.Empty;
            }
        }
    }
}
