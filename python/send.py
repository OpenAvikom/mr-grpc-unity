import sys

import grpc

from hello_pb2 import HelloMessage
from hello_service_pb2_grpc import HelloServiceStub

print(f"Sending message '{sys.argv[2]}' to {sys.argv[1]} ...")
channel = grpc.insecure_channel(sys.argv[1])
client = HelloServiceStub(channel)
answer = client.SayHello(HelloMessage(message=sys.argv[2]))
print(f"Received answer: {answer.message}")
