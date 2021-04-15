using Grpc.Core;
using UnityEngine;
using Proto.Messages;
using Proto.Services;

public class HelloMessageSender : MonoBehaviour
{
    public string RemoteURL;
    public TMPro.TMP_Text TargetText;
    private string _receivedMessage = null;
    public string Message;

    void Update()
    {
        if (_receivedMessage != null)
        {
            TargetText.text = _receivedMessage;
            _receivedMessage = null;
        }
    }

    public void SendMessage()
    {
        var channel = new Channel(RemoteURL, ChannelCredentials.Insecure);
        var client = new HelloService.HelloServiceClient(channel);
        var message = new HelloMessage { Message = Message };
        Debug.Log($"Sending message '{Message}' to {RemoteURL}");
        var answer = client.SayHello(message);
        _receivedMessage = answer.Message;
    }
}
