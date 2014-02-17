using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using SDWebImage;
using System.Linq;
using MonoTouch.Foundation;
using System.IO;
using System.Drawing;

namespace iYao
{
	public class MessageTableViewSource:UITableViewSource
	{
		UIViewController viewController;

		public MessageTableViewSource (List<LocalMessage> datas, UIViewController vc)
		{
			viewController = vc;
			messageList = datas;

		}

		public override float GetHeightForRow (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = GetCell (tableView, indexPath) as LegendinMessageCell; 
			var size = LegendinMessageCell.GetSizeForText (cell, cell.label.Text) + LegendinMessageCell.LegendinMessagePadding;
			return size.Height + 20;
		}

		public	List<LocalMessage> messageList;

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var msg = messageList [indexPath.Row];
			LegendinMessageCell cell = null;
			if (msg.fromUserID == AppDelegate.currentUser.idstr) {
				cell = tableView.DequeueReusableCell (LegendinMessageCell.KeyRight) as LegendinMessageCell;
				if (cell == null) {
					cell = new LegendinMessageCell (false, viewController);
					cell.userImageView.SetImage (new NSUrl (AppDelegate.currentUser.profile_image_url));
				}
				cell.lblName.Text = AppDelegate.currentUser.name;
				cell.uID = messageList [indexPath.Row].fromUserID;
				cell.Update (msg.messageBody);
			} else {
				cell = tableView.DequeueReusableCell (LegendinMessageCell.KeyLeft) as LegendinMessageCell;
				if (cell == null) {
					cell = new LegendinMessageCell (true, viewController);
					Contacts c = AppDelegate.db.QueryAsync<Contacts > ("SELECT * FROM Contacts WHERE (id=?)", messageList [indexPath.Row].fromUserID).Result.FirstOrDefault ();
					if (c != null)
						cell.userImageView.SetImage (new NSUrl (c.profile_image_url));
					cell.lblName.Text = c.name;
//							cell.userImageView.SetImage (c.profile_image_url);
				}
				cell.uID = messageList [indexPath.Row].fromUserID;
				cell.Update (msg.messageBody);
			}
			return cell;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return messageList.Count;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{

		}
	}
}

