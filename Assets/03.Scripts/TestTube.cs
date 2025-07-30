using UnityEngine;

public class TestTube : MonoBehaviour {
    private LabManager labManager;
    [Header("Step01")]
    [SerializeField] private Beaker breaker;
    private MeshRenderer meshRenderer;
    public GameObject pourBeakerAnim;
    private bool isFill;
    [Header("Step02")]
    [SerializeField] private Tweezer tweezer;
    public GameObject aluminiumFall;

    private void Awake() {
        this.labManager = FindObjectOfType<LabManager>();
        this.meshRenderer = this.GetComponent<MeshRenderer>();
    }

    private void OnMouseDown() {
        if (this.breaker.pickupBeaker.activeSelf && !this.isFill) {
            this.meshRenderer.enabled = false;
            this.breaker.pickupBeaker.gameObject.SetActive(false);
            this.pourBeakerAnim.SetActive(true); 
            Invoke(nameof(ResetBeaker), 1.2f);
        }
        if (this.tweezer.pickupAluminiumHand.activeSelf) {
            this.tweezer.pickupAluminiumHand.SetActive(false);
            this.tweezer.pickupTweezer.SetActive(true);
            this.aluminiumFall.SetActive(true);
            this.labManager.NextStep();
        }
    }

    private void ResetBeaker() {
        this.meshRenderer.enabled = true;
        this.breaker.pickupBeaker.gameObject.SetActive(true);
        this.pourBeakerAnim.SetActive(false); 
        this.labManager.IncrementTestTubeCount();
    }
}
