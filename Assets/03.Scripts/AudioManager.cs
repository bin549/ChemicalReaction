using UnityEngine;

public class AudioManager : MonoBehaviour {
    private AudioSource audioSource;
    
    [SerializeField] private AudioClip startAudioClip;
    [SerializeField] private AudioClip[] ruleAudioClips;
    [SerializeField] private AudioClip[] tipAudioClips;
    [SerializeField] private AudioClip concludeAudioClip;
    [SerializeField] private AudioClip endAudioClip;
    [SerializeField] private AudioClip finishAudioClip;
    [SerializeField] private AudioClip clickAudioClip;
    [SerializeField] private AudioClip passAudioClip;
    [SerializeField] private AudioClip errorAudioClip;
    [SerializeField] private AudioClip matchAudioClip;
    [SerializeField] private AudioClip stickAudioClip;
    [SerializeField] private AudioClip igniteAudioClip;
    [SerializeField] private AudioClip collideAudioClip;
    [SerializeField] private AudioClip pourAudioClip;
    
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

    public void PlayClickClip() {
        this.PlaySound(this.clickAudioClip);
    }

    public void PlayPassClip() {
        this.PlaySound(this.passAudioClip);
    }

    public void PlayErrorClip() {
        this.PlaySound(this.errorAudioClip);
    }
    
    public void PlayMatchClip() {
        this.PlaySound(this.matchAudioClip);
    }

    public void PlayStickClip() {
        this.PlaySound(this.stickAudioClip);
    }

    public void PlayIgniteClip() {
        this.PlaySound(this.igniteAudioClip);
    }

    public void PlayCollideClip() {
        this.PlaySound(this.collideAudioClip);
    }

    public void PlayPourClip() {
        this.PlaySound(this.pourAudioClip);
    }
}