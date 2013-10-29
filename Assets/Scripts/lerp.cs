using UnityEngine;
using System.Collections;

public class lerp : MonoBehaviour {
	
	public Vector3 start, end;

	// Use this for initialization
	void Start () {
		
		StartCoroutine (PlatformLerp());
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator PlatformLerp(){
		
		while(true){
			float t = Mathf.Abs (Mathf.Sin (Time.time));
			transform.position = Vector3.Lerp(start, end,t);
			yield return 0;
		}
	}
}
