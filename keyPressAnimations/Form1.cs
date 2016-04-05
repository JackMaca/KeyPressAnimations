/// Object Animation created along with classes for players, bullets, and monsters
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace keyPressAnimations
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            GameMenu gm = new GameMenu();
            this.Controls.Add(gm);
        }

    }

}
