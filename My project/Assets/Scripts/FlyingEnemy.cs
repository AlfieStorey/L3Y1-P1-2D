using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class FlyingEnemy : MonoBehaviour
{
    public int damage;
    public float moveSpeed;
    public float distance;
    Transform target;
 
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }
 
    void Update()
    {
        float currentDistance = Vector2.Distance(transform.position, target.position);
 
        if(currentDistance < distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}
