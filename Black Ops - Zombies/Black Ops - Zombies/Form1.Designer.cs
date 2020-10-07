namespace Black_Ops___Zombies
{
    partial class BlackOpsZombies
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameStatusLabel = new DevExpress.XtraEditors.LabelControl();
            this.ClientOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GrabClients = new System.Windows.Forms.ToolStripMenuItem();
            this.GiveHostPoints = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientList = new System.Windows.Forms.ListView();
            this.Clients = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SelfOptionsGroupBox = new DevExpress.XtraEditors.GroupControl();
            this.NoTargetSwitch = new DevExpress.XtraEditors.ToggleSwitch();
            this.NoclipSwitch = new DevExpress.XtraEditors.ToggleSwitch();
            this.GodModeSwitch = new DevExpress.XtraEditors.ToggleSwitch();
            this.GiveSelfWeapons = new DevExpress.XtraEditors.ComboBoxEdit();
            this.DropWeaponButton = new DevExpress.XtraEditors.SimpleButton();
            this.ClientOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelfOptionsGroupBox)).BeginInit();
            this.SelfOptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoTargetSwitch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoclipSwitch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GodModeSwitch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GiveSelfWeapons.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GameStatusLabel
            // 
            this.GameStatusLabel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.GameStatusLabel.Appearance.Options.UseForeColor = true;
            this.GameStatusLabel.Location = new System.Drawing.Point(12, 577);
            this.GameStatusLabel.Name = "GameStatusLabel";
            this.GameStatusLabel.Size = new System.Drawing.Size(131, 13);
            this.GameStatusLabel.TabIndex = 0;
            this.GameStatusLabel.Text = "Game Status - Not Hooked!";
            // 
            // ClientOptions
            // 
            this.ClientOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GrabClients,
            this.GiveHostPoints});
            this.ClientOptions.Name = "ClientOptions";
            this.ClientOptions.Size = new System.Drawing.Size(172, 48);
            // 
            // GrabClients
            // 
            this.GrabClients.Name = "GrabClients";
            this.GrabClients.Size = new System.Drawing.Size(171, 22);
            this.GrabClients.Text = "Fetch Clients";
            this.GrabClients.Click += new System.EventHandler(this.GrabClients_Click);
            // 
            // GiveHostPoints
            // 
            this.GiveHostPoints.Name = "GiveHostPoints";
            this.GiveHostPoints.Size = new System.Drawing.Size(171, 22);
            this.GiveHostPoints.Text = "Give Points(HOST)";
            this.GiveHostPoints.Click += new System.EventHandler(this.GiveHostPoints_Click);
            // 
            // ClientList
            // 
            this.ClientList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Clients});
            this.ClientList.ContextMenuStrip = this.ClientOptions;
            this.ClientList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.ClientList.FullRowSelect = true;
            this.ClientList.GridLines = true;
            this.ClientList.HideSelection = false;
            this.ClientList.Location = new System.Drawing.Point(12, 2);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(570, 112);
            this.ClientList.TabIndex = 1;
            this.ClientList.UseCompatibleStateImageBehavior = false;
            this.ClientList.View = System.Windows.Forms.View.Details;
            // 
            // Clients
            // 
            this.Clients.Text = "Client Names";
            this.Clients.Width = 558;
            // 
            // SelfOptionsGroupBox
            // 
            this.SelfOptionsGroupBox.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(148)))), ((int)(((byte)(0)))));
            this.SelfOptionsGroupBox.AppearanceCaption.Options.UseForeColor = true;
            this.SelfOptionsGroupBox.Controls.Add(this.DropWeaponButton);
            this.SelfOptionsGroupBox.Controls.Add(this.GiveSelfWeapons);
            this.SelfOptionsGroupBox.Controls.Add(this.NoTargetSwitch);
            this.SelfOptionsGroupBox.Controls.Add(this.NoclipSwitch);
            this.SelfOptionsGroupBox.Controls.Add(this.GodModeSwitch);
            this.SelfOptionsGroupBox.Location = new System.Drawing.Point(13, 120);
            this.SelfOptionsGroupBox.Name = "SelfOptionsGroupBox";
            this.SelfOptionsGroupBox.Size = new System.Drawing.Size(569, 451);
            this.SelfOptionsGroupBox.TabIndex = 2;
            this.SelfOptionsGroupBox.Text = "Self Options";
            // 
            // NoTargetSwitch
            // 
            this.NoTargetSwitch.Location = new System.Drawing.Point(348, 42);
            this.NoTargetSwitch.Name = "NoTargetSwitch";
            this.NoTargetSwitch.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(148)))), ((int)(((byte)(0)))));
            this.NoTargetSwitch.Properties.Appearance.Options.UseForeColor = true;
            this.NoTargetSwitch.Properties.OffText = "No Target Off";
            this.NoTargetSwitch.Properties.OnText = "No Target  On";
            this.NoTargetSwitch.Size = new System.Drawing.Size(130, 20);
            this.NoTargetSwitch.TabIndex = 2;
            this.NoTargetSwitch.Toggled += new System.EventHandler(this.NoTargetSwitch_Toggled);
            // 
            // NoclipSwitch
            // 
            this.NoclipSwitch.Location = new System.Drawing.Point(211, 42);
            this.NoclipSwitch.Name = "NoclipSwitch";
            this.NoclipSwitch.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(148)))), ((int)(((byte)(0)))));
            this.NoclipSwitch.Properties.Appearance.Options.UseForeColor = true;
            this.NoclipSwitch.Properties.OffText = "Noclip Off";
            this.NoclipSwitch.Properties.OnText = "Noclip  On";
            this.NoclipSwitch.Size = new System.Drawing.Size(111, 20);
            this.NoclipSwitch.TabIndex = 1;
            this.NoclipSwitch.Toggled += new System.EventHandler(this.NoclipSwitch_Toggled);
            // 
            // GodModeSwitch
            // 
            this.GodModeSwitch.Location = new System.Drawing.Point(90, 42);
            this.GodModeSwitch.Name = "GodModeSwitch";
            this.GodModeSwitch.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(148)))), ((int)(((byte)(0)))));
            this.GodModeSwitch.Properties.Appearance.Options.UseForeColor = true;
            this.GodModeSwitch.Properties.OffText = "God Off";
            this.GodModeSwitch.Properties.OnText = "God On";
            this.GodModeSwitch.Size = new System.Drawing.Size(100, 20);
            this.GodModeSwitch.TabIndex = 0;
            this.GodModeSwitch.Toggled += new System.EventHandler(this.GodModeSwitch_Toggled);
            // 
            // GiveSelfWeapons
            // 
            this.GiveSelfWeapons.EditValue = "Give Weapon";
            this.GiveSelfWeapons.Location = new System.Drawing.Point(176, 356);
            this.GiveSelfWeapons.Name = "GiveSelfWeapons";
            this.GiveSelfWeapons.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.GiveSelfWeapons.Properties.Appearance.Options.UseForeColor = true;
            this.GiveSelfWeapons.Properties.Appearance.Options.UseTextOptions = true;
            this.GiveSelfWeapons.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GiveSelfWeapons.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GiveSelfWeapons.Properties.Items.AddRange(new object[] {
            "AK7u",
            "AUG ",
            "China_Lake",
            "Claymore",
            "Commando",
            "Crossbow",
            "Cz75",
            "cz75dw",
            "Dragonov",
            "Famas",
            "FnFal",
            "Frag",
            "FreezeGun",
            "G11",
            "Galil",
            "Hk21",
            "Hs10",
            "Ithica",
            "BallisticKnife",
            "A1",
            "m14",
            "m16",
            "m1911",
            "m72",
            "Mp5k",
            "Vmpl",
            "Pm63",
            "Python",
            "Raygun",
            "Rotweil72",
            "RPK",
            "SPAS",
            "Spectre"});
            this.GiveSelfWeapons.Size = new System.Drawing.Size(136, 20);
            this.GiveSelfWeapons.TabIndex = 3;
            this.GiveSelfWeapons.SelectedIndexChanged += new System.EventHandler(this.GiveSelfWeapons_SelectedIndexChanged);
            // 
            // DropWeaponButton
            // 
            this.DropWeaponButton.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(148)))), ((int)(((byte)(0)))));
            this.DropWeaponButton.Appearance.Options.UseForeColor = true;
            this.DropWeaponButton.Location = new System.Drawing.Point(318, 354);
            this.DropWeaponButton.Name = "DropWeaponButton";
            this.DropWeaponButton.Size = new System.Drawing.Size(75, 23);
            this.DropWeaponButton.TabIndex = 4;
            this.DropWeaponButton.Text = "Drop Weapon";
            this.DropWeaponButton.Click += new System.EventHandler(this.DropWeaponButton_Click);
            // 
            // BlackOpsZombies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 602);
            this.Controls.Add(this.SelfOptionsGroupBox);
            this.Controls.Add(this.ClientList);
            this.Controls.Add(this.GameStatusLabel);
            this.Name = "BlackOpsZombies";
            this.Text = "Black Ops - Zombies";
            this.Load += new System.EventHandler(this.BlackOpsZombies_Load);
            this.ClientOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SelfOptionsGroupBox)).EndInit();
            this.SelfOptionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NoTargetSwitch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoclipSwitch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GodModeSwitch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GiveSelfWeapons.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl GameStatusLabel;
        private System.Windows.Forms.ContextMenuStrip ClientOptions;
        private System.Windows.Forms.ToolStripMenuItem GrabClients;
        private System.Windows.Forms.ListView ClientList;
        private System.Windows.Forms.ColumnHeader Clients;
        private System.Windows.Forms.ToolStripMenuItem GiveHostPoints;
        private DevExpress.XtraEditors.GroupControl SelfOptionsGroupBox;
        private DevExpress.XtraEditors.ToggleSwitch NoTargetSwitch;
        private DevExpress.XtraEditors.ToggleSwitch NoclipSwitch;
        private DevExpress.XtraEditors.ToggleSwitch GodModeSwitch;
        private DevExpress.XtraEditors.ComboBoxEdit GiveSelfWeapons;
        private DevExpress.XtraEditors.SimpleButton DropWeaponButton;
    }
}

