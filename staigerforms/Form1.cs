using Microsoft.VisualBasic;
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

namespace staigerforms
{
    public partial class Form1 : Form
    {
        Button btn;
        TreeView tree;
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2;
        TextBox txt_box;
        PictureBox picture;
        TabControl tabControl;
        TabPage page1, page2, page3;
        ListBox lbox;
        DataSet dataSet;
        Color[] Colors_list;

        public Form1()
        {
            this.Height = 500;
            this.Width = 800;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elementid");

            tn.Nodes.Add(new TreeNode("Nupp-Button"));
            //button
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(200, 100);
            btn.Height = 40;
            btn.Width = 120;
            btn.Click += Btn_Click;

            tn.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Tarkvara arendajad";
            lbl.Size = new Size(150, 30);
            lbl.Location = new Point(150, 200);

            tn.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstkast-Textbox"));
            tn.Nodes.Add(new TreeNode("PictureBox"));
            tn.Nodes.Add(new TreeNode("Kaart--TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("DataGridView"));
            tn.Nodes.Add(new TreeNode("Menu"));

            tree.Nodes.Add(tn);

            this.Controls.Add(tree);

        }



        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp-Button")
            {

                this.Controls.Add(btn);

            }
            else if (e.Node.Text == "Silt-Label")
            {
                lbl = new Label();
                lbl.Text = "Tarkvara arendajad";
                lbl.Size = new Size(150, 30);
                lbl.Location = new Point(150, 200);

                this.Controls.Add(lbl);
            }

            else if (e.Node.Text == "Märkeruut-Checkbox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita nupp";
                box_btn.Location = new Point(200, 30);
                this.Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Näita silt";
                box_lbl.Location = new Point(200, 70);
                this.Controls.Add(box_lbl);
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;


            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = " Nupp Vasakule";
                r1.Location = new Point(300, 30);
                r1.CheckedChanged += new EventHandler(RadioButtons_Changed);
                this.Controls.Add(r1);
                r2 = new RadioButton();
                r2.Location = new Point(300, 70);
                r2.Text = "Nupp Paremale";
                this.Controls.Add(r2);
                r2.CheckedChanged += new EventHandler(RadioButtons_Changed);

            }

            else if (e.Node.Text == "Tekstkast-Textbox")
            {
                string text;
                try
                {
                    text = File.ReadAllText(path: "text.txt");
                }
                catch (FileNotFoundException)
                {
                    text = "text puudub";
                }
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = text;
                txt_box.Location = new Point(300, 300);
                txt_box.Width = 100;
                txt_box.Height = 100;
                this.Controls.Add(txt_box);

            }
            else if (e.Node.Text == "PictureBox")
            {
                picture = new PictureBox();
                picture.Image = new Bitmap("pic.png");
                picture.Location = new Point(350, 200);
                picture.Size = new Size(100, 100);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(picture);
            }
            else if (e.Node.Text == "Kaart--TabControl")
            {

                tabControl = new TabControl();
                tabControl.Location = new Point(300, 300);
                tabControl.Size = new Size(200, 100);
                page1 = new TabPage("Esimene");

                page2 = new TabPage("Teine");
                page3 = new TabPage("Kolmas");
                tabControl.SelectedIndex = 1;
                tabControl.SelectedIndex = 2;
                tabControl.SelectedIndex = 3;

                this.Controls.Add(tabControl);

                var answer = MessageBox.Show("Tahad InpudBoxi naha?", "aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {

                    string text = Interaction.InputBox("Открытие вкладки", "InputBox", "Введите номер вкладки 1,2,3");
                    if (text == "1")
                    {
                        page1.BackColor = Color.Red;
                        tabControl.Controls.Add(page1);
                        tabControl.SelectedTab = page1;
                    }
                    else if (text == "2")
                    {
                        page2.BackColor = Color.Blue;
                        tabControl.Controls.Add(page2);
                        tabControl.SelectedTab = page2;
                    }

                    else if (text == "3")
                    {
                        tabControl.Controls.Add(page3);
                        tabControl.SelectedTab = page3;
                    }

                }




            }

            else if (e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MessageBox", "Kõige listsam aken");
                var answer = MessageBox.Show("Tahad InpudBoxi naha?", "aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi Tekst");
                    if (MessageBox.Show("Kas tahad tekst saada Tekstakastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);

                    }

                }


            }


            else if (e.Node.Text == "ListBox")
            {
                string[] Colors_nimetused = new string[] { "Kollane", "Punane", "Roheline", "Sinine" };
                Colors_list = new Color[] { Color.Yellow, Color.Red, Color.Green, Color.Blue };



                lbox = new ListBox();

                foreach (var item in Colors_nimetused)
                {
                    lbox.Items.Add(item);
                }




                lbox.Location = new Point(550, 350);
                lbox.Width = Colors_nimetused.OrderByDescending(n => n.Length).First().Length * 15;
                lbox.Height = Colors_nimetused.Length * 15;
                lbox.SelectedIndexChanged += Lbox_SelectedIndexChanged;
                Controls.Add(lbox);







            }
            else if (e.Node.Text == "DataGridView")
            {
                DataSet dataset = new DataSet("Näide");
                dataset.ReadXml("..//..//Files//excample.xml");
                DataGridView dgv = new DataGridView();
                dgv.Location = new Point(480, 50);
                dgv.Height = 250;
                dgv.Width = 250;
                dgv.AutoGenerateColumns = true;
                dgv.DataMember = "Food";
                dgv.DataSource = dataSet;
                Controls.Add(dgv);
            }
            else if (e.Node.Text == "Menu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuItem1 = new MenuItem("File");
                menuItem1.MenuItems.Add("Exit", new EventHandler(menuItem1_Exit));
                menu.MenuItems.Add(menuItem1);

                MenuItem menuItem2 = new MenuItem("Settings");
                menuItem2.MenuItems.Add("Random Color", new EventHandler(menuItem2_Color));
                menuItem2.MenuItems.Add("Reset", new EventHandler(menuItem3_Reset));
                menu.MenuItems.Add(menuItem2);
                this.Menu = menu;

            }
        }

        private void menuItem3_Reset(object sender, EventArgs e)
        {
            Controls.Clear();
            Controls.Add(tree);
            BackColor = DefaultBackColor;
        }

        private Random rnd = new Random();

        private void menuItem2_Color(object sender, EventArgs e)
        {
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            BackColor = randomColor;

        }

        private void menuItem1_Exit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kas oled kindel?", "Küsimus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Dispose(); //Завершение работы приложения
            }
        }

        private void Lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            lb.BackColor = Colors_list[lbox.SelectedIndex];
        }

        private void RadioButtons_Changed(object sender, EventArgs e)
        {

            if (r1.Checked)
            {
                btn.Location = new Point(150, 100);
            }
            else if (r2.Checked)
            {
                btn.Location = new Point(400,100);
            }
        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (box_btn.Checked)
            {
                Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (btn.BackColor == Color.Gray) 
            {
                btn.BackColor = Color.Blue;
                lbl.BackColor = Color.Green;
                lbl.ForeColor = Color.White;
            }
            else if (btn.BackColor == Color.Blue)
            {
                btn.BackColor = Color.Red;
                
            }
            else
            {
                lbl.BackColor = Color.White;
                lbl.ForeColor = Color.Green;
                btn.BackColor = Color.Gray;
            }
            

        }
    }
}
