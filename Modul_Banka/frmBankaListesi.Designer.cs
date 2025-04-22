namespace Otomasyon.Modul_Banka
{
    partial class frmBankaListesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankaListesi));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtIban = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtHesapNo = new DevExpress.XtraEditors.TextEdit();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnAra = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtHesapAdi = new DevExpress.XtraEditors.TextEdit();
            this.Liste = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BankaAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HesapAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Iban = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HesapNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Bakiye = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Giris = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Çikis = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.Liste);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(995, 474);
            this.splitContainerControl1.SplitterPosition = 316;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(316, 470);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.txtIban);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.txtHesapNo);
            this.xtraTabPage1.Controls.Add(this.btnSil);
            this.xtraTabPage1.Controls.Add(this.btnAra);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.txtHesapAdi);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(314, 440);
            this.xtraTabPage1.Text = "Arama";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(20, 195);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 16);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "İban";
            // 
            // txtIban
            // 
            this.txtIban.Location = new System.Drawing.Point(20, 226);
            this.txtIban.Name = "txtIban";
            this.txtIban.Size = new System.Drawing.Size(195, 22);
            this.txtIban.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 117);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 16);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Hesap NO";
            // 
            // txtHesapNo
            // 
            this.txtHesapNo.Location = new System.Drawing.Point(20, 148);
            this.txtHesapNo.Name = "txtHesapNo";
            this.txtHesapNo.Size = new System.Drawing.Size(195, 22);
            this.txtHesapNo.TabIndex = 4;
            // 
            // btnSil
            // 
            this.btnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.Image")));
            this.btnSil.Location = new System.Drawing.Point(119, 294);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(96, 46);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "Temizle";
            // 
            // btnAra
            // 
            this.btnAra.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAra.ImageOptions.Image")));
            this.btnAra.Location = new System.Drawing.Point(20, 294);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(86, 46);
            this.btnAra.TabIndex = 2;
            this.btnAra.Text = "Ara";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Hesap Adı/Türü";
            // 
            // txtHesapAdi
            // 
            this.txtHesapAdi.Location = new System.Drawing.Point(20, 59);
            this.txtHesapAdi.Name = "txtHesapAdi";
            this.txtHesapAdi.Size = new System.Drawing.Size(195, 22);
            this.txtHesapAdi.TabIndex = 0;
            // 
            // Liste
            // 
            this.Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Liste.Location = new System.Drawing.Point(0, 0);
            this.Liste.MainView = this.gridView1;
            this.Liste.Name = "Liste";
            this.Liste.Size = new System.Drawing.Size(663, 470);
            this.Liste.TabIndex = 0;
            this.Liste.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.BankaAdi,
            this.HesapAdi,
            this.Iban,
            this.HesapNo,
            this.Bakiye,
            this.Giris,
            this.Çikis});
            this.gridView1.GridControl = this.Liste;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.MinWidth = 25;
            this.ID.Name = "ID";
            this.ID.Width = 94;
            // 
            // BankaAdi
            // 
            this.BankaAdi.Caption = "Banka Adı";
            this.BankaAdi.FieldName = "BankaAdi";
            this.BankaAdi.MinWidth = 25;
            this.BankaAdi.Name = "BankaAdi";
            this.BankaAdi.OptionsColumn.AllowEdit = false;
            this.BankaAdi.OptionsColumn.AllowFocus = false;
            this.BankaAdi.OptionsColumn.FixedWidth = true;
            this.BankaAdi.Visible = true;
            this.BankaAdi.VisibleIndex = 0;
            this.BankaAdi.Width = 94;
            // 
            // HesapAdi
            // 
            this.HesapAdi.Caption = "Hesap Adı";
            this.HesapAdi.FieldName = "HesapAdi";
            this.HesapAdi.MinWidth = 25;
            this.HesapAdi.Name = "HesapAdi";
            this.HesapAdi.OptionsColumn.AllowEdit = false;
            this.HesapAdi.OptionsColumn.AllowFocus = false;
            this.HesapAdi.OptionsColumn.FixedWidth = true;
            this.HesapAdi.Visible = true;
            this.HesapAdi.VisibleIndex = 1;
            this.HesapAdi.Width = 94;
            // 
            // Iban
            // 
            this.Iban.Caption = "İban";
            this.Iban.FieldName = "Iban";
            this.Iban.MinWidth = 25;
            this.Iban.Name = "Iban";
            this.Iban.Visible = true;
            this.Iban.VisibleIndex = 2;
            this.Iban.Width = 94;
            // 
            // HesapNo
            // 
            this.HesapNo.Caption = "Hesap No";
            this.HesapNo.FieldName = "HesapNo";
            this.HesapNo.MinWidth = 25;
            this.HesapNo.Name = "HesapNo";
            this.HesapNo.OptionsColumn.AllowEdit = false;
            this.HesapNo.OptionsColumn.AllowFocus = false;
            this.HesapNo.OptionsColumn.FixedWidth = true;
            this.HesapNo.Visible = true;
            this.HesapNo.VisibleIndex = 3;
            this.HesapNo.Width = 94;
            // 
            // Bakiye
            // 
            this.Bakiye.Caption = "Bakiye";
            this.Bakiye.FieldName = "Bakiye";
            this.Bakiye.MinWidth = 25;
            this.Bakiye.Name = "Bakiye";
            this.Bakiye.OptionsColumn.AllowEdit = false;
            this.Bakiye.OptionsColumn.AllowFocus = false;
            this.Bakiye.OptionsColumn.FixedWidth = true;
            this.Bakiye.Visible = true;
            this.Bakiye.VisibleIndex = 4;
            this.Bakiye.Width = 94;
            // 
            // Giris
            // 
            this.Giris.Caption = "Giriş";
            this.Giris.FieldName = "Giris";
            this.Giris.MinWidth = 25;
            this.Giris.Name = "Giris";
            this.Giris.OptionsColumn.AllowEdit = false;
            this.Giris.OptionsColumn.AllowFocus = false;
            this.Giris.Visible = true;
            this.Giris.VisibleIndex = 5;
            this.Giris.Width = 94;
            // 
            // Çikis
            // 
            this.Çikis.Caption = "Çıkış";
            this.Çikis.FieldName = "Çikis";
            this.Çikis.MinWidth = 25;
            this.Çikis.Name = "Çikis";
            this.Çikis.OptionsColumn.AllowEdit = false;
            this.Çikis.OptionsColumn.AllowFocus = false;
            this.Çikis.Visible = true;
            this.Çikis.VisibleIndex = 6;
            this.Çikis.Width = 94;
            // 
            // frmBankaListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 474);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBankaListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banka Listesi";
            this.Load += new System.EventHandler(this.frmBankaListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtIban;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtHesapNo;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnAra;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtHesapAdi;
        private DevExpress.XtraGrid.GridControl Liste;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn BankaAdi;
        private DevExpress.XtraGrid.Columns.GridColumn HesapAdi;
        private DevExpress.XtraGrid.Columns.GridColumn Iban;
        private DevExpress.XtraGrid.Columns.GridColumn HesapNo;
        private DevExpress.XtraGrid.Columns.GridColumn Bakiye;
        private DevExpress.XtraGrid.Columns.GridColumn Giris;
        private DevExpress.XtraGrid.Columns.GridColumn Çikis;
    }
}