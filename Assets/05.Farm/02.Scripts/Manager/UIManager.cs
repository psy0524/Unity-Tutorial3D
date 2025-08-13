using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject outSideUI;
    [SerializeField] private GameObject plantationUI;
    [SerializeField] private GameObject houseUI;
    [SerializeField] private GameObject animalUI;
    [SerializeField] private GameObject seedUI;
    [SerializeField] private GameObject inventoryUI;

    [SerializeField] private Button seedButton;
    [SerializeField] private Button harvestButton;
    [SerializeField] private Button[] plantButtons;

    private void Awake()
    {
        seedButton.onClick.AddListener(OnSeedButton);
        harvestButton.onClick.AddListener(OnHarvestButton);

        for(int i = 0; i < plantButtons.Length; i++)
        {
            int j = i;
            plantButtons[i].onClick.AddListener(() => GameManager.Instance.plantation.SetPlant(j));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    private void OnSeedButton()
    {
        GameManager.Instance.plantation.SetState(PlantationManager.PlantationState.Seed);
        seedUI.SetActive(true);
    }

    private void OnHarvestButton()
    {
        GameManager.Instance.plantation.SetState(PlantationManager.PlantationState.Harvest);
        seedUI.SetActive(false);
    }

    public void ActivatePlantationUI(bool isActive)
    {
        plantationUI.SetActive(isActive);
    }
}
