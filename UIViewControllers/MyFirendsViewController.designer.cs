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
	[Register ("MyFirendsViewController")]
	partial class MyFirendsViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnBack { get; set; }

		[Outlet]
		MonoTouch.UIKit.UINavigationBar navBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISearchBar searchBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView tableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (navBar != null) {
				navBar.Dispose ();
				navBar = null;
			}

			if (searchBar != null) {
				searchBar.Dispose ();
				searchBar = null;
			}

			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}

			if (btnBack != null) {
				btnBack.Dispose ();
				btnBack = null;
			}
		}
	}
}
