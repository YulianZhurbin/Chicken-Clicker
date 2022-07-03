using UnityEngine;
using System.IO;

public class RecordManager : MonoBehaviour
{
    RecordContainer recordContainer;

    public int GetRecord()
    {
        LoadRecord();

        if(recordContainer != null)
        {
            return recordContainer.score;
        }
        else
        {
            return 0;
        }
    }
    public void CheckRecord(int score)
    {
        LoadRecord();

        if (recordContainer == null || score > recordContainer.score)
        {
            WriteNewRecord(score);
        }
    }

    void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            recordContainer = JsonUtility.FromJson<RecordContainer>(json);
        }
    }

    void WriteNewRecord(int score)
    {
        RecordContainer newRecordContainer = new RecordContainer();

        newRecordContainer.score = score;

        string json = JsonUtility.ToJson(newRecordContainer);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
