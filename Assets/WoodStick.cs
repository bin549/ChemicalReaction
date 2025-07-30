using UnityEngine;

public class WoodStick : MonoBehaviour {
    [SerializeField] private Match match;
    
    private void OnMouseDown() {
        this.match.PickupWoodStick();
        this.gameObject.SetActive(false);
    }
}