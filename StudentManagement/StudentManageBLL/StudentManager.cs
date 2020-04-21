using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagerDAL;
using StudentManagerModel;
using StudentManagerModel.ObjExt;
using System.Data;


namespace StudentManageBLL
{
    /// <summary>
    /// 学生管理业务逻辑
    /// </summary>
    public class StudentManager
    {
        StudentServer server = new StudentServer();
        /// <summary>
        /// 对指定学生信息查询的业务逻辑方法
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public List<StudentExt> GetStudents(int cid)
        {
            return server.GetStudents(cid);//对数据访问层的交互
        }

        /// <summary>
        /// 根据Id或Name的模糊查询与数据库交互代码
        /// </summary>
        /// <param name="targe"></param>
        /// <returns></returns>
        public List<StudentExt> GetStudentIdOrName(string targe)
        {
            return server.GetStudentIDorName(targe);
        }
        

        /// <summary>
        /// 学生姓名查询信息判断
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>

        public bool UpdateStudentInfor(StudentExt student)
        {
            if (server.UpdateStudentInfor(student) <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool UpAddStudent(StudentExt student)
        {
            if (server.AddStudent(student) <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentExt GetStudentById(int id)
        {
            return server.GetStudentById(id);
        }


        /// <summary>
        /// 对ID学生 查询制表
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public DataTable GetDataTable(int cid)
        {
            return server.GetDataTable(cid);
        }

        /// <summary>
        /// 对Excel数据进行读取
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<StudentExt> GetStudentByExcel(string path)
        {
            return server.GetStudentByExcel(path);
        }


        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int InsertStudent(StudentExt stu)
        {
            if (server.CheckStuId(stu.StudentIdNo) > 0)
            {
                return -1;
            }
            return server.InsertStudent(stu);
        }


        /// <summary>
        /// 通过ID 来进行删除学员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteStudentBid(int id)
        {
            if (server.DeleteStudentById(id)<=0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
