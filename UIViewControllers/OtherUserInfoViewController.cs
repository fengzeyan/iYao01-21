using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using iYao.iYaoWebService;

namespace iYao
{
	public partial class OtherUserInfoViewController : UIViewController
	{
		public OtherUserInfoViewController () : base ("OtherUserInfoViewController", null)
		{
		}

		public	string userID;

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			btnBack.TouchUpInside+= delegate(object sender, EventArgs e) {
				this.DismissViewController(true,null);
			};
			tabBar.ItemSelected += HandleItemSelected;

			// Perform any additional setup after loading the view, typically from a nib.
		}

		void HandleItemSelected (object sender, UITabBarItemEventArgs e)
		{
			UITabBarItem item = e.Item as UITabBarItem;
			if (item != null) {
				if (item == barItemBasicInfo) {
//					AppDelegate.web.
				} else if (item == barItemAddFirends) {
//					Console.WriteLine(	AppDelegate.web.AddOrUpdateUsers_rel (AppDelegate.currentUser.idstr, userID, RelationType.friends));
					if (AppDelegate.web.AddOrUpdateUsers_rel (AppDelegate.currentUser.idstr, userID, RelationType.friends) > 0) {
						UIAlertView alert = new UIAlertView ();
						alert.Title = "提示";
						alert.Message = "发送请求成功，请等待对方应答。";
						alert.AddButton ("OK");
						alert.Show ();
					} else {
						UIAlertView alert = new UIAlertView ();
						alert.Title = "提示";
						alert.Message = "Unknow Error。";
						alert.AddButton ("OK");
						alert.Show ();
					}
//					Console.WriteLine (AppDelegate.web. (AppDelegate.currentUser.idstr, userID, "nihao ").ToString () + "addapply");
				} else if (item == barItemDeleteFirend) {
//					Console.WriteLine(	AppDelegate.web.AddOrUpdateUsers_rel (AppDelegate.currentUser.idstr, userID, RelationType.blacklist));
					if (AppDelegate.web.AddOrUpdateUsers_rel (AppDelegate.currentUser.idstr, userID, RelationType.blacklist) > 0) {
						UIAlertView alert = new UIAlertView ();
						alert.Title = "提示";
						alert.Message = "已拉黑该用户,您不会再收到来自对方的任何消息。";
						alert.AddButton ("OK");
						alert.Show ();
					} else {
						UIAlertView alert = new UIAlertView ();
						alert.Title = "提示";
						alert.Message = "Unknow Error。";
						alert.AddButton ("OK");
						alert.Show ();
					}
				}

//					Console.WriteLine(AppDelegate.web.DelUsers_rel(AppDelegate.currentUser.idstr, userID).ToString());

			}
		}
	}
}

