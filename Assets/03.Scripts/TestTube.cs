using UnityEngine;

public class TestTube : MonoBehaviour {
    [SerializeField] private Beaker breaker;
    private MeshRenderer meshRenderer;
    public GameObject pourBeakerAnim;
    private bool isFill;
    private LabManager labManager;

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
    }

    private void ResetBeaker() {
        this.meshRenderer.enabled = true;
        this.breaker.pickupBeaker.gameObject.SetActive(true);
        this.pourBeakerAnim.SetActive(false); 
        this.labManager.IncrementTestTubeCount();
    }
}
