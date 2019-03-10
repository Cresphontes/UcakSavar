using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcakSavar.Lib
{
    public class Ucak:OyunBase,IHareketEdebilirMi
    {



        public Ucak(Point point, ContainerControl container):base(container)
        {
            Resim = new PictureBox()
            {
                Image = Properties.Resources.ucak,
                Size = new Size(52,44),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = point
            };


            container.Controls.Add(Resim);

        }

        public void HarekeEt(Yonler yon)
        {
            if(yon == Yonler.asagi)
            {
                Resim.Location = new Point()
                {
                    X = Resim.Location.X,
                    Y = Resim.Location.Y + 5
                };
            }
        }
    }
}
