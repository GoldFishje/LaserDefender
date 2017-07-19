using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 2f;
	public float height = 5f;
	public float speed = 5f;
	
	private bool movingRight=true;

	private float xmax;
	private float xmin;
	
	// Use this for initialization
	void Start () {
		float distanceToCamera= transform.position.z-Camera.main.transform.position.z;
		Vector3 leftBoundary=Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera));
		Vector3 rightBoundary=Camera.main.ViewportToWorldPoint(new Vector3(1,0,distanceToCamera));
		xmin=leftBoundary.x;
		xmax=rightBoundary.x;
		foreach ( Transform child in transform){
			GameObject enemy= Instantiate(enemyPrefab,child.transform.position,Quaternion.identity) as GameObject;
			enemy.transform.parent=child; //add instantiated object under the parent
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
	}
	
	
	// Update is called once per frame
	void Update () {
		MoveEnemyFormation();
	}
	
	void MoveEnemyFormation(){

		
		if (movingRight){
			transform.position+= Vector3.right*speed*Time.deltaTime;
		} else{
			transform.position+= Vector3.right*-speed*Time.deltaTime;
		}
		
		float rightEdgeOfFormation = transform.position.x+(0.5f*width);
		float leftEdgeOfFormation = transform.position.x-(0.5f*width);
		
		if(leftEdgeOfFormation<xmin){
			movingRight=true;
		}else if (rightEdgeOfFormation>xmax){
			movingRight=false;
		}		
		
			
	}
}
