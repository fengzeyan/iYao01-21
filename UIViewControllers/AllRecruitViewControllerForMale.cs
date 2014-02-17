using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq;

namespace iYao
{
	public partial class AllRecruitViewControllerForMale : UIViewController
	{
		public AllRecruitViewControllerForMale () : base ("AllRecruitViewControllerForMale", null)
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


			UIRefreshControl fresh = new UIRefreshControl ();
			fresh.ValueChanged += RefreshData;

			this.tableView.AddSubview (fresh);
			LoadTableViewData ();
			btnBack.TouchUpInside += BackToPreView;



			// Perform any additional setup after loading the view, typically from a nib.
		}

		void LoadTableViewData ()
		{
			try {
				var datas = AppDelegate.web.GetAllRecruits ();
				this.tableView.Source = new AllRecruitTableViewDataSource (datas.ToList (), this);
				this.tableView.ReloadData ();
			} catch (Exception ex) {
				UIAlertView alert = new UIAlertView ();
				alert.Title = "Error";
				alert.Message = ex.Message;
				alert.AddButton ("OK");
				alert.Show ();
			}
		}

		void RefreshData (object sender, EventArgs e)
		{
			LoadTableViewData ();
			UIRefreshControl f = sender as UIRefreshControl;
			if (f != null) {
				f.EndRefreshing ();
			}
		}

		void BackToPreView (object sender, EventArgs e)
		{
			this.DismissViewController (true, null);
		}
	}
}

