using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Player")]
public class Player3 : MonoBehaviour {

    // �t��
    public float m_speed = 1;

    // �ͩR
    public float m_life = 3;

    // �l�uprefab
    public Transform m_rocket;

    protected Transform m_transform;

    // �l�u�ɶ����j
    float m_rocketRate = 0;

    // �n��
    public AudioClip m_shootClip;

    // �n����
    protected AudioSource m_audio;

    // �z���S��
    public Transform m_explosionFX;

	// Use this for initialization
	void Start () {

        m_transform = this.transform;

        m_audio = this.audio;
	}
	
	// Update is called once per frame
	void Update () {

        // �a�V���ʶZ��
        float movev=0;

        // ���ǲ��ʶZ��
        float moveh=0;

        // ���W��
        if ( Input.GetKey( KeyCode.UpArrow ) )
        {
            movev -= m_speed * Time.deltaTime;
        }

        // ���U��
        if ( Input.GetKey( KeyCode.DownArrow ) )
        {
            movev += m_speed * Time.deltaTime;
        }

        // ������
        if ( Input.GetKey( KeyCode.LeftArrow ) )
        {
            moveh += m_speed * Time.deltaTime;
        }

        // ���k��
        if ( Input.GetKey( KeyCode.RightArrow ) )
        {
            moveh -= m_speed * Time.deltaTime;
        }

        // ����
        this.m_transform.Translate( new Vector3( moveh, 0, movev ) );


        m_rocketRate -= Time.deltaTime;
        if ( m_rocketRate <= 0 )
        {
            m_rocketRate = 0.1f;

            //���ť���ηƹ�����o�g�l�u
            if ( Input.GetKey( KeyCode.Space ) || Input.GetMouseButton(0) )
            {
                Instantiate( m_rocket, m_transform.position, m_transform.rotation );

                // ����g���n��
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
                // �z���S��
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);

                Destroy(this.gameObject);
            }
        }
    }


}
