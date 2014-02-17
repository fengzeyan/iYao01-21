using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using SDWebImage;
using iYao.iYaoWebService;
using System.Linq;

namespace iYao
{
	public class NormalMessageTableViewSource:UITableViewSource
	{
		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 64;
		}

		UIViewController vc;
		List<Contacts> contactsList;

		public NormalMessageTableViewSource (List<Contacts> datas, UIViewController vC)
		{
			contactsList = datas;
			vc = vC;


		}

		string cellID = "cellID";

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{

			RecommandMessageTableViewCell cell;
			cell = tableView.DequeueReusableCell (cellID) as RecommandMessageTableViewCell;
			if (cell == null) {
				cell = new RecommandMessageTableViewCell (UITableViewCellStyle.Subtitle, cellID);
			}
			cell.userImageView.SetImage (new NSUrl (contactsList [indexPath.Row].profile_image_url));
			cell.lblName.Text = contactsList [indexPath.Row].name;
			cell.lblLastTime.Text = DateTime.Now.ToShortTimeString ();
			cell.lblLastMessage.Text = "lblLastMessage";

			return cell;

		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, false);
			Contacts lu = AppDelegate.db.QueryAsync<Contacts> ("SELECT * FROM Contacts WHERE (id=?)", contactsList [indexPath.Row].id).Result.FirstOrDefault ();
			if (lu != null) {
				MessageViewController mvc = new MessageViewController ();
				Users u = new  Users ();
				u.gender = lu.gender;
				u.id = lu.id;
				u.idstr = lu.idstr;
				u.name = lu.name;
				u.profile_image_url = lu.profile_image_url;
				u.screen_name = lu.screen_name;
				mvc.fromUser = Common.GetUserFromLocalUser (AppDelegate.currentUser);
				mvc.toUser = u;
				vc.PresentViewController (mvc, true, null); 
			}
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return contactsList.Count;
		}
	}
}

