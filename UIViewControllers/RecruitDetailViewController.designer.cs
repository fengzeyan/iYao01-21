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
	[Register ("RecruitDetailViewController")]
	partial class RecruitDetailViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnApply { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnBack { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblAge { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblDistance { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel lblPublishTime { get; set; }

		[Outlet]
		MonoTouch.UIKit.UINavigationBar navBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView txtUserDes { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView userImageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnApply != null) {
				btnApply.Dispose ();
				btnApply = null;
			}

			if (btnBack != null) {
				btnBack.Dispose ();
				btnBack = null;
			}

			if (lblAge != null) {
				lblAge.Dispose ();
				lblAge = null;
			}

			if (lblDistance != null) {
				lblDistance.Dispose ();
				lblDistance = null;
			}

			if (lblName != null) {
				lblName.Dispose ();
				lblName = null;
			}

			if (lblPublishTime != null) {
				lblPublishTime.Dispose ();
				lblPublishTime = null;
			}

			if (navBar != null) {
				navBar.Dispose ();
				navBar = null;
			}

			if (txtUserDes != null) {
				txtUserDes.Dispose ();
				txtUserDes = null;
			}

			if (userImageView != null) {
				userImageView.Dispose ();
				userImageView = null;
			}
		}
	}
}
