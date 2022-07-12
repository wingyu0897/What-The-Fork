using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] [Range(100.0f, 1000.0f)] private float rotSpeed = 600.0f;
	[SerializeField] private float rotTime = 1.0f;
	private bool canRot = true;
	[SerializeField] private float dashTime = 1.0f;
	private bool canDash = true;
	private bool isDash = true;

    private Rigidbody2D rigid2D;

	private void Awake()
	{
		rigid2D = GetComponent<Rigidbody2D>();
		rigid2D.gravityScale = 0f;
	}

	private void OnEnable()
	{
		rigid2D.velocity = transform.up * 4f;
		rigid2D.gravityScale = 0.3f;
	}

	void Update()
    {
		if (isDash) transform.up = rigid2D.velocity;
    }

	public void Rotation()
	{
		if (canRot && enabled) {
			canRot = false;
			StartCoroutine(RotCoolTime());
			rotTime = 1.0f;
			isDash = false;
			rigid2D.angularVelocity = rotSpeed;
		}
	}

	public void Dash()
	{
		if (canDash && enabled) {
			canDash = false;
			StartCoroutine(DashCoolTime());
			rigid2D.velocity = transform.up * 4f;
			rigid2D.angularVelocity = 0f;
			isDash = true;
		}
	}

	IEnumerator RotCoolTime() {
		yield return new WaitForSeconds(rotTime);
		canRot = true;
	}
	IEnumerator DashCoolTime() {
		yield return new WaitForSeconds(dashTime);
		canDash = true;
	}
}
