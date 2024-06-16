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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void BTNlİSTELE_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLURUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.DURUM,
                                            x.STOK,
                                            x.FİYAT,
                                            x.TBLKATAGORİ.AD
                                        }).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.URUNAD = txtUrunAd.Text;
            t.MARKA = txtMarka.Text;
            t.STOK = short.Parse(txtStok.Text);
            t.FİYAT = decimal.Parse(txtFiyat.Text);
            t.KATEGORİ = int.Parse(cmbKategori.SelectedValue.ToString());
            t.DURUM = true;
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Eklendi");


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var urun = db.TBLURUN.Find(x);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var urun = db.TBLURUN.Find(x);
            urun.URUNAD = txtUrunAd.Text;
            urun.MARKA = txtMarka.Text;
            urun.STOK = short.Parse(txtStok.Text);
            urun.FİYAT = decimal.Parse(txtFiyat.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategori = (from x in db.TBLURUN select new { x.URUNID, x.URUNAD }).ToList();
            cmbKategori.ValueMember = "URUNID";
            cmbKategori.DisplayMember = "URUNAD";
            cmbKategori.DataSource = kategori;
        }
    }
}
