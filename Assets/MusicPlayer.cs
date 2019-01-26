using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    public List<AudioClip> musat = new List<AudioClip>();
    public List<GameObject> balls = new List<GameObject>();
    public Canvas c;
    AudioSource musa;
    bool gameOver;
    int counter = 0;

    // Use this for initialization
    void Start () {
        musa = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

      

       StartCoroutine(CheckBalls());

       GameOver();

       MusaValitsin();

    }

    IEnumerator CheckBalls()
    {
        
        foreach (var item in balls)
        {
            
            if (!item)
            {
                counter++;
                
            }
            if (counter == balls.Count)
            {
                gameOver = true;
                
            }
            
        }
        counter = 0;

        yield return new WaitForSeconds(2f);
    }

    public void GameOver()
    {

        if (gameOver == true)
        {
            c.gameObject.SetActive(true);
            Debug.Log("PALLOT LOPPU");
            gameOver = true;
            StopAllCoroutines();
            int rng = Random.Range(1, 2);
            if (rng == 1)
            {
                musa.clip = musat[0];
            } else if (rng == 2)
            {
                musa.clip = musat[4];
            }

            if (musa.isPlaying == false)
            {
                
                StartCoroutine(LoppuBiisi());             
            }
        }

    }

    public void MusaValitsin()
    {
           
        if (musa.isPlaying == false && gameOver == false)
        {
            StartCoroutine(Biisi());
        }
    }

    IEnumerator LoppuBiisi()
    {

        
        musa.Play();
        yield return new WaitForSeconds(musa.clip.length);

    }

    IEnumerator Biisi()
    {
        musa.clip = musat[Random.Range(1, 3)];
        musa.Play();
        yield return new WaitForSeconds(musa.clip.length);

    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
