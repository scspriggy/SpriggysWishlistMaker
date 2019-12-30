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

//TODO: P1 Figure out how to store barrel/mag that don't fit a group (ie: Martyr's Retribution)
//TODO: P1 Add Perks: +Lead from gold, +Disruption Break
//TODO: P2 Speed up loading when selecting weapon

//TODO: P4 Add weapon details to main page when selected
//TODO: P4 Add option to include curated rolls
//TODO: P4 Filter perks based on weapon selection

namespace Spriggys_DIM_Wishlist_Maker
{
    public partial class Form1 : Form
    {
        private List<Perk> barrelPerks = new List<Perk>();
        private List<Perk> magPerks = new List<Perk>();
        private List<Perk> traitPerks = new List<Perk>();
        private List<Weapon> weapons = new List<Weapon>();
        bool customDropdowns;

        public Form1()
        {
            InitializeComponent();
            importData();
            loadWeaponDropdowns("");
            loadBarrelDropdowns("");
            loadMagDropdowns("");
            loadTraitDropdowns("");
            loadSettings();
            loadGameMode();
        }

        private void importData()
        {
            XmlDocument doc = new XmlDocument();

            //Load Weapons
            doc.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WeaponCollection.xml");
            XmlNodeList weaponNodes = doc.SelectNodes("weapons/weapon");

            foreach (XmlNode n in weaponNodes)
            {
                if(n["id"].InnerText != null && n["id"].InnerText != "")
                {
                    Weapon w = new Weapon();
                    string idText = n["id"].InnerText;
                    w.id = Convert.ToInt64(idText);

                    if (!n["name"].IsEmpty)
                        w.name = n["name"].InnerText;

                    if (!n["perk1Group"].IsEmpty)
                        w.perk1Group = n["perk1Group"].InnerText;

                    if (!n["perk2Group"].IsEmpty)
                        w.perk2Group = n["perk2Group"].InnerText;

                    if (!n["category"].IsEmpty)
                        w.category = n["category"].InnerText;

                    weapons.Add(w);
                }
            }

            //Load Barrels
            doc.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Perk1Collection.xml");
            XmlNodeList perkNodes = doc.SelectNodes("perks/perk");

            foreach (XmlNode n in perkNodes)
            {
                if(n["id"].InnerText != null && n["id"].InnerText != "")
                {
                    Perk p = new Perk();
                    p.id = Convert.ToInt64(n["id"].InnerText);

                    if (!n["name"].IsEmpty)
                        p.name = n["name"].InnerText;

                    if (!n["perkGroup"].IsEmpty)
                        p.perkGroup = n["perkGroup"].InnerText;

                    barrelPerks.Add(p);
                }
            }

            //Load Mags
            doc.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Perk2Collection.xml");
            perkNodes = doc.SelectNodes("perks/perk");

            foreach (XmlNode n in perkNodes)
            {
                if(n["id"].InnerText != null && n["id"].InnerText != "")
                {
                    Perk p = new Perk();
                    p.id = Convert.ToInt64(n["id"].InnerText);

                    if (!n["name"].IsEmpty)
                        p.name = n["name"].InnerText;

                    if (!n["perkGroup"].IsEmpty)
                        p.perkGroup = n["perkGroup"].InnerText;

                    magPerks.Add(p);
                }
            }

            //Load Traits
            doc.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\TraitCollection.xml");
            perkNodes = doc.SelectNodes("perks/perk");

            foreach (XmlNode n in perkNodes)
            {
                if(n["id"].InnerText != null && n["id"].InnerText != "")
                {
                    Perk p = new Perk();
                    p.id = Convert.ToInt64(n["id"].InnerText);

                    if (!n["name"].IsEmpty)
                        p.name = n["name"].InnerText;

                    traitPerks.Add(p);
                }
            }
        }

        private void clearWeaponDropdowns()
        {
            comboBoxMain_Weapon.Items.Clear();
        }

        private void loadWeaponDropdowns(string category)
        {
            clearWeaponDropdowns();

            comboBoxMain_Weapon.Items.Add("");

            foreach (Weapon w in weapons)
            {
                if (category == "" || category == w.category)
                {
                    comboBoxMain_Weapon.Items.Add(w.name);
                }
            }
        }

        private void clearBarrelDropdowns()
        {
            comboBoxMain_Barrel1id.Items.Clear();
            comboBoxMain_Barrel2id.Items.Clear();
            comboBoxMain_Barrel3id.Items.Clear();
            comboBoxMain_Barrel4id.Items.Clear();
            comboBoxMain_Barrel5id.Items.Clear();
            comboBoxMain_Barrel6id.Items.Clear();
            comboBoxMain_Barrel7id.Items.Clear();
            comboBoxMain_ComboBarrel1.Items.Clear();
            comboBoxMain_ComboBarrel2.Items.Clear();
            comboBoxMain_ComboBarrel3.Items.Clear();
            comboBoxMain_ComboBarrel4.Items.Clear();
            comboBoxMain_ComboBarrel5.Items.Clear();
        }
        private void loadBarrelDropdowns(string group)
        {
            clearBarrelDropdowns();

            if (group == "")
            {
                labelMain_Barrel.Text = "Barrel";
                labelMain_Barrel2.Text = "Barrel";
            }
            else
            {
                labelMain_Barrel.Text = group;
                labelMain_Barrel2.Text = group;
            }

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

            foreach (Perk p in barrelPerks)
            {
                if( group == "" || group == p.perkGroup)
                {
                    if (!customDropdowns && group == p.perkGroup)
                        customDropdowns = true;

                    comboBoxMain_Barrel1id.Items.Add(p.name);
                    comboBoxMain_Barrel2id.Items.Add(p.name);
                    comboBoxMain_Barrel3id.Items.Add(p.name);
                    comboBoxMain_Barrel4id.Items.Add(p.name);
                    comboBoxMain_Barrel5id.Items.Add(p.name);
                    comboBoxMain_Barrel6id.Items.Add(p.name);
                    comboBoxMain_Barrel7id.Items.Add(p.name);
                    comboBoxMain_ComboBarrel1.Items.Add(p.name);
                    comboBoxMain_ComboBarrel2.Items.Add(p.name);
                    comboBoxMain_ComboBarrel3.Items.Add(p.name);
                    comboBoxMain_ComboBarrel4.Items.Add(p.name);
                    comboBoxMain_ComboBarrel5.Items.Add(p.name);
                }
            }
        }

