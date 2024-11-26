using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void btnListele_Click(object sender, EventArgs e)
        {
          
            var values = db.Guide.ToList();

            dataGridView1.DataSource= values;
            textId.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide= new Guide();
            guide.GuideName = textName.Text;
            guide.GuideSurname = textSoyad.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            int id = int.Parse(textId.Text);

            var removeValue=db.Guide.Find(id);

            db.Guide.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Rehber silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(textId.Text);

            var updateValue = db.Guide.Find(id);

            updateValue.GuideName = textName.Text;
            updateValue.GuideSurname= textSoyad.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Güncellendi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textId.Text);
            var values=db.Guide.Where(x=>x.GuideId==id).ToList();   
            dataGridView1.DataSource= values;
        }
    }
}
