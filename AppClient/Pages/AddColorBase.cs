using AppClient.IServices;
using AppData.Models;
using Microsoft.AspNetCore.Components;

namespace AppClient.Pages
{
    public class AddColorBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IColorService ColorService { get; set; }
        public Color Color { get; set; } = new Color();
        public async Task HandleSubmitForm()
        {
            var result = await ColorService.AddColor(Color);
            if (result != null)
            {
                NavigationManager.NavigateTo("/list");
            }
        }
    }
}
