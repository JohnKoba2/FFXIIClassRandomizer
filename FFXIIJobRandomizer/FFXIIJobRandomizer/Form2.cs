using FFXIIJobRandomizer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXIIJobRandomizer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        public void Update(RandomizerInfo info)
        {
            lbName1.Text = info.Character1.Name;
            lbMain1.Text = info.Character1.Main;
            lbSub1.Text = info.Character1.Sub;
            lbEq1.Text = info.Character1.Equipment;
            pxChara1.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(info.Character1.Name + "Sprite");
            lbName2.Text = info.Character2.Name;
            lbMain2.Text = info.Character2.Main;
            lbSub2.Text = info.Character2.Sub;
            lbEq2.Text = info.Character2.Equipment;
            pxChara2.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(info.Character2.Name + "Sprite");
            lbName3.Text = info.Character3.Name;
            lbMain3.Text = info.Character3.Main;
            lbSub3.Text = info.Character3.Sub;
            lbEq3.Text = info.Character3.Equipment;
            pxChara3.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(info.Character3.Name + "Sprite");
        }
    }
}
