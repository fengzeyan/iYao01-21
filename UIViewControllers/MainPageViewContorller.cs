using System;
using MonoTouch.UIKit;
using System.Drawing;
using SDWebImage;
using MonoTouch.Foundation;
using System.Linq;
using System.Collections.Generic;
using MonoTouch.CoreLocation;

namespace iYao
{
	public class MainPageViewController:UIViewController
	{
		public MainPageViewController ()
		{
		}

		public void RequestLocationServicesAuthorization ()
		{
			if (locationManager == null)
				locationManager = new CLLocationManager ();
			locationManager.Delegate = new iYaoLocationDelegate ();
			locationManager.Failed += delegate {
				locationManager.StopUpdatingLocation ();
			};
			locationManager.LocationsUpdated += delegate {
				locationManager.StopUpdatingLocation ();
			};
			locationManager.AuthorizationChanged += delegate (object sender, CLAuthorizationChangedEventArgs e) {
				//				CheckLocationServicesAuthorizationStatus (e.Status);
			};
			locationManager.StartUpdatingLocation ();
		}

		CLLocationManager locationManager;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (CLLocationManager.Status != CLAuthorizationStatus.Authorized) {
				RequestLocationServicesAuthorization ();
			} else if (CLLocationManager.Status == CLAuthorizationStatus.Authorized) {
				locationManager = new CLLocationManager ();
				locationManager.Delegate = new iYaoLocationDelegate ();
				locationManager.StartUpdatingLocation ();
				//				locationManager.LocationsUpdated += delegate {
				//					locationManager.StopUpdatingLocation ();
				//				};
			}

		

			UIImageView coverImageView = new UIImageView ();
			coverImageView.Frame = new System.Drawing.RectangleF (30, 40, 80, 80);
			coverImageView.Layer.MasksToBounds = true;
			coverImageView.Layer.CornerRadius = 40;


			UILabel lblName = new UILabel ();
			lblName.Frame = new System.Drawing.RectangleF (120, 70, 120, 20);
			lblName.BackgroundColor = UIColor.Clear;

//			UIImageView imgOne = new UIImageView ();
//			imgOne.Frame = new System.Drawing.RectangleF (30, 150, 30, 30);
//
//			UIImageView imgTwo = new UIImageView ();
//			imgTwo.Frame = new System.Drawing.RectangleF (30, 210, 30, 30);
//			UIImageView imgThree = new UIImageView ();
//			imgThree.Frame = new System.Drawing.RectangleF (30, 270, 30, 30);
//			UIImageView imgFour = new UIImageView ();
//			imgFour.Frame = new System.Drawing.RectangleF (30, 330, 30, 30);
//			UIImageView imgFive = new UIImageView ();
//			imgFive.Frame = new System.Drawing.RectangleF (30, 390, 30, 30);




			View.AddSubview (lblName);
			View.AddSubview (coverImageView);
//			View.AddSubview (imgOne);
//			View.AddSubview (imgTwo);
//			View.AddSubview (imgThree);
//			View.AddSubview (imgFive);
//			View.AddSubview (imgFour);

			UITableView tableView = new UITableView ();
			tableView.Frame = new RectangleF (0, 120, 320, UIScreen.MainScreen.Bounds.Height - 120);
			tableView.Source = new MainPageTableViewSource (this);
			tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			this.View.AddSubview (tableView);
			//			招募英雄
			//			搜索英雄
			//			我的英雄
			//			消息信箱
			//			设置中心
			//			救美任务
			//			搜索公主
			//			我的公主

			UIView rightView = new UIView ();
			rightView.Frame = new RectangleF (240, 0, 80, UIScreen.MainScreen.Bounds.Height);
			if (AppDelegate.currentUser.gender == "m") {
				rightView.BackgroundColor = UIColor.FromRGB (27, 36, 18);
				this.View.BackgroundColor = UIColor.FromRGB (225, 235, 137);
				tableView.BackgroundColor = UIColor.FromRGB (225, 235, 137);
			


			} else {
				rightView.BackgroundColor = UIColor.FromRGB (116, 19, 51);

			

				this.View.BackgroundColor = UIColor.FromRGB (216, 109, 98);
				tableView.BackgroundColor = UIColor.FromRGB (216, 109, 98);
			

			}
			this.View.AddSubview (rightView);


