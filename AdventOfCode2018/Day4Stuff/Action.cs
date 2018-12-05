using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2018.Day4Stuff
{
    public enum ActionType { Starts, Sleeps, Wakes }
    public class Action
    {
        public DateTime TimeStamp;
        public ActionType ActionType;

        public Action(DateTime time, ActionType actionType)
        {
            TimeStamp = time;
            ActionType = actionType;
        }
    }
}
