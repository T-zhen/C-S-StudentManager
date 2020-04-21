using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagerModel.ObjExt
{
    /// <summary>
    /// 对Students的继承添加课程名称
    /// </summary>
    public class StudentExt : Students
    {
        public string ClassName { get; set; }
        public string ImgPath   { get; set; }
    }
}
