using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeText;
    public Text LimitText;
    private float time;
    public float LimitTime;

    private void Update()
    {
        //≈∏¿Ã∏”
        LimitTime -= Time.deltaTime;
        LimitText.text = "" + Mathf.Round(LimitTime);

        time += Time.deltaTime;
        timeText.text = string.Format("{0:N0}", time);

        if(LimitTime <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
