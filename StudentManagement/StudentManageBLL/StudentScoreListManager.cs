using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagerDAL;
using StudentManagerModel;
using StudentManagerModel.ObjExt;

namespace StudentManageBLL
{
    
    public class StudentScoreListManager
    {
        ScoreListServer server = new ScoreListServer();//对数据访问类实例化
        StudentServer student = new StudentServer();

        /// <summary>
        /// 成绩表所有信息访问
        /// </summary>
        /// <returns></returns>
        public List<ScoreList> GetScores()
        {
            return server.GetScoreList();
        }


        /// <summary>
        /// 返回未及格学生成绩表信息
        /// </summary>
        /// <returns></returns>
        public List<ScoreList> GetScoresNO()
        {
            return server.GetScoreListsNO();
        }


        /// <summary>
        /// 根据所在的班级来查询里面的学生
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<StudentExt> GetStudent(int id)
        {
            return student.GetStudentsClassid(id);
        }

        /// <summary>
        /// 通过学生的ID来进行查询成绩
        /// </summary>
        /// <param name="Stuid"></param>
        /// <returns></returns>
        public List<ScoreList> GetScoresStuId(int Stuid)
        {
            return server.GetScoreListsStuID(Stuid);
        }
    }
}
