using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlatA : MonoBehaviour
{
    public Transform posA, posB;
    public int speed;
    Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.1f)
        {
            targetPos = posB.position;
        }
        if (Vector2.Distance(transform.position, posB.position) < 0.1f)
        { 
            targetPos = posA.position;
    }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
 }

}

