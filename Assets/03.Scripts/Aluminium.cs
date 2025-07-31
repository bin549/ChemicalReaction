using UnityEngine;

public class Aluminium : MonoBehaviour {
    [SerializeField] private Tweezer tweezer;
    private MeshRenderer meshRenderer;

    private void Awake() {
        this.meshRenderer = this.GetComponent<MeshRenderer>();
    }

    private void OnMouseDown() {
        if (this.tweezer.pickupTweezer.activeSelf) {
            this.meshRenderer.enabled = false;
            this.tweezer.pickupTweezer.SetActive(false);
            this.tweezer.pickupAluminiumHand.SetActive(true);
        }
    }
}