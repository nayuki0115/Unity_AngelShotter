using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Enemy")]
public class Enemy : MonoBehaviour {

    // 速度
    public float m_speed = 1;

    // 生命
    public float m_life = 10;

    // 旋轉速度
    protected float m_rotSpeed = 30;

    // 變向間隔時間
    protected float m_timer = 1.5f;

    protected Transform m_transform;

    public Transform m_explosionFX;

    public int m_point = 10;

	// Use this for initialization
	void Start () {

        m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

        UpdateMove();
	}

    protected virtual void UpdateMove()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            m_timer = 3;

            //改變旋轉方向
            m_rotSpeed = -m_rotSpeed;
        }

        // 旋轉方向
        m_transform.Rotate(Vector3.up, m_rotSpeed * Time.deltaTime, Space.World);

        // 前進
        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("PlayerRocket") == 0)
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket != null)
            {
                m_life -= rocket.m_power;

                if (m_life <= 0)
                {
                    GameManager.Instance.AddScore(m_point);

                    Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
            }
        }
        else if (other.tag.CompareTo("Player") == 0)
        {
            m_life = 0;
            Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        
        if (other.tag.CompareTo("bound") == 0)
        {
            m_life = 0;
            Destroy(this.gameObject);
        }
    }
}
