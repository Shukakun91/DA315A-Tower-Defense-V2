using System;
using System.Collections.Generic;

namespace DA315A_Tower_Defense_V2
{
    public static class MessageBus
    {
        static Dictionary<string, List<Action<GameMessage>>> listenerDict =
           new Dictionary<string, List<Action<GameMessage>>>();

        static Queue<GameMessage> queue = new Queue<GameMessage>();

        public static void Subscribe(string messageType, Action<GameMessage> handler)
        {
            if (!listenerDict.ContainsKey(messageType))
            {
                listenerDict[messageType] = new List<Action<GameMessage>>();
            }

            listenerDict[messageType].Add(handler);
        }

        public static void Unsubscribe(string messageType, Action<GameMessage> handler)
        {
            if (listenerDict.TryGetValue(messageType, out List<Action<GameMessage>> handlerList))
            {
                handlerList.Remove(handler);

                if (handlerList.Count == 0)
                {
                    listenerDict.Remove(messageType);
                }
            }
        }

        public static void Publish(GameMessage msg)
        {
            if (msg == null) return;
            queue.Enqueue(msg);
        }

        public static void Dispatch()
        {
            while (queue.Count > 0)
            {
                GameMessage msg = queue.Dequeue();

                if (listenerDict.TryGetValue(msg.Type, out List<Action<GameMessage>> handlerList))
                {
                    var handlerCopy = new List<Action<GameMessage>>(handlerList);

                    for (int i = 0; i < handlerCopy.Count; i++)
                    {
                        handlerCopy[i].Invoke(msg);
                    }
                }
            }
        }
    }
}