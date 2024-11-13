/// <summary>
/// A class that is used for storing information of actions, which are used by entities.
/// Actions are what enemies and the player uses to attack each other.
/// </summary>
class Action
{
    private int id;
    private string name;
    private int manaCost;
    private int healthCost;
    private string description;
    public ActionBuilder action = new ActionBuilder();

    public void SetID(int setID)
    {
        this.id = Math.Clamp(setID, 1, int.MaxValue);
    }

    public int GetID()
    {
        return id;
    }

    public void SetName(string setName)
    {
        if (setName.Length <= 12)
            this.name = setName;
        else
            this.name = setName.Substring(0, 12);
    }

    public string GetName()
    {
        return this.name;
    }

    public void SetManaCost(int setCost)
    {
        this.manaCost = Math.Clamp(setCost, 0, int.MaxValue);
    }

    public int GetManaCost()
    {
        return manaCost;
    }

    public void SetHealthCost(int setCost)
    {
        this.healthCost = Math.Clamp(setCost, 0, int.MaxValue);
    }

    public int GetHealthCost()
    {
        return healthCost;
    }

    public void SetDescription(string setDesc)
    {
        description = setDesc;
    }

    public string GetDescription()
    {
        return description;
    }

    /// <summary>
    /// This action will be performed, it will need a source (the entity doing the action) and a target (the entity the source will attack).
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool Perform(Entity source, Entity target)
    {
        if (source == null && target == null) return false;
        (int sourceMana, int sourceMaxMana) = source.GetMana();
        (int sourceHealth, int sourceMaxHealth) = source.GetHealth();

        if (sourceMana - manaCost >= 0 && sourceHealth - healthCost >= 1)
        {
            source.ManaIncrement(-manaCost);
            source.HealthIncrement(-healthCost);
            this.action.Action(source, target);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Returns a string value that determines if the enemy can use the action.
    /// The string differs depending on why the source (the entity) cannot use it.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public string CanPerformAction(Entity source)
    {
        if (source == null) return "no_source_found";
        (int sourceMana, int sourceMaxMana) = source.GetMana();
        (int sourceHealth, int sourceMaxHealth) = source.GetHealth();

        if (sourceMana - manaCost >= 0 && sourceHealth - healthCost >= 1) return "can_be_done";
        else if (sourceMana - manaCost < 0 && sourceHealth - healthCost < 1) return "not_enough_HP_MP";
        else if (sourceMana - manaCost < 0) return "not_enough_MP";
        else if (sourceHealth - healthCost < 1) return "not_enough_HP";

        return "nothing_happened";
    }

    public override string ToString()
    {
        string returnName = name;

        if (manaCost > 0)
            returnName += $" (MP : {manaCost})";

        if (healthCost > 0)
            returnName += $" (HP : {healthCost})";

        return returnName;
    }
}