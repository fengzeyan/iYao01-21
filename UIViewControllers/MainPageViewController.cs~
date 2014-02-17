//using System;
//using MonoTouch.UIKit;
//using System.Drawing;
//using SDWebImage;
//using MonoTouch.Foundation;
//using System.Linq;
//
//namespace iYao
//{
//	public class MainPageViewController:UIViewController
//	{
//		public MainPageViewController ()
//		{
//		}
//
//		public override void ViewDidLoad ()
//		{
//			base.ViewDidLoad ();
//
//			UIImageView coverImageView = new UIImageView ();
//			coverImageView.Frame = new System.Drawing.RectangleF (30, 40, 80, 80);
//
//			UILabel lblName = new UILabel ();
//			lblName.Frame = new System.Drawing.RectangleF (120, 70, 120, 20);
//
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
//
//	
//			btnRecruitHero = UIButton.FromType (UIButtonType.Custom);
//			btnSearch = UIButton.FromType (UIButtonType.Custom);
//			btnMyFriends = UIButton.FromType (UIButtonType.Custom);
//			btnMessageCenter = UIButton.FromType (UIButtonType.Custom);
//			btnSetting = UIButton.FromType (UIButtonType.Custom);
//
//
//			btnRecruitHero.Frame = new System.Drawing.RectangleF (70, 150, 120, 30);
//			btnSearch.Frame = new System.Drawing.RectangleF (70, 210, 120, 30);
//			btnMyFriends.Frame = new System.Drawing.RectangleF (70, 270, 120, 30);
//			btnMessageCenter.Frame = new System.Drawing.RectangleF (70, 330, 120, 30);
//			btnSetting.Frame = new System.Drawing.RectangleF (70, 390, 120, 30);
//
//
//
//			View.AddSubview (btnSearch);
//			View.AddSubview (btnSetting);
//			View.AddSubview (btnRecruitHero);
//			View.AddSubview (btnMyFriends);
//			View.AddSubview (btnMessageCenter);
//			View.AddSubview (lblName);
//			View.AddSubview (coverImageView);
//			View.AddSubview (imgOne);
//			View.AddSubview (imgTwo);
//			View.AddSubview (imgThree);
//			View.AddSubview (imgFive);
//			View.AddSubview (imgFour);
//
//
////			招募英雄
////			搜索英雄
////			我的英雄
////			消息信箱
////			设置中心
////			救美任务
////			搜索公主
////			我的公主
//
//			UIView rightView = new UIView ();
//			rightView.Frame = new RectangleF (240, 0, 80, UIScreen.MainScreen.Bounds.Height);
//			if (AppDelegate.currentUser.gender == "m") {
//				rightView.BackgroundColor = UIColor.FromRGB (27, 36, 18);
//				this.View.BackgroundColor = UIColor.FromRGB (225, 235, 137);
//				btnMessageCenter.SetTitle ("消息信箱", UIControlState.Normal);
//				btnMyFriends.SetTitle ("我的公主", UIControlState.Normal);
//				btnRecruitHero.SetTitle ("救美任务", UIControlState.Normal);
//				btnSearch.SetTitle ("搜索公主", UIControlState.Normal);
//				btnSetting.SetTitle ("设置中心", UIControlState.Normal);
//
//
//
//			} else {
//				rightView.BackgroundColor = UIColor.FromRGB (116, 19, 51);
//
//				btnMessageCenter.SetTitle ("消息信箱", UIControlState.Normal);
//				btnMyFriends.SetTitle ("我的英雄", UIControlState.Normal);
//				btnRecruitHero.SetTitle ("招募英雄", UIControlState.Normal);
//				btnSearch.SetTitle ("搜索英雄", UIControlState.Normal);
//				btnSetting.SetTitle ("设置中心", UIControlState.Normal);
//
//				this.View.BackgroundColor = UIColor.FromRGB (216, 109, 98);
//				btnSearch.SetTitleColor (UIColor.FromRGB (115, 19, 50), UIControlState.Normal);
//				btnSetting.SetTitleColor (UIColor.FromRGB (115, 19, 50), UIControlState.Normal);
//				btnRecruitHero.SetTitleColor (UIColor.FromRGB (115, 19, 50), UIControlState.Normal);
//				btnMessageCenter.SetTitleColor (UIColor.FromRGB (115, 19, 50), UIControlState.Normal);
//				btnMyFriends.SetTitleColor (UIColor.FromRGB (115, 19, 50), UIControlState.Normal);
//
//
//			}
//			this.View.AddSubview (rightView);
//
//
//			InvokeInBackground (() => {
//				try {
//					Common.InitServerConnection ();
//
//					var userFriends = AppDelegate.web.GetMyUsers_rel (AppDelegate.currentUser.idstr);
//					if (userFriends != null) {
//						foreach (var item in userFriends) {
//							var c = Common.GetContactsFromUsers (item);
//							Contacts c1 = AppDelegate.db.QueryAsync<Contacts > ("SELECT * FROM Contacts WHERE (id=?)", item.idstr).Result.FirstOrDefault ();
//							if (c1 != null) {
//								AppDelegate.db.UpdateAsync (c);
//							} else {
//								AppDelegate.db.InsertAsync (c);
//							}
//						}
//					}
//
//				} catch (Exception ex) {
//					Console.WriteLine ("Server Connection Error " + ex.ToString ());
//				}
//			});
//			lblName.Text = AppDelegate.currentUser.name;
//			coverImageView.SetImage (new NSUrl (AppDelegate.currentUser.profile_image_url), null, null);
//			btnRecruitHero.TouchUpInside += ShowRecruitedViewController;
//
//			btnMessageCenter.TouchUpInside += GotoMessagesManagement;
//
//			btnSetting.TouchUpInside += GotoSettingViewController;
//
//			btnSearch.TouchUpInside += GotoSearchViewController;
//
//			btnMyFriends.TouchUpInside += GotoMyFirendsViewController;
//		}
//
//		UIButton btnRecruitHero;
//		UIButton btnSearch;
//		UIButton btnMyFriends;
//		UIButton btnMessageCenter;
//		UIButton btnSetting;
//
//		void GotoMyFirendsViewController (object sender, EventArgs e)
//		{
//			MyFirendsViewController mmvc = new MyFirendsViewController ();
//			this.PresentViewController (mmvc, true, null);
//		}
//
//		void GotoSearchViewController (object sender, EventArgs e)
//		{
//
//		}
//
//		void GotoSettingViewController (object sender, EventArgs e)
//		{
//			SettingViewController mmvc = new SettingViewController ();
//			this.PresentViewController (mmvc, true, null);
//		}
//
//		void GotoMessagesManagement (object sender, EventArgs e)
//		{
//			MessageManagementViewController mmvc = new MessageManagementViewController ();
//			this.PresentViewController (mmvc, true, null);
//		}
//
//		public void SetMessageTitle ()
//		{
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
//		}
//
//		void ShowRecruitedViewController (object sender, EventArgs e)
//		{
//			MyRecruitedViewController viewC = new MyRecruitedViewController ();
//			this.PresentViewController (viewC, true, null);
//		}
//	}
//}
//
