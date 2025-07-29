using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance { get; private set; }
    
    private AudioSource audioSource;
    
    [SerializeField] private AudioClip startAudioClip;
    [SerializeField] private AudioClip[] ruleAudioClips;
    [SerializeField] private AudioClip[] tipAudioClips;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }
        this.audioSource = this.GetComponent<AudioSource>();
    }
    
    public void PlayStartClip() {
        this.PlaySound(startAudioClip);
    }

    public void PlayRuleClip(int index) {
        Debug.Log($"Playing rule clip {index}");
        this.PlaySound(this.ruleAudioClips[index]);
    }

    public void PlayTipClip(int index) {
        this.PlaySound(this.tipAudioClips[index]);
    }

    private void PlaySound(AudioClip clip) {
        this.audioSource.PlayOneShot(clip);
    }
}