using System;
using Windows.UI.Xaml;

namespace Happy_Zoo
{
    /// <summary>
    /// This class is a timer which can be set in seconds. When the time is elapsed a boolean will be set true.
    /// </summary>
    public class Visitor
    {
        private DispatcherTimer timer1;
        private bool readyToLeave = false;

        //initiate the timer
        public Visitor(int seconds) {
            timer1 = new DispatcherTimer();

            timer1.Elapsed += timerTick;
            timer1.Interval = seconds * 1000;
            timer1.Start();
        }

        //set boolean readyToLeave on true
        private void timerTick(object sender, EventArgs e)
        {
            readyToLeave = true;
        }

        //returns boolean readyToLeave
        public bool getBool()
        {
            return readyToLeave;
        }
    }
}
