using UnityEngine;
using System.Collections;

public class BlockBehaviour : MonoBehaviour {


	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0))
		{
			Destroy (this.gameObject);
		}
	}


}
