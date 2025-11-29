using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class CombatManager : MonoBehaviour
{
    public TextMeshProUGUI PvText;
    public TextMeshProUGUI PaText;
    public TextMeshProUGUI CombatText;
    public TextMeshProUGUI ExpText;
    public int playerHP;
    public int currentPA;
    public EnemyManager enemyManager;
    private EnemyBase enemy;
    public UnityEngine.UI.Button endTurnButton; // À lier dans l'inspector
    private bool isPlayerTurn = true;
    public GameObject EndPanel;
    public TMPro.TextMeshProUGUI endText;


    void Start()
    {
        string target = GameData.ChosenTarget;
        enemy = GameData.CreateEnemy();
        currentPA = PlayerData.Instance.MaxPA;
        playerHP = PlayerData.Instance.MaxHP;
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
        
        playerHP += card.heal;

        if (PlayerData.Instance.LifestealPercent > 0 && card.damage > 0)
        {
            LifeSteal(playerHP,card.damage);
        }
        enemyManager.currentHp -= IsCrit(card.damage);
        
        
        enemyManager.TakeDamage(card.damage);
        if (playerHP > 20) playerHP = 20;
        if (enemyManager.currentHp < 1) enemyManager.currentHp = 0;
        PvText.text = playerHP.ToString();
        if (enemyManager.currentHp <= 0)
        {
            EndCombat(true);
        }
    }

    public int LifeSteal(int playerHP,int damage)
    {
        int lifesteal = Mathf.FloorToInt(damage * PlayerData.Instance.LifestealPercent);
        return playerHP += lifesteal;
    }
    public int IsCrit(int damage)
    {
        return Mathf.RoundToInt(damage * PlayerData.Instance.CritMultiplier);
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
        int enemyDamage = enemy.GetRandomDamage();

        if (Random.Range(0,100) > PlayerData.Instance.DodgePercent)
        {
            playerHP -= Mathf.Max(0, enemyDamage - PlayerData.Instance.Armor);
        }

        if (playerHP < 0) playerHP = 0;

        PvText.text = playerHP.ToString();
        Debug.Log("hp player " +playerHP);
        // Vérifie si le joueur est mort
        if (playerHP <= 0)
        {
            EndCombat(false);
            return;
        }

        // Sinon, ton tour recommence après une mini pause
        Invoke(nameof(StartPlayerTurn), 2f);
    }
    
    void StartPlayerTurn()
    {
        isPlayerTurn = true;
        currentPA = PlayerData.Instance.MaxPA;
        PaText.text = $"{currentPA} PA";
        endTurnButton.interactable = true;

    }

    private void EndCombat(bool victory)
    {
        EndPanel.SetActive(true);

        if (victory)
        {
            endText.text = "🏆 Victoire !";
            ExpText.text = "Exp: " + enemy.Exp;
            PlayerData.Instance.CurrentHP = playerHP;
            if(PlayerLevel.AddExp(enemy.Exp)) Debug.Log("Level Up"); 
        }
        else
        {
            endText.text = "💀 Défaite...";
        }

        endTurnButton.interactable = false;
    }

    public void OnReplay()
    {
        playerHP = PlayerData.Instance.CurrentHP;
        enemyManager.currentHp = enemy.MaxHP;
        currentPA = PlayerData.Instance.MaxPA;
        PvText.text = playerHP.ToString();
        PaText.text = $"{currentPA} PA";
        CombatText.text = "";
        EndPanel.SetActive(false);

        // Reset l’ennemi
        enemyManager.Start(enemy);
        isPlayerTurn = true;
        endTurnButton.interactable = true;
    }

    public void OnMenu()
    {
        EndPanel.SetActive(false);
        CombatText.text = "Retour au menu (placeholder)";
    }
    public void ReturnToWorldHUB()
    {
        SceneManager.LoadScene("WorldHUBScene");
    }

}
