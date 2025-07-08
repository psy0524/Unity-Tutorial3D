using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class PersonData
{
    public int age;
    public string name;
    public float height;
    public float weight;

    public PersonData(int age, string name, float height, float weight)
    {
        this.age = age;
        this.name = name;
        this.height = height;
        this.weight = weight;
        
    }
}

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, PersonData> persons = new Dictionary<string, PersonData>();

    private void Start()
    {
        persons.Add("繹熱", new PersonData(15, "繹熱", 165f, 75f));
        persons.Add("艙��", new PersonData(15, "繹熱", 165f, 75f));
        persons.Add("翕熱", new PersonData(15, "繹熱", 165f, 75f));

        Debug.Log(persons["繹熱"].age);
        Debug.Log(persons["繹熱"].name);
        Debug.Log(persons["繹熱"].height);
        Debug.Log(persons["繹熱"].weight);
    }
}
