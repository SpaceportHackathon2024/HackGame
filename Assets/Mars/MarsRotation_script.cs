using UnityEngine;

public class MarsRotation_script : MonoBehaviour {

	public float earthRotationSpeed = 2.0f;
	

	void Update()
	{
		transform.Rotate(new Vector3(0, Time.deltaTime * earthRotationSpeed, 0));

	}
}
