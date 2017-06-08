using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Attending
{
    class AttendingInfo
    {
        public string Name;
        public DateTime[] Time;
        public string Statu;

        internal int level
        {
            get
            {
                switch (Statu)
                {
                    case "正常上班":
                        return 1;break;
                    case "迟到":
                        return 2;break;
                    case "早退":
                        return 3;break;
                    default:
                        return 0;break;
                }
            }
        }

        private static string RandomStat()
        {
            int r = Random.Range(0, 5);
            switch (r)
            {
                case 1:
                    return "正常上班";
                case 2:
                    return "迟到";
                case 3:
                    return "早退";
            }

            return "正常上班";
        }

        public static List<AttendingInfo> GetAttendingInfo(string name)
        {
            List<AttendingInfo> res = new List<AttendingInfo>();

            int count = Random.Range(3, 10);
            while (count > 0)
            {
                AttendingInfo t = new AttendingInfo();
                t.Name = name;
                t.Statu = RandomStat();
                t.Time = new DateTime[4];
                for (int i = 0; i < 4; i++)
                {
                    t.Time[i] = DateTime.Now;
                }
                count--;

                res.Add(t);
            }

            return res;
        }

        public string toString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t", this.Name, this.Time[0], this.Time[1], this.Time[2], this.Time[3], this.Statu);
        }
    }
}
