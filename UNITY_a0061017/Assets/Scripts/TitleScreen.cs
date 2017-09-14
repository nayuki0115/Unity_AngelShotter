using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/TitleScreen")]
public class TitleScreen : MonoBehaviour
{

    void OnGUI()
    {
        // ��r�j�p
        GUI.skin.label.fontSize = 48;

        // UI���߹��
        GUI.skin.label.alignment = TextAnchor.LowerCenter;

        // ��ܼ��D
        GUI.Label(new Rect(0, 30, Screen.width, 100), "�ӪŤj��");


        // �}�l�C�����s
        if (GUI.Button(new Rect(Screen.width * 0.5f - 100, Screen.height * 0.7f, 200, 30), "�}�l�C��"))
        {
            // �}�lŪ���U�@��
            Application.LoadLevel("level1");
        }
    }
}
