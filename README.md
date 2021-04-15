# Using gRPC with Unity

This project illustrates how [gRPC](https://grpc.io/) can be used in Unity projects and contains all necessary resources for Unity target platforms based on `x86`, `x64` and `arm64`.
Its primary goal is to speed up the development of mixed reality applications based on Microsoft's [Mixed Reality Toolkit](https://github.com/Microsoft/MixedRealityToolkit-Unity).
However, the MRTK components used in this project are not necessary for gRPC communication.

## Using GRPC in other Unity projects

You need to copy the content of `UnityGRPC/Assets/Plugins` to your project.
It contains all required gRPC DLLs as well as compatible protocol buffer well-known type definitions and libraries.
Make sure that all DLL targets in `Grpc.Core/runtimes/win/<arch>` are correctly set.
Furthermore, you need to copy `UnityGRPC/Assets/link.xml` to your `Assets` folder to prevent Unity/IL2CPP to accidentally strip vital protocol buffer resources from your project.

## Example

### Compiling protocol buffer messages

The unity project contain the compiled versions of the proto files found in `proto`. In case you want to tinker around a bit. You can compile the changed proto files the following way.

For Unity, you need to use `dotnet` and build the mock project `csharp`. All required dependencies will be installed by `dotnet`.

```shell
cd <repository_root>
dotnet build csharp
```

For Python, you need to install `grpcio-tools` (preferably via `pip`) and run the `protoc` compiler. The output will be written into the `python` folder.

```shell
cd <repository_root>
pip install -r requirements.txt
python -m grpc_tools.protoc \
    -I ./proto \
    --python_out=./python \
    --grpc_python_out=./python \
    ./proto/*.proto
```


### Running the example

The example scene `UnityGRPC/Assets/Scenes/HelloGrpc` contains a button and a text GameObject. Starting the scene create a gRPC server. Clicking the button will trigger the creation of a gRPC client and sending a message. The last received message will be shown under "Message Received:".

The empty GameObjects `MessageSender` and `MessageHandler` can be adjusted:

- `ServerPort`: The port for the Unity gRPC server (default is `9090`)
- `Message`: The message to be sent to the *remote* server when the button is clicked. (default is `Hello from Unity!`)
- `RemoteURL`: The URL (commonly IP and port) of the *remote* gRPC server to send the message to. (default is `localhost:9091`)

For testing, you can run both, the Unity project as well as the Python server/client on the same machine.
When the scene is running in the Unity Editor, you can send a message from Python with:

```shell
python python/send.py localhost:9090 "Hello from Python"
```

The string "Hello from Python" should appear in the Editor.

If you want to receive a message send from Unity, you need to start the Python server first:

```shell
python python/receive.py 9091
```

The server will listen on port `9091`, print messages when received and return "Answer from Python!" to the sender.

If you want to run the Unity project on a remote machine or on a HoloLens(2), make sure that `RemoteURL` is set correctly (pointing to the machine that will run the python server) before you export the project and build it with Visual Studio.
There is no way to set `RemoteURL` during runtime.
Also, verify that the target platform in Unity's build settings is correctly set to `Universial Windows Platform`.
