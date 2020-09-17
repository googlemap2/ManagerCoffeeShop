namespace ManagerCoffeeShop
{
    partial class Product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Product));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cb_selectProduct = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_delProduct = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstripbtn_Menu = new System.Windows.Forms.ToolStripButton();
            this.toolstripbtn_Product = new System.Windows.Forms.ToolStripButton();
            this.btn_back = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_size = new System.Windows.Forms.ComboBox();
            this.btn_insertProduct = new System.Windows.Forms.Button();
            this.tb_sale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_sell = new System.Windows.Forms.TextBox();
            this.tb_insertProduct = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cb_selectProduct);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btn_delProduct);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.btn_back);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cb_size);
            this.panel1.Controls.Add(this.btn_insertProduct);
            this.panel1.Controls.Add(this.tb_sale);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tb_sell);
            this.panel1.Controls.Add(this.tb_insertProduct);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 236);
            this.panel1.TabIndex = 0;
            // 
            // cb_selectProduct
            // 
            this.cb_selectProduct.FormattingEnabled = true;
            this.cb_selectProduct.Location = new System.Drawing.Point(111, 64);
            this.cb_selectProduct.Name = "cb_selectProduct";
            this.cb_selectProduct.Size = new System.Drawing.Size(148, 21);
            this.cb_selectProduct.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Chọn sản phẩm";
            // 
            // btn_delProduct
            // 
            this.btn_delProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btn_delProduct.FlatAppearance.BorderSize = 0;
            this.btn_delProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delProduct.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_delProduct.Location = new System.Drawing.Point(210, 201);
            this.btn_delProduct.Name = "btn_delProduct";
            this.btn_delProduct.Size = new System.Drawing.Size(75, 23);
            this.btn_delProduct.TabIndex = 11;
            this.btn_delProduct.Text = "Xóa";
            this.btn_delProduct.UseVisualStyleBackColor = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripbtn_Menu,
            this.toolstripbtn_Product});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(297, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstripbtn_Menu
            // 
            this.toolstripbtn_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.toolstripbtn_Menu.ForeColor = System.Drawing.Color.Coral;
            this.toolstripbtn_Menu.Image = ((System.Drawing.Image)(resources.GetObject("toolstripbtn_Menu.Image")));
            this.toolstripbtn_Menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstripbtn_Menu.Name = "toolstripbtn_Menu";
            this.toolstripbtn_Menu.Size = new System.Drawing.Size(58, 22);
            this.toolstripbtn_Menu.Text = "Menu";
            this.toolstripbtn_Menu.ToolTipText = "Thêm món";
            // 
            // toolstripbtn_Product
            // 
            this.toolstripbtn_Product.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.toolstripbtn_Product.ForeColor = System.Drawing.Color.Coral;
            this.toolstripbtn_Product.Image = ((System.Drawing.Image)(resources.GetObject("toolstripbtn_Product.Image")));
            this.toolstripbtn_Product.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstripbtn_Product.Name = "toolstripbtn_Product";
            this.toolstripbtn_Product.Size = new System.Drawing.Size(52, 22);
            this.toolstripbtn_Product.Text = "Món";
            this.toolstripbtn_Product.ToolTipText = "Thêm món";
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btn_back.FlatAppearance.BorderSize = 0;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_back.Location = new System.Drawing.Point(12, 201);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(77, 23);
            this.btn_back.TabIndex = 9;
            this.btn_back.Text = "Trở về";
            this.btn_back.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Size:";
            // 
            // cb_size
            // 
            this.cb_size.FormattingEnabled = true;
            this.cb_size.Location = new System.Drawing.Point(111, 95);
            this.cb_size.Name = "cb_size";
            this.cb_size.Size = new System.Drawing.Size(121, 21);
            this.cb_size.TabIndex = 7;
            // 
            // btn_insertProduct
            // 
            this.btn_insertProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.btn_insertProduct.FlatAppearance.BorderSize = 0;
            this.btn_insertProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_insertProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_insertProduct.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_insertProduct.Location = new System.Drawing.Point(111, 201);
            this.btn_insertProduct.Name = "btn_insertProduct";
            this.btn_insertProduct.Size = new System.Drawing.Size(75, 23);
            this.btn_insertProduct.TabIndex = 6;
            this.btn_insertProduct.Text = "Thêm";
            this.btn_insertProduct.UseVisualStyleBackColor = false;
            // 
            // tb_sale
            // 
            this.tb_sale.Location = new System.Drawing.Point(111, 157);
            this.tb_sale.Name = "tb_sale";
            this.tb_sale.Size = new System.Drawing.Size(148, 20);
            this.tb_sale.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sale";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Giá Bán";
            // 
            // tb_sell
            // 
            this.tb_sell.Location = new System.Drawing.Point(111, 125);
            this.tb_sell.Name = "tb_sell";
            this.tb_sell.Size = new System.Drawing.Size(148, 20);
            this.tb_sell.TabIndex = 2;
            // 
            // tb_insertProduct
            // 
            this.tb_insertProduct.Location = new System.Drawing.Point(111, 34);
            this.tb_insertProduct.Name = "tb_insertProduct";
            this.tb_insertProduct.Size = new System.Drawing.Size(148, 20);
            this.tb_insertProduct.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Sản Phẩm:";
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(297, 236);
            this.Controls.Add(this.panel1);
            this.Name = "Product";
            this.Text = "Product";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_insertProduct;
        private System.Windows.Forms.TextBox tb_sale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_sell;
        private System.Windows.Forms.TextBox tb_insertProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_size;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstripbtn_Menu;
        private System.Windows.Forms.ToolStripButton toolstripbtn_Product;
        private System.Windows.Forms.Button btn_delProduct;
        private System.Windows.Forms.ComboBox cb_selectProduct;
        private System.Windows.Forms.Label label5;
    }
}