# This is an example script to go with the above constants.py

from pygaze.display import Display
from pygaze.screen import Screen
from pygaze.eyetracker import EyeTracker
import pygaze.libtime as timer

# Initialise the Display and a Screen.
disp = Display()
scr = Screen()

# Show a waiting message.
scr.draw_text("Preparing experiment...", fontsize=20)
disp.fill(scr)
disp.show()

# Open a connection to the eye tracker.
tracker = EyeTracker(disp)

# Calibrate the eye tracker.
tracker.calibrate()

# Start streaming and logging samples.
tracker.start_recording()

# Run for 5000 milliseconds, showing a dot on the current gaze position.
t0 = timer.get_time()
while timer.get_time() - t0 < 5000:
	# Get the latest gaze sample.
	gazepos = tracker.sample()
	# Clear the current contents of the Screen.
	scr.clear()
	# Draw a dot on the Screen, at the current gaze position.
	scr.draw_fixation(fixtype='dot', pos=gazepos)
	# Show the Screen.
	disp.fill(scr)
	disp.show()

# Stop streaming and logging samples.
tracker.stop_recording()
# Close the connection to the tracker.
tracker.close()

# Close the display.
disp.close()