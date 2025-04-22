namespace Otomasyon.Modul_Banka
{
    partial class frmBankaHareketleri
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtBakiye = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCikis = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtGiris = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtHesapNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtHesapAdi = new DevExpress.XtraEditors.ButtonEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.Liste = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BelgeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EvrakTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EvrakID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Giris = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cikis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Aciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SagTik = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BankaIsleminiDuzenle = new System.Windows.Forms.ToolStripMenuItem();
            this.bankaParaTransferiniDuzenle = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBakiye.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiris.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SagTik.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtBakiye);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtCikis);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtGiris);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtHesapNo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtHesapAdi);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(848, 159);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Banka Bilgileri";
            // 
            // txtBakiye
            // 
            this.txtBakiye.Location = new System.Drawing.Point(337, 107);
            this.txtBakiye.Name = "txtBakiye";
            this.txtBakiye.Properties.ReadOnly = true;
            this.txtBakiye.Size = new System.Drawing.Size(67, 22);
            this.txtBakiye.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(285, 110);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 16);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Bakiye";
            // 
            // txtCikis
            // 
            this.txtCikis.Location = new System.Drawing.Point(197, 107);
            this.txtCikis.Name = "txtCikis";
            this.txtCikis.Properties.ReadOnly = true;
            this.txtCikis.Size = new System.Drawing.Size(60, 22);
            this.txtCikis.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(151, 110);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(26, 16);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Çıkış";
            // 
            // txtGiris
            // 
            this.txtGiris.Location = new System.Drawing.Point(72, 107);
            this.txtGiris.Name = "txtGiris";
            this.txtGiris.Properties.ReadOnly = true;
            this.txtGiris.Size = new System.Drawing.Size(59, 22);
            this.txtGiris.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(28, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Giriş";
            // 
            // txtHesapNo
            // 
            this.txtHesapNo.Location = new System.Drawing.Point(128, 79);
            this.txtHesapNo.Name = "txtHesapNo";
            this.txtHesapNo.Properties.ReadOnly = true;
            this.txtHesapNo.Size = new System.Drawing.Size(161, 22);
            this.txtHesapNo.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 82);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Hesap No:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Hesap Türü/Ad:";
            // 
            // txtHesapAdi
            // 
            this.txtHesapAdi.Location = new System.Drawing.Point(128, 51);
            this.txtHesapAdi.Name = "txtHesapAdi";
            this.txtHesapAdi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtHesapAdi.Properties.ReadOnly = true;
            this.txtHesapAdi.Size = new System.Drawing.Size(161, 22);
            this.txtHesapAdi.TabIndex = 1;
            this.txtHesapAdi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtHesapAdi_ButtonClick);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.Liste);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 159);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(848, 351);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Hesap Listesi";
            // 
            // Liste
            // 
            this.Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Liste.EmbeddedNavigator.ContextMenuStrip = this.SagTik;
            this.Liste.Location = new System.Drawing.Point(2, 28);
            this.Liste.MainView = this.gridView1;
            this.Liste.Name = "Liste";
            this.Liste.Size = new System.Drawing.Size(844, 321);
            this.Liste.TabIndex = 0;
            this.Liste.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.BelgeNo,
            this.EvrakTuru,
            this.EvrakID,
            this.Giris,
            this.Cikis,
            this.Aciklama,
            this.Tarih});
            this.gridView1.GridControl = this.Liste;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.MinWidth = 25;
            this.ID.Name = "ID";
            this.ID.Width = 94;
            // 
            // BelgeNo
            // 
            this.BelgeNo.Caption = "Belge No";
            this.BelgeNo.FieldName = "BelgeNo";
            this.BelgeNo.MinWidth = 25;
            this.BelgeNo.Name = "BelgeNo";
            this.BelgeNo.OptionsColumn.AllowEdit = false;
            this.BelgeNo.OptionsColumn.AllowFocus = false;
            this.BelgeNo.OptionsColumn.FixedWidth = true;
            this.BelgeNo.Visible = true;
            this.BelgeNo.VisibleIndex = 0;
            this.BelgeNo.Width = 94;
            // 
            // EvrakTuru
            // 
            this.EvrakTuru.Caption = "Evrak Türü";
            this.EvrakTuru.FieldName = "EvrakTuru";
            this.EvrakTuru.MinWidth = 25;
            this.EvrakTuru.Name = "EvrakTuru";
            this.EvrakTuru.OptionsColumn.AllowEdit = false;
            this.EvrakTuru.OptionsColumn.AllowFocus = false;
            this.EvrakTuru.OptionsColumn.FixedWidth = true;
            this.EvrakTuru.Visible = true;
            this.EvrakTuru.VisibleIndex = 1;
            this.EvrakTuru.Width = 94;
            // 
            // EvrakID
            // 
            this.EvrakID.Caption = "Evrak ID";
            this.EvrakID.FieldName = "EvrakID";
            this.EvrakID.MinWidth = 25;
            this.EvrakID.Name = "EvrakID";
            this.EvrakID.Width = 94;
            // 
            // Giris
            // 
            this.Giris.Caption = "Giriş";
            this.Giris.FieldName = "Giris";
            this.Giris.MinWidth = 25;
            this.Giris.Name = "Giris";
            this.Giris.OptionsColumn.AllowEdit = false;
            this.Giris.OptionsColumn.AllowFocus = false;
            this.Giris.OptionsColumn.FixedWidth = true;
            this.Giris.Visible = true;
            this.Giris.VisibleIndex = 2;
            this.Giris.Width = 94;
            // 
            // Cikis
            // 
            this.Cikis.Caption = "Çıkış";
            this.Cikis.FieldName = "Cikis";
            this.Cikis.MinWidth = 25;
            this.Cikis.Name = "Cikis";
            this.Cikis.OptionsColumn.AllowEdit = false;
            this.Cikis.OptionsColumn.AllowFocus = false;
            this.Cikis.OptionsColumn.FixedWidth = true;
            this.Cikis.Visible = true;
            this.Cikis.VisibleIndex = 3;
            this.Cikis.Width = 94;
            // 
            // Aciklama
            // 
            this.Aciklama.Caption = "Açıklama";
            this.Aciklama.FieldName = "Aciklama";
            this.Aciklama.MinWidth = 25;
            this.Aciklama.Name = "Aciklama";
            this.Aciklama.OptionsColumn.AllowEdit = false;
            this.Aciklama.OptionsColumn.AllowFocus = false;
            this.Aciklama.Visible = true;
            this.Aciklama.VisibleIndex = 4;
            this.Aciklama.Width = 94;
            // 
            // Tarih
            // 
            this.Tarih.Caption = "Tarih";
            this.Tarih.FieldName = "Tarih";
            this.Tarih.MinWidth = 25;
            this.Tarih.Name = "Tarih";
            this.Tarih.OptionsColumn.AllowEdit = false;
            this.Tarih.OptionsColumn.AllowFocus = false;
            this.Tarih.OptionsColumn.FixedWidth = true;
            this.Tarih.Visible = true;
            this.Tarih.VisibleIndex = 5;
            this.Tarih.Width = 94;
            // 
            // SagTik
            // 
            this.SagTik.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SagTik.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BankaIsleminiDuzenle,
            this.bankaParaTransferiniDuzenle});
            this.SagTik.Name = "SagTik";
            this.SagTik.Size = new System.Drawing.Size(281, 80);
            this.SagTik.Opening += new System.ComponentModel.CancelEventHandler(this.SagTik_Opening);
            // 
            // BankaIsleminiDuzenle
            // 
            this.BankaIsleminiDuzenle.Enabled = false;
            this.BankaIsleminiDuzenle.Name = "BankaIsleminiDuzenle";
            this.BankaIsleminiDuzenle.Size = new System.Drawing.Size(280, 24);
            this.BankaIsleminiDuzenle.Text = "Banka İşlemini Düzenle";
            this.BankaIsleminiDuzenle.Click += new System.EventHandler(this.BankaIsleminiDuzenle_Click);
            // 
            // bankaParaTransferiniDuzenle
            // 
            this.bankaParaTransferiniDuzenle.Enabled = false;
            this.bankaParaTransferiniDuzenle.Name = "bankaParaTransferiniDuzenle";
            this.bankaParaTransferiniDuzenle.Size = new System.Drawing.Size(280, 24);
            this.bankaParaTransferiniDuzenle.Text = "Banka Para Transferini Düzenle";
            this.bankaParaTransferiniDuzenle.Click += new System.EventHandler(this.bankaParaTransferiniDuzenle_Click);
            // 
            // frmBankaHareketleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 510);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBankaHareketleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banka Hareketleri";
            this.Load += new System.EventHandler(this.frmBankaHareketleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBakiye.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCikis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGiris.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHesapAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Liste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.SagTik.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtGiris;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtHesapNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtBakiye;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtCikis;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl Liste;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn BelgeNo;
        private DevExpress.XtraGrid.Columns.GridColumn EvrakTuru;
        private DevExpress.XtraGrid.Columns.GridColumn EvrakID;
        private DevExpress.XtraGrid.Columns.GridColumn Giris;
        private DevExpress.XtraGrid.Columns.GridColumn Cikis;
        private DevExpress.XtraGrid.Columns.GridColumn Aciklama;
        private DevExpress.XtraGrid.Columns.GridColumn Tarih;
        private DevExpress.XtraEditors.ButtonEdit txtHesapAdi;
        private System.Windows.Forms.ContextMenuStrip SagTik;
        private System.Windows.Forms.ToolStripMenuItem BankaIsleminiDuzenle;
        private System.Windows.Forms.ToolStripMenuItem bankaParaTransferiniDuzenle;
    }
}