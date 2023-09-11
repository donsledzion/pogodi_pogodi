using System.Runtime.CompilerServices;
using UnityEngine;

public class HurryUp : MonoBehaviour
{
    [SerializeField] private GameObject[] bells;
    [SerializeField] private float _animationInterval;
    [SerializeField] private int stages;
    private float timer;
    private int currentStage;

    void Start()
    {
        timer = 0;
        currentStage = 0;
        HideBells();
        
    }

    void Update()
    {
        if (currentStage >= stages)
        {
            currentStage = 0;
            gameObject.SetActive(false);
        }
        timer += Time.deltaTime;        
        if (timer > _animationInterval)
        {
            currentStage++;
            timer = 0;
            HideBells();
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
}
