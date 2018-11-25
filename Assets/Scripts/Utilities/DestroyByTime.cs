using System.Collections;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
	[SerializeField]
	private float timer;
	
	[Zenject.Inject]
	private IPool pool;

	private void OnEnable()
	{
		StartCoroutine(StartTimer());
	}

	IEnumerator StartTimer()
	{
		yield return new WaitForSeconds(timer);
		pool.Destroy(gameObject);
	}
}
