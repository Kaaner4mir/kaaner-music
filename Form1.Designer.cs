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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.pnl_titlebar = new System.Windows.Forms.Panel();
            this.btn_restore = new System.Windows.Forms.Button();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.lst_songs = new System.Windows.Forms.ListBox();
            this.timer_progress = new System.Windows.Forms.Timer(this.components);
            this.pnl_controls = new System.Windows.Forms.Panel();
            this.btn_sort_title = new System.Windows.Forms.Button();
            this.btn_sort_artist = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.track_progress = new System.Windows.Forms.TrackBar();
            this.btn_next_song = new System.Windows.Forms.Button();
            this.btn_previous_song = new System.Windows.Forms.Button();
            this.btn_resume = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.track_volume = new System.Windows.Forms.TrackBar();
            this.btn_play = new System.Windows.Forms.Button();
            this.pic_album_art = new System.Windows.Forms.PictureBox();
            this.pnl_titlebar.SuspendLayout();
            this.pnl_controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_progress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_album_art)).BeginInit();
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
            this.lst_songs.Size = new System.Drawing.Size(362, 770);
            this.lst_songs.TabIndex = 1;
            // 
            // timer_progress
            // 
            this.timer_progress.Interval = 1000;
            this.timer_progress.Tick += new System.EventHandler(this.timer_progress_Tick);
            // 
            // pnl_controls
            // 
            this.pnl_controls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnl_controls.Controls.Add(this.btn_sort_title);
            this.pnl_controls.Controls.Add(this.btn_sort_artist);
            this.pnl_controls.Controls.Add(this.pictureBox1);
            this.pnl_controls.Controls.Add(this.track_progress);
            this.pnl_controls.Controls.Add(this.btn_next_song);
            this.pnl_controls.Controls.Add(this.btn_previous_song);
            this.pnl_controls.Controls.Add(this.btn_resume);
            this.pnl_controls.Controls.Add(this.lbl_title);
            this.pnl_controls.Controls.Add(this.track_volume);
            this.pnl_controls.Controls.Add(this.btn_play);
            this.pnl_controls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_controls.Location = new System.Drawing.Point(362, 536);
            this.pnl_controls.Name = "pnl_controls";
            this.pnl_controls.Size = new System.Drawing.Size(838, 264);
            this.pnl_controls.TabIndex = 2;
            // 
            // btn_sort_title
            // 
            this.btn_sort_title.BackColor = System.Drawing.Color.Transparent;
            this.btn_sort_title.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_sort_title.BackgroundImage")));
            this.btn_sort_title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_sort_title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sort_title.FlatAppearance.BorderSize = 0;
            this.btn_sort_title.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_sort_title.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_sort_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sort_title.Location = new System.Drawing.Point(44, 136);
            this.btn_sort_title.Name = "btn_sort_title";
            this.btn_sort_title.Size = new System.Drawing.Size(40, 40);
            this.btn_sort_title.TabIndex = 12;
            this.btn_sort_title.UseVisualStyleBackColor = false;
            this.btn_sort_title.Click += new System.EventHandler(this.btn_sort_title_Click);
            // 
            // btn_sort_artist
            // 
            this.btn_sort_artist.BackColor = System.Drawing.Color.Transparent;
            this.btn_sort_artist.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_sort_artist.BackgroundImage")));
            this.btn_sort_artist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_sort_artist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sort_artist.FlatAppearance.BorderSize = 0;
            this.btn_sort_artist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_sort_artist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_sort_artist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sort_artist.Location = new System.Drawing.Point(99, 136);
            this.btn_sort_artist.Name = "btn_sort_artist";
            this.btn_sort_artist.Size = new System.Drawing.Size(40, 40);
            this.btn_sort_artist.TabIndex = 11;
            this.btn_sort_artist.UseVisualStyleBackColor = false;
            this.btn_sort_artist.Click += new System.EventHandler(this.btn_sort_artist_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(663, 147);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // track_progress
            // 
            this.track_progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.track_progress.Location = new System.Drawing.Point(37, 207);
            this.track_progress.Name = "track_progress";
            this.track_progress.Size = new System.Drawing.Size(771, 45);
            this.track_progress.TabIndex = 9;
            this.track_progress.TickStyle = System.Windows.Forms.TickStyle.None;
            this.track_progress.Scroll += new System.EventHandler(this.track_progress_Scroll);
            this.track_progress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.track_progress_MouseDown);
            this.track_progress.MouseUp += new System.Windows.Forms.MouseEventHandler(this.track_progress_MouseUp);
            // 
            // btn_next_song
            // 
            this.btn_next_song.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_next_song.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_next_song.BackgroundImage")));
            this.btn_next_song.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_next_song.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_next_song.FlatAppearance.BorderSize = 0;
            this.btn_next_song.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_next_song.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_next_song.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next_song.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next_song.ForeColor = System.Drawing.Color.White;
            this.btn_next_song.Location = new System.Drawing.Point(489, 134);
            this.btn_next_song.Name = "btn_next_song";
            this.btn_next_song.Size = new System.Drawing.Size(40, 40);
            this.btn_next_song.TabIndex = 7;
            this.btn_next_song.UseVisualStyleBackColor = true;
            this.btn_next_song.Click += new System.EventHandler(this.btn_next_song_Click);
            // 
            // btn_previous_song
            // 
            this.btn_previous_song.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_previous_song.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_previous_song.BackgroundImage")));
            this.btn_previous_song.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_previous_song.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_previous_song.FlatAppearance.BorderSize = 0;
            this.btn_previous_song.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_previous_song.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_previous_song.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_previous_song.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_previous_song.ForeColor = System.Drawing.Color.White;
            this.btn_previous_song.Location = new System.Drawing.Point(318, 134);
            this.btn_previous_song.Name = "btn_previous_song";
            this.btn_previous_song.Size = new System.Drawing.Size(40, 40);
            this.btn_previous_song.TabIndex = 6;
            this.btn_previous_song.UseVisualStyleBackColor = true;
            this.btn_previous_song.Click += new System.EventHandler(this.btn_previous_song_Click);
            // 
            // btn_resume
            // 
            this.btn_resume.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_resume.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_resume.BackgroundImage")));
            this.btn_resume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_resume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_resume.FlatAppearance.BorderSize = 0;
            this.btn_resume.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_resume.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_resume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resume.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_resume.ForeColor = System.Drawing.Color.White;
            this.btn_resume.Location = new System.Drawing.Point(394, 124);
            this.btn_resume.Name = "btn_resume";
            this.btn_resume.Size = new System.Drawing.Size(60, 60);
            this.btn_resume.TabIndex = 5;
            this.btn_resume.UseVisualStyleBackColor = true;
            this.btn_resume.Visible = false;
            this.btn_resume.Click += new System.EventHandler(this.btn_resume_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(32, 29);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(121, 30);
            this.lbl_title.TabIndex = 4;
            this.lbl_title.Text = "Select Song";
            // 
            // track_volume
            // 
            this.track_volume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.track_volume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.track_volume.Location = new System.Drawing.Point(704, 156);
            this.track_volume.Maximum = 100;
            this.track_volume.Name = "track_volume";
            this.track_volume.Size = new System.Drawing.Size(104, 45);
            this.track_volume.TabIndex = 3;
            this.track_volume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.track_volume.Value = 50;
            this.track_volume.Scroll += new System.EventHandler(this.track_volume_Scroll);
            // 
            // btn_play
            // 
            this.btn_play.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_play.BackgroundImage")));
            this.btn_play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_play.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_play.FlatAppearance.BorderSize = 0;
            this.btn_play.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_play.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_play.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_play.ForeColor = System.Drawing.Color.White;
            this.btn_play.Location = new System.Drawing.Point(394, 124);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(60, 60);
            this.btn_play.TabIndex = 0;
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // pic_album_art
            // 
            this.pic_album_art.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_album_art.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.pic_album_art.Location = new System.Drawing.Point(362, 36);
            this.pic_album_art.Name = "pic_album_art";
            this.pic_album_art.Size = new System.Drawing.Size(838, 494);
            this.pic_album_art.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_album_art.TabIndex = 10;
            this.pic_album_art.TabStop = false;
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pic_album_art);
            this.Controls.Add(this.pnl_controls);
            this.Controls.Add(this.lst_songs);
            this.Controls.Add(this.pnl_titlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kaaner Music";
            this.pnl_titlebar.ResumeLayout(false);
            this.pnl_controls.ResumeLayout(false);
            this.pnl_controls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_progress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_album_art)).EndInit();
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
        private System.Windows.Forms.TrackBar track_volume;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_resume;
        private System.Windows.Forms.Button btn_next_song;
        private System.Windows.Forms.Button btn_previous_song;
        private System.Windows.Forms.Timer timer_progress; // Yeni Zamanlayıcı
        private System.Windows.Forms.TrackBar track_progress;
        private System.Windows.Forms.PictureBox pic_album_art; // Albüm Resmi
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_sort_title;
        private System.Windows.Forms.Button btn_sort_artist;
    }
}
