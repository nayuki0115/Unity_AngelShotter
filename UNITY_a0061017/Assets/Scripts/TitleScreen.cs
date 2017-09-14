using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/TitleScreen")]
public class TitleScreen : MonoBehaviour
{

    void OnGUI()
    {
        // 文字大小
        GUI.skin.label.fontSize = 48;

        // UI中心對齊
        GUI.skin.label.alignment = TextAnchor.LowerCenter;

        // 顯示標題
        GUI.Label(new Rect(0, 30, Screen.width, 100), "太空大戰");


        // 開始遊戲按鈕
        if (GUI.Button(new Rect(Screen.width * 0.5f - 100, Screen.height * 0.7f, 200, 30), "開始遊戲"))
        {
            // 開始讀取下一關
            Application.LoadLevel("level1");
        }
    }
}
