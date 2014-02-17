using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using iYao.iYaoWebService;
using SDWebImage;
using MonoTouch.Foundation;
using System.Drawing;
using System.Linq;

namespace iYao
{
	public class  RecommandMessageTableViewCell:UITableViewCell
	{
		public	UIImageView userImageView;
		public	UILabel lblName;
		public	UILabel lblLastMessage;
		public	UILabel lblLastTime;

		public RecommandMessageTableViewCell (UITableViewCellStyle style, string reuseIdentifier) : base (style, (reuseIdentifier != null) ? new NSString (reuseIdentifier) : null)
		{
			//创建圆形用户头像
			userImageView = new UIImageView ();
			userImageView.Frame = new RectangleF (10, 10, 44, 44); 
			userImageView.Layer.MasksToBounds = true;
			userImageView.Layer.CornerRadius = userImageView.Frame.Width / 2;
			//创建用户昵称控件
			lblName = new UILabel ();
			lblName.Frame = new RectangleF (64, 10, 200, 20);
			lblName.TextColor = UIColor.Black;
			//创建最后一条消息文本控件
			lblLastMessage = new UILabel ();
			lblLastMessage.Frame = new RectangleF (64, 30, 200, 30);
			lblLastMessage.TextColor = UIColor.Black;
			//创建时间控件
			lblLastTime = new UILabel ();
			lblLastTime.Frame = new RectangleF (264, 15, 36, 30);
			lblLastTime.TextColor = UIColor.Black;

			this.ContentView.AddSubview (userImageView);
			this.ContentView.AddSubview (lblName);
			this.ContentView.AddSubview (lblLastTime);
			this.ContentView.AddSubview (lblLastMessage);
		}
	}

	public class RecommandMessageTableViewSource:UITableViewSource
	{
		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 64;
		}

		List<Contacts> contanctList;
		UIViewController viewC;

		public RecommandMessageTableViewSource (List<Contacts> datas, UIViewController vc)
		{
			contanctList = datas;

			viewC = vc;

		}

		string cellID = "cellID";

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{

			RecommandMessageTableViewCell cell;
			cell = tableView.DequeueReusableCell (cellID) as RecommandMessageTableViewCell;
			if (cell == null) {
				cell = new RecommandMessageTableViewCell (UITableViewCellStyle.Subtitle, cellID);
			}
			cell.userImageView.SetImage (new NSUrl (contanctList [indexPath.Row].profile_image_url));
			cell.lblName.Text = contanctList [indexPath.Row].name;
			cell.lblLastTime.Text = DateTime.Now.ToShortTimeString ();
			cell.lblLastMessage.Text = "lblLastMessage";

			return cell;

		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return contanctList.Count;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, false);
			Contacts lu = AppDelegate.db.QueryAsync<Contacts> ("SELECT * FROM Contacts WHERE (id=?)", contanctList [indexPath.Row].id).Result.FirstOrDefault ();
			if (lu == null) {
				lu = Common.GetContactsFromUsers(  AppDelegate.web.GetUserInfoByID (contanctList [indexPath.Row].id.ToString()));
				if (lu != null) {
					AppDelegate.db.InsertAsync (lu);
				}
			}
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
				viewC.PresentViewController (mvc, true, null); 
			}
		}
	}
}

