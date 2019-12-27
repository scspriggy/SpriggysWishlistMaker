using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

//TODO: fix issues with other game types printing wrong
//TODO: hide/show based on game type
//TODO: change loadSettings to include either text input or dropdown (default)
//TODO: look up barrel, mag, perk name on text entry (like we're doing for weapon id to name)

namespace Spriggys_DIM_Wishlist_Maker
{
    public partial class Form1 : Form
    {
        private Dictionary<string, long> weaponPairs = new Dictionary<string, long>();
        private Dictionary<string, long> perk1Pairs = new Dictionary<string, long>();
        private Dictionary<string, long> perk2Pairs = new Dictionary<string, long>();
        private Dictionary<string, long> traitPairs = new Dictionary<string, long>();
        bool customDropdowns;

        public Form1()
        {
            InitializeComponent();
            loadDropdowns();
            loadSettings();
        }

        private void loadDropdowns()
        {
            XmlDocument doc = new XmlDocument();
            customDropdowns = false;

            doc.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WeaponCollection.xml");
            XmlNodeList weaponNodes = doc.SelectNodes("weapons/weapon");

            foreach (XmlNode w in weaponNodes)
            {
                string name = w["name"].InnerText;
                if (name != null && name != "")
                {
                    comboBoxMain_Weapon.Items.Add(name);
                    weaponPairs.Add(name, Convert.ToInt64(w["id"].InnerText));
                }
            }

            doc.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Perk1Collection.xml");
            XmlNodeList perkNodes = doc.SelectNodes("perk1/perkGroup/perk");

            comboBoxMain_Barrel1id.Items.Add("");
            comboBoxMain_Barrel2id.Items.Add("");
            comboBoxMain_Barrel3id.Items.Add("");
            comboBoxMain_Barrel4id.Items.Add("");
            comboBoxMain_Barrel5id.Items.Add("");
            comboBoxMain_Barrel6id.Items.Add("");
            comboBoxMain_Barrel7id.Items.Add("");
            comboBoxMain_ComboBarrel1.Items.Add("");
            comboBoxMain_ComboBarrel2.Items.Add("");
            comboBoxMain_ComboBarrel3.Items.Add("");
            comboBoxMain_ComboBarrel4.Items.Add("");
            comboBoxMain_ComboBarrel5.Items.Add("");
            foreach (XmlNode p in perkNodes)
            {
                string name = p["name"].InnerText;
                if (!comboBoxMain_Barrel1id.Items.Contains(name))
                {
                    comboBoxMain_Barrel1id.Items.Add(name);
                    comboBoxMain_Barrel2id.Items.Add(name);
                    comboBoxMain_Barrel3id.Items.Add(name);
                    comboBoxMain_Barrel4id.Items.Add(name);
                    comboBoxMain_Barrel5id.Items.Add(name);
                    comboBoxMain_Barrel6id.Items.Add(name);
                    comboBoxMain_Barrel7id.Items.Add(name);
                    comboBoxMain_ComboBarrel1.Items.Add(name);
                    comboBoxMain_ComboBarrel2.Items.Add(name);
                    comboBoxMain_ComboBarrel3.Items.Add(name);
                    comboBoxMain_ComboBarrel4.Items.Add(name);
                    comboBoxMain_ComboBarrel5.Items.Add(name);
                    perk1Pairs.Add(name, Convert.ToInt64(p["id"].InnerText));
                }
            }

            doc.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Perk2Collection.xml");
            perkNodes = doc.SelectNodes("perk2/perkGroup/perk");

            comboBoxMain_Mag1id.Items.Add("");
            comboBoxMain_Mag2id.Items.Add("");
            comboBoxMain_Mag3id.Items.Add("");
            comboBoxMain_Mag4id.Items.Add("");
            comboBoxMain_Mag5id.Items.Add("");
            comboBoxMain_Mag6id.Items.Add("");
            comboBoxMain_Mag7id.Items.Add("");
            comboBoxMain_ComboMag1.Items.Add("");
            comboBoxMain_ComboMag2.Items.Add("");
            comboBoxMain_ComboMag3.Items.Add("");
            comboBoxMain_ComboMag4.Items.Add("");
            comboBoxMain_ComboMag5.Items.Add("");
            foreach (XmlNode p in perkNodes)
            {
                string name = p["name"].InnerText;
                if (!comboBoxMain_Mag1id.Items.Contains(name))
                {
                    comboBoxMain_Mag1id.Items.Add(name);
                    comboBoxMain_Mag2id.Items.Add(name);
                    comboBoxMain_Mag3id.Items.Add(name);
                    comboBoxMain_Mag4id.Items.Add(name);
                    comboBoxMain_Mag5id.Items.Add(name);
                    comboBoxMain_Mag6id.Items.Add(name);
                    comboBoxMain_Mag7id.Items.Add(name);
                    comboBoxMain_ComboMag1.Items.Add(name);
                    comboBoxMain_ComboMag2.Items.Add(name);
                    comboBoxMain_ComboMag3.Items.Add(name);
                    comboBoxMain_ComboMag4.Items.Add(name);
                    comboBoxMain_ComboMag5.Items.Add(name);
                    perk2Pairs.Add(name, Convert.ToInt64(p["id"].InnerText));
                }
            }

            doc.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\TraitCollection.xml");
            perkNodes = doc.SelectNodes("traits/trait");

            comboBoxMain_PerkOne1id.Items.Add("");
            comboBoxMain_PerkOne2id.Items.Add("");
            comboBoxMain_PerkOne3id.Items.Add("");
            comboBoxMain_PerkOne4id.Items.Add("");
            comboBoxMain_PerkOne5id.Items.Add("");
            comboBoxMain_PerkOne6id.Items.Add("");
            comboBoxMain_PerkOne7id.Items.Add("");
            comboBoxMain_PerkTwo1id.Items.Add("");
            comboBoxMain_PerkTwo2id.Items.Add("");
            comboBoxMain_PerkTwo3id.Items.Add("");
            comboBoxMain_PerkTwo4id.Items.Add("");
            comboBoxMain_PerkTwo5id.Items.Add("");
            comboBoxMain_PerkTwo6id.Items.Add("");
            comboBoxMain_PerkTwo7id.Items.Add("");
            comboBoxMain_ComboPerkOne1.Items.Add("");
            comboBoxMain_ComboPerkOne2.Items.Add("");
            comboBoxMain_ComboPerkOne3.Items.Add("");
            comboBoxMain_ComboPerkOne4.Items.Add("");
            comboBoxMain_ComboPerkOne5.Items.Add("");
            comboBoxMain_ComboPerkTwo1.Items.Add("");
            comboBoxMain_ComboPerkTwo2.Items.Add("");
            comboBoxMain_ComboPerkTwo3.Items.Add("");
            comboBoxMain_ComboPerkTwo4.Items.Add("");
            comboBoxMain_ComboPerkTwo5.Items.Add("");
            foreach (XmlNode p in perkNodes)
            {
                string name = p["name"].InnerText;
                if (!comboBoxMain_PerkOne1id.Items.Contains(name))
                {
                    comboBoxMain_PerkOne1id.Items.Add(name);
                    comboBoxMain_PerkOne2id.Items.Add(name);
                    comboBoxMain_PerkOne3id.Items.Add(name);
                    comboBoxMain_PerkOne4id.Items.Add(name);
                    comboBoxMain_PerkOne5id.Items.Add(name);
                    comboBoxMain_PerkOne6id.Items.Add(name);
                    comboBoxMain_PerkOne7id.Items.Add(name);
                    comboBoxMain_PerkTwo1id.Items.Add(name);
                    comboBoxMain_PerkTwo2id.Items.Add(name);
                    comboBoxMain_PerkTwo3id.Items.Add(name);
                    comboBoxMain_PerkTwo4id.Items.Add(name);
                    comboBoxMain_PerkTwo5id.Items.Add(name);
                    comboBoxMain_PerkTwo6id.Items.Add(name);
                    comboBoxMain_PerkTwo7id.Items.Add(name);
                    comboBoxMain_ComboPerkOne1.Items.Add(name);
                    comboBoxMain_ComboPerkOne2.Items.Add(name);
                    comboBoxMain_ComboPerkOne3.Items.Add(name);
                    comboBoxMain_ComboPerkOne4.Items.Add(name);
                    comboBoxMain_ComboPerkOne5.Items.Add(name);
                    comboBoxMain_ComboPerkTwo1.Items.Add(name);
                    comboBoxMain_ComboPerkTwo2.Items.Add(name);
                    comboBoxMain_ComboPerkTwo3.Items.Add(name);
                    comboBoxMain_ComboPerkTwo4.Items.Add(name);
                    comboBoxMain_ComboPerkTwo5.Items.Add(name);
                    traitPairs.Add(name, Convert.ToInt64(p["id"].InnerText));
                }
            }
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
            //Check valid input
            if( textBoxMain_Weapon.Visible && (textBoxMain_Weapon.Text == null || textBoxMain_Weapon.Text == ""))
            {
                System.Windows.Forms.MessageBox.Show("Please enter a valid weapon id.");
                return;
            }



            List<string> roll = new List<string>();

            string tier = "U";
            if (comboBoxMain_WeaponTier.Text != "")
                tier = comboBoxMain_WeaponTier.Text;

            if( comboBoxMain_Weapon.Visible)
            {
                roll.Add("//" + comboBoxMain_Weapon.Text + " - " + tier);
            }
            else
            {
                string name = "";
                int n;
                if (textBoxMain_WeaponName.Text != null && textBoxMain_WeaponName.Text != "")
                    name = textBoxMain_WeaponName.Text;
                else if (int.TryParse(textBoxMain_Weapon.Text, out n) && weaponPairs.ContainsValue(Convert.ToInt64(textBoxMain_Weapon.Text)))
                    name = weaponPairs.FirstOrDefault(x => x.Value == Convert.ToInt64(textBoxMain_Weapon.Text)).Key;
                else 
                    name = "Unknown";

                roll.Add("//" + name + " - " + tier);
            }
            

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

            tabControl1.SelectTab("TabPageText");
        }

