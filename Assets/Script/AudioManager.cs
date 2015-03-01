using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	private static AudioManager _instance;
	
	public static AudioManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<AudioManager>();
			}
			return _instance;
		}
	}

	public AudioClip ballHit;
	public AudioClip build;
	public AudioClip reload;
	public AudioClip menuSelect;
	public AudioClip menuShift;
	public AudioClip Success;
	public AudioClip Scream;
	
	public void playBallHitSound(){
		audio.PlayOneShot(ballHit);
	}
	public void playBuildSound(){
		audio.PlayOneShot(build);
	}
	public void playReloadSound(){
		audio.PlayOneShot(reload);
	}
	public void playMenuSelectSound(){
		audio.PlayOneShot(menuSelect);
	}
	public void playMenuShiftSound(){
		audio.PlayOneShot(menuShift);
	}
	public void playSuccessSound(){
		audio.PlayOneShot(Success);
	}
	public void playScreamSound(){
		audio.PlayOneShot(Scream);
	}
}
