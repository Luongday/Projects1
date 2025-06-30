namespace QuanLyHoSoSinhVien
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
            dgvHoSoSV = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHoSoSV).BeginInit();
            SuspendLayout();
            // 
            // dgvHoSoSV
            // 
            dgvHoSoSV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoSoSV.Location = new Point(2, 0);
            dgvHoSoSV.Name = "dgvHoSoSV";
            dgvHoSoSV.RowHeadersWidth = 51;
            dgvHoSoSV.Size = new Size(1057, 291);
            dgvHoSoSV.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1057, 593);
            Controls.Add(dgvHoSoSV);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvHoSoSV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvHoSoSV;
    }
}
