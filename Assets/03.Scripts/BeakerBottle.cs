using UnityEngine;

public class BeakerBottle : MonoBehaviour {
    [SerializeField] private Beaker beaker;
    
    private void OnMouseDown() {
        if (!this.beaker.pickupBeaker.activeSelf && !this.beaker.pickupHand.activeSelf) {
            this.beaker.pickupHand.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}