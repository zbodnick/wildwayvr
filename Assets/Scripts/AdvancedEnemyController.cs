﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AdvancedEnemyController : MonoBehaviour
{
    public GunNew shooter;
    private PlayerController playerController;

    private NavMeshAgent enemy;
    private Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    // Patroling
    public Vector3 walkPoint;
    public float walkPointRange;
    bool walkPointSet;

    public bool isDead = false;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    [SerializeField] private float cooldown = 5;
    private float cooldownTimer;

    private void Awake() {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.Find("XR Rig").transform;
    }

    // Start is called before the first frame update
    void Start() {
        playerController = FindObjectOfType<PlayerController>();
        SetupRagdoll(true);
    }

    Vector3 GetTarget() {
    	// Using transform.LookAt(player); does not work
    	// Must predict player location otherwise enemy miss every shot. Geometry!
        return ((Camera.main.transform.position - shooter.barrelLocation.position) / 3) + new Vector3(0, 0, playerController.speed);
    }

    // Update is called once per frame
    void Update() {

        if (isDead) {
            Dead(transform.position);
        }

	    playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        // if (playerInSightRange && !playerInAttackRange) ChasePlayer();

        if (playerInSightRange) {
			// transform.forward = GetTarget().normalized;
	        lookAtPlayer();
			
			if (playerInAttackRange) {
                Shoot();
	        }
        }

        // if (!playerInSightRange && !playerInAttackRange) Patroling();

    }

    // private void Patroling() {
    //     if (!walkPointSet) SearchWalkPoint();

    //     if (walkPointSet)
    //         enemy.SetDestination(walkPoint);

    //     Vector3 distanceToWalkPoint = transform.position - walkPoint;

    //     //Walkpoint reached
    //     if (distanceToWalkPoint.magnitude < 1f)
    //         walkPointSet = false;
    // }

    // private void SearchWalkPoint() {

    //     //Calculate random point in range
    //     float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //     float randomX = Random.Range(-walkPointRange, walkPointRange);

    //     walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    //     if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
    //         walkPointSet = true;
    // }

    void lookAtPlayer() {
	    transform.forward = Vector3.ProjectOnPlane((Camera.main.transform.position - transform.position), Vector3.up).normalized;
    }

    void SetupRagdoll(bool value) {
        foreach (var item in GetComponentsInChildren<Rigidbody>()) {
            item.isKinematic = value;
        }
    }

    public void Dead(Vector3 hitpoint) {


       // //Call SetColor using the shader property name "_Color" and setting the color to red
        gameObject.transform.Find("Ch36").gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);


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

        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;

        shooter.barrelLocation.forward = GetTarget().normalized;
        shooter.shotPower = GetTarget().magnitude;
        shooter.Shoot();
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}