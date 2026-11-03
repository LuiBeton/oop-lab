namespace formlab5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gbTetragon = new System.Windows.Forms.GroupBox();
            this.lblTetragonResult = new System.Windows.Forms.Label();
            this.btnCheckTetragon = new System.Windows.Forms.Button();
            this.txtPointY = new System.Windows.Forms.TextBox();
            this.lblY = new System.Windows.Forms.Label();
            this.txtPointX = new System.Windows.Forms.TextBox();
            this.lblX = new System.Windows.Forms.Label();
            this.gbPolygon = new System.Windows.Forms.GroupBox();
            this.lblPolygonConvex = new System.Windows.Forms.Label();
            this.lblPolygonArea = new System.Windows.Forms.Label();
            this.btnGeneratePolygon = new System.Windows.Forms.Button();
            this.txtPointCount = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.gbTetragon.SuspendLayout();
            this.gbPolygon.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTetragon
            // 
            this.gbTetragon.Controls.Add(this.lblTetragonResult);
            this.gbTetragon.Controls.Add(this.btnCheckTetragon);
            this.gbTetragon.Controls.Add(this.txtPointY);
            this.gbTetragon.Controls.Add(this.lblY);
            this.gbTetragon.Controls.Add(this.txtPointX);
            this.gbTetragon.Controls.Add(this.lblX);
            this.gbTetragon.Location = new System.Drawing.Point(20, 20);
            this.gbTetragon.Name = "gbTetragon";
            this.gbTetragon.Size = new System.Drawing.Size(590, 150);
            this.gbTetragon.TabIndex = 0;
            this.gbTetragon.TabStop = false;
            this.gbTetragon.Text = "Завдання 1: Перевірка точки в чотирикутнику";
            // 
            // lblTetragonResult
            // 
            this.lblTetragonResult.AutoSize = true;
            this.lblTetragonResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTetragonResult.Location = new System.Drawing.Point(20, 110);
            this.lblTetragonResult.Name = "lblTetragonResult";
            this.lblTetragonResult.Size = new System.Drawing.Size(111, 13);
            this.lblTetragonResult.TabIndex = 5;
            this.lblTetragonResult.Text = "Результат: ...";
            // 
            // btnCheckTetragon
            // 
            this.btnCheckTetragon.Location = new System.Drawing.Point(20, 65);
            this.btnCheckTetragon.Name = "btnCheckTetragon";
            this.btnCheckTetragon.Size = new System.Drawing.Size(150, 30);
            this.btnCheckTetragon.TabIndex = 4;
            this.btnCheckTetragon.Text = "Перевірити точку";
            this.btnCheckTetragon.UseVisualStyleBackColor = true;
            this.btnCheckTetragon.Click += new System.EventHandler(this.btnCheckTetragon_Click);
            // 
            // txtPointY
            // 
            this.txtPointY.Location = new System.Drawing.Point(360, 27);
            this.txtPointY.Name = "txtPointY";
            this.txtPointY.Size = new System.Drawing.Size(100, 20);
            this.txtPointY.TabIndex = 3;
            this.txtPointY.Text = "2";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(250, 30);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(81, 13);
            this.lblY.TabIndex = 2;
            this.lblY.Text = "Координата Y:";
            // 
            // txtPointX
            // 
            this.txtPointX.Location = new System.Drawing.Point(130, 27);
            this.txtPointX.Name = "txtPointX";
            this.txtPointX.Size = new System.Drawing.Size(100, 20);
            this.txtPointX.TabIndex = 1;
            this.txtPointX.Text = "2";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(20, 30);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(81, 13);
            this.lblX.TabIndex = 0;
            this.lblX.Text = "Координата X:";
            // 
            // gbPolygon
            // 
            this.gbPolygon.Controls.Add(this.lblPolygonConvex);
            this.gbPolygon.Controls.Add(this.lblPolygonArea);
            this.gbPolygon.Controls.Add(this.btnGeneratePolygon);
            this.gbPolygon.Controls.Add(this.txtPointCount);
            this.gbPolygon.Controls.Add(this.lblCount);
            this.gbPolygon.Location = new System.Drawing.Point(20, 190);
            this.gbPolygon.Name = "gbPolygon";
            this.gbPolygon.Size = new System.Drawing.Size(590, 170);
            this.gbPolygon.TabIndex = 1;
            this.gbPolygon.TabStop = false;
            this.gbPolygon.Text = "Завдання 2: Аналіз багатокутника з випадкових точок";
            // 
            // lblPolygonConvex
            // 
            this.lblPolygonConvex.AutoSize = true;
            this.lblPolygonConvex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPolygonConvex.Location = new System.Drawing.Point(20, 115);
            this.lblPolygonConvex.Name = "lblPolygonConvex";
            this.lblPolygonConvex.Size = new System.Drawing.Size(70, 13);
            this.lblPolygonConvex.TabIndex = 4;
            this.lblPolygonConvex.Text = "Статус: -";
            // 
            // lblPolygonArea
            // 
            this.lblPolygonArea.AutoSize = true;
            this.lblPolygonArea.Location = new System.Drawing.Point(20, 80);
            this.lblPolygonArea.Name = "lblPolygonArea";
            this.lblPolygonArea.Size = new System.Drawing.Size(130, 13);
            this.lblPolygonArea.TabIndex = 3;
            this.lblPolygonArea.Text = "Площа багатокутника: -";
            // 
            // btnGeneratePolygon
            // 
            this.btnGeneratePolygon.Location = new System.Drawing.Point(280, 29);
            this.btnGeneratePolygon.Name = "btnGeneratePolygon";
            this.btnGeneratePolygon.Size = new System.Drawing.Size(200, 30);
            this.btnGeneratePolygon.TabIndex = 2;
            this.btnGeneratePolygon.Text = "Згенерувати та проаналізувати";
            this.btnGeneratePolygon.UseVisualStyleBackColor = true;
            this.btnGeneratePolygon.Click += new System.EventHandler(this.btnGeneratePolygon_Click);
            // 
            // txtPointCount
            // 
            this.txtPointCount.Location = new System.Drawing.Point(150, 32);
            this.txtPointCount.Name = "txtPointCount";
            this.txtPointCount.Size = new System.Drawing.Size(100, 20);
            this.txtPointCount.TabIndex = 1;
            this.txtPointCount.Text = "6";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(20, 35);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(103, 13);
            this.lblCount.TabIndex = 0;
            this.lblCount.Text = "Кількість точок (n):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 385);
            this.Controls.Add(this.gbPolygon);
            this.Controls.Add(this.gbTetragon);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторна робота: Геометричні класи та DLL";
            this.gbTetragon.ResumeLayout(false);
            this.gbTetragon.PerformLayout();
            this.gbPolygon.ResumeLayout(false);
            this.gbPolygon.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox gbTetragon;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.TextBox txtPointX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.TextBox txtPointY;
        private System.Windows.Forms.Button btnCheckTetragon;
        private System.Windows.Forms.Label lblTetragonResult;
        private System.Windows.Forms.GroupBox gbPolygon;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtPointCount;
        private System.Windows.Forms.Button btnGeneratePolygon;
        private System.Windows.Forms.Label lblPolygonArea;
        private System.Windows.Forms.Label lblPolygonConvex;
    }
}