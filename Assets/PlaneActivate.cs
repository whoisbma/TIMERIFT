using UnityEngine;
using System.Collections;

public class PlaneActivate : MonoBehaviour {

	public float curAngle = 0.0f;
	private float triggerDegrees = 10.0f;
	private float bufferDegrees = 5.0f;
	private float lastTransitionAngle = 0.0f;
	private float differenceDegrees = 0.0f;


	public Transform curFramePlane;
	public Transform nextFramePlane;
	public Transform transFramePlane;
	
	private const int frameCount = 5;
	private Texture2D[] frames; 

	private bool isUpdating = false;
	private enum TransitionDirection {advancing, retreating};
	private TransitionDirection updateDirection;

	// Use this for initialization
	void Start () {
		// init frames array and fill wth Texture2D objects of frames of the video
		Texture2D[] frames = new Texture2D[frameCount];
		for (int i = 0; i < frameCount; i++) {

		}
	}
	
	// Update is called once per frame
	void Update () {
//		p1.gameObject.SetActive(true);
		curAngle = transform.eulerAngles.y;
		differenceDegrees = curAngle - lastTransitionAngle;
		Debug.Log (curAngle);

		// transition animation
		if (isUpdating) {
			
		}

		// decide whether to trigger
		else if (Mathf.Abs (differenceDegrees) > triggerDegrees) {
//			isUpdating = true;
			if (differenceDegrees < 0.0f) {
				updateDirection = TransitionDirection.retreating;
			} else {
				updateDirection = TransitionDirection.advancing;
			}
		}

	}

	// ask bryan about animation paradigm - just adjust completion amount on each update?
}