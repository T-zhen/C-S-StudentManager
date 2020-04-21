using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerModel
{
    [Serializable]//可序列化

    /// <summary>
    /// 班级表
    /// </summary>
    public class StudentClass
    {
        
        /// <summary>
        /// 班级编号
        /// </summary>
        public int ClassId { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
    }
}
