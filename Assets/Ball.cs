using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public AudioClip dropSound;
    public AudioClip bounceSound;
    AudioSource sound;
	// Use this for initialization
	void Start () {
        sound = gameObject.GetComponent<AudioSource>(); 
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.localPosition.y <= -3)
        {
            
            if (sound.isPlaying == false)
            {
                sound.spatialBlend = 0.0f;
                sound.clip = dropSound;
                sound.Play();
            }
            StartCoroutine(LoseBall());
        }
	}
    IEnumerator LoseBall()
    {
        
        yield return new WaitForSeconds(sound.clip.length);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

        sound.spatialBlend = 1.0f;
        sound.clip = bounceSound;
        if (sound.isPlaying == false)
        {
            sound.Play();
        }

    }
}

