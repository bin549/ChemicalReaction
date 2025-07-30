using System;
using UnityEngine;

public class Beaker : MonoBehaviour {
    private LabManager labManager;
    [SerializeField] private GameObject currentBeaker;
    [SerializeField] private GameObject bottle;
    public GameObject pickupHand;
    [SerializeField] private GameObject pickdownArea;
    [SerializeField] private GameObject resetArea;
    public GameObject pickupBeaker;
    
    private void Awake() {
        this.labManager = FindObjectOfType<LabManager>(true);
    }

    private void OnMouseDown() {
        if (!labManager.IsWorking) {
            return;
        }
        if (this.labManager.isStep01Done && this.pickupHand.activeSelf) {
            this.PickDownBottle();
            return;
        }
        if (this.resetArea.activeSelf) {
            this.ResetPosition();
            return;
        }
        if (this.bottle.activeSelf) {
            this.PickupBottle();
        } else {
            this.PickupBeaker();
        }
    }

    private void PickupBottle() {
        this.bottle.SetActive(false);
        this.pickupHand.SetActive(true);
        this.pickdownArea.SetActive(true);
    }

    private void PickDownBottle() {
        this.bottle.SetActive(true);
        this.pickupHand.SetActive(false);
        this.labManager.NextStep();
    }

    private void PickupBeaker() {
        this.currentBeaker.SetActive(false);
        this.pickupBeaker.SetActive(true);
    }

    private void ResetPosition() {
        this.currentBeaker.SetActive(true);
        this.pickupBeaker.SetActive(false);
        this.resetArea.SetActive(false);
    }
}
