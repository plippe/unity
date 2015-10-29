using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour {

    public float searchTurnSpeed = 120f;
    public float searchDuration = 4f;
    public float sightRange = 20f;

    public Transform[] waypoints;

    public Transform eyes;

    public Vector3 offset = new Vector3(0, .5f, 0);

    public MeshRenderer meshRenderedFlag;

    [HideInInspector]
    public Transform chaseTarget;

    [HideInInspector]
    public IEnemyState currentState;
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public AlertState alertState;
    [HideInInspector]
    public ChaseState chaseState;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    
    void Awake () {
        patrolState = new PatrolState(this);
        alertState = new AlertState(this);
        chaseState = new ChaseState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();
    }
	
    void Start()
    {
        currentState = patrolState;
    }

	void Update () {
        currentState.Update();
	}

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
}
