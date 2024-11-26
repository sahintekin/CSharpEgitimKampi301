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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db =new EgitimKampiEfTravelDbEntities();

        private void btnListele_Click(object sender, EventArgs e)
        {
            var values=db.Location.ToList();
            dataGridView1.DataSource= values;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                FullName=x.GuideName+" " + x.GuideSurname,
                x.GuideId
            }).ToList();
            comboGuide.DisplayMember = "FullName";
            comboGuide.ValueMember = "GuideId";
            comboGuide.DataSource=values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.LocationCapacity=byte.Parse(numericUpDown1.Value.ToString());
            location.LocationCity=textCity.Text;
            location.LocationCountry=textCountry.Text;
            location.LocationPrice = decimal.Parse(textPrice.Text);
            location.DayNight = textDay.Text;
            location.GuideId= int.Parse(comboGuide.SelectedValue.ToString());

            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi yapıldı");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id =int.Parse(LocaId.Text);
            var deletedValue = db.Location.Find(id);
            db.Location.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi yapıldı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(LocaId.Text);
            var updatedValue = db.Location.Find(id);
            updatedValue.DayNight= textDay.Text;
            updatedValue.LocationCapacity = byte.Parse(numericUpDown1.Value.ToString());
            updatedValue.LocationCity = textCity.Text;
            updatedValue.LocationCountry = textCountry.Text;
            updatedValue.LocationPrice = decimal.Parse(textPrice.Text);
            updatedValue.GuideId = int.Parse(comboGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Güncelleme işlemi yapıldı");

        }
    }
}
