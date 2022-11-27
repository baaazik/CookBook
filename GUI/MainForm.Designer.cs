
namespace GUI
{
    partial class MainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageRecipes = new System.Windows.Forms.TabPage();
            this.recipesList1 = new GUI.RecipesList();
            this.pageSelected = new System.Windows.Forms.TabPage();
            this.pageShoppingList = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.pageRecipes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.pageRecipes);
            this.tabControl.Controls.Add(this.pageSelected);
            this.tabControl.Controls.Add(this.pageShoppingList);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(625, 426);
            this.tabControl.TabIndex = 0;
            // 
            // pageRecipes
            // 
            this.pageRecipes.Controls.Add(this.recipesList1);
            this.pageRecipes.Location = new System.Drawing.Point(4, 24);
            this.pageRecipes.Name = "pageRecipes";
            this.pageRecipes.Padding = new System.Windows.Forms.Padding(3);
            this.pageRecipes.Size = new System.Drawing.Size(617, 398);
            this.pageRecipes.TabIndex = 0;
            this.pageRecipes.Text = "Список рецептов";
            this.pageRecipes.UseVisualStyleBackColor = true;
            // 
            // recipesList1
            // 
            this.recipesList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recipesList1.Location = new System.Drawing.Point(6, 6);
            this.recipesList1.Name = "recipesList1";
            this.recipesList1.Size = new System.Drawing.Size(605, 386);
            this.recipesList1.TabIndex = 0;
            // 
            // pageSelected
            // 
            this.pageSelected.Location = new System.Drawing.Point(4, 24);
            this.pageSelected.Name = "pageSelected";
            this.pageSelected.Padding = new System.Windows.Forms.Padding(3);
            this.pageSelected.Size = new System.Drawing.Size(617, 398);
            this.pageSelected.TabIndex = 1;
            this.pageSelected.Text = "Выбранные рецепты";
            this.pageSelected.UseVisualStyleBackColor = true;
            // 
            // pageShoppingList
            // 
            this.pageShoppingList.Location = new System.Drawing.Point(4, 24);
            this.pageShoppingList.Name = "pageShoppingList";
            this.pageShoppingList.Padding = new System.Windows.Forms.Padding(3);
            this.pageShoppingList.Size = new System.Drawing.Size(617, 398);
            this.pageShoppingList.TabIndex = 2;
            this.pageShoppingList.Text = "Список покупок";
            this.pageShoppingList.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Книга рецептов";
            this.tabControl.ResumeLayout(false);
            this.pageRecipes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pageRecipes;
        private System.Windows.Forms.TabPage pageSelected;
        private System.Windows.Forms.TabPage pageShoppingList;
        private RecipesList recipesList1;
    }
}

