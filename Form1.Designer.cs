namespace IS_Lab5
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
            this.activityListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.familyListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.commListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.natureListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tripsListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.goodsListBox = new System.Windows.Forms.ListBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.findCar = new System.Windows.Forms.Button();
            this.algListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.carListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // activityListBox
            // 
            this.activityListBox.FormattingEnabled = true;
            this.activityListBox.ItemHeight = 20;
            this.activityListBox.Items.AddRange(new object[] {
            "студент",
            "работник",
            "предприниматель"});
            this.activityListBox.Location = new System.Drawing.Point(12, 51);
            this.activityListBox.Name = "activityListBox";
            this.activityListBox.Size = new System.Drawing.Size(180, 24);
            this.activityListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Род деятельности";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Семейное положение";
            // 
            // familyListBox
            // 
            this.familyListBox.FormattingEnabled = true;
            this.familyListBox.ItemHeight = 20;
            this.familyListBox.Items.AddRange(new object[] {
            "холост",
            "есть семья",
            "есть дети"});
            this.familyListBox.Location = new System.Drawing.Point(200, 51);
            this.familyListBox.Name = "familyListBox";
            this.familyListBox.Size = new System.Drawing.Size(182, 24);
            this.familyListBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Количество общения";
            // 
            // commListBox
            // 
            this.commListBox.FormattingEnabled = true;
            this.commListBox.ItemHeight = 20;
            this.commListBox.Items.AddRange(new object[] {
            "мало",
            "средне",
            "много"});
            this.commListBox.Location = new System.Drawing.Point(388, 51);
            this.commListBox.Name = "commListBox";
            this.commListBox.Size = new System.Drawing.Size(167, 24);
            this.commListBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(943, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Поездки на природу";
            // 
            // natureListBox
            // 
            this.natureListBox.FormattingEnabled = true;
            this.natureListBox.ItemHeight = 20;
            this.natureListBox.Items.AddRange(new object[] {
            "нет",
            "иногда есть",
            "часто"});
            this.natureListBox.Location = new System.Drawing.Point(947, 51);
            this.natureListBox.Name = "natureListBox";
            this.natureListBox.Size = new System.Drawing.Size(173, 24);
            this.natureListBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(755, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Поездки за город";
            // 
            // tripsListBox
            // 
            this.tripsListBox.FormattingEnabled = true;
            this.tripsListBox.ItemHeight = 20;
            this.tripsListBox.Items.AddRange(new object[] {
            "нет",
            "иногда есть",
            "часто"});
            this.tripsListBox.Location = new System.Drawing.Point(759, 51);
            this.tripsListBox.Name = "tripsListBox";
            this.tripsListBox.Size = new System.Drawing.Size(182, 24);
            this.tripsListBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(584, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 40);
            this.label6.TabIndex = 7;
            this.label6.Text = "Необхожимость\r\nвезти грузы";
            // 
            // goodsListBox
            // 
            this.goodsListBox.FormattingEnabled = true;
            this.goodsListBox.ItemHeight = 20;
            this.goodsListBox.Items.AddRange(new object[] {
            "нет",
            "иногда есть",
            "часто"});
            this.goodsListBox.Location = new System.Drawing.Point(573, 51);
            this.goodsListBox.Name = "goodsListBox";
            this.goodsListBox.Size = new System.Drawing.Size(180, 24);
            this.goodsListBox.TabIndex = 6;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.descriptionTextBox.Location = new System.Drawing.Point(684, 81);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(436, 302);
            this.descriptionTextBox.TabIndex = 13;
            this.descriptionTextBox.Text = "Здесь будет описание вывода";
            // 
            // findCar
            // 
            this.findCar.Location = new System.Drawing.Point(888, 430);
            this.findCar.Name = "findCar";
            this.findCar.Size = new System.Drawing.Size(219, 46);
            this.findCar.TabIndex = 14;
            this.findCar.Text = "Подобрать автомобиль";
            this.findCar.UseVisualStyleBackColor = true;
            this.findCar.Click += new System.EventHandler(this.findCar_Click);
            // 
            // algListBox
            // 
            this.algListBox.FormattingEnabled = true;
            this.algListBox.ItemHeight = 20;
            this.algListBox.Items.AddRange(new object[] {
            "прямой",
            "обратный"});
            this.algListBox.Location = new System.Drawing.Point(698, 479);
            this.algListBox.Name = "algListBox";
            this.algListBox.Size = new System.Drawing.Size(161, 24);
            this.algListBox.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(694, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Вывод";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.Location = new System.Drawing.Point(12, 81);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(666, 422);
            this.textBox1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(694, 393);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Цель";
            // 
            // carListBox
            // 
            this.carListBox.FormattingEnabled = true;
            this.carListBox.ItemHeight = 20;
            this.carListBox.Items.AddRange(new object[] {
            "VW Passat",
            "VW Tiguan",
            "VW Touareg",
            "VW Golf",
            "BMW X6",
            "BMW Z4",
            "Daewoo Matiz",
            "Hyundai Solaris",
            "Lada Niva"});
            this.carListBox.Location = new System.Drawing.Point(698, 416);
            this.carListBox.Name = "carListBox";
            this.carListBox.Size = new System.Drawing.Size(161, 24);
            this.carListBox.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1132, 515);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.carListBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.algListBox);
            this.Controls.Add(this.findCar);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.natureListBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tripsListBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.goodsListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.familyListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.activityListBox);
            this.Name = "Form1";
            this.Text = "PM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox activityListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox familyListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox commListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox natureListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox tripsListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox goodsListBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button findCar;
        private System.Windows.Forms.ListBox algListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox carListBox;
    }
}

