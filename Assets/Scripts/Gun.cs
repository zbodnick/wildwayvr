using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public float speed = 60;
	public GameObject bullet;
	public Transform barrel;
	public AudioSource audioSource;
	public AudioClip audioClip;

    public void Fire() {
        
    	GameObject newBullet = Instantiate(bullet, barrel.position, barrel.rotation);
    	newBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;

    	// Play gun shot sound
		audioSource.PlayOneShot(audioClip);

    	Destroy(newBullet, 3);
    }

}