        private void clearMagDropdowns()
        {
            comboBoxMain_Mag1id.Items.Clear();
            comboBoxMain_Mag2id.Items.Clear();
            comboBoxMain_Mag3id.Items.Clear();
            comboBoxMain_Mag4id.Items.Clear();
            comboBoxMain_Mag5id.Items.Clear();
            comboBoxMain_Mag6id.Items.Clear();
            comboBoxMain_Mag7id.Items.Clear();
            comboBoxMain_ComboMag1.Items.Clear();
            comboBoxMain_ComboMag2.Items.Clear();
            comboBoxMain_ComboMag3.Items.Clear();
            comboBoxMain_ComboMag4.Items.Clear();
            comboBoxMain_ComboMag5.Items.Clear();
        }
        private void loadMagDropdowns(string group)
        {
            clearMagDropdowns();

            if(group == "")
            {
                labelMain_Mag.Text = "Magazine";
                labelMain_Mag2.Text = "Magazine";
            }
            else
            {
                labelMain_Mag.Text = group;
                labelMain_Mag2.Text = group;
            }
            

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

            foreach (Perk p in magPerks)
            {
                if (group == "" || group == p.perkGroup)
                {
                    if (!customDropdowns && group == p.perkGroup)
                        customDropdowns = true;

                    comboBoxMain_Mag1id.Items.Add(p.name);
                    comboBoxMain_Mag2id.Items.Add(p.name);
                    comboBoxMain_Mag3id.Items.Add(p.name);
                    comboBoxMain_Mag4id.Items.Add(p.name);
                    comboBoxMain_Mag5id.Items.Add(p.name);
                    comboBoxMain_Mag6id.Items.Add(p.name);
                    comboBoxMain_Mag7id.Items.Add(p.name);
                    comboBoxMain_ComboMag1.Items.Add(p.name);
                    comboBoxMain_ComboMag2.Items.Add(p.name);
                    comboBoxMain_ComboMag3.Items.Add(p.name);
                    comboBoxMain_ComboMag4.Items.Add(p.name);
                    comboBoxMain_ComboMag5.Items.Add(p.name);
                }
            }
        }

