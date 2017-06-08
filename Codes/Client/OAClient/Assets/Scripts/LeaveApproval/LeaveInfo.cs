using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.LeaveApproval
{
    class LeaveInfo
    {
        public string Name = "菜鸡";
        public DateTime StarTime = DateTime.Now;
        public DateTime EndTime = DateTime.MaxValue;
        public string Reason = "不想上班";
        public string Statu = "等待审批";

        public static List<LeaveInfo> LeaveInfos = new List<LeaveInfo>();

        public static LeaveInfo GetLeaveInfo(string name)
        {
            if (LeaveInfos.Count == 0)
            {
                LeaveInfos.Add(new LeaveInfo());
            }

            return LeaveInfos[0];
        }
    }
}
