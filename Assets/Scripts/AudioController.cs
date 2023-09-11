using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private AudioClip[] fallingClips;
    [SerializeField] private AudioClip itemCollected;
    [SerializeField] private AudioClip failToCollect;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip themeMusic;
    public static AudioController Instance { get; private set; }

    private int nextClipIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static AudioClip[] FallingClips => Instance.fallingClips;
    public static AudioClip ItemCollected => Instance.itemCollected;
    public static AudioClip FailToCollect => Instance.failToCollect;
    public static AudioClip GameOver => Instance.gameOver;

    public static void PlayGameOver()
    {
        Instance._audioSource.clip = GameOver;
        Instance._audioSource.Play();
    }

    public static void PlayItemCollected()
    {
        Instance._audioSource.clip = ItemCollected;
        Instance._audioSource.Play();
    }

    public static void PlayFailToCollect()
    {
        Instance._audioSource.clip = FailToCollect;
        Instance._audioSource.Play();
    }

    public static AudioClip NextClip()
    {
        if(Instance.nextClipIndex >= FallingClips.Length)
            Instance.nextClipIndex = 0;
        AudioClip nextClip = FallingClips[Instance.nextClipIndex];
        Instance.nextClipIndex++;
        return nextClip;
    }

    public static void Loop(bool loop)
    {
        Instance._audioSource.loop = loop;
    }

    public static void SetVolume(float volume)
    {
        Instance._audioSource.volume = Mathf.Clamp(volume, 0.0f, 1.0f);
    }

    public static void StopPlaying()
    {
        Instance._audioSource.Stop();
    }
}
