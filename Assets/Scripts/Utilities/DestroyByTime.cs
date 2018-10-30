using System.Collections;
using ObjectsPool;
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
		GodPool.Instance.ReturnPoolObject(gameObject);
	}
}
