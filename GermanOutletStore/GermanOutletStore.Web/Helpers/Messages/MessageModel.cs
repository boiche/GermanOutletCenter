using System;

namespace GermanOutletStore.Web.Helpers.Messages
{
    [Serializable]
    public class MessageModel
    {
        public MessageType Type { get; set; }
        public string Message { get; set; }
    }
}
