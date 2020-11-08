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
import numpy as np
from datetime import datetime

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
coordinate_list = []
timeSum = 0
start = 0.0
end = 0.0
while 1:

    if timeSum >= 0.8 and len(coordinate_list) > 0:
        # print(timeSum)
        # print(coordinate_list)
        xAvg = np.average([float(tpl[0]) for tpl in coordinate_list])
        yAvg = np.average([float(tpl[1]) for tpl in coordinate_list])
        xStd = np.std([float(tpl[0]) for tpl in coordinate_list])
        yStd = np.std([float(tpl[1]) for tpl in coordinate_list])
        # print('Std: '+str(xStd)+'  '+str(yStd))
        # print('Std average: '+str(np.average([xStd,yStd])))
        std_avarage=np.average([xStd,yStd])
        if(std_avarage<0.1):
            AP.clearCanvas()
            AP.draw(xAvg, yAvg)
        timeSum = 0
        coordinate_list = []

    start = datetime.now()
    # print(start)

    rxdat = s.recv(1024)
    records = bytes.decode(rxdat).split("<")
    for el in records:
        if ('REC' in el):
            # print(el)
            coords = el.split("\"")
            try:
                # timeThresh = float(coords[1]) - prevT
                # if timeThresh > 0.008:
                coordinate_list.append((coords[3],coords[5]))
                # prevT = float(coords[1])
            except:
                pass
    end = datetime.now()
    # print(end)
    timeSum += (end - start).total_seconds()
    # print(timeSum)
s.close()
