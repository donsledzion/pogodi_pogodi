using System.Runtime.CompilerServices;
using UnityEngine;

public class HurryUp : MonoBehaviour
{
    [SerializeField] private GameObject[] bells;
    [SerializeField] private float _animationInterval;
    [SerializeField] private int stages;
    [Range(0f, 10)]
    [SerializeField] private int ringTreshold;
    private float timer;
    private int currentStage;
    private bool withBells = false;

    void Start()
    {
        ResetStatus();
    }

    void Update()
    {
        if (currentStage >= stages)
        {
            ResetStatus();
            gameObject.SetActive(false);
        }
        timer += Time.deltaTime;        
        if (timer > _animationInterval)
        {
            currentStage++;
            timer = 0;
            HideBells();
            if (!withBells) return;
            bells[1- (currentStage % bells.Length)].gameObject.SetActive(true);
        }
    }

    private void HideBells()
    {
        foreach (GameObject go in bells)
        {
            go.SetActive(false);
        }
    }

    private void ResetStatus()
    {
        withBells = false;
        timer = 0;
        currentStage = 0;
        HideBells();
        if (Random.Range(0, 10) > ringTreshold)
            withBells = true;
    }
}
