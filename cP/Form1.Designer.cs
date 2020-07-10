namespace cP
{
    partial class mainWindow
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
            this.listBonusInfo = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabForm = new System.Windows.Forms.TabControl();
            this.backGroundPayList = new System.Windows.Forms.TabPage();
            this.getPayInfo = new System.Windows.Forms.Button();
            this.initBynPayInfo = new System.Windows.Forms.Button();
            this.listPayInfo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backGroundForPersonnelInfo = new System.Windows.Forms.TabPage();
            this.initPersonnelInfo = new System.Windows.Forms.Button();
            this.listPersonnelInfo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listEmployeeInfo = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upperContexMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.listBonusInfo)).BeginInit();
            this.tabForm.SuspendLayout();
            this.backGroundPayList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listPayInfo)).BeginInit();
            this.backGroundForPersonnelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listPersonnelInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listEmployeeInfo)).BeginInit();
            this.upperContexMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBonusInfo
            // 
            this.listBonusInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listBonusInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listBonusInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3});
            this.listBonusInfo.Location = new System.Drawing.Point(747, 0);
            this.listBonusInfo.Name = "listBonusInfo";
            this.listBonusInfo.RowHeadersWidth = 50;
            this.listBonusInfo.RowTemplate.Height = 24;
            this.listBonusInfo.Size = new System.Drawing.Size(715, 400);
            this.listBonusInfo.TabIndex = 2;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 149.7326F;
            this.Column7.HeaderText = "Has-number";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 83.42246F;
            this.Column1.HeaderText = "Должность";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 83.42246F;
            this.Column2.HeaderText = "Стаж";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 83.42246F;
            this.Column3.HeaderText = "Процент";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // tabForm
            // 
            this.tabForm.Controls.Add(this.backGroundPayList);
            this.tabForm.Controls.Add(this.backGroundForPersonnelInfo);
            this.tabForm.Location = new System.Drawing.Point(12, 31);
            this.tabForm.Name = "tabForm";
            this.tabForm.SelectedIndex = 0;
            this.tabForm.Size = new System.Drawing.Size(1470, 570);
            this.tabForm.TabIndex = 4;
            // 
            // backGroundPayList
            // 
            this.backGroundPayList.Controls.Add(this.getPayInfo);
            this.backGroundPayList.Controls.Add(this.initBynPayInfo);
            this.backGroundPayList.Controls.Add(this.listPayInfo);
            this.backGroundPayList.Controls.Add(this.listBonusInfo);
            this.backGroundPayList.Location = new System.Drawing.Point(4, 25);
            this.backGroundPayList.Name = "backGroundPayList";
            this.backGroundPayList.Padding = new System.Windows.Forms.Padding(3);
            this.backGroundPayList.Size = new System.Drawing.Size(1462, 541);
            this.backGroundPayList.TabIndex = 0;
            this.backGroundPayList.Text = "Информация о заработной плате";
            this.backGroundPayList.UseVisualStyleBackColor = true;
            // 
            // getPayInfo
            // 
            this.getPayInfo.Location = new System.Drawing.Point(142, 409);
            this.getPayInfo.Name = "getPayInfo";
            this.getPayInfo.Size = new System.Drawing.Size(158, 49);
            this.getPayInfo.TabIndex = 7;
            this.getPayInfo.Text = "Узнать информацию о з/п должности";
            this.getPayInfo.UseVisualStyleBackColor = true;
            this.getPayInfo.Click += new System.EventHandler(this.getPayInfo_Click);
            // 
            // initBynPayInfo
            // 
            this.initBynPayInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.initBynPayInfo.Location = new System.Drawing.Point(6, 408);
            this.initBynPayInfo.Name = "initBynPayInfo";
            this.initBynPayInfo.Size = new System.Drawing.Size(130, 50);
            this.initBynPayInfo.TabIndex = 6;
            this.initBynPayInfo.Text = "Инициализация инф-ии о з/п";
            this.initBynPayInfo.UseVisualStyleBackColor = true;
            this.initBynPayInfo.Click += new System.EventHandler(this.initBynTreePay_Click);
            // 
            // listPayInfo
            // 
            this.listPayInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listPayInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listPayInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.listPayInfo.Location = new System.Drawing.Point(0, 2);
            this.listPayInfo.Name = "listPayInfo";
            this.listPayInfo.RowHeadersWidth = 50;
            this.listPayInfo.RowTemplate.Height = 24;
            this.listPayInfo.Size = new System.Drawing.Size(715, 400);
            this.listPayInfo.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Должность";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Размер з/п";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Коэффициент";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // backGroundForPersonnelInfo
            // 
            this.backGroundForPersonnelInfo.Controls.Add(this.initPersonnelInfo);
            this.backGroundForPersonnelInfo.Controls.Add(this.listPersonnelInfo);
            this.backGroundForPersonnelInfo.Controls.Add(this.listEmployeeInfo);
            this.backGroundForPersonnelInfo.Location = new System.Drawing.Point(4, 25);
            this.backGroundForPersonnelInfo.Name = "backGroundForPersonnelInfo";
            this.backGroundForPersonnelInfo.Padding = new System.Windows.Forms.Padding(3);
            this.backGroundForPersonnelInfo.Size = new System.Drawing.Size(1462, 541);
            this.backGroundForPersonnelInfo.TabIndex = 1;
            this.backGroundForPersonnelInfo.Text = "Информация о сотрудниках";
            this.backGroundForPersonnelInfo.UseVisualStyleBackColor = true;
            // 
            // initPersonnelInfo
            // 
            this.initPersonnelInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.initPersonnelInfo.Location = new System.Drawing.Point(6, 408);
            this.initPersonnelInfo.Name = "initPersonnelInfo";
            this.initPersonnelInfo.Size = new System.Drawing.Size(156, 55);
            this.initPersonnelInfo.TabIndex = 7;
            this.initPersonnelInfo.Text = "Инициализация инф-ии о работниках\r\n";
            this.initPersonnelInfo.UseVisualStyleBackColor = true;
            this.initPersonnelInfo.Click += new System.EventHandler(this.initPersonnelInfo_Click);
            // 
            // listPersonnelInfo
            // 
            this.listPersonnelInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listPersonnelInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listPersonnelInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.listPersonnelInfo.Location = new System.Drawing.Point(0, 2);
            this.listPersonnelInfo.Name = "listPersonnelInfo";
            this.listPersonnelInfo.RowHeadersWidth = 50;
            this.listPersonnelInfo.RowTemplate.Height = 24;
            this.listPersonnelInfo.Size = new System.Drawing.Size(715, 400);
            this.listPersonnelInfo.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ФИО";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Должность";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Подразделение";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // listEmployeeInfo
            // 
            this.listEmployeeInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listEmployeeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listEmployeeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6});
            this.listEmployeeInfo.Location = new System.Drawing.Point(747, 0);
            this.listEmployeeInfo.Name = "listEmployeeInfo";
            this.listEmployeeInfo.RowHeadersWidth = 50;
            this.listEmployeeInfo.RowTemplate.Height = 24;
            this.listEmployeeInfo.Size = new System.Drawing.Size(715, 400);
            this.listEmployeeInfo.TabIndex = 0;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ФИО";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Стаж";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Коэффициент";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // upperContexMenu
            // 
            this.upperContexMenu.AutoSize = false;
            this.upperContexMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.upperContexMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.отчётToolStripMenuItem});
            this.upperContexMenu.Location = new System.Drawing.Point(0, 0);
            this.upperContexMenu.Name = "upperContexMenu";
            this.upperContexMenu.Size = new System.Drawing.Size(1482, 28);
            this.upperContexMenu.TabIndex = 6;
            this.upperContexMenu.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // отчётToolStripMenuItem
            // 
            this.отчётToolStripMenuItem.Name = "отчётToolStripMenuItem";
            this.отчётToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.отчётToolStripMenuItem.Text = "Отчёт";
            // 
            // mainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1482, 608);
            this.Controls.Add(this.tabForm);
            this.Controls.Add(this.upperContexMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "База данных сотрудиков";
            ((System.ComponentModel.ISupportInitialize)(this.listBonusInfo)).EndInit();
            this.tabForm.ResumeLayout(false);
            this.backGroundPayList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listPayInfo)).EndInit();
            this.backGroundForPersonnelInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listPersonnelInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listEmployeeInfo)).EndInit();
            this.upperContexMenu.ResumeLayout(false);
            this.upperContexMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView listBonusInfo;
        private System.Windows.Forms.TabControl tabForm;
        private System.Windows.Forms.TabPage backGroundPayList;
        private System.Windows.Forms.DataGridView listPayInfo;
        private System.Windows.Forms.TabPage backGroundForPersonnelInfo;
        private System.Windows.Forms.DataGridView listEmployeeInfo;
        private System.Windows.Forms.DataGridView listPersonnelInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button initBynPayInfo;
        private System.Windows.Forms.MenuStrip upperContexMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button initPersonnelInfo;
        private System.Windows.Forms.Button getPayInfo;
    }
}

