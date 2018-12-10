using System; namespace HomeworkTracker5000 {     public class Assignments      {         NMCCourses _courseName;         string _assignmentName;         DateTime _dueDate;         private double _score;         string assignmentName = null;

        #region Properties         public double Score         {             get { return _score; }             set { _score = value; }         }          public NMCCourses CourseName         {             get { return _courseName; }             set { _courseName = value; }         }          public string AssignmentName         {             get { return _assignmentName; }             set { _assignmentName = value; }         }          public DateTime DueDate         {             get { return _dueDate; }             set { _dueDate = value; }         }          public Assignments()         {          }          public string AssignmentNameMethod()         {             return _assignmentName;         }          public Assignments(string assignmnetName)         {             _assignmentName = assignmentName;         }
        #endregion 
        //
        //Enum of Courses
        //
        public enum NMCCourses         {             CIT110,             EET102,             HIT112,             MTH121         }     } }    