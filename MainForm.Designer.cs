namespace ShopeeReplayDownloader
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainStatusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            label1 = new Label();
            sessionTextBox = new TextBox();
            sessionButton = new Button();
            recordListBox = new ListBox();
            label2 = new Label();
            titleRichText = new RichTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            durationLabel = new Label();
            usernameLabel = new Label();
            label6 = new Label();
            label7 = new Label();
            viewsLabel = new Label();
            likesLabel = new Label();
            prepareButton = new Button();
            directoryTextBox = new TextBox();
            startNumeric = new NumericUpDown();
            endNumeric = new NumericUpDown();
            downloadButton = new Button();
            mergeButton = new Button();
            mainStatusStrip.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)startNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)endNumeric).BeginInit();
            SuspendLayout();
            // 
            // mainStatusStrip
            // 
            mainStatusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            mainStatusStrip.Location = new Point(0, 255);
            mainStatusStrip.Name = "mainStatusStrip";
            mainStatusStrip.Size = new Size(520, 22);
            mainStatusStrip.TabIndex = 0;
            mainStatusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Padding = new Padding(6, 0, 0, 0);
            statusLabel.Size = new Size(35, 17);
            statusLabel.Text = "Siap";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 1;
            label1.Text = "Session ID / URL:";
            // 
            // sessionTextBox
            // 
            sessionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sessionTextBox.Location = new Point(113, 12);
            sessionTextBox.Name = "sessionTextBox";
            sessionTextBox.Size = new Size(314, 23);
            sessionTextBox.TabIndex = 2;
            // 
            // sessionButton
            // 
            sessionButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sessionButton.Location = new Point(433, 12);
            sessionButton.Name = "sessionButton";
            sessionButton.Size = new Size(75, 23);
            sessionButton.TabIndex = 3;
            sessionButton.Text = "Lihat";
            sessionButton.UseVisualStyleBackColor = true;
            sessionButton.Click += OnSession;
            // 
            // recordListBox
            // 
            recordListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            recordListBox.FormattingEnabled = true;
            recordListBox.ItemHeight = 15;
            recordListBox.Location = new Point(12, 58);
            recordListBox.Name = "recordListBox";
            recordListBox.Size = new Size(120, 184);
            recordListBox.TabIndex = 4;
            recordListBox.SelectedIndexChanged += OnSelectRecord;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 5;
            label2.Text = "Record ID:";
            // 
            // titleRichText
            // 
            titleRichText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            titleRichText.BackColor = SystemColors.Control;
            titleRichText.BorderStyle = BorderStyle.None;
            titleRichText.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            titleRichText.Location = new Point(141, 41);
            titleRichText.Multiline = false;
            titleRichText.Name = "titleRichText";
            titleRichText.ReadOnly = true;
            titleRichText.ScrollBars = RichTextBoxScrollBars.None;
            titleRichText.Size = new Size(367, 29);
            titleRichText.TabIndex = 6;
            titleRichText.Text = "[Harap pilih record!]";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.81579F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.18421F));
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Controls.Add(durationLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(usernameLabel, 1, 1);
            tableLayoutPanel1.Controls.Add(label6, 0, 2);
            tableLayoutPanel1.Controls.Add(label7, 0, 3);
            tableLayoutPanel1.Controls.Add(viewsLabel, 1, 2);
            tableLayoutPanel1.Controls.Add(likesLabel, 1, 3);
            tableLayoutPanel1.Location = new Point(138, 76);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(370, 80);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 8;
            label3.Text = "Perkiraan Durasi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 20);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 9;
            label4.Text = "Username";
            // 
            // durationLabel
            // 
            durationLabel.AutoSize = true;
            durationLabel.Location = new Point(146, 0);
            durationLabel.Name = "durationLabel";
            durationLabel.Size = new Size(35, 15);
            durationLabel.TabIndex = 13;
            durationLabel.Text = "[null]";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(146, 20);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(35, 15);
            usernameLabel.TabIndex = 14;
            usernameLabel.Text = "[null]";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 40);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 11;
            label6.Text = "Jumlah Penonton";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 60);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 12;
            label7.Text = "Jumlah Suka";
            // 
            // viewsLabel
            // 
            viewsLabel.AutoSize = true;
            viewsLabel.Location = new Point(146, 40);
            viewsLabel.Name = "viewsLabel";
            viewsLabel.Size = new Size(35, 15);
            viewsLabel.TabIndex = 15;
            viewsLabel.Text = "[null]";
            // 
            // likesLabel
            // 
            likesLabel.AutoSize = true;
            likesLabel.Location = new Point(146, 60);
            likesLabel.Name = "likesLabel";
            likesLabel.Size = new Size(35, 15);
            likesLabel.TabIndex = 16;
            likesLabel.Text = "[null]";
            // 
            // prepareButton
            // 
            prepareButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            prepareButton.Location = new Point(433, 162);
            prepareButton.Name = "prepareButton";
            prepareButton.Size = new Size(75, 23);
            prepareButton.TabIndex = 8;
            prepareButton.Text = "Persiapan";
            prepareButton.UseVisualStyleBackColor = true;
            prepareButton.Click += OnPrepare;
            // 
            // directoryTextBox
            // 
            directoryTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            directoryTextBox.Location = new Point(138, 162);
            directoryTextBox.Name = "directoryTextBox";
            directoryTextBox.Size = new Size(289, 23);
            directoryTextBox.TabIndex = 9;
            // 
            // startNumeric
            // 
            startNumeric.Location = new Point(141, 191);
            startNumeric.Maximum = new decimal(new int[] { 1874919424, 2328306, 0, 0 });
            startNumeric.Name = "startNumeric";
            startNumeric.Size = new Size(73, 23);
            startNumeric.TabIndex = 11;
            // 
            // endNumeric
            // 
            endNumeric.Location = new Point(220, 191);
            endNumeric.Maximum = new decimal(new int[] { 1874919424, 2328306, 0, 0 });
            endNumeric.Name = "endNumeric";
            endNumeric.Size = new Size(73, 23);
            endNumeric.TabIndex = 12;
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(299, 191);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(60, 23);
            downloadButton.TabIndex = 13;
            downloadButton.Text = "Unduh";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += OnDownload;
            // 
            // mergeButton
            // 
            mergeButton.Location = new Point(365, 191);
            mergeButton.Name = "mergeButton";
            mergeButton.Size = new Size(96, 23);
            mergeButton.TabIndex = 14;
            mergeButton.Text = "Gabung MP4";
            mergeButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 277);
            Controls.Add(mergeButton);
            Controls.Add(downloadButton);
            Controls.Add(endNumeric);
            Controls.Add(startNumeric);
            Controls.Add(directoryTextBox);
            Controls.Add(prepareButton);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(titleRichText);
            Controls.Add(label2);
            Controls.Add(recordListBox);
            Controls.Add(sessionButton);
            Controls.Add(sessionTextBox);
            Controls.Add(label1);
            Controls.Add(mainStatusStrip);
            MinimumSize = new Size(536, 316);
            Name = "MainForm";
            Text = "Shopee Replay Downloader";
            mainStatusStrip.ResumeLayout(false);
            mainStatusStrip.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)startNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)endNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip mainStatusStrip;
        private ToolStripStatusLabel statusLabel;
        private Label label1;
        private TextBox sessionTextBox;
        private Button sessionButton;
        private ListBox recordListBox;
        private Label label2;
        private RichTextBox titleRichText;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label durationLabel;
        private Label usernameLabel;
        private Label viewsLabel;
        private Label likesLabel;
        private Button prepareButton;
        private TextBox directoryTextBox;
        private NumericUpDown startNumeric;
        private NumericUpDown endNumeric;
        private Button downloadButton;
        private Button mergeButton;
    }
}