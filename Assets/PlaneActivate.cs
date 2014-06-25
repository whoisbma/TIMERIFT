using UnityEngine;
using System.Collections;

public class PlaneActivate : MonoBehaviour {

	public float angle;

	public Transform p1;
	public Transform p2;
	public Transform p3;
	public Transform p4;
	public Transform p5;

	private float initOffset = 5.0f;
	private float offset = 10.0f;
	private float y5;
	private float y10;
	private float y15;
	private float y20;
	private float y25;

	// Use this for initialization
	void Start () {
		y5 = initOffset;
		y10 = y5 + offset;
		y15 = y10 + offset;
		y20 = y15 + offset;
		y25 = y20 + offset;
	}
	
	// Update is called once per frame
	void Update () {

//		angle = transform.rotation.y;
		angle = transform.eulerAngles.y;
		Debug.Log (angle); 
		if (angle >= y5 && angle < y10) {
			p1.gameObject.SetActive(false); 
			p2.gameObject.SetActive(true); 
		} else if (angle >= y10 && angle < y15) {
			p2.gameObject.SetActive(false); 
			p3.gameObject.SetActive(true); 
		} else if (angle >= y15 && angle < y20) {
			p3.gameObject.SetActive(false); 
			p4.gameObject.SetActive(true); 
		} else if (angle >= y20 && angle < y25) {
			p4.gameObject.SetActive(false); 
			p5.gameObject.SetActive(true); 
		} 

		if (angle < y5) { 
			p1.gameObject.SetActive(true);
		}
	}
}
