using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using iYao.iYaoWebService;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace iYao
{
	public class MyRecruitedTableViewCell:UITableViewCell
	{
		public	UILabel lblToDo;
		public		UILabel lblTime;

		public MyRecruitedTableViewCell (UITableViewCellStyle style, string reuseIdentifier) : base (style, (reuseIdentifier != null) ? new NSString (reuseIdentifier) : null)
		{
			lblToDo = new UILabel ();
			lblTime = new UILabel ();
			lblToDo.Frame = new RectangleF (20, 20, 280, 30);
			lblTime.Frame = new RectangleF (20, 50, 280, 30);
			lblToDo.BackgroundColor = UIColor.Clear;
			lblTime.BackgroundColor = UIColor.Clear;
			lblToDo.TextColor = UIColor.White;
			lblTime.TextColor = UIColor.White;

			AddSubview (lblTime);
			AddSubview (lblToDo);
			BackgroundColor = UIColor.FromRGB (117, 16, 50);
			this.SelectionStyle = UITableViewCellSelectionStyle.None;

		}
	}

	public class MyRecruitedTableViewSource:UITableViewSource
	{
		UIViewController viewController;
		List<Recruit> rows;

		public MyRecruitedTableViewSource (UIViewController vc, List<Recruit>  datas)
		{
			rows = datas;
			viewController = vc;
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 100;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
		
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return rows.Count;
		}

		readonly string normalIden = "normalIden";
		readonly string buttomIden = "buttomIden";

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{

			MyRecruitedTableViewCell cell = null;
		
			cell = tableView.DequeueReusableCell (normalIden) as MyRecruitedTableViewCell;
			if (cell == null) {
				cell = new MyRecruitedTableViewCell (UITableViewCellStyle.Subtitle, normalIden);
			}
			cell.lblToDo.Text = "招募进行中：" + rows [indexPath.Row].Description;
			cell.lblTime.Text = "剩余时间" + Common.GetTimeSpan (rows [indexPath.Row].PublishTime, rows [indexPath.Row].EffectiveTime);
	
			return cell;
		}
	}

	public partial class MyRecruitedViewController : UIViewController
	{
		public MyRecruitedViewController () : base ("MyRecruitedViewController", null)
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
			btnBack.TouchUpInside += delegate(object sender, EventArgs e) {
				this.DismissViewController (true, null);
			};
		}

		Task LoadDataTask;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			tableView.Frame = new RectangleF (tableView.Frame.X, tableView.Frame.Y, tableView.Frame.Width, tableView.Frame.Height - 60);

			UIButton btnRecruit = UIButton.FromType (UIButtonType.Custom);
			btnRecruit.Frame = new RectangleF (0, tableView.Frame.Y + tableView.Frame.Height, 320, 60);
			btnRecruit.BackgroundColor = UIColor.FromRGB (62, 26, 34);
			btnRecruit.SetTitle ("招募英雄", UIControlState.Normal);
			btnRecruit.TouchUpInside += GotoRecruit;
			this.View.AddSubview (btnRecruit);
			//set navigationbar


			if (AppDelegate.currentUser.gender == "m") {
				navBar.TintColor = UIColor.FromRGB (48, 48, 48);
				navBar.BarTintColor = UIColor.FromRGB (48, 48, 48);
				navBar.BackgroundColor = UIColor.FromRGB (48, 48, 48);
			} else {
				navBar.TintColor = UIColor.FromRGB (62, 26, 34);
				navBar.BarTintColor = UIColor.FromRGB (62, 26, 34);
				navBar.BackgroundColor = UIColor.FromRGB (62, 26, 34);
			}
			LoadBackButton ();
			tableView.BackgroundColor = UIColor.FromRGB (117, 16, 50);
//			tableView.Source = new MyRecruitedTableViewSource (this, new List<Recruit> ());
			LoadDataTask = Task.Factory.StartNew (() => {
			});

			LoadDataTask = LoadDataTask.ContinueWith (prevTask => {
				try {
					myRecruit = AppDelegate.web.GetMyRecruits (Common.GetUserFromLocalUser (AppDelegate.currentUser));
				} catch (Exception ex) {
					Console.WriteLine (ex.ToString ());
				} finally {
				}
			});

			LoadDataTask = LoadDataTask.ContinueWith (t => {
				if (myRecruit != null) {
					tableView.Source = new MyRecruitedTableViewSource (this, myRecruit.ToList ());
					tableView.ReloadData ();
				}
			}, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.FromCurrentSynchronizationContext ());

//			tableView.Source = new MyRecruitedTableViewSource (this,null);
			// Perform any additional setup after loading the view, typically from a nib.
		}

		Recruit[] myRecruit = null;

		void GotoRecruit (object sender, EventArgs e)
		{
			if (myRecruit != null && myRecruit.Count() >= 3) {
			
			} else {
				RecruitHeroViewController rh = new RecruitHeroViewController ();
				this.PresentViewController (rh, true, null);
			}
		}
	}
}

