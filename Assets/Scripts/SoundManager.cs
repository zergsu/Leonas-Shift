using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;
        
    [SerializeField] AudioClip jumpSound, textSound1, textSound2, textSound3, playerDamage, door, cat;

    [Header("Audio Source")]
    [SerializeField] AudioSource audioSrc;

    [Header("Mixers")]
    [SerializeField] AudioMixer musicMixer;
    [SerializeField] AudioMixer soundsMixer;

	private void Awake() {
        instance = this;
	}

	void Start() {
        musicMixer.SetFloat("MyExposedParam", PlayerPrefs.GetFloat("Music"));
        soundsMixer.SetFloat("MyExposedParam", PlayerPrefs.GetFloat("Sound"));
    }


    public void PlaySound(string clip) {
        switch (clip) {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "damage":
                audioSrc.PlayOneShot(playerDamage);
                break;
            case "text1":
                audioSrc.PlayOneShot(textSound1);
                break;
            case "text2":
                audioSrc.PlayOneShot(textSound2);
                break;
            case "text3":
                audioSrc.PlayOneShot(textSound3);
                break;
            case "door":
                audioSrc.PlayOneShot(door);
                break;
            case "cat":
                audioSrc.PlayOneShot(cat);
                break;
        }
    }

    public void StopSound() {
        audioSrc.Stop();
    }
}




