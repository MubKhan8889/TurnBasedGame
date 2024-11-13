/// <summary>
/// The contents of the action that relates to what the action actually does.
/// This allows the action to be functional.
/// </summary>
class ActionBuilder {
    private string actionType;
    private string actionDamageType;
    private int actionPotency;

    public void SetActionType(string setType)
    {
        if (setType == "Heal" || actionType == "Damage")
            this.actionType = setType;
        else
            this.actionType = "Damage";
    }

    public string GetActionType()
    {
        return this.actionType;
    }

    public void SetDamageType(string setType)
    {
        List<string> acceptedDamageTypes = new List<string>()
        {
            "Slash",
            "Bludgeon",
            "Pierce",
            "Fire",
            "Arcane"
        };

        foreach (string damageType in acceptedDamageTypes)
        {
            if (setType == damageType)
            {
                this.actionDamageType = setType;
                break;
            }
        }
    }

    public string GetDamageType()
    {
        return this.actionDamageType;
    }

    public void SetActionPotency(int setPotency)
    {
        if (setPotency > 0)
            this.actionPotency = setPotency;
        else
            this.actionPotency = 0;
    }

    public int GetPotency()
    {
        return this.actionPotency;
    }

    /// <summary>
    /// This performs the action on either the source or target, depending on what type of action it is.
    /// Used by the CanPerformActions function in Actions.cs
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    public void Action(Entity source, Entity target)
    {
        switch(this.actionType)
        {
            case "Heal":
                Heal(source);
                break;
            case "Damage":
                Damage(target);
                break;
        }
    }

    private void Heal(Entity source)
    {
        if (source == null) return;
        source.HealthIncrement(this.actionPotency);
    }

    private void Damage(Entity target)
    {
        int damage = GetDamage(target);
        target.HealthIncrement(-damage);
    }

    public int GetDamage(Entity target)
    {
        float getResistance = target.GetResistance(this.actionDamageType);
        float convertPotency = Convert.ToSingle(this.actionPotency);
        int damage = Convert.ToInt16(convertPotency * getResistance);

        return damage;
    }
}