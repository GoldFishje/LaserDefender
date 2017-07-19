using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed=1.0f;
	public float padding = 1f;
	public GameObject Laser;
	public float projectileSpeed;
	public float firingRate=0.2f;
	
	float xmin;
	float xmax;


    // Use this for initialization
    void Start () {
		float distance = transform.position.z- Camera.main.transform.position.z;
		
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin=leftmost.x+padding;
		xmax=rightmost.x-padding;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire",0.000001f,firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke();
		}
		MovePlayer();
	}
	
	void MovePlayer(){
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position+= Vector3.left*speed*Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)){
			transform.position+= Vector3.right*speed*Time.deltaTime;
		}
		//restrict the player to the gamespace
		float newX=Mathf.Clamp(transform.position.x,xmin,xmax);
		transform.position=new Vector3(newX,transform.position.y,transform.position.z);
	}
	
	void Fire(){
			GameObject projectile=Instantiate(Laser,transform.position,Quaternion.identity) as GameObject;
			projectile.rigidbody2D.velocity=new Vector3(0,projectileSpeed,0);
			
			
			
			//enemy.transform.parent=child; //add instantiated object under the parent	
	
	}
	
	
}
