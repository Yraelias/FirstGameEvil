using UnityEngine;
using TMPro;

public class CombatManager : MonoBehaviour
{
    public TextMeshProUGUI PvText;
    public TextMeshProUGUI PaText;
    public TextMeshProUGUI CombatText;
    public int playerHP;
    public int enemyHP;
    public int maxPA = 3;
    public int currentPA;
    public EnemyManager enemyManager;
    private EnemyBase enemy;
    public UnityEngine.UI.Button endTurnButton; // À lier dans l'inspector
    private bool isPlayerTurn = true;

    void Start()
    {
        string target = GameData.ChosenTarget;
        enemy = GameData.CreateEnemy();
        currentPA = maxPA;
        //enemyManager.maxHp = enemy.MaxHP;
        enemyManager.Start(enemy);
        //UpdatePvText();
        PvText.text = $"{playerHP} PV";
        PaText.text = $"{currentPA} PA";
        
    }


    public bool TryPlayCard(CardData card)
    {
        if (card.actionCost > currentPA)
        {
            Debug.Log("⛔ Pas assez de PA !");
            return false;
        }

        currentPA -= card.actionCost;
        PaText.text = $"{currentPA} PA";
        ApplyCardEffect(card);
        return true;
    }
    public void ApplyCardEffect(CardData card)
    {
        enemyHP -= card.damage;
        playerHP += card.heal;

        if (playerHP > 20) playerHP = 20;
        if (enemyHP < 0) enemyHP = 0;
        PvText.text = playerHP.ToString();
        string target = GameData.ChosenTarget;
        enemyManager.TakeDamage(card.damage);

        if (enemyHP <= 0)
        {
            PvText.text += $"\n🏆 Tu as vaincu {target} !";
        }
    }
    public void EndPlayerTurn()
    {
        if (!isPlayerTurn) return;

        isPlayerTurn = false;
        endTurnButton.interactable = false;

        Invoke(nameof(EnemyTurn), 2f);
    }
 
    void EnemyTurn()
    {
        // L’ennemi attaque (exemple simple)
        int enemyDamage = Random.Range(3, 6); // Dégâts aléatoires entre 3 et 5
        playerHP -= enemyDamage;

        if (playerHP < 0) playerHP = 0;

        PvText.text = playerHP.ToString();
        // Vérifie si le joueur est mort
        if (playerHP <= 0)
        {
            endTurnButton.interactable = false;
            return;
        }

        // Sinon, ton tour recommence après une mini pause
        Invoke(nameof(StartPlayerTurn), 2f);
    }

    void StartPlayerTurn()
    {
        isPlayerTurn = true;
        currentPA = maxPA;
        PaText.text = $"{currentPA} PA";
        endTurnButton.interactable = true;

    }

}
