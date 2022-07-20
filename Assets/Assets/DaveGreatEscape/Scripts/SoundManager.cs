using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource musicSource, sfxSource;
    private Scene scene, currentmusicscene;
    private void Awake() 
    {
        scene = SceneManager.GetActiveScene();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update() 
    {
        if(SceneManager.GetActiveScene() != scene
            && musicSource.isPlaying)    
        {
            StopMusic();
            scene = SceneManager.GetActiveScene();
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    
    public void PlayMusic(AudioClip music)
    {
       // Debug.Log("Called");
        musicSource.clip = music;
        musicSource.Play();
        currentmusicscene = SceneManager.GetActiveScene();
    }
     public void StopMusic()
     {
        if(SceneManager.GetActiveScene() == currentmusicscene)
        {
            //Debug.Log("~~~Don't Stop The Music~~~");
        }
        else
        {
            musicSource.Stop();
           // Debug.Log("Music stopped!, current scene name: " + scene.name);
        }
     }
}
