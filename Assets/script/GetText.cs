using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetText : MonoBehaviour
{
    public InputField Hour;
    public InputField Minute;
    public InputField Plan;
    public Text HMPlan; 
     
    
    //入力された予定を合わせて表示
    public void setget()
    {
        int H = int.Parse(Hour.text);
        int M = int.Parse(Minute.text);
       
        //Planが空欄でも入力できてしまう。。。
        if ((H <= 24 && M <= 9) && (Hour != null && Minute != null && Plan != null))
        {
            HMPlan.text = Hour.text + ":" + "0" + Minute.text + "  " + Plan.text;
            Hour.text = null;
            Minute.text = null;
            Plan.text = null;
        }
        else if ((H <= 24 && M <= 59) && (Hour != null && Minute != null && Plan != null))
        {
            HMPlan.text = Hour.text + ":" + Minute.text + "  " + Plan.text;
            Hour.text = null;
            Minute.text = null;
            Plan.text = null;
        }
        else
        {
           
        }
        //時刻の表記エラーは保留
        //絵文字未対応
    }

    public void delete()
    {
        HMPlan.text = null;
    }

}
