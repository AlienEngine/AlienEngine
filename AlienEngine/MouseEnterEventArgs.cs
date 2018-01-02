using System;

namespace AlienEngine.Core
{
    public class MouseEnterEventArgs: EventArgs
    {
        private readonly Point2d EnterLocation;

        public MouseEnterEventArgs(Point2d location)
        {
            EnterLocation = location;
        }
    }
}