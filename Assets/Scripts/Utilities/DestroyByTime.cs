using System.Collections;
using CalongeCore.ObjectsPool;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
	[SerializeField]
	private float timer;

	private void OnEnable()
	{
		StartCoroutine(StartTimer());
	}

	IEnumerator StartTimer()
	{
		yield return new WaitForSeconds(timer);
		GodPoolSingleton.Instance.Destroy(gameObject);
	}
}
