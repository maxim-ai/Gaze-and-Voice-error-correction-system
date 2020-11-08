
namespace EyeGaze.GazeTracker
{
    interface InterfaceGazeToCoords
    {
        void connect(string key, string keyInfo);
        string listen();
        void disconnect();
    }
}
