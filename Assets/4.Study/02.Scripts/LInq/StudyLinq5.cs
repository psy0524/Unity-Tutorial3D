using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class StudyLinq5 : MonoBehaviour
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
        students.Add(new Student(5, "Frank"));

        grades.Add(new Grade(1, 90, "Math"));
        grades.Add(new Grade(2, 80, "Science"));
        grades.Add(new Grade(3, 70, "English"));
        grades.Add(new Grade(4, 60, "Math"));
        grades.Add(new Grade(6, 55, "History"));

        OuterJoin();
    }

    private void OuterJoin()
    {
        var leftOuterJoin = from student in students
                            join grade in grades on student.studentId equals grade.studentId into studentGrades
                            from grade in studentGrades.DefaultIfEmpty()

                            select new
                            {
                                studentId = student.studentId,
                                studentName = student.studentName,
                                subject = grade?.subject ?? "None",
                                score = grade?.score ?? 0,
                            };
        var rightOuterJoin = from grade in grades
                             join student in students on grade.studentId equals student.studentId into gradeStudents
                             from student in gradeStudents.DefaultIfEmpty()
                             where student == null

                             select new
                             {
                                 studentId = grade.studentId,
                                 //studentName = student?.studentName ?? "N/A",
                                 studentName = "N/A",
                                 subject = grade?.subject ?? "None",
                                 score = grade?.score ?? 0,
                             };

        var outerJoin = leftOuterJoin.Union(rightOuterJoin);

        foreach(var person in outerJoin)
        {
            Debug.Log($"ID : {person.studentId} / Name : {person.studentName} / Subject : {person.subject} / Score : {person.score}");
        }

    }
}
