using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.PersonalInfo
{
    class PersonInfo
    {
        public string Name = "菜鸡";
        public string Sex = "男";
        public int Age = 233;
        public string IDCard = "123456789123124";
        public int ID = 666;
        public string statu = "在职";

        public string CellNum = "110";
        public string QQNum = "10000";
        public string Email = "10000@qq.com";
        public string Address = "马房山跳劈大学";

        public string toString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("姓名：{0}\n", Name));
            sb.Append(string.Format("性别：{0}\n", Sex));
            sb.Append(string.Format("年龄：{0}\n", Age));
            sb.Append(string.Format("身份证：{0}\n", IDCard));
            sb.Append(string.Format("员工编号：{0}\n", ID));
            sb.Append(string.Format("状态：{0}\n", statu));
            sb.Append("\n\n\n");
            sb.Append(string.Format("手机：{0}\n", CellNum));
            sb.Append(string.Format("QQ：{0}\n", QQNum));
            sb.Append(string.Format("Email：{0}\n", Email));
            sb.Append(string.Format("地址：\n{0}\n", Address));

            return sb.ToString();
        }

        public static List<PersonInfo> personDatabase = new List<PersonInfo>();

        public static PersonInfo GetPersonalInfo(string name)
        {
            if (personDatabase.Count <= 0)
            {
                personDatabase.Add(new PersonInfo());
            }

            return personDatabase[0];
        }
    }
}
