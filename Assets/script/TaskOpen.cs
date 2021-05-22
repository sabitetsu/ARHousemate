using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskOpen : MonoBehaviour
{
    //Panelの表示切り替え
    public GameObject Panel;
    public void OpenTask()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
            // Panel.SetActive(true);
        }
    }


}