        private void clearTraitDropdowns()
        {
            comboBoxMain_PerkOne1id.Items.Clear();
            comboBoxMain_PerkOne2id.Items.Clear();
            comboBoxMain_PerkOne3id.Items.Clear();
            comboBoxMain_PerkOne4id.Items.Clear();
            comboBoxMain_PerkOne5id.Items.Clear();
            comboBoxMain_PerkOne6id.Items.Clear();
            comboBoxMain_PerkOne7id.Items.Clear();
            comboBoxMain_ComboPerkOne1.Items.Clear();
            comboBoxMain_ComboPerkOne2.Items.Clear();
            comboBoxMain_ComboPerkOne3.Items.Clear();
            comboBoxMain_ComboPerkOne4.Items.Clear();
            comboBoxMain_ComboPerkOne5.Items.Clear();

            comboBoxMain_PerkTwo1id.Items.Clear();
            comboBoxMain_PerkTwo2id.Items.Clear();
            comboBoxMain_PerkTwo3id.Items.Clear();
            comboBoxMain_PerkTwo4id.Items.Clear();
            comboBoxMain_PerkTwo5id.Items.Clear();
            comboBoxMain_PerkTwo6id.Items.Clear();
            comboBoxMain_PerkTwo7id.Items.Clear();
            comboBoxMain_ComboPerkTwo1.Items.Clear();
            comboBoxMain_ComboPerkTwo2.Items.Clear();
            comboBoxMain_ComboPerkTwo3.Items.Clear();
            comboBoxMain_ComboPerkTwo4.Items.Clear();
            comboBoxMain_ComboPerkTwo5.Items.Clear();
        }
        private void loadTraitDropdowns(string group)
        {
            clearTraitDropdowns();

            comboBoxMain_PerkOne1id.Items.Add("");
            comboBoxMain_PerkOne2id.Items.Add("");
            comboBoxMain_PerkOne3id.Items.Add("");
            comboBoxMain_PerkOne4id.Items.Add("");
            comboBoxMain_PerkOne5id.Items.Add("");
            comboBoxMain_PerkOne6id.Items.Add("");
            comboBoxMain_PerkOne7id.Items.Add("");
            comboBoxMain_ComboPerkOne1.Items.Add("");
            comboBoxMain_ComboPerkOne2.Items.Add("");
            comboBoxMain_ComboPerkOne3.Items.Add("");
            comboBoxMain_ComboPerkOne4.Items.Add("");
            comboBoxMain_ComboPerkOne5.Items.Add("");

            comboBoxMain_PerkTwo1id.Items.Add("");
            comboBoxMain_PerkTwo2id.Items.Add("");
            comboBoxMain_PerkTwo3id.Items.Add("");
            comboBoxMain_PerkTwo4id.Items.Add("");
            comboBoxMain_PerkTwo5id.Items.Add("");
            comboBoxMain_PerkTwo6id.Items.Add("");
            comboBoxMain_PerkTwo7id.Items.Add("");
            comboBoxMain_ComboPerkTwo1.Items.Add("");
            comboBoxMain_ComboPerkTwo2.Items.Add("");
            comboBoxMain_ComboPerkTwo3.Items.Add("");
            comboBoxMain_ComboPerkTwo4.Items.Add("");
            comboBoxMain_ComboPerkTwo5.Items.Add("");

            foreach (Perk p in traitPerks)
            {
                if (group == "" || group == p.perkGroup)
                {
                    if (!customDropdowns && group == p.perkGroup)
                        customDropdowns = true;

                    comboBoxMain_PerkOne1id.Items.Add(p.name);
                    comboBoxMain_PerkOne2id.Items.Add(p.name);
                    comboBoxMain_PerkOne3id.Items.Add(p.name);
                    comboBoxMain_PerkOne4id.Items.Add(p.name);
                    comboBoxMain_PerkOne5id.Items.Add(p.name);
                    comboBoxMain_PerkOne6id.Items.Add(p.name);
                    comboBoxMain_PerkOne7id.Items.Add(p.name);
                    comboBoxMain_ComboPerkOne1.Items.Add(p.name);
                    comboBoxMain_ComboPerkOne2.Items.Add(p.name);
                    comboBoxMain_ComboPerkOne3.Items.Add(p.name);
                    comboBoxMain_ComboPerkOne4.Items.Add(p.name);
                    comboBoxMain_ComboPerkOne5.Items.Add(p.name);

                    comboBoxMain_PerkTwo1id.Items.Add(p.name);
                    comboBoxMain_PerkTwo2id.Items.Add(p.name);
                    comboBoxMain_PerkTwo3id.Items.Add(p.name);
                    comboBoxMain_PerkTwo4id.Items.Add(p.name);
                    comboBoxMain_PerkTwo5id.Items.Add(p.name);
                    comboBoxMain_PerkTwo6id.Items.Add(p.name);
                    comboBoxMain_PerkTwo7id.Items.Add(p.name);
                    comboBoxMain_ComboPerkTwo1.Items.Add(p.name);
                    comboBoxMain_ComboPerkTwo2.Items.Add(p.name);
                    comboBoxMain_ComboPerkTwo3.Items.Add(p.name);
                    comboBoxMain_ComboPerkTwo4.Items.Add(p.name);
                    comboBoxMain_ComboPerkTwo5.Items.Add(p.name);
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
            this.checkBoxSettings_ClearEntries.Checked = Properties.Settings.Default.ClearEntries;

            populateSampleOutput();
        }


        private void changeInputToText()
        {
            //Show Textboxes
            textBoxMain_Weapon.Visible = true;
            textBoxMain_WeaponName.Visible = true;
            textBoxMain_Barrel1id.Visible = true;
            textBoxMain_Barrel2id.Visible = true;
            textBoxMain_Barrel3id.Visible = true;
            textBoxMain_Barrel4id.Visible = true;
            textBoxMain_Barrel5id.Visible = true;
            textBoxMain_Barrel6id.Visible = true;
            textBoxMain_Barrel7id.Visible = true;
            textBoxMain_ComboBarrel1.Visible = true;
            textBoxMain_ComboBarrel2.Visible = true;
            textBoxMain_ComboBarrel3.Visible = true;
            textBoxMain_ComboBarrel4.Visible = true;
            textBoxMain_ComboBarrel5.Visible = true;
            textBoxMain_Mag1id.Visible = true;
            textBoxMain_Mag2id.Visible = true;
            textBoxMain_Mag3id.Visible = true;
            textBoxMain_Mag4id.Visible = true;
            textBoxMain_Mag5id.Visible = true;
            textBoxMain_Mag6id.Visible = true;
            textBoxMain_Mag7id.Visible = true;
            textBoxMain_ComboMag1.Visible = true;
            textBoxMain_ComboMag2.Visible = true;
            textBoxMain_ComboMag3.Visible = true;
            textBoxMain_ComboMag4.Visible = true;
            textBoxMain_ComboMag5.Visible = true;
            textBoxMain_PerkOne1id.Visible = true;
            textBoxMain_PerkOne2id.Visible = true;
            textBoxMain_PerkOne3id.Visible = true;
            textBoxMain_PerkOne4id.Visible = true;
            textBoxMain_PerkOne5id.Visible = true;
            textBoxMain_PerkOne6id.Visible = true;
            textBoxMain_PerkOne7id.Visible = true;
            textBoxMain_ComboPerkOne1.Visible = true;
            textBoxMain_ComboPerkOne2.Visible = true;
            textBoxMain_ComboPerkOne3.Visible = true;
            textBoxMain_ComboPerkOne4.Visible = true;
            textBoxMain_ComboPerkOne5.Visible = true;
            textBoxMain_PerkTwo1id.Visible = true;
            textBoxMain_PerkTwo2id.Visible = true;
            textBoxMain_PerkTwo3id.Visible = true;
            textBoxMain_PerkTwo4id.Visible = true;
            textBoxMain_PerkTwo5id.Visible = true;
            textBoxMain_PerkTwo6id.Visible = true;
            textBoxMain_PerkTwo7id.Visible = true;
            textBoxMain_ComboPerkTwo1.Visible = true;
            textBoxMain_ComboPerkTwo2.Visible = true;
            textBoxMain_ComboPerkTwo3.Visible = true;
            textBoxMain_ComboPerkTwo4.Visible = true;
            textBoxMain_ComboPerkTwo5.Visible = true;

            //Hide Dropdowns
            comboBoxMain_Weapon.Visible = false;
            comboBoxMain_Barrel1id.Visible = false;
            comboBoxMain_Barrel2id.Visible = false;
            comboBoxMain_Barrel3id.Visible = false;
            comboBoxMain_Barrel4id.Visible = false;
            comboBoxMain_Barrel5id.Visible = false;
            comboBoxMain_Barrel6id.Visible = false;
            comboBoxMain_Barrel7id.Visible = false;
            comboBoxMain_ComboBarrel1.Visible = false;
            comboBoxMain_ComboBarrel2.Visible = false;
            comboBoxMain_ComboBarrel3.Visible = false;
            comboBoxMain_ComboBarrel4.Visible = false;
            comboBoxMain_ComboBarrel5.Visible = false;
            comboBoxMain_Mag1id.Visible = false;
            comboBoxMain_Mag2id.Visible = false;
            comboBoxMain_Mag3id.Visible = false;
            comboBoxMain_Mag4id.Visible = false;
            comboBoxMain_Mag5id.Visible = false;
            comboBoxMain_Mag6id.Visible = false;
            comboBoxMain_Mag7id.Visible = false;
            comboBoxMain_ComboMag1.Visible = false;
            comboBoxMain_ComboMag2.Visible = false;
            comboBoxMain_ComboMag3.Visible = false;
            comboBoxMain_ComboMag4.Visible = false;
            comboBoxMain_ComboMag5.Visible = false;
            comboBoxMain_PerkOne1id.Visible = false;
            comboBoxMain_PerkOne2id.Visible = false;
            comboBoxMain_PerkOne3id.Visible = false;
            comboBoxMain_PerkOne4id.Visible = false;
            comboBoxMain_PerkOne5id.Visible = false;
            comboBoxMain_PerkOne6id.Visible = false;
            comboBoxMain_PerkOne7id.Visible = false;
            comboBoxMain_ComboPerkOne1.Visible = false;
            comboBoxMain_ComboPerkOne2.Visible = false;
            comboBoxMain_ComboPerkOne3.Visible = false;
            comboBoxMain_ComboPerkOne4.Visible = false;
            comboBoxMain_ComboPerkOne5.Visible = false;
            comboBoxMain_PerkTwo1id.Visible = false;
            comboBoxMain_PerkTwo2id.Visible = false;
            comboBoxMain_PerkTwo3id.Visible = false;
            comboBoxMain_PerkTwo4id.Visible = false;
            comboBoxMain_PerkTwo5id.Visible = false;
            comboBoxMain_PerkTwo6id.Visible = false;
            comboBoxMain_PerkTwo7id.Visible = false;
            comboBoxMain_ComboPerkTwo1.Visible = false;
            comboBoxMain_ComboPerkTwo2.Visible = false;
            comboBoxMain_ComboPerkTwo3.Visible = false;
            comboBoxMain_ComboPerkTwo4.Visible = false;
            comboBoxMain_ComboPerkTwo5.Visible = false;
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
            Properties.Settings.Default.ClearEntries = this.checkBoxSettings_ClearEntries.Checked;

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

            //Populate Rolls
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
                else if (int.TryParse(textBoxMain_Weapon.Text, out n) && weapons.Find(x => x.id == Convert.ToInt64(textBoxMain_Weapon.Text)) != null)
                    name = weapons.Find(x => x.id == Convert.ToInt64(textBoxMain_Weapon.Text)).name;
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

            long weaponId;
            if (textBoxMain_Weapon.Visible)
                weaponId = Convert.ToInt64(textBoxMain_Weapon.Text);
            else
                weaponId = weapons.Find(x => x.name == comboBoxMain_Weapon.Text).id;

            WishlistItem w = new WishlistItem(roll.ToArray(), weaponId);
            textBoxRollInput.Text = w.toString();

            if (Properties.Settings.Default.ClearEntries)
            {
                loadWeaponDropdowns("");
                loadBarrelDropdowns("");
                loadMagDropdowns("");
                loadTraitDropdowns("");
                clearTextEntries();
            }

            tabControl1.SelectTab("TabPageText");
        }

        private void clearTextEntries()
        {
            textBoxMain_Barrel1pve.Clear();
            textBoxMain_Barrel2pve.Clear();
            textBoxMain_Barrel3pve.Clear();
            textBoxMain_Barrel4pve.Clear();
            textBoxMain_Barrel5pve.Clear();
            textBoxMain_Barrel6pve.Clear();
            textBoxMain_Barrel7pve.Clear();
            textBoxMain_Barrel1pvp.Clear();
            textBoxMain_Barrel2pvp.Clear();
            textBoxMain_Barrel3pvp.Clear();
            textBoxMain_Barrel4pvp.Clear();
            textBoxMain_Barrel5pvp.Clear();
            textBoxMain_Barrel6pvp.Clear();
            textBoxMain_Barrel7pvp.Clear();

            textBoxMain_Mag1pve.Clear();
            textBoxMain_Mag2pve.Clear();
            textBoxMain_Mag3pve.Clear();
            textBoxMain_Mag4pve.Clear();
            textBoxMain_Mag5pve.Clear();
            textBoxMain_Mag6pve.Clear();
            textBoxMain_Mag7pve.Clear();
            textBoxMain_Mag1pvp.Clear();
            textBoxMain_Mag2pvp.Clear();
            textBoxMain_Mag3pvp.Clear();
            textBoxMain_Mag4pvp.Clear();
            textBoxMain_Mag5pvp.Clear();
            textBoxMain_Mag6pvp.Clear();
            textBoxMain_Mag7pvp.Clear();

            textBoxMain_PerkOne1pve.Clear();
            textBoxMain_PerkOne2pve.Clear();
            textBoxMain_PerkOne3pve.Clear();
            textBoxMain_PerkOne4pve.Clear();
            textBoxMain_PerkOne5pve.Clear();
            textBoxMain_PerkOne6pve.Clear();
            textBoxMain_PerkOne7pve.Clear();
            textBoxMain_PerkOne1pvp.Clear();
            textBoxMain_PerkOne2pvp.Clear();
            textBoxMain_PerkOne3pvp.Clear();
            textBoxMain_PerkOne4pvp.Clear();
            textBoxMain_PerkOne5pvp.Clear();
            textBoxMain_PerkOne6pvp.Clear();
            textBoxMain_PerkOne7pvp.Clear();

            textBoxMain_PerkTwo1pve.Clear();
            textBoxMain_PerkTwo2pve.Clear();
            textBoxMain_PerkTwo3pve.Clear();
            textBoxMain_PerkTwo4pve.Clear();
            textBoxMain_PerkTwo5pve.Clear();
            textBoxMain_PerkTwo6pve.Clear();
            textBoxMain_PerkTwo7pve.Clear();
            textBoxMain_PerkTwo1pvp.Clear();
            textBoxMain_PerkTwo2pvp.Clear();
            textBoxMain_PerkTwo3pvp.Clear();
            textBoxMain_PerkTwo4pvp.Clear();
            textBoxMain_PerkTwo5pvp.Clear();
            textBoxMain_PerkTwo6pvp.Clear();
            textBoxMain_PerkTwo7pvp.Clear();

            textBoxMain_Combopve1.Clear();
            textBoxMain_Combopve2.Clear();
            textBoxMain_Combopve3.Clear();
            textBoxMain_Combopve4.Clear();
            textBoxMain_Combopve5.Clear();
            textBoxMain_Combopvp1.Clear();
            textBoxMain_Combopvp2.Clear();
            textBoxMain_Combopvp3.Clear();
            textBoxMain_Combopvp4.Clear();
            textBoxMain_Combopvp5.Clear();

            textBoxMain_PvEmw.Text = "";
            textBoxMain_PvPmw.Text = "";
            comboBoxMain_WeaponTier.SelectedIndex = 0;
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
                        roll.Add("//" + float.Parse(textBoxMain_Barrel1pvp.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel1id.Text).id + ":" + comboBoxMain_Barrel1id.Text);
                    if (comboBoxMain_Barrel2id.Visible && comboBoxMain_Barrel2id.Text != "" && textBoxMain_Barrel2pvp.Text != "" && textBoxMain_Barrel2pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel2pvp.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel2id.Text).id + ":" + comboBoxMain_Barrel2id.Text);
                    if (comboBoxMain_Barrel3id.Visible && comboBoxMain_Barrel3id.Text != "" && textBoxMain_Barrel3pvp.Text != "" && textBoxMain_Barrel3pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel3pvp.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel3id.Text).id + ":" + comboBoxMain_Barrel3id.Text);
                    if (comboBoxMain_Barrel4id.Visible && comboBoxMain_Barrel4id.Text != "" && textBoxMain_Barrel4pvp.Text != "" && textBoxMain_Barrel4pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel4pvp.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel4id.Text).id + ":" + comboBoxMain_Barrel4id.Text);
                    if (comboBoxMain_Barrel5id.Visible && comboBoxMain_Barrel5id.Text != "" && textBoxMain_Barrel5pvp.Text != "" && textBoxMain_Barrel5pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel5pvp.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel5id.Text).id + ":" + comboBoxMain_Barrel5id.Text);
                    if (comboBoxMain_Barrel6id.Visible && comboBoxMain_Barrel6id.Text != "" && textBoxMain_Barrel6pvp.Text != "" && textBoxMain_Barrel6pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel6pvp.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel6id.Text).id + ":" + comboBoxMain_Barrel6id.Text);
                    if (comboBoxMain_Barrel7id.Visible && comboBoxMain_Barrel7id.Text != "" && textBoxMain_Barrel7pvp.Text != "" && textBoxMain_Barrel7pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel7pvp.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel7id.Text).id + ":" + comboBoxMain_Barrel7id.Text);
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
                        roll.Add("//" + float.Parse(textBoxMain_Barrel1pve.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel1id.Text).id + ":" + comboBoxMain_Barrel1id.Text);
                    if (comboBoxMain_Barrel2id.Visible && comboBoxMain_Barrel2id.Text != "" && textBoxMain_Barrel2pve.Text != "" && textBoxMain_Barrel2pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel2pve.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel2id.Text).id + ":" + comboBoxMain_Barrel2id.Text);
                    if (comboBoxMain_Barrel3id.Visible && comboBoxMain_Barrel3id.Text != "" && textBoxMain_Barrel3pve.Text != "" && textBoxMain_Barrel3pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel3pve.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel3id.Text).id + ":" + comboBoxMain_Barrel3id.Text);
                    if (comboBoxMain_Barrel4id.Visible && comboBoxMain_Barrel4id.Text != "" && textBoxMain_Barrel4pve.Text != "" && textBoxMain_Barrel4pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel4pve.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel4id.Text).id + ":" + comboBoxMain_Barrel4id.Text);
                    if (comboBoxMain_Barrel5id.Visible && comboBoxMain_Barrel5id.Text != "" && textBoxMain_Barrel5pve.Text != "" && textBoxMain_Barrel5pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel5pve.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel5id.Text).id + ":" + comboBoxMain_Barrel5id.Text);
                    if (comboBoxMain_Barrel6id.Visible && comboBoxMain_Barrel6id.Text != "" && textBoxMain_Barrel6pve.Text != "" && textBoxMain_Barrel6pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel6pve.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel6id.Text).id + ":" + comboBoxMain_Barrel6id.Text);
                    if (comboBoxMain_Barrel7id.Visible && comboBoxMain_Barrel7id.Text != "" && textBoxMain_Barrel7pve.Text != "" && textBoxMain_Barrel7pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Barrel7pve.Text).ToString("0.0") + ":" + barrelPerks.Find(x => x.name == comboBoxMain_Barrel7id.Text).id + ":" + comboBoxMain_Barrel7id.Text);
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
                        roll.Add("//" + float.Parse(textBoxMain_Mag1pvp.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag1id.Text).id + ":" + comboBoxMain_Mag1id.Text);
                    if (comboBoxMain_Mag2id.Visible && comboBoxMain_Mag2id.Text != "" && textBoxMain_Mag2pvp.Text != "" && textBoxMain_Mag2pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag2pvp.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag2id.Text).id + ":" + comboBoxMain_Mag2id.Text);
                    if (comboBoxMain_Mag3id.Visible && comboBoxMain_Mag3id.Text != "" && textBoxMain_Mag3pvp.Text != "" && textBoxMain_Mag3pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag3pvp.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag3id.Text).id + ":" + comboBoxMain_Mag3id.Text);
                    if (comboBoxMain_Mag4id.Visible && comboBoxMain_Mag4id.Text != "" && textBoxMain_Mag4pvp.Text != "" && textBoxMain_Mag4pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag4pvp.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag4id.Text).id + ":" + comboBoxMain_Mag4id.Text);
                    if (comboBoxMain_Mag5id.Visible && comboBoxMain_Mag5id.Text != "" && textBoxMain_Mag5pvp.Text != "" && textBoxMain_Mag5pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag5pvp.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag5id.Text).id + ":" + comboBoxMain_Mag5id.Text);
                    if (comboBoxMain_Mag6id.Visible && comboBoxMain_Mag6id.Text != "" && textBoxMain_Mag6pvp.Text != "" && textBoxMain_Mag6pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag6pvp.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag6id.Text).id + ":" + comboBoxMain_Mag6id.Text);
                    if (comboBoxMain_Mag7id.Visible && comboBoxMain_Mag7id.Text != "" && textBoxMain_Mag7pvp.Text != "" && textBoxMain_Mag7pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag7pvp.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag7id.Text).id + ":" + comboBoxMain_Mag7id.Text);
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
                        roll.Add("//" + float.Parse(textBoxMain_Mag1pve.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag1id.Text).id + ":" + comboBoxMain_Mag1id.Text);
                    if (comboBoxMain_Mag2id.Visible && comboBoxMain_Mag2id.Text != "" && textBoxMain_Mag2pve.Text != "" && textBoxMain_Mag2pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag2pve.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag2id.Text).id + ":" + comboBoxMain_Mag2id.Text);
                    if (comboBoxMain_Mag3id.Visible && comboBoxMain_Mag3id.Text != "" && textBoxMain_Mag3pve.Text != "" && textBoxMain_Mag3pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag3pve.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag3id.Text).id + ":" + comboBoxMain_Mag3id.Text);
                    if (comboBoxMain_Mag4id.Visible && comboBoxMain_Mag4id.Text != "" && textBoxMain_Mag4pve.Text != "" && textBoxMain_Mag4pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag4pve.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag4id.Text).id + ":" + comboBoxMain_Mag4id.Text);
                    if (comboBoxMain_Mag5id.Visible && comboBoxMain_Mag5id.Text != "" && textBoxMain_Mag5pve.Text != "" && textBoxMain_Mag5pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag5pve.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag5id.Text).id + ":" + comboBoxMain_Mag5id.Text);
                    if (comboBoxMain_Mag6id.Visible && comboBoxMain_Mag6id.Text != "" && textBoxMain_Mag6pve.Text != "" && textBoxMain_Mag6pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag6pve.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag6id.Text).id + ":" + comboBoxMain_Mag6id.Text);
                    if (comboBoxMain_Mag7id.Visible && comboBoxMain_Mag7id.Text != "" && textBoxMain_Mag7pve.Text != "" && textBoxMain_Mag7pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_Mag7pve.Text).ToString("0.0") + ":" + magPerks.Find(x => x.name == comboBoxMain_Mag7id.Text).id + ":" + comboBoxMain_Mag7id.Text);
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
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne1pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne1id.Text).id + ":" + comboBoxMain_PerkOne1id.Text);
                    if (comboBoxMain_PerkOne2id.Visible && comboBoxMain_PerkOne2id.Text != "" && textBoxMain_PerkOne2pvp.Text != "" && textBoxMain_PerkOne2pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne2pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne2id.Text).id + ":" + comboBoxMain_PerkOne2id.Text);
                    if (comboBoxMain_PerkOne3id.Visible && comboBoxMain_PerkOne3id.Text != "" && textBoxMain_PerkOne3pvp.Text != "" && textBoxMain_PerkOne3pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne3pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne3id.Text).id + ":" + comboBoxMain_PerkOne3id.Text);
                    if (comboBoxMain_PerkOne4id.Visible && comboBoxMain_PerkOne4id.Text != "" && textBoxMain_PerkOne4pvp.Text != "" && textBoxMain_PerkOne4pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne4pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne4id.Text).id + ":" + comboBoxMain_PerkOne4id.Text);
                    if (comboBoxMain_PerkOne5id.Visible && comboBoxMain_PerkOne5id.Text != "" && textBoxMain_PerkOne5pvp.Text != "" && textBoxMain_PerkOne5pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne5pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne5id.Text).id + ":" + comboBoxMain_PerkOne5id.Text);
                    if (comboBoxMain_PerkOne6id.Visible && comboBoxMain_PerkOne6id.Text != "" && textBoxMain_PerkOne6pvp.Text != "" && textBoxMain_PerkOne6pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne6pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne6id.Text).id + ":" + comboBoxMain_PerkOne6id.Text);
                    if (comboBoxMain_PerkOne7id.Visible && comboBoxMain_PerkOne7id.Text != "" && textBoxMain_PerkOne7pvp.Text != "" && textBoxMain_PerkOne7pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne7pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne7id.Text).id + ":" + comboBoxMain_PerkOne7id.Text);
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
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne1pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne1id.Text).id + ":" + comboBoxMain_PerkOne1id.Text);
                    if (comboBoxMain_PerkOne2id.Visible && comboBoxMain_PerkOne2id.Text != "" && textBoxMain_PerkOne2pve.Text != "" && textBoxMain_PerkOne2pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne2pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne2id.Text).id + ":" + comboBoxMain_PerkOne2id.Text);
                    if (comboBoxMain_PerkOne3id.Visible && comboBoxMain_PerkOne3id.Text != "" && textBoxMain_PerkOne3pve.Text != "" && textBoxMain_PerkOne3pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne3pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne3id.Text).id + ":" + comboBoxMain_PerkOne3id.Text);
                    if (comboBoxMain_PerkOne4id.Visible && comboBoxMain_PerkOne4id.Text != "" && textBoxMain_PerkOne4pve.Text != "" && textBoxMain_PerkOne4pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne4pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne4id.Text).id + ":" + comboBoxMain_PerkOne4id.Text);
                    if (comboBoxMain_PerkOne5id.Visible && comboBoxMain_PerkOne5id.Text != "" && textBoxMain_PerkOne5pve.Text != "" && textBoxMain_PerkOne5pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne5pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne5id.Text).id + ":" + comboBoxMain_PerkOne5id.Text);
                    if (comboBoxMain_PerkOne6id.Visible && comboBoxMain_PerkOne6id.Text != "" && textBoxMain_PerkOne6pve.Text != "" && textBoxMain_PerkOne6pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne6pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne6id.Text).id + ":" + comboBoxMain_PerkOne6id.Text);
                    if (comboBoxMain_PerkOne7id.Visible && comboBoxMain_PerkOne7id.Text != "" && textBoxMain_PerkOne7pve.Text != "" && textBoxMain_PerkOne7pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkOne7pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkOne7id.Text).id + ":" + comboBoxMain_PerkOne7id.Text);
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
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo1pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo1id.Text).id + ":" + comboBoxMain_PerkTwo1id.Text);
                    if (comboBoxMain_PerkTwo2id.Visible && comboBoxMain_PerkTwo2id.Text != "" && textBoxMain_PerkTwo2pvp.Text != "" && textBoxMain_PerkTwo2pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo2pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo2id.Text).id + ":" + comboBoxMain_PerkTwo2id.Text);
                    if (comboBoxMain_PerkTwo3id.Visible && comboBoxMain_PerkTwo3id.Text != "" && textBoxMain_PerkTwo3pvp.Text != "" && textBoxMain_PerkTwo3pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo3pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo3id.Text).id + ":" + comboBoxMain_PerkTwo3id.Text);
                    if (comboBoxMain_PerkTwo4id.Visible && comboBoxMain_PerkTwo4id.Text != "" && textBoxMain_PerkTwo4pvp.Text != "" && textBoxMain_PerkTwo4pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo4pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo4id.Text).id + ":" + comboBoxMain_PerkTwo4id.Text);
                    if (comboBoxMain_PerkTwo5id.Visible && comboBoxMain_PerkTwo5id.Text != "" && textBoxMain_PerkTwo5pvp.Text != "" && textBoxMain_PerkTwo5pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo5pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo5id.Text).id + ":" + comboBoxMain_PerkTwo5id.Text);
                    if (comboBoxMain_PerkTwo6id.Visible && comboBoxMain_PerkTwo6id.Text != "" && textBoxMain_PerkTwo6pvp.Text != "" && textBoxMain_PerkTwo6pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo6pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo6id.Text).id + ":" + comboBoxMain_PerkTwo6id.Text);
                    if (comboBoxMain_PerkTwo7id.Visible && comboBoxMain_PerkTwo7id.Text != "" && textBoxMain_PerkTwo7pvp.Text != "" && textBoxMain_PerkTwo7pvp.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo7pvp.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo7id.Text).id + ":" + comboBoxMain_PerkTwo7id.Text);
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
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo1pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo1id.Text).id + ":" + comboBoxMain_PerkTwo1id.Text);
                    if (comboBoxMain_PerkTwo2id.Visible && comboBoxMain_PerkTwo2id.Text != "" && textBoxMain_PerkTwo2pve.Text != "" && textBoxMain_PerkTwo2pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo2pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo2id.Text).id + ":" + comboBoxMain_PerkTwo2id.Text);
                    if (comboBoxMain_PerkTwo3id.Visible && comboBoxMain_PerkTwo3id.Text != "" && textBoxMain_PerkTwo3pve.Text != "" && textBoxMain_PerkTwo3pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo3pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo3id.Text).id + ":" + comboBoxMain_PerkTwo3id.Text);
                    if (comboBoxMain_PerkTwo4id.Visible && comboBoxMain_PerkTwo4id.Text != "" && textBoxMain_PerkTwo4pve.Text != "" && textBoxMain_PerkTwo4pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo4pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo4id.Text).id + ":" + comboBoxMain_PerkTwo4id.Text);
                    if (comboBoxMain_PerkTwo5id.Visible && comboBoxMain_PerkTwo5id.Text != "" && textBoxMain_PerkTwo5pve.Text != "" && textBoxMain_PerkTwo5pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo5pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo5id.Text).id + ":" + comboBoxMain_PerkTwo5id.Text);
                    if (comboBoxMain_PerkTwo6id.Visible && comboBoxMain_PerkTwo6id.Text != "" && textBoxMain_PerkTwo6pve.Text != "" && textBoxMain_PerkTwo6pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo6pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo6id.Text).id + ":" + comboBoxMain_PerkTwo6id.Text);
                    if (comboBoxMain_PerkTwo7id.Visible && comboBoxMain_PerkTwo7id.Text != "" && textBoxMain_PerkTwo7pve.Text != "" && textBoxMain_PerkTwo7pve.Text != "0")
                        roll.Add("//" + float.Parse(textBoxMain_PerkTwo7pve.Text).ToString("0.0") + ":" + traitPerks.Find(x => x.name == comboBoxMain_PerkTwo7id.Text).id + ":" + comboBoxMain_PerkTwo7id.Text);
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
                            s += getValueOrZero(comboBoxMain_ComboBarrel1.Text, barrelPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel1.Text) + ",";

                        if (comboBoxMain_ComboMag1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag1.Text, magPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag1.Text) + ",";

                        if (comboBoxMain_ComboPerkOne1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne1.Text, traitPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne1.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo1.Text, traitPerks) + ":" + float.Parse(textBoxMain_Combopvp1.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo1.Text) + ":" + float.Parse(textBoxMain_Combopvp1.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopvp2.Text != "" && textBoxMain_Combopvp2.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel2.Text, barrelPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel2.Text) + ",";

                        if (comboBoxMain_ComboMag2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag2.Text, magPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag2.Text) + ",";

                        if (comboBoxMain_ComboPerkOne2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne2.Text, traitPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne2.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo2.Text, traitPerks) + ":" + float.Parse(textBoxMain_Combopvp2.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo2.Text) + ":" + float.Parse(textBoxMain_Combopvp2.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopvp3.Text != "" && textBoxMain_Combopvp3.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel3.Text, barrelPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel3.Text) + ",";

                        if (comboBoxMain_ComboMag3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag3.Text, magPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag3.Text) + ",";

                        if (comboBoxMain_ComboPerkOne3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne3.Text, traitPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne3.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo3.Text, traitPerks) + ":" + float.Parse(textBoxMain_Combopvp3.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo3.Text) + ":" + float.Parse(textBoxMain_Combopvp3.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopvp4.Text != "" && textBoxMain_Combopvp4.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel4.Text, barrelPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel4.Text) + ",";

                        if (comboBoxMain_ComboMag4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag4.Text, magPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag4.Text) + ",";

                        if (comboBoxMain_ComboPerkOne4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne4.Text, traitPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne4.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo4.Text, traitPerks) + ":" + float.Parse(textBoxMain_Combopvp4.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo4.Text) + ":" + float.Parse(textBoxMain_Combopvp4.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopvp5.Text != "" && textBoxMain_Combopvp5.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel5.Text, barrelPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel5.Text) + ",";

                        if (comboBoxMain_ComboMag5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag5.Text, magPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag5.Text) + ",";

                        if (comboBoxMain_ComboPerkOne5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne5.Text, traitPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne5.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo5.Text, traitPerks) + ":" + float.Parse(textBoxMain_Combopvp5.Text).ToString("0.0");
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
                            s += getValueOrZero(comboBoxMain_ComboBarrel1.Text, barrelPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel1.Text) + ",";

                        if (comboBoxMain_ComboMag1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag1.Text, magPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag1.Text) + ",";

                        if (comboBoxMain_ComboPerkOne1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne1.Text, traitPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne1.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo1.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo1.Text, traitPerks) + ":" + float.Parse(textBoxMain_Combopve1.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo1.Text) + ":" + float.Parse(textBoxMain_Combopve1.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopve2.Text != "" && textBoxMain_Combopve2.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel2.Text, barrelPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel2.Text) + ",";

                        if (comboBoxMain_ComboMag2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag2.Text, magPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag2.Text) + ",";

                        if (comboBoxMain_ComboPerkOne2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne2.Text, traitPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne2.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo2.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo2.Text, traitPerks) + ":" + float.Parse(textBoxMain_Combopve2.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo2.Text) + ":" + float.Parse(textBoxMain_Combopve2.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopve3.Text != "" && textBoxMain_Combopve3.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel3.Text, barrelPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel3.Text) + ",";

                        if (comboBoxMain_ComboMag3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag3.Text, magPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag3.Text) + ",";

                        if (comboBoxMain_ComboPerkOne3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne3.Text, traitPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne3.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo3.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo3.Text, traitPerks) + ":" + float.Parse(textBoxMain_Combopve3.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo3.Text) + ":" + float.Parse(textBoxMain_Combopve3.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopve4.Text != "" && textBoxMain_Combopve4.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel4.Text, barrelPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel4.Text) + ",";

                        if (comboBoxMain_ComboMag4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag4.Text, magPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag4.Text) + ",";

                        if (comboBoxMain_ComboPerkOne4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne4.Text, traitPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne4.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo4.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo4.Text, traitPerks) + ":" + float.Parse(textBoxMain_Combopve4.Text).ToString("0.0");
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkTwo4.Text) + ":" + float.Parse(textBoxMain_Combopve4.Text).ToString("0.0");

                        roll.Add(s);
                    }

                    if (textBoxMain_Combopve5.Text != "" && textBoxMain_Combopve5.Text != "0")
                    {
                        string s = "//";

                        if (comboBoxMain_ComboBarrel5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboBarrel5.Text, barrelPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboBarrel5.Text) + ",";

                        if (comboBoxMain_ComboMag5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboMag5.Text, magPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboMag5.Text) + ",";

                        if (comboBoxMain_ComboPerkOne5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkOne5.Text, traitPerks) + ",";
                        else
                            s += getValueOrZero(textBoxMain_ComboPerkOne5.Text) + ",";

                        if (comboBoxMain_ComboPerkTwo5.Visible)
                            s += getValueOrZero(comboBoxMain_ComboPerkTwo5.Text, traitPerks) + ":" + float.Parse(textBoxMain_Combopve5.Text).ToString("0.0");
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

        private string getValueOrZero(string s, List<Perk> p)
        {
            if (s == null || s == "")
                return "0";
            if (p.Find(x => x.name == s) != null)
                return p.Find(x => x.name == s).id.ToString();

            return "0";
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

                //Simulate re-selecting item in dropdown
                comboBoxMain_Weapon_SelectedIndexChanged(sender, e);
            }
            else
            {
                textBoxMain_Weapon.Visible = true;
                labelMain_WeaponName.Visible = true;
                textBoxMain_WeaponName.Visible = true;
                comboBoxMain_Weapon.Visible = false;

                if (customDropdowns)
                {
                    loadBarrelDropdowns("");
                    loadMagDropdowns("");
                    loadTraitDropdowns("");
                    customDropdowns = false;
                }
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
            if (int.TryParse(textBoxMain_Weapon.Text, out n) && weapons.Find(x => x.id == Convert.ToInt64(textBoxMain_Weapon.Text)) != null)
                textBoxMain_WeaponName.Text = weapons.Find(x => x.id == Convert.ToInt64(textBoxMain_Weapon.Text)).name;
        }

        private void comboBoxMain_Weapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMain_Weapon.Text == null || comboBoxMain_Weapon.Text == "")
            {
                if (customDropdowns)
                {
                    loadBarrelDropdowns("");
                    loadMagDropdowns("");
                    loadTraitDropdowns("");
                    customDropdowns = false;
                }
                return;
            }

            //Load Custom Dropdowns
            string perk1Group = weapons.Find(x => x.name == comboBoxMain_Weapon.Text).perk1Group;
            string perk2Group = weapons.Find(x => x.name == comboBoxMain_Weapon.Text).perk2Group;

             loadBarrelDropdowns(perk1Group);
             loadMagDropdowns(perk2Group);

        }

        private void comboBoxMain_GameType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMain_GameType.Text == "Both")
            {
                if (!textBoxMain_Barrel1pve.Visible)
                    ShowPvE();
                if (!textBoxMain_Barrel1pvp.Visible)
                    ShowPvP();
            }
            else if (comboBoxMain_GameType.Text == "PvE Only" || comboBoxMain_GameType.Text == "PvE/PvP")
            {
                if (!textBoxMain_Barrel1pve.Visible)
                    ShowPvE();
                if (textBoxMain_Barrel1pvp.Visible)
                    HidePvP();
            }
            else if (comboBoxMain_GameType.Text == "PvP Only")
            {
                if (textBoxMain_Barrel1pve.Visible)
                    HidePvE();
                if (!textBoxMain_Barrel1pvp.Visible)
                    ShowPvP();
            }
        }
        
        private void loadGameMode()
        {
            if (comboBoxMain_GameType.Text == "PvE Only" || comboBoxMain_GameType.Text == "PvE/PvP")
            {
                HidePvP();
            }
            else if (comboBoxMain_GameType.Text == "PvP Only")
            {
                HidePvE();
            }
        }

        private void ShowPvP()
        {
            //Barrel
            labelMain_Barrelpvp.Visible = true;
            textBoxMain_Barrel1pvp.Visible = true;
            textBoxMain_Barrel2pvp.Visible = true;
            textBoxMain_Barrel3pvp.Visible = true;
            textBoxMain_Barrel4pvp.Visible = true;
            textBoxMain_Barrel5pvp.Visible = true;
            textBoxMain_Barrel6pvp.Visible = true;
            textBoxMain_Barrel7pvp.Visible = true;

            //Mag
            labelMain_Magpvp.Visible = true;
            textBoxMain_Mag1pvp.Visible = true;
            textBoxMain_Mag2pvp.Visible = true;
            textBoxMain_Mag3pvp.Visible = true;
            textBoxMain_Mag4pvp.Visible = true;
            textBoxMain_Mag5pvp.Visible = true;
            textBoxMain_Mag6pvp.Visible = true;
            textBoxMain_Mag7pvp.Visible = true;

            //Perk 1
            labelMain_Perk1pvp.Visible = true;
            textBoxMain_PerkOne1pvp.Visible = true;
            textBoxMain_PerkOne2pvp.Visible = true;
            textBoxMain_PerkOne3pvp.Visible = true;
            textBoxMain_PerkOne4pvp.Visible = true;
            textBoxMain_PerkOne5pvp.Visible = true;
            textBoxMain_PerkOne6pvp.Visible = true;
            textBoxMain_PerkOne7pvp.Visible = true;

            //Perk 2
            labelMain_Perk2pvp.Visible = true;
            textBoxMain_PerkTwo1pvp.Visible = true;
            textBoxMain_PerkTwo2pvp.Visible = true;
            textBoxMain_PerkTwo3pvp.Visible = true;
            textBoxMain_PerkTwo4pvp.Visible = true;
            textBoxMain_PerkTwo5pvp.Visible = true;
            textBoxMain_PerkTwo6pvp.Visible = true;
            textBoxMain_PerkTwo7pvp.Visible = true;

            //Combos
            labelMain_combopvp.Visible = true;
            textBoxMain_Combopvp1.Visible = true;
            textBoxMain_Combopvp2.Visible = true;
            textBoxMain_Combopvp3.Visible = true;
            textBoxMain_Combopvp4.Visible = true;
            textBoxMain_Combopvp5.Visible = true;

            labelMain_PvPmw.Visible = true;
            textBoxMain_PvPmw.Visible = true;
        }

        private void HidePvP()
        {
            //Barrel
            labelMain_Barrelpvp.Visible = false;
            textBoxMain_Barrel1pvp.Visible = false;
            textBoxMain_Barrel2pvp.Visible = false;
            textBoxMain_Barrel3pvp.Visible = false;
            textBoxMain_Barrel4pvp.Visible = false;
            textBoxMain_Barrel5pvp.Visible = false;
            textBoxMain_Barrel6pvp.Visible = false;
            textBoxMain_Barrel7pvp.Visible = false;

            //Mag
            labelMain_Magpvp.Visible = false;
            textBoxMain_Mag1pvp.Visible = false;
            textBoxMain_Mag2pvp.Visible = false;
            textBoxMain_Mag3pvp.Visible = false;
            textBoxMain_Mag4pvp.Visible = false;
            textBoxMain_Mag5pvp.Visible = false;
            textBoxMain_Mag6pvp.Visible = false;
            textBoxMain_Mag7pvp.Visible = false;

            //Perk 1
            labelMain_Perk1pvp.Visible = false;
            textBoxMain_PerkOne1pvp.Visible = false;
            textBoxMain_PerkOne2pvp.Visible = false;
            textBoxMain_PerkOne3pvp.Visible = false;
            textBoxMain_PerkOne4pvp.Visible = false;
            textBoxMain_PerkOne5pvp.Visible = false;
            textBoxMain_PerkOne6pvp.Visible = false;
            textBoxMain_PerkOne7pvp.Visible = false;

            //Perk 2
            labelMain_Perk2pvp.Visible = false;
            textBoxMain_PerkTwo1pvp.Visible = false;
            textBoxMain_PerkTwo2pvp.Visible = false;
            textBoxMain_PerkTwo3pvp.Visible = false;
            textBoxMain_PerkTwo4pvp.Visible = false;
            textBoxMain_PerkTwo5pvp.Visible = false;
            textBoxMain_PerkTwo6pvp.Visible = false;
            textBoxMain_PerkTwo7pvp.Visible = false;

            //Combos
            labelMain_combopvp.Visible = false;
            textBoxMain_Combopvp1.Visible = false;
            textBoxMain_Combopvp2.Visible = false;
            textBoxMain_Combopvp3.Visible = false;
            textBoxMain_Combopvp4.Visible = false;
            textBoxMain_Combopvp5.Visible = false;

            labelMain_PvPmw.Visible = false;
            textBoxMain_PvPmw.Visible = false;
        }


        private void ShowPvE()
        {
            //Barrel
            labelMain_Barrelpve.Visible = true;
            textBoxMain_Barrel1pve.Visible = true;
            textBoxMain_Barrel2pve.Visible = true;
            textBoxMain_Barrel3pve.Visible = true;
            textBoxMain_Barrel4pve.Visible = true;
            textBoxMain_Barrel5pve.Visible = true;
            textBoxMain_Barrel6pve.Visible = true;
            textBoxMain_Barrel7pve.Visible = true;

            //Mag
            labelMain_Magpve.Visible = true;
            textBoxMain_Mag1pve.Visible = true;
            textBoxMain_Mag2pve.Visible = true;
            textBoxMain_Mag3pve.Visible = true;
            textBoxMain_Mag4pve.Visible = true;
            textBoxMain_Mag5pve.Visible = true;
            textBoxMain_Mag6pve.Visible = true;
            textBoxMain_Mag7pve.Visible = true;

            //Perk 1
            labelMain_Perk1pve.Visible = true;
            textBoxMain_PerkOne1pve.Visible = true;
            textBoxMain_PerkOne2pve.Visible = true;
            textBoxMain_PerkOne3pve.Visible = true;
            textBoxMain_PerkOne4pve.Visible = true;
            textBoxMain_PerkOne5pve.Visible = true;
            textBoxMain_PerkOne6pve.Visible = true;
            textBoxMain_PerkOne7pve.Visible = true;

            //Perk 2
            labelMain_Perk2pve.Visible = true;
            textBoxMain_PerkTwo1pve.Visible = true;
            textBoxMain_PerkTwo2pve.Visible = true;
            textBoxMain_PerkTwo3pve.Visible = true;
            textBoxMain_PerkTwo4pve.Visible = true;
            textBoxMain_PerkTwo5pve.Visible = true;
            textBoxMain_PerkTwo6pve.Visible = true;
            textBoxMain_PerkTwo7pve.Visible = true;

            //Combos
            labelMain_combopve.Visible = true;
            textBoxMain_Combopve1.Visible = true;
            textBoxMain_Combopve2.Visible = true;
            textBoxMain_Combopve3.Visible = true;
            textBoxMain_Combopve4.Visible = true;
            textBoxMain_Combopve5.Visible = true;

            labelMain_PvEmw.Visible = true;
            textBoxMain_PvEmw.Visible = true;
        }

        private void HidePvE()
        {
            //Barrel
            labelMain_Barrelpve.Visible = false;
            textBoxMain_Barrel1pve.Visible = false;
            textBoxMain_Barrel2pve.Visible = false;
            textBoxMain_Barrel3pve.Visible = false;
            textBoxMain_Barrel4pve.Visible = false;
            textBoxMain_Barrel5pve.Visible = false;
            textBoxMain_Barrel6pve.Visible = false;
            textBoxMain_Barrel7pve.Visible = false;

            //Mag
            labelMain_Magpve.Visible = false;
            textBoxMain_Mag1pve.Visible = false;
            textBoxMain_Mag2pve.Visible = false;
            textBoxMain_Mag3pve.Visible = false;
            textBoxMain_Mag4pve.Visible = false;
            textBoxMain_Mag5pve.Visible = false;
            textBoxMain_Mag6pve.Visible = false;
            textBoxMain_Mag7pve.Visible = false;

            //Perk 1
            labelMain_Perk1pve.Visible = false;
            textBoxMain_PerkOne1pve.Visible = false;
            textBoxMain_PerkOne2pve.Visible = false;
            textBoxMain_PerkOne3pve.Visible = false;
            textBoxMain_PerkOne4pve.Visible = false;
            textBoxMain_PerkOne5pve.Visible = false;
            textBoxMain_PerkOne6pve.Visible = false;
            textBoxMain_PerkOne7pve.Visible = false;

            //Perk 2
            labelMain_Perk2pve.Visible = false;
            textBoxMain_PerkTwo1pve.Visible = false;
            textBoxMain_PerkTwo2pve.Visible = false;
            textBoxMain_PerkTwo3pve.Visible = false;
            textBoxMain_PerkTwo4pve.Visible = false;
            textBoxMain_PerkTwo5pve.Visible = false;
            textBoxMain_PerkTwo6pve.Visible = false;
            textBoxMain_PerkTwo7pve.Visible = false;

            //Combos
            labelMain_combopve.Visible = false;
            textBoxMain_Combopve1.Visible = false;
            textBoxMain_Combopve2.Visible = false;
            textBoxMain_Combopve3.Visible = false;
            textBoxMain_Combopve4.Visible = false;
            textBoxMain_Combopve5.Visible = false;

            labelMain_PvEmw.Visible = false;
            textBoxMain_PvEmw.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/scspriggy/Spriggys-Wishlist");
        }
    }
}
