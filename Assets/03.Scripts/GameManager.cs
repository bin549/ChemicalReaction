using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    
    private AudioManager audioManager;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }
        
        this.audioManager = AudioManager.Instance;
    }

    private void Start() {
        Invoke(nameof(PlayStartAudio), 0.1f);
    }

    private void PlayStartAudio() {
        this.audioManager.PlayStartClip();
    }
}