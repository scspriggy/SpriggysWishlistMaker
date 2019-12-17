using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Spriggys_DIM_Wishlist_Maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadSettings();
        }

        private void loadSettings()
        {
            string rollInput = Properties.Settings.Default.RollInput;
            int location = this.textBoxSettings_RollInput.FindStringExact(rollInput);

            this.textBoxSettings_RollInput.SelectedIndex = location;
            if (Properties.Settings.Default.RollInput == "Text")
            {
                changeInputToText();
            }

            this.checkBoxSettings_IncludeRating.Checked = Properties.Settings.Default.NoteRatings;
            this.checkBoxSettings_IncludeNameRating.Checked = Properties.Settings.Default.NameRating;
            this.checkBoxSettings_IncludeMasterwork.Checked = Properties.Settings.Default.NoteMasterwork;
            this.checkBoxSettings_IncludeRollInfo.Checked = Properties.Settings.Default.CommentedRollInfo;
            this.checkBoxSettings_IncludeCharacterSeparator.Checked = Properties.Settings.Default.LetterSeparator;
            this.textBoxSettings_MinRating.Text = Properties.Settings.Default.MinRating.ToString();

            populateSampleOutput();
        }


        private void changeInputToText()
        {
            textBoxMain_Weapon.Visible = true;
            comboBoxMain_Weapon.Visible = false;
        }

        private void populateSampleOutput()
        {
            string s = "";

            if (this.checkBoxSettings_IncludeCharacterSeparator.Checked)
            {
                s += "///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////" + Environment.NewLine;
                s += "//=======================================================================S=====================================================================" + Environment.NewLine;
                s += "///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////" + Environment.NewLine + Environment.NewLine;
            }

            if(this.checkBoxSettings_IncludeNameRating.Checked)
            {
                s += "//Spriggy's Gjallarhorn - S" + Environment.NewLine;
            }
            else
            {
                s += "//Spriggy's Gjallarhorn" + Environment.NewLine; ;
            }

            if(this.checkBoxSettings_IncludeRollInfo.Checked)
            {
                s += "//=================PvE=================" + Environment.NewLine;
                s += "//Barrel" + Environment.NewLine;
                s += "//2.0:1478423395:Volatile Launch" + Environment.NewLine;
                s += "//1.5:1441682018:Linear Compensator" + Environment.NewLine;
                s += "//Magazine" + Environment.NewLine;
                s += "//2.0:2822142346:High-Velocity Rounds" + Environment.NewLine;
                s += "//1.5:1996142143:Black Powder" + Environment.NewLine;
                s += "//1.0:2985827016:Alloy Casing" + Environment.NewLine;
                s += "//Perk 1" + Environment.NewLine;
                s += "//3.0:3977735242:Tracking Module" + Environment.NewLine;
                s += "//0.5:3300816228:Auto-Loading Holster" + Environment.NewLine;
                s += "//Perk 2" + Environment.NewLine;
                s += "//3.0:1275731761:Cluster Bomb" + Environment.NewLine;
                s += "//1.0:3096702027:Genesis" + Environment.NewLine;
                s += "//0.5:1015611457:Kill Clip" + Environment.NewLine;
                s += "//MW Reload" + Environment.NewLine;
                s += "//=================PvP=================" + Environment.NewLine;
                s += "//Barrel" + Environment.NewLine;
                s += "//2.0:1478423395:Volatile Launch" + Environment.NewLine;
                s += "//1.5:1441682018:Linear Compensator" + Environment.NewLine;
                s += "//Magazine" + Environment.NewLine;
                s += "//2.0:2822142346:High-Velocity Rounds" + Environment.NewLine;
                s += "//1.5:1996142143:Black Powder" + Environment.NewLine;
                s += "//1.0:2985827016:Alloy Casing" + Environment.NewLine;
                s += "//Perk 1" + Environment.NewLine;
                s += "//3.0:3977735242:Tracking Module" + Environment.NewLine;
                s += "//0.5:957782887:Snapshot Sights" + Environment.NewLine;
                s += "//Perk 2" + Environment.NewLine;
                s += "//3.0:1275731761:Cluster Bomb" + Environment.NewLine;
                s += "//0.5:706527188:Quickdraw" + Environment.NewLine;
                s += "//MW Blast Radius" + Environment.NewLine;
            }

            s += "//=================Wishlist=================" + Environment.NewLine;


            s += "dimwishlist:item=991314988&perks=1478423395,2822142346,3977735242,1275731761#notes:" + getSampleWishlistNotes("pve10", "pvp10");
            s += "dimwishlist:item=991314988&perks=1478423395,2822142346,3977735242,3096702027#notes:" + getSampleWishlistNotes("pve8", "pvp7");
            s += "dimwishlist:item=991314988&perks=1478423395,2822142346,3977735242,1015611457#notes:" + getSampleWishlistNotes("pve7.5", "pvp7");
            s += "dimwishlist:item=991314988&perks=1478423395,2822142346,3977735242,706527188#notes:" + getSampleWishlistNotes("pve7", "pvp7.5");
            s += "dimwishlist:item=991314988&perks=1478423395,2822142346,3977735242#notes:" + getSampleWishlistNotes("pve7", "pvp7");
            s += "dimwishlist:item=991314988&perks=1478423395,1996142143,1275731761#notes:" + getSampleWishlistNotes("pve6.5", null);
            s += "...";
            this.textBoxSettings_SampleOutput.Text = s;
        }

        private string getSampleWishlistNotes(string pve, string pvp)
        {
            string s = "";
            if (this.checkBoxSettings_IncludeRating.Checked)
            {
                s += "S" + pve;

                if( pvp != null)
                    s += ", S" + pvp;
            }
            else
            {
                s += pve;
                if (pvp != null)
                    s += ", " + pvp;
            }

            if(this.checkBoxSettings_IncludeMasterwork.Checked)
            {
                if (pvp != null)
                    s += " MWpve Reload, MWpvp Blast Radius";
                else
                    s += " MW Reload";
            }

            s += Environment.NewLine;

            return s;
        }

        private void comboBoxInputType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkedListBoxSettings_NoteOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelMain_WeaponID_Click(object sender, EventArgs e)
        {
            if (comboBoxMain_Weapon.Visible == true)
            {
                textBoxMain_Weapon.Visible = true;
                comboBoxMain_Weapon.Visible = false;
            }
            else
            {
                comboBoxMain_Weapon.Visible = true;
                textBoxMain_Weapon.Visible = false;
            }
        }

        private void textBoxSettings_OutputFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSettings_Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.RollInput = this.textBoxSettings_RollInput.Text;
            Properties.Settings.Default.NoteRatings = this.checkBoxSettings_IncludeRating.Checked;
            Properties.Settings.Default.NameRating = this.checkBoxSettings_IncludeNameRating.Checked;
            Properties.Settings.Default.NoteMasterwork = this.checkBoxSettings_IncludeMasterwork.Checked;
            Properties.Settings.Default.CommentedRollInfo = this.checkBoxSettings_IncludeRollInfo.Checked;
            Properties.Settings.Default.LetterSeparator = this.checkBoxSettings_IncludeCharacterSeparator.Checked;
            Properties.Settings.Default.MinRating = float.Parse(this.textBoxSettings_MinRating.Text);

            Properties.Settings.Default.Save();
        }

        private void buttonGenerateText_Click(object sender, EventArgs e)
        {
            WishlistDoc doc = new WishlistDoc(textBoxRollInput.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
            textBoxRollInput.Text = doc.getOutput();
        }

        private void checkBoxSettings_IncludeRollInfo_CheckedChanged(object sender, EventArgs e)
        {
            populateSampleOutput();
        }

        private void checkBoxSettings_IncludeRating_CheckedChanged(object sender, EventArgs e)
        {
            populateSampleOutput();
        }

        private void checkBoxSettings_IncludeNameRating_CheckedChanged(object sender, EventArgs e)
        {
            populateSampleOutput();
        }

        private void checkBoxSettings_IncludeMasterwork_CheckedChanged(object sender, EventArgs e)
        {
            populateSampleOutput();
        }

        private void checkBoxSettings_IncludeCharacterSeparator_CheckedChanged(object sender, EventArgs e)
        {
            populateSampleOutput();
        }
    }
}
