using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int score;
}

public class SaveDataFile : MonoBehaviour
{
    private int score;
    private string savePath;

    private void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "saveDataFile.json");

        Load();
        Debug.Log("Load Score : " + score);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            Save();

            Debug.Log(score);
        }
    }

    private void Save()
    {
        SaveData data = new SaveData();
        data.score = this.score;

        string json = JsonUtility.ToJson(data);
        //string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Data saved to : " + savePath);
    }

    private void Load()
    {
        if(File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            this.score = data.score;
        }
        else
        {
            score = 0;
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
