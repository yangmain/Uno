using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uno.Extensions;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Controls
{
	[ContentProperty(Name = "Items")]
	public partial class MenuFlyout : FlyoutBase
    {
		public MenuFlyout()
		{
			Items = new DependencyObjectCollection<MenuFlyoutItemBase>(this);
		}

		#region Items DependencyProperty

		public IList<MenuFlyoutItemBase> Items
		{
			get { return (IList<MenuFlyoutItemBase>)this.GetValue(ItemsProperty); }
			private set { this.SetValue(ItemsProperty, value); }
		}

		public static readonly DependencyProperty ItemsProperty =
			DependencyProperty.Register(
				"Items",
				typeof(IList<MenuFlyoutItemBase>),
				typeof(MenuFlyoutItem),
				new PropertyMetadata(defaultValue: null)
			);

		#endregion

		public global::Windows.UI.Xaml.Style MenuFlyoutPresenterStyle
		{
			get => (Style)this.GetValue(MenuFlyoutPresenterStyleProperty);
			set => SetValue(MenuFlyoutPresenterStyleProperty, value);
		}

		public static global::Windows.UI.Xaml.DependencyProperty MenuFlyoutPresenterStyleProperty { get; } =
		Windows.UI.Xaml.DependencyProperty.Register(
			"MenuFlyoutPresenterStyle",
			typeof(global::Windows.UI.Xaml.Style),
			typeof(global::Windows.UI.Xaml.Controls.MenuFlyout),
			new FrameworkPropertyMetadata(null));

		public void ShowAt(global::Windows.UI.Xaml.UIElement targetElement, global::Windows.Foundation.Point point)
		{
			base.ShowAt((FrameworkElement)targetElement);
		}
	}
}
