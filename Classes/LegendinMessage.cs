using System;

namespace iYao
{
	public enum MessageType
	{
		Connection,
		Normal,
		ToUser,
		UnConnection,
		Apply
	}

	public class LegendinBaseMessage
	{
		public MessageType messageType { get; set; }

		public string messageID { get; set; }

		public string messageBody { get; set; }

		public string fromUserID { get; set; }

		public string toUserID { get; set; }

		public DateTime SendTime { get; set; }
		public string RecruitID { get; set; }
	}

}

