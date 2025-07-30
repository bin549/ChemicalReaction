using UnityEngine;

public class Tweezer : MonoBehaviour {
    [SerializeField] private GameObject currentTweezer;
    public GameObject pickupTweezer;
    public GameObject pickupAluminiumHand;

    private void OnMouseDown() {
        this.currentTweezer.SetActive(false);
        this.pickupTweezer.SetActive(true);
    }
}
