namespace GUI
{
    partial class ShoppingList
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxShopping = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxShopping
            // 
            this.listBoxShopping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxShopping.FormattingEnabled = true;
            this.listBoxShopping.ItemHeight = 15;
            this.listBoxShopping.Location = new System.Drawing.Point(4, 18);
            this.listBoxShopping.Name = "listBoxShopping";
            this.listBoxShopping.Size = new System.Drawing.Size(372, 229);
            this.listBoxShopping.TabIndex = 4;
            // 
            // ShoppingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxShopping);
            this.Name = "ShoppingList";
            this.Size = new System.Drawing.Size(380, 260);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxShopping;
    }
}
