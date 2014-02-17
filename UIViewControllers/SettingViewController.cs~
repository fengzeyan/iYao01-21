using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace iYao
{
	public class SettingTableViewSource:UITableViewSource
	{
		string cellid="cellid";
		public SettingTableViewSource()
		{
			rows = new List<string> ();
			rows.Add ("通知设置");
			rows.Add ("系统设置");
			rows.Add ("个人隐私设置");
				rows.Add ("绑定设置");
		}
		List<String> rows;
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell;
			cell = tableView.DequeueReusableCell (cellid);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellid);
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				cell.SelectionStyle = UITableViewCellSelectionStyle.None;
				UIView v = new UIView ();
				v.Frame = new RectangleF (10,52,cell.Frame.Width-10,1);
				v.BackgroundColor = UIColor.Black;
				cell.AddSubview (v);
			}
			cell.TextLabel.Text = rows [indexPath.Row];
			if (AppDelegate.currentUser.gender == "m") {
				cell.TextLabel.TextColor = UIColor.FromRGB(48,48,48);
			} else {
				cell.TextLabel.TextColor = UIColor.FromRGB(115,19,50);
			}
			return cell;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return 4;
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 53;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, false);
		}

	}


	public partial class SettingViewController : UIViewController
	{
		public SettingViewController () : base ("SettingViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		void LoadBackButton()
		{
			btnBack.SetTitleColor (UIColor.White, UIControlState.Normal);

			//			btnBack.SetImage (UIImage.FromFile ("Images/buttonback@2x.png"), UIControlState.Normal);
			btnBack.Frame = new RectangleF (btnBack.Frame.Location,new SizeF (50,27));
			btnBack.SetBackgroundImage(UIImage.FromFile ("Images/buttonback@2x.png"), UIControlState.Normal);
			btnBack.TitleEdgeInsets = new UIEdgeInsets (0, 5, 0, 0);

		}

		public override UIStatusBarStyle PreferredStatusBarStyle ()
		{
			return UIStatusBarStyle.LightContent;
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			btnLogout.Frame = new RectangleF (btnLogout.Frame.X,UIScreen.MainScreen.Bounds.Height-60,btnLogout.Frame.Width,60);
			btnBack.TouchUpInside+= delegate(object sender, EventArgs e) {
				this.DismissViewController(true,null);
			};

			LoadBackButton ();
			tableView.Frame = new RectangleF (tableView.Frame.X,tableView.Frame.Y,tableView.Frame.Width,UIScreen.MainScreen.Bounds.Height-navBar.Frame.Y-navBar.Frame.Height-btnLogout.Frame.Height);
			tableView.BackgroundColor = UIColor.White;
			tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			tableView.Source = new SettingTableViewSource ();
			if (AppDelegate.currentUser.gender == "m") {
				navBar.TintColor = UIColor.FromRGB (48, 48, 48);
				navBar.BarTintColor = UIColor.FromRGB (48, 48, 48);
				navBar.BackgroundColor = UIColor.FromRGB (48, 48, 48);
				btnLogout.BackgroundColor = UIColor.FromRGB (48, 48, 48);
			} else {
				navBar.TintColor = UIColor.FromRGB (62, 26, 34);
				navBar.BarTintColor = UIColor.FromRGB (62, 26, 34);
				navBar.BackgroundColor = UIColor.FromRGB (62, 26, 34);
				btnLogout.BackgroundColor = UIColor.FromRGB (62, 26, 34);
			}
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

