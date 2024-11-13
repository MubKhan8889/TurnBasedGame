using System.Media;

namespace AssignmentProject
{
    public partial class Form1 : Form
    {
        EasyScripting ezScript = new EasyScripting();
        public Form1()
        {
            InitializeComponent();
        }

        // Misc
        Random rng = new Random();

        // Player Info
        short startPlayerHealth;
        short startPlayerMana;
        List<float> startPlayerResistances = new List<float>();
        List<Action> startPlayerActions = new List<Action>();

        // Reward Info
        short maxRewards;
        short healthIncreaseReward;
        short manaIncreaseReward;
        float resistDiffReward;

        // Values
        short rewardsLeft = 0;
        short enemiesKilled = 0;
        short totalPlayerTurns = 0;
        string combatText = "The battle has started!";

        // Add both entites
        Entity player = new Entity();
        Entity enemy = new Entity();

        // Add lists for actions and enemies
        List<Entity> enemyList = new List<Entity>() { };
        List<Action> actionList = new List<Action>() { };

        /* Controls to either hide or show, depending on what menu
            the player is currently in */
        List<Control> mainMenuControls = new List<Control>() { };
        List<Control> gameplayControls = new List<Control>() { };
        List<Control> rewardControls = new List<Control>() { };
        List<Control> winControls = new List<Control>() { };
        List<Control> howToPlayControls = new List<Control> { };
        List<Control> settingsControls = new List<Control> { };

        // Controls for settings to change
        List<Control> backgroundControls = new List<Control>() { };
        List<Control> foregroundControls = new List<Control>() { };
        List<Control> middleControls = new List<Control>() { };

        // Sounds List
        List<SoundPlayer> allSounds = new List<SoundPlayer>() { };

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add Actions
            List<string> getAllActionLines = File.ReadAllLines("configs\\actions.txt").ToList();

            for(int l = 0; l < getAllActionLines.Count; l += 1) 
            {
                string lineInfo = getAllActionLines[l];
                if (lineInfo.Contains("NEWACTION") == true)
                {
                    string actionName = getAllActionLines[l + 1].Substring(5);
                    string manaCost = getAllActionLines[l + 2].Substring(10);
                    string healthCost = getAllActionLines[l + 3].Substring(12);
                    string description = getAllActionLines[l + 4].Substring(12);
                    string actionType = getAllActionLines[l + 5].Substring(12);
                    string damageType = getAllActionLines[l + 6].Substring(12);
                    string actionPotency = getAllActionLines[l + 7].Substring(15);

                    int actionID = actionList.Count();
                    actionList.Add(new Action());
                    actionList[actionID].SetID(actionID + 1);
                    actionList[actionID].SetName(actionName);
                    actionList[actionID].SetManaCost(Convert.ToInt16(manaCost));
                    actionList[actionID].SetHealthCost(Convert.ToInt16(healthCost));
                    actionList[actionID].SetDescription(description);
                    actionList[actionID].action.SetActionType(actionType);
                    actionList[actionID].action.SetDamageType(damageType);
                    actionList[actionID].action.SetActionPotency(Convert.ToInt16(actionPotency));
                }
            }

            // Add enemies
            List<string> getAllEnemyLines = File.ReadAllLines("configs\\enemies.txt").ToList();

