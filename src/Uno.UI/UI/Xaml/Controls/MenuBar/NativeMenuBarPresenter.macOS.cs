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

			var platformItems = _menuBar.Items.Select(i =>
			{
				var platformItem = new NSMenuItem(i.Title);
				platformItem.Activated += PlatformItem_Activated;
				return platformItem;
			}).ToArray();

			NSApplication.SharedApplication.MainMenu.Items = platformItems;
		}

		private void PlatformItem_Activated(object sender, EventArgs e) => throw new NotImplementedException();
	}
}
