
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TitleDirector : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonClicked() { 
        SceneManager.LoadScene("AR");
        }
    }

