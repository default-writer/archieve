using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SharpKeys
{
    /// <summary>
    /// Summary description for Dialog_Main.
    /// </summary>
    partial class MainWindow
    {
        System.Windows.Forms.ListView lvKeys;
        Button btnSave;
        Button btnClose;
        Button btnAdd;
        Button btnDelete;
        Button btnEdit;
        System.Windows.Forms.ColumnHeader lvcFrom;
        System.Windows.Forms.ColumnHeader lvcTo;
        Button btnDeleteAll;
        System.Windows.Forms.Label label1;
        System.Windows.Forms.Label label2;
        System.Windows.Forms.LinkLabel urlMain;
        System.Windows.Forms.MenuItem menuItem5;
        System.Windows.Forms.MenuItem mniAdd;
        System.Windows.Forms.MenuItem mniEdit;
        System.Windows.Forms.MenuItem mniDelete;
        System.Windows.Forms.MenuItem mniDeleteAll;
        System.Windows.Forms.ContextMenu mnuPop;
        Panel mainPanel;
        LinkLabel urlCode;
        TableLayoutPanel tableLayoutPanel1;

#pragma warning disable CS0649
        /// <summary>
        /// Required designer variable.
        /// </summary>
        Container components;
#pragma warning restore CS0649

        public MainWindow() => InitializeComponent();

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lvKeys = new System.Windows.Forms.ListView();
            this.lvcFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvcTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuPop = new System.Windows.Forms.ContextMenu();
            this.mniAdd = new System.Windows.Forms.MenuItem();
            this.mniEdit = new System.Windows.Forms.MenuItem();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mniDeleteAll = new System.Windows.Forms.MenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.urlMain = new System.Windows.Forms.LinkLabel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.urlCode = new System.Windows.Forms.LinkLabel();
            this.mainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvKeys
            // 
            this.lvKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvcFrom,
            this.lvcTo});
            this.lvKeys.ContextMenu = this.mnuPop;
            this.lvKeys.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvKeys.FullRowSelect = true;
            this.lvKeys.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvKeys.HideSelection = false;
            this.lvKeys.Location = new System.Drawing.Point(13, 15);
            this.lvKeys.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvKeys.MultiSelect = false;
            this.lvKeys.Name = "lvKeys";
            this.lvKeys.Size = new System.Drawing.Size(821, 460);
            this.lvKeys.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvKeys.TabIndex = 0;
            this.lvKeys.UseCompatibleStateImageBehavior = false;
            this.lvKeys.View = System.Windows.Forms.View.Details;
            this.lvKeys.SelectedIndexChanged += new System.EventHandler(this.LvKeys_SelectedIndexChanged);
            this.lvKeys.DoubleClick += new System.EventHandler(this.LvKeys_DoubleClick);
            // 
            // lvcFrom
            // 
            this.lvcFrom.Text = "From:";
            // 
            // lvcTo
            // 
            this.lvcTo.Text = "To:";
            // 
            // mnuPop
            // 
            this.mnuPop.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniAdd,
            this.mniEdit,
            this.mniDelete,
            this.menuItem5,
            this.mniDeleteAll});
            // 
            // mniAdd
            // 
            this.mniAdd.Index = 0;
            this.mniAdd.Text = "Add";
            this.mniAdd.Click += new System.EventHandler(this.MniAdd_Click);
            // 
            // mniEdit
            // 
            this.mniEdit.Index = 1;
            this.mniEdit.Text = "Edit";
            this.mniEdit.Click += new System.EventHandler(this.MniEdit_Click);
            // 
            // mniDelete
            // 
            this.mniDelete.Index = 2;
            this.mniDelete.Text = "Delete";
            this.mniDelete.Click += new System.EventHandler(this.MniDelete_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.Text = "-";
            // 
            // mniDeleteAll
            // 
            this.mniDeleteAll.Index = 4;
            this.mniDeleteAll.Text = "Delete All";
            this.mniDeleteAll.Click += new System.EventHandler(this.MniDeleteAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(559, 485);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(159, 37);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Write to Registry";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(727, 485);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(108, 37);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(13, 485);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 37);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(245, 485);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 37);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(129, 485);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(108, 37);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAll.Location = new System.Drawing.Point(361, 485);
            this.btnDeleteAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(108, 37);
            this.btnDeleteAll.TabIndex = 4;
            this.btnDeleteAll.Text = "De&lete All";
            this.btnDeleteAll.Click += new System.EventHandler(this.BtnDeleteAll_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "BetterSharpKeys 1.0 - Copyright 2018 experimentalcommunity.org";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(4, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 26);
            this.label2.TabIndex = 10;
            this.label2.Text = "Registry hack for remapping keys for Windows";
            // 
            // urlMain
            // 
            this.urlMain.AutoSize = true;
            this.urlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlMain.Location = new System.Drawing.Point(427, 25);
            this.urlMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.urlMain.Name = "urlMain";
            this.urlMain.Size = new System.Drawing.Size(416, 26);
            this.urlMain.TabIndex = 11;
            this.urlMain.TabStop = true;
            this.urlMain.Text = "https://sharpkeys.experimentalcommunity.org/";
            this.urlMain.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.urlMain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UrlMain_MainLinkClicked);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.Controls.Add(this.tableLayoutPanel1);
            this.mainPanel.Controls.Add(this.lvKeys);
            this.mainPanel.Controls.Add(this.btnAdd);
            this.mainPanel.Controls.Add(this.btnEdit);
            this.mainPanel.Controls.Add(this.btnDelete);
            this.mainPanel.Controls.Add(this.btnDeleteAll);
            this.mainPanel.Controls.Add(this.btnSave);
            this.mainPanel.Controls.Add(this.btnClose);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(847, 628);
            this.mainPanel.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.urlCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.urlMain, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 577);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(847, 51);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // urlCode
            // 
            this.urlCode.AutoSize = true;
            this.urlCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlCode.Location = new System.Drawing.Point(427, 0);
            this.urlCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.urlCode.Name = "urlCode";
            this.urlCode.Size = new System.Drawing.Size(416, 25);
            this.urlCode.TabIndex = 11;
            this.urlCode.TabStop = true;
            this.urlCode.Text = "https://github.com/hack2root/sharpkeys/";
            this.urlCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.urlCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UrlMain_CodeLinkClicked);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(847, 628);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainWindow";
            this.Text = "SharpKeys";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainWindow_Closing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.mainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code
    }
}