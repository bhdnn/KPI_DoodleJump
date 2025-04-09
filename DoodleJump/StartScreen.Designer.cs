namespace DoodleJump
{
    partial class StartScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            this.Play = new System.Windows.Forms.Button();
            this.bg = new System.Windows.Forms.ComboBox();
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
            this.Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
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
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DoodleJump.Properties.Resources.doodlemenusolo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(314, 561);
            this.Controls.Add(this.bg);
            this.Controls.Add(this.Play);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Головне меню";
            this.Load += new System.EventHandler(this.StartScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.ComboBox bg;
    }
}