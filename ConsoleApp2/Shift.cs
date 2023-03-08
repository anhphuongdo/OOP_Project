using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Shift
    {
        private string shiftid;
        private string startTime;
        private string endTime;

        public string Shiftid { get { return shiftid; } set { shiftid = value; } }
        public string StartTime { get { return startTime; } set { startTime = value; } }
        public string EndTime { get { return endTime; } set { endTime = value; } }

        public Shift() { }
        public Shift(string shiftid, string startTime, string endTime)
        {
            this.shiftid = shiftid;
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public string Display()
        {
            string s = $"ID ca: {shiftid} | Giờ bắt đầu: {startTime} | Giờ kết thúc: {endTime}";
            return s;
        }

        public string Format4File()
        {
            string s = $"{shiftid}|{startTime}|{endTime}*";
            return s;
        }
    }
}
