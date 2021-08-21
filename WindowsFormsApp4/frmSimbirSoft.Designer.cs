namespace ProjectSimbirSoft
{
    partial class FrmSimbirSoft
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogger = new System.Windows.Forms.Button();
            this.lbEnCodingWeb = new System.Windows.Forms.Label();
            this.cbEncoding = new System.Windows.Forms.ComboBox();
            this.btnAnaliz = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvStatic = new System.Windows.Forms.DataGridView();
            this.номерDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаСтатистикиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сайтDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vStaticBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSimbirSoft1 = new ProjectSimbirSoft.dsSimbirSoft();
            this.dgvStaticCount = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkvStatictblStaticCountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblStaticCountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterManager1 = new ProjectSimbirSoft.dsSimbirSoftTableAdapters.TableAdapterManager();
            this.tblStaticTableAdapter1 = new ProjectSimbirSoft.dsSimbirSoftTableAdapters.tblStaticTableAdapter();
            this.tblWebsiteTableAdapter1 = new ProjectSimbirSoft.dsSimbirSoftTableAdapters.tblWebsiteTableAdapter();
            this.tblStaticCountTableAdapter1 = new ProjectSimbirSoft.dsSimbirSoftTableAdapters.tblStaticCountTableAdapter();
            this.tblStaticBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vStaticTableAdapter = new ProjectSimbirSoft.dsSimbirSoftTableAdapters.vStaticTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vStaticBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSimbirSoft1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaticCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fkvStatictblStaticCountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStaticCountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStaticBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogger);
            this.panel1.Controls.Add(this.lbEnCodingWeb);
            this.panel1.Controls.Add(this.cbEncoding);
            this.panel1.Controls.Add(this.btnAnaliz);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtLink);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 57);
            this.panel1.TabIndex = 7;
            // 
            // btnLogger
            // 
            this.btnLogger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogger.Location = new System.Drawing.Point(586, 7);
            this.btnLogger.Name = "btnLogger";
            this.btnLogger.Size = new System.Drawing.Size(118, 23);
            this.btnLogger.TabIndex = 13;
            this.btnLogger.Text = "Журнал событий";
            this.btnLogger.UseVisualStyleBackColor = true;
            this.btnLogger.Click += new System.EventHandler(this.btnLogger_Click);
            // 
            // lbEnCodingWeb
            // 
            this.lbEnCodingWeb.AutoSize = true;
            this.lbEnCodingWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEnCodingWeb.Location = new System.Drawing.Point(13, 39);
            this.lbEnCodingWeb.Name = "lbEnCodingWeb";
            this.lbEnCodingWeb.Size = new System.Drawing.Size(191, 13);
            this.lbEnCodingWeb.TabIndex = 12;
            this.lbEnCodingWeb.Text = "Текущая кодировка страницы:";
            // 
            // cbEncoding
            // 
            this.cbEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEncoding.FormattingEnabled = true;
            this.cbEncoding.Location = new System.Drawing.Point(460, 7);
            this.cbEncoding.Name = "cbEncoding";
            this.cbEncoding.Size = new System.Drawing.Size(119, 21);
            this.cbEncoding.TabIndex = 11;
            // 
            // btnAnaliz
            // 
            this.btnAnaliz.Location = new System.Drawing.Point(379, 5);
            this.btnAnaliz.Name = "btnAnaliz";
            this.btnAnaliz.Size = new System.Drawing.Size(75, 23);
            this.btnAnaliz.TabIndex = 10;
            this.btnAnaliz.Text = "Анализ";
            this.btnAnaliz.UseVisualStyleBackColor = true;
            this.btnAnaliz.Click += new System.EventHandler(this.Analiz_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ссылка:";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(69, 7);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(304, 20);
            this.txtLink.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 57);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvStatic);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvStaticCount);
            this.splitContainer1.Size = new System.Drawing.Size(707, 270);
            this.splitContainer1.SplitterDistance = 373;
            this.splitContainer1.TabIndex = 8;
            // 
            // dgvStatic
            // 
            this.dgvStatic.AllowUserToAddRows = false;
            this.dgvStatic.AllowUserToDeleteRows = false;
            this.dgvStatic.AutoGenerateColumns = false;
            this.dgvStatic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерDataGridViewTextBoxColumn,
            this.датаСтатистикиDataGridViewTextBoxColumn,
            this.сайтDataGridViewTextBoxColumn});
            this.dgvStatic.DataSource = this.vStaticBindingSource;
            this.dgvStatic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatic.Location = new System.Drawing.Point(0, 0);
            this.dgvStatic.Name = "dgvStatic";
            this.dgvStatic.ReadOnly = true;
            this.dgvStatic.Size = new System.Drawing.Size(373, 270);
            this.dgvStatic.TabIndex = 0;
            // 
            // номерDataGridViewTextBoxColumn
            // 
            this.номерDataGridViewTextBoxColumn.DataPropertyName = "Номер";
            this.номерDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.номерDataGridViewTextBoxColumn.Name = "номерDataGridViewTextBoxColumn";
            this.номерDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // датаСтатистикиDataGridViewTextBoxColumn
            // 
            this.датаСтатистикиDataGridViewTextBoxColumn.DataPropertyName = "Дата статистики";
            this.датаСтатистикиDataGridViewTextBoxColumn.HeaderText = "Дата статистики";
            this.датаСтатистикиDataGridViewTextBoxColumn.Name = "датаСтатистикиDataGridViewTextBoxColumn";
            this.датаСтатистикиDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // сайтDataGridViewTextBoxColumn
            // 
            this.сайтDataGridViewTextBoxColumn.DataPropertyName = "Сайт";
            this.сайтDataGridViewTextBoxColumn.HeaderText = "Сайт";
            this.сайтDataGridViewTextBoxColumn.Name = "сайтDataGridViewTextBoxColumn";
            this.сайтDataGridViewTextBoxColumn.ReadOnly = true;
            this.сайтDataGridViewTextBoxColumn.Width = 200;
            // 
            // vStaticBindingSource
            // 
            this.vStaticBindingSource.DataMember = "vStatic";
            this.vStaticBindingSource.DataSource = this.dsSimbirSoft1;
            // 
            // dsSimbirSoft1
            // 
            this.dsSimbirSoft1.DataSetName = "dsSimbirSoft";
            this.dsSimbirSoft1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvStaticCount
            // 
            this.dgvStaticCount.AllowUserToAddRows = false;
            this.dgvStaticCount.AllowUserToDeleteRows = false;
            this.dgvStaticCount.AutoGenerateColumns = false;
            this.dgvStaticCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaticCount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn});
            this.dgvStaticCount.DataSource = this.fkvStatictblStaticCountBindingSource;
            this.dgvStaticCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaticCount.Location = new System.Drawing.Point(0, 0);
            this.dgvStaticCount.Name = "dgvStaticCount";
            this.dgvStaticCount.ReadOnly = true;
            this.dgvStaticCount.Size = new System.Drawing.Size(330, 270);
            this.dgvStaticCount.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Слово";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fkvStatictblStaticCountBindingSource
            // 
            this.fkvStatictblStaticCountBindingSource.DataMember = "fk_vStatic_tblStaticCount";
            this.fkvStatictblStaticCountBindingSource.DataSource = this.vStaticBindingSource;
            // 
            // tblStaticCountBindingSource
            // 
            this.tblStaticCountBindingSource.DataMember = "tblStaticCount";
            this.tblStaticCountBindingSource.DataSource = this.dsSimbirSoft1;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.tblStaticCountTableAdapter = null;
            this.tableAdapterManager1.tblStaticTableAdapter = this.tblStaticTableAdapter1;
            this.tableAdapterManager1.tblWebsiteTableAdapter = this.tblWebsiteTableAdapter1;
            this.tableAdapterManager1.UpdateOrder = ProjectSimbirSoft.dsSimbirSoftTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tblStaticTableAdapter1
            // 
            this.tblStaticTableAdapter1.ClearBeforeFill = true;
            // 
            // tblWebsiteTableAdapter1
            // 
            this.tblWebsiteTableAdapter1.ClearBeforeFill = true;
            // 
            // tblStaticCountTableAdapter1
            // 
            this.tblStaticCountTableAdapter1.ClearBeforeFill = true;
            // 
            // tblStaticBindingSource
            // 
            this.tblStaticBindingSource.DataMember = "tblStatic";
            this.tblStaticBindingSource.DataSource = this.dsSimbirSoft1;
            // 
            // vStaticTableAdapter
            // 
            this.vStaticTableAdapter.ClearBeforeFill = true;
            // 
            // FrmSimbirSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 327);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSimbirSoft";
            this.Text = "Анализатор сайта";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSimbirSoft_FormClosing);
            this.Load += new System.EventHandler(this.frmSimbirSoft_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vStaticBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSimbirSoft1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaticCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fkvStatictblStaticCountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStaticCountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblStaticBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbEnCodingWeb;
        private System.Windows.Forms.ComboBox cbEncoding;
        private System.Windows.Forms.Button btnAnaliz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLink;
        private dsSimbirSoft dsSimbirSoft1;
        private dsSimbirSoftTableAdapters.TableAdapterManager tableAdapterManager1;
        private dsSimbirSoftTableAdapters.tblStaticTableAdapter tblStaticTableAdapter1;
        private dsSimbirSoftTableAdapters.tblWebsiteTableAdapter tblWebsiteTableAdapter1;
        private dsSimbirSoftTableAdapters.tblStaticCountTableAdapter tblStaticCountTableAdapter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvStatic;
        private System.Windows.Forms.DataGridView dgvStaticCount;
        private System.Windows.Forms.BindingSource tblStaticBindingSource;
        private System.Windows.Forms.BindingSource vStaticBindingSource;
        private dsSimbirSoftTableAdapters.vStaticTableAdapter vStaticTableAdapter;
        private System.Windows.Forms.BindingSource tblStaticCountBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource fkvStatictblStaticCountBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаСтатистикиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сайтDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnLogger;
    }
}

