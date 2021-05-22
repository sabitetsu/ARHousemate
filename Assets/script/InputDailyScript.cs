using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class InputDailyScript : MonoBehaviour
{
    InputField inputDaily;
    InputField inputTime;
    InputField inputMin;
    TaskPush taskPush;

    void Start()
    {
        inputDaily = GameObject.Find("InputDaily").GetComponent<InputField>();
        inputTime = GameObject.Find("InputTime").GetComponent<InputField>();
        inputMin = GameObject.Find("InputMin").GetComponent<InputField>();
        taskPush = new TaskPush();
    }

    public void OnClick(int InputDailyNum)
    {
        switch (InputDailyNum)
        {
            case 0://back
                Destroy(this.gameObject);
                break;
            case 1://submit
                AddNewDaily();
                taskPush.InitPush();
                Destroy(this.gameObject);
                break;
        }
    }

    public void AddNewDaily()
    {
        var writer = new StreamWriter(Application.persistentDataPath + @"\Resources\DayTaskCSV.csv",true, Encoding.GetEncoding("UTF-8"));
        string[] newDaily = new string[3] { inputTime.text, inputMin.text, inputDaily.text };
        string addDaily = string.Join(",", newDaily);
        writer.WriteLine(addDaily);
        writer.Close();
        Debug.Log("add");
    }

    
}
