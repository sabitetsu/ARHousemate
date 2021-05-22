using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
   
    InputField inputHour;
    InputField inputMinute;
    InputField inputPlan;

    /// <summary>
    /// Startメソッド
    /// InputFieldコンポーネントの取得および初期化メソッドの実行
    /// </summary>
    void Start()
    {

        inputHour = GetComponent<InputField>();
        inputMinute = GetComponent<InputField>();
        inputPlan = GetComponent<InputField>();

        InitInputField();
    }

    /// <summary>
    /// Log出力用メソッド
    /// 入力値を取得してLogに出力し、初期化
    /// </summary>

    public void InputLogger()
    {

        string inputH = inputHour.text;
        string inputM = inputHour.text;
        string inputP = inputHour.text;


        InitInputField();
    }

    /// <summary>
    /// InputFieldの初期化用メソッド
    /// 入力値をリセットして、フィールドにフォーカスする
    /// </summary>

    void InitInputField()
    {

        // 値をリセット
        inputHour.text = "";
        inputMinute.text = "";
        inputPlan.text = "";

        // フォーカス
        inputHour.ActivateInputField();
        inputMinute.ActivateInputField();
        inputPlan.ActivateInputField();
    }
   

}