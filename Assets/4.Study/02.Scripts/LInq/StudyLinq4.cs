using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class StudyLinq4 : MonoBehaviour
{
    public class Student
    {
        public int studentId;
        public string studentName;

        public Student(int studentId, string studentName)
        {
            this.studentId = studentId;
            this.studentName = studentName;
        }
    }

    public class Grade
    {
        public int studentId;
        public int score;
        public string subject;

        public Grade(int studentId, int score, string subject)
        {
            this.studentId = studentId;
            this.score = score;
            this.subject = subject;
        }
    }

    public List<Student> students = new List<Student>();
    public List<Grade> grades = new List<Grade>();

    private void Start()
    {
        students.Add(new Student(1, "Alice"));
        students.Add(new Student(2, "Bob"));
        students.Add(new Student(3, "Charlie"));
        students.Add(new Student(4, "Eve"));

        grades.Add(new Grade(1, 90, "Math"));
        grades.Add(new Grade(2, 80, "Science"));
        grades.Add(new Grade(3, 70, "English"));
        grades.Add(new Grade(4, 60, "Math"));

        InnerJoin();
    }

    private void InnerJoin()
    {
        var innerJoin = from student in students
                        join grade in grades on student.studentId equals grade.studentId
                        select new
                        {
                            studentID = student.studentId,
                            studentName = student.studentName,
                            subject = grade.subject,
                            score = grade.score
                        };

        foreach(var person in innerJoin)
        {
            Debug.Log($"ID : {person.studentID} / Name : {person.studentName} / Subject : {person.subject} / Score : {person.score}");
        }
    }
}
