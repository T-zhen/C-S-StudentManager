using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagerDAL;
using StudentManagerModel;

namespace StudentManageBLL
{
    public class StudentClassManager
    {
       StudentClassServer server = new StudentClassServer();
        /// <summary>
        /// 查询所有班级
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetClasses()
        {
            return server.GetClasses();
        }

    }
}
    