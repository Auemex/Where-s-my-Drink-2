using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scr_BlobFish : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    public float EnemyDistanceRun = 4.0f;
    [SerializeField]
    GameObject player;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
        private void Update()
    {
        RunAwayFromPlayer();
    }
    public void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButton(0) && other.tag == "CatchPlane")
        {
            Destroy(gameObject);
            Debug.Log("oh no I die :(");
            player.GetComponent<scr_NpcTalk>().SetCountText(1);
        }
    }
    void RunAwayFromPlayer ()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log ("Distance: " + distance);

        if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;

            agent.SetDestination(newPos);

        }
    }
}
