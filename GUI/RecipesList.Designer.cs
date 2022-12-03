
namespace GUI
{
    partial class RecipesList
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
            this.listBoxRecipes = new System.Windows.Forms.ListBox();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.btnChooseRecipe = new System.Windows.Forms.Button();
            this.btnRemoveRecipe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxRecipes
            // 
            this.listBoxRecipes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRecipes.FormattingEnabled = true;
            this.listBoxRecipes.ItemHeight = 15;
            this.listBoxRecipes.Location = new System.Drawing.Point(4, 33);
            this.listBoxRecipes.Name = "listBoxRecipes";
            this.listBoxRecipes.Size = new System.Drawing.Size(372, 214);
            this.listBoxRecipes.Sorted = true;
            this.listBoxRecipes.TabIndex = 0;
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Enabled = false;
            this.btnAddRecipe.Location = new System.Drawing.Point(4, 4);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(120, 23);
            this.btnAddRecipe.TabIndex = 1;
            this.btnAddRecipe.Text = "Создать рецепт";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            // 
            // btnChooseRecipe
            // 
            this.btnChooseRecipe.Location = new System.Drawing.Point(130, 4);
            this.btnChooseRecipe.Name = "btnChooseRecipe";
            this.btnChooseRecipe.Size = new System.Drawing.Size(120, 23);
            this.btnChooseRecipe.TabIndex = 2;
            this.btnChooseRecipe.Text = "Выбрать рецепт";
            this.btnChooseRecipe.UseVisualStyleBackColor = true;
            this.btnChooseRecipe.Click += new System.EventHandler(this.btnChooseRecipe_Click);
            // 
            // btnRemoveRecipe
            // 
            this.btnRemoveRecipe.Enabled = false;
            this.btnRemoveRecipe.Location = new System.Drawing.Point(256, 4);
            this.btnRemoveRecipe.Name = "btnRemoveRecipe";
            this.btnRemoveRecipe.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveRecipe.TabIndex = 3;
            this.btnRemoveRecipe.Text = "Удалить рецепт";
            this.btnRemoveRecipe.UseVisualStyleBackColor = true;
            // 
            // RecipesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemoveRecipe);
            this.Controls.Add(this.btnChooseRecipe);
            this.Controls.Add(this.btnAddRecipe);
            this.Controls.Add(this.listBoxRecipes);
            this.Name = "RecipesList";
            this.Size = new System.Drawing.Size(380, 260);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRecipes;
        private System.Windows.Forms.Button btnAddRecipe;
        private System.Windows.Forms.Button btnChooseRecipe;
        private System.Windows.Forms.Button btnRemoveRecipe;
    }
}
