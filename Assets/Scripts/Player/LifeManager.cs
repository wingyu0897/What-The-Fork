using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    private PlayerController myController;
    private Rigidbody2D myRigid;
	private bool gameEnd = false; //���� ����

	private void Awake() //���۽� ��ũ ����
	{
		myController = GetComponent<PlayerController>();
		myRigid = GetComponent<Rigidbody2D>();
		myController.enabled = false;
		myRigid.gravityScale = 0f;
		myRigid.velocity = Vector2.zero;
		myRigid.angularVelocity = 0f;
	}

	private void OnCollisionEnter2D(Collision2D collision) //�浹�� ��ũ ����
	{
		myController.enabled = false;
		myRigid.velocity = Vector2.zero;
		myRigid.angularVelocity = 0f;
		myRigid.gravityScale = 0f;
		if (collision.gameObject == GameObject.Find("Food")) Debug.Log("Success!");
		else Debug.Log("Fail!");
	}

	public void GameReady()
	{

	}

	public void GameStart() //���� ���� �Լ�
	{
		myController.enabled = true;
	}
}
