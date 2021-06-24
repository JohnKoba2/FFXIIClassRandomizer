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
    public partial class Form1 : Form
    {
        Form2 form2;

        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(this.ckUni, "If checked, cannot generate duplicate jobs.");
            toolTip1.SetToolTip(this.ckAssChara, "If checked, selects which characters you use for the run.");
            toolTip1.SetToolTip(this.ckLockEq, "If checked, tells you which classes equipment you MUST use. Cannot be used with Weapon lock!");
            toolTip1.SetToolTip(this.ckWeap, "If checked, tells you which Weapon you MUST use. Cannot be used with Equipment lock!");


            form2 = new Form2();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //clears the screen then checks which parameters to randomize. After they've been randomized enables the use of the streamer button.
            Clear();
            if (ckAssChara.Checked == true){Character();}
            if (ckUni.Checked == true){UniqueJobs();}
            else { Jobs(); }
            if (ckLockEq.Checked == true) { Equipment(); }
            if (ckWeap.Checked == true) { Equipment(); }
            bnStreamer.Enabled = true;
        }

        private void bnStreamer_Click(object sender, EventArgs e)
        {
            //creates a small window for the user to capture when streaming the randomizer without taking up too much screenspace
            //passes in all roll information and displays it on Form2
            RandomizerInfo info = new RandomizerInfo();
            info.Character1 = new Character(lbChara1.Text, lbMain1.Text, lbSub1.Text, lbEq1.Text);
            info.Character2 = new Character(lbChara2.Text, lbMain2.Text, lbSub2.Text, lbEq2.Text);
            info.Character3 = new Character(lbChara3.Text, lbMain3.Text, lbSub3.Text, lbEq3.Text);

            form2.Update(info);
            form2.ShowDialog();
        }

        private void Clear()
        {
            //Clears the input boxes between rolls to prevent rolls from being carried over in the case that that box isn't used in the next roll.
            lbChara1.Text= "";
            lbChara2.Text = "";
            lbChara3.Text = "";
            lbEq3.Text = "N/A";
            lbEq2.Text = "N/A";
            lbEq1.Text = "N/A";
            pxChara1.BackgroundImage = null;
            pxChara2.BackgroundImage = null;
            pxChara3.BackgroundImage = null;
        }

        private void Character()
        {
            //Randomize the characters used for the run, provides the name and picture of each character.
            int player, temp1 = 0, temp2 = 0, temp3 = 0;
            Random r = new Random();

            string[] arr = new[] { "Vaan", "Penelo", "Fran", "Balthier", "Ashe", "Basch" };
            
            player = r.Next(arr.Length);
            temp1 = player;
            while (player == temp1) { player = r.Next(arr.Length); }
            temp2 = player;
            while (player == temp1 || player == temp2) { player = r.Next(arr.Length); }
            temp3 = player;

            lbChara1.Text = arr[temp1];
            lbChara2.Text = arr[temp2];
            lbChara3.Text = arr[temp3];
            pxChara1.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[temp1]);
            pxChara2.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[temp2]);
            pxChara3.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[temp3]);
        }
        private void UniqueJobs()
        {
            //Randomize and supplies a main and secondary job for each character, ensures jobs are only used once
            int player, temp1 = 0, temp2 = 0, temp3 = 0, sub1 = 0, sub2 = 0, sub3 = 0;
            Random r = new Random();

            string[] arr = new[] { "Monk", "White Mage", "Black Mage", "Red Battlemage", "Shikari", "Uhlan", "Time Battlemage", "Bushi", "Archer", "Machinist", "FoeBreaker", "Knight" };

            player = r.Next(arr.Length);
            temp1 = player;
            player = r.Next(arr.Length);
            while (player == temp1) { player = r.Next(arr.Length); }
            temp2 = player;
            player = r.Next(arr.Length);
            while (player == temp1 || player == temp2) { player = r.Next(arr.Length); }
            temp3 = player;
            player = r.Next(arr.Length);
            while (player == temp1 || player == temp2 || player == temp3) { player = r.Next(arr.Length); }
            sub1 = player;
            player = r.Next(arr.Length);
            while (player == temp1 || player == temp2 || player == temp3 || player == sub1) { player = r.Next(arr.Length); }
            sub2 = player;
            player = r.Next(arr.Length);
            while (player == temp1 || player == temp2 || player == temp3 || player == sub1 || player == sub2) { player = r.Next(arr.Length); }
            sub3 = player;

            
            lbMain1.Text = arr[temp1];
            lbMain2.Text = arr[temp2];
            lbMain3.Text = arr[temp3];
            lbSub1.Text = arr[sub1];
            lbSub2.Text = arr[sub2];
            lbSub3.Text = arr[sub3];
            pxMain1.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[temp1].Replace(" ", "_"));
            pxMain2.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[temp2].Replace(" ", "_"));
            pxMain3.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[temp3].Replace(" ", "_"));
            pxSub1.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[sub1].Replace(" ", "_"));
            pxSub2.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[sub2].Replace(" ", "_"));
            pxSub3.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[sub3].Replace(" ", "_"));
        }
        private void Jobs()
        {
            //Randomize and supplies a main and secondary job for each character, can have duplicate jobs
            int player =0, temp1 = -1, temp2 = -1, temp3 = -1,sub1= -1, sub2 = -1, sub3 = -1;
            Random r = new Random();

            string[] arr = new[] { "Monk", "White Mage", "Black Mage", "Red Battlemage", "Shikari", "Uhlan", "Time Battlemage", "Bushi", "Archer", "Machinist", "FoeBreaker", "Knight" };

            player = r.Next(arr.Length);
            temp1 = player;
            while (player == temp1)
            {
                player = r.Next(arr.Length);
            }
            sub1 = player;
            
            player = r.Next(arr.Length);
            temp2 = player;
            while (player == temp2)
            {
                player = r.Next(arr.Length);
            }
            sub2 = player;
            player = r.Next(arr.Length);
            temp3 = player;
            while (player == temp3)
            {
                player = r.Next(arr.Length);
            }
            sub3 = player;


            lbMain1.Text = arr[temp1];
            lbMain2.Text = arr[temp2];
            lbMain3.Text = arr[temp3];
            lbSub1.Text = arr[sub1];
            lbSub2.Text = arr[sub2];
            lbSub3.Text = arr[sub3];
            pxMain1.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[temp1].Replace(" ", "_"));
            pxMain2.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[temp2].Replace(" ", "_"));
            pxMain3.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[temp3].Replace(" ", "_"));
            pxSub1.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[sub1].Replace(" ", "_"));
            pxSub2.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[sub2].Replace(" ", "_"));
            pxSub3.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject(arr[sub3].Replace(" ", "_"));
        }
        private void Equipment()
        {
            //if chosen provides a lock on which equipment cane be used, either the first or second jobs.
            int temp, main1 =-1, main2 =-1, main3 =-1;
            Random r = new Random();

            string[] arr = new[] { "Monk", "White Mage", "Black Mage", "Red Battlemage", "Shikari", "Uhlan", "Time Battlemage", "Bushi", "Archer", "Machinist", "FoeBreaker", "Knight" };

            temp = r.Next(1, 3);
            if (temp == 1) { lbEq1.Text = lbMain1.Text; }
            else lbEq1.Text = lbSub1.Text;


            temp = r.Next(1, 3);
            if (temp == 1) { lbEq2.Text = lbMain2.Text; }
            else lbEq2.Text = lbSub2.Text;


            temp = r.Next(1, 3);
            if (temp == 1) { lbEq3.Text = lbMain3.Text; }
            else lbEq3.Text = lbSub3.Text;

            if (ckWeap.Checked == true) //currently a mess, but works. Choosing lock weapon will force you to only use the weapon stated.
            {
                temp = r.Next(1, 3);
                if (lbEq1.Text == arr[0] )
                {
                    if (temp == 1) { lbEq1.Text = "Unarmed"; }
                    else lbEq1.Text = "Poles";
                }

                if (lbEq1.Text == arr[1])
                {
                    lbEq1.Text = "Rods";
                }

                if (lbEq1.Text == arr[2])
                {
                    lbEq1.Text = "Staves";
                }
                
                if (lbEq1.Text == arr[3])
                {
                    lbEq1.Text = "Maces";
                }

                if (lbEq1.Text == arr[4])
                {
                    if (temp == 1) { lbEq1.Text = "Daggers"; }
                    else lbEq1.Text = "Ninja Swords";
                }

                if (lbEq1.Text == arr[5])
                {
                    lbEq1.Text = "Spears";
                }

                if (lbEq1.Text == arr[6])
                {
                    lbEq1.Text = "Crossbows";
                }

                if (lbEq1.Text == arr[7])
                {
                    lbEq1.Text = "Katana";
                }

                if (lbEq1.Text == arr[8])
                {
                    lbEq1.Text = "Bows";
                }

                if (lbEq1.Text == arr[9])
                {
                    if (temp == 1) { lbEq1.Text = "Guns"; }
                    else lbEq1.Text = "Measures";
                }

                if (lbEq1.Text == arr[10])
                {
                    if (temp == 1) { lbEq1.Text = "Axes & Hammers"; }
                    else lbEq1.Text = "Hand-bombs";
                }

                if (lbEq1.Text == arr[11])
                {
                    if (temp == 1) { lbEq1.Text = "Swords"; }
                    else lbEq1.Text = "Greatswords";
                }

                temp = r.Next(1, 3);
                if (lbEq2.Text == arr[0])
                {
                    if (temp == 1) { lbEq2.Text = "Unarmed"; }
                    else lbEq2.Text = "Poles";
                }

                if (lbEq2.Text == arr[1])
                {
                    lbEq2.Text = "Rods";
                }

                if (lbEq2.Text == arr[2])
                {
                    lbEq2.Text = "Staves";
                }

                if (lbEq2.Text == arr[3])
                {
                    lbEq2.Text = "Maces";
                }

                if (lbEq2.Text == arr[4])
                {
                    if (temp == 1) { lbEq2.Text = "Daggers"; }
                    else lbEq2.Text = "Ninja Swords";
                }

                if (lbEq2.Text == arr[5])
                {
                    lbEq2.Text = "Spears";
                }

                if (lbEq2.Text == arr[6])
                {
                    lbEq2.Text = "Crossbows";
                }

                if (lbEq2.Text == arr[7])
                {
                    lbEq2.Text = "Katana";
                }

                if (lbEq2.Text == arr[8])
                {
                    lbEq2.Text = "Bows";
                }

                if (lbEq2.Text == arr[9])
                {
                    if (temp == 1) { lbEq2.Text = "Guns"; }
                    else lbEq2.Text = "Measures";
                }

                if (lbEq2.Text == arr[10])
                {
                    if (temp == 1) { lbEq2.Text = "Axes & Hammers"; }
                    else lbEq2.Text = "Hand-bombs";
                }

                if (lbEq2.Text == arr[11])
                {
                    if (temp == 1) { lbEq2.Text = "Swords"; }
                    else lbEq2.Text = "Greatswords";
                }

                temp = r.Next(1, 3);
                if (lbEq3.Text == arr[0])
                {
                    if (temp == 1) { lbEq3.Text = "Unarmed"; }
                    else lbEq3.Text = "Poles";
                }

                if (lbEq3.Text == arr[1])
                {
                    lbEq3.Text = "Rods";
                }

                if (lbEq3.Text == arr[2])
                {
                    lbEq3.Text = "Staves";
                }

                if (lbEq3.Text == arr[3])
                {
                    lbEq3.Text = "Maces";
                }

                if (lbEq3.Text == arr[4])
                {
                    if (temp == 1) { lbEq3.Text = "Daggers"; }
                    else lbEq3.Text = "Ninja Swords";
                }

                if (lbEq3.Text == arr[5])
                {
                    lbEq3.Text = "Spears";
                }

                if (lbEq3.Text == arr[6])
                {
                    lbEq3.Text = "Crossbows";
                }

                if (lbEq3.Text == arr[7])
                {
                    lbEq3.Text = "Katana";
                }

                if (lbEq3.Text == arr[8])
                {
                    lbEq3.Text = "Bows";
                }

                if (lbEq3.Text == arr[9])
                {
                    if (temp == 1) { lbEq3.Text = "Guns"; }
                    else lbEq3.Text = "Measures";
                }

                if (lbEq3.Text == arr[10])
                {
                    if (temp == 1) { lbEq3.Text = "Axes & Hammers"; }
                    else lbEq3.Text = "Hand-bombs";
                }

                if (lbEq3.Text == arr[11])
                {
                    if (temp == 1) { lbEq3.Text = "Swords"; }
                    else lbEq3.Text = "Greatswords";
                }

            }
        }


    }

    
    
}
