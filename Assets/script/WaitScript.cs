using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class WaitScript : MonoBehaviour
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
    public AudioClip v12;
    public AudioClip v13;
    public AudioClip v14;
    public AudioClip v15;
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
                    anim.Play("Yahho");
                    audioSource.PlayOneShot(v4);
                    ChangeFace("OSR");
                    nextAnim = 2;
                    break;
                case 2:
                    anim.Play("Ojigi");
                    audioSource.PlayOneShot(v2);
                    ChangeFace("Fun");
                    nextAnim = 3;
                    break;
                case 3:
                    anim.Play("GohanOfuro");
                    audioSource.PlayOneShot(v7);
                    ChangeFace("Nayami");
                    nextAnim = 4;
                    break;
                case 4:
                    anim.Play("Haraheri");
                    audioSource.PlayOneShot(v14);
                    ChangeFace("Sorrow");
                    nextAnim = 5;
                    break;
                case 5:
                    anim.Play("WIN00");
                    audioSource.PlayOneShot(v10);
                    ChangeFace("BLINK_R");
                    nextAnim = 6;
                    break;
                case 6:
                    anim.Play("MoeMoe");
                    audioSource.PlayOneShot(v5);
                    ChangeFace("Extra");
                    nextAnim = 7;
                    break;
                case 7:
                    anim.Play("Nobi");
                    audioSource.PlayOneShot(v1);
                    ChangeFace("Kyukei");
                    nextAnim = 8;
                    break;
                case 8:
                    anim.Play("Nemui");
                    audioSource.PlayOneShot(v6);
                    ChangeFace("Nemui");
                    nextAnim = 9;
                    break;
                case 9:
                    anim.Play("Nyam");
                    audioSource.PlayOneShot(v9);
                    ChangeFace("Nyao");
                    nextAnim = 10;
                    break;
                case 10:
                    anim.Play("Kick");
                    audioSource.PlayOneShot(v11);
                    ChangeFace("DOYA");
                    nextAnim = 11;
                    break;
                case 11:
                    anim.Play("RUN00");
                    audioSource.PlayOneShot(v12);
                    ChangeFace("ANGRY");
                    nextAnim = 12;
                    break;
                case 12:
                    anim.Play("Minaide");
                    audioSource.PlayOneShot(v8);
                    ChangeFace("Minaide");
                    nextAnim = 13;
                    break;
                case 13:
                    anim.Play("Daisuki");
                    audioSource.PlayOneShot(v13);
                    ChangeFace("JOY");
                    nextAnim = 14;
                    break;
                case 14:
                    anim.Play("Hazukasii");
                    audioSource.PlayOneShot(v3);
                    ChangeFace("Hazukasii");
                    nextAnim = 15;
                    break;
                case 15:
                    anim.Play("Matane");
                    audioSource.PlayOneShot(v15);
                    ChangeFace("Matane");
                    nextAnim = 1;
                    break;
                default:
                    nextAnim = 1;
                    break;
            }
        }
    }
}
