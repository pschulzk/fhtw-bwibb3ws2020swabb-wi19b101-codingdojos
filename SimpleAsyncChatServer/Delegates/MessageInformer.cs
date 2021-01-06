using System.Net.Sockets;

namespace SimpleAsyncChatServer.Delegates
{
    public delegate void MessageInformer(Socket caller, string message);
}
