using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Player")]
public class Player3 : MonoBehaviour {

    // 速度
    public float m_speed = 1;

    // 生命
    public float m_life = 3;

    // 子彈prefab
    public Transform m_rocket;

    protected Transform m_transform;

    // 子彈時間間隔
    float m_rocketRate = 0;

    // 聲音
    public AudioClip m_shootClip;

    // 聲音源
    protected AudioSource m_audio;

    // 爆炸特效
    public Transform m_explosionFX;

	// Use this for initialization
	void Start () {

        m_transform = this.transform;

        m_audio = this.audio;
	}
	
	// Update is called once per frame
	void Update () {

        // 縱向移動距離
        float movev=0;

        // 水準移動距離
        float moveh=0;

        // 按上鍵
        if ( Input.GetKey( KeyCode.UpArrow ) )
        {
            movev -= m_speed * Time.deltaTime;
        }

        // 按下鍵
        if ( Input.GetKey( KeyCode.DownArrow ) )
        {
            movev += m_speed * Time.deltaTime;
        }

        // 按左鍵
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            moveh += m_speed * Time.deltaTime;
        }

        // 按右鍵
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            moveh -= m_speed * Time.deltaTime;
        }

        // 移動
        this.m_transform.Translate( new Vector3( moveh, 0, movev ) );


        m_rocketRate -= Time.deltaTime;
        if ( m_rocketRate <= 0 )
        {
            m_rocketRate = 0.1f;

            //按空白鍵或滑鼠左鍵發射子彈
            if ( Input.GetKey( KeyCode.Space ) || Input.GetMouseButton(0) )
            {
                Instantiate( m_rocket, m_transform.position, m_transform.rotation );

                // 播放射擊聲音
                m_audio.PlayOneShot(m_shootClip);
            }
        }
       

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") != 0)
        {
            m_life -= 1;

            if (m_life <= 0) 
            {
                // 爆炸特效
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);

                Destroy(this.gameObject);
            }
        }
    }


}
