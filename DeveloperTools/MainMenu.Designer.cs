namespace DeveloperTools
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.panelDesktop = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.exitPuctureBix = new System.Windows.Forms.PictureBox();
            this.backPuctureBix = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl3 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitPuctureBix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backPuctureBix)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panelDesktop.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panelDesktop.Location = new System.Drawing.Point(0, 31);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.ShadowDecoration.Parent = this.panelDesktop;
            this.panelDesktop.Size = new System.Drawing.Size(305, 209);
            this.panelDesktop.TabIndex = 2;
            this.panelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktop_Paint);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.guna2Panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.guna2Panel3.Controls.Add(this.exitPuctureBix);
            this.guna2Panel3.Controls.Add(this.backPuctureBix);
            this.guna2Panel3.Controls.Add(this.nameLabel);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(305, 31);
            this.guna2Panel3.TabIndex = 5;
            // 
            // exitPuctureBix
            // 
            this.exitPuctureBix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitPuctureBix.Image = ((System.Drawing.Image)(resources.GetObject("exitPuctureBix.Image")));
            this.exitPuctureBix.Location = new System.Drawing.Point(279, 7);
            this.exitPuctureBix.Name = "exitPuctureBix";
            this.exitPuctureBix.Size = new System.Drawing.Size(16, 16);
            this.exitPuctureBix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exitPuctureBix.TabIndex = 8;
            this.exitPuctureBix.TabStop = false;
            this.exitPuctureBix.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // backPuctureBix
            // 
            this.backPuctureBix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backPuctureBix.Image = ((System.Drawing.Image)(resources.GetObject("backPuctureBix.Image")));
            this.backPuctureBix.Location = new System.Drawing.Point(257, 7);
            this.backPuctureBix.Name = "backPuctureBix";
            this.backPuctureBix.Size = new System.Drawing.Size(16, 16);
            this.backPuctureBix.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backPuctureBix.TabIndex = 7;
            this.backPuctureBix.TabStop = false;
            this.backPuctureBix.Visible = false;
            this.backPuctureBix.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(5, 4);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(169, 22);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Win Booster Developer Tool";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nameLabel.Click += new System.EventHandler(this.nameLabel_Click);
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.TargetControl = this.guna2Panel3;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.nameLabel;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 240);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.guna2Panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Win Booster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exitPuctureBix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backPuctureBix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel panelDesktop;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        public System.Windows.Forms.Label nameLabel;
        public System.Windows.Forms.PictureBox exitPuctureBix;
        public System.Windows.Forms.PictureBox backPuctureBix;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl3;
    }
}

