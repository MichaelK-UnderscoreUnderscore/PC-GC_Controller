
namespace PC_GC_Controller
{
    partial class Form1
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
            this.button1Connect = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comboBox1Serial = new System.Windows.Forms.ComboBox();
            this.comboBox1Controller = new System.Windows.Forms.ComboBox();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxNoAnalog = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1Connect
            // 
            this.button1Connect.Location = new System.Drawing.Point(294, 27);
            this.button1Connect.Name = "button1Connect";
            this.button1Connect.Size = new System.Drawing.Size(63, 23);
            this.button1Connect.TabIndex = 0;
            this.button1Connect.Text = "Connect";
            this.button1Connect.UseVisualStyleBackColor = true;
            this.button1Connect.Click += new System.EventHandler(this.button1Connect_Click);
            // 
            // comboBox1Serial
            // 
            this.comboBox1Serial.FormattingEnabled = true;
            this.comboBox1Serial.Location = new System.Drawing.Point(155, 29);
            this.comboBox1Serial.Name = "comboBox1Serial";
            this.comboBox1Serial.Size = new System.Drawing.Size(121, 21);
            this.comboBox1Serial.TabIndex = 1;
            // 
            // comboBox1Controller
            // 
            this.comboBox1Controller.FormattingEnabled = true;
            this.comboBox1Controller.Location = new System.Drawing.Point(10, 29);
            this.comboBox1Controller.Name = "comboBox1Controller";
            this.comboBox1Controller.Size = new System.Drawing.Size(121, 21);
            this.comboBox1Controller.TabIndex = 2;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(155, 56);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(202, 23);
            this.buttonCheck.TabIndex = 3;
            this.buttonCheck.Text = "Check for Controllers / Serial";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Controller";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Serial Port";
            // 
            // checkBoxNoAnalog
            // 
            this.checkBoxNoAnalog.AutoSize = true;
            this.checkBoxNoAnalog.Location = new System.Drawing.Point(10, 60);
            this.checkBoxNoAnalog.Name = "checkBoxNoAnalog";
            this.checkBoxNoAnalog.Size = new System.Drawing.Size(108, 17);
            this.checkBoxNoAnalog.TabIndex = 6;
            this.checkBoxNoAnalog.Text = "No Analog Inputs";
            this.checkBoxNoAnalog.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 93);
            this.Controls.Add(this.checkBoxNoAnalog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.comboBox1Controller);
            this.Controls.Add(this.comboBox1Serial);
            this.Controls.Add(this.button1Connect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Close);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1Connect;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBox1Serial;
        private System.Windows.Forms.ComboBox comboBox1Controller;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxNoAnalog;
    }
}