            for (int l = 0; l < getAllEnemyLines.Count; l += 1)
            {
                string lineInfo = getAllEnemyLines[l];
                if (lineInfo.Contains("NEWENEMY") == true)
                {
                    string enemyName = getAllEnemyLines[l + 1].Substring(5);
                    string imagePath = getAllEnemyLines[l + 2].Substring(6);
                    string health = getAllEnemyLines[l + 3].Substring(7);
                    string mana = getAllEnemyLines[l + 4].Substring(5);
                    string resists = getAllEnemyLines[l + 5].Substring(7);
                    string actions = getAllEnemyLines[l + 6].Substring(8);

                    int enemyID = enemyList.Count();
                    enemyList.Add(new Entity());
                    enemyList[enemyID].SetName(enemyName);
                    enemyList[enemyID].SetImage(imagePath);
                    enemyList[enemyID].SetHealth(Convert.ToInt16(health));
                    enemyList[enemyID].SetMana(Convert.ToInt16(mana));

                    int startIndex = 0;
                    for (int i = 0; i < resists.Length; i += 1)
                    {
                        char getChar = Convert.ToChar(resists[i]);
                        if (getChar == ',' || getChar == ';')
                        {
                           string getResistInfo = resists.Substring(startIndex, i - startIndex);

                            int separator = 0;
                            for (int j = 0; j < getResistInfo.Length; j += 1)
                            {
                                char findColon = Convert.ToChar(getResistInfo[j]);

                                if (findColon == ':')
                                {
                                    separator = j;
                                    break;
                                }
                            }

                            
                            string damageType = getResistInfo.Substring(0, separator);
                            string getValue = getResistInfo.Substring(separator + 1, getResistInfo.Length - separator - 1);

                            enemyList[enemyID].SetResistance(damageType, Convert.ToSingle(getValue));
                            startIndex = i + 1;
                        }
                    }

                    startIndex = 0;
                    for (int i = 0; i < actions.Length; i += 1)
                    {
                        char getChar = Convert.ToChar(actions[i]);
                        if (getChar == ',' || getChar == ';')
                        {
                            string getActionID = actions.Substring(startIndex, i - startIndex);
                            enemyList[enemyID].AddAction(actionList[Convert.ToInt16(getActionID)]);

                            startIndex = i + 1;
                        }
                    }
                }
            }

            // Set Up Config Info
            List<string> getAllConfigLines = File.ReadAllLines("configs\\config.txt").ToList();

            for (int l = 0; l < getAllConfigLines.Count; l += 1)
            {
                string lineInfo = getAllConfigLines[l];
                if (lineInfo.Contains("GAMECONFIG") == true)
                {
                    string rewardsPerEnemyDefeat = getAllConfigLines[l + 1].Substring(25);
                    string rewardHealthIncrease = getAllConfigLines[l + 2].Substring(23);
                    string rewardManaIncrease = getAllConfigLines[l + 3].Substring(21);
                    string rewardResistanceIncrease = getAllConfigLines[l + 4].Substring(25);

                    maxRewards = Convert.ToInt16(rewardsPerEnemyDefeat);
                    healthIncreaseReward = Convert.ToInt16(rewardHealthIncrease);
                    manaIncreaseReward = Convert.ToInt16(rewardManaIncrease);
                    resistDiffReward = Convert.ToSingle(rewardResistanceIncrease);
                }
                else if (lineInfo.Contains("PLAYERCONFIG") == true)
                {
                    string playerHealth = getAllConfigLines[l + 1].Substring(7);
                    string playerMana = getAllConfigLines[l + 2].Substring(5);
                    string playerResistances = getAllConfigLines[l + 3].Substring(7);
                    string playerActions = getAllConfigLines[l + 4].Substring(8);

                    startPlayerHealth = Convert.ToInt16(playerHealth);
                    startPlayerMana = Convert.ToInt16(playerMana);

                    int startIndex = 0;
                    for (int i = 0; i < playerResistances.Length; i += 1)
                    {
                        char getChar = Convert.ToChar(playerResistances[i]);
                        if (getChar == ',' || getChar == ';')
                        {
                            string getResistInfo = playerResistances.Substring(startIndex, i - startIndex);

                            int separator = 0;
                            for (int j = 0; j < getResistInfo.Length; j += 1)
                            {
                                char findColon = Convert.ToChar(getResistInfo[j]);

                                if (findColon == ':')
                                {
                                    separator = j;
                                    break;
                                }
                            }

                            string getValue = getResistInfo.Substring(separator + 1, getResistInfo.Length - separator - 1);
                            startPlayerResistances.Add(Convert.ToSingle(getValue));
                            startIndex = i + 1;
                        }
                    }

                    startIndex = 0;
                    for (int i = 0; i < playerActions.Length; i += 1)
                    {
                        char getChar = Convert.ToChar(playerActions[i]);
                        if (getChar == ',' || getChar == ';')
                        {
                            string getActionID = playerActions.Substring(startIndex, i - startIndex);
                            startPlayerActions.Add(actionList[Convert.ToInt16(getActionID)]);

                            startIndex = i + 1;
                        }
                    }
                }
            }

            // Rest of the player info will be set up in a function
            // for setting up battles
            player.SetName("Player");

            // Assign controls to control lists
            mainMenuControls.Add(buttonPlay);
            mainMenuControls.Add(labelGame);
            mainMenuControls.Add(buttonHowToPlay);
            mainMenuControls.Add(buttonSettings);

