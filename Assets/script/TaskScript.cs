using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class TaskScript : MonoBehaviour
{
    [SerializeField] Text NowTime;
    List<string[]> taskList = new List<string[]>(); //Y,M,D,t,m,etc
    [SerializeField] GameObject InputTaskCanvas;
    [SerializeField] GameObject AllShowTaskCanvas;
    [SerializeField] GameObject TaskCanvas;

    void Awake()
    {
        UniLocalNotification.Initialize();
    }
    void Start()
    {
        StreamReader reader = new StreamReader(Application.persistentDataPath + @"\Resources\TaskCSV.csv");
        var taskButton = Resources.Load(path: "TaskButton") as GameObject;
        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            taskList.Add(line.Split(','));
        }
        reader.Close();

        //最大4つのボタンを表示
        for (int i = 0; i < taskList.Count; i++)
        {
            var task = Instantiate(taskButton, TaskCanvas.transform);
            Vector3 pos = task.transform.position;
            pos.y -= i * 80;
            task.transform.position = pos;
            var loadedText = taskList[i][1] + "/" + taskList[i][2] + " " + taskList[i][3] + ":" + taskList[i][4]+" "+taskList[i][5];
            var label = task.GetComponentInChildren<Text>();
            label.text = loadedText;
            if (i >= 3)
            {
                break;
            }
        }

    }

    void Update()
    {
        NowTime.text = DateTime.Now.ToString();
    }

    public void OnClick(int taskNum)
    {
        switch (taskNum)
        {
            case 0: //back
                SceneManager.LoadScene("AR");
                break;

            case 1: //allshow
                Instantiate(AllShowTaskCanvas);
                break;

            case 2: //new
                Instantiate(InputTaskCanvas);
                break;

        }
    }
}
