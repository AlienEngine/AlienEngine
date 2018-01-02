using System;

namespace AlienEngine.Core
{
    public class MouseLeaveEventArgs: EventArgs
    {
        private readonly Point2d LeaveLocation;

        public MouseLeaveEventArgs(Point2d location)
        {
            LeaveLocation = location;
        }
    }
}