using UnityEngine;

public class AudioManager : MonoBehaviour {
    private AudioSource audioSource;
    
    [SerializeField] private AudioClip startAudioClip;
    [SerializeField] private AudioClip[] ruleAudioClips;
    [SerializeField] private AudioClip[] tipAudioClips;
    [SerializeField] private AudioClip concludeAudioClip;
    [SerializeField] private AudioClip endAudioClip;
    [SerializeField] private AudioClip finishAudioClip;
    
    public AudioClip[] RuleAudioClips { get { return ruleAudioClips; } }
    public AudioClip[] TipAudioClips { get { return tipAudioClips; } }

    private void Awake() {
        this.audioSource = this.GetComponent<AudioSource>();
    }
    
    public void PlayStartClip() {
        this.PlaySound(this.startAudioClip);
    }
    
    public void PlayConcluedeClip() {
        this.PlaySound(this.concludeAudioClip);
    }
    
    public void PlayEndClip() {
        this.PlaySound(this.endAudioClip);
    }

    public void PlayFinishClip() {
        this.PlaySound(this.finishAudioClip);
    }

    public void PlayRuleClip(int index) {
        if (ruleAudioClips != null && index >= 0 && index < ruleAudioClips.Length) {
            this.PlaySound(this.ruleAudioClips[index]);
        }
    }

    public void PlayTipClip(int index) {
        if (tipAudioClips != null && index >= 0 && index < tipAudioClips.Length) {
            this.PlaySound(this.tipAudioClips[index]);
        }
    }

    private void PlaySound(AudioClip clip) {
        this.audioSource.Stop();
        this.audioSource.PlayOneShot(clip);
    }
    
    public void StopPlayAudio() {
        this.audioSource.Stop();
    }
}