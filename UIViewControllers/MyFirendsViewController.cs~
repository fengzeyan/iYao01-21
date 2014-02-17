using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq;
using System.Collections.Generic;
using SDWebImage;
using iYao.iYaoWebService;

namespace iYao
{
	public class FriendsTableViewCell:UITableViewCell
	{
		public		UIImageView imgView;
		public	UILabel lblName;
		public	UILabel lblTime;
		public	UILabel lblRange;

		public FriendsTableViewCell (UITableViewCellStyle style, string reuseIdentifier) : base (style, (reuseIdentifier != null) ? new NSString (reuseIdentifier) : null)
		{
			imgView = new UIImageView ();
			imgView.Frame = new RectangleF (20, 10, 40, 40);
			imgView.Layer.MasksToBounds = true;
			imgView.Layer.CornerRadius = 20;
			AddSubview (imgView);
			this.SelectionStyle = UITableViewCellSelectionStyle.None;
			this.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			lblName = new UILabel ();
			lblName.Frame = new RectangleF (65, 20, 150, 20);
			lblName.BackgroundColor = UIColor.Clear;
			AddSubview (lblName);

			lblRange = new UILabel ();
			lblTime = new UILabel ();
			lblRange.Frame = new RectangleF (210,30,80,20);
			lblTime.Frame = new RectangleF (210,10,80,20);
			lblTime.BackgroundColor = UIColor.Clear;
			lblRange.BackgroundColor = UIColor.Clear;
			lblRange.TextAlignment = UITextAlignment.Right;
			lblTime.TextAlignment = UITextAlignment.Right;

			AddSubview (lblRange);
			AddSubview (lblTime);

			lblName.TextColor = UIColor.White;
			lblRange.TextColor = UIColor.White;
			lblTime.TextColor = UIColor.White;

			if (AppDelegate.currentUser.gender == "m") {
				this.BackgroundColor = UIColor.FromRGB (255, 236, 131);
			} else {
				this.BackgroundColor = UIColor.FromRGB (218, 108, 95);
			}

		}
	}

	public class FriendsTableViewSource:UITableViewSource
	{
		public FriendsTableViewSource (List<	Contacts> ContactsList,UIViewController  viewc)
		{
			rows = ContactsList;
			ViewController = viewc;
		}
		UIViewController ViewController;

		List<	Contacts> rows;

		public override int RowsInSection (UITableView tableview, int section)
		{

			return rows.Count;
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 60;
		}

		string id = "cellID";

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			FriendsTableViewCell cell;
			cell = tableView.DequeueReusableCell (id) as FriendsTableViewCell;
			if (cell == null) {
				cell = new FriendsTableViewCell (UITableViewCellStyle.Default, id);
			}

			cell.lblName.Text = rows [indexPath.Row].name;
			cell.imgView.SetImage (new NSUrl (rows [indexPath.Row].profile_image_url));
			var range = Common.GetDistance (Common.Latitude, Common.Longitude, rows [indexPath.Row].Latitude, rows [indexPath.Row].Longitude);
			if (range > 1) {
				cell.lblRange.Text =Convert.ToInt32( range) + "公里";
			} else {
				cell.lblRange.Text =Convert.ToInt32( range*1000) + "米";
			}
			cell.lblTime.Text = Common.GetTimeSpan (rows[indexPath.Row].LastLoginTime);
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true);

			MessageViewController mvc = new MessageViewController ();
			Users u = new  Users ();
			u.gender = rows[indexPath.Row].gender;
			u.id = rows[indexPath.Row].id;
			u.idstr = rows[indexPath.Row].idstr;
			u.name = rows[indexPath.Row].name;
			u.profile_image_url = rows[indexPath.Row].profile_image_url;
			u.screen_name = rows[indexPath.Row].screen_name;
			mvc.fromUser = Common.GetUserFromLocalUser (AppDelegate.currentUser);
			mvc.toUser = u;
			ViewController.PresentViewController (mvc, true, null); 
		}
	}

	public partial class MyFirendsViewController : UIViewController
	{
		public MyFirendsViewController () : base ("MyFirendsViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}



		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			navBar.TopItem.Title = "我的好友";
		
			//	ios7 去除SearchBar背景颜色
			searchBar.BarTintColor = UIColor.Clear;
//			searchBar.BarTintColor = UIColor.FromRGB (65,27,35);


			if (AppDelegate.currentUser.gender == "m") {
				tableView.BackgroundColor = UIColor.FromRGB (255, 235, 137);
				navBar.BarTintColor = UIColor.FromRGB (49,49,49);

			} else {
				tableView.BackgroundColor = UIColor.FromRGB (218, 108, 95);
				navBar.BarTintColor = UIColor.FromRGB (65,27,35);
			}
			btnBack.Frame = new RectangleF (btnBack.Frame.Location, new SizeF (50, 27));
			btnBack.SetBackgroundImage (UIImage.FromFile ("Images/buttonback@2x.png"), UIControlState.Normal);
			btnBack.TitleEdgeInsets = new UIEdgeInsets (0, 5, 0, 0);
			btnBack.SetTitleColor (UIColor.White, UIControlState.Normal);
			btnBack.TouchUpInside += Back;
			List<	Contacts> ContactsList = AppDelegate.db.QueryAsync<Contacts > ("SELECT * FROM Contacts inner JOIN Friends ON Contacts.id=Friends.id ").Result;
			var values = ContactsList.OrderBy (x => x.name).ToList ();

			tableView.Source = new FriendsTableViewSource (values,this);

			// Perform any additional setup after loading the view, typically from a nib.
		}

		void Back (object sender, EventArgs e)
		{
			this.DismissViewController (true, null);
		}
	}
}

