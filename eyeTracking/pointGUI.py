from tkinter import Tk, Canvas, Frame, BOTH
from PIL import Image, ImageTk
import time
class pointGUI:

    def __init__(self):
        self.root = Tk()
        self.width = self.root.winfo_screenwidth()
        self.height = self.root.winfo_screenheight()
        self.root.attributes('-fullscreen', True)  # make main window full-screen
        self.root.overrideredirect(True)
        self.root.geometry("+250+250")
        self.root.lift()
        self.root.wm_attributes("-topmost", True)
        self.root.wm_attributes("-disabled", True)
        self.root.wm_attributes("-transparentcolor", "white")
        self.canvas = Canvas(self.root, bg='white', highlightthickness=0)
        self.canvas.pack(fill=BOTH, expand=True)  # configure canvas to occupy the whole main window
        diapason = 0


    def point(self,x,y):
        return self.canvas.create_oval(x-25, y-25, x+25, y+25, outline="#2541f4",width=20)



    def draw(self,x,y):
        x = (x*self.width)
        y = (y*self.height)
        self.point( x, y)
        self.root.update()
        # self.root.mainloop()

    def clearCanvas(self):
        self.canvas.delete("all")

#### make tranparent: replace in INIT ####


