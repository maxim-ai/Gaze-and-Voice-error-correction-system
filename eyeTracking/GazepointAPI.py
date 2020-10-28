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

# Host machine IP
HOST = '127.0.0.1'
# Gazepoint Port
PORT = 4242
ADDRESS = (HOST, PORT)

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect(ADDRESS)
s.send(str.encode('<SET ID="ENABLE_SEND_POG_BEST" STATE="1" />\r\n'))
s.send(str.encode('<SET ID="ENABLE_SEND_DATA" STATE="1" />\r\n'))

GUI = pointGUI()

while 1:
    rxdat = s.recv(1024)
    records = bytes.decode(rxdat).split("<")
    for el in records:
        if ('REC' in el):
            coords = el.split("\"")
            print("X:" + coords[1] + "  Y:" + coords[3])
            GUI.clearCanvas()
            GUI.draw(float(coords[1]), float(coords[3]))

s.close()
