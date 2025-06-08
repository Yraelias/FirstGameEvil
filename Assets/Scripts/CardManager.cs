using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    [Header("Prefab & UI")]
    public GameObject cardPrefab;          // Le prefab de la carte (avec Button + TMP texts)
    public Transform cardContainer;        // Parent où on instancie les cartes
    public CombatManager combatManager;
    private List<CardData> deck = new List<CardData>();

    void Start()
    {
        // On crée un deck simple de 3 cartes
        deck.Add(new CardData("Siphon de Vie", "Inflige 5 DMG, soigne 2 PV", 5, 2, 1));
        deck.Add(new CardData("Caresse de la Nuit", "Inflige 4 DMG, affaiblit", 4, 0, 1));
        deck.Add(new CardData("Charme Hypnotique", "Stun pendant 1 tour", 0, 0, 1));

        DisplayCards();
    }

    void DisplayCards()
    {
        foreach (CardData card in deck)
        {
            GameObject cardGO = Instantiate(cardPrefab, cardContainer);
            TextMeshProUGUI nameText = cardGO.transform.Find("Name").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI descText = cardGO.transform.Find("Description").GetComponent<TextMeshProUGUI>();
            Button btn = cardGO.GetComponent<Button>();
            nameText.text = card.cardName;
            descText.text = card.description;
            btn.onClick.AddListener(() =>
            {
                combatManager.TryPlayCard(card);                
            });
        }
    }


    void PlayCard(CardData card)
    {
        Debug.Log("Tu as joué la carte : " + card.cardName);
        Debug.Log("Dégâts : " + card.damage + ", Soins : " + card.heal);

        // Ici tu peux envoyer les effets au CombatManager, etc.
    }
}

