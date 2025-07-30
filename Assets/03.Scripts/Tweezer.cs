using System;
using UnityEngine;

public class Tweezer : MonoBehaviour {
    [SerializeField] private GameObject currentTweezer;
    public GameObject pickupTweezer;
    public GameObject pickupAluminiumHand;
    private LabManager labManager;

    private void Awake() {
        this.labManager = FindObjectOfType<LabManager>();
    }

    private void OnMouseDown() {
        if (this.labManager.isStep02Done) {
            return;
        }
        this.currentTweezer.SetActive(false);
        this.pickupTweezer.SetActive(true);
    }

    public void ShowTweezer() {
        this.currentTweezer.SetActive(true);
    }
}
