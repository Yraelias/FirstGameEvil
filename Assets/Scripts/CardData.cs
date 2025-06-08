public class CardData
{
    public string cardName;
    public string description;
    public int damage;
    public int heal;
    public int actionCost;

    public CardData(string name, string desc, int dmg, int healAmount, int cost)
    {
        cardName = name;
        description = desc;
        damage = dmg;
        heal = healAmount;
        actionCost = cost;
    }
}
