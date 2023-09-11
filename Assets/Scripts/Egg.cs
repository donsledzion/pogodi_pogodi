using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Egg : MonoBehaviour
{
    [SerializeField] private GameObject[] eggs;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float timeInterval;
    private AudioClip clip;
    private float timer;
    private int stage;
    private BoardPosition _origin;
    public BoardPosition Origin => _origin;


    private void Start()
    {
        stage = 0;
        timer = 0;
        SetStage(stage);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeInterval)
        {
            timer = 0;
            stage++;
            SetStage(stage);
        }
    }

    internal void SetInterval(float interval)
    {
        timeInterval = interval;
    }

    internal void SetClip(AudioClip clip)
    {
        this.clip = clip;
        audioSource.clip = clip;
    }

    private void SetStage(int stage)
    {
        HideEggs();
        if (stage < eggs.Length)
        {
            audioSource.Play();
            eggs[stage].gameObject.SetActive(true);
        }
        else
            FallDown();

    }

    private void FallDown()
    {
        GameManager.Instance.HandleEggFall(this);
        Destroy(gameObject);
    }

    private void HideEggs()
    {
        foreach (GameObject egg in eggs)
        {
            egg.SetActive(false);
        }
    }

    internal void SetOrigin(BoardPosition boardPosition)
    {
        _origin = boardPosition;
    }
}