        private void populateRolls(List<string> roll, int perkNum, string type)
        {

            //Text input, combine with dropdowns later
            if (perkNum == 1) //Barrel
            {
                if( type == "pvp")
                {

                    if (textBoxMain_Barrel1id.Visible && textBoxMain_Barrel1id.Text != "" && textBoxMain_Barrel1pvp.Text != "" && textBoxMain_Barrel1pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel1pvp.Text).ToString("0.0") + ":" + textBoxMain_Barrel1id.Text + ":Unknown");
                    if (textBoxMain_Barrel2id.Visible && textBoxMain_Barrel2id.Text != "" && textBoxMain_Barrel2pvp.Text != "" && textBoxMain_Barrel2pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel2pvp.Text).ToString("0.0") + ":" + textBoxMain_Barrel2id.Text + ":Unknown");
                    if (textBoxMain_Barrel3id.Visible && textBoxMain_Barrel3id.Text != "" && textBoxMain_Barrel3pvp.Text != "" && textBoxMain_Barrel3pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel3pvp.Text).ToString("0.0") + ":" + textBoxMain_Barrel3id.Text + ":Unknown");
                    if (textBoxMain_Barrel4id.Visible && textBoxMain_Barrel4id.Text != "" && textBoxMain_Barrel4pvp.Text != "" && textBoxMain_Barrel4pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel4pvp.Text).ToString("0.0") + ":" + textBoxMain_Barrel4id.Text + ":Unknown");
                    if (textBoxMain_Barrel5id.Visible && textBoxMain_Barrel5id.Text != "" && textBoxMain_Barrel5pvp.Text != "" && textBoxMain_Barrel5pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel5pvp.Text).ToString("0.0") + ":" + textBoxMain_Barrel5id.Text + ":Unknown");
                    if (textBoxMain_Barrel6id.Visible && textBoxMain_Barrel6id.Text != "" && textBoxMain_Barrel6pvp.Text != "" && textBoxMain_Barrel6pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel6pvp.Text).ToString("0.0") + ":" + textBoxMain_Barrel6id.Text + ":Unknown");
                    if (textBoxMain_Barrel7id.Visible && textBoxMain_Barrel7id.Text != "" && textBoxMain_Barrel7pvp.Text != "" && textBoxMain_Barrel7pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel7pvp.Text).ToString("0.0") + ":" + textBoxMain_Barrel7id.Text + ":Unknown");

                    if (comboBoxMain_Barrel1id.Visible && comboBoxMain_Barrel1id.Text != "" && textBoxMain_Barrel1pvp.Text != "" && textBoxMain_Barrel1pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel1pvp.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel1id.Text] + ":" + comboBoxMain_Barrel1id.Text);
                    if (comboBoxMain_Barrel2id.Visible && comboBoxMain_Barrel2id.Text != "" && textBoxMain_Barrel2pvp.Text != "" && textBoxMain_Barrel2pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel2pvp.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel2id.Text] + ":" + comboBoxMain_Barrel2id.Text);
                    if (comboBoxMain_Barrel3id.Visible && comboBoxMain_Barrel3id.Text != "" && textBoxMain_Barrel3pvp.Text != "" && textBoxMain_Barrel3pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel3pvp.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel3id.Text] + ":" + comboBoxMain_Barrel3id.Text);
                    if (comboBoxMain_Barrel4id.Visible && comboBoxMain_Barrel4id.Text != "" && textBoxMain_Barrel4pvp.Text != "" && textBoxMain_Barrel4pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel4pvp.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel4id.Text] + ":" + comboBoxMain_Barrel4id.Text);
                    if (comboBoxMain_Barrel5id.Visible && comboBoxMain_Barrel5id.Text != "" && textBoxMain_Barrel5pvp.Text != "" && textBoxMain_Barrel5pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel5pvp.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel5id.Text] + ":" + comboBoxMain_Barrel5id.Text);
                    if (comboBoxMain_Barrel6id.Visible && comboBoxMain_Barrel6id.Text != "" && textBoxMain_Barrel6pvp.Text != "" && textBoxMain_Barrel6pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel6pvp.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel6id.Text] + ":" + comboBoxMain_Barrel6id.Text);
                    if (comboBoxMain_Barrel7id.Visible && comboBoxMain_Barrel7id.Text != "" && textBoxMain_Barrel7pvp.Text != "" && textBoxMain_Barrel7pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel7pvp.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel7id.Text] + ":" + comboBoxMain_Barrel7id.Text);
                }
                else
                {
                    
                    if (textBoxMain_Barrel1id.Visible && textBoxMain_Barrel1id.Text != "" && textBoxMain_Barrel1pve.Text != "" && textBoxMain_Barrel1pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel1pve.Text).ToString("0.0") + ":" + textBoxMain_Barrel1id.Text + ":Unknown");
                    if (textBoxMain_Barrel2id.Visible && textBoxMain_Barrel2id.Text != "" && textBoxMain_Barrel2pve.Text != "" && textBoxMain_Barrel2pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel2pve.Text).ToString("0.0") + ":" + textBoxMain_Barrel2id.Text + ":Unknown");
                    if (textBoxMain_Barrel3id.Visible && textBoxMain_Barrel3id.Text != "" && textBoxMain_Barrel3pve.Text != "" && textBoxMain_Barrel3pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel3pve.Text).ToString("0.0") + ":" + textBoxMain_Barrel3id.Text + ":Unknown");
                    if (textBoxMain_Barrel4id.Visible && textBoxMain_Barrel4id.Text != "" && textBoxMain_Barrel4pve.Text != "" && textBoxMain_Barrel4pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel4pve.Text).ToString("0.0") + ":" + textBoxMain_Barrel4id.Text + ":Unknown");
                    if (textBoxMain_Barrel5id.Visible && textBoxMain_Barrel5id.Text != "" && textBoxMain_Barrel5pve.Text != "" && textBoxMain_Barrel5pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel5pve.Text).ToString("0.0") + ":" + textBoxMain_Barrel5id.Text + ":Unknown");
                    if (textBoxMain_Barrel6id.Visible && textBoxMain_Barrel6id.Text != "" && textBoxMain_Barrel6pve.Text != "" && textBoxMain_Barrel6pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel6pve.Text).ToString("0.0") + ":" + textBoxMain_Barrel6id.Text + ":Unknown");
                    if (textBoxMain_Barrel7id.Visible && textBoxMain_Barrel7id.Text != "" && textBoxMain_Barrel7pve.Text != "" && textBoxMain_Barrel7pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel7pve.Text).ToString("0.0") + ":" + textBoxMain_Barrel7id.Text + ":Unknown");

                    if (comboBoxMain_Barrel1id.Visible && comboBoxMain_Barrel1id.Text != "" && textBoxMain_Barrel1pve.Text != "" && textBoxMain_Barrel1pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel1pve.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel1id.Text] + ":" + comboBoxMain_Barrel1id.Text);
                    if (comboBoxMain_Barrel2id.Visible && comboBoxMain_Barrel2id.Text != "" && textBoxMain_Barrel2pve.Text != "" && textBoxMain_Barrel2pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel2pve.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel2id.Text] + ":" + comboBoxMain_Barrel2id.Text);
                    if (comboBoxMain_Barrel3id.Visible && comboBoxMain_Barrel3id.Text != "" && textBoxMain_Barrel3pve.Text != "" && textBoxMain_Barrel3pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel3pve.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel3id.Text] + ":" + comboBoxMain_Barrel3id.Text);
                    if (comboBoxMain_Barrel4id.Visible && comboBoxMain_Barrel4id.Text != "" && textBoxMain_Barrel4pve.Text != "" && textBoxMain_Barrel4pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel4pve.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel4id.Text] + ":" + comboBoxMain_Barrel4id.Text);
                    if (comboBoxMain_Barrel5id.Visible && comboBoxMain_Barrel5id.Text != "" && textBoxMain_Barrel5pve.Text != "" && textBoxMain_Barrel5pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel5pve.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel5id.Text] + ":" + comboBoxMain_Barrel5id.Text);
                    if (comboBoxMain_Barrel6id.Visible && comboBoxMain_Barrel6id.Text != "" && textBoxMain_Barrel6pve.Text != "" && textBoxMain_Barrel6pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel6pve.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel6id.Text] + ":" + comboBoxMain_Barrel6id.Text);
                    if (comboBoxMain_Barrel7id.Visible && comboBoxMain_Barrel7id.Text != "" && textBoxMain_Barrel7pve.Text != "" && textBoxMain_Barrel7pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel7pve.Text).ToString("0.0") + ":" + perk1Pairs[comboBoxMain_Barrel7id.Text] + ":" + comboBoxMain_Barrel7id.Text);
                }
            }
            else if (perkNum == 2) //Magazine
            {
                if (type == "pvp")
                {
                    //Text Input
                    if (textBoxMain_Mag1id.Visible && textBoxMain_Mag1id.Text != "" && textBoxMain_Mag1pvp.Text != "" && textBoxMain_Mag1pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag1pvp.Text).ToString("0.0") + ":" + textBoxMain_Mag1id.Text + ":Unknown");
                    if (textBoxMain_Mag2id.Visible && textBoxMain_Mag2id.Text != "" && textBoxMain_Mag2pvp.Text != "" && textBoxMain_Mag2pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag2pvp.Text).ToString("0.0") + ":" + textBoxMain_Mag2id.Text + ":Unknown");
                    if (textBoxMain_Mag3id.Visible && textBoxMain_Mag3id.Text != "" && textBoxMain_Mag3pvp.Text != "" && textBoxMain_Mag3pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag3pvp.Text).ToString("0.0") + ":" + textBoxMain_Mag3id.Text + ":Unknown");
                    if (textBoxMain_Mag4id.Visible && textBoxMain_Mag4id.Text != "" && textBoxMain_Mag4pvp.Text != "" && textBoxMain_Mag4pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag4pvp.Text).ToString("0.0") + ":" + textBoxMain_Mag4id.Text + ":Unknown");
                    if (textBoxMain_Mag5id.Visible && textBoxMain_Mag5id.Text != "" && textBoxMain_Mag5pvp.Text != "" && textBoxMain_Mag5pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag5pvp.Text).ToString("0.0") + ":" + textBoxMain_Mag5id.Text + ":Unknown");
                    if (textBoxMain_Mag6id.Visible && textBoxMain_Mag6id.Text != "" && textBoxMain_Mag6pvp.Text != "" && textBoxMain_Mag6pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag6pvp.Text).ToString("0.0") + ":" + textBoxMain_Mag6id.Text + ":Unknown");
                    if (textBoxMain_Mag7id.Visible && textBoxMain_Mag7id.Text != "" && textBoxMain_Mag7pvp.Text != "" && textBoxMain_Mag7pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag7pvp.Text).ToString("0.0") + ":" + textBoxMain_Mag7id.Text + ":Unknown");

                    //Dropdown
                    if (comboBoxMain_Mag1id.Visible && comboBoxMain_Mag1id.Text != "" && textBoxMain_Mag1pvp.Text != "" && textBoxMain_Mag1pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag1pvp.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag1id.Text] + ":" + comboBoxMain_Mag1id.Text);
                    if (comboBoxMain_Mag2id.Visible && comboBoxMain_Mag2id.Text != "" && textBoxMain_Mag2pvp.Text != "" && textBoxMain_Mag2pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag2pvp.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag2id.Text] + ":" + comboBoxMain_Mag2id.Text);
                    if (comboBoxMain_Mag3id.Visible && comboBoxMain_Mag3id.Text != "" && textBoxMain_Mag3pvp.Text != "" && textBoxMain_Mag3pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag3pvp.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag3id.Text] + ":" + comboBoxMain_Mag3id.Text);
                    if (comboBoxMain_Mag4id.Visible && comboBoxMain_Mag4id.Text != "" && textBoxMain_Mag4pvp.Text != "" && textBoxMain_Mag4pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag4pvp.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag4id.Text] + ":" + comboBoxMain_Mag4id.Text);
                    if (comboBoxMain_Mag5id.Visible && comboBoxMain_Mag5id.Text != "" && textBoxMain_Mag5pvp.Text != "" && textBoxMain_Mag5pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag5pvp.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag5id.Text] + ":" + comboBoxMain_Mag5id.Text);
                    if (comboBoxMain_Mag6id.Visible && comboBoxMain_Mag6id.Text != "" && textBoxMain_Mag6pvp.Text != "" && textBoxMain_Mag6pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag6pvp.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag6id.Text] + ":" + comboBoxMain_Mag6id.Text);
                    if (comboBoxMain_Mag7id.Visible && comboBoxMain_Mag7id.Text != "" && textBoxMain_Mag7pvp.Text != "" && textBoxMain_Mag7pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag7pvp.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag7id.Text] + ":" + comboBoxMain_Mag7id.Text);
                }
                else
                {
                    //Text Input
                    if (textBoxMain_Mag1id.Visible && textBoxMain_Mag1id.Text != "" && textBoxMain_Mag1pve.Text != "" && textBoxMain_Mag1pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag1pve.Text).ToString("0.0") + ":" + textBoxMain_Mag1id.Text + ":Unknown");
                    if (textBoxMain_Mag2id.Visible && textBoxMain_Mag2id.Text != "" && textBoxMain_Mag2pve.Text != "" && textBoxMain_Mag2pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag2pve.Text).ToString("0.0") + ":" + textBoxMain_Mag2id.Text + ":Unknown");
                    if (textBoxMain_Mag3id.Visible && textBoxMain_Mag3id.Text != "" && textBoxMain_Mag3pve.Text != "" && textBoxMain_Mag3pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag3pve.Text).ToString("0.0") + ":" + textBoxMain_Mag3id.Text + ":Unknown");
                    if (textBoxMain_Mag4id.Visible && textBoxMain_Mag4id.Text != "" && textBoxMain_Mag4pve.Text != "" && textBoxMain_Mag4pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag4pve.Text).ToString("0.0") + ":" + textBoxMain_Mag4id.Text + ":Unknown");
                    if (textBoxMain_Mag5id.Visible && textBoxMain_Mag5id.Text != "" && textBoxMain_Mag5pve.Text != "" && textBoxMain_Mag5pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag5pve.Text).ToString("0.0") + ":" + textBoxMain_Mag5id.Text + ":Unknown");
                    if (textBoxMain_Mag6id.Visible && textBoxMain_Mag6id.Text != "" && textBoxMain_Mag6pve.Text != "" && textBoxMain_Mag6pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag6pve.Text).ToString("0.0") + ":" + textBoxMain_Mag6id.Text + ":Unknown");
                    if (textBoxMain_Mag7id.Visible && textBoxMain_Mag7id.Text != "" && textBoxMain_Mag7pve.Text != "" && textBoxMain_Mag7pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag7pve.Text).ToString("0.0") + ":" + textBoxMain_Mag7id.Text + ":Unknown");

                    //Dropdown
                    if (comboBoxMain_Mag1id.Visible && comboBoxMain_Mag1id.Text != "" && textBoxMain_Mag1pve.Text != "" && textBoxMain_Mag1pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag1pve.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag1id.Text] + ":" + comboBoxMain_Mag1id.Text);
                    if (comboBoxMain_Mag2id.Visible && comboBoxMain_Mag2id.Text != "" && textBoxMain_Mag2pve.Text != "" && textBoxMain_Mag2pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag2pve.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag2id.Text] + ":" + comboBoxMain_Mag2id.Text);
                    if (comboBoxMain_Mag3id.Visible && comboBoxMain_Mag3id.Text != "" && textBoxMain_Mag3pve.Text != "" && textBoxMain_Mag3pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag3pve.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag3id.Text] + ":" + comboBoxMain_Mag3id.Text);
                    if (comboBoxMain_Mag4id.Visible && comboBoxMain_Mag4id.Text != "" && textBoxMain_Mag4pve.Text != "" && textBoxMain_Mag4pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag4pve.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag4id.Text] + ":" + comboBoxMain_Mag4id.Text);
                    if (comboBoxMain_Mag5id.Visible && comboBoxMain_Mag5id.Text != "" && textBoxMain_Mag5pve.Text != "" && textBoxMain_Mag5pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag5pve.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag5id.Text] + ":" + comboBoxMain_Mag5id.Text);
                    if (comboBoxMain_Mag6id.Visible && comboBoxMain_Mag6id.Text != "" && textBoxMain_Mag6pve.Text != "" && textBoxMain_Mag6pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag6pve.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag6id.Text] + ":" + comboBoxMain_Mag6id.Text);
                    if (comboBoxMain_Mag7id.Visible && comboBoxMain_Mag7id.Text != "" && textBoxMain_Mag7pve.Text != "" && textBoxMain_Mag7pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag7pve.Text).ToString("0.0") + ":" + perk2Pairs[comboBoxMain_Mag7id.Text] + ":" + comboBoxMain_Mag7id.Text);
                }
            }
            else if (perkNum == 3) //Perk 1
            {
                if (type == "pvp")
                {
                    //Text Input
                    if (textBoxMain_PerkOne1id.Visible && textBoxMain_PerkOne1id.Text != "" && textBoxMain_PerkOne1pvp.Text != "" && textBoxMain_PerkOne1pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne1pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkOne1id.Text + ":Unknown");
                    if (textBoxMain_PerkOne2id.Visible && textBoxMain_PerkOne2id.Text != "" && textBoxMain_PerkOne2pvp.Text != "" && textBoxMain_PerkOne2pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne2pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkOne2id.Text + ":Unknown");
                    if (textBoxMain_PerkOne3id.Visible && textBoxMain_PerkOne3id.Text != "" && textBoxMain_PerkOne3pvp.Text != "" && textBoxMain_PerkOne3pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne3pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkOne3id.Text + ":Unknown");
                    if (textBoxMain_PerkOne4id.Visible && textBoxMain_PerkOne4id.Text != "" && textBoxMain_PerkOne4pvp.Text != "" && textBoxMain_PerkOne4pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne4pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkOne4id.Text + ":Unknown");
                    if (textBoxMain_PerkOne5id.Visible && textBoxMain_PerkOne5id.Text != "" && textBoxMain_PerkOne5pvp.Text != "" && textBoxMain_PerkOne5pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne5pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkOne5id.Text + ":Unknown");
                    if (textBoxMain_PerkOne6id.Visible && textBoxMain_PerkOne6id.Text != "" && textBoxMain_PerkOne6pvp.Text != "" && textBoxMain_PerkOne6pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne6pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkOne6id.Text + ":Unknown");
                    if (textBoxMain_PerkOne7id.Visible && textBoxMain_PerkOne7id.Text != "" && textBoxMain_PerkOne7pvp.Text != "" && textBoxMain_PerkOne7pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne7pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkOne7id.Text + ":Unknown");

                    //Dropdown
                    if (comboBoxMain_PerkOne1id.Visible && comboBoxMain_PerkOne1id.Text != "" && textBoxMain_PerkOne1pvp.Text != "" && textBoxMain_PerkOne1pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne1pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne1id.Text] + ":" + comboBoxMain_PerkOne1id.Text);
                    if (comboBoxMain_PerkOne2id.Visible && comboBoxMain_PerkOne2id.Text != "" && textBoxMain_PerkOne2pvp.Text != "" && textBoxMain_PerkOne2pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne2pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne2id.Text] + ":" + comboBoxMain_PerkOne2id.Text);
                    if (comboBoxMain_PerkOne3id.Visible && comboBoxMain_PerkOne3id.Text != "" && textBoxMain_PerkOne3pvp.Text != "" && textBoxMain_PerkOne3pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne3pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne3id.Text] + ":" + comboBoxMain_PerkOne3id.Text);
                    if (comboBoxMain_PerkOne4id.Visible && comboBoxMain_PerkOne4id.Text != "" && textBoxMain_PerkOne4pvp.Text != "" && textBoxMain_PerkOne4pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne4pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne4id.Text] + ":" + comboBoxMain_PerkOne4id.Text);
                    if (comboBoxMain_PerkOne5id.Visible && comboBoxMain_PerkOne5id.Text != "" && textBoxMain_PerkOne5pvp.Text != "" && textBoxMain_PerkOne5pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne5pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne5id.Text] + ":" + comboBoxMain_PerkOne5id.Text);
                    if (comboBoxMain_PerkOne6id.Visible && comboBoxMain_PerkOne6id.Text != "" && textBoxMain_PerkOne6pvp.Text != "" && textBoxMain_PerkOne6pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne6pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne6id.Text] + ":" + comboBoxMain_PerkOne6id.Text);
                    if (comboBoxMain_PerkOne7id.Visible && comboBoxMain_PerkOne7id.Text != "" && textBoxMain_PerkOne7pvp.Text != "" && textBoxMain_PerkOne7pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne7pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne7id.Text] + ":" + comboBoxMain_PerkOne7id.Text);
                }
                else
                {
                    //Text Input
                    if (textBoxMain_PerkOne1id.Visible && textBoxMain_PerkOne1id.Text != "" && textBoxMain_PerkOne1pve.Text != "" && textBoxMain_PerkOne1pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne1pve.Text).ToString("0.0") + ":" + textBoxMain_PerkOne1id.Text + ":Unknown");
                    if (textBoxMain_PerkOne2id.Visible && textBoxMain_PerkOne2id.Text != "" && textBoxMain_PerkOne2pve.Text != "" && textBoxMain_PerkOne2pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne2pve.Text).ToString("0.0") + ":" + textBoxMain_PerkOne2id.Text + ":Unknown");
                    if (textBoxMain_PerkOne3id.Visible && textBoxMain_PerkOne3id.Text != "" && textBoxMain_PerkOne3pve.Text != "" && textBoxMain_PerkOne3pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne3pve.Text).ToString("0.0") + ":" + textBoxMain_PerkOne3id.Text + ":Unknown");
                    if (textBoxMain_PerkOne4id.Visible && textBoxMain_PerkOne4id.Text != "" && textBoxMain_PerkOne4pve.Text != "" && textBoxMain_PerkOne4pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne4pve.Text).ToString("0.0") + ":" + textBoxMain_PerkOne4id.Text + ":Unknown");
                    if (textBoxMain_PerkOne5id.Visible && textBoxMain_PerkOne5id.Text != "" && textBoxMain_PerkOne5pve.Text != "" && textBoxMain_PerkOne5pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne5pve.Text).ToString("0.0") + ":" + textBoxMain_PerkOne5id.Text + ":Unknown");
                    if (textBoxMain_PerkOne6id.Visible && textBoxMain_PerkOne6id.Text != "" && textBoxMain_PerkOne6pve.Text != "" && textBoxMain_PerkOne6pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne6pve.Text).ToString("0.0") + ":" + textBoxMain_PerkOne6id.Text + ":Unknown");
                    if (textBoxMain_PerkOne7id.Visible && textBoxMain_PerkOne7id.Text != "" && textBoxMain_PerkOne7pve.Text != "" && textBoxMain_PerkOne7pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne7pve.Text).ToString("0.0") + ":" + textBoxMain_PerkOne7id.Text + ":Unknown");

                    //Dropdown
                    if (comboBoxMain_PerkOne1id.Visible && comboBoxMain_PerkOne1id.Text != "" && textBoxMain_PerkOne1pve.Text != "" && textBoxMain_PerkOne1pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne1pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne1id.Text] + ":" + comboBoxMain_PerkOne1id.Text);
                    if (comboBoxMain_PerkOne2id.Visible && comboBoxMain_PerkOne2id.Text != "" && textBoxMain_PerkOne2pve.Text != "" && textBoxMain_PerkOne2pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne2pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne2id.Text] + ":" + comboBoxMain_PerkOne2id.Text);
                    if (comboBoxMain_PerkOne3id.Visible && comboBoxMain_PerkOne3id.Text != "" && textBoxMain_PerkOne3pve.Text != "" && textBoxMain_PerkOne3pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne3pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne3id.Text] + ":" + comboBoxMain_PerkOne3id.Text);
                    if (comboBoxMain_PerkOne4id.Visible && comboBoxMain_PerkOne4id.Text != "" && textBoxMain_PerkOne4pve.Text != "" && textBoxMain_PerkOne4pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne4pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne4id.Text] + ":" + comboBoxMain_PerkOne4id.Text);
                    if (comboBoxMain_PerkOne5id.Visible && comboBoxMain_PerkOne5id.Text != "" && textBoxMain_PerkOne5pve.Text != "" && textBoxMain_PerkOne5pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne5pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne5id.Text] + ":" + comboBoxMain_PerkOne5id.Text);
                    if (comboBoxMain_PerkOne6id.Visible && comboBoxMain_PerkOne6id.Text != "" && textBoxMain_PerkOne6pve.Text != "" && textBoxMain_PerkOne6pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne6pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne6id.Text] + ":" + comboBoxMain_PerkOne6id.Text);
                    if (comboBoxMain_PerkOne7id.Visible && comboBoxMain_PerkOne7id.Text != "" && textBoxMain_PerkOne7pve.Text != "" && textBoxMain_PerkOne7pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne7pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkOne7id.Text] + ":" + comboBoxMain_PerkOne7id.Text);
                }
            }
            else if (perkNum == 4) //Perk 2
            {
                if (type == "pvp")
                {
                    if (textBoxMain_PerkTwo1id.Visible && textBoxMain_PerkTwo1id.Text != "" && textBoxMain_PerkTwo1pvp.Text != "" && textBoxMain_PerkTwo1pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo1pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo1id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo2id.Visible && textBoxMain_PerkTwo2id.Text != "" && textBoxMain_PerkTwo2pvp.Text != "" && textBoxMain_PerkTwo2pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo2pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo2id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo3id.Visible && textBoxMain_PerkTwo3id.Text != "" && textBoxMain_PerkTwo3pvp.Text != "" && textBoxMain_PerkTwo3pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo3pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo3id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo4id.Visible && textBoxMain_PerkTwo4id.Text != "" && textBoxMain_PerkTwo4pvp.Text != "" && textBoxMain_PerkTwo4pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo4pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo4id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo5id.Visible && textBoxMain_PerkTwo5id.Text != "" && textBoxMain_PerkTwo5pvp.Text != "" && textBoxMain_PerkTwo5pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo5pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo5id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo6id.Visible && textBoxMain_PerkTwo6id.Text != "" && textBoxMain_PerkTwo6pvp.Text != "" && textBoxMain_PerkTwo6pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo6pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo6id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo7id.Visible && textBoxMain_PerkTwo7id.Text != "" && textBoxMain_PerkTwo7pvp.Text != "" && textBoxMain_PerkTwo7pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo7pvp.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo7id.Text + ":Unknown");

                    if (comboBoxMain_PerkTwo1id.Visible && comboBoxMain_PerkTwo1id.Text != "" && textBoxMain_PerkTwo1pvp.Text != "" && textBoxMain_PerkTwo1pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo1pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo1id.Text] + ":" + comboBoxMain_PerkTwo1id.Text);
                    if (comboBoxMain_PerkTwo2id.Visible && comboBoxMain_PerkTwo2id.Text != "" && textBoxMain_PerkTwo2pvp.Text != "" && textBoxMain_PerkTwo2pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo2pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo2id.Text] + ":" + comboBoxMain_PerkTwo2id.Text);
                    if (comboBoxMain_PerkTwo3id.Visible && comboBoxMain_PerkTwo3id.Text != "" && textBoxMain_PerkTwo3pvp.Text != "" && textBoxMain_PerkTwo3pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo3pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo3id.Text] + ":" + comboBoxMain_PerkTwo3id.Text);
                    if (comboBoxMain_PerkTwo4id.Visible && comboBoxMain_PerkTwo4id.Text != "" && textBoxMain_PerkTwo4pvp.Text != "" && textBoxMain_PerkTwo4pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo4pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo4id.Text] + ":" + comboBoxMain_PerkTwo4id.Text);
                    if (comboBoxMain_PerkTwo5id.Visible && comboBoxMain_PerkTwo5id.Text != "" && textBoxMain_PerkTwo5pvp.Text != "" && textBoxMain_PerkTwo5pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo5pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo5id.Text] + ":" + comboBoxMain_PerkTwo5id.Text);
                    if (comboBoxMain_PerkTwo6id.Visible && comboBoxMain_PerkTwo6id.Text != "" && textBoxMain_PerkTwo6pvp.Text != "" && textBoxMain_PerkTwo6pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo6pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo6id.Text] + ":" + comboBoxMain_PerkTwo6id.Text);
                    if (comboBoxMain_PerkTwo7id.Visible && comboBoxMain_PerkTwo7id.Text != "" && textBoxMain_PerkTwo7pvp.Text != "" && textBoxMain_PerkTwo7pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo7pvp.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo7id.Text] + ":" + comboBoxMain_PerkTwo7id.Text);
                }
                else
                {
                    if (textBoxMain_PerkTwo1id.Visible && textBoxMain_PerkTwo1id.Text != "" && textBoxMain_PerkTwo1pve.Text != "" && textBoxMain_PerkTwo1pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo1pve.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo1id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo2id.Visible && textBoxMain_PerkTwo2id.Text != "" && textBoxMain_PerkTwo2pve.Text != "" && textBoxMain_PerkTwo2pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo2pve.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo2id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo3id.Visible && textBoxMain_PerkTwo3id.Text != "" && textBoxMain_PerkTwo3pve.Text != "" && textBoxMain_PerkTwo3pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo3pve.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo3id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo4id.Visible && textBoxMain_PerkTwo4id.Text != "" && textBoxMain_PerkTwo4pve.Text != "" && textBoxMain_PerkTwo4pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo4pve.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo4id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo5id.Visible && textBoxMain_PerkTwo5id.Text != "" && textBoxMain_PerkTwo5pve.Text != "" && textBoxMain_PerkTwo5pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo5pve.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo5id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo6id.Visible && textBoxMain_PerkTwo6id.Text != "" && textBoxMain_PerkTwo6pve.Text != "" && textBoxMain_PerkTwo6pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo6pve.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo6id.Text + ":Unknown");
                    if (textBoxMain_PerkTwo7id.Visible && textBoxMain_PerkTwo7id.Text != "" && textBoxMain_PerkTwo7pve.Text != "" && textBoxMain_PerkTwo7pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo7pve.Text).ToString("0.0") + ":" + textBoxMain_PerkTwo7id.Text + ":Unknown");

                    if (comboBoxMain_PerkTwo1id.Visible && comboBoxMain_PerkTwo1id.Text != "" && textBoxMain_PerkTwo1pve.Text != "" && textBoxMain_PerkTwo1pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo1pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo1id.Text] + ":" + comboBoxMain_PerkTwo1id.Text);
                    if (comboBoxMain_PerkTwo2id.Visible && comboBoxMain_PerkTwo2id.Text != "" && textBoxMain_PerkTwo2pve.Text != "" && textBoxMain_PerkTwo2pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo2pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo2id.Text] + ":" + comboBoxMain_PerkTwo2id.Text);
                    if (comboBoxMain_PerkTwo3id.Visible && comboBoxMain_PerkTwo3id.Text != "" && textBoxMain_PerkTwo3pve.Text != "" && textBoxMain_PerkTwo3pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo3pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo3id.Text] + ":" + comboBoxMain_PerkTwo3id.Text);
                    if (comboBoxMain_PerkTwo4id.Visible && comboBoxMain_PerkTwo4id.Text != "" && textBoxMain_PerkTwo4pve.Text != "" && textBoxMain_PerkTwo4pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo4pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo4id.Text] + ":" + comboBoxMain_PerkTwo4id.Text);
                    if (comboBoxMain_PerkTwo5id.Visible && comboBoxMain_PerkTwo5id.Text != "" && textBoxMain_PerkTwo5pve.Text != "" && textBoxMain_PerkTwo5pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo5pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo5id.Text] + ":" + comboBoxMain_PerkTwo5id.Text);
                    if (comboBoxMain_PerkTwo6id.Visible && comboBoxMain_PerkTwo6id.Text != "" && textBoxMain_PerkTwo6pve.Text != "" && textBoxMain_PerkTwo6pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo6pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo6id.Text] + ":" + comboBoxMain_PerkTwo6id.Text);
                    if (comboBoxMain_PerkTwo7id.Visible && comboBoxMain_PerkTwo7id.Text != "" && textBoxMain_PerkTwo7pve.Text != "" && textBoxMain_PerkTwo7pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo7pve.Text).ToString("0.0") + ":" + traitPairs[comboBoxMain_PerkTwo7id.Text] + ":" + comboBoxMain_PerkTwo7id.Text);
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
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel1.Text, perk1Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel1.Text) + ",";

                        if (comboBoxMain_ComboMag1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag1.Text, perk2Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag1.Text) + ",";

                        if (comboBoxMain_ComboPerkOne1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne1.Text, traitPairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne1.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo1.Text, traitPairs) + ":" + float.Parse(textBoxMain_Combopvp1.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo1.Text) + ":" + float.Parse(textBoxMain_Combopvp1.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopvp2.Text != "" && textBoxMain_Combopvp2.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel2.Text, perk1Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel2.Text) + ",";

                        if (comboBoxMain_ComboMag2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag2.Text, perk2Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag2.Text) + ",";

                        if (comboBoxMain_ComboPerkOne2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne2.Text, traitPairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne2.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo2.Text, traitPairs) + ":" + float.Parse(textBoxMain_Combopvp2.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo2.Text) + ":" + float.Parse(textBoxMain_Combopvp2.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopvp3.Text != "" && textBoxMain_Combopvp3.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel3.Text, perk1Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel3.Text) + ",";

                        if (comboBoxMain_ComboMag3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag3.Text, perk2Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag3.Text) + ",";

                        if (comboBoxMain_ComboPerkOne3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne3.Text, traitPairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne3.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo3.Text, traitPairs) + ":" + float.Parse(textBoxMain_Combopvp3.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo3.Text) + ":" + float.Parse(textBoxMain_Combopvp3.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopvp4.Text != "" && textBoxMain_Combopvp4.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel4.Text, perk1Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel4.Text) + ",";

                        if (comboBoxMain_ComboMag4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag4.Text, perk2Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag4.Text) + ",";

                        if (comboBoxMain_ComboPerkOne4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne4.Text, traitPairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne4.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo4.Text, traitPairs) + ":" + float.Parse(textBoxMain_Combopvp4.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo4.Text) + ":" + float.Parse(textBoxMain_Combopvp4.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopvp5.Text != "" && textBoxMain_Combopvp5.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel5.Text, perk1Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel5.Text) + ",";

                        if (comboBoxMain_ComboMag5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag5.Text, perk2Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag5.Text) + ",";

                        if (comboBoxMain_ComboPerkOne5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne5.Text, traitPairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne5.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo5.Text, traitPairs) + ":" + float.Parse(textBoxMain_Combopvp5.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo5.Text) + ":" + float.Parse(textBoxMain_Combopvp5.Text).ToString("0.0");

                        roll.Add(s);
                    }    
                }
                else
                {
                    //Check if any
                    if ((textBoxMain_Combopve1.Text != "" && textBoxMain_Combopve1.Text != "0") || (textBoxMain_Combopve2.Text != "" && textBoxMain_Combopve2.Text != "0") || (textBoxMain_Combopve3.Text != "" && textBoxMain_Combopve3.Text != "0") || (textBoxMain_Combopve4.Text != "" && textBoxMain_Combopve4.Text != "0") || (textBoxMain_Combopve5.Text != "" && textBoxMain_Combopve5.Text != "0"))
                    {
                        roll.Add("//Combos");
                    }

                    if (textBoxMain_Combopve1.Text != "" && textBoxMain_Combopve1.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel1.Text, perk1Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel1.Text) + ",";

                        if (comboBoxMain_ComboMag1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag1.Text, perk2Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag1.Text) + ",";

                        if (comboBoxMain_ComboPerkOne1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne1.Text, traitPairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne1.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo1.Text, traitPairs) + ":" + float.Parse(textBoxMain_Combopve1.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo1.Text) + ":" + float.Parse(textBoxMain_Combopve1.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopve2.Text != "" && textBoxMain_Combopve2.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel2.Text, perk1Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel2.Text) + ",";

                        if (comboBoxMain_ComboMag2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag2.Text, perk2Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag2.Text) + ",";

                        if (comboBoxMain_ComboPerkOne2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne2.Text, traitPairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne2.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo2.Text, traitPairs) + ":" + float.Parse(textBoxMain_Combopve2.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo2.Text) + ":" + float.Parse(textBoxMain_Combopve2.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopve3.Text != "" && textBoxMain_Combopve3.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel3.Text, perk1Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel3.Text) + ",";

                        if (comboBoxMain_ComboMag3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag3.Text, perk2Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag3.Text) + ",";

                        if (comboBoxMain_ComboPerkOne3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne3.Text, traitPairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne3.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo3.Text, traitPairs) + ":" + float.Parse(textBoxMain_Combopve3.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo3.Text) + ":" + float.Parse(textBoxMain_Combopve3.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopve4.Text != "" && textBoxMain_Combopve4.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel4.Text, perk1Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel4.Text) + ",";

                        if (comboBoxMain_ComboMag4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag4.Text, perk2Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag4.Text) + ",";

                        if (comboBoxMain_ComboPerkOne4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne4.Text, traitPairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne4.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo4.Text, traitPairs) + ":" + float.Parse(textBoxMain_Combopve4.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo4.Text) + ":" + float.Parse(textBoxMain_Combopve4.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopve5.Text != "" && textBoxMain_Combopve5.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel5.Text, perk1Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel5.Text) + ",";

                        if (comboBoxMain_ComboMag5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag5.Text, perk2Pairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag5.Text) + ",";

                        if (comboBoxMain_ComboPerkOne5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne5.Text, traitPairs) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne5.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo5.Text, traitPairs) + ":" + float.Parse(textBoxMain_Combopve5.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo5.Text) + ":" + float.Parse(textBoxMain_Combopve5.Text).ToString("0.0");

                        roll.Add(s);
                    }
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

        private string getValueOrZero(string s, Dictionary<string, long> d)
        {
            if (s == null || s == "")
                return "0";
            return d[s].ToString();
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

        private void perk2OneChange_Click(object sender, EventArgs e)
        {
            if(textBoxMain_PerkTwo1id.Visible)
            {
                textBoxMain_PerkTwo1id.Visible = false;
                comboBoxMain_PerkTwo1id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkTwo1id.Visible = false;
                textBoxMain_PerkTwo1id.Visible = true;                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkTwo2id.Visible)
            {
                textBoxMain_PerkTwo2id.Visible = false;
                comboBoxMain_PerkTwo2id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkTwo2id.Visible = false;
                textBoxMain_PerkTwo2id.Visible = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkTwo3id.Visible)
            {
                textBoxMain_PerkTwo3id.Visible = false;
                comboBoxMain_PerkTwo3id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkTwo3id.Visible = false;
                textBoxMain_PerkTwo3id.Visible = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkTwo4id.Visible)
            {
                textBoxMain_PerkTwo4id.Visible = false;
                comboBoxMain_PerkTwo4id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkTwo4id.Visible = false;
                textBoxMain_PerkTwo4id.Visible = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkTwo5id.Visible)
            {
                textBoxMain_PerkTwo5id.Visible = false;
                comboBoxMain_PerkTwo5id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkTwo5id.Visible = false;
                textBoxMain_PerkTwo5id.Visible = true;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkTwo6id.Visible)
            {
                textBoxMain_PerkTwo6id.Visible = false;
                comboBoxMain_PerkTwo6id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkTwo6id.Visible = false;
                textBoxMain_PerkTwo6id.Visible = true;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkTwo7id.Visible)
            {
                textBoxMain_PerkTwo7id.Visible = false;
                comboBoxMain_PerkTwo7id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkTwo7id.Visible = false;
                textBoxMain_PerkTwo7id.Visible = true;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkOne1id.Visible)
            {
                textBoxMain_PerkOne1id.Visible = false;
                comboBoxMain_PerkOne1id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkOne1id.Visible = false;
                textBoxMain_PerkOne1id.Visible = true;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkOne2id.Visible)
            {
                textBoxMain_PerkOne2id.Visible = false;
                comboBoxMain_PerkOne2id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkOne2id.Visible = false;
                textBoxMain_PerkOne2id.Visible = true;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkOne3id.Visible)
            {
                textBoxMain_PerkOne3id.Visible = false;
                comboBoxMain_PerkOne3id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkOne3id.Visible = false;
                textBoxMain_PerkOne3id.Visible = true;
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkOne4id.Visible)
            {
                textBoxMain_PerkOne4id.Visible = false;
                comboBoxMain_PerkOne4id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkOne4id.Visible = false;
                textBoxMain_PerkOne4id.Visible = true;
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkOne5id.Visible)
            {
                textBoxMain_PerkOne5id.Visible = false;
                comboBoxMain_PerkOne5id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkOne5id.Visible = false;
                textBoxMain_PerkOne5id.Visible = true;
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkOne6id.Visible)
            {
                textBoxMain_PerkOne6id.Visible = false;
                comboBoxMain_PerkOne6id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkOne6id.Visible = false;
                textBoxMain_PerkOne6id.Visible = true;
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (textBoxMain_PerkOne7id.Visible)
            {
                textBoxMain_PerkOne7id.Visible = false;
                comboBoxMain_PerkOne7id.Visible = true;
            }
            else
            {
                comboBoxMain_PerkOne7id.Visible = false;
                textBoxMain_PerkOne7id.Visible = true;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Mag1id.Visible)
            {
                textBoxMain_Mag1id.Visible = false;
                comboBoxMain_Mag1id.Visible = true;
            }
            else
            {
                comboBoxMain_Mag1id.Visible = false;
                textBoxMain_Mag1id.Visible = true;
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Mag2id.Visible)
            {
                textBoxMain_Mag2id.Visible = false;
                comboBoxMain_Mag2id.Visible = true;
            }
            else
            {
                comboBoxMain_Mag2id.Visible = false;
                textBoxMain_Mag2id.Visible = true;
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Mag3id.Visible)
            {
                textBoxMain_Mag3id.Visible = false;
                comboBoxMain_Mag3id.Visible = true;
            }
            else
            {
                comboBoxMain_Mag3id.Visible = false;
                textBoxMain_Mag3id.Visible = true;
            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Mag4id.Visible)
            {
                textBoxMain_Mag4id.Visible = false;
                comboBoxMain_Mag4id.Visible = true;
            }
            else
            {
                comboBoxMain_Mag4id.Visible = false;
                textBoxMain_Mag4id.Visible = true;
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Mag5id.Visible)
            {
                textBoxMain_Mag5id.Visible = false;
                comboBoxMain_Mag5id.Visible = true;
            }
            else
            {
                comboBoxMain_Mag5id.Visible = false;
                textBoxMain_Mag5id.Visible = true;
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Mag6id.Visible)
            {
                textBoxMain_Mag6id.Visible = false;
                comboBoxMain_Mag6id.Visible = true;
            }
            else
            {
                comboBoxMain_Mag6id.Visible = false;
                textBoxMain_Mag6id.Visible = true;
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Mag7id.Visible)
            {
                textBoxMain_Mag7id.Visible = false;
                comboBoxMain_Mag7id.Visible = true;
            }
            else
            {
                comboBoxMain_Mag7id.Visible = false;
                textBoxMain_Mag7id.Visible = true;
            }
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Barrel1id.Visible)
            {
                textBoxMain_Barrel1id.Visible = false;
                comboBoxMain_Barrel1id.Visible = true;
            }
            else
            {
                comboBoxMain_Barrel1id.Visible = false;
                textBoxMain_Barrel1id.Visible = true;
            }
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Barrel2id.Visible)
            {
                textBoxMain_Barrel2id.Visible = false;
                comboBoxMain_Barrel2id.Visible = true;
            }
            else
            {
                comboBoxMain_Barrel2id.Visible = false;
                textBoxMain_Barrel2id.Visible = true;
            }
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Barrel3id.Visible)
            {
                textBoxMain_Barrel3id.Visible = false;
                comboBoxMain_Barrel3id.Visible = true;
            }
            else
            {
                comboBoxMain_Barrel3id.Visible = false;
                textBoxMain_Barrel3id.Visible = true;
            }
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Barrel4id.Visible)
            {
                textBoxMain_Barrel4id.Visible = false;
                comboBoxMain_Barrel4id.Visible = true;
            }
            else
            {
                comboBoxMain_Barrel4id.Visible = false;
                textBoxMain_Barrel4id.Visible = true;
            }
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Barrel5id.Visible)
            {
                textBoxMain_Barrel5id.Visible = false;
                comboBoxMain_Barrel5id.Visible = true;
            }
            else
            {
                comboBoxMain_Barrel5id.Visible = false;
                textBoxMain_Barrel5id.Visible = true;
            }
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Barrel6id.Visible)
            {
                textBoxMain_Barrel6id.Visible = false;
                comboBoxMain_Barrel6id.Visible = true;
            }
            else
            {
                comboBoxMain_Barrel6id.Visible = false;
                textBoxMain_Barrel6id.Visible = true;
            }
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            if (textBoxMain_Barrel7id.Visible)
            {
                textBoxMain_Barrel7id.Visible = false;
                comboBoxMain_Barrel7id.Visible = true;
            }
            else
            {
                comboBoxMain_Barrel7id.Visible = false;
                textBoxMain_Barrel7id.Visible = true;
            }
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            if(textBoxMain_Weapon.Visible)
            {
                textBoxMain_Weapon.Visible = false;
                labelMain_WeaponName.Visible = false;
                textBoxMain_WeaponName.Visible = false;
                comboBoxMain_Weapon.Visible = true;
            }
            else
            {
                textBoxMain_Weapon.Visible = true;
                labelMain_WeaponName.Visible = true;
                textBoxMain_WeaponName.Visible = true;
                comboBoxMain_Weapon.Visible = false;
            }
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboBarrel1.Visible)
            {
                textBoxMain_ComboBarrel1.Visible = false;
                comboBoxMain_ComboBarrel1.Visible = true;
            }
            else
            {
                comboBoxMain_ComboBarrel1.Visible = false;
                textBoxMain_ComboBarrel1.Visible = true;
            }
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboBarrel2.Visible)
            {
                textBoxMain_ComboBarrel2.Visible = false;
                comboBoxMain_ComboBarrel2.Visible = true;
            }
            else
            {
                comboBoxMain_ComboBarrel2.Visible = false;
                textBoxMain_ComboBarrel2.Visible = true;
            }
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboBarrel3.Visible)
            {
                textBoxMain_ComboBarrel3.Visible = false;
                comboBoxMain_ComboBarrel3.Visible = true;
            }
            else
            {
                comboBoxMain_ComboBarrel3.Visible = false;
                textBoxMain_ComboBarrel3.Visible = true;
            }
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboBarrel4.Visible)
            {
                textBoxMain_ComboBarrel4.Visible = false;
                comboBoxMain_ComboBarrel4.Visible = true;
            }
            else
            {
                comboBoxMain_ComboBarrel4.Visible = false;
                textBoxMain_ComboBarrel4.Visible = true;
            }
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboBarrel5.Visible)
            {
                textBoxMain_ComboBarrel5.Visible = false;
                comboBoxMain_ComboBarrel5.Visible = true;
            }
            else
            {
                comboBoxMain_ComboBarrel5.Visible = false;
                textBoxMain_ComboBarrel5.Visible = true;
            }
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboMag1.Visible)
            {
                textBoxMain_ComboMag1.Visible = false;
                comboBoxMain_ComboMag1.Visible = true;
            }
            else
            {
                comboBoxMain_ComboMag1.Visible = false;
                textBoxMain_ComboMag1.Visible = true;
            }
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboMag2.Visible)
            {
                textBoxMain_ComboMag2.Visible = false;
                comboBoxMain_ComboMag2.Visible = true;
            }
            else
            {
                comboBoxMain_ComboMag2.Visible = false;
                textBoxMain_ComboMag2.Visible = true;
            }
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboMag3.Visible)
            {
                textBoxMain_ComboMag3.Visible = false;
                comboBoxMain_ComboMag3.Visible = true;
            }
            else
            {
                comboBoxMain_ComboMag3.Visible = false;
                textBoxMain_ComboMag3.Visible = true;
            }
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboMag4.Visible)
            {
                textBoxMain_ComboMag4.Visible = false;
                comboBoxMain_ComboMag4.Visible = true;
            }
            else
            {
                comboBoxMain_ComboMag4.Visible = false;
                textBoxMain_ComboMag4.Visible = true;
            }
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboMag5.Visible)
            {
                textBoxMain_ComboMag5.Visible = false;
                comboBoxMain_ComboMag5.Visible = true;
            }
            else
            {
                comboBoxMain_ComboMag5.Visible = false;
                textBoxMain_ComboMag5.Visible = true;
            }
        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboPerkOne1.Visible)
            {
                textBoxMain_ComboPerkOne1.Visible = false;
                comboBoxMain_ComboPerkOne1.Visible = true;
            }
            else
            {
                comboBoxMain_ComboPerkOne1.Visible = false;
                textBoxMain_ComboPerkOne1.Visible = true;
            }
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboPerkOne2.Visible)
            {
                textBoxMain_ComboPerkOne2.Visible = false;
                comboBoxMain_ComboPerkOne2.Visible = true;
            }
            else
            {
                comboBoxMain_ComboPerkOne2.Visible = false;
                textBoxMain_ComboPerkOne2.Visible = true;
            }
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboPerkOne3.Visible)
            {
                textBoxMain_ComboPerkOne3.Visible = false;
                comboBoxMain_ComboPerkOne3.Visible = true;
            }
            else
            {
                comboBoxMain_ComboPerkOne3.Visible = false;
                textBoxMain_ComboPerkOne3.Visible = true;
            }
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboPerkOne4.Visible)
            {
                textBoxMain_ComboPerkOne4.Visible = false;
                comboBoxMain_ComboPerkOne4.Visible = true;
            }
            else
            {
                comboBoxMain_ComboPerkOne4.Visible = false;
                textBoxMain_ComboPerkOne4.Visible = true;
            }
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboPerkOne5.Visible)
            {
                textBoxMain_ComboPerkOne5.Visible = false;
                comboBoxMain_ComboPerkOne5.Visible = true;
            }
            else
            {
                comboBoxMain_ComboPerkOne5.Visible = false;
                textBoxMain_ComboPerkOne5.Visible = true;
            }
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboPerkTwo1.Visible)
            {
                textBoxMain_ComboPerkTwo1.Visible = false;
                comboBoxMain_ComboPerkTwo1.Visible = true;
            }
            else
            {
                comboBoxMain_ComboPerkTwo1.Visible = false;
                textBoxMain_ComboPerkTwo1.Visible = true;
            }
        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboPerkTwo2.Visible)
            {
                textBoxMain_ComboPerkTwo2.Visible = false;
                comboBoxMain_ComboPerkTwo2.Visible = true;
            }
            else
            {
                comboBoxMain_ComboPerkTwo2.Visible = false;
                textBoxMain_ComboPerkTwo2.Visible = true;
            }
        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboPerkTwo3.Visible)
            {
                textBoxMain_ComboPerkTwo3.Visible = false;
                comboBoxMain_ComboPerkTwo3.Visible = true;
            }
            else
            {
                comboBoxMain_ComboPerkTwo3.Visible = false;
                textBoxMain_ComboPerkTwo3.Visible = true;
            }
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboPerkTwo4.Visible)
            {
                textBoxMain_ComboPerkTwo4.Visible = false;
                comboBoxMain_ComboPerkTwo4.Visible = true;
            }
            else
            {
                comboBoxMain_ComboPerkTwo4.Visible = false;
                textBoxMain_ComboPerkTwo4.Visible = true;
            }
        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {
            if (textBoxMain_ComboPerkTwo5.Visible)
            {
                textBoxMain_ComboPerkTwo5.Visible = false;
                comboBoxMain_ComboPerkTwo5.Visible = true;
            }
            else
            {
                comboBoxMain_ComboPerkTwo5.Visible = false;
                textBoxMain_ComboPerkTwo5.Visible = true;
            }
        }

        private void textBoxMain_Weapon_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(textBoxMain_Weapon.Text, out n) && weaponPairs.ContainsValue(Convert.ToInt64(textBoxMain_Weapon.Text)))
                textBoxMain_WeaponName.Text = weaponPairs.FirstOrDefault(x => x.Value == Convert.ToInt64(textBoxMain_Weapon.Text)).Key;
        }

        private void comboBoxMain_Weapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMain_Weapon.Text == null || comboBoxMain_Weapon.Text == "")
            {
                if (customDropdowns)
                    loadDropdowns();
                return;
            }
                

            XmlDocument doc = new XmlDocument();
            string perk1Group = "";
            string perk2Group = "";

            doc.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WeaponCollection.xml");
            XmlNodeList weaponNodes = doc.SelectNodes("weapons/weapon");

            foreach (XmlNode w in weaponNodes)
            {
                string name = w["name"].InnerText;
                if (name == comboBoxMain_Weapon.Text)
                {
                    perk1Group = w["perk1Group"].InnerText;
                    perk2Group = w["perk1Group"].InnerText;
                }
            }

            if (perk1Group == "" && perk2Group == "")
            {
                if (customDropdowns)
                    loadDropdowns();
                return;
            }

            //Load Custom Dropdowns
            doc.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Perk1Collection.xml");
            XmlNodeList perkNodes = doc.SelectNodes("perk1/perkGroup");

            foreach (XmlNode p in perkNodes)
            {
                string name = p["name"].InnerText;
                if (name == perk1Group)
                {
                    comboBoxMain_Barrel2id.Items.Clear();
                    for(int i=0; i<p.ChildNodes.Count; i++)
                    {
                        if( p.ChildNodes[i].Name == "perk")
                        {
                            //TODO: add filter to rest of barrels
                            comboBoxMain_Barrel2id.Items.Add(p.ChildNodes[i]["name"].InnerText);
                        }
                    }
                    customDropdowns = true;
                }
            }

            //TODO: add logic for mags

            
        }
    }
}
