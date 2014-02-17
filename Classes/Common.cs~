using System;
using System.Net;
using iYao.iYaoWebService;
using Newtonsoft.Json;
using StriveEngine;
using StriveEngine.Tcp.Passive;
using StriveEngine.Core;

namespace iYao
{
	public class Common
	{
		public Common ()
		{

		}

		public static ITcpPassiveEngine tcpPassiveEngine;
		public static	MessageViewController MSGViewController;
		public static int toUserMessageCount = 0;
		public static int systemMessageCount = 0;
		public static int recommendMessageCount = 0;

		public static void CloseClient ()
		{
			tcpPassiveEngine.CloseConnection ();
		}

		public static void SendMessage (string MSG)
		{
			string msg = MSG + "\0";// "\0" 表示一个消息的结尾
			byte[] bMsg = System.Text.Encoding.UTF8.GetBytes (msg);//消息使用UTF-8编码
			Common.tcpPassiveEngine.SendMessageToServer (bMsg);
		}

		public static void SendConnectionMessage ()
		{
			LegendinBaseMessage lbm = new LegendinBaseMessage ();
			lbm.fromUserID = AppDelegate.currentUser.idstr;
			lbm.messageBody = "Connection";
			lbm.messageID = Guid.NewGuid ().ToString ();
			lbm.messageType = MessageType.Connection;
			lbm.SendTime = DateTime.Now;
			lbm.toUserID = "Server";

			string MSG = JsonConvert.SerializeObject (lbm);
			string msg = MSG + "\0";// "\0" 表示一个消息的结尾
			byte[] bMsg = System.Text.Encoding.UTF8.GetBytes (msg);//消息使用UTF-8编码
			Common.tcpPassiveEngine.SendMessageToServer (bMsg);
		}

		private static void StartClient ()
		{
			try {
				//初始化并启动客户端引擎（TCP、文本协议）
				tcpPassiveEngine = NetworkEngineFactory.CreateTextTcpPassiveEngine (ServerIPAddress, 9000, new DefaultTextContractHelper ("\0"));
//				tcpPassiveEngine = NetworkEngineFactory.CreateTextTcpPassiveEngine("192.168.199.163", 9000, new DefaultTextContractHelper("\0"));
				tcpPassiveEngine.MessageReceived += new CbDelegate<System.Net.IPEndPoint, byte[]> (AppDelegate.tcpPassiveEngine_MessageReceived);
//				tcpPassiveEngine.MessageReceived+=   delegate(IPEndPoint obj1, byte[] obj2) {
//				
//			};
				tcpPassiveEngine.AutoReconnect = true;//启动掉线自动重连                
				tcpPassiveEngine.ConnectionInterrupted += new CbDelegate (AppDelegate.tcpPassiveEngine_ConnectionInterrupted);
				tcpPassiveEngine.ConnectionRebuildSucceed += new CbDelegate (AppDelegate.tcpPassiveEngine_ConnectionRebuildSucceed);
				tcpPassiveEngine.MessageSent += HandleMessageSent;
				tcpPassiveEngine.Initialize ();

				SendConnectionMessage ();

				Console.WriteLine ("连接成功！");
			} catch (Exception ee) {
				Console.WriteLine (ee.Message);
			}
		}

		static void HandleMessageSent (IPEndPoint obj1, byte[] obj2)
		{
			string msg = System.Text.Encoding.UTF8.GetString (obj2); //消息使用UTF-8编码
			msg = msg.Substring (0, msg.Length - 1); //将结束标记"\0"剔除

			Console.WriteLine ("消息发生成功" + msg);
		}
		//		public static string ServerIPAddress = "192.168.199.241";
		public static string ServerIPAddress = "192.168.199.163";
		public static int ServerPort = 1979;

