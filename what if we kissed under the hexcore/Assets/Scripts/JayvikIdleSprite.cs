using UnityEngine;

public class JayvikIdleSprite : MonoBehaviour
{
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			gameObject.GetComponent<Renderer>().enabled = false;

		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
	}
}
