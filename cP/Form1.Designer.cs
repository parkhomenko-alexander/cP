namespace cP
{
    public partial class mainWindow
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
            this.button1 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.listPayInfo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backGroundForPersonnelInfo = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.initPersonnelInfo = new System.Windows.Forms.Button();
            this.listPersonnelInfo = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listEmployeeInfo = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button19 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listBonusInfo)).BeginInit();
            this.tabForm.SuspendLayout();
            this.backGroundPayList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listPayInfo)).BeginInit();
            this.backGroundForPersonnelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listPersonnelInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listEmployeeInfo)).BeginInit();
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
            this.listBonusInfo.Location = new System.Drawing.Point(739, 2);
            this.listBonusInfo.Name = "listBonusInfo";
            this.listBonusInfo.RowHeadersWidth = 50;
            this.listBonusInfo.RowTemplate.Height = 24;
            this.listBonusInfo.Size = new System.Drawing.Size(715, 400);
            this.listBonusInfo.TabIndex = 2;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 149.7326F;
            this.Column7.HeaderText = "хеш-адрес";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 83.42246F;
            this.Column1.HeaderText = "должность";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 83.42246F;
            this.Column2.HeaderText = "зп";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 83.42246F;
            this.Column3.HeaderText = "коэффициент";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // tabForm
            // 
            this.tabForm.Controls.Add(this.backGroundPayList);
            this.tabForm.Controls.Add(this.backGroundForPersonnelInfo);
            this.tabForm.Location = new System.Drawing.Point(12, 12);
            this.tabForm.Name = "tabForm";
            this.tabForm.SelectedIndex = 0;
            this.tabForm.Size = new System.Drawing.Size(1470, 570);
            this.tabForm.TabIndex = 4;
            // 
            // backGroundPayList
            // 
            this.backGroundPayList.Controls.Add(this.button1);
            this.backGroundPayList.Controls.Add(this.button10);
            this.backGroundPayList.Controls.Add(this.button11);
            this.backGroundPayList.Controls.Add(this.button12);
            this.backGroundPayList.Controls.Add(this.button13);
            this.backGroundPayList.Controls.Add(this.button14);
            this.backGroundPayList.Controls.Add(this.button15);
            this.backGroundPayList.Controls.Add(this.button16);
            this.backGroundPayList.Controls.Add(this.button17);
            this.backGroundPayList.Controls.Add(this.button18);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(627, 467);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 54);
            this.button1.TabIndex = 18;
            this.button1.Text = "Эксперименты над хеш-функциями";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(938, 467);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(300, 55);
            this.button10.TabIndex = 10;
            this.button10.Text = "Формирование отчета о заработной плате, стаже и премиях сотрудников";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(224, 467);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(300, 55);
            this.button11.TabIndex = 11;
            this.button11.Text = "Формирование отчета о подразделении, стаже и заработной плате сотрудников";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(224, 406);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(212, 55);
            this.button12.TabIndex = 12;
            this.button12.Text = "Поиск записи в Списке премий";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(6, 467);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(212, 55);
            this.button13.TabIndex = 13;
            this.button13.Text = "Удаление записи из Списка премий";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(6, 406);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(212, 55);
            this.button14.TabIndex = 14;
            this.button14.Text = "Добавление записи в Список премий";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(1026, 408);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(212, 55);
            this.button15.TabIndex = 15;
            this.button15.Text = "Поиск записи в списке Заработных плат";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(1244, 467);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(212, 55);
            this.button16.TabIndex = 16;
            this.button16.Text = "Удаление записи из списка Заработных плат";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(1242, 406);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(212, 55);
            this.button17.TabIndex = 17;
            this.button17.Text = "Добавление записи в список Заработных плат";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button18.Location = new System.Drawing.Point(547, 406);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(370, 55);
            this.button18.TabIndex = 9;
            this.button18.Text = "Загрузка справочников";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
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
            this.dataGridViewTextBoxColumn1.HeaderText = "должность";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "стаж";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "процент";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // backGroundForPersonnelInfo
            // 
            this.backGroundForPersonnelInfo.Controls.Add(this.button19);
            this.backGroundForPersonnelInfo.Controls.Add(this.button9);
            this.backGroundForPersonnelInfo.Controls.Add(this.button6);
            this.backGroundForPersonnelInfo.Controls.Add(this.button5);
            this.backGroundForPersonnelInfo.Controls.Add(this.button4);
            this.backGroundForPersonnelInfo.Controls.Add(this.button3);
            this.backGroundForPersonnelInfo.Controls.Add(this.button7);
            this.backGroundForPersonnelInfo.Controls.Add(this.button8);
            this.backGroundForPersonnelInfo.Controls.Add(this.button2);
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
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(936, 467);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(300, 55);
            this.button9.TabIndex = 8;
            this.button9.Text = "Формирование отчета о зп каждого сотрудника";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(224, 467);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(300, 55);
            this.button6.TabIndex = 8;
            this.button6.Text = "Формирование отчета о стаже и должности сотрудников";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(224, 406);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(212, 55);
            this.button5.TabIndex = 8;
            this.button5.Text = "Поиск записи в Кадровом списке";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 467);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(212, 55);
            this.button4.TabIndex = 8;
            this.button4.Text = "Удаление записи из Кадрового списка";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 406);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(212, 55);
            this.button3.TabIndex = 8;
            this.button3.Text = "Добавление записи в Кадровый список";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1024, 406);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(212, 55);
            this.button7.TabIndex = 8;
            this.button7.Text = "Поиск записи в списке Сотрудников";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1242, 467);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(212, 55);
            this.button8.TabIndex = 8;
            this.button8.Text = "Удаление записи из списка Сотрудников";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1242, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(212, 55);
            this.button2.TabIndex = 8;
            this.button2.Text = "Добавление записи в список Сотрудников";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // initPersonnelInfo
            // 
            this.initPersonnelInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.initPersonnelInfo.Location = new System.Drawing.Point(547, 406);
            this.initPersonnelInfo.Name = "initPersonnelInfo";
            this.initPersonnelInfo.Size = new System.Drawing.Size(370, 55);
            this.initPersonnelInfo.TabIndex = 7;
            this.initPersonnelInfo.Text = "Загрузка справочников";
            this.initPersonnelInfo.UseVisualStyleBackColor = true;
            this.initPersonnelInfo.Click += new System.EventHandler(this.initPersonnelInfo_Click);
            // 
            // listPersonnelInfo
            // 
            this.listPersonnelInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listPersonnelInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listPersonnelInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
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
            // Column8
            // 
            this.Column8.HeaderText = "хеш-адрес";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ФИО";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "должность";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "подразделение";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // listEmployeeInfo
            // 
            this.listEmployeeInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listEmployeeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listEmployeeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column4,
            this.Column5,
            this.Column6});
            this.listEmployeeInfo.Location = new System.Drawing.Point(739, 2);
            this.listEmployeeInfo.Name = "listEmployeeInfo";
            this.listEmployeeInfo.RowHeadersWidth = 50;
            this.listEmployeeInfo.RowTemplate.Height = 24;
            this.listEmployeeInfo.Size = new System.Drawing.Size(715, 400);
            this.listEmployeeInfo.TabIndex = 0;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "хеш-адрес";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ФИО";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "стаж";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "коэффициент";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(627, 467);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(204, 54);
            this.button19.TabIndex = 9;
            this.button19.Text = "Эксперимент по сравнению методов хеш-таблиц";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1482, 608);
            this.Controls.Add(this.tabForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных сотрудиков";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.listBonusInfo)).EndInit();
            this.tabForm.ResumeLayout(false);
            this.backGroundPayList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listPayInfo)).EndInit();
            this.backGroundForPersonnelInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listPersonnelInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listEmployeeInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView listBonusInfo;
        private System.Windows.Forms.TabControl tabForm;
        private System.Windows.Forms.TabPage backGroundPayList;
        private System.Windows.Forms.DataGridView listPayInfo;
        private System.Windows.Forms.TabPage backGroundForPersonnelInfo;
        private System.Windows.Forms.DataGridView listEmployeeInfo;
        private System.Windows.Forms.DataGridView listPersonnelInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button initPersonnelInfo;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button19;
    }
}

