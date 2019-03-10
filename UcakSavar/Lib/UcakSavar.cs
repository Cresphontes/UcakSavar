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
    public class UcakSavar : OyunBase, IAtesEdebilirMi, IHareketEdebilirMi
    {

        public List<Roket> Roketler { get; set; } = new List<Roket>();

        public UcakSavar(ContainerControl container) : base(container)
        {
            Resim = new PictureBox()
            {
                Image = Properties.Resources.ucaksavar,
                Size = new Size(83, 83),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point((container.Width / 2) - 40, container.Height - 100)

            };

            container.Controls.Add(Resim);

        }

        public void AtesEt()
        {
            Point konum = new Point(Resim.Location.X + 30, Resim.Location.Y - 5);

            Roket roket = new Roket(konum, this.Container);
            Roketler.Add(roket);
            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.AWP_Ates);
            soundPlayer.Play();


        }

        public void HarekeEt(Yonler yon)
        {


            if (yon == Yonler.sag)
            {
                Resim.Location = new Point()
                {
                    X = Resim.Location.X + 10,
                    Y = Resim.Location.Y
                };

            }
            else if (yon == Yonler.sol)
            {

                Resim.Location = new Point()
                {
                    X = Resim.Location.X - 10,
                    Y = Resim.Location.Y
                };
            }
            else
            {
                throw new Exception("Uçaksavar sağa veya sola hareket edebilir.");
            }
        }
    }
}
