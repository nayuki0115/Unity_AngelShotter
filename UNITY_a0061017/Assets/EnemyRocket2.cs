using UnityEngine;
using System.Collections;

public class EnemyRocket2 : Rocket2 {

	void OnTriggerEnter(Collider other)
	{
		if(other.tag.CompareTo("Player")!=0)
			return;
		Destroy(this.gameObject);
	}
}
