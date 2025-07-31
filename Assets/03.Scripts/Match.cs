using System;
using UnityEngine;

public class Match : MonoBehaviour {
    private AudioManager audioManager;
    [SerializeField] private GameObject matchStick;
    public GameObject pickupMatchStickHand;
    public GameObject pickupWoodStickHand;
    public GameObject pickupWoodStickFireParticleIgnite;
    public GameObject pickupWoodStickFireParticleNormal;

    private void Awake() {
        this.audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnMouseDown() {
        this.PickupMatchStick();
    }
    
    private void PickupMatchStick() {
        this.matchStick.SetActive(false);
        this.pickupMatchStickHand.SetActive(true);
        this.audioManager.PlayMatchClip();
    }
    
    public void PickupWoodStick() {
        this.audioManager.PlayStickClip();
        this.pickupMatchStickHand.SetActive(false);
        this.pickupWoodStickHand.SetActive(true);
    }

    public void IgnoreWoodStick() {
        this.pickupWoodStickFireParticleIgnite.SetActive(true);
        this.pickupWoodStickFireParticleNormal.SetActive(false);
    }
}