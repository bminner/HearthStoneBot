using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneCs
{
    class HearthWindowControl
    {
        IntPtr hearthWindowHandle;
        public HearthWindowControl()
        {
            hearthWindowHandle = getProcessesHandle();
            handleNullWindow();
        }
        //Properly gets Handle, Private because we only deal with window handles within this class
        private IntPtr getProcessesHandle()
        {
            //Hearthstone will only have 1 window open, so it will be the element 0of the array
            Process[] processes = Process.GetProcessesByName("Hearthstone");
            IntPtr windowHandle = processes[0].MainWindowHandle;
            return windowHandle;
        }
        //Scale the window to a fixed size in order to have same window for each
        private void setWindowToFrontandSize()
        {
            SetForegroundWindow(hearthWindowHandle);
        }
        //Used to make sure window is open, will throw a popup and wait for user to open Hearthstone then they click Ok
        private void handleNullWindow()
        {
            if (hearthWindowHandle == null)
            {
                Console.WriteLine("Please open hearthstone then click OK.");
                //Make a gui thing with a wait until they open it
            }
        }
    }
}
