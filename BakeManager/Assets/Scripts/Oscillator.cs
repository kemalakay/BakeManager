using UnityEngine;
using System.Collections;

public class Oscillator : MonoBehaviour {
	public Vector3 amplitude = Vector3.forward;
	public float period = 1.0f;
	private Vector3 originalPosition;

	void Start () {
		originalPosition = transform.position;
	}

	Vector3 GetPosition (float t)
	{
		float k = t * 2.0f * Mathf.PI / period;
		return Vector3.Scale ( amplitude, new Vector3 ( Mathf.Sin (k), 0.0f, Mathf.Cos (k)));
	}

	void Update () {
		transform.position = originalPosition + GetPosition (Time.time);
	}


	void OnDrawGizmosSelected () {

		Vector3 origin = transform.position;
		if (Application.isPlaying)
			origin = originalPosition;

		Gizmos.color = Color.red;
		for (int i = 0; i < 100; ++i)
		{
			Gizmos.DrawLine (origin+GetPosition(i*period/100), origin+GetPosition((i+1)*period/100));
		}
	}
}
