using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class FaceChange : MonoBehaviour
{
    BlendShapePreset currentFace;
    VRMBlendShapeProxy proxy;
    private int nextAnim = 1;

    void Start()
    {
        proxy = GetComponent<VRMBlendShapeProxy>();
        currentFace = BlendShapePreset.Neutral;
        proxy.AccumulateValue(currentFace, 1);
    }

    // Update is called once per frame
    void Update()
    {
        proxy.Apply();
    }

    public void ChangeFace(BlendShapePreset preset = BlendShapePreset.Neutral)
    {
        proxy.AccumulateValue(currentFace, 0);  //今の表情を無効化する
        proxy.AccumulateValue(preset, 1);    //新しい表情をセットする
        currentFace = preset;
    }

    [System.Obsolete]
    void OnGUI()
    {
        var face = this.GetComponent<VRM.VRMBlendShapeProxy>();

        if (GUI.Button(new Rect(Screen.width - 110, 10, 100, 90), "Motion"))
        {
            switch (nextAnim)
            {
                case 1:

                    ChangeFace(BlendShapePreset.Angry);
                    nextAnim = 2;
                    break;
                case 2:

                    ChangeFace(BlendShapePreset.Sorrow);

                    nextAnim = 3;
                    break;
                case 3:

                    ChangeFace(BlendShapePreset.Fun);

                    nextAnim = 4;
                    break;
                case 4:

                    // proxy.SetValue("Angry", 1);
                    proxy.ImmediatelySetValue("Fun", 0);
                    proxy.ImmediatelySetValue("OSR", 1);

                    //ChangeFace();
                    nextAnim = 5;
                    break;
                case 5:
                    // proxy.SetValue("OSR", 0);
                    proxy.ImmediatelySetValue("OSR", 0);
                    proxy.ImmediatelySetValue("NEUTRAL", 1);
                    // proxy.SetValue("NEUTRAL", 1);
                    //ChangeFace();
                    nextAnim = 1;
                    break;
            }
        }
    }
}
