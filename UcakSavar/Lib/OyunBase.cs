using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcakSavar.Lib
{
    public abstract class OyunBase
    {
        private readonly ContainerControl container;
        public PictureBox Resim { get; set; } = new PictureBox();
        public ContainerControl Container { get; set; }


        public OyunBase(ContainerControl container)
        {
            this.container = container;
            this.Container = container;

        }

    }
}
