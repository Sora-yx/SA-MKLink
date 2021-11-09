
namespace SA_MKLink
{
    partial class SAMkLink
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGamePath = new System.Windows.Forms.TextBox();
            this.textBoxVSPath = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mklinkTip = new System.Windows.Forms.ToolTip(this.components);
            this.VSTip = new System.Windows.Forms.ToolTip(this.components);
            this.gameLocationTip = new System.Windows.Forms.ToolTip(this.components);
            this.modNameTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(208, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter your mod Name, then select";
            this.label1.Click += new System.EventHandler(this.Select_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(30, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Game PC Location:";
            this.gameLocationTip.SetToolTip(this.label2, "Select your game location (where sonic.exe or sonic2app.exe is).");
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(30, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(283, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Visual Studio Projects Location:";
            this.VSTip.SetToolTip(this.label3, "Select the folder where all your VS Projects are located. (ex: \"D:/GitHub\")");
            // 
            // textBoxGamePath
            // 
            this.textBoxGamePath.Location = new System.Drawing.Point(30, 176);
            this.textBoxGamePath.Name = "textBoxGamePath";
            this.textBoxGamePath.Size = new System.Drawing.Size(354, 23);
            this.textBoxGamePath.TabIndex = 6;
            this.gameLocationTip.SetToolTip(this.textBoxGamePath, "Select your game location (where sonic.exe or sonic2app.exe is).");
            // 
            // textBoxVSPath
            // 
            this.textBoxVSPath.Location = new System.Drawing.Point(30, 249);
            this.textBoxVSPath.Name = "textBoxVSPath";
            this.textBoxVSPath.Size = new System.Drawing.Size(354, 23);
            this.textBoxVSPath.TabIndex = 7;
            this.VSTip.SetToolTip(this.textBoxVSPath, "Select the folder where all your VS Projects are located. (ex: \"D:/GitHub\")");
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(594, 266);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 43);
            this.button3.TabIndex = 9;
            this.button3.Text = "Process MKLink";
            this.mklinkTip.SetToolTip(this.button3, "Create Mod Folder (if it doesn\'t exist) and  symbolic link with your mod DLL.");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.MKLink_Button);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(30, 102);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(354, 23);
            this.textBox3.TabIndex = 10;
            this.modNameTip.SetToolTip(this.textBox3, "Please enter the name of your mod, it must match the folder name of your VS Proje" +
        "ct.");
            this.textBox3.TextChanged += new System.EventHandler(this.textBoxModName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(30, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 28);
            this.label4.TabIndex = 11;
            this.label4.Text = "DLL Mod Name:";
            this.modNameTip.SetToolTip(this.label4, "Please enter the name of your mod, it must match the folder name of your VS Proje" +
        "ct.");
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(194, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(398, 28);
            this.label5.TabIndex = 12;
            this.label5.Text = "the Game and Visual Project Studio location.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 34);
            this.button1.TabIndex = 13;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GameLocation_Button);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(415, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 32);
            this.button2.TabIndex = 14;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.VSLocation_Button);
            // 
            // mklinkTip
            // 
            this.mklinkTip.AutomaticDelay = 200;
            this.mklinkTip.AutoPopDelay = 5000;
            this.mklinkTip.InitialDelay = 200;
            this.mklinkTip.ReshowDelay = 40;
            // 
            // VSTip
            // 
            this.VSTip.AutomaticDelay = 200;
            this.VSTip.AutoPopDelay = 5000;
            this.VSTip.InitialDelay = 200;
            this.VSTip.ReshowDelay = 40;
            // 
            // SAMkLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 320);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBoxVSPath);
            this.Controls.Add(this.textBoxGamePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SAMkLink";
            this.Text = "SAMkLink";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGamePath;
        private System.Windows.Forms.TextBox textBoxVSPath;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip mklinkTip;
        private System.Windows.Forms.ToolTip VSTip;
        private System.Windows.Forms.ToolTip gameLocationTip;
        private System.Windows.Forms.ToolTip modNameTip;
    }
}

