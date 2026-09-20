using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using WebApp.Enums;

namespace WebApp.Layout
{
    public partial class MainLayout : LayoutComponentBase, IDisposable
    {
        [Inject] public NavigationManager NavManager { get; set; }
        private PageEnum CurrentPage = PageEnum.Home;
        private Boolean HiddenMenu = true;
        private Boolean IsDarkMode = false;

        protected override void OnInitialized()
        {
            string current_url = NavManager?.ToBaseRelativePath(NavManager.Uri);
            FindPage(current_url);

            NavManager.LocationChanged += OnPage;
        }

        private PageEnum FindPage(string current_url)
        {
            if (string.IsNullOrEmpty(current_url))
                return PageEnum.Home;

            foreach (PageEnum page in Enum.GetValues<PageEnum>())
            {
                if (current_url.EndsWith(page.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return page;
                }
            }

            return PageEnum.Home;
        }

        private void OnToggleDark()
        {
            IsDarkMode = !IsDarkMode;
        }

        private void OnToggleMenu()
        {
            HiddenMenu = !HiddenMenu;
        }

        private void OnPage(object sender, LocationChangedEventArgs args)
        {
            HiddenMenu = true;
            CurrentPage = FindPage(args?.Location);
            StateHasChanged();
        }

        public void Dispose()
        {
            if (NavManager is null)
                return;

            NavManager.LocationChanged -= OnPage;
        }
    }
}
