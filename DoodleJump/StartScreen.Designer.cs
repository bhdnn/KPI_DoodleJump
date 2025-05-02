namespace DoodleJump
{
    partial class StartScreen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            this.Play = new System.Windows.Forms.Button();
            this.bg = new System.Windows.Forms.ComboBox();
            this.buySoccerButton = new System.Windows.Forms.Button();
            this.labelCoins = new System.Windows.Forms.Label();
            this.buyNinja = new System.Windows.Forms.Button();
            this.buyNightNinja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Play
            // 
            this.Play.BackColor = System.Drawing.Color.Transparent;
            this.Play.BackgroundImage = global::DoodleJump.Properties.Resources.play;
            this.Play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Play.Cursor = System.Windows.Forms.Cursors.Default;
            this.Play.FlatAppearance.BorderSize = 0;
            this.Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Play.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Play.Location = new System.Drawing.Point(101, 233);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(115, 55);
            this.Play.TabIndex = 1;
            this.Play.UseVisualStyleBackColor = false;
            this.Play.Click += new System.EventHandler(this.LoadGame);
            // 
            // bg
            // 
            this.bg.FormattingEnabled = true;
            this.bg.Location = new System.Drawing.Point(166, 513);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(121, 21);
            this.bg.TabIndex = 2;
            // 
            // buySoccerButton
            // 
            this.buySoccerButton.Location = new System.Drawing.Point(197, 305);
            this.buySoccerButton.Name = "buySoccerButton";
            this.buySoccerButton.Size = new System.Drawing.Size(105, 51);
            this.buySoccerButton.TabIndex = 3;
            this.buySoccerButton.Text = "Придбати скін \"Soccer\" 20 монет";
            this.buySoccerButton.UseVisualStyleBackColor = true;
            this.buySoccerButton.Click += new System.EventHandler(this.buySoccerButton_Click);
            // 
            // labelCoins
            // 
            this.labelCoins.AutoSize = true;
            this.labelCoins.Location = new System.Drawing.Point(61, 9);
            this.labelCoins.Name = "labelCoins";
            this.labelCoins.Size = new System.Drawing.Size(0, 13);
            this.labelCoins.TabIndex = 4;
            this.labelCoins.Click += new System.EventHandler(this.label1_Click);
            // 
            // buyNinja
            // 
            this.buyNinja.Location = new System.Drawing.Point(197, 362);
            this.buyNinja.Name = "buyNinja";
            this.buyNinja.Size = new System.Drawing.Size(105, 51);
            this.buyNinja.TabIndex = 5;
            this.buyNinja.Text = "Придбати скін \"Ninja\" 30 монет";
            this.buyNinja.UseVisualStyleBackColor = true;
            this.buyNinja.Click += new System.EventHandler(this.buyNinja_Click);
            // 
            // buyNightNinja
            // 
            this.buyNightNinja.Location = new System.Drawing.Point(197, 419);
            this.buyNightNinja.Name = "buyNightNinja";
            this.buyNightNinja.Size = new System.Drawing.Size(105, 51);
            this.buyNightNinja.TabIndex = 6;
            this.buyNightNinja.Text = "Придбати скін \"NightNinja\" 50 монет";
            this.buyNightNinja.UseVisualStyleBackColor = true;
            this.buyNightNinja.Click += new System.EventHandler(this.buyNightNinja_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoodleJump.Properties.Resources.doodlemenusolo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(314, 561);
            this.Controls.Add(this.buyNightNinja);
            this.Controls.Add(this.buyNinja);
            this.Controls.Add(this.labelCoins);
            this.Controls.Add(this.buySoccerButton);
            this.Controls.Add(this.bg);
            this.Controls.Add(this.Play);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Головне меню";
            this.Load += new System.EventHandler(this.StartScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.ComboBox bg;
        private System.Windows.Forms.Button buySoccerButton;
        private System.Windows.Forms.Label labelCoins;
        private System.Windows.Forms.Button buyNinja;
        private System.Windows.Forms.Button buyNightNinja;
    }
}
