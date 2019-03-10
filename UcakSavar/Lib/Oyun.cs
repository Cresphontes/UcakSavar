using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcakSavar.Lib
{
    public class Oyun
    {
        private Timer tmr_uretim, tmr_roket, tmr_ucak, tmr_kontrol;
        private ContainerControl container;
        bool vurduMu = false;
        int skor = 0;


        public List<Ucak> Ucaklar { get; set; } = new List<Ucak>();
        public List<Ucak> UcakVurulanlar { get; set; } = new List<Ucak>();
        public UcakSavar UcakSavar { get; set; }
        public Label labelSkor { get; set; }
        public Label labelSkorText { get; set; }


        public Oyun(ContainerControl container)
        {
            this.container = container;

            this.UcakSavar = new UcakSavar(this.container);

            Point konumlabelSkor = new Point()
            {
                X = 90,
                Y = 30
            };

            Point konumlabelSkorText = new Point()
            {
                X = 20,
                Y = 30
            };


            this.labelSkor = new Label()
            {
                Location = konumlabelSkor,
                Font = new Font("Arial", 15),
                ForeColor = Color.Crimson

            };

            this.labelSkorText = new Label()
            {
                Location = konumlabelSkorText,
                Text = "SKOR: ",
                Font = new Font("Arial", 15),
                ForeColor = Color.Crimson

            };

            container.Controls.Add(labelSkor);
            container.Controls.Add(labelSkorText);

            tmr_uretim = new Timer()
            {
                Enabled = true,
                Interval = 1200
            };
            tmr_uretim.Tick += Ucak_Uretim_Tick;

            tmr_roket = new Timer()
            {
                Enabled = true,
                Interval = 5

            };
            tmr_roket.Tick += Roket_Hareket_Tick;

            tmr_ucak = new Timer()
            {
                Enabled = true,
                Interval = 120

            };

            tmr_ucak.Tick += Ucak_Hareket_Tick;

            tmr_kontrol = new Timer()
            {
                Enabled = true,
                Interval = 20
            };

            tmr_kontrol.Tick += Kontrol_Tick;
        }


        private void Kontrol_Tick(object sender, System.EventArgs e)
        {



            foreach (Ucak ucak in Ucaklar)
            {


                if (ucak.Resim.Location.Y + ucak.Resim.Height > container.Height - 70)
                {
                    tmr_kontrol.Stop();
                    tmr_roket.Stop();
                    tmr_ucak.Stop();
                    tmr_uretim.Stop();
               
                }

                


                bool vurduMu = false;
                foreach (Roket roket in UcakSavar.Roketler)
                {

                    if (roket.Resim.Bounds.IntersectsWith(ucak.Resim.Bounds))
                    {
                        vurduMu = true;


                        container.Controls.Remove(roket.Resim);
                        container.Controls.Remove(ucak.Resim);
                        UcakSavar.Roketler.Remove(roket);
                        Ucaklar.Remove(ucak);

                        SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.bomb_small);
                        soundPlayer.Play();
                        break;
                    }

              

                }
                if (vurduMu)
                {
                    skor++;

                    break;
                }


            }



            labelSkor.Text = $"{skor}";

            foreach (Ucak ucakVurulan in UcakVurulanlar)
            {

                if (ucakVurulan.Resim.Location.Y + ucakVurulan.Resim.Height > container.Height - 70)
                {
                    container.Controls.Remove(ucakVurulan.Resim);
                    UcakVurulanlar.Remove(ucakVurulan);
                    break;
                }

            }


            foreach (Roket roket in UcakSavar.Roketler)
            {
                if (roket.Resim.Location.Y < 0)
                {
                    UcakSavar.Roketler.Remove(roket);
                    this.container.Controls.Remove(roket.Resim);
                    break;
                }
            }




        }

        Random rnd = new Random();

        private void Ucak_Uretim_Tick(object sender, System.EventArgs e)
        {
            Point konum = new Point(rnd.Next(20, container.Width - 70), 10);

            Ucak ucak = new Ucak(konum, this.container);
            Ucak ucakVurulan = new Ucak(konum, this.container);

            Ucaklar.Add(ucak);
            ucakVurulan.Resim.Image = Properties.Resources.yanma;
            UcakVurulanlar.Add(ucakVurulan);
        }

        private void Roket_Hareket_Tick(object sender, System.EventArgs e)
        {
            foreach (Roket item in UcakSavar.Roketler)
            {
                item.HarekeEt(Yonler.yukari);
            }

        }


        private void Ucak_Hareket_Tick(object sender, System.EventArgs e)
        {
            foreach (Ucak item in Ucaklar)
            {
                item.HarekeEt(Yonler.asagi);
            }
            foreach (Ucak item in UcakVurulanlar)
            {
                item.HarekeEt(Yonler.asagi);
            }

        }



    }
}
