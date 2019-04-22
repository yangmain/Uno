using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppKit;
using Foundation;
using Windows.UI.Xaml;

namespace Windows.UI.Xaml.Controls
{
	public class NativeMenuBarPresenter : FrameworkElement
	{
		private MenuBar _menuBar;

		public NativeMenuBarPresenter()
		{
			Loaded += MenuBarPresenter_Loaded;
		}

		private void MenuBarPresenter_Loaded(object sender, RoutedEventArgs e)
		{
			_menuBar = this.FindFirstParent<MenuBar>() ?? throw new InvalidOperationException($"MenuBarPresenter must be used with a MenuBar control");

			NSMenu menubar = new NSMenu();

			foreach (var item in _menuBar.Items)
			{
				NSMenuItem appMenuItem = new NSMenuItem(item.Title);
				menubar.AddItem(appMenuItem);

				AddSubMenus(appMenuItem, item);
			}

			NSApplication.SharedApplication.MainMenu = menubar;
		}

		private void AddSubMenus(NSMenuItem platformItem, MenuBarItem item)
		{
			if (item.Items.Any())
			{
				platformItem.Submenu = new NSMenu();

				foreach (var subItem in item.Items)
				{
					NSMenuItem subPlatformItem = null;
					switch (subItem)
					{
						case MenuFlyoutSubItem flyoutSubItem:
							platformItem.Submenu.AddItem(subPlatformItem = new NSMenuItem(flyoutSubItem.Text));
							break;

						case MenuFlyoutItem flyoutItem:
							platformItem.Submenu.AddItem(subPlatformItem = new NSMenuItem(flyoutItem.Text));
							break;
					}

					//if (subPlatformItem != null)
					//{
					//	AddSubMenus(subPlatformItem, subItem);
				//}
				}
			}
		}

		private void PlatformItem_Activated(object sender, EventArgs e) 
		{
			Console.WriteLine("Item activated");
		}
	}
}
