using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using iYao.iYaoWebService;
using SDWebImage;
using MonoTouch.Foundation;

namespace iYao
{
	public class AllRecruitTableViewDataSource:UITableViewSource
	{
		UIViewController viewC;

		public AllRecruitTableViewDataSource (List<Recruit> datas, UIViewController vc)
		{
			rows = datas;
			viewC = vc;
		}

		List<Recruit> rows;

		public override int RowsInSection (UITableView tableview, int section)
		{

			return rows.Count;
		}

		readonly string ident = "cellident";

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (ident);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, ident);
			}
			cell.TextLabel.Text = rows [indexPath.Row].Description + "剩余时间" + (DateTime.Now.Hour - rows [indexPath.Row].PublishTime.Hour - rows [indexPath.Row].EffectiveTime).ToString ();
			;
			if (rows [indexPath.Row].Target != null) {
				cell.DetailTextLabel.Text = rows [indexPath.Row].Target.RecruitTargetDisplayName;
			}
			cell.ImageView.SetImage (new NSUrl (rows [indexPath.Row].PublishUser.profile_image_url));
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			RecruitDetailViewController vc = new RecruitDetailViewController ();
			vc.recruit = rows [indexPath.Row];
			viewC.PresentViewController (vc, true, null);
		}
	}
}

