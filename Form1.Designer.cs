namespace AssignmentProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelGame = new Label();
            buttonPlay = new Button();
            labelPlayer = new Label();
            labelEnemy = new Label();
            labelPlayerHealth = new Label();
            labelPlayerMana = new Label();
            labelEnemyHealth = new Label();
            labelEnemyMana = new Label();
            listPlayerActions = new ListBox();
            richTextBoxCombat = new RichTextBox();
            buttonAttack = new Button();
            buttonContinue = new Button();
            labelChooseReward = new Label();
            buttonIncreaseHP = new Button();
            buttonIncreaseMP = new Button();
            buttonRandomAbility = new Button();
            buttonNewResistances = new Button();
            labelGameWon = new Label();
            labelTurns = new Label();
            listBoxWinHistory = new ListBox();
            labelEnterName = new Label();
            textBoxEnterName = new TextBox();
            buttonEnterName = new Button();
            pictureBoxEnemy = new PictureBox();
            buttonHowToPlay = new Button();
            comboBoxHowToPlay = new ComboBox();
            labelHowToPlayCategory = new Label();
            buttonBackToMenu = new Button();
            richTextBoxInstructions = new RichTextBox();
            buttonSettings = new Button();
            comboBoxFonts = new ComboBox();
            buttonBackToMenu2 = new Button();
            comboBoxThemes = new ComboBox();
            labelFontSetting = new Label();
            labelThemeSetting = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEnemy).BeginInit();
            SuspendLayout();
            // 
            // labelGame
            // 
            labelGame.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            labelGame.Location = new Point(-1, 27);
            labelGame.Name = "labelGame";
            labelGame.Size = new Size(486, 50);
            labelGame.TabIndex = 0;
            labelGame.Text = "Game for an Assignment";
            labelGame.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonPlay
            // 
            buttonPlay.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            buttonPlay.Location = new Point(188, 195);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(109, 52);
            buttonPlay.TabIndex = 1;
            buttonPlay.Text = "Play";
            buttonPlay.UseVisualStyleBackColor = true;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // labelPlayer
            // 
            labelPlayer.AutoSize = true;
            labelPlayer.Font = new Font("Segoe UI", 18F, FontStyle.Underline, GraphicsUnit.Point);
            labelPlayer.Location = new Point(12, 152);
            labelPlayer.Name = "labelPlayer";
            labelPlayer.Size = new Size(78, 32);
            labelPlayer.TabIndex = 2;
            labelPlayer.Text = "Player";
            // 
            // labelEnemy
            // 
            labelEnemy.AutoSize = true;
            labelEnemy.Font = new Font("Segoe UI", 18F, FontStyle.Underline, GraphicsUnit.Point);
            labelEnemy.Location = new Point(12, 9);
            labelEnemy.Name = "labelEnemy";
            labelEnemy.Size = new Size(86, 32);
            labelEnemy.TabIndex = 3;
            labelEnemy.Text = "Enemy";
            // 
            // labelPlayerHealth
            // 
            labelPlayerHealth.AutoSize = true;
            labelPlayerHealth.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlayerHealth.Location = new Point(12, 184);
            labelPlayerHealth.Name = "labelPlayerHealth";
            labelPlayerHealth.Size = new Size(111, 25);
            labelPlayerHealth.TabIndex = 4;
            labelPlayerHealth.Text = "Health : 100";
            // 
            // labelPlayerMana
            // 
            labelPlayerMana.AutoSize = true;
            labelPlayerMana.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlayerMana.Location = new Point(12, 209);
            labelPlayerMana.Name = "labelPlayerMana";
            labelPlayerMana.Size = new Size(104, 25);
            labelPlayerMana.TabIndex = 5;
            labelPlayerMana.Text = "Mana : 100";
            // 
            // labelEnemyHealth
            // 
            labelEnemyHealth.AutoSize = true;
            labelEnemyHealth.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelEnemyHealth.Location = new Point(12, 41);
            labelEnemyHealth.Name = "labelEnemyHealth";
            labelEnemyHealth.Size = new Size(111, 25);
            labelEnemyHealth.TabIndex = 6;
            labelEnemyHealth.Text = "Health : 100";
            // 
            // labelEnemyMana
            // 
            labelEnemyMana.AutoSize = true;
            labelEnemyMana.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelEnemyMana.Location = new Point(12, 66);
            labelEnemyMana.Name = "labelEnemyMana";
            labelEnemyMana.Size = new Size(104, 25);
            labelEnemyMana.TabIndex = 7;
            labelEnemyMana.Text = "Mana : 100";
            // 
            // listPlayerActions
            // 
            listPlayerActions.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            listPlayerActions.FormattingEnabled = true;
            listPlayerActions.ItemHeight = 25;
            listPlayerActions.Location = new Point(245, 152);
            listPlayerActions.Name = "listPlayerActions";
            listPlayerActions.Size = new Size(226, 104);
            listPlayerActions.TabIndex = 8;
            listPlayerActions.SelectedIndexChanged += listPlayerActions_SelectedIndexChanged;
            // 
            // richTextBoxCombat
            // 
            richTextBoxCombat.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBoxCombat.Location = new Point(12, 287);
            richTextBoxCombat.Name = "richTextBoxCombat";
            richTextBoxCombat.ReadOnly = true;
            richTextBoxCombat.Size = new Size(460, 118);
            richTextBoxCombat.TabIndex = 10;
            richTextBoxCombat.Text = "";
            // 
            // buttonAttack
            // 
            buttonAttack.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAttack.Location = new Point(12, 411);
            buttonAttack.Name = "buttonAttack";
            buttonAttack.Size = new Size(155, 38);
            buttonAttack.TabIndex = 11;
            buttonAttack.Text = "Attack";
            buttonAttack.UseVisualStyleBackColor = true;
            buttonAttack.Click += buttonAttack_Click;
            // 
            // buttonContinue
            // 
            buttonContinue.Enabled = false;
            buttonContinue.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonContinue.Location = new Point(317, 411);
            buttonContinue.Name = "buttonContinue";
            buttonContinue.Size = new Size(155, 38);
            buttonContinue.TabIndex = 12;
            buttonContinue.Text = "Continue";
            buttonContinue.UseVisualStyleBackColor = true;
            buttonContinue.Click += buttonContinue_Click;
            // 
            // labelChooseReward
            // 
            labelChooseReward.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            labelChooseReward.Location = new Point(12, 138);
            labelChooseReward.Name = "labelChooseReward";
            labelChooseReward.Size = new Size(460, 30);
            labelChooseReward.TabIndex = 13;
            labelChooseReward.Text = "Choose a reward!";
            labelChooseReward.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonIncreaseHP
            // 
            buttonIncreaseHP.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            buttonIncreaseHP.Location = new Point(16, 181);
            buttonIncreaseHP.Name = "buttonIncreaseHP";
            buttonIncreaseHP.Size = new Size(140, 79);
            buttonIncreaseHP.TabIndex = 14;
            buttonIncreaseHP.Text = "Increase Health";
            buttonIncreaseHP.UseVisualStyleBackColor = true;
            buttonIncreaseHP.Click += buttonIncreaseHP_Click;
            // 
            // buttonIncreaseMP
            // 
            buttonIncreaseMP.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            buttonIncreaseMP.Location = new Point(173, 181);
            buttonIncreaseMP.Name = "buttonIncreaseMP";
            buttonIncreaseMP.Size = new Size(140, 79);
            buttonIncreaseMP.TabIndex = 15;
            buttonIncreaseMP.Text = "Increase Mana";
            buttonIncreaseMP.UseVisualStyleBackColor = true;
            buttonIncreaseMP.Click += buttonIncreaseMP_Click;
            // 
            // buttonRandomAbility
            // 
            buttonRandomAbility.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            buttonRandomAbility.Location = new Point(332, 181);
            buttonRandomAbility.Name = "buttonRandomAbility";
            buttonRandomAbility.Size = new Size(139, 79);
            buttonRandomAbility.TabIndex = 16;
            buttonRandomAbility.Text = "Random Ability";
            buttonRandomAbility.UseVisualStyleBackColor = true;
            buttonRandomAbility.Click += buttonRandomAbility_Click;
            // 
            // buttonNewResistances
            // 
            buttonNewResistances.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            buttonNewResistances.Location = new Point(154, 277);
            buttonNewResistances.Name = "buttonNewResistances";
            buttonNewResistances.Size = new Size(183, 79);
            buttonNewResistances.TabIndex = 17;
            buttonNewResistances.Text = "Random Resistances";
            buttonNewResistances.UseVisualStyleBackColor = true;
            buttonNewResistances.Click += buttonNewResistances_Click;
            // 
            // labelGameWon
            // 
            labelGameWon.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            labelGameWon.Location = new Point(-1, 27);
            labelGameWon.Name = "labelGameWon";
            labelGameWon.Size = new Size(473, 50);
            labelGameWon.TabIndex = 18;
            labelGameWon.Text = "You win!";
            labelGameWon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTurns
            // 
            labelTurns.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            labelTurns.Location = new Point(7, 91);
            labelTurns.Name = "labelTurns";
            labelTurns.RightToLeft = RightToLeft.No;
            labelTurns.Size = new Size(464, 31);
            labelTurns.TabIndex = 19;
            labelTurns.Text = "You have beaten the game in : 0 turns.";
            labelTurns.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listBoxWinHistory
            // 
            listBoxWinHistory.Enabled = false;
            listBoxWinHistory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            listBoxWinHistory.FormattingEnabled = true;
            listBoxWinHistory.ItemHeight = 25;
            listBoxWinHistory.Location = new Point(226, 145);
            listBoxWinHistory.Name = "listBoxWinHistory";
            listBoxWinHistory.Size = new Size(246, 304);
            listBoxWinHistory.TabIndex = 20;
            // 
            // labelEnterName
            // 
            labelEnterName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelEnterName.Location = new Point(12, 145);
            labelEnterName.Name = "labelEnterName";
            labelEnterName.Size = new Size(204, 211);
            labelEnterName.TabIndex = 21;
            labelEnterName.Text = "Enter in your name. It must be between 1 - 20 characters long. \r\nThis list will only show your last 12 attempts, with how many turns it took to beat the game.\r\n";
            // 
            // textBoxEnterName
            // 
            textBoxEnterName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxEnterName.Location = new Point(12, 373);
            textBoxEnterName.Name = "textBoxEnterName";
            textBoxEnterName.Size = new Size(199, 32);
            textBoxEnterName.TabIndex = 22;
            // 
            // buttonEnterName
            // 
            buttonEnterName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEnterName.Location = new Point(12, 411);
            buttonEnterName.Name = "buttonEnterName";
            buttonEnterName.Size = new Size(199, 38);
            buttonEnterName.TabIndex = 23;
            buttonEnterName.Text = "Enter";
            buttonEnterName.UseVisualStyleBackColor = true;
            buttonEnterName.Click += buttonEnterName_Click;
            // 
            // pictureBoxEnemy
            // 
            pictureBoxEnemy.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxEnemy.Location = new Point(344, 12);
            pictureBoxEnemy.Name = "pictureBoxEnemy";
            pictureBoxEnemy.Size = new Size(128, 128);
            pictureBoxEnemy.TabIndex = 24;
            pictureBoxEnemy.TabStop = false;
            // 
            // buttonHowToPlay
            // 
            buttonHowToPlay.Anchor = AnchorStyles.None;
            buttonHowToPlay.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            buttonHowToPlay.Location = new Point(148, 262);
            buttonHowToPlay.Name = "buttonHowToPlay";
            buttonHowToPlay.Size = new Size(187, 52);
            buttonHowToPlay.TabIndex = 25;
            buttonHowToPlay.Text = "How To Play";
            buttonHowToPlay.UseVisualStyleBackColor = true;
            buttonHowToPlay.Click += buttonHowToPlay_Click;
            // 
            // comboBoxHowToPlay
            // 
            comboBoxHowToPlay.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHowToPlay.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxHowToPlay.Items.AddRange(new object[] { "Player", "Enemies", "Actions", "Rewards", "Game Won" });
            comboBoxHowToPlay.Location = new Point(12, 13);
            comboBoxHowToPlay.Name = "comboBoxHowToPlay";
            comboBoxHowToPlay.Size = new Size(170, 33);
            comboBoxHowToPlay.TabIndex = 30;
            comboBoxHowToPlay.SelectedIndexChanged += comboBoxHowToPlay_SelectedIndexChanged;
            // 
            // labelHowToPlayCategory
            // 
            labelHowToPlayCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelHowToPlayCategory.Location = new Point(188, 13);
            labelHowToPlayCategory.Name = "labelHowToPlayCategory";
            labelHowToPlayCategory.Size = new Size(283, 33);
            labelHowToPlayCategory.TabIndex = 27;
            labelHowToPlayCategory.Text = "None selected";
            labelHowToPlayCategory.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buttonBackToMenu
            // 
            buttonBackToMenu.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonBackToMenu.Location = new Point(12, 411);
            buttonBackToMenu.Name = "buttonBackToMenu";
            buttonBackToMenu.Size = new Size(199, 38);
            buttonBackToMenu.TabIndex = 28;
            buttonBackToMenu.Text = "Back to Menu";
            buttonBackToMenu.UseVisualStyleBackColor = true;
            buttonBackToMenu.Click += buttonBackToMenu_Click;
            // 
            // richTextBoxInstructions
            // 
            richTextBoxInstructions.BackColor = SystemColors.Control;
            richTextBoxInstructions.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBoxInstructions.ForeColor = SystemColors.MenuText;
            richTextBoxInstructions.Location = new Point(12, 51);
            richTextBoxInstructions.Name = "richTextBoxInstructions";
            richTextBoxInstructions.ReadOnly = true;
            richTextBoxInstructions.Size = new Size(459, 354);
            richTextBoxInstructions.TabIndex = 29;
            richTextBoxInstructions.Text = "";
            // 
            // buttonSettings
            // 
            buttonSettings.Anchor = AnchorStyles.None;
            buttonSettings.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSettings.Location = new Point(168, 329);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(145, 52);
            buttonSettings.TabIndex = 31;
            buttonSettings.Text = "Settings";
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // comboBoxFonts
            // 
            comboBoxFonts.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFonts.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxFonts.FormattingEnabled = true;
            comboBoxFonts.Items.AddRange(new object[] { "Default", "Courier", "Lucida", "Roman" });
            comboBoxFonts.Location = new Point(36, 209);
            comboBoxFonts.Name = "comboBoxFonts";
            comboBoxFonts.Size = new Size(131, 33);
            comboBoxFonts.TabIndex = 32;
            comboBoxFonts.SelectedIndexChanged += comboBoxFontOptions_SelectedIndexChanged;
            // 
            // buttonBackToMenu2
            // 
            buttonBackToMenu2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonBackToMenu2.Location = new Point(142, 337);
            buttonBackToMenu2.Name = "buttonBackToMenu2";
            buttonBackToMenu2.Size = new Size(195, 38);
            buttonBackToMenu2.TabIndex = 33;
            buttonBackToMenu2.Text = "Back to Menu";
            buttonBackToMenu2.UseVisualStyleBackColor = true;
            buttonBackToMenu2.Click += buttonBackToMenu2_Click;
            // 
            // comboBoxThemes
            // 
            comboBoxThemes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxThemes.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxThemes.FormattingEnabled = true;
            comboBoxThemes.Items.AddRange(new object[] { "Light", "Dark" });
            comboBoxThemes.Location = new Point(317, 209);
            comboBoxThemes.Name = "comboBoxThemes";
            comboBoxThemes.Size = new Size(131, 33);
            comboBoxThemes.TabIndex = 34;
            comboBoxThemes.SelectedIndexChanged += comboBoxThemes_SelectedIndexChanged;
            // 
            // labelFontSetting
            // 
            labelFontSetting.Anchor = AnchorStyles.Top;
            labelFontSetting.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelFontSetting.Location = new Point(36, 181);
            labelFontSetting.Name = "labelFontSetting";
            labelFontSetting.Size = new Size(131, 25);
            labelFontSetting.TabIndex = 35;
            labelFontSetting.Text = "Chosen font";
            labelFontSetting.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelThemeSetting
            // 
            labelThemeSetting.Anchor = AnchorStyles.Top;
            labelThemeSetting.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelThemeSetting.Location = new Point(309, 181);
            labelThemeSetting.Name = "labelThemeSetting";
            labelThemeSetting.Size = new Size(145, 25);
            labelThemeSetting.TabIndex = 36;
            labelThemeSetting.Text = "Chosen theme";
            labelThemeSetting.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.Control;
            CausesValidation = false;
            ClientSize = new Size(484, 461);
            Controls.Add(labelThemeSetting);
            Controls.Add(labelFontSetting);
            Controls.Add(comboBoxThemes);
            Controls.Add(buttonBackToMenu2);
            Controls.Add(comboBoxFonts);
            Controls.Add(buttonSettings);
            Controls.Add(richTextBoxInstructions);
            Controls.Add(buttonBackToMenu);
            Controls.Add(labelHowToPlayCategory);
            Controls.Add(comboBoxHowToPlay);
            Controls.Add(buttonHowToPlay);
            Controls.Add(pictureBoxEnemy);
            Controls.Add(buttonEnterName);
            Controls.Add(textBoxEnterName);
            Controls.Add(labelEnterName);
            Controls.Add(listBoxWinHistory);
            Controls.Add(labelTurns);
            Controls.Add(labelGameWon);
            Controls.Add(buttonNewResistances);
            Controls.Add(buttonRandomAbility);
            Controls.Add(buttonIncreaseMP);
            Controls.Add(buttonIncreaseHP);
            Controls.Add(labelChooseReward);
            Controls.Add(buttonContinue);
            Controls.Add(buttonAttack);
            Controls.Add(richTextBoxCombat);
            Controls.Add(listPlayerActions);
            Controls.Add(labelEnemyMana);
            Controls.Add(labelEnemyHealth);
            Controls.Add(labelPlayerMana);
            Controls.Add(labelPlayerHealth);
            Controls.Add(labelEnemy);
            Controls.Add(labelPlayer);
            Controls.Add(buttonPlay);
            Controls.Add(labelGame);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Game";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxEnemy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelGame;
        private Button buttonPlay;
        private Label labelPlayer;
        private Label labelEnemy;
        private Label labelPlayerHealth;
        private Label labelPlayerMana;
        private Label labelEnemyHealth;
        private Label labelEnemyMana;
        private ListBox listPlayerActions;
        private RichTextBox richTextBoxCombat;
        private Button buttonAttack;
        private Button buttonContinue;
        private Label labelChooseReward;
        private Button buttonIncreaseHP;
        private Button buttonIncreaseMP;
        private Button buttonRandomAbility;
        private Button buttonNewResistances;
        private Label labelGameWon;
        private Label labelTurns;
        private ListBox listBoxWinHistory;
        private Label labelEnterName;
        private TextBox textBoxEnterName;
        private Button buttonEnterName;
        private PictureBox pictureBoxEnemy;
        private Button buttonHowToPlay;
        private ComboBox comboBoxHowToPlay;
        private Label labelHowToPlayCategory;
        private Button buttonBackToMenu;
        private RichTextBox richTextBoxInstructions;
        private Button buttonSettings;
        private ComboBox comboBoxFonts;
        private Button buttonBackToMenu2;
        private ComboBox comboBoxThemes;
        private Label labelFontSetting;
        private Label labelThemeSetting;
    }
}