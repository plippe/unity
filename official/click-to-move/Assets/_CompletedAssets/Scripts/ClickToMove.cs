using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class ClickToMove : MonoBehaviour
    {
        public float shootDistance = 12f;
        public float shootRate = 0.125f;
        public PlayerShooting shootingScript;

        private Animator anim;
        private NavMeshAgent navMeshAgent;
        private Transform targetedEnemy;
        private Ray shootRay;
        private RaycastHit shootHit;
        private bool walking;
        private bool enemyClicked;
        private float nextFire;

        void Awake()
        {
            anim = GetComponent<Animator>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                int distanceCameraFloor = 100;

                if (Physics.Raycast(ray, out hit, distanceCameraFloor))
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        targetedEnemy = hit.transform;
                        enemyClicked = true;
                    }
                    else
                    {
                        enemyClicked = false;
                        navMeshAgent.destination = hit.point;
                        navMeshAgent.Resume();
                    }
                }
            }

            if (enemyClicked)
            {
                MoveAndShoot();
            }

            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                walking = false;
            }
            else
            {
                walking = true;
            }

            anim.SetBool("IsWalking", walking);
        }

        private void MoveAndShoot()
        {
            if (targetedEnemy == null || targetedEnemy.position.y < 0) { return; }

            navMeshAgent.destination = targetedEnemy.position;
            if (navMeshAgent.remainingDistance >= shootDistance)
            {
                navMeshAgent.Resume();
            }
            else
            {
                navMeshAgent.destination = transform.position;
                transform.LookAt(targetedEnemy);

                if (Time.time > nextFire)
                {
                    nextFire = Time.time + shootRate;

                    Vector3 directionToShoot = targetedEnemy.transform.position - transform.position;
                    shootingScript.Shoot(directionToShoot);

                    navMeshAgent.Stop();
                }
            }
        }
    }
}