		public	static	void InitServerConnection ()
		{
//			client	 = new Client ();
//			Common.client.Connections.Clear ();
//			client.StartClient (System.Net.IPAddress.Parse (ServerIPAddress), ServerPort);//启动客户端连接。  
//			LegendinBaseMessage lmsg = new LegendinBaseMessage ();
//			//连接成功之后发送一个连接消息。 
//
//
//			lmsg.fromUserID = AppDelegate.currentUser.id.ToString();
//
//			lmsg.toUserID = "server";
//
//			lmsg.messageBody = "messageBody";
//
//			lmsg.messageType = MessageType.Connection;
//
//			lmsg.SendTime = DateTime.Now;
//
//			string msgBody = JsonConvert.SerializeObject (lmsg);
//
//			Message message = new Message (Message.CommandHeader.SendMessage, 1, 1,msgBody);
//
//			client.messageQueue.Add (message);
//
//			//定义接收消息处理函数
//		
//			client.MessageReceived += AppDelegate.HandleMessageReceived;;
			StartClient ();
		}

		public static double Latitude;
		public static double Longitude;

		public  static Contacts GetContactsFromUsers (Users u)
		{
			if (u == null) {
				return null;
			}
			Contacts c = new Contacts ();
			//			u.gender = luser.gender;
			//			u.id = luser.id;
			//			u.idstr = luser.idstr;
			//			u.name = luser.name;
			//			u.screen_name = luser.screen_name;
			c.age = u.age;
			c.company = u.company;
			c.gender = u.gender;
			c.id = u.id;
			c.idstr = u.idstr;
			c.ImageList = u.ImageList;
			c.location = u.location;
			c.name = u.name;
			c.nickName = u.nickName;
			c.profile_image_url = u.profile_image_url;
			c.school = u.school;
			c.screen_name = u.screen_name;
			c.sign = u.sign;
			c.verified = u.verified;
			c.verified_reason = u.verified_reason;
			c.Latitude = u.Latitude;
			c.LastLoginTime = u.LastLoginTime;
			c.Longitude = u.Longitude;
			return c;
		}

		public static string GetTimeSpan (DateTime  dt)
		{
			DateTime dtNow = DateTime.Now;
			TimeSpan ts = dtNow - dt;
			if (ts.TotalMinutes < 60) {
				return ts.TotalMinutes + "分钟前";
			} else if (ts.TotalMinutes > 60 && ts.TotalMinutes < 1440) {
				return Convert.ToInt32 (ts.TotalMinutes / 60).ToString () + "小时前";
			} else {
				return Convert.ToInt32 (ts.TotalMinutes / 1440).ToString () + "天前";
			}
		}

		public static string GetTimeSpan (DateTime  dtbegin, int EffectiveTime)
		{
			DateTime dtNow = DateTime.Now;
			TimeSpan ts = dtNow - dtbegin;
			var minutes = ts.TotalMinutes;
			minutes = EffectiveTime * 60 - minutes;
			if (minutes < 60) {
				return Convert.ToInt32(minutes) + "分钟";
			} else if (minutes > 60 && minutes < 1440) {
				return Convert.ToInt32 (minutes / 60).ToString () + "小时";
			} else {
				return Convert.ToInt32 (minutes / 1440).ToString () + "天";
			}
		}

		public const double EARTH_RADIUS = 6378.137;

		public static double GetDistance (double beginLat, double beginLng, double endLat, double endLng)
		{    
			double lat = beginLat - endLat;    
			double lng = beginLng - endLng;    

			double dis = 2 * Math.Asin (Math.Sqrt (Math.Pow (Math.Sin (lat / 2), 2) + Math.Cos (beginLat) * Math.Cos (endLat) * Math.Pow (Math.Sin (lng / 2), 2)));    
			dis = dis * EARTH_RADIUS;    
			dis = Math.Round (dis * 1e4) / 1e4;    

			return dis;    
		}

		public static Users GetUserFromLocalUser (LocalUser luser)
		{
			Users u = new Users ();
//			u.gender = luser.gender;
//			u.id = luser.id;
//			u.idstr = luser.idstr;
//			u.name = luser.name;
//			u.screen_name = luser.screen_name;
			u.age = luser.age;
			u.company = luser.company;
			u.gender = luser.gender;
			u.id = luser.id;
			u.idstr = luser.idstr;
			u.ImageList = luser.ImageList;
			u.location = luser.location;
			u.name = luser.name;
			u.nickName = luser.nickName;
			u.profile_image_url = luser.profile_image_url;
			u.school = luser.school;
			u.screen_name = luser.screen_name;
			u.sign = luser.sign;
			u.verified = luser.verified;
			u.verified_reason = luser.verified_reason;
			return u;
		}
	}
}

