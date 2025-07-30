using UnityEngine;

public class PickdownArea : MonoBehaviour {
    public ParticleSystem emitEffect;
    [SerializeField] private GameObject bottle;
    [SerializeField] private GameObject pickupHand;

    private void Awake() {
        this.emitEffect = this.GetComponent<ParticleSystem>();
    }

    private void OnMouseDown() {
        this.emitEffect.enableEmission = false;
        this.bottle.SetActive(true);
        this.pickupHand.SetActive(false);
    }
}