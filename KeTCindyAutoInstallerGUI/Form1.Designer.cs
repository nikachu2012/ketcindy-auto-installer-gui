namespace KeTCindyAutoInstallerGUI
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.StatusBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InstallButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.インストールするソフトを選択ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cinderella2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keTTeXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sumatraPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keTCindyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CinderellaVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeTCindyVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeTTeXVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaximaVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(0, 33);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10);
            this.label1.Size = new System.Drawing.Size(363, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "KeTCindy Auto Installer on GUI";
            // 
            // StatusBox
            // 
            this.StatusBox.BackColor = System.Drawing.SystemColors.Window;
            this.StatusBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusBox.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBox.Location = new System.Drawing.Point(0, 85);
            this.StatusBox.Multiline = true;
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.ReadOnly = true;
            this.StatusBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusBox.Size = new System.Drawing.Size(800, 310);
            this.StatusBox.TabIndex = 1;
            this.StatusBox.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.InstallButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel1.Location = new System.Drawing.Point(0, 395);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 55);
            this.panel1.TabIndex = 2;
            // 
            // InstallButton
            // 
            this.InstallButton.Enabled = false;
            this.InstallButton.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.InstallButton.Location = new System.Drawing.Point(5, 5);
            this.InstallButton.Margin = new System.Windows.Forms.Padding(5);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Padding = new System.Windows.Forms.Padding(5);
            this.InstallButton.Size = new System.Drawing.Size(182, 45);
            this.InstallButton.TabIndex = 0;
            this.InstallButton.Text = "Install";
            this.InstallButton.UseVisualStyleBackColor = true;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
            this.fileToolStripMenuItem.Text = "ファイル";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.closeToolStripMenuItem.Text = "閉じる";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.インストールするソフトを選択ToolStripMenuItem,
            this.CinderellaVersionToolStripMenuItem,
            this.KeTTeXVersionToolStripMenuItem,
            this.RVersionToolStripMenuItem,
            this.MaximaVersionToolStripMenuItem,
            this.KeTCindyVersionToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.configToolStripMenuItem.Text = "設定";
            // 
            // インストールするソフトを選択ToolStripMenuItem
            // 
            this.インストールするソフトを選択ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cinderella2ToolStripMenuItem,
            this.keTTeXToolStripMenuItem,
            this.rToolStripMenuItem,
            this.sumatraPDFToolStripMenuItem,
            this.maximaToolStripMenuItem,
            this.keTCindyToolStripMenuItem});
            this.インストールするソフトを選択ToolStripMenuItem.Name = "インストールするソフトを選択ToolStripMenuItem";
            this.インストールするソフトを選択ToolStripMenuItem.Size = new System.Drawing.Size(309, 34);
            this.インストールするソフトを選択ToolStripMenuItem.Text = "インストールするソフトを選択";
            // 
            // cinderella2ToolStripMenuItem
            // 
            this.cinderella2ToolStripMenuItem.Checked = true;
            this.cinderella2ToolStripMenuItem.CheckOnClick = true;
            this.cinderella2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cinderella2ToolStripMenuItem.Name = "cinderella2ToolStripMenuItem";
            this.cinderella2ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.cinderella2ToolStripMenuItem.Text = "Cinderella2";
            // 
            // keTTeXToolStripMenuItem
            // 
            this.keTTeXToolStripMenuItem.Checked = true;
            this.keTTeXToolStripMenuItem.CheckOnClick = true;
            this.keTTeXToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keTTeXToolStripMenuItem.Name = "keTTeXToolStripMenuItem";
            this.keTTeXToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.keTTeXToolStripMenuItem.Text = "KeTTeX";
            // 
            // rToolStripMenuItem
            // 
            this.rToolStripMenuItem.Checked = true;
            this.rToolStripMenuItem.CheckOnClick = true;
            this.rToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rToolStripMenuItem.Name = "rToolStripMenuItem";
            this.rToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.rToolStripMenuItem.Text = "R";
            // 
            // sumatraPDFToolStripMenuItem
            // 
            this.sumatraPDFToolStripMenuItem.Checked = true;
            this.sumatraPDFToolStripMenuItem.CheckOnClick = true;
            this.sumatraPDFToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sumatraPDFToolStripMenuItem.Name = "sumatraPDFToolStripMenuItem";
            this.sumatraPDFToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.sumatraPDFToolStripMenuItem.Text = "SumatraPDF";
            // 
            // maximaToolStripMenuItem
            // 
            this.maximaToolStripMenuItem.Checked = true;
            this.maximaToolStripMenuItem.CheckOnClick = true;
            this.maximaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.maximaToolStripMenuItem.Name = "maximaToolStripMenuItem";
            this.maximaToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.maximaToolStripMenuItem.Text = "Maxima";
            // 
            // keTCindyToolStripMenuItem
            // 
            this.keTCindyToolStripMenuItem.Checked = true;
            this.keTCindyToolStripMenuItem.CheckOnClick = true;
            this.keTCindyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.keTCindyToolStripMenuItem.Name = "keTCindyToolStripMenuItem";
            this.keTCindyToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.keTCindyToolStripMenuItem.Text = "KeTCindy";
            // 
            // CinderellaVersionToolStripMenuItem
            // 
            this.CinderellaVersionToolStripMenuItem.Name = "CinderellaVersionToolStripMenuItem";
            this.CinderellaVersionToolStripMenuItem.Size = new System.Drawing.Size(309, 34);
            this.CinderellaVersionToolStripMenuItem.Text = "Cinderellaのバージョン";
            // 
            // KeTCindyVersionToolStripMenuItem
            // 
            this.KeTCindyVersionToolStripMenuItem.Name = "KeTCindyVersionToolStripMenuItem";
            this.KeTCindyVersionToolStripMenuItem.Size = new System.Drawing.Size(309, 34);
            this.KeTCindyVersionToolStripMenuItem.Text = "KeTCindyのバージョン";
            // 
            // KeTTeXVersionToolStripMenuItem
            // 
            this.KeTTeXVersionToolStripMenuItem.Name = "KeTTeXVersionToolStripMenuItem";
            this.KeTTeXVersionToolStripMenuItem.Size = new System.Drawing.Size(309, 34);
            this.KeTTeXVersionToolStripMenuItem.Text = "KeTTeXのバージョン";
            // 
            // RVersionToolStripMenuItem
            // 
            this.RVersionToolStripMenuItem.Name = "RVersionToolStripMenuItem";
            this.RVersionToolStripMenuItem.Size = new System.Drawing.Size(309, 34);
            this.RVersionToolStripMenuItem.Text = "Rのバージョン";
            // 
            // MaximaVersionToolStripMenuItem
            // 
            this.MaximaVersionToolStripMenuItem.Name = "MaximaVersionToolStripMenuItem";
            this.MaximaVersionToolStripMenuItem.Size = new System.Drawing.Size(309, 34);
            this.MaximaVersionToolStripMenuItem.Text = "Maximaのバージョン";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "KeTCindy Auto Installer on GUI";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StatusBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KeTCindyVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KeTTeXVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem インストールするソフトを選択ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cinderella2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keTTeXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sumatraPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maximaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keTCindyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CinderellaVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaximaVersionToolStripMenuItem;
    }
}

