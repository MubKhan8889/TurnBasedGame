class EasyScripting
{
    // I found out how to hide controls when I found out that the classification for
    // controls like labels, buttons, etc, was literally just called "Controls",
    // Although learned that when I searched up how to hide buttons, labels, combo boxes, etc.
    // Link : https://stackoverflow.com/questions/31233558/c-sharp-hide-all-labels-controls

    /// <summary>
    /// Shows or hides groups of controls, used for displaying menus.
    /// </summary>
    /// <param name="controlsToHide"></param>
    /// <param name="show"></param>
    public void ShowControlGroup(List<Control> controlsToHide, bool show)
    {
        foreach (Control getControl in controlsToHide)
        {
            if (getControl != null)
            {
                getControl.Visible = show;
            }
        }
    }

    /// <summary>
    /// Gets a list of actions that is usable by an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public List<Action> GetUsableActions(Entity entity)
    {
        List<Action> usableActions = new List<Action>() { };
        List<Action> entityActions = entity.GetActions();

        foreach (Action action in entityActions)
        {
            string actionInfo = action.CanPerformAction(entity);

            if (actionInfo == "can_be_done")
                usableActions.Add(action);
        }

        return usableActions;
    }

    /// <summary>
    /// Finds text in a richtextbox to colour in.
    /// </summary>
    /// <param name="richTextBox"></param>
    /// <param name="findText"></param>
    /// <param name="colour"></param>
    public void ColourInText(RichTextBox richTextBox, string findText, Color colour)
    {
        int textPos = richTextBox.Find(findText);
        if (textPos == -1) return;

        richTextBox.Select(textPos, findText.Length);
        richTextBox.SelectionColor = colour;
        richTextBox.DeselectAll();
    }
}