using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	public float health=300f;
	
	void OnTriggerEnter2D(Collider2D trigger){
		Laser missile=trigger.gameObject.GetComponent<Laser>();
		if(missile){
			health-=missile.GetDamage();
			missile.Hit ();
			if (health<0){
				Destroy(gameObject);
			}
		}	
	}
		
}
