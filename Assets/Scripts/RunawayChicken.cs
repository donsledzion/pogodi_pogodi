using UnityEngine;

public class RunawayChicken : MonoBehaviour
{

    [SerializeField] private GameObject[] stages;
    [SerializeField] private float timeInterval;
    private float timer;
    private int stage;
    void Start()
    {
        DisableAll();
        timer = 0;
        stage = 0;
        SetStage(stage);

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeInterval)
        {
            timer = 0;
            stage++;
            SetStage(stage);
        }
    }

    private void DisableAll()
    {
        foreach (GameObject stage in stages)
        {
            stage.SetActive(false);
        }
    }

    private void SetStage(int stageNo)
    {
        DisableAll();
        if (stageNo < stages.Length)
            stages[stageNo].SetActive(true);
        else
            Destroy(gameObject);
    }
}
