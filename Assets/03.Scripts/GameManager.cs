using UnityEngine;

public class GameManager : MonoBehaviour {
    private AudioManager audioManager;
    private LabManager labManager;

    private void Awake() {
        this.audioManager = FindObjectOfType<AudioManager>();
        this.labManager = FindObjectOfType<LabManager>();
    }

    private void Start() {
        Invoke(nameof(PlayStartAudio), 0.1f);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.N)) {
            this.labManager.NextStep();
        }
    }

    private void PlayStartAudio() {
        this.audioManager.PlayStartClip();
    }
    
    
}