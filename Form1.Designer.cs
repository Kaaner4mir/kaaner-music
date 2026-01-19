namespace KaanerMusic
{
    partial class main_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.pnl_titlebar = new System.Windows.Forms.Panel();
            this.btn_restore = new System.Windows.Forms.Button();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lst_songs = new System.Windows.Forms.ListBox();
            this.pnl_controls = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.track_volume = new System.Windows.Forms.TrackBar();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_prev = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.pnl_titlebar.SuspendLayout();
            this.pnl_controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_volume)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_titlebar
            // 
            this.pnl_titlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(155)))), ((int)(((byte)(23)))));
            this.pnl_titlebar.Controls.Add(this.btn_restore);
            this.pnl_titlebar.Controls.Add(this.btn_minimize);
            this.pnl_titlebar.Controls.Add(this.btn_close);
            this.pnl_titlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titlebar.Location = new System.Drawing.Point(0, 0);
            this.pnl_titlebar.Name = "pnl_titlebar";
            this.pnl_titlebar.Size = new System.Drawing.Size(1200, 30);
            this.pnl_titlebar.TabIndex = 0;
            this.pnl_titlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_titlebar_MouseDown);
            // 
            // btn_restore
            // 
            this.btn_restore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_restore.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_restore.BackgroundImage")));
            this.btn_restore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_restore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_restore.FlatAppearance.BorderSize = 0;
            this.btn_restore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_restore.Location = new System.Drawing.Point(1140, 0);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(30, 30);
            this.btn_restore.TabIndex = 3;
            this.btn_restore.UseVisualStyleBackColor = true;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_minimize.BackgroundImage")));
            this.btn_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimize.FlatAppearance.BorderSize = 0;
            this.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimize.Location = new System.Drawing.Point(1110, 0);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(30, 30);
            this.btn_minimize.TabIndex = 2;
            this.btn_minimize.UseVisualStyleBackColor = true;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close.BackgroundImage")));
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Location = new System.Drawing.Point(1170, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(30, 30);
            this.btn_close.TabIndex = 1;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lst_songs
            // 
            this.lst_songs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lst_songs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_songs.Dock = System.Windows.Forms.DockStyle.Left;
            this.lst_songs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_songs.ForeColor = System.Drawing.Color.White;
            this.lst_songs.FormattingEnabled = true;
            this.lst_songs.ItemHeight = 21;
            this.lst_songs.Location = new System.Drawing.Point(0, 30);
            this.lst_songs.Name = "lst_songs";
            this.lst_songs.Size = new System.Drawing.Size(300, 770);
            this.lst_songs.TabIndex = 1;
            // 
            // pnl_controls
            // 
            this.pnl_controls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnl_controls.Controls.Add(this.lbl_title);
            this.pnl_controls.Controls.Add(this.track_volume);
            this.pnl_controls.Controls.Add(this.btn_next);
            this.pnl_controls.Controls.Add(this.btn_prev);
            this.pnl_controls.Controls.Add(this.btn_play);
            this.pnl_controls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_controls.Location = new System.Drawing.Point(300, 680);
            this.pnl_controls.Name = "pnl_controls";
            this.pnl_controls.Size = new System.Drawing.Size(900, 120);
            this.pnl_controls.TabIndex = 2;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(20, 20);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(121, 30);
            this.lbl_title.TabIndex = 4;
            this.lbl_title.Text = "Select Song";
            // 
            // track_volume
            // 
            this.track_volume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.track_volume.Location = new System.Drawing.Point(780, 40);
            this.track_volume.Maximum = 100;
            this.track_volume.Name = "track_volume";
            this.track_volume.Size = new System.Drawing.Size(104, 45);
            this.track_volume.TabIndex = 3;
            this.track_volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.track_volume.Value = 50;
            // 
            // btn_next
            // 
            this.btn_next.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.ForeColor = System.Drawing.Color.White;
            this.btn_next.Location = new System.Drawing.Point(500, 40);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(50, 40);
            this.btn_next.TabIndex = 2;
            this.btn_next.Text = ">>";
            this.btn_next.UseVisualStyleBackColor = true;
            // 
            // btn_prev
            // 
            this.btn_prev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_prev.ForeColor = System.Drawing.Color.White;
            this.btn_prev.Location = new System.Drawing.Point(340, 40);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(50, 40);
            this.btn_prev.TabIndex = 1;
            this.btn_prev.Text = "<<";
            this.btn_prev.UseVisualStyleBackColor = true;
            // 
            // btn_play
            // 
            this.btn_play.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_play.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_play.ForeColor = System.Drawing.Color.White;
            this.btn_play.Location = new System.Drawing.Point(410, 30);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(70, 60);
            this.btn_play.TabIndex = 0;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = true;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnl_controls);
            this.Controls.Add(this.lst_songs);
            this.Controls.Add(this.pnl_titlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.main_form_Load);
            this.pnl_titlebar.ResumeLayout(false);
            this.pnl_controls.ResumeLayout(false);
            this.pnl_controls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_volume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titlebar;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.Button btn_restore;
        private System.Windows.Forms.ListBox lst_songs;
        private System.Windows.Forms.Panel pnl_controls;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_prev;
        private System.Windows.Forms.TrackBar track_volume;
        private System.Windows.Forms.Label lbl_title;
    }
}
