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
	public partial class FrmStatistics : Form
	{
		public FrmStatistics()
		{
			InitializeComponent();
		}

		EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

		private void FrmStatistics_Load(object sender, EventArgs e)
		{
			// Toplam  Lokasyon Sayısı

			lblLocationCount.Text = db.Location.Count().ToString();
			lblSumCapacity.Text = db.Location.Sum(x => x.LocationCapacity).ToString();
			lblRehber.Text = db.Guide.Count().ToString();

			lblAVgCapacity.Text = db.Location.Average(x => x.LocationCapacity).ToString();
			decimal avgLocationPrice = decimal.Parse(db.Location.Average(x => x.LocationPrice).ToString());
			lblAvgPrice.Text = avgLocationPrice.ToString("0.00") + " ₺";

			int lastCountryId = db.Location.Max(x => x.LocationId);
			lblLastCountry.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.LocationCountry).FirstOrDefault();
			lblKapadokyaTurKapasitesi.Text = db.Location.Where(x => x.LocationCity == "Kapadokya").Select(y => y.LocationCapacity).FirstOrDefault().ToString();
			lblTurAvgCapacity.Text = db.Location.Where(x => x.LocationCountry == "Türkiye").Average(y => y.LocationCapacity).ToString();

			var romeGudieId = db.Location.Where(x => x.LocationCity == "Roma").Select(y => y.GuideId).FirstOrDefault();
			lblGuideName.Text = db.Guide.Where(x => x.GuideId == romeGudieId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

			var maxCapacity = db.Location.Max(x => x.LocationCapacity);
			lblMaxCapacity.Text = db.Location.Where(x => x.LocationCapacity == maxCapacity).Select(y => y.LocationCity).FirstOrDefault().ToString();

			var maxPrice = db.Location.Max(x => x.LocationPrice);
			lblMaxPrice.Text = db.Location.Where(x => x.LocationPrice == maxPrice).Select(y => y.LocationCity).FirstOrDefault().ToString();

			var guideIdByName = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
			lblSahısTurSayısı.Text = db.Location.Where(x => x.GuideId == guideIdByName).Count().ToString();
		
		
		}



	}
}
