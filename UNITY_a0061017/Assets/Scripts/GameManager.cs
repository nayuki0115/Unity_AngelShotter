﻿using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/GameManager")]
public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    //得分
    public int m_score = 0;

    //紀錄
    public static int m_hiscore = 0;

    //主角
    protected Player m_player;

    // 背景音樂
    public AudioClip m_musicClip;

    // 聲音源
    protected AudioSource m_Audio;

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {

        m_Audio = this.audio;

        // 取得主角
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if (obj != null)
        {
            m_player = obj.GetComponent<Player>();
        }
	
	}
	
	// Update is called once per frame
	void Update () {

        // 迴圈播放背景音樂
        if (!m_Audio.isPlaying)
        {
            m_Audio.clip = m_musicClip;
            m_Audio.Play();
           
        }

        // 暫停遊戲
        if (Time.timeScale > 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
        }
	}

    void OnGUI()
    {
        // 遊戲暫停
        if (Time.timeScale == 0)
        {
            // 繼續遊戲按鈕
            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.4f, 100, 30), "继续游戏"))
            {
                Time.timeScale = 1;
            }

            // 退出遊戲按鈕
            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.6f, 100, 30), "退出游戏"))
            {
                // 退出遊戲
                Application.Quit();
            }
        }
        
        int life = 0;
        if (m_player != null)
        {
            // 獲得主角的生命值
            life = (int)m_player.m_life;
        }
        else // game over
        {

            // 放大字體
            GUI.skin.label.fontSize = 50;

            // 顯示遊戲失敗
            GUI.skin.label.alignment = TextAnchor.LowerCenter;
            GUI.Label(new Rect(0, Screen.height * 0.2f, Screen.width, 60), "游戏失败");

            GUI.skin.label.fontSize = 20;

            // 顯示按鈕
            if (GUI.Button(new Rect(Screen.width * 0.5f - 50, Screen.height * 0.5f, 100, 30), "再试一次"))
            {
                // 讀取目前關卡
                Application.LoadLevel(Application.loadedLevelName);
            }
        }

        GUI.skin.label.fontSize = 15;

        // 顯示主角生命
        GUI.Label(new Rect(5, 5, 100, 30), "装甲 " + life);

        // 顯示最高分
        GUI.skin.label.alignment = TextAnchor.LowerCenter;
        GUI.Label(new Rect(0, 5, Screen.width, 30), "纪录 " + m_hiscore);

        // 顯示目前得分
        GUI.Label(new Rect(0, 25, Screen.width, 30), "得分 " + m_score);
      
    }

    // 增加分數
    public void AddScore( int point )
    {
        m_score += point;

        // 更新高分紀錄
        if (m_hiscore < m_score)
            m_hiscore = m_score;
    }
}
