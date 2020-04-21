using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerModel
{
    /// <summary>
    /// 管理员表
    /// </summary>
    [Serializable]
    public class Admins
    {
        /// <summary>
        /// 登录ID
        /// </summary>
        public int LoginId { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public int LoginPwd { get; set; }
        /// <summary>
        /// 管理员姓名
        /// </summary>
        public string AdminName { get; set; }
    }
}
