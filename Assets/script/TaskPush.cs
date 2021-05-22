using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class TaskPush : MonoBehaviour
{
    public void DelPush()
    {
        UniLocalNotification.CancelAll();
    }
    public void InitPush()
    {

        var taskReader = new StreamReader(Application.persistentDataPath + @"\Resources\TaskCSV.csv");
        List<string[]> taskList = new List<string[]>();
        while (taskReader.Peek() != -1)
        {
            string line = taskReader.ReadLine();
            taskList.Add(line.Split(','));
        }
        taskReader.Close();
        SetTaskPush(taskList.Count, taskList);

        var dailyReader = new StreamReader(Application.persistentDataPath + @"\Resources\DayTaskCSV.csv");
        List<string[]> dailyList = new List<string[]>();
        while (dailyReader.Peek() != -1)
        {
            string line = dailyReader.ReadLine();
            dailyList.Add(line.Split(','));
        }
        dailyReader.Close();
        SetDailyPush(dailyList.Count, dailyList);
    }

    void SetTaskPush(int num, List<string[]> tasks)
    {
        for (int i = 0; i < num; i++)
        {
            UniLocalNotification.Register(TTC(tasks[i]), tasks[i][5] + "の時間", "お知らせするよ！");
        }
    }

    int TTC(string[] task) //TaskTimeCalculation
    {
        int yyyy = int.Parse(task[0]);
        int mm = int.Parse(task[1]);
        int dd = int.Parse(task[2]);
        int time = int.Parse(task[3]);
        int minute = int.Parse(task[4]);
        DateTime taskTime = new DateTime(yyyy, mm, dd, time, minute, 00);

        TimeSpan ts = taskTime - DateTime.Now;
        int delayTime = (int)ts.TotalSeconds;
        return delayTime;
    }

    void SetDailyPush(int num, List<string[]> tasks)
    {
        for (int i = 0; i < num; i++)
        {
            UniLocalNotification.Register(DTTC(tasks[i][0], tasks[i][1]), tasks[i][2] + "の時間", "お知らせするよ！");
        }
    }

    int DTTC(string tt, string mm) //TaskTimeCalculation
    {
        int time = int.Parse(tt);
        int minute = int.Parse(mm);
        DateTime taskTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, time, minute, 00);


        TimeSpan ts = taskTime - DateTime.Now;
        int delayTime = (int)ts.TotalSeconds;
        return delayTime;
    }
}
