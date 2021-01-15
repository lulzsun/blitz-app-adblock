
namespace Blitz_Patcher
{
    partial class Blitz_Patcher
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MainTP = new System.Windows.Forms.TabPage();
            this.PatchBTN = new System.Windows.Forms.Button();
            this.SettingsTP = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.BlitzSettingsTP = new System.Windows.Forms.TabPage();
            this.SaveSettingsBTN = new System.Windows.Forms.Button();
            this.BlitzNoUpdateCB = new System.Windows.Forms.CheckBox();
            this.BlitzAutoGuestCB = new System.Windows.Forms.CheckBox();
            this.FiltersSettingsTP = new System.Windows.Forms.TabPage();
            this.PeterLoweCB = new System.Windows.Forms.CheckBox();
            this.UBlockAdsCB = new System.Windows.Forms.CheckBox();
            this.UBlockPrivacyCB = new System.Windows.Forms.CheckBox();
            this.EasyListCB = new System.Windows.Forms.CheckBox();
            this.EasyPrivacyCB = new System.Windows.Forms.CheckBox();
            this.VersionLB = new System.Windows.Forms.Label();
            this.UnpatchButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.MainTP.SuspendLayout();
            this.SettingsTP.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.BlitzSettingsTP.SuspendLayout();
            this.FiltersSettingsTP.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MainTP);
            this.tabControl1.Controls.Add(this.SettingsTP);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(354, 168);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // MainTP
            // 
            this.MainTP.Controls.Add(this.UnpatchButton);
            this.MainTP.Controls.Add(this.PatchBTN);
            this.MainTP.Location = new System.Drawing.Point(4, 22);
            this.MainTP.Name = "MainTP";
            this.MainTP.Padding = new System.Windows.Forms.Padding(3);
            this.MainTP.Size = new System.Drawing.Size(346, 142);
            this.MainTP.TabIndex = 0;
            this.MainTP.Text = "Main";
            this.MainTP.UseVisualStyleBackColor = true;
            // 
            // PatchBTN
            // 
            this.PatchBTN.Location = new System.Drawing.Point(10, 6);
            this.PatchBTN.Name = "PatchBTN";
            this.PatchBTN.Size = new System.Drawing.Size(330, 79);
            this.PatchBTN.TabIndex = 1;
            this.PatchBTN.Text = "Patch";
            this.PatchBTN.UseVisualStyleBackColor = true;
            this.PatchBTN.Click += new System.EventHandler(this.PatchBTN_Click);
            // 
            // SettingsTP
            // 
            this.SettingsTP.Controls.Add(this.tabControl2);
            this.SettingsTP.Location = new System.Drawing.Point(4, 22);
            this.SettingsTP.Name = "SettingsTP";
            this.SettingsTP.Size = new System.Drawing.Size(346, 142);
            this.SettingsTP.TabIndex = 1;
            this.SettingsTP.Text = "Settings";
            this.SettingsTP.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.BlitzSettingsTP);
            this.tabControl2.Controls.Add(this.FiltersSettingsTP);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(340, 136);
            this.tabControl2.TabIndex = 2;
            // 
            // BlitzSettingsTP
            // 
            this.BlitzSettingsTP.Controls.Add(this.SaveSettingsBTN);
            this.BlitzSettingsTP.Controls.Add(this.BlitzNoUpdateCB);
            this.BlitzSettingsTP.Controls.Add(this.BlitzAutoGuestCB);
            this.BlitzSettingsTP.Location = new System.Drawing.Point(4, 22);
            this.BlitzSettingsTP.Name = "BlitzSettingsTP";
            this.BlitzSettingsTP.Padding = new System.Windows.Forms.Padding(3);
            this.BlitzSettingsTP.Size = new System.Drawing.Size(332, 110);
            this.BlitzSettingsTP.TabIndex = 0;
            this.BlitzSettingsTP.Text = "Blitz";
            this.BlitzSettingsTP.UseVisualStyleBackColor = true;
            // 
            // SaveSettingsBTN
            // 
            this.SaveSettingsBTN.Location = new System.Drawing.Point(6, 81);
            this.SaveSettingsBTN.Name = "SaveSettingsBTN";
            this.SaveSettingsBTN.Size = new System.Drawing.Size(320, 23);
            this.SaveSettingsBTN.TabIndex = 2;
            this.SaveSettingsBTN.Text = "Save Settings";
            this.SaveSettingsBTN.UseVisualStyleBackColor = true;
            this.SaveSettingsBTN.Click += new System.EventHandler(this.SaveSettingsBTN_Click);
            // 
            // BlitzNoUpdateCB
            // 
            this.BlitzNoUpdateCB.AutoSize = true;
            this.BlitzNoUpdateCB.Location = new System.Drawing.Point(6, 6);
            this.BlitzNoUpdateCB.Name = "BlitzNoUpdateCB";
            this.BlitzNoUpdateCB.Size = new System.Drawing.Size(106, 17);
            this.BlitzNoUpdateCB.TabIndex = 0;
            this.BlitzNoUpdateCB.Text = "Blitz - No Update";
            this.BlitzNoUpdateCB.UseVisualStyleBackColor = true;
            // 
            // BlitzAutoGuestCB
            // 
            this.BlitzAutoGuestCB.AutoSize = true;
            this.BlitzAutoGuestCB.Location = new System.Drawing.Point(6, 29);
            this.BlitzAutoGuestCB.Name = "BlitzAutoGuestCB";
            this.BlitzAutoGuestCB.Size = new System.Drawing.Size(107, 17);
            this.BlitzAutoGuestCB.TabIndex = 1;
            this.BlitzAutoGuestCB.Text = "Blitz - Auto Guest";
            this.BlitzAutoGuestCB.UseVisualStyleBackColor = true;
            // 
            // FiltersSettingsTP
            // 
            this.FiltersSettingsTP.Controls.Add(this.PeterLoweCB);
            this.FiltersSettingsTP.Controls.Add(this.UBlockAdsCB);
            this.FiltersSettingsTP.Controls.Add(this.UBlockPrivacyCB);
            this.FiltersSettingsTP.Controls.Add(this.EasyListCB);
            this.FiltersSettingsTP.Controls.Add(this.EasyPrivacyCB);
            this.FiltersSettingsTP.Location = new System.Drawing.Point(4, 22);
            this.FiltersSettingsTP.Name = "FiltersSettingsTP";
            this.FiltersSettingsTP.Padding = new System.Windows.Forms.Padding(3);
            this.FiltersSettingsTP.Size = new System.Drawing.Size(332, 110);
            this.FiltersSettingsTP.TabIndex = 1;
            this.FiltersSettingsTP.Text = "Filters";
            this.FiltersSettingsTP.UseVisualStyleBackColor = true;
            // 
            // PeterLoweCB
            // 
            this.PeterLoweCB.AutoSize = true;
            this.PeterLoweCB.Location = new System.Drawing.Point(115, 6);
            this.PeterLoweCB.Name = "PeterLoweCB";
            this.PeterLoweCB.Size = new System.Drawing.Size(80, 17);
            this.PeterLoweCB.TabIndex = 6;
            this.PeterLoweCB.Text = "Peter Lowe";
            this.PeterLoweCB.UseVisualStyleBackColor = true;
            // 
            // UBlockAdsCB
            // 
            this.UBlockAdsCB.AutoSize = true;
            this.UBlockAdsCB.Location = new System.Drawing.Point(6, 52);
            this.UBlockAdsCB.Name = "UBlockAdsCB";
            this.UBlockAdsCB.Size = new System.Drawing.Size(82, 17);
            this.UBlockAdsCB.TabIndex = 4;
            this.UBlockAdsCB.Text = "UBlock Ads";
            this.UBlockAdsCB.UseVisualStyleBackColor = true;
            // 
            // UBlockPrivacyCB
            // 
            this.UBlockPrivacyCB.AutoSize = true;
            this.UBlockPrivacyCB.Location = new System.Drawing.Point(6, 75);
            this.UBlockPrivacyCB.Name = "UBlockPrivacyCB";
            this.UBlockPrivacyCB.Size = new System.Drawing.Size(99, 17);
            this.UBlockPrivacyCB.TabIndex = 5;
            this.UBlockPrivacyCB.Text = "UBlock Privacy";
            this.UBlockPrivacyCB.UseVisualStyleBackColor = true;
            // 
            // EasyListCB
            // 
            this.EasyListCB.AutoSize = true;
            this.EasyListCB.Location = new System.Drawing.Point(6, 6);
            this.EasyListCB.Name = "EasyListCB";
            this.EasyListCB.Size = new System.Drawing.Size(65, 17);
            this.EasyListCB.TabIndex = 2;
            this.EasyListCB.Text = "EasyList";
            this.EasyListCB.UseVisualStyleBackColor = true;
            // 
            // EasyPrivacyCB
            // 
            this.EasyPrivacyCB.AutoSize = true;
            this.EasyPrivacyCB.Location = new System.Drawing.Point(6, 29);
            this.EasyPrivacyCB.Name = "EasyPrivacyCB";
            this.EasyPrivacyCB.Size = new System.Drawing.Size(84, 17);
            this.EasyPrivacyCB.TabIndex = 3;
            this.EasyPrivacyCB.Text = "EasyPrivacy";
            this.EasyPrivacyCB.UseVisualStyleBackColor = true;
            // 
            // VersionLB
            // 
            this.VersionLB.AutoSize = true;
            this.VersionLB.Location = new System.Drawing.Point(315, 167);
            this.VersionLB.Name = "VersionLB";
            this.VersionLB.Size = new System.Drawing.Size(19, 13);
            this.VersionLB.TabIndex = 0;
            this.VersionLB.Text = "v1";
            // 
            // UnpatchButton
            // 
            this.UnpatchButton.Location = new System.Drawing.Point(10, 91);
            this.UnpatchButton.Name = "UnpatchButton";
            this.UnpatchButton.Size = new System.Drawing.Size(330, 45);
            this.UnpatchButton.TabIndex = 2;
            this.UnpatchButton.Text = "Unpatch";
            this.UnpatchButton.UseVisualStyleBackColor = true;
            this.UnpatchButton.Click += new System.EventHandler(this.UnpatchButton_Click);
            // 
            // Blitz_Patcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 182);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.VersionLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Blitz_Patcher";
            this.Text = "Blitz_Patcher";
            this.Load += new System.EventHandler(this.Blitz_Patcher_Load);
            this.tabControl1.ResumeLayout(false);
            this.MainTP.ResumeLayout(false);
            this.SettingsTP.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.BlitzSettingsTP.ResumeLayout(false);
            this.BlitzSettingsTP.PerformLayout();
            this.FiltersSettingsTP.ResumeLayout(false);
            this.FiltersSettingsTP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MainTP;
        private System.Windows.Forms.TabPage SettingsTP;
        private System.Windows.Forms.Label VersionLB;
        private System.Windows.Forms.CheckBox BlitzNoUpdateCB;
        private System.Windows.Forms.CheckBox BlitzAutoGuestCB;
        private System.Windows.Forms.Button PatchBTN;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage BlitzSettingsTP;
        private System.Windows.Forms.TabPage FiltersSettingsTP;
        private System.Windows.Forms.CheckBox UBlockAdsCB;
        private System.Windows.Forms.CheckBox UBlockPrivacyCB;
        private System.Windows.Forms.CheckBox EasyListCB;
        private System.Windows.Forms.CheckBox EasyPrivacyCB;
        private System.Windows.Forms.CheckBox PeterLoweCB;
        private System.Windows.Forms.Button SaveSettingsBTN;
        private System.Windows.Forms.Button UnpatchButton;
    }
}