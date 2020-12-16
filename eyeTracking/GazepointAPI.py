######################################################################################
# GazepointAPI.py - Example Client
# Written in 2013 by Gazepoint www.gazept.com
#
# To the extent possible under law, the author(s) have dedicated all copyright 
# and related and neighboring rights to this software to the public domain worldwide. 
# This software is distributed without any warranty.
#
# You should have received a copy of the CC0 Public Domain Dedication along with this 
# software. If not, see <http://creativecommons.org/publicdomain/zero/1.0/>.
######################################################################################

import socket
from pointGUI import pointGUI
import time
import math

# Host machine IP
HOST = '127.0.0.1'
# Gazepoint Port
PORT = 4242
ADDRESS = (HOST, PORT)

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect(ADDRESS)
s.send(str.encode('<SET ID="ENABLE_SEND_POG_FIX" STATE="1" />\r\n'))
s.send(str.encode('<SET ID="ENABLE_SEND_TIME" STATE="1" />\r\n'))
s.send(str.encode('<SET ID="ENABLE_SEND_DATA" STATE="1" />\r\n'))
# s.send(str.encode('<SET ID="CALIBRATE_START" STATE="1" />\r\n'))
# s.send(str.encode('<SET ID="CALIBRATE_SHOW" STATE="1" />\r\n'))

AP = pointGUI()
prevX = 1000
prevY = 1000
prevT = 0.0
coordinate_list = []
while 1:
    rxdat = s.recv(1024)
    records = bytes.decode(rxdat).split("<")
    for el in records:
        if ('REC' in el):
            print(el)
            coords = el.split("\"")

            try:
                oclidDis = math.sqrt(math.pow(float(coords[3]) - prevX, 2) + math.pow(float(coords[5]) - prevY, 2))
                timeThresh = float(coords[1]) - prevT
                # print(oclidDis)
                # print(coords[1])
                # if  abs(prevX - float(coords[3])) > 0.01 and abs(prevY - float(coords[5]) > 0.01):
                # print("TIME: " + coords[1] + " X:" + coords[3] + "  Y:" + coords[5])
                # if oclidDis > 0.5:
                if timeThresh > 0.008:
                    AP.clearCanvas()
                    AP.draw(float(coords[3]), float(coords[5]))
                    prevX = float(coords[3])
                    prevY = float(coords[5])
                    prevT = float(coords[1])
            except:
                pass

s.close()
