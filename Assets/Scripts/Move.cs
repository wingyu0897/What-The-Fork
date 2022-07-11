using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rigid2D;

	private float rotTime = 1.0f;
	private bool isGo = true;

	private void Awake()
	{
		rigid2D = GetComponent<Rigidbody2D>();
		rigid2D.velocity = transform.up * 5f;
	}

	void Update()
    {
		if (rotTime > 0)
		{
			rotTime -= Time.deltaTime;
		}
		if (isGo) { 
			transform.up = rigid2D.velocity;    
		}
		Click();
		if (Input.GetMouseButtonDown(1) && rotTime <= 0)
		{
			rotTime = 1.0f;
			isGo = false;
			//rigid2D.velocity = new Vector2(0, 0);
			//rigid2D.AddTorque(1.1f, ForceMode2D.Impulse);
			rigid2D.angularVelocity = 600f;
		}
    }

	private void Click()
	{
		if (Input.GetMouseButtonDown(0))
		{
			isGo = true;
			rigid2D.velocity = transform.up * 4f;
			rigid2D.angularVelocity = 0f;
		}
	}
}
