using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocationer : MonoBehaviour
{
    private GameObject target;

	private void Awake()
	{
		target = GameObject.Find("Food");
	}

	private void Update()
	{
		Vector2 aaa = target.transform.position - transform.position;

		float angle = Mathf.Atan2(aaa.y, aaa.x);

		transform.eulerAngles = new Vector3(0, 0, angle);
	}
}
