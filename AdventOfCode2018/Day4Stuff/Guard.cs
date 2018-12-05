using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2018.Day4Stuff
{
    public class Guard
    {
        private int _ID;
        private List<Action> _actions;

        public Guard(int ID)
        {
            _ID = ID;
            _actions = new List<Action>();
        }

        public void AddAction(Action action)
        {
            _actions.Add(action);
        }

        public double CalculateMinutesSleeping()
        {
            double value = 0;

            for (int i = 0; i < _actions.Count; i++)
            {
                if (_actions[i].ActionType == ActionType.Sleeps)
                {
                    TimeSpan span = _actions[i + 1].TimeStamp - _actions[i].TimeStamp;
                    double totalMinutes = span.TotalMinutes;
                    value += totalMinutes;
                }
            }

            return value;
        }

        public int FindMostSleepyMinute()
        {
            List<int> sleepyMinutes = new List<int>();
            int result = 0;
            for (int i = 0; i < _actions.Count; i++)
            {
                if (_actions[i].ActionType == ActionType.Sleeps)
                {
                    int startMinute = _actions[i].TimeStamp.Minute;
                    TimeSpan span = _actions[i + 1].TimeStamp - _actions[i].TimeStamp;
                    int totalMinutes = (int)span.TotalMinutes;

                    for (int j = 0; j < totalMinutes; j++)
                    {
                        sleepyMinutes.Add(startMinute);

                        if ((startMinute + 1) >= 60)
                            startMinute = 0;
                        else
                            startMinute++;
                    }

                }
            }

            if (sleepyMinutes.Count > 0)
                result = sleepyMinutes.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();

            return result;
        }

        public int HowManyTimesMinuteSlept(int minute)
        {
            List<int> sleepyMinutes = new List<int>();

            for (int i = 0; i < _actions.Count; i++)
            {
                if (_actions[i].ActionType == ActionType.Sleeps)
                {
                    int startMinute = _actions[i].TimeStamp.Minute;
                    TimeSpan span = _actions[i + 1].TimeStamp - _actions[i].TimeStamp;
                    int totalMinutes = (int)span.TotalMinutes;

                    for (int j = 0; j < totalMinutes; j++)
                    {
                        sleepyMinutes.Add(startMinute);

                        if ((startMinute + 1) >= 60)
                            startMinute = 0;
                        else
                            startMinute++;
                    }

                }
            }
            var count = sleepyMinutes.Where(temp => temp.Equals(minute))
                    .Select(temp => temp)
                    .Count();

            return count;
        }
    }
}
