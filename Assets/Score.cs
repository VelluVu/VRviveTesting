using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score;
    AudioSource sound;
    public GameObject scoreEffect;

    private void Start()
    {
        sound = gameObject.GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        score++;
        Destroy(Instantiate(scoreEffect, transform.position, Quaternion.identity),2f);
        gameObject.GetComponentInChildren<Text>().text = "SCORE : " + score;
        gameObject.GetComponentInChildren<Text>().color = Color.red;
        sound.Play();
        StartCoroutine(Flash(other));
        
    }
    IEnumerator Flash(Collider other)
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponentInChildren<Text>().color = Color.yellow;
        other.gameObject.transform.position = new Vector3(0, 5, 0);
    }
}
