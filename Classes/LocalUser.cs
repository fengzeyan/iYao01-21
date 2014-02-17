using System;
using System.Collections.Generic;
using SQLite;

namespace iYao
{
	public class PicUrl
	{
		public string thumbnail_pic { get; set; }
	}

	public class Visible
	{
		public int type { get; set; }

		public int list_id { get; set; }
	}

	public class Status
	{
		public string created_at { get; set; }

		public long id { get; set; }

		public string mid { get; set; }

		public string idstr { get; set; }

		public string text { get; set; }

		public string source { get; set; }

		public bool favorited { get; set; }

		public bool truncated { get; set; }

		public string in_reply_to_status_id { get; set; }

		public string in_reply_to_user_id { get; set; }

		public string in_reply_to_screen_name { get; set; }

		public List<PicUrl> pic_urls { get; set; }

		public string thumbnail_pic { get; set; }

		public string bmiddle_pic { get; set; }

		public string original_pic { get; set; }

		public object geo { get; set; }

		public int reposts_count { get; set; }

		public int comments_count { get; set; }

		public int attitudes_count { get; set; }

		public int mlevel { get; set; }

		public Visible visible { get; set; }
	}

	public class LocalUser
	{
		[PrimaryKey]
		public long id { get; set; }

		public string idstr { get; set; }

		public string screen_name { get; set; }

		public string name { get; set; }

		public string profile_image_url { get; set; }

		public string gender { get; set; }

		public bool verified{ get; set;}
		public string  verified_reason { get; set;}
		public string  nickName { get; set;}
		public string  location { get; set;}
		public string  company { get; set;}
		public string  school { get; set;}
		public string  age { get; set;}
		public string  sign { get; set;}
		public string  ImageList { get; set;}
	}

	public class Friends
	{
		[PrimaryKey]
		public long id { get; set; }
		public DateTime LatelyMessageTime{ get; set; }
	}

	public class Stranger
	{
		[PrimaryKey]
		public long id { get; set; }
		public DateTime LatelyMessageTime{ get; set; }
	}



	public class Contacts
	{
		[PrimaryKey]
		public long id { get; set; }

		public string idstr { get; set; }

		public string screen_name { get; set; }

		public string name { get; set; }

		public string profile_image_url { get; set; }

		public string gender { get; set; }
		public bool verified{ get; set;}
		public string  verified_reason { get; set;}
		public string  nickName { get; set;}
		public string  location { get; set;}
		public string  company { get; set;}
		public string  school { get; set;}
		public string  age { get; set;}
		public string  sign { get; set;}
		public string  ImageList { get; set;}
		public DateTime LatelyMessageTime{ get; set; }
		public DateTime LastLoginTime{ get; set;}
		public double Latitude{ get; set;}
		public double Longitude{ get; set;}

	}




	public class LocalMessage
	{
		[PrimaryKey]
		public string MessageID{ get; set; }

		public DateTime SendTime{ get; set;}

		public MessageType messageType{ get; set; }

		public string messageBody{ get; set; }

		public string fromUserID{ get; set; }

		public string toUserID{ get; set; }
		public string RecruitID{ get; set; }
	}





}

