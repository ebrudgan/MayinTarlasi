using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Tarla mayin_tarlam;
        Image mayin_Resmi = Image.FromFile(Environment.CurrentDirectory+@"\mayin.jpg");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
    }
        List<Mayin> mayinlarimiz;
       
       
        private void Form1_Load(object sender, EventArgs e)
        {
            mayin_tarlam = new Tarla(new Size(400, 400),60);
            panel1.Size = mayin_tarlam.buyuklugu;
            MayinEkle();
        }
        public void MayinEkle()
        {
            for (int x = 0; x < panel1.Width; x = x + 20)
            {
                for (int y = 0; y < panel1.Height; y = y + 20)
                {
                    ButtonEkle(new Point(x, y));
                }
            }
            
        }
        public void ButtonEkle(Point loc)
        {
            Button btn = new Button();
            btn.Name = loc.X + "" + loc.Y;
            btn.Size = new Size(20,20);
            btn.Location = loc;
            btn.Click += new EventHandler(Btn_Click);
            panel1.Controls.Add(btn);
        }

        public void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            Mayin myn = mayin_tarlam.mayin_al_loc(btn.Location);
            mayinlarimiz = new List<Mayin>();
            if (myn.mayin_var_mi)
            {
                MessageBox.Show("Game Over");
                Mayinlari_goster();
            }
            else
            {
                int s = etrafta_kac_mayin_var(myn);
                if (s == 0)
                {
                    mayinlarimiz.Add(myn);
                    for (int i = 0; i < mayinlarimiz.Count; i++)
                    {
                        Mayin item = mayinlarimiz[i];
                        if (item != null)
                        {
                            if (item.bakildi_mi==false &&item.mayin_var_mi==false)
                            {
                                Button btnx = (Button)panel1.Controls.Find(item.KonumAl.X + "" + item.KonumAl.Y, false)[0];
                                if (etrafta_kac_mayin_var(mayinlarimiz[i]) == 0)
                                {

                                    btnx.Enabled = false;
                                    item.bakildi_mi = true;
                                    cevre_ekle(item);
                                }
                                else
                                {
                                    btnx.Text = etrafta_kac_mayin_var(item).ToString();
                                }
                                item.bakildi_mi = true;
                            }
                        }
                    }
                }
                else
                {
                    btn.Text = s.ToString();
                }
            }
        }
        public int etrafta_kac_mayin_var(Mayin m)
        {
            int sayi = 0;
            if (m.KonumAl.X > 0)
            {
                if (mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X - 20, m.KonumAl.Y)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.Y < panel1.Height - 20 && m.KonumAl.X < panel1.Width - 20)
            {
                if (mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X + 20, m.KonumAl.Y + 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.X < panel1.Width - 20)
            {

                if (mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X + 20, m.KonumAl.Y)).mayin_var_mi)
                {
                    sayi++;
                }
            }

            if (m.KonumAl.X > 0 && m.KonumAl.Y > 0)
            {
                if (mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X - 20, m.KonumAl.Y - 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.Y > 0)
            {
                if (mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X, m.KonumAl.Y - 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.X > 0 && m.KonumAl.Y < panel1.Height)
            {
                if (mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X - 20, m.KonumAl.Y + 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            if (m.KonumAl.X < panel1.Height)
            {
                if (mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X, m.KonumAl.Y + 20)).mayin_var_mi)
                {
                    sayi++;
                }
            }
            
            return sayi;
        }
        public void cevre_ekle(Mayin m)
        {
            bool b1=false;
            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            if (m.KonumAl.X > 0)
            {
                mayinlarimiz.Add(mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X - 20, m.KonumAl.Y)));
                b1 = true;
            }
            if (m.KonumAl.Y> 0)
            {
                mayinlarimiz.Add(mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X , m.KonumAl.Y - 20)));
                b2 = true;
            }
            if (m.KonumAl.X < panel1.Width)
            {
                mayinlarimiz.Add(mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X+20, m.KonumAl.Y )));
                b3 = true;
            }
            if (m.KonumAl.Y< panel1.Height)
            {
                mayinlarimiz.Add(mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X, m.KonumAl.Y+20)));
                b4 = true;
            }
            if(b1 && b2)
            {
                mayinlarimiz.Add(mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X - 20, m.KonumAl.Y-20)));
            }
            if (b1 && b2)
            {
                mayinlarimiz.Add(mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X - 20, m.KonumAl.Y + 20)));
            }
            if (b2 && b3)
            {
                mayinlarimiz.Add(mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X + 20, m.KonumAl.Y - 20)));
            }
            if (b2 && b4)
            {
                mayinlarimiz.Add(mayin_tarlam.mayin_al_loc(new Point(m.KonumAl.X +20, m.KonumAl.Y + 20)));
            }

        }
        public void Mayinlari_goster()
        {
            foreach(Mayin item in mayin_tarlam.GetAllMayin)
            {
                if (item.mayin_var_mi)
                {
                    Button btn = (Button)panel1.Controls.Find(item.KonumAl.X + "" + item.KonumAl.Y, false)[0];
                    btn.BackgroundImage = mayin_Resmi;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }
    }
    }
