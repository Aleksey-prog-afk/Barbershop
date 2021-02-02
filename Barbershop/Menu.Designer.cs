namespace Barbershop
{
    partial class Menu
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
            this.createOrderButton = new System.Windows.Forms.Button();
            this.createRecordButton = new System.Windows.Forms.Button();
            this.changeScheduleButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createOrderButton
            // 
            this.createOrderButton.Location = new System.Drawing.Point(140, 107);
            this.createOrderButton.Name = "createOrderButton";
            this.createOrderButton.Size = new System.Drawing.Size(191, 75);
            this.createOrderButton.TabIndex = 0;
            this.createOrderButton.Text = "Создать запись";
            this.createOrderButton.UseVisualStyleBackColor = true;
            this.createOrderButton.Click += new System.EventHandler(this.createOrderButton_Click);
            // 
            // createRecordButton
            // 
            this.createRecordButton.Location = new System.Drawing.Point(140, 223);
            this.createRecordButton.Name = "createRecordButton";
            this.createRecordButton.Size = new System.Drawing.Size(191, 75);
            this.createRecordButton.TabIndex = 1;
            this.createRecordButton.Text = "Создать отчёт";
            this.createRecordButton.UseVisualStyleBackColor = true;
            // 
            // changeScheduleButton
            // 
            this.changeScheduleButton.Location = new System.Drawing.Point(140, 347);
            this.changeScheduleButton.Name = "changeScheduleButton";
            this.changeScheduleButton.Size = new System.Drawing.Size(191, 75);
            this.changeScheduleButton.TabIndex = 2;
            this.changeScheduleButton.Text = "Изменить расписание";
            this.changeScheduleButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 527);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changeScheduleButton);
            this.Controls.Add(this.createRecordButton);
            this.Controls.Add(this.createOrderButton);
            this.Name = "Menu";
            this.Text = "BarbershopApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createOrderButton;
        private System.Windows.Forms.Button createRecordButton;
        private System.Windows.Forms.Button changeScheduleButton;
        private System.Windows.Forms.Label label1;
    }
}