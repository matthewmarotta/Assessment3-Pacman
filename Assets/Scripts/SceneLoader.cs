using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioClip startMusic; // Assign in the Inspector
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (startMusic != null && audioSource != null)
        {
            audioSource.clip = startMusic;
            audioSource.loop = true; // Set the AudioSource to loop
            audioSource.Play(); // Start playing the music
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(0);
    }
}