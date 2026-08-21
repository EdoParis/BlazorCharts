using Microsoft.AspNetCore.Components;

namespace WebApp.Layout
{
    public partial class MainLayout : LayoutComponentBase
    {
        private bool HiddenMenu = true;

        private void OnToggleMenu()
        {
            HiddenMenu = !HiddenMenu;
        }

        private void OnHideMenu()
        {
            HiddenMenu = true;
        }

        private void OnShowMenu()
        {
            HiddenMenu = false;
        }
    }
}
