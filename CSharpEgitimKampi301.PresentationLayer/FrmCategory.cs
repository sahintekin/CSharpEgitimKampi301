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
    public partial class Form1 : Form
    {
        private readonly ICategoryService _categoryService;

        public Form1()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource= categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName=textName.Text;
            category.CategoryStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Ekleme İşlemi Başarıyla Yapıldı");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textID.Text);
            var deletedValues=_categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Silme İşlemi Başarıyla Yapıldı");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textID.Text);
            var values = _categoryService.TGetById(id);
            dataGridView1.DataSource= values;
            MessageBox.Show("İdye göre getirme İşlemi Başarıyla Yapıldı");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            int updatedId=int.Parse(textID.Text);
            var updatedValue = _categoryService.TGetById(updatedId);
            updatedValue.CategoryName= textName.Text;
            updatedValue.CategoryStatus = true;
            _categoryService.TUpdate(updatedValue);
            MessageBox.Show("Güncelleme İşlemi Başarıyla Yapıldı");

        }

		
	}
}
