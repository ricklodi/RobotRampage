using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.VersionControl;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    GameObject missileprefab;
    [SerializeField]
    private string robotType;
    public int health;
    public int range;
    public float fireRate;
    public Transform missileFireSpot;
    UnityEngine.AI.NavMeshAgent agent;
    private Transform player;
    private float timeLastFired;
    private bool isDead;
    public Animator robot;
    // Start is called before the first frame update
    void Start()
    {
        //By default, all robots are alive. You then set the agent and player values to the NavMesh Agent and Player components respectively.
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // 1
    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        }
        health -= amount;
        if (health <= 0)
        {
            isDead = true;
            robot.Play("Die");
            StartCoroutine("DestroyRobot");
        }
    }
    // 2
    IEnumerator DestroyRobot()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    void Update()
    {
        // Check if the robot is dead before continuing.
        if (isDead)
        {
            return;
        }
        // Make the robot face the player.
        transform.LookAt(player);
        // Tell the robot to use the NavMesh to find the player.
        agent.SetDestination(player.position);
        // 5 Check to see if the robot is within firing range and if there’s been enough time between shots to fire again.
        if (Vector3.Distance(transform.position, player.position) < range
        && Time.time - timeLastFired > fireRate)
        {
            // 6 Update timeLastFired to the current time and call Fire(), which simply logs a message to the console for the time being.
                        timeLastFired = Time.time;
            fire();
        }
    }
    private void fire()
    {
        GameObject missile = Instantiate(missileprefab);
        missile.transform.position = missileFireSpot.transform.position;
        missile.transform.rotation = missileFireSpot.transform.rotation;
        robot.Play("Fire");
    }
}
