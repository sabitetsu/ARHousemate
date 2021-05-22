using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class InputTaskScript : MonoBehaviour
{
    InputField yyyy;
    InputField mm;
    InputField dd;
    InputField time;
    InputField min;
    InputField inputTask;
    TaskPush taskPush;

    void Start()
    {
        yyyy = GameObject.Find("YYYY").GetComponent<InputField>();
        mm = GameObject.Find("MM").GetComponent<InputField>();
        dd = GameObject.Find("DD").GetComponent<InputField>();
        time = GameObject.Find("Time").GetComponent<InputField>();
        min = GameObject.Find("Minute").GetComponent<InputField>();
        inputTask = GameObject.Find("InputTask").GetComponent<InputField>();
        taskPush = new TaskPush();
    }

    // Update is called once per frame
    public void ClickButton(int inputTaskNum)
    {
        switch (inputTaskNum)
        {
            case 0://back
                Destroy(this.gameObject);
                break;
            case 1://submit
                AddNewTask();
                taskPush.InitPush();
                Destroy(this.gameObject);
                break;
        }
    }

    public void AddNewTask()
    {
        var writer = new StreamWriter(Application.persistentDataPath + @"\Resources\TaskCSV.csv", true, Encoding.GetEncoding("UTF-8"));
        string[] newTask = new string[6] { yyyy.text, mm.text, dd.text, time.text, min.text, inputTask.text };
        string addTask = string.Join(",", newTask);
        writer.WriteLine(addTask);
        writer.Close();
        Debug.Log("add");
    }
}