            gameplayControls.Add(labelPlayer);
            gameplayControls.Add(labelPlayerHealth);
            gameplayControls.Add(labelPlayerMana);
            gameplayControls.Add(labelEnemy);
            gameplayControls.Add(labelEnemyHealth);
            gameplayControls.Add(labelEnemyMana);
            gameplayControls.Add(listPlayerActions);
            gameplayControls.Add(richTextBoxCombat);
            gameplayControls.Add(buttonAttack);
            gameplayControls.Add(buttonContinue);
            gameplayControls.Add(pictureBoxEnemy);

            rewardControls.Add(labelChooseReward);
            rewardControls.Add(buttonIncreaseHP);
            rewardControls.Add(buttonIncreaseMP);
            rewardControls.Add(buttonRandomAbility);
            rewardControls.Add(buttonNewResistances);

            winControls.Add(labelGameWon);
            winControls.Add(labelTurns);
            winControls.Add(labelEnterName);
            winControls.Add(textBoxEnterName);
            winControls.Add(listBoxWinHistory);
            winControls.Add(buttonEnterName);

            howToPlayControls.Add(comboBoxHowToPlay);
            howToPlayControls.Add(labelHowToPlayCategory);
            howToPlayControls.Add(richTextBoxInstructions);
            howToPlayControls.Add(buttonBackToMenu);

            settingsControls.Add(buttonBackToMenu2);
            settingsControls.Add(labelFontSetting);
            settingsControls.Add(labelThemeSetting);
            settingsControls.Add(comboBoxFonts);
            settingsControls.Add(comboBoxThemes);

            // Assign background and foreground controls
            backgroundControls.Add(labelGame);
            backgroundControls.Add(labelEnemy);
            backgroundControls.Add(labelChooseReward);
            backgroundControls.Add(labelEnemyHealth);
            backgroundControls.Add(labelEnemyMana);
            backgroundControls.Add(labelEnterName);
            backgroundControls.Add(labelFontSetting);
            backgroundControls.Add(labelGameWon);
            backgroundControls.Add(labelHowToPlayCategory);
            backgroundControls.Add(labelPlayer);
            backgroundControls.Add(labelPlayerHealth);
            backgroundControls.Add(labelPlayerMana);
            backgroundControls.Add(labelThemeSetting);
            backgroundControls.Add(labelTurns);
            backgroundControls.Add(richTextBoxCombat);
            backgroundControls.Add(richTextBoxInstructions);

            middleControls.Add(listBoxWinHistory);
            middleControls.Add(listPlayerActions);
            middleControls.Add(comboBoxFonts);
            middleControls.Add(comboBoxHowToPlay);
            middleControls.Add(comboBoxThemes);

            foregroundControls.Add(buttonPlay);
            foregroundControls.Add(buttonAttack);
            foregroundControls.Add(buttonBackToMenu);
            foregroundControls.Add(buttonBackToMenu2);
            foregroundControls.Add(buttonContinue);
            foregroundControls.Add(buttonEnterName);
            foregroundControls.Add(buttonHowToPlay);
            foregroundControls.Add(buttonIncreaseHP);
            foregroundControls.Add(buttonIncreaseMP);
            foregroundControls.Add(buttonNewResistances);
            foregroundControls.Add(buttonRandomAbility);
            foregroundControls.Add(buttonSettings);

            // Add sound effects
            allSounds.Add(new SoundPlayer("slash.wav"));
            allSounds.Add(new SoundPlayer("bludgeon.wav"));
            allSounds.Add(new SoundPlayer("pierce.wav"));
            allSounds.Add(new SoundPlayer("fire.wav"));
            allSounds.Add(new SoundPlayer("magicTrim.wav"));
            allSounds.Add(new SoundPlayer("healTrim.wav"));

            // Set up the application
            ezScript.ShowControlGroup(mainMenuControls, true);
            ezScript.ShowControlGroup(gameplayControls, false);
            ezScript.ShowControlGroup(rewardControls, false);
            ezScript.ShowControlGroup(winControls, false);
            ezScript.ShowControlGroup(howToPlayControls, false);
            ezScript.ShowControlGroup(settingsControls, false);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            SetUpBattle(true);
        }

        private void listPlayerActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listPlayerActions.SelectedIndex;
            if (index == -1)
            {
                ReplaceCombatText("None");
                return;
            }

