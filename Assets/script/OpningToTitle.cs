using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

public class OpningToTitle : MonoBehaviour
{
    private float step_time;    // 経過時間カウント用
    TaskPush taskPush;
    string path;
    // Use this for initialization
    void Awake()
    {
        UniLocalNotification.Initialize();
        path = Application.persistentDataPath + "/Resources";
        if (Directory.Exists(path))
        {
            //ディレクトリがある
            if (File.Exists(path + "/TaskCSV.csv"))
            {
                //Taskcsvもある
            }
            else
            {
                InitTaskCSV();
            }

            if (File.Exists(path + "/DayTaskCSV.csv"))
            {
                //DayTaskcsvもあった
            }
            else
            {
                InitDayTaskCSV();
            }
        }
        else //ディレクトリ自体がない場合
        {
            Directory.CreateDirectory(path);
            InitTaskCSV();
            InitDayTaskCSV();
            UniLocalNotification.Register(1, "Resources作った", "報告");
        }
    }
    void Start()
    {
        step_time = 0.0f;       // 経過時間初期化
        taskPush = new TaskPush();
        taskPush.InitPush();
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間をカウント
        step_time += Time.deltaTime;

        // 3秒後に画面遷移（scene2へ移動）
        if (step_time >= 4.0f)
        {
            SceneManager.LoadScene("Title");
        }
    }

    void InitTaskCSV()
    {
        File.Create(path + "/TaskCSV.csv");
        StreamWriter tw = new StreamWriter(path + "/TaskCSV.csv", false, Encoding.GetEncoding("UTF-8"));
        tw.WriteLine("2020,01,01,00,00,サンプル");
        tw.Close();
    }

    void InitDayTaskCSV()
    {
        File.Create(path + "/DayTaskCSV.csv");
        StreamWriter dw = new StreamWriter(path + "/DayTaskCSV.csv", false, Encoding.GetEncoding("UTF-8"));
        dw.WriteLine("23,59,サンプル");
        dw.Close();
    }
}