using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading.Tasks;
using System.Linq;

namespace iYao
{
	public partial class SplashScreenViewController : UIViewController
	{
		public SplashScreenViewController () : base ("SplashScreenViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		private readonly TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext ();
		LoginViewController viewController;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			try {
				UIImageView imgView = new UIImageView ();
				imgView.Frame = new RectangleF (0, 0, 320, 568);
				imgView.Image = UIImage.FromBundle ("Images/640x1136.png");
				this.View.AddSubview (imgView);

				AppDelegate.db.QueryAsync<LocalUser > ("SELECT * FROM LocalUser ")
					.ContinueWith (t => {
					if (t.Exception != null) {
					}
					if (t.Result.Count > 0) {
						AppDelegate.currentUser = t.Result.FirstOrDefault ();
//						if (AppDelegate.currentUser.gender == "f") {
//							femaleViewController = new MainPageForFemale ();
//							AppDelegate.mainPageForFemale = femaleViewController;
//							this.PresentViewController (femaleViewController, false, null);
//						} else if (AppDelegate.currentUser.gender == "m") {
//							maleViewController = new  MainPageForMale ();
//							this.PresentViewController (maleViewController, false, null);
//						}
							MainPageViewController mainpage=new MainPageViewController ();
							AppDelegate.MainPage=mainpage;
							this.PresentViewController (mainpage, false, null);
					} else {
						viewController = new LoginViewController ();
						this.PresentViewController (viewController, false, null);
					}

				}, uiScheduler);

			} catch (Exception ex) {
				Console.WriteLine ("EX" + ex.ToString ());
			}
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

