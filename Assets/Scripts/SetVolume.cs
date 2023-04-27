using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
	[SerializeField] AudioMixer mixer;

	private void Start() {
		gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat(gameObject.tag + "slider"); ;
	}

	public void SetLevel(float sliderValue) {
		PlayerPrefs.SetFloat(gameObject.tag + "slider", sliderValue);
		PlayerPrefs.SetFloat(gameObject.tag, Mathf.Log10(sliderValue) * 20);
		mixer.SetFloat("MyExposedParam", Mathf.Log10(sliderValue) * 20);
	}
}
