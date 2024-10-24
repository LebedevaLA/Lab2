namespace Lab_2
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Ball = new System.Windows.Forms.Button();
            this.Style = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Random = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new Lab_2.MyDisplay();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Ball);
            this.groupBox1.Controls.Add(this.Style);
            this.groupBox1.Controls.Add(this.Save);
            this.groupBox1.Controls.Add(this.Random);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(608, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 621);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buttons";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Ball.Location = new System.Drawing.Point(90, 349);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(74, 59);
            this.Ball.TabIndex = 3;
            this.Ball.UseVisualStyleBackColor = false;
            this.Ball.Click += new System.EventHandler(this.Ball_Click);
            // 
            // Style
            // 
            this.Style.Location = new System.Drawing.Point(15, 225);
            this.Style.Name = "Style";
            this.Style.Size = new System.Drawing.Size(221, 56);
            this.Style.TabIndex = 2;
            this.Style.Text = "Выбрать стиль фона";
            this.Style.UseVisualStyleBackColor = true;
            this.Style.Click += new System.EventHandler(this.Style_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(15, 132);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(221, 52);
            this.Save.TabIndex = 1;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Random
            // 
            this.Random.Location = new System.Drawing.Point(15, 54);
            this.Random.Name = "Random";
            this.Random.Size = new System.Drawing.Size(221, 47);
            this.Random.TabIndex = 0;
            this.Random.Text = "Случайная функция";
            this.Random.UseVisualStyleBackColor = true;
            this.Random.Click += new System.EventHandler(this.Random_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(600, 615);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 621);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 621);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(878, 677);
            this.Name = "Form1";
            this.Text = "lab_2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Style;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Random;
        private System.Windows.Forms.Button Ball;
        private MyDisplay panel1;
        private System.Windows.Forms.Timer timer;
    }
}

