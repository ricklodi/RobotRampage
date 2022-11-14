using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 10;
    //1When you instantiate a missile, you start a coroutine called deathTimer(). This is name of the method that the coroutine will call.
    void Start()
    {
        StartCoroutine("deathTimer");
    }
    // 2 Move the missile forward at speed multiplied by the time between frames.
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.GetComponent<Player>() != null
        && collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    // 3 You'll notice that the method immediately returns a WaitForSeconds, set to 10. Once  those 10 seconds have passed, the method will resume after the yield statement.If the missile doesn’t hit the player, it should auto-destruct.
        IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

}
