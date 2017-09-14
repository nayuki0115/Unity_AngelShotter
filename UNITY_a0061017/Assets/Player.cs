using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float m_speed = 1;
	public float m_life = 3;
	
	public AudioClip m_shootClip;
	protected AudioSource m_audio;	
	public Transform m_explosionFX;
	
	public Transform m_rocket;
	public float m_rocketRate = 0;
	
	protected Transform m_transform;
	
	
	// Use this for initialization
	void Start () {
		m_transform = this.transform;
		m_audio = this.audio;
	}
	
	// Update is called once per frame
	void Update () {
		float movev = 0;
		float moveh = 0;
		
		if(Input.GetKey(KeyCode.UpArrow))
		{
			movev -= m_speed*Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			movev+=m_speed*Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			moveh+=m_speed*Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			moveh-=m_speed*Time.deltaTime;
		}
		m_transform.Translate(new Vector3(moveh,0,movev));
		
		m_rocketRate -= Time.deltaTime;
		if(m_rocketRate<=0)
		{
			m_rocketRate=0.1f;		
			if(Input.GetKey(KeyCode.Space)||Input.GetMouseButton(0))
			{
				Instantiate(m_rocket,m_transform.position,m_transform.rotation);
				m_audio.PlayOneShot(m_shootClip);
			}
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag.CompareTo("PlayerRocket")!=0)
		{
			m_life-=1;
			
			if(m_life<=0)
			{
				Destroy(this.gameObject);
				Instantiate(m_explosionFX,m_transform.position, Quaternion.identity);
			}
		}
	}
}
