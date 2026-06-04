using UnityEngine;

public class LevelRule : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject loosePanel;

    private void Start() => LevelEventBus.Instance.OnEnemyDie += CheckFinish;

    public void CheckFinish()
    {
        if(Registry<Health>.Count == 0) Win();
    }

    private void Win()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Win");
    }

    
    private void OnDisable() => LevelEventBus.Instance.OnEnemyDie -= CheckFinish;
}
