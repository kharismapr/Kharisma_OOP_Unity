using UnityEngine;
using UnityEngine.UIElements;

public class MainUIController : MonoBehaviour
{
    private Label healthLabel;
    private Label pointsLabel;
    private Label waveLabel;
    private Label totalEnemiesLabel;

    private HealthComponent playerHealth;
    private CombatManager combatManager;

    private void OnEnable()
    {
        // get component UI Document
        var root = GetComponent<UIDocument>().rootVisualElement;

        // get Label berdasarkan name yang ada di UXML
        healthLabel = root.Q<Label>("Health");
        pointsLabel = root.Q<Label>("Points");
        waveLabel = root.Q<Label>("Wave");
        totalEnemiesLabel = root.Q<Label>("EnemiesLeft");

        // referensi ke komponen HealthComponent dan CombatManager
        playerHealth = FindObjectOfType<HealthComponent>();
        combatManager = FindObjectOfType<CombatManager>();

        // update UI tiap setiap kali frame diperbarui
        UpdateUI();
    }

    private void Update()
    {
        // Update UI 
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Update label health, wave, enemies, points
        healthLabel.text = "Health: " + playerHealth.Health;
        waveLabel.text = "Wave: " + combatManager.waveNumber;
        totalEnemiesLabel.text = "Enemies Left: " + combatManager.totalEnemies;
        pointsLabel.text = "Points: " + GetPoints();
    }

    private int GetPoints()
    {
        // karena player saya attack system belum benar jadi ngitung point dari wave * 5 aja ya TT
        return combatManager.waveNumber * 5;
    }
}
