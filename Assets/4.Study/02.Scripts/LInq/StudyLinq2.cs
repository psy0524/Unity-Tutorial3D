using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StudyLinq2 : MonoBehaviour
{
    public class Person
    {
        public string name;
        public int score;

        public Person(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    public List<Person> persons = new List<Person>();
    public int cutline = 70;

    private void Start()
    {
        persons.Add(new Person("John", 65));
        persons.Add(new Person("Sarah", 80));
        persons.Add(new Person("David", 95));
        persons.Add(new Person("Emily", 70));
        persons.Add(new Person("Michael", 50));

        CheckScore();
    }

    private void CheckScore()
    {
        // Linq를 사용 X
        //foreach (Person person in persons)
        //{
        //    if(person.score > cutline)
        //    {
        //        Debug.Log($"{person.name} 합격");
        //    }
        //    else
        //    {
        //        Debug.Log($"{person.name} 불합격");
        //    }
        //}


        // Linq 사용 O
        //var passPersons = from person in persons
        //                  where person.score >= cutline
        //                  select person;

        var passPersons = persons.Where(p => p.score >= cutline);
        var failPersons = persons.Except(passPersons);

        foreach(var person in passPersons)
        {
            Debug.Log($"<color=green>{person.name}</color>");
        }

        foreach (var person in failPersons)
        {
            Debug.Log($"<color=red>{person.name}</color>");
        }
    }
}
