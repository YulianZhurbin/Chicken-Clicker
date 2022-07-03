using UnityEngine;
using UnityEngine.UI;

public class RecordsUIController : MonoBehaviour
{
    [SerializeField] Text recordText;

    void Start()
    {
        RecordManager recordManager = GetComponent<RecordManager>();
        recordText.text = "Record:    " + recordManager.GetRecord();
    }
}
