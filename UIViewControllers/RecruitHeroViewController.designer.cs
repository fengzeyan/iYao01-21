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
	[Register ("RecruitHeroViewController")]
	partial class RecruitHeroViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnAction { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnBack { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnPulish { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnTime { get; set; }

		[Outlet]
		MonoTouch.UIKit.UINavigationBar navBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView txtDescribe { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnAction != null) {
				btnAction.Dispose ();
				btnAction = null;
			}

			if (btnBack != null) {
				btnBack.Dispose ();
				btnBack = null;
			}

			if (btnPulish != null) {
				btnPulish.Dispose ();
				btnPulish = null;
			}

			if (btnTime != null) {
				btnTime.Dispose ();
				btnTime = null;
			}

			if (txtDescribe != null) {
				txtDescribe.Dispose ();
				txtDescribe = null;
			}

			if (navBar != null) {
				navBar.Dispose ();
				navBar = null;
			}
		}
	}
}
