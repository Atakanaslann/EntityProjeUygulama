using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBLKATAGORİ.Count().ToString();
            label3.Text = db.TBLURUN.Count().ToString();
            label5.Text = db.TBLMUSTERI.Count(x => x.DURUM == true).ToString();
            label7.Text = db.TBLMUSTERI.Count(x=> x.DURUM == false).ToString();
            label15.Text = db.TBLURUN.Count(x=> x.KATEGORİ == 1).ToString();    
            label13.Text = db.TBLURUN.Sum(y => y.STOK).ToString();
            label21.Text = db.TBLSATIS.Sum(x => x.FIYAT).ToString() + " TL";
            label11.Text = (from x in db.TBLURUN orderby x.FİYAT descending select x.URUNAD).FirstOrDefault();
            label9.Text = (from x in db.TBLURUN orderby x.FİYAT ascending select x.URUNAD).FirstOrDefault();
            label17.Text = db.TBLURUN.Count(x=> x.URUNAD == "BUZDOLABI").ToString();
            label23.Text = (from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();


        }
    }
}
