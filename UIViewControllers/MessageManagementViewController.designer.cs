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
	[Register ("MessageManagementViewController")]
	partial class MessageManagementViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITabBarItem barItemNormessage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITabBarItem barItemRecommandMessage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITabBarItem barItemSystemMessage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnBack { get; set; }

		[Outlet]
		MonoTouch.UIKit.UINavigationBar navBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView normalTableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView recommandTableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView systemTableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITabBar tabBar { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (barItemNormessage != null) {
				barItemNormessage.Dispose ();
				barItemNormessage = null;
			}

			if (barItemRecommandMessage != null) {
				barItemRecommandMessage.Dispose ();
				barItemRecommandMessage = null;
			}

			if (barItemSystemMessage != null) {
				barItemSystemMessage.Dispose ();
				barItemSystemMessage = null;
			}

			if (btnBack != null) {
				btnBack.Dispose ();
				btnBack = null;
			}

			if (normalTableView != null) {
				normalTableView.Dispose ();
				normalTableView = null;
			}

			if (recommandTableView != null) {
				recommandTableView.Dispose ();
				recommandTableView = null;
			}

			if (systemTableView != null) {
				systemTableView.Dispose ();
				systemTableView = null;
			}

			if (tabBar != null) {
				tabBar.Dispose ();
				tabBar = null;
			}

			if (navBar != null) {
				navBar.Dispose ();
				navBar = null;
			}
		}
	}
}
