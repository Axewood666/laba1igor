namespace laba1igor
{
    partial class menu
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
            this.circle = new System.Windows.Forms.Button();
            this.Mainhead = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.Button();
            this.rectangle = new System.Windows.Forms.Button();
            this.square = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // circle
            // 
            this.circle.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.circle.Location = new System.Drawing.Point(3, 92);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(166, 72);
            this.circle.TabIndex = 0;
            this.circle.Text = "Круг";
            this.circle.UseVisualStyleBackColor = true;
            this.circle.Click += new System.EventHandler(this.circle_Click);
            // 
            // Mainhead
            // 
            this.Mainhead.AutoSize = true;
            this.Mainhead.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Mainhead.Location = new System.Drawing.Point(45, 9);
            this.Mainhead.Name = "Mainhead";
            this.Mainhead.Size = new System.Drawing.Size(304, 69);
            this.Mainhead.TabIndex = 1;
            this.Mainhead.Text = "Выберите фигуру. \r\nОтрисовка будет производиться \r\nв отдельном окне.";
            // 
            // line
            // 
            this.line.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.line.Location = new System.Drawing.Point(193, 92);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(165, 72);
            this.line.TabIndex = 2;
            this.line.Text = "Эллипс";
            this.line.UseVisualStyleBackColor = true;
            this.line.Click += new System.EventHandler(this.line_Click);
            // 
            // rectangle
            // 
            this.rectangle.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rectangle.Location = new System.Drawing.Point(3, 170);
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(166, 72);
            this.rectangle.TabIndex = 3;
            this.rectangle.Text = "Прямоугольник";
            this.rectangle.UseVisualStyleBackColor = true;
            this.rectangle.Click += new System.EventHandler(this.rectangle_Click);
            // 
            // square
            // 
            this.square.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.square.Location = new System.Drawing.Point(193, 170);
            this.square.Name = "square";
            this.square.Size = new System.Drawing.Size(165, 72);
            this.square.TabIndex = 4;
            this.square.Text = "Квадрат";
            this.square.UseVisualStyleBackColor = true;
            this.square.Click += new System.EventHandler(this.square_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 261);
            this.Controls.Add(this.square);
            this.Controls.Add(this.rectangle);
            this.Controls.Add(this.line);
            this.Controls.Add(this.Mainhead);
            this.Controls.Add(this.circle);
            this.Name = "menu";
            this.Text = "mainmenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button circle;
        private System.Windows.Forms.Label Mainhead;
        private System.Windows.Forms.Button line;
        private System.Windows.Forms.Button rectangle;
        private System.Windows.Forms.Button square;
    }
}

