
namespace Fixture_Maker_2._0
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.UpgradeDatabase = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ChooseADifferentTemplate = new System.Windows.Forms.Button();
            this.Cls = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UpgradeDatabase
            // 
            this.UpgradeDatabase.BackColor = System.Drawing.Color.Gray;
            this.UpgradeDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpgradeDatabase.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpgradeDatabase.ForeColor = System.Drawing.Color.White;
            this.UpgradeDatabase.Location = new System.Drawing.Point(440, 63);
            this.UpgradeDatabase.Name = "UpgradeDatabase";
            this.UpgradeDatabase.Size = new System.Drawing.Size(305, 61);
            this.UpgradeDatabase.TabIndex = 0;
            this.UpgradeDatabase.Text = "Upgrade Database";
            this.UpgradeDatabase.UseVisualStyleBackColor = false;
            this.UpgradeDatabase.Click += new System.EventHandler(this.UpgradeDatabase_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(440, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(305, 61);
            this.button1.TabIndex = 1;
            this.button1.Text = "Work Space";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChooseADifferentTemplate
            // 
            this.ChooseADifferentTemplate.BackColor = System.Drawing.Color.Gray;
            this.ChooseADifferentTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseADifferentTemplate.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseADifferentTemplate.ForeColor = System.Drawing.Color.White;
            this.ChooseADifferentTemplate.Location = new System.Drawing.Point(440, 265);
            this.ChooseADifferentTemplate.Name = "ChooseADifferentTemplate";
            this.ChooseADifferentTemplate.Size = new System.Drawing.Size(305, 61);
            this.ChooseADifferentTemplate.TabIndex = 2;
            this.ChooseADifferentTemplate.Text = "Choose A Different Template";
            this.ChooseADifferentTemplate.UseVisualStyleBackColor = false;
            // 
            // Cls
            // 
            this.Cls.BackColor = System.Drawing.Color.Gray;
            this.Cls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cls.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cls.ForeColor = System.Drawing.Color.White;
            this.Cls.Location = new System.Drawing.Point(440, 366);
            this.Cls.Name = "Cls";
            this.Cls.Size = new System.Drawing.Size(305, 61);
            this.Cls.TabIndex = 3;
            this.Cls.Text = "Close";
            this.Cls.UseVisualStyleBackColor = false;
            this.Cls.Click += new System.EventHandler(this.Cls_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1184, 491);
            this.Controls.Add(this.Cls);
            this.Controls.Add(this.ChooseADifferentTemplate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UpgradeDatabase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fixture Maker(Home Page)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UpgradeDatabase;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ChooseADifferentTemplate;
        private System.Windows.Forms.Button Cls;
    }
}