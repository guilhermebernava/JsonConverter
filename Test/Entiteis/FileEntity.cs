namespace JsonConverter.Entiteis
{
    public class Channel
    {
        public string id { get; set; }
        public int type { get; set; }
        public string description { get; set; }
        public string identifier { get; set; }
    }

    public class DataMedia
    {
        public string urlFile { get; set; }
        public object caption { get; set; }
        public string mimetype { get; set; }
        public string type { get; set; }
        public string filename { get; set; }
        public bool isGif { get; set; }
        public string duration { get; set; }
        public object base64Thumb { get; set; }
    }


    public class Contact
    {
        public string id { get; set; }
        public string name { get; set; }
        public string secondaryName { get; set; }
        public string number { get; set; }
        public string linkImage { get; set; }
        public bool isMe { get; set; }
        public List<object> tags { get; set; }
    }

    public class CurrentSector
    {
        public string id { get; set; }
        public string description { get; set; }
    }

    public class CurrentUser
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class FinalizadoPor
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class LastMessage
    {
        public string id { get; set; }
        public string text { get; set; }
        public object sender { get; set; }
        public DateTime? utcDhMessage { get; set; }
        public int? utcDhMessageUnixTime { get; set; }
        public bool isPrivate { get; set; }
    }

    public class Message
    {
        public string IdMessage { get; set; }
        public string senderName { get; set; }
        public DateTime? dhMessage { get; set; }
        public int? unixTimeMessage { get; set; }
        public string text { get; set; }
        public bool isSentByMe { get; set; }
        public bool isDeleted { get; set; }
        public bool isForwarded { get; set; }
        public bool isReply { get; set; }
        public bool isMMS { get; set; }
        public bool isPrivate { get; set; }
        public int? origen { get; set; }
        public int? typeMessage { get; set; }
        public int? statusMessage { get; set; }
        public DataMedia dataMedia { get; set; }
        public object dataLocation { get; set; }
        public List<object> dataVcard { get; set; }
    }

    public class FileEntity
    {
        public string attendanceId { get; set; }
        public string protocol { get; set; }
        public int status { get; set; }
        public int type { get; set; }
        public string description { get; set; }
        public string secondaryDescription { get; set; }
        public string linkImage { get; set; }
        public int countUnreadMessages { get; set; }
        public bool hasTag { get; set; }
        public object lastSeen { get; set; }
        public DateTime? utcDhStartChat { get; set; }
        public DateTime? utcDhEndChat { get; set; }
        public Contact contact { get; set; }
        public Channel channel { get; set; }
        public LastMessage lastMessage { get; set; }
        public CurrentSector? currentSector { get; set; }
        public CurrentUser? currentUser { get; set; }
        public FinalizadoPor finalizadoPor { get; set; }
        public List<Message> messages { get; set; }

    }


}
