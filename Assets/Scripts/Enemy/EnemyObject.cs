using UnityEngine.AI;

public class EnemyObject : PoolableObject {
	public EnemyController Controller;
    public NavMeshAgent Agent;
    public int Health = 100;

    public override void OnDisable()
    {
        base.OnDisable();

        Agent.enabled = false;
    }
}