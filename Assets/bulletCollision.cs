using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{

	public float speed = 20f;
	 public int damage = 10;
	 public Rigidbody2D rb;
	 public GameObject Enemy;
	 public GameObject impactEffect;
	
	 void Start () {
	 }
	 
    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // private void OnCollisionEnter(Collision collision) {
    //      if (collision.transform.tag == "Enemy")
    //      {
    //          // do damage here, for example:
    //          collision.gameObject.GetComponent<AdvancedEnemyController>().Dead(5);
    //      }
    //  }
 }

 