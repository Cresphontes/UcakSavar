using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakSavar.Lib;

namespace UcakSavar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private Oyun oyun;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && oyun == null)
            {
                oyun = new Oyun(this);
                lbl1.Visible = false;
                lbl2.Visible = false;
                lbl3.Visible = false;
            }
            else if (e.KeyCode == Keys.Left)
            {
                oyun?.UcakSavar.HarekeEt(Yonler.sol);
            }
            else if (e.KeyCode == Keys.Right)
            {
                oyun?.UcakSavar.HarekeEt(Yonler.sag);
            }
            else if (e.KeyCode == Keys.Space)
            {
                oyun?.UcakSavar.AtesEt();
            }

          
        }

       

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dosyaKaydet.Title = "Bir Json Dosyası Seçiniz.";
            dosyaKaydet.Filter = "(Json Dosyası)| *.json";
            dosyaKaydet.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dosyaKaydet.FileName = "Skor";


            if(dosyaKaydet.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream file = File.Open(dosyaKaydet.FileName, FileMode.Create);
                    StreamWriter writer = new StreamWriter(file);
                    writer.Write(JsonConvert.SerializeObject(oyun.labelSkor.Text));
                    writer.Close();
                    writer.Dispose();
                    MessageBox.Show($"{dosyaKaydet.FileName} dosyası başarıyla kaydedildi.");
                }
                catch (Exception)
                {

                    throw new Exception("Skor Kaydı Başarısız.");
                }

            }
        }

        private void AcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dosyaAc.Title = "Bir Json Dosyası Seçiniz.";
            dosyaAc.Filter = "(Json Dosyası)|*.json";
            dosyaAc.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dosyaAc.FileName = "Skor.json";

            if (dosyaAc.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream file = File.OpenRead(dosyaAc.FileName);
                    StreamReader reader = new StreamReader(file);
                    string fileContent = reader.ReadToEnd();
                    reader.Close();
                    file.Close();
                    oyun.labelSkor.Text = (JsonConvert.DeserializeObject(fileContent) as Label).ToString();
                    MessageBox.Show("Oyun başarıyla yüklendi.");
                }
                catch (Exception ex)
                {

                    throw new Exception("Bir hata oluştu: " + ex.Message);
                }


            }

            
        }
    }

    

}
