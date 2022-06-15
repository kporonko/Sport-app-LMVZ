
namespace LB4
{
    partial class PlaylistName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistName));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.playlistTableAdapter1 = new LB4.TrainingHelperDataSetPlaylistsTableAdapters.PlaylistTableAdapter();
            this.trainingHelperDataSetPlaylists1 = new LB4.TrainingHelperDataSetPlaylists();
            this.trainingHelperDataSet1 = new LB4.TrainingHelperDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.trainingHelperDataSetPlaylists1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainingHelperDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(142, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 26);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите название плэйлиста";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(396, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Готово";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // playlistTableAdapter1
            // 
            this.playlistTableAdapter1.ClearBeforeFill = true;
            // 
            // trainingHelperDataSetPlaylists1
            // 
            this.trainingHelperDataSetPlaylists1.DataSetName = "TrainingHelperDataSetPlaylists";
            this.trainingHelperDataSetPlaylists1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // trainingHelperDataSet1
            // 
            this.trainingHelperDataSet1.DataSetName = "TrainingHelperDataSet";
            this.trainingHelperDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PlaylistName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 220);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlaylistName";
            this.Text = "PlaylistName";
            this.Load += new System.EventHandler(this.PlaylistName_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trainingHelperDataSetPlaylists1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainingHelperDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private TrainingHelperDataSetPlaylistsTableAdapters.PlaylistTableAdapter playlistTableAdapter1;
        private TrainingHelperDataSetPlaylists trainingHelperDataSetPlaylists1;
        private TrainingHelperDataSet trainingHelperDataSet1;
    }
}