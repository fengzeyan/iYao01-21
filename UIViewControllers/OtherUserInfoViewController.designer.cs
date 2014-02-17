// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace iYao
{
	[Register ("OtherUserInfoViewController")]
	partial class OtherUserInfoViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITabBarItem barItemAddFirends { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITabBarItem barItemBasicInfo { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITabBarItem barItemDeleteFirend { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnBack { get; set; }

		[Outlet]
		MonoTouch.UIKit.UINavigationBar navbar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITabBar tabBar { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (barItemAddFirends != null) {
				barItemAddFirends.Dispose ();
				barItemAddFirends = null;
			}

			if (barItemBasicInfo != null) {
				barItemBasicInfo.Dispose ();
				barItemBasicInfo = null;
			}

			if (barItemDeleteFirend != null) {
				barItemDeleteFirend.Dispose ();
				barItemDeleteFirend = null;
			}

			if (btnBack != null) {
				btnBack.Dispose ();
				btnBack = null;
			}

			if (navbar != null) {
				navbar.Dispose ();
				navbar = null;
			}

			if (tabBar != null) {
				tabBar.Dispose ();
				tabBar = null;
			}
		}
	}
}
