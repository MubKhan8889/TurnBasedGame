/// <summary>
/// A class which represents a entity in the game, usually in the form of a player or a enemy.
/// </summary>
class Entity
{
    private string name;
    private Image image;
    private int maxHealth;
    private int health;
    private int maxMana;
    private int mana;
    private Resistance resistances = new Resistance();
    private List<Action> actions = new List<Action>() { };

    public void SetName(string setName)
    {
        if (setName == null) return;

        if (setName.Length <= 12)
            this.name = setName;
        else
            this.name = setName.Substring(0, 12);
    }

    public string GetName()
    {
        return this.name;
    }

    public void SetImage(string imageName)
    {
        if (imageName == null) return;

        image = Image.FromFile(imageName);
    }

    public Image GetImage()
    {
        return this.image;
    }

    public void SetHealth(int newHealth) 
    {
        if (newHealth == null) return;
        this.maxHealth = Math.Clamp(newHealth, 0, int.MaxValue);
        this.health = Math.Clamp(newHealth, 0, int.MaxValue);
    }

    public void HealthIncrement(int healthIncrement)
    {
        if (healthIncrement == null) return;

        this.health = Math.Clamp(this.health += healthIncrement, 0, this.maxHealth);
    }

    // I searched up how to return 2 variables instead of 1
    // Link : https://code-maze.com/csharp-return-multiple-values-to-a-method-caller/
    public (int, int) GetHealth()
    {
        return (this.health, this.maxHealth);
    }

    public void SetMana(int newMana)
    {
        if (newMana == null) return;
        this.maxMana = Math.Clamp(newMana, 0, int.MaxValue);
        this.mana = Math.Clamp(newMana, 0, int.MaxValue);
    }

    public void ManaIncrement(int manaIncrement)
    {
        if (manaIncrement == null) return;

        this.mana = Math.Clamp(this.mana += manaIncrement, 0, this.maxMana);
    }

    public (int, int) GetMana()
    {
        return (this.mana, this.maxMana);
    }

    public void SetResistance(string resistance, float value)
    {
        switch(resistance)
        {
            case "Slash":
                resistances.slash = value;
                break;
            case "Bludgeon":
                resistances.bludgeon = value;
                break;
            case "Pierce":
                resistances.pierce = value;
                break;
            case "Fire":
                resistances.fire = value;
                break;
            case "Arcane":
                resistances.arcane = value;
                break;
        }
    }

    public float GetResistance(string resistance)
    {
        switch (resistance)
        {
            case "Slash":
                return resistances.slash;
            case "Bludgeon":
                return resistances.bludgeon;
            case "Pierce":
                return resistances.pierce;
            case "Fire":
                return resistances.fire;
            case "Arcane":
                return resistances.arcane;
            default:
                return 1f;
        }
    }

    public void AddAction(Action action)
    {
        if (action == null) return;
        actions.Add(action);
    }

    public void RemoveAction(int actionID)
    {
        for (int i = 0; i < actions.Count; i += 1)
        {
            int id = actions[i].GetID();

            if (id == actionID)
            {
                actions.RemoveAt(i);
                break;
            }
        }
    }

    public void RemoveAllActions()
    {
        actions.Clear();
    }

    public List<Action> GetActions()
    {
        return actions;
    }
}