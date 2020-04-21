using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagerDAL;
using StudentManagerModel;

namespace StudentManageBLL
{
    /// <summary>
    /// 与数据库交互中枢
    /// </summary>
    public class AdminManager
    {
        AdminServer server = new AdminServer();//将对管理员表的数据库访问类进行实例化

        /// <summary>
        /// 管理员数据交互 （验证）
        /// </summary>
        /// <param name="adm"></param>
        /// <returns></returns>
        public Admins GetAdmins(Admins adm)
        {
            return server.GetAdmins(adm);//在数据交互层进行访问数据库进行查询
        }

        public int GetAddAdmins(Admins adm)
        {
            return server.AddAdmins(adm);
        }
    }
}
