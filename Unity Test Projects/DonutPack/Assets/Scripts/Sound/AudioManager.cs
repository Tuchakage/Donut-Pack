using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            Play("MainMenuBGM");
        }

        if (SceneManager.GetActiveScene().name == "IngredientsTutorial" || SceneManager.GetActiveScene().name == "Ingredients")
        {
            Play("Ingredients Tutorial Music");
        }
        if (SceneManager.GetActiveScene().name == "Roll-A-Ball-Tutorial" || SceneManager.GetActiveScene().name == "Roll-A-Ball")
        {
            Play("Roll-A-Ball-BGM");
        }

        if (SceneManager.GetActiveScene().name == "ShakeTutorial" || SceneManager.GetActiveScene().name == "Shake")
        {
            Play("FrostingBGM");
        }

        if (SceneManager.GetActiveScene().name == "Packing")
        {
            Play("PackingBGM");
        }
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Play();
    }

    public void Stop(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;

        s.source.Stop();
    }
}
