using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMove : MonoBehaviour
{
    public float speed = 0.0f;
    public Vector3 dir = new Vector3(0,0,0);
    // Start is calle   d before the first frame update
    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
