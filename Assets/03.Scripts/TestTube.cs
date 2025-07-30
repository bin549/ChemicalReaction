using UnityEngine;

public class TestTube : MonoBehaviour {
    private LabManager labManager;
    private AudioManager audioManager;
    private QuestionManager questionManager;
    [Header("Step01")]
    [SerializeField] private Beaker breaker;
    private MeshRenderer meshRenderer;
    public GameObject pourBeakerAnim;
    private bool isFill;
    [Header("Step02")]
    [SerializeField] private Tweezer tweezer;
    public GameObject aluminiumFall;
    [Header("Step03")] 
    [SerializeField] private Match match;
    [SerializeField] private Transform woodStickHandTransform;
    [SerializeField] private GameObject liquidPrefab;

    private void Awake() {
        this.labManager = FindObjectOfType<LabManager>();
        this.meshRenderer = this.GetComponent<MeshRenderer>();
        this.questionManager = FindObjectOfType<QuestionManager>();
        this.audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnMouseDown() {
        if (this.breaker.pickupBeaker.activeSelf && !this.isFill) {
            this.audioManager.PlayPourClip();
            this.meshRenderer.enabled = false;
            this.breaker.pickupBeaker.gameObject.SetActive(false);
            this.pourBeakerAnim.SetActive(true); 
            Invoke(nameof(ResetBeaker), 1.2f);
        }
        if (this.tweezer.pickupAluminiumHand.activeSelf) {
            this.audioManager.PlayCollideClip();
            this.tweezer.pickupAluminiumHand.SetActive(false);
            this.tweezer.pickupTweezer.SetActive(true);
            this.aluminiumFall.SetActive(true);
            this.labManager.NextStep();
            this.labManager.aluminiumFallCount++;
            if (this.labManager.aluminiumFallCount == 2) {
                this.labManager.isStep02Done = true;
                this.tweezer.ShowTweezer();
                this.tweezer.pickupTweezer.SetActive(false);
                this.questionManager.InitializeQuestion(this.labManager.CurrentStepIndex+1);
            }
        }
        if (this.match.pickupWoodStickHand.activeSelf) {
            this.match.pickupWoodStickHand.transform.position = woodStickHandTransform.position;
            this.match.IgnoreWoodStick();
            this.labManager.stickTestCount++;
            this.audioManager.PlayIgniteClip();
            if (this.labManager.stickTestCount == 2) {
                this.labManager.isStep03Done = true;
                this.labManager.NextStep();
                this.questionManager.InitializeQuestion(this.labManager.CurrentStepIndex+1);
            }
        }
    }

    private void ResetBeaker() {
        this.meshRenderer.enabled = true;
        this.breaker.pickupBeaker.gameObject.SetActive(true);
        this.pourBeakerAnim.SetActive(false); 
        this.labManager.IncrementTestTubeCount();
        this.liquidPrefab.SetActive(true);
    }
}
