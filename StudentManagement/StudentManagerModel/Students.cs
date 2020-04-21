using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerModel
{
    [Serializable]
    /// <summary>
    /// 学生类模块
    /// </summary>
   public class Students
   {
        /// <summary>
        /// 学号
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// 学员姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string StudentIdNo { get; set; }
        /// <summary>
        /// 指纹号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 学生照片
        /// </summary>
        public string StuImage { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 电话号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 家庭住址
        /// </summary>
        public string StudentAddress { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        public int ClassId { get; set; }
   }
}