			InvokeInBackground (() => {
				try {
					Common.InitServerConnection ();

					var userFriends = AppDelegate.web.GetMyUsers_rel (AppDelegate.currentUser.idstr);
					if (userFriends != null) {
						foreach (var item in userFriends) {
							var c = Common.GetContactsFromUsers (item);
							Contacts c1 = AppDelegate.db.QueryAsync<Contacts > ("SELECT * FROM Contacts WHERE (id=?)", item.idstr).Result.FirstOrDefault ();
							if (c1 != null) {
								AppDelegate.db.UpdateAsync (c);
							} else {
								AppDelegate.db.InsertAsync (c);
							}
							Friends f = AppDelegate.db.QueryAsync<Friends > ("SELECT * FROM Friends WHERE (id=?)", item.idstr).Result.FirstOrDefault ();
							if (f != null) {
								AppDelegate.db.UpdateAsync (f);
							} else {
								f = new Friends ();
								f.id = c.id;
								f.LatelyMessageTime = DateTime.Now;
								AppDelegate.db.InsertAsync (f).ContinueWith (t2 => {
									if (t2.Exception != null) {
										Console.WriteLine (t2.Exception.InnerException.ToString ());
									}
								});
							}
						}
					}

				} catch (Exception ex) {
					Console.WriteLine ("Server Connection Error " + ex.ToString ());
				}
			});
			lblName.Text = AppDelegate.currentUser.name;
			coverImageView.SetImage (new NSUrl (AppDelegate.currentUser.profile_image_url), null, null);




		}

		void GotoMyFirendsViewController (object sender, EventArgs e)
		{
			MyFirendsViewController mmvc = new MyFirendsViewController ();
			this.PresentViewController (mmvc, true, null);
		}

		void GotoSearchViewController (object sender, EventArgs e)
		{

		}

		void GotoSettingViewController (object sender, EventArgs e)
		{
			SettingViewController mmvc = new SettingViewController ();
			this.PresentViewController (mmvc, true, null);
		}

		void GotoMessagesManagement (object sender, EventArgs e)
		{
			MessageManagementViewController mmvc = new MessageManagementViewController ();
			this.PresentViewController (mmvc, true, null);
		}

		public void SetMessageTitle ()
		{
//			InvokeOnMainThread (delegate {
//				//				btnMessageManagement.SetTitle ("消息中心21312",UIControlState.Normal);
//				foreach (var item in btnMessageCenter .Subviews) {
//					BadgeView b = item as BadgeView;
//					if (b != null) {
//						item.RemoveFromSuperview ();
//						item.Dispose ();
//					}
//				}
//				BadgeView bv = new BadgeView (new RectangleF (btnMessageCenter.Frame.Width - 10, btnMessageCenter.Frame.Height - 10, 20, 20), (Common.toUserMessageCount + Common.recommendMessageCount + Common.systemMessageCount).ToString ());
//				btnMessageCenter.AddSubview (bv);
//			});
		}

