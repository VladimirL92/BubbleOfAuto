using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] Musics;
    public TMP_Text Title;

    private AudioSource AudioSource;
    private int AudioNum;

    private void Start()
    {
        AudioNum =  PlayerPrefs.GetInt("Audio", 0);
        AudioSource = GetComponent<AudioSource>();
        AudioSource.clip = Musics[AudioNum];
        AudioSource.Play();
        AudioSource.loop = true;
        Title.text = AudioSource.clip.name;
    }

    public void NextTrack()
    {
        AudioNum++;

        if (AudioNum > Musics.Length - 1)
        {
            AudioNum = 0;
        }

        AudioSource.Stop();
        AudioSource.clip = Musics[AudioNum];
        AudioSource.Play();
        Title.text = AudioSource.clip.name;
        PlayerPrefs.SetInt("AudioTrack", AudioNum);
        PlayerPrefs.Save();

    }
}

