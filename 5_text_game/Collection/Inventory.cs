public class Inventory
{
    public int HealingPotions { get; private set; }
    public int ResourcePotions { get; private set; }

    public Inventory()
    {
        HealingPotions = 2;
        ResourcePotions = 2;
    }

    public bool UseHealingPotion(Character character)
    {
        if (HealingPotions > 0)
        {
            character.Health += 30;
            HealingPotions--;
            return true;
        }
        return false;
    }

    public bool UseResourcePotion(Character character)
    {
        if (ResourcePotions > 0)
        {
            character.RestoreResource();
            ResourcePotions--;
            return true;
        }
        return false;
    }
}
