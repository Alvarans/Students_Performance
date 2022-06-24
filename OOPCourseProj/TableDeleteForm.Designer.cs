namespace OOPCourseProj
{
    partial class TableDeleteForm
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
            this.TableDelTextBox = new System.Windows.Forms.TextBox();
            this.TableDelLabel = new System.Windows.Forms.Label();
            this.TableDelButtonConfirm = new System.Windows.Forms.Button();
            this.TableDelButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TableDelTextBox
            // 
            this.TableDelTextBox.Location = new System.Drawing.Point(59, 103);
            this.TableDelTextBox.Name = "TableDelTextBox";
            this.TableDelTextBox.Size = new System.Drawing.Size(275, 27);
            this.TableDelTextBox.TabIndex = 0;
            // 
            // TableDelLabel
            // 
            this.TableDelLabel.AutoSize = true;
            this.TableDelLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TableDelLabel.Location = new System.Drawing.Point(28, 46);
            this.TableDelLabel.Name = "TableDelLabel";
            this.TableDelLabel.Size = new System.Drawing.Size(338, 28);
            this.TableDelLabel.TabIndex = 1;
            this.TableDelLabel.Text = "Введите имя таблицы для удаления";
            // 
            // TableDelButtonConfirm
            // 
            this.TableDelButtonConfirm.Location = new System.Drawing.Point(70, 202);
            this.TableDelButtonConfirm.Name = "TableDelButtonConfirm";
            this.TableDelButtonConfirm.Size = new System.Drawing.Size(94, 29);
            this.TableDelButtonConfirm.TabIndex = 2;
            this.TableDelButtonConfirm.Text = "Удалить";
            this.TableDelButtonConfirm.UseVisualStyleBackColor = true;
            this.TableDelButtonConfirm.Click += new System.EventHandler(this.TableDelButtonConfirm_Click);
            // 
            // TableDelButtonCancel
            // 
            this.TableDelButtonCancel.Location = new System.Drawing.Point(240, 202);
            this.TableDelButtonCancel.Name = "TableDelButtonCancel";
            this.TableDelButtonCancel.Size = new System.Drawing.Size(94, 29);
            this.TableDelButtonCancel.TabIndex = 3;
            this.TableDelButtonCancel.Text = "Отмена";
            this.TableDelButtonCancel.UseVisualStyleBackColor = true;
            this.TableDelButtonCancel.Click += new System.EventHandler(this.TableDelButtonCancel_Click);
            // 
            // TableDeleteForm
            // 
            this.AcceptButton = this.TableDelButtonConfirm;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Azure;
            this.CancelButton = this.TableDelButtonCancel;
            this.ClientSize = new System.Drawing.Size(398, 283);
            this.ControlBox = false;
            this.Controls.Add(this.TableDelButtonCancel);
            this.Controls.Add(this.TableDelButtonConfirm);
            this.Controls.Add(this.TableDelLabel);
            this.Controls.Add(this.TableDelTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 330);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 330);
            this.Name = "TableDeleteForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удаление таблицы";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TableDelTextBox;
        private System.Windows.Forms.Label TableDelLabel;
        private System.Windows.Forms.Button TableDelButtonConfirm;
        private System.Windows.Forms.Button TableDelButtonCancel;
    }
}