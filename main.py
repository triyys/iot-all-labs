print("Xin chào ThingsBoard")
import paho.mqtt.client as mqttclient
import time
import json
import serial.tools.list_ports

mess = ""
# Use the other COM along with the one Hercules uses
bbc_port = "COM4"
if len(bbc_port) > 0:
    ser = serial.Serial(port=bbc_port, baudrate=115200)
    
def processData(data: str):
    data = data.replace("!", "").replace("#", "")
    splitData = data.split(":")
    # TODO convert to JSON
    return splitData
    
def readSerial():
    bytesToRead = ser.inWaiting()
    if bytesToRead > 0:
        global mess
        mess = mess + ser.read(bytesToRead).decode("UTF-8")
        while ("#" in mess) and ("!" in mess):
            start = mess.find("!")
            end = mess.find("#")
            print(processData(mess[start: end + 1]))
            if end == len(mess):
                mess = ""
            else:
                mess = mess[end + 1:]

BROKER_ADDRESS = "demo.thingsboard.io"
PORT = 1883
THINGS_BOARD_ACCESS_TOKEN = "ea7goOgmiKgplBes9oUh"


def subscribed(client, userdata, mid, granted_qos):
    print("Subscribed...")


def recv_message(client, userdata, message):
    print("Received: ", message.payload.decode("utf-8"))
    cmdMessage = "0"
    try:
        jsonobj = json.loads(message.payload)
        
        if jsonobj['method'] == "setLED":
            cmdMessage = "0"
            client.publish('v1/devices/me/attributes', json.dumps({ 'isLedOn': jsonobj['params'] }), 1)
            
        if jsonobj['method'] == "setPump":
            cmdMessage = "1"
            client.publish('v1/devices/me/attributes', json.dumps({ 'isPumpOn': jsonobj['params'] }), 1)
    except:
        print("Could not update realtime")
    
    ser.write(("%s#" % cmdMessage).encode())


def connected(client, usedata, flags, rc):
    if rc == 0:
        print("Thingsboard connected successfully!!")
        client.subscribe("v1/devices/me/rpc/request/+")
    else:
        print("Connection is failed")


client = mqttclient.Client("Gateway_Thingsboard")
client.username_pw_set(THINGS_BOARD_ACCESS_TOKEN)

client.on_connect = connected
client.connect(BROKER_ADDRESS, 1883)
client.loop_start()

client.on_subscribe = subscribed
client.on_message = recv_message

temp = 0
humi = 0
light_intesity = 100


while True:
    if len(bbc_port) > 0:
        readSerial()
    time.sleep(1)