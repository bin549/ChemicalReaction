using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    
    private AudioManager audioManager;
    private LabManager labManager;
    private UIManager uiManager;
    
    private float startTime;
    private float elapsedTime;
    private int score = 100;
    private bool isGameActive = false;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }
        
        this.audioManager = FindObjectOfType<AudioManager>();
        this.labManager = FindObjectOfType<LabManager>();
        this.uiManager = FindObjectOfType<UIManager>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.N)) {
            this.labManager.NextStep();
        }
        if (isGameActive) {
            elapsedTime = Time.time - startTime;
            if (uiManager != null) {
                uiManager.UpdateTimeDisplay(GetFormattedTime());
            }
        }
    }

    public void StartTimer() {
        startTime = Time.time;
        elapsedTime = 0f;
        isGameActive = true;
    }
    
    public void StopTimer() {
        isGameActive = false;
    }
    
    public void DeductScore(int points = 5) {
        score = Mathf.Max(0, score - points);
        if (uiManager != null) {
            uiManager.UpdateScoreDisplay(score);
        }
    }
    
    public string GetFormattedTime() {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public int GetScore() {
        return score;
    }
    
    public float GetElapsedTime() {
        return elapsedTime;
    }
    
    public void ResetGame() {
        score = 100;
        elapsedTime = 0f;
        isGameActive = false;
    }
}