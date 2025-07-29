using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField] private Image bgImage;

    [SerializeField] private Button startButton;

    [SerializeField] private GameObject tipObject;

    public void OnStartButtonClicked() {
        this.bgImage.gameObject.SetActive(false);
        this.startButton.gameObject.SetActive(false);
        this.tipObject.gameObject.SetActive(true);
    }
}