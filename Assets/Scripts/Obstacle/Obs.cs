using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs : MonoBehaviour
{
    [SerializeField]
    [Tooltip("1 = 떨어지는 장애물\n2 = 플레이어에게 날아오는 장애물\n3 = 옆으로 날아가는 장애물\n4 = 위로 튀어나오는 장애물")]
    private int obsType = 0;
    [SerializeField]
    [Tooltip("3 Only\n(Default = Left)")]
    private bool reverse = false;
    [SerializeField]
    [Tooltip("4 Only")]
    private float distance = 0.0f;
    [SerializeField]
    [Tooltip("4 not use")]
    private GameObject obsPrefab;
    [SerializeField] private float delayTime = 0.0f;
    
    // Start is called before the first frame update
    void Awake()
    {
        switch(obsType)
        {
            case 1:
                StartCoroutine("obs1");
                break;
            case 2:
                StartCoroutine("obs2");
                break;
            case 3:
                StartCoroutine("obs3");
                break;
            case 4:
                Obs4 obs4 = GetComponent<Obs4>();
                obs4.delaytime = delayTime;
                if(reverse) obs4.distance = -distance;
                else obs4.distance = distance;
                
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator obs1()
    {
        while(true)
        {
            GameObject obs = Instantiate(obsPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delayTime);
        }       
    }
    IEnumerator obs2()
    {
        while(true)
        {
              GameObject obs = Instantiate(obsPrefab, transform.position, Quaternion.identity);
              obs.GetComponent<ObsMove>().speed = 1;
              obs.GetComponent<ObsMove>().dir = GameObject.Find("Fork").transform.position - obs.transform.position;
              yield return new WaitForSeconds(delayTime);
        }
    }
    IEnumerator obs3()
    {
        while(true)
        {
            GameObject obs = Instantiate(obsPrefab, transform.position, Quaternion.identity);
            obs.GetComponent<ObsMove>().speed = 1;
            
            if(reverse) obs.GetComponent<ObsMove>().dir = new Vector3(10,0,0);
            else obs.GetComponent<ObsMove>().dir = new Vector3(-10,0,0);
            
              yield return new WaitForSeconds(delayTime);
        }
    }

}
