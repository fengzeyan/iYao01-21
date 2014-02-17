using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using iYao.iYaoWebService;

namespace iYao
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		public	static	UIWindow window;
		LoginViewController viewController;
		SplashScreenViewController splashScreenViewController;
		public static LocalUser currentUser;
		public static iYaoWebService.WebService1 web;
		public static readonly SQLiteAsyncConnection db = new SQLiteAsyncConnection (Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), "iYao.db"));
		public static MainPageViewController MainPage;
		//		public		static void HandleMessageReceived (object sender, SocketBase.MessageEventArgs e)
		//		{
		//			Console.WriteLine (e.Message.MessageBody);
		//
		//			LegendinBaseMessage lmsg = JsonConvert.DeserializeObject<LegendinBaseMessage> (e.Message.MessageBody);
		//			if (lmsg != null) {
		//				if (lmsg.messageType == MessageType.ToUser) {
		//					Common.toUserMessageCount += 1;
		//					//
		//					LocalMessage lm = new LocalMessage ();
		//					lm.MessageID = lmsg.messageID;
		//					lm.fromUserID = lmsg.fromUserID;
		//					lm.messageBody = lmsg.messageBody;
		//					lm.messageType = lmsg.messageType;
		//					lm.toUserID = lmsg.toUserID;
		//					lm.SendTime = lmsg.SendTime;
		//					AppDelegate.db.InsertAsync (lm).ContinueWith (t => {
		//						if (t.Exception != null) {
		//							Console.WriteLine(t.Exception.ToString());
		//						}
		//
		//					});
		//
		//
		//					if (Common.MSGViewController != null) {
		//						Common.MSGViewController.ReLoadMessageData ();
		//					}
		//
		//					//向最近联系人里面添加数据
		//					AppDelegate.db.QueryAsync<LatelyFriendContacts > ("SELECT * FROM LatelyFriendContacts WHERE (id=?)", lmsg.fromUserID)
		//						.ContinueWith (t => {
		//							if (t.Exception != null) {
		//
		//							}
		//							//如果联系人存在
		//							if (t.Result.Count > 0) {
		//								var u = t.Result.FirstOrDefault ();
		//								u.LatelyTime = DateTime.Now;
		//								AppDelegate.db.UpdateAsync (u).ContinueWith (t1 => {
		//									if (t.Exception != null) {
		//										Console.WriteLine ("Fail");
		//									}
		//									if (t1.Result > 0) {
		//										Console.WriteLine ("OK");
		//									} else {
		//										Console.WriteLine ("Fail");
		//									}
		//								});
		//							} else {
		//								//TODO
		//								//如果联系人不存在则从联系人表中搜索出联系人的信息然后新建一个推荐消息联系人的对象插入，如果不存在则向服务器请求联系人数据然后在新建一个推荐消息联系人的对象再插入。
		//								LatelyApplyContacts lac = new LatelyApplyContacts ();
		//								Contacts c=		AppDelegate.db.QueryAsync<Contacts > ("SELECT * FROM Contacts WHERE (id=?)",lmsg.fromUserID).Result.FirstOrDefault();
		//								if(c!=null)
		//								{
		//									lac.LatelyTime = DateTime.Now;
		//									lac.gender=c.gender;
		//									lac.id=c.id;
		//									lac.idstr=c.idstr;
		//									lac.name=c.name;
		//									lac.profile_image_url=c.profile_image_url;
		//									lac.screen_name=c.screen_name;
		//									AppDelegate.db.InsertAsync (lac).ContinueWith (t2 => {
		//
		//									});
		//								}
		////								lac.gender=
		//
		//							}
		//
		//						}, uiScheduler);
		//
		//
		////					Common.toUserMessageCount += 1;
		//				} else if (lmsg.messageType == MessageType.Apply) {
		//					Common.recommendMessageCount += 1;
		//					//向消息表中添加数据
		//
		//					ApplyMessage am = JsonConvert.DeserializeObject<ApplyMessage> (e.Message.MessageBody);
		//					if (am != null) {
		//						LocalMessage lm = new LocalMessage ();
		//						lm.fromUserID = lmsg.fromUserID;
		//						lm.messageBody = lmsg.messageBody;
		//						lm.messageType = lmsg.messageType;
		//						lm.toUserID = lmsg.toUserID;
		//						lm.RecruitID = am.RecruitID;
		//						lm.SendTime = lmsg.SendTime;
		//						AppDelegate.db.InsertAsync (lm);
		//					}
		//					//向推荐消息联系人数据库中添加联系人数据。 如果联系人已存在则修改推荐消息联系人的最后联系时间。
		//					AppDelegate.db.QueryAsync<LatelyApplyContacts > ("SELECT * FROM LatelyApplyContacts WHERE (id=?)", lmsg.fromUserID)
		//						.ContinueWith (t => {
		//						if (t.Exception != null) {
		//
		//						}
		//						//如果联系人存在
		//						if (t.Result.Count > 0) {
		//							var u = t.Result.FirstOrDefault ();
		//							u.LatelyTime = DateTime.Now;
		//							AppDelegate.db.UpdateAsync (u).ContinueWith (t1 => {
		//								if (t.Exception != null) {
		//									Console.WriteLine ("Fail");
		//								}
		//								if (t1.Result > 0) {
		//									Console.WriteLine ("OK");
		//								} else {
		//									Console.WriteLine ("Fail");
		//								}
		//
		//							});
		//						} else {
		//							//TODO
		//							//如果联系人不存在则从联系人表中搜索出联系人的信息然后新建一个推荐消息联系人的对象插入，如果不存在则向服务器请求联系人数据然后在新建一个推荐消息联系人的对象再插入。
		//							LatelyApplyContacts lac = new LatelyApplyContacts ();
		//								Contacts c=		AppDelegate.db.QueryAsync<Contacts > ("SELECT * FROM Contacts WHERE (id=?)",am.fromUserID).Result.FirstOrDefault();
		//								if(c!=null)
		//								{
		//									lac.LatelyTime = DateTime.Now;
		//									lac.gender=c.gender;
		//									lac.id=c.id;
		//									lac.idstr=c.idstr;
		//									lac.name=c.name;
		//									lac.profile_image_url=c.profile_image_url;
		//									lac.screen_name=c.screen_name;
		//									AppDelegate.db.InsertAsync (lac).ContinueWith (t2 => {
		//
		//									});
		//								}
		////								lac.gender=
		//						
		//						}
		//
		//					}, uiScheduler);
		//
		//				} else if (lmsg.messageType == MessageType.Normal) {
		//					Common.systemMessageCount += 1;
		//				}
		//				using (var pool = new NSAutoreleasePool ()) {
		//					if ((mainPageForFemale) != null) {
		//						mainPageForFemale.SetMessageTitle ();
		//					}
		//				}
		//			}
		//
		//
		//		
		////
		////			UIAlertView alert = new UIAlertView ();
		////			alert.Title = "ttt";
		////			alert.AddButton ("OK");
		////			alert.Message = e.Message.MessageBody;
		////			alert.Show ();
		//
		//		
		//
		//
		//
		//		
		//		}



		public static	void tcpPassiveEngine_ConnectionInterrupted ()
		{
//			if (this.InvokeRequired)
//			{
//				this.BeginInvoke(new CbDelegate(this.tcpPassiveEngine_ConnectionInterrupted));
//			}
//			else
//			{
//				this.button2.Enabled = false;
//				MessageBox.Show("您已经掉线。");
//			}
			Console.WriteLine ("您已经掉线");

		}

		public 	static void InfoChange (string info)
		{
			Console.WriteLine ("收到信息：{0}", info);
		}

		public static	void tcpPassiveEngine_ConnectionRebuildSucceed ()
		{
//			if (this.InvokeRequired)
//			{
//				this.BeginInvoke(new CbDelegate(this.tcpPassiveEngine_ConnectionInterrupted));
//			}
//			else
//			{
//				this.button2.Enabled = true;
//				MessageBox.Show("重连成功。");
//			}

			Common.SendConnectionMessage ();
			Console.WriteLine ("重连成功");
		}

		public static UIViewController TopMostViewController ()
		{
			UIViewController topController = UIApplication.SharedApplication.KeyWindow.RootViewController;
			while (topController.PresentedViewController != null) {
				topController = topController.PresentedViewController;
			}

			return topController;
		}
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		private static readonly TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext ();

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			web = new iYao.iYaoWebService.WebService1 ();
			UITextAttributes att = new UITextAttributes () { 
				TextColor = UIColor.White
			};
			UINavigationBar.Appearance.SetTitleTextAttributes (att);
			Console.WriteLine (Environment.GetFolderPath (Environment.SpecialFolder.Personal));
			db.CreateTableAsync<LocalUser> ().Wait ();
			db.CreateTableAsync<LocalMessage> ().Wait ();
			db.CreateTableAsync<Contacts> ().Wait ();
			db.CreateTableAsync<Friends> ().Wait ();
			db.CreateTableAsync<Stranger> ().Wait ();


			window = new UIWindow (UIScreen.MainScreen.Bounds);
			splashScreenViewController = new   SplashScreenViewController ();
			window.RootViewController = splashScreenViewController;
