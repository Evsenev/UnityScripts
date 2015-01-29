using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// This script working with Text GameObject in new UI of Unity3D ( >= 4.6)
public class FPSMeter : MonoBehaviour
{
	private float updateInterval = 0.5f;
	private int frames = 0;
	private float accum = 0f;
	private float timeleft = 0.0f;

	private Text txtFPS; //Text Object

	private void Start()
	{
		timeleft = updateInterval;
		txtFPS = GetComponent<Text>(); //GetTextObject
	}

	private void Update()
	{
		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;

		if (timeleft <= 0f)
		{
			string fpsText ="FPS: " + (accum/frames).ToString("f2");
			txtFPS.text = fpsText;
			timeleft = updateInterval;
			accum = 0f;
			frames = 0;
		}
	}
}
