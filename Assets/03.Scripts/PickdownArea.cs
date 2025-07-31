using UnityEngine;

public class PickdownArea : MonoBehaviour {
    public GameObject arrowEffect;
    [SerializeField] private GameObject bottle;
    [SerializeField] private GameObject pickupHand;

    private void OnMouseDown() {
        this.arrowEffect.SetActive(false);
        this.bottle.SetActive(true);
        this.pickupHand.SetActive(false);
    }
}