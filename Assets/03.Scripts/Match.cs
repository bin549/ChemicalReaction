using UnityEngine;

public class Match : MonoBehaviour {
    [SerializeField] private GameObject matchStick;
    public GameObject pickupMatchStickHand;
    public GameObject pickupWoodStickHand;
    public GameObject pickupWoodStickFireParticleIgnite;
    public GameObject pickupWoodStickFireParticleNormal;

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

    public void IgnoreWoodStick() {
        this.pickupWoodStickFireParticleIgnite.SetActive(true);
        this.pickupWoodStickFireParticleNormal.SetActive(false);
    }
}