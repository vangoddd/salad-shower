using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
  public AudioSource SFXSource;
  // Singleton instance.
  public static SoundManagerScript Instance = null;

  public List<AudioClip> clips;

  // Initialize the singleton instance.
  private void Awake()
  {
    // If there is not already an instance of SoundManager, set it to this.
    if (Instance == null)
    {
      Instance = this;
    }
    //If an instance already exists, destroy whatever this object is to enforce the singleton.
    else if (Instance != this)
    {
      Destroy(gameObject);
    }

    //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
    DontDestroyOnLoad(gameObject);
  }

  // Play a single clip through the sound effects source.
  public void Play(int index)
  {
    SFXSource.clip = clips[index];
    SFXSource.Play();
  }

}
