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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TBLKATAGORİ t = new TBLKATAGORİ();
            t.AD = textBox2.Text;
            db.TBLKATAGORİ.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi");
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.TBLKATAGORİ.ToList();
            dataGridView1.DataSource = kategoriler;
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var kategori = db.TBLKATAGORİ.Find(x);
            db.TBLKATAGORİ.Remove(kategori);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var kategori = db.TBLKATAGORİ.Find(x);
            kategori.AD = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Tamamlandı");

        }
    }
}
