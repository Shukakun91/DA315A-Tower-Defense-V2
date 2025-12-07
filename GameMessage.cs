namespace DA315A_Tower_Defense_V2
{
    public class GameMessage
    {
        public string Type { get; }
        public object Sender {  get; }
        public object Data {  get; }

        public GameMessage(string type)
        {
            Type = type;
            Sender = null;
            Data = null;
        }

        public GameMessage(string type, object sender)
        {
            Type = type;
            Sender = sender;
            Data = null;
        }

        public GameMessage(string type, object sender, object data)
        {
            Type = type;
            Sender = sender;
            Data = data;
        }
    }
}