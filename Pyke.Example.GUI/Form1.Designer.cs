namespace Pyke.Example.GUI
{
    partial class Form1
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
            this.YourTeamList = new System.Windows.Forms.ListBox();
            this.TheirTeamList = new System.Windows.Forms.ListBox();
            this.ChampSelectGroup = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.ReadyCheckGroup = new System.Windows.Forms.GroupBox();
            this.ChampSelectGroup.SuspendLayout();
            this.ReadyCheckGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // YourTeamList
            // 
            this.YourTeamList.FormattingEnabled = true;
            this.YourTeamList.ItemHeight = 15;
            this.YourTeamList.Location = new System.Drawing.Point(-1, 0);
            this.YourTeamList.Name = "YourTeamList";
            this.YourTeamList.Size = new System.Drawing.Size(173, 349);
            this.YourTeamList.TabIndex = 0;
            // 
            // TheirTeamList
            // 
            this.TheirTeamList.FormattingEnabled = true;
            this.TheirTeamList.ItemHeight = 15;
            this.TheirTeamList.Location = new System.Drawing.Point(786, 0);
            this.TheirTeamList.Name = "TheirTeamList";
            this.TheirTeamList.Size = new System.Drawing.Size(173, 349);
            this.TheirTeamList.TabIndex = 0;
            // 
            // ChampSelectGroup
            // 
            this.ChampSelectGroup.Controls.Add(this.button2);
            this.ChampSelectGroup.Controls.Add(this.button1);
            this.ChampSelectGroup.Controls.Add(this.label1);
            this.ChampSelectGroup.Controls.Add(this.textBox1);
            this.ChampSelectGroup.Location = new System.Drawing.Point(191, 12);
            this.ChampSelectGroup.Name = "ChampSelectGroup";
            this.ChampSelectGroup.Size = new System.Drawing.Size(200, 100);
            this.ChampSelectGroup.TabIndex = 1;
            this.ChampSelectGroup.TabStop = false;
            this.ChampSelectGroup.Text = "Champ Select";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 23);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Hover";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(101, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Lock in";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(100, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Decline";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Accept";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ReadyCheckGroup
            // 
            this.ReadyCheckGroup.Controls.Add(this.button3);
            this.ReadyCheckGroup.Controls.Add(this.button4);
            this.ReadyCheckGroup.Location = new System.Drawing.Point(191, 118);
            this.ReadyCheckGroup.Name = "ReadyCheckGroup";
            this.ReadyCheckGroup.Size = new System.Drawing.Size(200, 54);
            this.ReadyCheckGroup.TabIndex = 1;
            this.ReadyCheckGroup.TabStop = false;
            this.ReadyCheckGroup.Text = "Ready Check";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 548);
            this.Controls.Add(this.ReadyCheckGroup);
            this.Controls.Add(this.ChampSelectGroup);
            this.Controls.Add(this.TheirTeamList);
            this.Controls.Add(this.YourTeamList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ChampSelectGroup.ResumeLayout(false);
            this.ChampSelectGroup.PerformLayout();
            this.ReadyCheckGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox YourTeamList;
        private System.Windows.Forms.ListBox TheirTeamList;
        private System.Windows.Forms.GroupBox ChampSelectGroup;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox ReadyCheckGroup;
    }
}

