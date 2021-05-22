using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class WaitScriptShituji: MonoBehaviour
{

    private Animator anim;
    private int nextAnim = 1;
    VRMBlendShapeProxy face;
    string currentFace;

    public AudioClip v1;
    public AudioClip v2;
    public AudioClip v3;
    public AudioClip v4;
    public AudioClip v5;
    public AudioClip v6;
    public AudioClip v7;
    public AudioClip v8;
    public AudioClip v9;
    public AudioClip v10;
    public AudioClip v11;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        this.anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        face = GetComponent<VRM.VRMBlendShapeProxy>();
        currentFace = "Neautral";
    }

    void Update()
    {
        face.Apply();
    }

    void ChangeFace(string preset = "Neutral")
    {
        face.ImmediatelySetValue(currentFace, 0);
        face.ImmediatelySetValue(preset, 1);
        currentFace = preset;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 110, 10, 100, 90), "Motion"))
        {
            switch (nextAnim)
            {
                case 1:
                    anim.Play("Ojigi");
                    audioSource.PlayOneShot(v2);
                    ChangeFace("Ojigi");
                    nextAnim = 2;
                    break;
                case 2:
                    anim.Play("Yubi");
                    audioSource.PlayOneShot(v1);
                    ChangeFace("Kime");
                    nextAnim = 3;
                    break;
                case 3:
                    anim.Play("Osyokuji");
                    audioSource.PlayOneShot(v3);
                    ChangeFace("Ocha");
                    nextAnim = 4;
                    break;
                case 4:
                    anim.Play("Haraheri");
                    audioSource.PlayOneShot(v4);
                    ChangeFace("SORROW");
                    nextAnim = 5;
                    break;
                case 5:
                    anim.Play("Naisyo");
                    audioSource.PlayOneShot(v5);
                    ChangeFace("BLINK_L");
                    nextAnim = 6;
                    break;
                case 6:
                    anim.Play("Fenix");
                    audioSource.PlayOneShot(v6);
                    ChangeFace("ANGRY");
                    nextAnim = 7;
                    break;
                case 7:
                    anim.Play("Nobi");
                    audioSource.PlayOneShot(v7);
                    ChangeFace("JOY");
                    nextAnim = 8;
                    break;
                case 8:
                    anim.Play("Nemui");
                    audioSource.PlayOneShot(v8);
                    ChangeFace("NETAI");
                    nextAnim = 9;
                    break;
                case 9:
                    anim.Play("Minaide");
                    audioSource.PlayOneShot(v9);
                    ChangeFace("Mirareruto");
                    nextAnim = 10;
                    break;
                case 10:
                    anim.Play("Oosenomamani");
                    audioSource.PlayOneShot(v10);
                    ChangeFace("FUN");
                    nextAnim = 11;
                    break;
                case 11:
                    anim.Play("Matane");
                    audioSource.PlayOneShot(v11);
                    ChangeFace("Yoi");
                    nextAnim = 1;
                    break;
                default:
                    nextAnim = 1;
                    break;
            }
        }
    }
}
