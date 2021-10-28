namespace MazeWF
{
    partial class MazeF
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.recSizeText = new System.Windows.Forms.TextBox();
            this.intervalText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(14, 129);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 525);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(726, 518);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(434, 15);
            this.btnGen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(127, 106);
            this.btnGen.TabIndex = 1;
            this.btnGen.Text = "미로 생성";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "가로";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(303, 30);
            this.widthBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(38, 25);
            this.widthBox.TabIndex = 3;
            this.widthBox.Text = "20";
            this.widthBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "세로";
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(303, 64);
            this.heightBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(38, 25);
            this.heightBox.TabIndex = 5;
            this.heightBox.Text = "20";
            this.heightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(567, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 106);
            this.button1.TabIndex = 6;
            this.button1.Text = "DFS 실행";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // recSizeText
            // 
            this.recSizeText.Location = new System.Drawing.Point(166, 30);
            this.recSizeText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.recSizeText.Name = "recSizeText";
            this.recSizeText.Size = new System.Drawing.Size(38, 25);
            this.recSizeText.TabIndex = 7;
            this.recSizeText.Text = "10";
            this.recSizeText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // intervalText
            // 
            this.intervalText.Location = new System.Drawing.Point(166, 64);
            this.intervalText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.intervalText.Name = "intervalText";
            this.intervalText.Size = new System.Drawing.Size(38, 25);
            this.intervalText.TabIndex = 8;
            this.intervalText.Text = "30";
            this.intervalText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "픽셀 크기";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "애니메이션 속도";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(77, 98);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(139, 19);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "애니메이션 끄기";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(695, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 106);
            this.button2.TabIndex = 14;
            this.button2.Text = "종료";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(631, 15);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 106);
            this.button3.TabIndex = 15;
            this.button3.Text = "BFS 실행";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MazeF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 669);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.intervalText);
            this.Controls.Add(this.recSizeText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MazeF";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox recSizeText;
        private System.Windows.Forms.TextBox intervalText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

