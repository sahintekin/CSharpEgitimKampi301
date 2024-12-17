using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }
        
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource= values;
        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource= values;   
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textProductId.Text);
            var value=_productService.TGetById(id);
            _productService.TDelete(value);
			MessageBox.Show("Silme işlemi gerçekleşti");
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
            Product product = new Product();
            product.CategoryId = int.Parse(comboBoxKategori.SelectedValue.ToString());
            product.ProductPrice=decimal.Parse(textPFiyat.Text);
            product.ProductName=textPName.Text;
            product.ProductDescription=textPAciklama.Text;
            product.ProductStock=int.Parse(textPStok.Text);
            _productService.TInsert(product);
            MessageBox.Show("Ekleme işlemi gerçekleşti");

			foreach (var item  in this.Controls)
			{
				if (item is TextBox textBox)
				{
					textBox.Text = "";
					
				}
			}
			comboBoxKategori.Text = "";



		}

		private void btnGetById_Click(object sender, EventArgs e)
		{
            int id =int.Parse(textProductId.Text);
            var value = _productService.TGetById(id);
            dataGridView1.DataSource=value;
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
            int id = int.Parse(textProductId.Text);
            var value = _productService.TGetById(id);
            value.ProductDescription = textPAciklama.Text;
            value.CategoryId = int.Parse(comboBoxKategori.SelectedValue.ToString());
            value.ProductPrice = decimal.Parse(textPFiyat.Text);
            value.ProductStock = int.Parse(textPStok.Text);
            value.ProductName = textPName.Text;
            _productService.TUpdate(value);
			MessageBox.Show("Güncelleme işlemi gerçekleşti");

		}

		private void FrmProduct_Load(object sender, EventArgs e)
		{
            var values = _categoryService.TGetAll();
            comboBoxKategori.DataSource=values;
            comboBoxKategori.DisplayMember = "CategoryName";
            comboBoxKategori.ValueMember= "CategoryId";
		}
	}
}
