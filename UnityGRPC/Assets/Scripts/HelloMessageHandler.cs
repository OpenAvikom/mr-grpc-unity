using UnityEngine;
using Grpc.Core;
using Proto.Services;
using Proto.Messages;
using System.Threading.Tasks;

public class HelloMessageHandler : MonoBehaviour
{
    public int ServerPort;
    public TMPro.TMP_Text TargetText;
    private string _receivedMessage = null;

    private Server _grpcServer;

    void OnEnable()
    {
        _grpcServer = new Server
        {
            Ports = { new ServerPort("0.0.0.0", ServerPort, ServerCredentials.Insecure) }
        };
        _grpcServer.Services.Add(HelloService.BindService(new HelloServiceImpl(this)));
        _grpcServer.Start();
        Debug.Log($"GRPC Server running on port {ServerPort}");
    }

    void OnDisable()
    {
        _grpcServer.ShutdownAsync().Wait();
    }

    void Update()
    {
        if (_receivedMessage != null)
        {
            TargetText.text = _receivedMessage;
            _receivedMessage = null;
        }
    }

    class HelloServiceImpl : HelloService.HelloServiceBase
    {
        private HelloMessageHandler _parent;
        public HelloServiceImpl(HelloMessageHandler parent)
        {
            _parent = parent;
        }
        public override Task<HelloMessage> SayHello(HelloMessage request, ServerCallContext context)
        {
            _parent._receivedMessage = request.Message;
            return Task.FromResult(new HelloMessage { Message = "Thank You!" });
        }
    }
}