//			viewController = new LoginViewController ();
//			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();
		
		

			return true;
		}
		//		public	static void HandleMessageReceived (System.Net.IPEndPoint obj1, byte[] obj2)
		//		{
		//
		//		}
		static	Task LoadDataTask = Task.Factory.StartNew (() => {
		});

		public static void GetContactInfoFromWebServiceAndInsertToDB (string uid)
		{


			Users u = null;
			LoadDataTask = LoadDataTask.ContinueWith (prevTask => {
				try {
					u =	AppDelegate.web.GetUserInfoByID (uid);
					if (u != null) {
						Contacts c = Common.GetContactsFromUsers (u);
						if (c != null) {
							AppDelegate.db.InsertAsync (c);
						}
					}
				} catch (Exception ex) {
					Console.WriteLine ("ERROR" + ex.ToString ());
				} finally {
				}
			});
		}

		public static 	void tcpPassiveEngine_MessageReceived (System.Net.IPEndPoint serverIPE, byte[] bMsg)
		{
			string msg = System.Text.Encoding.UTF8.GetString (bMsg); //消息使用UTF-8编码
			msg = msg.Substring (0, msg.Length - 1); //将结束标记"\0"剔除
			LegendinBaseMessage lmsg = JsonConvert.DeserializeObject<LegendinBaseMessage> (msg);
			//向消息数据库中插入消息
			LocalMessage lm = new LocalMessage ();
			lm.MessageID = lmsg.messageID;
			lm.fromUserID = lmsg.fromUserID;
			lm.messageBody = lmsg.messageBody;
			lm.messageType = lmsg.messageType;
			lm.toUserID = lmsg.toUserID;
			lm.SendTime = lmsg.SendTime;
			AppDelegate.db.InsertAsync (lm).ContinueWith (t => {
				if (t.Exception != null) {
					Console.WriteLine (t.Exception.ToString ());
				}
			});
			//判断是否用户好友
			Friends f = AppDelegate.db.QueryAsync<Friends > ("SELECT * FROM Friends WHERE (id=?)", lmsg.fromUserID).Result.FirstOrDefault ();
			//如果是用户好友，则归类到好友消息
			if (f != null) {
				//更新好友数据库好友的最后联系时间
				f.LatelyMessageTime = DateTime.Now;
				db.UpdateAsync (f);
			}
			//如果不是用户好友则归类到推荐消息
			else {
				//如果陌生人存在联系人表则修改最后联系时间，如果不存在则向服务器请求陌生人信息然后插入到Contacts表

				Stranger s = AppDelegate.db.QueryAsync<Stranger > ("SELECT * FROM Stranger WHERE (id=?)", lmsg.fromUserID).Result.FirstOrDefault ();
				if (s != null) {
					s.LatelyMessageTime = DateTime.Now;
					db.UpdateAsync (s);
				} else {
					s = new Stranger ();
					s.id =Convert.ToInt32( lmsg.fromUserID);
					s.LatelyMessageTime = DateTime.Now;
					db.InsertAsync (s);
				}
				InsertContactInfo (lmsg.fromUserID.ToString());
			}
			//	如果用户当前停留在消息页面则刷新当前页面的数据
			if (Common.MSGViewController != null && Common.MSGViewController.fromUser.idstr == lmsg.fromUserID) {
				Common.MSGViewController.ReLoadMessageData ();
			}
		}

		static void InsertContactInfo(string id)
		{
			Contacts c=AppDelegate.db.QueryAsync<Contacts > ("SELECT * FROM Contacts WHERE (id=?)", id).Result.FirstOrDefault ();
			if (c == null) {
				try
				{
					var c1=AppDelegate.web.GetUserInfoByID (id);
					c=Common.GetContactsFromUsers(c1	);
				}
				catch(Exception ex) {
					Console.WriteLine (ex.ToString());
				}
				if (c != null) {
					AppDelegate.db.InsertAsync (c).ContinueWith (t2 => {
						if (t2.Exception != null) {
							Console.WriteLine (t2.Exception.InnerException.ToString ());
						}
					});
				} else {
					InsertContactInfo (id);
				}
			}
		}


