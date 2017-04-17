namespace QLMobileStore
{
    partial class frmQLMobileStore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLMobileStore));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trangChủToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giớiThiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loạiSảnPhẩmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinĐặtHàngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tinTứcToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ngườiQuảnTrịToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.timerChayChu = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trangChủToolStripMenuItem,
            this.sảnPhẩmToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(590, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            this.trangChủToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.giớiThiệuToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            this.trangChủToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.trangChủToolStripMenuItem.Text = "Trang chủ";
            // 
            // giớiThiệuToolStripMenuItem
            // 
            this.giớiThiệuToolStripMenuItem.Name = "giớiThiệuToolStripMenuItem";
            this.giớiThiệuToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.giớiThiệuToolStripMenuItem.Text = "Giới thiệu";
            this.giớiThiệuToolStripMenuItem.Click += new System.EventHandler(this.GioithieuToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.exitMenuStrip_Click);
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sảnPhẩmToolStripMenuItem1,
            this.loạiSảnPhẩmToolStripMenuItem1,
            this.ngườiQuảnTrịToolStripMenuItem1,
            this.thôngTinĐặtHàngToolStripMenuItem1,
            this.hóaĐơnToolStripMenuItem1,
            this.tinTứcToolStripMenuItem1});
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.sảnPhẩmToolStripMenuItem.Text = "Chương trình";
            // 
            // sảnPhẩmToolStripMenuItem1
            // 
            this.sảnPhẩmToolStripMenuItem1.Name = "sảnPhẩmToolStripMenuItem1";
            this.sảnPhẩmToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.sảnPhẩmToolStripMenuItem1.Text = "Sản phẩm";
            this.sảnPhẩmToolStripMenuItem1.Click += new System.EventHandler(this.SanPhamToolStripMenuItem_Click);
            // 
            // loạiSảnPhẩmToolStripMenuItem1
            // 
            this.loạiSảnPhẩmToolStripMenuItem1.Name = "loạiSảnPhẩmToolStripMenuItem1";
            this.loạiSảnPhẩmToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.loạiSảnPhẩmToolStripMenuItem1.Text = "Loại sản phẩm";
            this.loạiSảnPhẩmToolStripMenuItem1.Click += new System.EventHandler(this.LoaiSanPhamToolStripMenuItem1_Click);
            // 
            // thôngTinĐặtHàngToolStripMenuItem1
            // 
            this.thôngTinĐặtHàngToolStripMenuItem1.Name = "thôngTinĐặtHàngToolStripMenuItem1";
            this.thôngTinĐặtHàngToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.thôngTinĐặtHàngToolStripMenuItem1.Text = "Thông tin đặt hàng";
            // 
            // hóaĐơnToolStripMenuItem1
            // 
            this.hóaĐơnToolStripMenuItem1.Name = "hóaĐơnToolStripMenuItem1";
            this.hóaĐơnToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.hóaĐơnToolStripMenuItem1.Text = "Hóa đơn";
            // 
            // tinTứcToolStripMenuItem1
            // 
            this.tinTứcToolStripMenuItem1.Name = "tinTứcToolStripMenuItem1";
            this.tinTứcToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.tinTứcToolStripMenuItem1.Text = "Tin tức";
            // 
            // ngườiQuảnTrịToolStripMenuItem1
            // 
            this.ngườiQuảnTrịToolStripMenuItem1.Name = "ngườiQuảnTrịToolStripMenuItem1";
            this.ngườiQuảnTrịToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.ngườiQuảnTrịToolStripMenuItem1.Text = "Người quản trị";
            this.ngườiQuảnTrịToolStripMenuItem1.Click += new System.EventHandler(this.NguoiQuanTriToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(0, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(590, 60);
            this.label1.TabIndex = 8;
            this.label1.Text = "         MOBILE STORE DATABASE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerChayChu
            // 
            this.timerChayChu.Enabled = true;
            this.timerChayChu.Interval = 140;
            this.timerChayChu.Tick += new System.EventHandler(this.timerChayChu_Tick);
            // 
            // frmQLMobileStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 370);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmQLMobileStore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOBILE STORE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQLMobileStore_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trangChủToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loạiSảnPhẩmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thôngTinĐặtHàngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tinTứcToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ngườiQuảnTrịToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerChayChu;
        private System.Windows.Forms.ToolStripMenuItem giớiThiệuToolStripMenuItem;
    }
}