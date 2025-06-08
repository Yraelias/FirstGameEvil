using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public TextMeshProUGUI enemyNameText;
    public TextMeshProUGUI enemyHpText;

    public int maxHp;       // Par d�faut, ou fixe selon ennemi
    public int currentHp;

    public void Start()
    {
        currentHp = maxHp;      // Init � full HP
        enemyNameText.text = GameData.ChosenTarget;  // Nom affich�
        enemyHpText.text = maxHp.ToString();
        UpdateUI();
    }

    public void Start(EnemyBase ennemy)
    {
        maxHp = currentHp = ennemy.MaxHP;
        enemyNameText.text = ennemy.Name;
        enemyHpText.text = maxHp.ToString();
        UpdateUI();
    }
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp < 0) currentHp = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        enemyHpText.text = $"HP: {currentHp} / {maxHp}";
    }
}
