using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AdvancedEnemyController : MonoBehaviour
{
    public GunNew shooter;

    private NavMeshAgent enemy;
    private Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    bool canShoot = true;
    public float shootDelaySeconds;

    private void Awake() {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.Find("XR Rig").transform;
    }

    // Start is called before the first frame update
    void Start() {
        SetupRagdoll(false);
        GetComponent<Animator>().enabled = false;
    }

    Vector3 GetTarget() {
    	// Using transform.LookAt(player); does not work
    	// Must predict player location otherwise enemy miss every shot. Geometry!
        return ((Camera.main.transform.position - shooter.barrelLocation.position) / 3) + new Vector3(0, 0, 2);
    }

    // Update is called once per frame
    void Update() {
	    playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange) {
			transform.forward = GetTarget().normalized;
	        // lookAtPlayer();
			
			if (playerInAttackRange && canShoot) {
	        	Shoot();
	        }
        }
        
    }

    void lookAtPlayer() {
	    transform.forward = Vector3.ProjectOnPlane((Camera.main.transform.position - transform.position), Vector3.up).normalized;
    }


    void SetupRagdoll(bool value) {
        foreach (var item in GetComponentsInChildren<Rigidbody>()) {
            item.isKinematic = value;
        }
    }

    void Dead(Vector3 hitpoint) {

        // var enemyRenderer = GetComponent<Renderer>();

       //Call SetColor using the shader property name "_Color" and setting the color to red
       // enemyRenderer.material.SetColor("_Color", Color.red);

        GetComponent<Animator>().enabled = false;
        SetupRagdoll(false);
        foreach (var item in Physics.OverlapSphere(hitpoint,0.5f)) {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb) {
                rb.AddExplosionForce(1000, hitpoint, 0.5f);
            }
        }

        this.enabled = false;
    }

    void Shoot() {

	    shooter.barrelLocation.forward = GetTarget().normalized;
	    shooter.shotPower = GetTarget().magnitude;
	    shooter.Shoot();

        canShoot = false;
        StartCoroutine(ShootDelay());

    }

    // Shoot delay co-routine
     IEnumerator ShootDelay() {
     	yield return new WaitForSeconds(shootDelaySeconds);
     	canShoot = true;
     }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}