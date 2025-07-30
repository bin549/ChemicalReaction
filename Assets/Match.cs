using UnityEngine;

public class Match : MonoBehaviour {
    [SerializeField] private GameObject matchStick;
    public GameObject pickupMatchStickHand;
    public GameObject pickupWoodStickHand;

    private void OnMouseDown() {
        PickupMatchStick();
    }
    
    private void PickupMatchStick() {
        this.matchStick.SetActive(false);
        this.pickupMatchStickHand.SetActive(true);
    }
    
    public void PickupWoodStick() {
        this.pickupMatchStickHand.SetActive(false);
        this.pickupWoodStickHand.SetActive(true);
    }
}