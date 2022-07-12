using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs4 : MonoBehaviour
{
    [HideInInspector] public float delaytime;
    [HideInInspector] public float distance;
    private float dis;
    private float currentTime = 0.0f;
    private float delayTime = 0.0f;
    private Vector3 a;
    private Vector3 b;
    private float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        dis = distance;
        delayTime = delaytime;
        a = transform.position;
        b = new Vector3(transform.position.x, transform.position.y + distance, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        currentTime += Time.deltaTime;
        if(currentTime >= delayTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(a, b, t);
            if(t >= 1)
            {
                Vector3 temp = a;
                a = b;
                b = temp;
                t = 0;
                currentTime = 0;
            }
        }

    }
}
