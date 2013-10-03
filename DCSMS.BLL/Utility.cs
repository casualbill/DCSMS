using System;
using System.Web.Security;

namespace DCSMS.BLL
{
    public class Utility
    {
        //生成随机数
        protected int getRandomNumber(int min, int max)
        {
            Random rand = new Random();
            int randNum = rand.Next(min, max);

            return randNum;
        }

        //加密密码 （MD5 Hash32位截取16）
        //test删除后改为private！！！！！！
        public String getMD5HashCode(String sourceStr)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(sourceStr, "MD5").ToLower().Substring(8, 16);
        }
    }
}
