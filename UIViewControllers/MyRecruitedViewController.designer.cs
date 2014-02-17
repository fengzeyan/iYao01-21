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
	[Register ("MyRecruitedViewController")]
	partial class MyRecruitedViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnBack { get; set; }

		[Outlet]
		MonoTouch.UIKit.UINavigationBar navBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView tableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (navBar != null) {
				navBar.Dispose ();
				navBar = null;
			}

			if (btnBack != null) {
				btnBack.Dispose ();
				btnBack = null;
			}

			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}
		}
	}
}
