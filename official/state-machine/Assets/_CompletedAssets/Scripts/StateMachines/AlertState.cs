using UnityEngine;
using System.Collections;

public class AlertState : IEnemyState
{
    private readonly StatePatternEnemy enemy;
    private float searchTimer;
    
    public AlertState(StatePatternEnemy parent)
    {
        enemy = parent;
    }

    public void Update()
    {
        Look();
        Search();
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToPatrolState()
    {
        searchTimer = 0f;
        enemy.currentState = enemy.patrolState;
    }

    public void ToAlertState()
    {
        searchTimer = 0f;
        enemy.currentState = enemy.alertState;
    }

    public void ToChaseState()
    {
        searchTimer = 0f;
        enemy.currentState = enemy.chaseState;
    }

    private void Look()
    {
        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange)
            && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            ToChaseState();
        }
    }

    private void Search()
    {
        enemy.meshRenderedFlag.material.color = Color.yellow;
        enemy.navMeshAgent.Stop();

        enemy.transform.Rotate(0, enemy.searchTurnSpeed * Time.deltaTime, 0);
        searchTimer += Time.deltaTime;

        if(searchTimer > enemy.searchDuration)
        {
            enemy.currentState = enemy.patrolState;
        }
    }
}