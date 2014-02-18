using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iYao
{
	public partial class MessageManagementViewController : UIViewController
	{
		public MessageManagementViewController () : base ("MessageManagementViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		void LoadBackButton ()
		{
			btnBack.SetTitleColor (UIColor.White, UIControlState.Normal);
			btnBack.SetTitle ("返回", UIControlState.Normal);
			btnBack.SetTitleColor (UIColor.White, UIControlState.Normal);
			//			btnBack.SetImage (UIImage.FromFile ("Images/buttonback@2x.png"), UIControlState.Normal);
			btnBack.Frame = new RectangleF (btnBack.Frame.Location, new SizeF (50, 27));
			btnBack.SetBackgroundImage (UIImage.FromFile ("Images/buttonback@2x.png"), UIControlState.Normal);
			btnBack.TitleEdgeInsets = new UIEdgeInsets (0, 5, 0, 0);

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			barItemNormessage.Image = UIImage.FromFile ("Images/MessageManagement/normal@2x.png");
			barItemRecommandMessage.Image = UIImage.FromFile ("Images/MessageManagement/recommand@2x.png");
			barItemSystemMessage.Image = UIImage.FromFile ("Images/MessageManagement/system@2x.png");


			if (AppDelegate.currentUser.gender == "f") {

				UITabBar.Appearance.BarTintColor = UIColor.FromRGB (65, 27, 35);
				UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB (65, 27, 35);
				tabBar.SelectedImageTintColor = UIColor.FromRGB (65, 27, 35);
			} else {
				UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB (49, 49, 49);
				UITabBar.Appearance.BarTintColor = UIColor.FromRGB (49, 49, 49);
				tabBar.SelectedImageTintColor = UIColor.FromRGB (49, 49, 49);
			}


			normalTableView.Hidden = false;
			systemTableView.Hidden = true;
			recommandTableView.Hidden = true;

			LoadBackButton ();

			this.btnBack.TouchUpInside += BackToPreviouViewController;

			tabBar.ItemSelected += TabBarItemSelectChanged;
			tabBar.SelectedItem = tabBar.Items [0];


			var latelyFriendsContactsList =	AppDelegate.db.QueryAsync<Contacts > ("SELECT * FROM Contacts inner JOIN Friends ON Contacts.id=Friends.id order by Friends.LatelyMessageTime");
			var latelyApplyContactsList =	AppDelegate.db.QueryAsync<Contacts > ("SELECT * FROM Contacts inner JOIN Stranger ON Contacts.id=Stranger.id order by Stranger.LatelyMessageTime");


			recommandTableView.Source = new RecommandMessageTableViewSource (latelyApplyContactsList.Result, this);


			normalTableView.Source = new 	NormalMessageTableViewSource (latelyFriendsContactsList.Result, this);


			if (Common.toUserMessageCount != 0) {
				barItemNormessage.BadgeValue = Common.toUserMessageCount.ToString ();
			} else if (Common.recommendMessageCount != 0) {
				barItemRecommandMessage.BadgeValue = Common.recommendMessageCount.ToString ();
			} else if (Common.systemMessageCount != 0) {
				barItemSystemMessage.BadgeValue = Common.systemMessageCount.ToString ();
			}
			// Perform any additional setup after loading the view, typically from a nib.
		}

		void TabBarItemSelectChanged (object sender, UITabBarItemEventArgs e)
		{
			if (e.Item == barItemNormessage) {
				this.normalTableView.Hidden = false;
				this.systemTableView.Hidden = true;
				this.recommandTableView.Hidden = true;
			} else if (e.Item == barItemRecommandMessage) {
				this.normalTableView.Hidden = true;
				this.systemTableView.Hidden = true;
				this.recommandTableView.Hidden = false;
			} else if (e.Item == barItemSystemMessage) {
				this.normalTableView.Hidden = true;
				this.systemTableView.Hidden = false;
				this.recommandTableView.Hidden = true;
			}
		}

		void BackToPreviouViewController (object sender, EventArgs e)
		{
			this.DismissViewController (true, null);
		}
	}
}

