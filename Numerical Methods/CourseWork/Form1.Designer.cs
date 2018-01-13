namespace CourseWork
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MatrixTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eigenValuesTextBox = new System.Windows.Forms.RichTextBox();
            this.SolveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MatrixTextBox
            // 
            this.MatrixTextBox.Location = new System.Drawing.Point(12, 96);
            this.MatrixTextBox.Name = "MatrixTextBox";
            this.MatrixTextBox.Size = new System.Drawing.Size(504, 324);
            this.MatrixTextBox.TabIndex = 0;
            this.MatrixTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Матрица";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(541, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Результат";
            // 
            // eigenValuesTextBox
            // 
            this.eigenValuesTextBox.Location = new System.Drawing.Point(545, 96);
            this.eigenValuesTextBox.Name = "eigenValuesTextBox";
            this.eigenValuesTextBox.Size = new System.Drawing.Size(308, 324);
            this.eigenValuesTextBox.TabIndex = 3;
            this.eigenValuesTextBox.Text = "";
            // 
            // SolveButton
            // 
            this.SolveButton.Location = new System.Drawing.Point(16, 448);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(837, 70);
            this.SolveButton.TabIndex = 4;
            this.SolveButton.Text = "найти собственные числа";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 549);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.eigenValuesTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MatrixTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox MatrixTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox eigenValuesTextBox;
        private System.Windows.Forms.Button SolveButton;
    }
}

