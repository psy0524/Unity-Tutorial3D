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
        persons.Add("ö��", new PersonData(15, "ö��", 165f, 75f));
        persons.Add("����", new PersonData(15, "ö��", 165f, 75f));
        persons.Add("����", new PersonData(15, "ö��", 165f, 75f));

        Debug.Log(persons["ö��"].age);
        Debug.Log(persons["ö��"].name);
        Debug.Log(persons["ö��"].height);
        Debug.Log(persons["ö��"].weight);
    }
}
