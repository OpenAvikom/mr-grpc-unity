// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: hello_service.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Proto.Services {
  /// <summary>
  ///*
  /// 
  /// </summary>
  public static partial class HelloService
  {
    static readonly string __ServiceName = "HelloService";

    static readonly grpc::Marshaller<global::Proto.Messages.HelloMessage> __Marshaller_HelloMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Proto.Messages.HelloMessage.Parser.ParseFrom);

    static readonly grpc::Method<global::Proto.Messages.HelloMessage, global::Proto.Messages.HelloMessage> __Method_SayHello = new grpc::Method<global::Proto.Messages.HelloMessage, global::Proto.Messages.HelloMessage>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SayHello",
        __Marshaller_HelloMessage,
        __Marshaller_HelloMessage);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Proto.Services.HelloServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of HelloService</summary>
    [grpc::BindServiceMethod(typeof(HelloService), "BindService")]
    public abstract partial class HelloServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Proto.Messages.HelloMessage> SayHello(global::Proto.Messages.HelloMessage request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for HelloService</summary>
    public partial class HelloServiceClient : grpc::ClientBase<HelloServiceClient>
    {
      /// <summary>Creates a new client for HelloService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public HelloServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for HelloService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public HelloServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected HelloServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected HelloServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Proto.Messages.HelloMessage SayHello(global::Proto.Messages.HelloMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SayHello(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Proto.Messages.HelloMessage SayHello(global::Proto.Messages.HelloMessage request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SayHello, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.Messages.HelloMessage> SayHelloAsync(global::Proto.Messages.HelloMessage request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SayHelloAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Proto.Messages.HelloMessage> SayHelloAsync(global::Proto.Messages.HelloMessage request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SayHello, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override HelloServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new HelloServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(HelloServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SayHello, serviceImpl.SayHello).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, HelloServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SayHello, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Proto.Messages.HelloMessage, global::Proto.Messages.HelloMessage>(serviceImpl.SayHello));
    }

  }
}
#endregion
