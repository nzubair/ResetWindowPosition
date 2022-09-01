namespace ResetWindowPosition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnRefreshWindow = new System.Windows.Forms.Button();
            this.comboWindows = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRefreshWindow
            // 
            this.btnRefreshWindow.Location = new System.Drawing.Point(12, 12);
            this.btnRefreshWindow.Name = "btnRefreshWindow";
            this.btnRefreshWindow.Size = new System.Drawing.Size(137, 23);
            this.btnRefreshWindow.TabIndex = 0;
            this.btnRefreshWindow.Text = "Refresh Window List";
            this.btnRefreshWindow.UseVisualStyleBackColor = true;
            this.btnRefreshWindow.Click += new System.EventHandler(this.btnRefreshWindow_Click);
            // 
            // comboWindows
            // 
            this.comboWindows.FormattingEnabled = true;
            this.comboWindows.Location = new System.Drawing.Point(12, 47);
            this.comboWindows.Name = "comboWindows";
            this.comboWindows.Size = new System.Drawing.Size(455, 23);
            this.comboWindows.TabIndex = 1;
            this.comboWindows.SelectedValueChanged += new System.EventHandler(this.comboWindows_SelectedValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(477, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Reset Window";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLog.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtLog.Location = new System.Drawing.Point(14, 89);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(558, 237);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = resources.GetString("txtLog.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 336);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboWindows);
            this.Controls.Add(this.btnRefreshWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Reset Window Position";
            this.Move += new System.EventHandler(this.Form1_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnRefreshWindow;
        private ComboBox comboWindows;
        private Button button2;
        private TextBox txtLog;
        private Label label1;
    }
}