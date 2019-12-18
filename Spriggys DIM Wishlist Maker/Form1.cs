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

            string gameType = Properties.Settings.Default.GameType;
            location = this.comboBoxSettings_GameType.FindStringExact(gameType);
            this.comboBoxSettings_GameType.SelectedIndex = location;

            this.comboBoxMain_GameType.SelectedIndex = location;
            

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
            Properties.Settings.Default.GameType = this.comboBoxSettings_GameType.Text;
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
            WishlistDoc doc = new WishlistDoc(textBoxRollInput.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None));
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

        private void buttonMain_Submit_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("TabPageText");
            List<string> roll = new List<string>();

            string tier = "U";
            if (comboBoxMain_WeaponTier.Text != "")
                tier = comboBoxMain_WeaponTier.Text;
            roll.Add("//Weapon Name - " + tier); //TODO: Weapon Name Lookup

            if(comboBoxMain_GameType.Text == "PvP Only")
            {
                roll.Add("//=================PvP=================");

                roll.Add("//Barrel");
                populateRolls(roll, 1, "pvp");

                roll.Add("//Magazine");
                populateRolls(roll, 2, "pvp");

                roll.Add("//Perk 1");
                populateRolls(roll, 3, "pvp");

                roll.Add("//Perk 2");
                populateRolls(roll, 4, "pvp");

                populateRolls(roll, 5, "pvp");
                populateRolls(roll, 6, "pvp");
            }
            else 
            {
                if (comboBoxMain_GameType.Text == "PvE/PvP")
                    roll.Add("//=================PvE/PvP=================");
                else
                    roll.Add("//=================PvE=================");

                roll.Add("//Barrel");
                populateRolls(roll, 1, "pve");

                roll.Add("//Magazine");
                populateRolls(roll, 2, "pve");

                roll.Add("//Perk 1");
                populateRolls(roll, 3, "pve");

                roll.Add("//Perk 2");
                populateRolls(roll, 4, "pve");

                populateRolls(roll, 5, "pve");
                populateRolls(roll, 6, "pve");

                if (comboBoxMain_GameType.Text == "Both")
                {
                    roll.Add("//=================PvP=================");

                    roll.Add("//Barrel");
                    populateRolls(roll, 1, "pvp");

                    roll.Add("//Magazine");
                    populateRolls(roll, 2, "pvp");

                    roll.Add("//Perk 1");
                    populateRolls(roll, 3, "pvp");

                    roll.Add("//Perk 2");
                    populateRolls(roll, 4, "pvp");

                    populateRolls(roll, 5, "pvp");
                    populateRolls(roll, 6, "pvp");
                }
            }

            WishlistItem w = new WishlistItem(roll.ToArray(), Convert.ToInt64(textBoxMain_Weapon.Text));
            textBoxRollInput.Text = w.toString();
        }

        private void populateRolls(List<string> roll, int perkNum, string type)
        {
            if (perkNum == 1) //Barrel
            {
                if( type == "pvp")
                {
                    //TODO: Barrel Lookup
                    if (textBoxMain_Barrel1id.Text != "" && textBoxMain_Barrel1pvp.Text != "" && textBoxMain_Barrel1pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel1pvp.Text + ":" + textBoxMain_Barrel1id.Text + ":Unknown");
                    if (textBoxMain_Barrel2id.Text != "" && textBoxMain_Barrel2pvp.Text != "" && textBoxMain_Barrel2pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel2pvp.Text + ":" + textBoxMain_Barrel2id.Text + ":Unknown");
                    if (textBoxMain_Barrel3id.Text != "" && textBoxMain_Barrel3pvp.Text != "" && textBoxMain_Barrel3pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel3pvp.Text + ":" + textBoxMain_Barrel3id.Text + ":Unknown");
                    if (textBoxMain_Barrel4id.Text != "" && textBoxMain_Barrel4pvp.Text != "" && textBoxMain_Barrel4pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel4pvp.Text + ":" + textBoxMain_Barrel4id.Text + ":Unknown");
                    if (textBoxMain_Barrel5id.Text != "" && textBoxMain_Barrel5pvp.Text != "" && textBoxMain_Barrel5pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel5pvp.Text + ":" + textBoxMain_Barrel5id.Text + ":Unknown");
                    if (textBoxMain_Barrel6id.Text != "" && textBoxMain_Barrel6pvp.Text != "" && textBoxMain_Barrel6pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel6pvp.Text + ":" + textBoxMain_Barrel6id.Text + ":Unknown");
                    if (textBoxMain_Barrel7id.Text != "" && textBoxMain_Barrel7pvp.Text != "" && textBoxMain_Barrel7pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel7pvp.Text + ":" + textBoxMain_Barrel7id.Text + ":Unknown");
                }
                else
                {
                    if (textBoxMain_Barrel1id.Text != "" && textBoxMain_Barrel1pve.Text != "" && textBoxMain_Barrel1pve.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel1pve.Text + ":" + textBoxMain_Barrel1id.Text + ":Unknown");
                    if (textBoxMain_Barrel2id.Text != "" && textBoxMain_Barrel2pve.Text != "" && textBoxMain_Barrel2pve.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel2pve.Text + ":" + textBoxMain_Barrel2id.Text + ":Unknown");
                    if (textBoxMain_Barrel3id.Text != "" && textBoxMain_Barrel3pve.Text != "" && textBoxMain_Barrel3pve.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel3pve.Text + ":" + textBoxMain_Barrel3id.Text + ":Unknown");
                    if (textBoxMain_Barrel4id.Text != "" && textBoxMain_Barrel4pve.Text != "" && textBoxMain_Barrel4pve.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel4pve.Text + ":" + textBoxMain_Barrel4id.Text + ":Unknown");
                    if (textBoxMain_Barrel5id.Text != "" && textBoxMain_Barrel5pve.Text != "" && textBoxMain_Barrel5pve.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel5pve.Text + ":" + textBoxMain_Barrel5id.Text + ":Unknown");
                    if (textBoxMain_Barrel6id.Text != "" && textBoxMain_Barrel6pve.Text != "" && textBoxMain_Barrel6pve.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel6pve.Text + ":" + textBoxMain_Barrel6id.Text + ":Unknown");
                    if (textBoxMain_Barrel7id.Text != "" && textBoxMain_Barrel7pve.Text != "" && textBoxMain_Barrel7pve.Text != "0")
                        roll.Add("//" + textBoxMain_Barrel7pve.Text + ":" + textBoxMain_Barrel7id.Text + ":Unknown");
                }
            }
            else if (perkNum == 2) //Magazine
            {
                if (type == "pvp")
                {
                    if (textBoxMain_Mag1id.Text != "" && textBoxMain_Mag1pvp.Text != "" && textBoxMain_Mag1pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Mag1pvp.Text + ":" + textBoxMain_Mag1id.Text + ":Unknown");
                    if (textBoxMain_Mag2id.Text != "" && textBoxMain_Mag2pvp.Text != "" && textBoxMain_Mag2pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Mag2pvp.Text + ":" + textBoxMain_Mag2id.Text + ":Unknown");
                    if (textBoxMain_Mag3id.Text != "" && textBoxMain_Mag3pvp.Text != "" && textBoxMain_Mag3pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Mag3pvp.Text + ":" + textBoxMain_Mag3id.Text + ":Unknown");
                    if (textBoxMain_Mag4id.Text != "" && textBoxMain_Mag4pvp.Text != "" && textBoxMain_Mag4pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Mag4pvp.Text + ":" + textBoxMain_Mag4id.Text + ":Unknown");
                    if (textBoxMain_Mag5id.Text != "" && textBoxMain_Mag5pvp.Text != "" && textBoxMain_Mag5pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Mag5pvp.Text + ":" + textBoxMain_Mag5id.Text + ":Unknown");
                    if (textBoxMain_Mag6id.Text != "" && textBoxMain_Mag6pvp.Text != "" && textBoxMain_Mag6pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Mag6pvp.Text + ":" + textBoxMain_Mag6id.Text + ":Unknown");
                    if (textBoxMain_Mag7id.Text != "" && textBoxMain_Mag7pvp.Text != "" && textBoxMain_Mag7pvp.Text != "0")
                        roll.Add("//" + textBoxMain_Mag7pvp.Text + ":" + textBoxMain_Mag7id.Text + ":Unknown");
                }
                else
                {
                    if (textBoxMain_Mag1id.Text != "" && textBoxMain_Mag1pve.Text != "" && textBoxMain_Mag1pve.Text != "0")
                        roll.Add("//" + textBoxMain_Mag1pve.Text + ":" + textBoxMain_Mag1id.Text + ":Unknown");
                    if (textBoxMain_Mag2id.Text != "" && textBoxMain_Mag2pve.Text != "" && textBoxMain_Mag2pve.Text != "0")
                        roll.Add("//" + textBoxMain_Mag2pve.Text + ":" + textBoxMain_Mag2id.Text + ":Unknown");
                    if (textBoxMain_Mag3id.Text != "" && textBoxMain_Mag3pve.Text != "" && textBoxMain_Mag3pve.Text != "0")
                        roll.Add("//" + textBoxMain_Mag3pve.Text + ":" + textBoxMain_Mag3id.Text + ":Unknown");
                    if (textBoxMain_Mag4id.Text != "" && textBoxMain_Mag4pve.Text != "" && textBoxMain_Mag4pve.Text != "0")
                        roll.Add("//" + textBoxMain_Mag4pve.Text + ":" + textBoxMain_Mag4id.Text + ":Unknown");
                    if (textBoxMain_Mag5id.Text != "" && textBoxMain_Mag5pve.Text != "" && textBoxMain_Mag5pve.Text != "0")
                        roll.Add("//" + textBoxMain_Mag5pve.Text + ":" + textBoxMain_Mag5id.Text + ":Unknown");
                    if (textBoxMain_Mag6id.Text != "" && textBoxMain_Mag6pve.Text != "" && textBoxMain_Mag6pve.Text != "0")
                        roll.Add("//" + textBoxMain_Mag6pve.Text + ":" + textBoxMain_Mag6id.Text + ":Unknown");
                    if (textBoxMain_Mag7id.Text != "" && textBoxMain_Mag7pve.Text != "" && textBoxMain_Mag7pve.Text != "0")
                        roll.Add("//" + textBoxMain_Mag7pve.Text + ":" + textBoxMain_Mag7id.Text + ":Unknown");
                }
            }
            else if (perkNum == 3) //Perk 1
            {
                if (type == "pvp")
                {
                    if (textBoxMain_PerkOne1id.Text != "" && textBoxMain_PerkOne1pvp.Text != "" && textBoxMain_PerkOne1pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne1pvp.Text + ":" + textBoxMain_PerkOne1id.Text + ":Unknown");
                    if (textBoxMain_PerkOne2id.Text != "" && textBoxMain_PerkOne2pvp.Text != "" && textBoxMain_PerkOne2pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne2pvp.Text + ":" + textBoxMain_PerkOne2id.Text + ":Unknown");
                    if (textBoxMain_PerkOne3id.Text != "" && textBoxMain_PerkOne3pvp.Text != "" && textBoxMain_PerkOne3pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne3pvp.Text + ":" + textBoxMain_PerkOne3id.Text + ":Unknown");
                    if (textBoxMain_PerkOne4id.Text != "" && textBoxMain_PerkOne4pvp.Text != "" && textBoxMain_PerkOne4pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne4pvp.Text + ":" + textBoxMain_PerkOne4id.Text + ":Unknown");
                    if (textBoxMain_PerkOne5id.Text != "" && textBoxMain_PerkOne5pvp.Text != "" && textBoxMain_PerkOne5pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne5pvp.Text + ":" + textBoxMain_PerkOne5id.Text + ":Unknown");
                    if (textBoxMain_PerkOne6id.Text != "" && textBoxMain_PerkOne6pvp.Text != "" && textBoxMain_PerkOne6pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne6pvp.Text + ":" + textBoxMain_PerkOne6id.Text + ":Unknown");
                    if (textBoxMain_PerkOne7id.Text != "" && textBoxMain_PerkOne7pvp.Text != "" && textBoxMain_PerkOne7pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne7pvp.Text + ":" + textBoxMain_PerkOne7id.Text + ":Unknown");
                }
                else
                {
                    if (textBoxMain_PerkOne1id.Text != "" && textBoxMain_PerkOne1pve.Text != "" && textBoxMain_PerkOne1pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne1pve.Text + ":" + textBoxMain_PerkOne1id.Text + ":Unknown");
                    if (textBoxMain_PerkOne2id.Text != "" && textBoxMain_PerkOne2pve.Text != "" && textBoxMain_PerkOne2pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne2pve.Text + ":" + textBoxMain_PerkOne2id.Text + ":Unknown");
                    if (textBoxMain_PerkOne3id.Text != "" && textBoxMain_PerkOne3pve.Text != "" && textBoxMain_PerkOne3pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne3pve.Text + ":" + textBoxMain_PerkOne3id.Text + ":Unknown");
                    if (textBoxMain_PerkOne4id.Text != "" && textBoxMain_PerkOne4pve.Text != "" && textBoxMain_PerkOne4pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne4pve.Text + ":" + textBoxMain_PerkOne4id.Text + ":Unknown");
                    if (textBoxMain_PerkOne5id.Text != "" && textBoxMain_PerkOne5pve.Text != "" && textBoxMain_PerkOne5pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne5pve.Text + ":" + textBoxMain_PerkOne5id.Text + ":Unknown");
                    if (textBoxMain_PerkOne6id.Text != "" && textBoxMain_PerkOne6pve.Text != "" && textBoxMain_PerkOne6pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne6pve.Text + ":" + textBoxMain_PerkOne6id.Text + ":Unknown");
                    if (textBoxMain_PerkOne7id.Text != "" && textBoxMain_PerkOne7pve.Text != "" && textBoxMain_PerkOne7pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkOne7pve.Text + ":" + textBoxMain_PerkOne7id.Text + ":Unknown");
                }
            }
            else if (perkNum == 4) //Perk 2
            {
                if (type == "pvp")
                {
                    if (textBoxMain_PerkTwo1id.Text != "" && textBoxMain_PerkTwo1pvp.Text != "" && textBoxMain_PerkTwo1pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo1pvp.Text + ":" + textBoxMain_PerkTwo1id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo2id.Text != "" && textBoxMain_PerkTwo2pvp.Text != "" && textBoxMain_PerkTwo2pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo2pvp.Text + ":" + textBoxMain_PerkTwo2id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo3id.Text != "" && textBoxMain_PerkTwo3pvp.Text != "" && textBoxMain_PerkTwo3pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo3pvp.Text + ":" + textBoxMain_PerkTwo3id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo4id.Text != "" && textBoxMain_PerkTwo4pvp.Text != "" && textBoxMain_PerkTwo4pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo4pvp.Text + ":" + textBoxMain_PerkTwo4id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo5id.Text != "" && textBoxMain_PerkTwo5pvp.Text != "" && textBoxMain_PerkTwo5pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo5pvp.Text + ":" + textBoxMain_PerkTwo5id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo6id.Text != "" && textBoxMain_PerkTwo6pvp.Text != "" && textBoxMain_PerkTwo6pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo6pvp.Text + ":" + textBoxMain_PerkTwo6id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo7id.Text != "" && textBoxMain_PerkTwo7pvp.Text != "" && textBoxMain_PerkTwo7pvp.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo7pvp.Text + ":" + textBoxMain_PerkTwo7id.Text + ":Unknown");
                }
                else
                {
                    if (textBoxMain_PerkTwo1id.Text != "" && textBoxMain_PerkTwo1pve.Text != "" && textBoxMain_PerkTwo1pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo1pve.Text + ":" + textBoxMain_PerkTwo1id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo2id.Text != "" && textBoxMain_PerkTwo2pve.Text != "" && textBoxMain_PerkTwo2pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo2pve.Text + ":" + textBoxMain_PerkTwo2id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo3id.Text != "" && textBoxMain_PerkTwo3pve.Text != "" && textBoxMain_PerkTwo3pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo3pve.Text + ":" + textBoxMain_PerkTwo3id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo4id.Text != "" && textBoxMain_PerkTwo4pve.Text != "" && textBoxMain_PerkTwo4pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo4pve.Text + ":" + textBoxMain_PerkTwo4id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo5id.Text != "" && textBoxMain_PerkTwo5pve.Text != "" && textBoxMain_PerkTwo5pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo5pve.Text + ":" + textBoxMain_PerkTwo5id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo6id.Text != "" && textBoxMain_PerkTwo6pve.Text != "" && textBoxMain_PerkTwo6pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo6pve.Text + ":" + textBoxMain_PerkTwo6id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo7id.Text != "" && textBoxMain_PerkTwo7pve.Text != "" && textBoxMain_PerkTwo7pve.Text != "0")
                        roll.Add("//" + textBoxMain_PerkTwo7pve.Text + ":" + textBoxMain_PerkTwo7id.Text + ":Unknown");
                }
            }
            else if (perkNum == 5) //Combos
            {
                if (type == "pvp")
                {
                    //Check if any
                    if ((textBoxMain_Combopvp1.Text != "" && textBoxMain_Combopvp1.Text != "0") || (textBoxMain_Combopvp2.Text != "" && textBoxMain_Combopvp2.Text != "0") || (textBoxMain_Combopvp3.Text != "" && textBoxMain_Combopvp3.Text != "0") || (textBoxMain_Combopvp4.Text != "" && textBoxMain_Combopvp4.Text != "0") || (textBoxMain_Combopvp5.Text != "" && textBoxMain_Combopvp5.Text != "0"))
                    {
                        roll.Add("//Combos");
                    }

                    if (textBoxMain_Combopvp1.Text != "" && textBoxMain_Combopvp1.Text != "0")
                        roll.Add("//" + getValueOrZero(textBoxMain_ComboBarrel1.Text) + "," + getValueOrZero(textBoxMain_ComboMag1.Text) + "," + getValueOrZero(textBoxMain_ComboPerkOne1.Text) + "," + getValueOrZero(textBoxMain_ComboPerkTwo1.Text) + ":" + textBoxMain_Combopvp1.Text);
                    if (textBoxMain_Combopvp2.Text != "" && textBoxMain_Combopvp2.Text != "0")
                        roll.Add("//" + getValueOrZero(textBoxMain_ComboBarrel2.Text) + "," + getValueOrZero(textBoxMain_ComboMag2.Text) + "," + getValueOrZero(textBoxMain_ComboPerkOne2.Text) + "," + getValueOrZero(textBoxMain_ComboPerkTwo2.Text) + ":" + textBoxMain_Combopvp2.Text);
                    if (textBoxMain_Combopvp3.Text != "" && textBoxMain_Combopvp3.Text != "0")
                        roll.Add("//" + getValueOrZero(textBoxMain_ComboBarrel3.Text) + "," + getValueOrZero(textBoxMain_ComboMag3.Text) + "," + getValueOrZero(textBoxMain_ComboPerkOne3.Text) + "," + getValueOrZero(textBoxMain_ComboPerkTwo3.Text) + ":" + textBoxMain_Combopvp3.Text);
                    if (textBoxMain_Combopvp4.Text != "" && textBoxMain_Combopvp4.Text != "0")
                        roll.Add("//" + getValueOrZero(textBoxMain_ComboBarrel4.Text) + "," + getValueOrZero(textBoxMain_ComboMag4.Text) + "," + getValueOrZero(textBoxMain_ComboPerkOne4.Text) + "," + getValueOrZero(textBoxMain_ComboPerkTwo4.Text) + ":" + textBoxMain_Combopvp4.Text);
                    if (textBoxMain_Combopvp5.Text != "" && textBoxMain_Combopvp5.Text != "0")
                        roll.Add("//" + getValueOrZero(textBoxMain_ComboBarrel5.Text) + "," + getValueOrZero(textBoxMain_ComboMag5.Text) + "," + getValueOrZero(textBoxMain_ComboPerkOne5.Text) + "," + getValueOrZero(textBoxMain_ComboPerkTwo5.Text) + ":" + textBoxMain_Combopvp5.Text);
                }
                else
                {
                    //Check if any
                    if ((textBoxMain_Combopve1.Text != "" && textBoxMain_Combopve1.Text != "0") || (textBoxMain_Combopve2.Text != "" && textBoxMain_Combopve2.Text != "0") || (textBoxMain_Combopve3.Text != "" && textBoxMain_Combopve3.Text != "0") || (textBoxMain_Combopve4.Text != "" && textBoxMain_Combopve4.Text != "0") || (textBoxMain_Combopve5.Text != "" && textBoxMain_Combopve5.Text != "0"))
                    {
                        roll.Add("//Combos");
                    }

                    if (textBoxMain_Combopve1.Text != "" && textBoxMain_Combopve1.Text != "0")
                        roll.Add("//" + getValueOrZero(textBoxMain_ComboBarrel1.Text) + "," + getValueOrZero(textBoxMain_ComboMag1.Text) + "," + getValueOrZero(textBoxMain_ComboPerkOne1.Text) + "," + getValueOrZero(textBoxMain_ComboPerkTwo1.Text) + ":" + textBoxMain_Combopve1.Text);
                    if (textBoxMain_Combopve2.Text != "" && textBoxMain_Combopve2.Text != "0")
                        roll.Add("//" + getValueOrZero(textBoxMain_ComboBarrel2.Text) + "," + getValueOrZero(textBoxMain_ComboMag2.Text) + "," + getValueOrZero(textBoxMain_ComboPerkOne2.Text) + "," + getValueOrZero(textBoxMain_ComboPerkTwo2.Text) + ":" + textBoxMain_Combopve2.Text);
                    if (textBoxMain_Combopve3.Text != "" && textBoxMain_Combopve3.Text != "0")
                        roll.Add("//" + getValueOrZero(textBoxMain_ComboBarrel3.Text) + "," + getValueOrZero(textBoxMain_ComboMag3.Text) + "," + getValueOrZero(textBoxMain_ComboPerkOne3.Text) + "," + getValueOrZero(textBoxMain_ComboPerkTwo3.Text) + ":" + textBoxMain_Combopve3.Text);
                    if (textBoxMain_Combopve4.Text != "" && textBoxMain_Combopve4.Text != "0")
                        roll.Add("//" + getValueOrZero(textBoxMain_ComboBarrel4.Text) + "," + getValueOrZero(textBoxMain_ComboMag4.Text) + "," + getValueOrZero(textBoxMain_ComboPerkOne4.Text) + "," + getValueOrZero(textBoxMain_ComboPerkTwo4.Text) + ":" + textBoxMain_Combopve4.Text);
                    if (textBoxMain_Combopve5.Text != "" && textBoxMain_Combopve5.Text != "0")
                        roll.Add("//" + getValueOrZero(textBoxMain_ComboBarrel5.Text) + "," + getValueOrZero(textBoxMain_ComboMag5.Text) + "," + getValueOrZero(textBoxMain_ComboPerkOne5.Text) + "," + getValueOrZero(textBoxMain_ComboPerkTwo5.Text) + ":" + textBoxMain_Combopve5.Text);
                }
            }
            else if (perkNum == 6) //Masterwork
            {
                if (type == "pvp" && textBoxMain_PvPmw.Text != "")
                {
                    roll.Add("//MW " + textBoxMain_PvPmw.Text);
                }
                else if(textBoxMain_PvEmw.Text != "")
                {
                    roll.Add("//MW " + textBoxMain_PvEmw.Text);
                }
            }
        }

        private string getValueOrZero(string s)
        {
            if (s == null || s == "")
                return "0";
            return s;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
