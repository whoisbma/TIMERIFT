using UnityEngine;
using System.Collections;

public class FrameManager : MonoBehaviour {

	public float curAngle = 0.0f;
	private float triggerDegrees = 10.0f;
	private float bufferDegrees = 5.0f;
	private float lastTransitionAngle = 0.0f;
	private float differenceDegrees = 0.0f;


	public Transform curFramePlaneTransform;
	public Transform nextFramePlaneTransform;
	public Transform transFramePlaneTransform;
	public Transform capsuleTransform;

	private Vector3 planeOffset = new Vector3 (0.0f, 0.0f, 1.5f);

	public Material curFrameMat;
	public Material nextFrameMat;
	public Material shutterMat;
	
	private const int frameCount = 5;
	private Texture2D[] frames; 
	private int curFrame = 0;

	private bool isUpdating = false;
	private enum TransitionDirection {advancing, retreating};
	private TransitionDirection updateDirection;
	
	void Start () {
		frames = new Texture2D[frameCount];
		for (int i = 0; i < frameCount; i++) {

			frames[i] = new Texture2D (1080, 1920, TextureFormat.RGB24, false);
//			frames [i] = new Texture2D (2048, 2048, TextureFormat.RGB24, false);

			string pathPrefix = @"file://";
			string assetPath = Application.dataPath;
			string pathFolders = @"/Textures/VideoFrames/";
			string fileName = string.Format ("{0}", i);
			string fileSuffix = @".jpg";

			string fullFilename = pathPrefix + assetPath + pathFolders + fileName + fileSuffix;
			Debug.Log (fullFilename);
			WWW www = new WWW (fullFilename);
			www.LoadImageIntoTexture (frames [i]);
		}

		curFrameMat.mainTexture = frames[0];
	}

	void Update () {
//		p1.gameObject.SetActive(true);
		curAngle = transform.eulerAngles.y;
		differenceDegrees = curAngle - lastTransitionAngle;
//		Debug.Log (curAngle);

		// transition animation
		if (isUpdating) {
			
		}

		// decide whether to trigger
		else if (Mathf.Abs (differenceDegrees) > triggerDegrees) {
//			isUpdating = true;
			if (differenceDegrees < 0.0f) {
				updateDirection = TransitionDirection.retreating;
				curFrame--;
			} else {
				updateDirection = TransitionDirection.advancing;
				curFrame++;
			}

			if (curFrame < 0) {
				curFrame = 0;
			} else if (curFrame >= frameCount) {
				curFrame = frameCount - 1;
			}

			lastTransitionAngle = curAngle;
			curFrameMat.mainTexture = frames[curFrame];
		}
	
		// TEMP
		// reset curframePlane position relative to capsule
		curFramePlaneTransform = capsuleTransform;
		curFramePlaneTransform.Translate (planeOffset, Space.Self);

	}	

}