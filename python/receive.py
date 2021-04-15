import sys
from concurrent.futures import ThreadPoolExecutor

import grpc

from hello_pb2 import HelloMessage
from hello_service_pb2_grpc import HelloServiceServicer, add_HelloServiceServicer_to_server


class HelloServiceHandler(HelloServiceServicer):
    def SayHello(self, request, context):
        print(f"Received message: {request.message} from {context.peer()}")
        return HelloMessage(message="Answer from Python!")


server = grpc.server(ThreadPoolExecutor(max_workers=10))
add_HelloServiceServicer_to_server(HelloServiceHandler(), server)
server.add_insecure_port(f"0.0.0.0:{sys.argv[1]}")
server.start()
print(f"Server listening on port {sys.argv[1]} ...")
server.wait_for_termination()
