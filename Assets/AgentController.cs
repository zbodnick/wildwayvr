﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{

	public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    	NavMeshAgent agent = GetComponent<NavMeshAgent>();
    	agent.destination = target.position;
        
    }
}