            List<Action> playerActions = player.GetActions();
            string getText = playerActions[index].GetDescription();
            ReplaceCombatText(getText);

            int potency = playerActions[index].action.GetPotency();
            string actionType = playerActions[index].action.GetActionType();

            if (actionType == "Damage")
            {
                ColourDamageText(potency, potency);
            }
            else if (actionType == "Heal")
            {
                ColourHealText(potency);
            }
        }

        private void buttonAttack_Click(object sender, EventArgs e)
        {
            int actionIndex = listPlayerActions.SelectedIndex;
            if (actionIndex == -1) return;

            totalPlayerTurns += 1;

            List<Action> playerActions = player.GetActions();
            string performInfo = playerActions[actionIndex].CanPerformAction(player);

            if (performInfo == "can_be_done")
            {
                playerActions[actionIndex].Perform(player, enemy);

                SetCombatText(playerActions[actionIndex], player, enemy);
                UpdateLabels();
                ChangeControlsBasedOnTurn("enemy");
            }
            else if (performInfo == "not_enough_MP_HP")
            {
                MessageBox.Show("You do not have enough health and mana to do this action.", "Action Failed");
            }
            else if (performInfo == "not_enough_MP")
            {
                MessageBox.Show("You do not have enough mana to do this action.", "Action Failed");
            }
            else if (performInfo == "not_enough_HP")
            {
                MessageBox.Show("You do not have enough health to do this action.", "Action Failed");
            }
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            (int playerHealth, int playerMaxHealth) = player.GetHealth();
            (int enemyHealth, int enemyMaxHealth) = enemy.GetHealth();

            if (playerHealth == 0)
            {
                ezScript.ShowControlGroup(mainMenuControls, true);
                ezScript.ShowControlGroup(gameplayControls, false);
                ezScript.ShowControlGroup(rewardControls, false);
                ezScript.ShowControlGroup(winControls, false);

                totalPlayerTurns = 0;

                return;
            }
            else if (enemyHealth == 0)
            {
                enemiesKilled += 1;

                ezScript.ShowControlGroup(mainMenuControls, false);
                ezScript.ShowControlGroup(gameplayControls, false);

                if (enemiesKilled == enemyList.Count)
                {
                    ezScript.ShowControlGroup(rewardControls, false);
                    ezScript.ShowControlGroup(winControls, true);

                    SetUpGameEnd();
                }
                else
                {
                    rewardsLeft = maxRewards;
                    RefreshRewards();
                    ezScript.ShowControlGroup(rewardControls, true);
                    ezScript.ShowControlGroup(winControls, false);
                }

                ezScript.ShowControlGroup(howToPlayControls, false);
                ezScript.ShowControlGroup(settingsControls, false);
                return;
            }

            List<Action> enemyActions = ezScript.GetUsableActions(enemy);
            if (enemyActions.Count == 0) return;

            int actionIndex = Math.Clamp(rng.Next(0, enemyActions.Count), 0, enemyActions.Count - 1);
            enemyActions[actionIndex].Perform(enemy, player);

            (playerHealth, playerMaxHealth) = player.GetHealth();
            SetCombatText(enemyActions[actionIndex], enemy, player);
            UpdateLabels();

            if (playerHealth > 0)
            {
                ChangeControlsBasedOnTurn("player");
            }
        }

        private void buttonIncreaseHP_Click(object sender, EventArgs e)
        {
            (int health, int maxHealth) = player.GetHealth();
            player.SetHealth(maxHealth + healthIncreaseReward);

            rewardsLeft -= 1;
            RefreshRewards();
        }

        private void buttonIncreaseMP_Click(object sender, EventArgs e)
        {
            (int mana, int maxMana) = player.GetMana();
            player.SetMana(maxMana + manaIncreaseReward);

            rewardsLeft -= 1;
            RefreshRewards();
        }

        private void buttonRandomAbility_Click(object sender, EventArgs e)
        {
            List<Action> playerActions = player.GetActions();
            List<Action> unlearnedActions = new List<Action> { };

            foreach (Action action in actionList)
            {
                bool isntInPlayerActions = true;
                int actionID = action.GetID();

                foreach (Action playerAction in playerActions)
                {
                    int playerActionID = playerAction.GetID();

                    if (actionID == playerActionID)
                    {
                        isntInPlayerActions = false;
                        break;
                    }
                }

                if (isntInPlayerActions == true)
                {
                    unlearnedActions.Add(action);
                }
            }

            int randomAction = Math.Clamp(rng.Next(0, unlearnedActions.Count), 0, unlearnedActions.Count - 1);
            player.AddAction(unlearnedActions[randomAction]);

            if (unlearnedActions.Count == 1)
                buttonRandomAbility.Enabled = false;

            rewardsLeft -= 1;
            RefreshRewards();
        }

        private void buttonNewResistances_Click(object sender, EventArgs e)
        {
            List<string> damageTypeList = new List<string>
            {
                "Slash",
                "Bludgeon",
                "Pierce",
                "Fire",
                "Arcane"
            };

            for (int i = 0; i < 3; i += 1)
            {
                int randomResist = Math.Clamp(rng.Next(0, damageTypeList.Count), 0, damageTypeList.Count - 1);
                string chosenResist = damageTypeList[randomResist];
                damageTypeList.Remove(chosenResist);

                if (i == 2)
                {
                    float resistValue = player.GetResistance(chosenResist);
                    player.SetResistance(chosenResist, resistValue + resistDiffReward);
                }
                else
                {
                    float resistValue = player.GetResistance(chosenResist);
                    player.SetResistance(chosenResist, resistValue - resistDiffReward);
                }
            }

            rewardsLeft -= 1;
            RefreshRewards();
        }

        private void buttonEnterName_Click(object sender, EventArgs e)
        {
            string getName = textBoxEnterName.Text;
            textBoxEnterName.Text = "";

            if (getName.Length == 0)
            {
                MessageBox.Show("Name cannot be left empty!", "Error");
                return;
            }
            else if (getName.Length > 20)
            {
                MessageBox.Show("Name cannot be more than 20 characters!");
                return;
            }

            if (File.Exists("previousGames.txt") == false)
            {
                string createLine = $"{totalPlayerTurns} | {getName}";
                File.WriteAllText("previousGames.txt", createLine);
            }
            else
            {
                string createLine = $"{totalPlayerTurns} | {getName}";

                List<string> newLines = new List<string>() { createLine };
                newLines.AddRange(File.ReadAllLines("previousGames.txt").ToList());

                for (int i = 0; i < newLines.Count; i += 1)
                {
                    if (i >= 12)
                    {
                        newLines.RemoveAt(i);
                    }
                }

                File.WriteAllLines("previousGames.txt", newLines);
            }

            ezScript.ShowControlGroup(mainMenuControls, true);
            ezScript.ShowControlGroup(gameplayControls, false);
            ezScript.ShowControlGroup(rewardControls, false);
            ezScript.ShowControlGroup(winControls, false);
            ezScript.ShowControlGroup(howToPlayControls, false);
            ezScript.ShowControlGroup(settingsControls, false);
            totalPlayerTurns = 0;
        }

        /// <summary>
        /// Updates the labels that are shown to the player during the game.
        /// </summary>
        private void UpdateLabels()
        {
            labelPlayer.Text = player.GetName();
            (int health, int maxHealth) = player.GetHealth();
            labelPlayerHealth.Text = $"Health : {health}/{maxHealth}";
            (int mana, int maxMana) = player.GetMana();
            labelPlayerMana.Text = $"Mana : {mana}/{maxMana}";

            labelEnemy.Text = enemy.GetName();
            (health, maxHealth) = enemy.GetHealth();
            labelEnemyHealth.Text = $"Health : {health}/{maxHealth}";
            (mana, maxMana) = enemy.GetMana();
            labelEnemyMana.Text = $"Mana : {mana}/{maxMana}";
        }

        private void SetUpGameEnd()
        {
            labelTurns.Text = $"You have beaten the game in {totalPlayerTurns} total turns.";

            listBoxWinHistory.Items.Clear();
            if (File.Exists("previousGames.txt") == true)
            {
                List<string> leaderboards = File.ReadAllLines("previousGames.txt").ToList();

                foreach (string score in leaderboards)
                {
                    listBoxWinHistory.Items.Add(score);
                }
            }
        }

        /// <summary>
        /// Replaces what the text in the richtextbox of the game would be if the text "None" was passed through it.
        /// None representing no text at all.
        /// </summary>
        /// <param name="text"></param>
        private void ReplaceCombatText(string text)
        {
            if (text == "None") richTextBoxCombat.Text = combatText;
            else richTextBoxCombat.Text = text;
        }

        private void ColourDamageText(int baseDamage, int damage)
        {
            string damageString = Convert.ToString(damage);
            int findPos = richTextBoxCombat.Find(damageString);

            if (findPos == -1) return;

            richTextBoxCombat.Select(findPos, damageString.Length);
            if (damage > baseDamage) richTextBoxCombat.SelectionColor = Color.Orange;
            else if (damage < baseDamage) richTextBoxCombat.SelectionColor = Color.Gray;
            else richTextBoxCombat.SelectionColor = Color.DarkRed;

            richTextBoxCombat.DeselectAll();
        }

        private void ColourHealText(int healAmount)
        {
            string healString = Convert.ToString(healAmount);
            int findPos = richTextBoxCombat.Find(healString);

            if (findPos == -1) return;
            ezScript.ColourInText(richTextBoxCombat, healString, Color.DarkGreen);
        }

        /// <summary>
        /// Changes what controls are enabled and disabled based on who's turn it is.
        /// </summary>
        /// <param name="turn"></param>
        private void ChangeControlsBasedOnTurn(string turn)
        {
            if (turn == "player")
            {
                buttonAttack.Enabled = true;
                buttonContinue.Enabled = false;
                listPlayerActions.Enabled = true;
            }
            else if (turn == "enemy")
            {
                buttonAttack.Enabled = false;
                buttonContinue.Enabled = true;
                listPlayerActions.Enabled = false;
            }
        }

        /// <summary>
        /// Sets the text that is displayed in the richtextbox of the game.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="source"></param>
        /// <param name="target"></param>
        private void SetCombatText(Action action, Entity source, Entity target)
        {
            string GetActionType = action.action.GetActionType();

            if (GetActionType == "Damage")
            {
                string GetDamageType = action.action.GetDamageType();
                int BaseDamage = action.action.GetPotency();
                int GetDamage = action.action.GetDamage(target);

                string textToDisplay = $"The {source.GetName()} attacked the {target.GetName()}, dealing {GetDamage} {GetDamageType} damage!";
                if (GetDamage < BaseDamage)
                {
                    textToDisplay += $"\nThe {target.GetName()}, seemed to resist the damage from this attack.";
                }
                else if (GetDamage > BaseDamage)
                {
                    textToDisplay += $"\nThe {target.GetName()}, seemed to take more damage from this attack.";
                }

                (int targetHealth, int targetMaxHealth) = target.GetHealth();
                if (targetHealth == 0)
                {
                    textToDisplay += $"\nThe {target.GetName()} has been defeated!";
                }

                combatText = textToDisplay;
                ReplaceCombatText("None");
                ColourDamageText(BaseDamage, GetDamage);

                switch (GetDamageType)
                {
                    case "Slash":
                        allSounds[0].Play();
                        break;
                    case "Bludgeon":
                        allSounds[1].Play();
                        break;
                    case "Pierce":
                        allSounds[2].Play();
                        break;
                    case "Fire":
                        allSounds[3].Play();
                        break;
                    case "Arcane":
                        allSounds[4].Play();
                        break;
                }
            }
            else if (GetActionType == "Heal")
            {
                int Potency = action.action.GetPotency();
                string textToDisplay = $"The {source.GetName()} healed {Potency} HP!";

                combatText = textToDisplay;
                ReplaceCombatText("None");
                ColourHealText(Potency);

                allSounds[5].Play();
            }
        }

        /// <summary>
        /// Sets up the battle, for which the player and a enemy will fight.
        /// If the firstBattle parameter is true, then player stats will be reset and the game will use the first enemy again.
        /// </summary>
        /// <param name="firstBattle"></param>
        private void SetUpBattle(bool firstBattle)
        {
            ezScript.ShowControlGroup(mainMenuControls, false);
            ezScript.ShowControlGroup(gameplayControls, true);
            ezScript.ShowControlGroup(rewardControls, false);
            ezScript.ShowControlGroup(winControls, false);
            ezScript.ShowControlGroup(howToPlayControls, false);
            ezScript.ShowControlGroup(settingsControls, false);

            if (firstBattle == true)
            {
                // Set up player info for the beginning of the game
                player.SetHealth(startPlayerHealth);
                player.SetMana(startPlayerMana);

                player.SetResistance("Slash", startPlayerResistances[0]);
                player.SetResistance("Bludgeon", startPlayerResistances[1]);
                player.SetResistance("Pierce", startPlayerResistances[2]);
                player.SetResistance("Fire", startPlayerResistances[3]);
                player.SetResistance("Arcane", startPlayerResistances[4]);

                player.RemoveAllActions();

                foreach (Action getAction in startPlayerActions)
                    player.AddAction(getAction);

                enemiesKilled = 0;
                SetUpEnemy(0);

                // Enable the random action button if user gets the max amount of actions available
                buttonRandomAbility.Enabled = true;
            }
            else
            {
                player.HealthIncrement(short.MaxValue);
                player.ManaIncrement(short.MaxValue);
                SetUpEnemy(enemiesKilled);
            }
            ReplaceCombatText("The battle has started!");
            ChangeControlsBasedOnTurn("player");
            UpdateLabels();
            RefreshActionList();
        }

        private void SetUpEnemy(int enemyID)
        {
            Entity selectedEnemy = enemyList[enemyID];

            enemy.SetName(selectedEnemy.GetName());

            pictureBoxEnemy.Image = selectedEnemy.GetImage();

            (int health, int maxHealth) = selectedEnemy.GetHealth();
            enemy.SetHealth(maxHealth);

            (int mana, int maxMana) = selectedEnemy.GetMana();
            enemy.SetMana(maxMana);

            enemy.RemoveAllActions();
            foreach (Action action in selectedEnemy.GetActions())
            {
                enemy.AddAction(action);
            }

            enemy.SetResistance("Slash", selectedEnemy.GetResistance("Slash"));
            enemy.SetResistance("Bludgeon", selectedEnemy.GetResistance("Bludgeon"));
            enemy.SetResistance("Pierce", selectedEnemy.GetResistance("Pierce"));
            enemy.SetResistance("Fire", selectedEnemy.GetResistance("Fire"));
            enemy.SetResistance("Arcane", selectedEnemy.GetResistance("Arcane"));
        }

        private void RefreshActionList()
        {
            listPlayerActions.Items.Clear();

            List<Action> playerActions = player.GetActions();
            foreach (Action action in playerActions)
            {
                listPlayerActions.Items.Add(action);
            }
        }

        private void RefreshRewards()
        {
            if (rewardsLeft == 0)
            {
                SetUpBattle(false);
            }
            else if (rewardsLeft == 1)
            {
                labelChooseReward.Text = "Choose your last reward.";
            }
            else
            {
                labelChooseReward.Text = $"You have {rewardsLeft} rewards to choose from.";
            }
        }

        private void buttonHowToPlay_Click(object sender, EventArgs e)
        {
            ezScript.ShowControlGroup(mainMenuControls, false);
            ezScript.ShowControlGroup(gameplayControls, false);
            ezScript.ShowControlGroup(rewardControls, false);
            ezScript.ShowControlGroup(winControls, false);
            ezScript.ShowControlGroup(howToPlayControls, true);
            ezScript.ShowControlGroup(settingsControls, false);
        }

        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            ezScript.ShowControlGroup(mainMenuControls, true);
            ezScript.ShowControlGroup(gameplayControls, false);
            ezScript.ShowControlGroup(rewardControls, false);
            ezScript.ShowControlGroup(winControls, false);
            ezScript.ShowControlGroup(howToPlayControls, false);
            ezScript.ShowControlGroup(settingsControls, false);
        }

        private void comboBoxHowToPlay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboBoxHowToPlay.Text;
            labelHowToPlayCategory.Text = category;

            switch (category)
            {
                case "Player":
                    richTextBoxInstructions.Text = "The player has health, and mana.\n\nThroughout the game you must keep the player always above 0 health and have the enemy defeated at the same time to win.\n\nIf the health of the player reaches 0, you will lose.";
                    ezScript.ColourInText(richTextBoxInstructions, "you will lose", Color.Red);
                    break;
                case "Enemies":
                    richTextBoxInstructions.Text = "The enemies also have health and mana.\n\n You must get the enemy to 0 health in order to win the battle, the enemy will always use random actions and also have randomised resistances.";
                    break;
                case "Actions":
                    richTextBoxInstructions.Text = "Some actions cost HP, sometimes it costs MP. There are 2 types of actions: Damage and Heal.\n\nThere are 5 damage types you can use against your enemy, if you use a attack that a enemy is weak to, the number turns orange, if you use a attack that a enemy resists, the number turns grey, otherwise it's red.\n\nHealing actions heal the player.";
                    ezScript.ColourInText(richTextBoxInstructions, "Damage", Color.DarkRed);
                    ezScript.ColourInText(richTextBoxInstructions, "Heal", Color.DarkGreen);
                    ezScript.ColourInText(richTextBoxInstructions, "orange", Color.Orange);
                    ezScript.ColourInText(richTextBoxInstructions, "grey", Color.Gray);
                    ezScript.ColourInText(richTextBoxInstructions, "red", Color.Red);
                    break;
                case "Rewards":
                    richTextBoxInstructions.Text = $"When you defeat the enemy, there are {maxRewards} rewards to choose from.\n\nOne increases your health by 50, one increases your max mana by 25, one gives you a random action, and one gives you 2 resistances and one weakness.";
                    ezScript.ColourInText(richTextBoxInstructions, "resistances", Color.Gray);
                    ezScript.ColourInText(richTextBoxInstructions, "weakness", Color.Orange);
                    break;
                case "Game Won":
                    richTextBoxInstructions.Text = "When you win the game, you are told how much turns you have won.\n\n You will have to enter your name, for it to be inputted in the list of your 12 recent completed games.";
                    break;
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            ezScript.ShowControlGroup(mainMenuControls, false);
            ezScript.ShowControlGroup(gameplayControls, false);
            ezScript.ShowControlGroup(rewardControls, false);
            ezScript.ShowControlGroup(winControls, false);
            ezScript.ShowControlGroup(howToPlayControls, false);
            ezScript.ShowControlGroup(settingsControls, true);
        }

        private void comboBoxFontOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Control> allControls = new List<Control>() { };
            allControls.AddRange(mainMenuControls);
            allControls.AddRange(gameplayControls);
            allControls.AddRange(rewardControls);
            allControls.AddRange(winControls);
            allControls.AddRange(howToPlayControls);
            allControls.AddRange(settingsControls);

            int stringIndex = 0;
            string chosenFont = comboBoxFonts.Text;

            List<string> fontFamilies = new List<string>()
            {
                "Segoe UI",
                "Courier New",
                "Lucida Console",
                "Times New Roman"
            };

            List<string> fontOptions = new List<string>()
            {
                "Default",
                "Courier",
                "Lucida",
                "Roman"
            };

            foreach (string font in fontOptions)
            {
                if (chosenFont == font) break;
                stringIndex += 1;
            }

            foreach (Control getControl in allControls)
            {
                if (getControl.Name != "pictureBoxEnemy")
                {
                    getControl.Font = new Font(fontFamilies[stringIndex], getControl.Font.Size);
                }
            }
        }

        private void comboBoxThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chosenTheme = comboBoxThemes.Text;

            foreach (Control getControl in backgroundControls)
            {
                switch (chosenTheme)
                {
                    case "Light":
                        getControl.BackColor = Color.WhiteSmoke;
                        break;
                    case "Dark":
                        getControl.BackColor = Color.DarkGray;
                        break;
                }
            }

            foreach (Control getControl in foregroundControls)
            {
                switch (chosenTheme)
                {
                    case "Light":
                        getControl.BackColor = Color.Gainsboro;
                        break;
                    case "Dark":
                        getControl.BackColor = Color.Gray;
                        break;
                }
            }

            foreach (Control getControl in middleControls)
            {
                switch (chosenTheme)
                {
                    case "Light":
                        getControl.BackColor = Color.White;
                        break;
                    case "Dark":
                        getControl.BackColor = Color.LightGray;
                        break;
                }
            }

            switch (chosenTheme)
            {
                case "Light":
                    Form1.ActiveForm.BackColor = Color.WhiteSmoke;
                    break;
                case "Dark":
                    Form1.ActiveForm.BackColor = Color.DarkGray;
                    break;
            }
        }

        private void buttonBackToMenu2_Click(object sender, EventArgs e)
        {
            ezScript.ShowControlGroup(mainMenuControls, true);
            ezScript.ShowControlGroup(gameplayControls, false);
            ezScript.ShowControlGroup(rewardControls, false);
            ezScript.ShowControlGroup(winControls, false);
            ezScript.ShowControlGroup(howToPlayControls, false);
            ezScript.ShowControlGroup(settingsControls, false);
        }
    }
}