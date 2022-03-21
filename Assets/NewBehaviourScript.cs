using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioClip musicClipOne;
    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.D))
        {
          musicSource.clip = musicClipOne;
          musicSource.Play();

         }

     if (Input.GetKeyUp(KeyCode.D))
        {
          musicSource.Stop();

         }
     if (Input.GetKeyDown(KeyCode.A))
        {
          musicSource.clip = musicClipOne;
          musicSource.Play();

         }

     if (Input.GetKeyUp(KeyCode.A))
        {
          musicSource.Stop();

         }
    }
}
