using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcakSavar.Lib
{
    public class Roket:OyunBase,IHareketEdebilirMi
    {

        public Roket(Point point, ContainerControl container) : base(container)
        {
            Resim = new PictureBox()
            {
                Image = Properties.Resources.mermi,
                Size = new Size(28, 36),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = point
            };

            container.Controls.Add(Resim);
            
        }

        public void HarekeEt(Yonler yon)
        {
            if (yon == Yonler.yukari)
            {
                Resim.Location = new Point()
                {
                    X = Resim.Location.X,
                    Y = Resim.Location.Y - 5
                };
            }
            else
            {
                throw new Exception("Roket sadece yukarı hareket edebilir.");
            }
        }
    }
    
}