		void ShowRecruitedViewController (object sender, EventArgs e)
		{
			MyRecruitedViewController viewC = new MyRecruitedViewController ();
			this.PresentViewController (viewC, true, null);
		}
	}

	public class MainPageTableViewSource:UITableViewSource
	{
		List<string> rows;
		UIViewController ViewController;

		public MainPageTableViewSource (UIViewController view)
		{
			ViewController = view;

			rows = new List<string> ();
			if (AppDelegate.currentUser.gender == "m") {

				rows.Add ("救美任务");
				rows.Add ("搜索公主");
				rows.Add ("我的公主");
				rows.Add ("消息信箱");
				rows.Add ("设置中心");
			} else {

				rows.Add ("招募英雄");
				rows.Add ("搜索英雄");
				rows.Add ("我的英雄");
				rows.Add ("消息信箱");
				rows.Add ("设置中心");
			
			}
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return 5;
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 50;
		}

		string str = "id";

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			MainPageTableViewCell cell;
			cell = tableView.DequeueReusableCell (str) as MainPageTableViewCell;
			if (cell == null) {
				cell = new  MainPageTableViewCell (UITableViewCellStyle.Subtitle, str);
//				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				cell.SelectionStyle = UITableViewCellSelectionStyle.None;

				if (AppDelegate.currentUser.gender == "m") {
					cell.BackgroundColor = UIColor.FromRGB (225, 235, 137);
				} else {
					cell.BackgroundColor = UIColor.FromRGB (216, 109, 98);

				}
			}
			switch (indexPath.Row) {
			case 0:
				UIImage img = UIImage.FromFile ("Images/MainPage/one.png");
				cell.img.Image = img;
			
				img.Dispose ();
				cell.lblBadge.Hidden = false;
				cell.lblBadge.Text = "0";
				break;
			case 1:
				UIImage imgtwo = UIImage.FromFile ("Images/MainPage/two.png");
				cell.img.Image = imgtwo;
				imgtwo.Dispose ();
				break;
			case 2:
				UIImage imgthree = UIImage.FromFile ("Images/MainPage/three.png");
				cell.img.Image = imgthree;
				imgthree.Dispose ();
				break;
			case 3:
				UIImage imgfour = UIImage.FromFile ("Images/MainPage/four.png");
				cell.img.Image = imgfour;
				imgfour.Dispose ();
				cell.lblBadge.Hidden = false;
				cell.lblBadge.Text = "0";
				break;
			case 4:
				UIImage imgfive = UIImage.FromFile ("Images/MainPage/five.png");
				cell.img.Image = imgfive;
				imgfive.Dispose ();
				cell.lblBadge.Hidden = false;
				cell.lblBadge.Text = "0";
				break;
			}

			cell.lbl.Text = rows [indexPath.Row];
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{

			switch (indexPath.Row) {
			case 0:
				try {
					if (AppDelegate.currentUser.gender == "f") {
						MyRecruitedViewController mr = new MyRecruitedViewController ();
						ViewController.PresentViewController (mr, true, null);

					} else {
						AllRecruitViewControllerForMale ar = new AllRecruitViewControllerForMale ();
						ViewController.PresentViewController (ar, true, null);

					}
				} catch (Exception ex) {
					Console.WriteLine (ex.ToString ());
				}
			
				break;
			case 1:
//				search rh = new RecruitHeroViewController ();
//				ViewController.PresentViewController (rh, true, null);
				break;
			case 2:
				MyFirendsViewController mf = new MyFirendsViewController ();
				ViewController.PresentViewController (mf, true, null);
				break;
			case 3:
				MessageManagementViewController mmv = new MessageManagementViewController ();
				ViewController.PresentViewController (mmv, true, null);
				break;
			case 4:
				SettingViewController sv = new SettingViewController ();
				ViewController.PresentViewController (sv, true, null);
				break;
			}
		}
	}

	public class MainPageTableViewCell:UITableViewCell
	{
		public		UIImageView img;
		public UILabel lbl;
		public UILabel lblBadge;

		public MainPageTableViewCell (UITableViewCellStyle style, string reuseIdentifier) : base (style, (reuseIdentifier != null) ? new NSString (reuseIdentifier) : null)
		{
			img = new UIImageView ();
			img.Frame = new RectangleF (10, 10, 30, 30);
			lbl = new UILabel ();
			lbl.Frame = new RectangleF (50, 10, 100, 30);
			lbl.BackgroundColor = UIColor.Clear;
			AddSubview (img);
			AddSubview (lbl);

			lblBadge = new UILabel ();
			lblBadge.Frame = new RectangleF (160, 10, 60, 25);
			lblBadge.BackgroundColor = UIColor.FromRGB (49, 49, 49);
			lblBadge.TextColor = UIColor.White;
			lblBadge.TextAlignment = UITextAlignment.Center;
			lblBadge.Hidden = true;
			lblBadge.Layer.MasksToBounds = true;
			lblBadge.Layer.CornerRadius = 10;
			AddSubview (lblBadge);
		}
	}
}

