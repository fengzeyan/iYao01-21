using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using iYao.iYaoWebService;

namespace iYao
{
	public partial class RecruitHeroViewController : UIViewController
	{
		public RecruitHeroViewController () : base ("RecruitHeroViewController", null)
		{
		}
		void LoadBackButton()
		{
			btnBack.SetTitleColor (UIColor.White, UIControlState.Normal);

			//			btnBack.SetImage (UIImage.FromFile ("Images/buttonback@2x.png"), UIControlState.Normal);
			btnBack.Frame = new RectangleF (btnBack.Frame.Location,new SizeF (50,27));
			btnBack.SetBackgroundImage(UIImage.FromFile ("Images/buttonback@2x.png"), UIControlState.Normal);
			btnBack.TitleEdgeInsets = new UIEdgeInsets (0, 5, 0, 0);
			btnBack.TouchUpInside+= delegate(object sender, EventArgs e) {
				this.DismissViewController(true,null);
			};
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
			LoadBackButton ();
			UITapGestureRecognizer tap = new UITapGestureRecognizer ();
			tap.AddTarget (() => {
				this.View.EndEditing (true);
			});
			this.View.AddGestureRecognizer (tap);
			btnPulish.TouchUpInside += PublishRecruitHero;
			txtDescribe.Layer.MasksToBounds = true;
			txtDescribe.Layer.BorderWidth = 1;
			txtDescribe.Layer.BorderColor = UIColor.Black.CGColor;
			// Perform any additional setup after loading the view, typically from a nib.

			//set navigationbar


		}

		void PublishRecruitHero (object sender, EventArgs e)
		{
			UIAlertView alert = new UIAlertView ();
			alert.AddButton ("等待");
			alert.Title = "发布成功";
			alert.Message = "等待你的勇者来解救你吧。";
			alert.Show ();
			alert.Dismissed += HandleDismissed;


			Recruit r = new Recruit ();
			r.Description = txtDescribe.Text;
			r.EffectiveTime = 3;
			r.Latitude = Common.Latitude;
			r.Longitude = Common.Longitude;
			r.PublishTime = DateTime.Now;
			r.PublishUser = Common.GetUserFromLocalUser (AppDelegate.currentUser);
			r.Target = new RecruitTarget () { 
				RecruitTargetDisplayName = "做苦力",
				RecruitTargetID = "123123123"
			};
			AppDelegate.web.AddRecruit (r);
		}

		void HandleDismissed (object sender, UIButtonEventArgs e)
		{
			this.DismissViewController (true, null);
		}
	}
}

