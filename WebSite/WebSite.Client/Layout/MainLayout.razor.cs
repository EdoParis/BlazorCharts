using Microsoft.AspNetCore.Components;
using WebApp.Enums;

namespace WebApp.Layout
{
    public partial class MainLayout : LayoutComponentBase
    {
        [Inject] public NavigationManager NavManager { get; set; }
        private PageEnum CurrentPage = PageEnum.Home;
        private Boolean HiddenMenu = true;

        protected override void OnInitialized()
        {
            string current_url = NavManager?.ToBaseRelativePath(NavManager.Uri);

            if (string.IsNullOrEmpty(current_url))
                return;

            foreach (PageEnum page in Enum.GetValues<PageEnum>())
            {
                if (current_url.EndsWith(page.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    CurrentPage = page;
                    return;
                }
            }
        }

        private void OnToggleMenu()
        {
            HiddenMenu = !HiddenMenu;
        }

        private void OnPage(PageEnum page)
        {
            HiddenMenu = true;
            CurrentPage = page;
        }
    }
}