//		public static 	void tcpPassiveEngine_MessageReceived_old (System.Net.IPEndPoint serverIPE, byte[] bMsg)
//		public	static void HandleMessageReceived (System.Net.IPEndPoint obj1, byte[] obj2)
//		{
//			string msg = System.Text.Encoding.UTF8.GetString (bMsg); //消息使用UTF-8编码
//			msg = msg.Substring (0, msg.Length - 1); //将结束标记"\0"剔除
//			ShowMessage (msg);
//
//			LegendinBaseMessage lmsg = JsonConvert.DeserializeObject<LegendinBaseMessage> (msg);
//			if (lmsg != null) {
//				if (lmsg.messageType == MessageType.Apply || lmsg.messageType == MessageType.ToUser) {
//					Contacts c = AppDelegate.db.QueryAsync<Contacts > ("SELECT * FROM Contacts WHERE (id=?)", lmsg.toUserID).Result.FirstOrDefault ();
//					if (c == null) {
//						GetContactInfoFromWebServiceAndInsertToDB (lmsg.toUserID);
//					}
//				}
//				if (lmsg.messageType == MessageType.ToUser) {
//					Common.toUserMessageCount += 1;
//					//
//					LocalMessage lm = new LocalMessage ();
//					lm.MessageID = lmsg.messageID;
//					lm.fromUserID = lmsg.fromUserID;
//					lm.messageBody = lmsg.messageBody;
//					lm.messageType = lmsg.messageType;
//					lm.toUserID = lmsg.toUserID;
//					lm.SendTime = lmsg.SendTime;
//					AppDelegate.db.InsertAsync (lm).ContinueWith (t => {
//						if (t.Exception != null) {
//							Console.WriteLine (t.Exception.ToString ());
//						}
//
//					});
//
//
//
//					if (Common.MSGViewController != null && Common.MSGViewController.fromUser.idstr == lmsg.fromUserID) {
//						Common.MSGViewController.ReLoadMessageData ();
//					}
//
//					//向最近联系人里面添加数据
//					AppDelegate.db.QueryAsync<LatelyFriendContacts > ("SELECT * FROM LatelyFriendContacts WHERE (id=?)", lmsg.fromUserID)
//						.ContinueWith (t => {
//						if (t.Exception != null) {
//
//						}
//						//如果联系人存在
//						if (t.Result.Count > 0) {
//							var u = t.Result.FirstOrDefault ();
//							u.LatelyTime = DateTime.Now;
//							AppDelegate.db.UpdateAsync (u).ContinueWith (t1 => {
//								if (t.Exception != null) {
//									Console.WriteLine ("Fail");
//								}
//								if (t1.Result > 0) {
//									Console.WriteLine ("OK");
//								} else {
//									Console.WriteLine ("Fail");
//								}
//							});
//						} else {
//							//TODO
//							//如果联系人不存在则从联系人表中搜索出联系人的信息然后新建一个推荐消息联系人的对象插入，如果不存在则向服务器请求联系人数据然后在新建一个推荐消息联系人的对象再插入。
//							LatelyApplyContacts lac = new LatelyApplyContacts ();
//							Contacts c = AppDelegate.db.QueryAsync<Contacts > ("SELECT * FROM Contacts WHERE (id=?)", lmsg.fromUserID).Result.FirstOrDefault ();
//							if (c != null) {
//								lac.LatelyTime = DateTime.Now;
//								lac.id = c.id;
//								AppDelegate.db.InsertAsync (lac).ContinueWith (t2 => {
//
//								});
//							}
////								lac.gender=
//
//						}
//
//					}, uiScheduler);
//
//
////					Common.toUserMessageCount += 1;
//				} else if (lmsg.messageType == MessageType.Apply) {
//					Common.recommendMessageCount += 1;
//					//向消息表中添加数据
//
//					LocalMessage lm = new LocalMessage ();
//					lm.fromUserID = lmsg.fromUserID;
//					lm.messageBody = lmsg.messageBody;
//					lm.messageType = lmsg.messageType;
//					lm.toUserID = lmsg.toUserID;
//					lm.RecruitID = lmsg.RecruitID;
//					lm.SendTime = lmsg.SendTime;
//					AppDelegate.db.InsertAsync (lm);
//					//向推荐消息联系人数据库中添加联系人数据。 如果联系人已存在则修改推荐消息联系人的最后联系时间。
//					AppDelegate.db.QueryAsync<LatelyApplyContacts > ("SELECT * FROM LatelyApplyContacts WHERE (id=?)", lmsg.fromUserID)
//						.ContinueWith (t => {
//						if (t.Exception != null) {
//
//						}
//						//如果联系人存在
//						if (t.Result.Count > 0) {
//							var u = t.Result.FirstOrDefault ();
//							u.LatelyTime = DateTime.Now;
//							AppDelegate.db.UpdateAsync (u).ContinueWith (t1 => {
//								if (t.Exception != null) {
//									Console.WriteLine ("Fail");
//								}
//								if (t1.Result > 0) {
//									Console.WriteLine ("OK");
//								} else {
//									Console.WriteLine ("Fail");
//								}
//
//							});
//						} else {
//							//TODO
//							//如果联系人不存在则从联系人表中搜索出联系人的信息然后新建一个推荐消息联系人的对象插入，如果不存在则向服务器请求联系人数据然后在新建一个推荐消息联系人的对象再插入。
//							LatelyApplyContacts lac = new LatelyApplyContacts ();
//							Contacts c = AppDelegate.db.QueryAsync<Contacts > ("SELECT * FROM Contacts WHERE (id=?)", lmsg.fromUserID).Result.FirstOrDefault ();
//							if (c != null) {
//								lac.LatelyTime = DateTime.Now;
//								lac.id = c.id;
//								AppDelegate.db.InsertAsync (lac).ContinueWith (t2 => {
//
//								});
//							} else {
//								c = Common.GetContactsFromUsers (AppDelegate.web.GetUserInfoByID (lmsg.fromUserID));
//								if (c != null) {
//									AppDelegate.db.InsertAsync (c).ContinueWith (t2 => {
//
//									});
//									lac.LatelyTime = DateTime.Now;
//									lac.id = c.id;
//									AppDelegate.db.InsertAsync (lac).ContinueWith (t2 => {
//
//									});
//								}
//							}
////								lac.gender=
//
//						}
//
//					}, uiScheduler);
//
//				} else if (lmsg.messageType == MessageType.Normal) {
//					Common.systemMessageCount += 1;
//				}
//				using (var pool = new NSAutoreleasePool ()) {
//					if ((MainPage) != null) {
//						MainPage.SetMessageTitle ();
//					}
//				}
//			}
//		}

		private static void ShowMessage (string msg)
		{
			Console.WriteLine ("MSG" + msg);
		}

		public override void WillTerminate (UIApplication application)
		{
//			Common.CloseClient ();
		}

		public override void WillEnterForeground (UIApplication application)
		{
//			Common.InitServerConnection ();

		}

		public override void DidEnterBackground (UIApplication application)
		{
//			Common.CloseClient ();
		}
	}
}

