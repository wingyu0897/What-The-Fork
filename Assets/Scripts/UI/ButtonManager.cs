using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
	public void UnActive(GameObject obj)
	{
		obj.SetActive(false);
	}
	public void Active(GameObject obj)
	{
		obj.SetActive(true);
	}
}
