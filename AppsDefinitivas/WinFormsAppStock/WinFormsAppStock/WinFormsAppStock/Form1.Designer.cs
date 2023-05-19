namespace WinFormsAppStock
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
            btnArticulos = new Button();
            btnDepositos = new Button();
            btnStocks = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnArticulos
            // 
            btnArticulos.Location = new Point(152, 99);
            btnArticulos.Margin = new Padding(3, 2, 3, 2);
            btnArticulos.Name = "btnArticulos";
            btnArticulos.Size = new Size(108, 22);
            btnArticulos.TabIndex = 0;
            btnArticulos.Text = "Articulos";
            btnArticulos.UseVisualStyleBackColor = true;
            btnArticulos.Click += btnArticulos_Click;
            // 
            // btnDepositos
            // 
            btnDepositos.Location = new Point(152, 151);
            btnDepositos.Margin = new Padding(3, 2, 3, 2);
            btnDepositos.Name = "btnDepositos";
            btnDepositos.Size = new Size(108, 22);
            btnDepositos.TabIndex = 1;
            btnDepositos.Text = "Depositos";
            btnDepositos.UseVisualStyleBackColor = true;
            btnDepositos.Click += btnDepositos_Click;
            // 
            // btnStocks
            // 
            btnStocks.Location = new Point(152, 205);
            btnStocks.Margin = new Padding(3, 2, 3, 2);
            btnStocks.Name = "btnStocks";
            btnStocks.Size = new Size(108, 22);
            btnStocks.TabIndex = 2;
            btnStocks.Text = "Stocks";
            btnStocks.UseVisualStyleBackColor = true;
            btnStocks.Click += btnStocks_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(152, 18);
            label1.Name = "label1";
            label1.Size = new Size(128, 31);
            label1.TabIndex = 3;
            label1.Text = "AppStock";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 277);
            Controls.Add(label1);
            Controls.Add(btnStocks);
            Controls.Add(btnDepositos);
            Controls.Add(btnArticulos);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "AppStock";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnArticulos;
        private Button btnDepositos;
        private Button btnStocks;
        private Label label1;
    }
}