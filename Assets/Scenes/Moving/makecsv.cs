using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class makecsv : MonoBehaviour
{
    StreamWriter writer;
    StreamReader reader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewDaily()
    {
        writer = new StreamWriter(Application.persistentDataPath + @"\Resources\DayTaskCSV.csv", true, Encoding.GetEncoding("UTF-8"));
        string[] newDaily = new string[3] { "10", "30", "test" };
        string addDaily = string.Join(",", newDaily);
        writer.WriteLine(addDaily);
        writer.Close();
        Debug.Log("add");
    }

    public void ReadDaily()
    {

    }
}
