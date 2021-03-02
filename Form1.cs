using DarkUI.Controls;
using DarkUI.Forms;
using FlawCraLib2.Net;
using Memory;
using QuickType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Hydra
{
    public partial class Form1 : DarkForm
    {

        Mem m = new Mem();
        List<DarkCheckBox> boxes = new List<DarkCheckBox>();
        public static CheatList cl;
        int y = 25;
        int x = 25;
        int num = 0;

        public static bool cheatLoaded = false;


        public Form1()
        {
            InitializeComponent();
            darkButton1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cl = CheatList.FromJson(new FCWebRequest("https://api.flawcra.cc/fcheatlauncher/cheatlist/").GetResponse());
            listBox1.DisplayMember = "Name";
            foreach (CheatListCheat cheat in cl.Cheats)
            {
                listBox1.Items.Add(cheat);
            }
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            cheatLoaded = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                lockList();
                CheatListCheat cheat = ((CheatListCheat)listBox1.SelectedItem);
                    if (m.OpenProcess(m.GetProcIdFromName(cheat.Procname)))
                    {
                        darkLabel1.Text = cheat.Name;

                        foreach (CheatCheat c in cheat.Cheats)
                        {
                            DarkCheckBox box = new DarkCheckBox();
                            box.Text = c.Name;
                            box.Location = new Point(x, y);
                            x += (25 * 8);
                            num++;
                            if (num > 2)
                            {
                                y += 25;
                                x = 25;
                                num = 0;
                            }

                            Thread wmThread = new Thread(() =>
                            {
                                while (cheatLoaded)
                                {
                                    try
                                    {
                                        if (box.Checked)
                                            m.WriteMemory(c.Address, c.Type, c.Value);
                                    } catch(Exception exc)
                                    {
                                        new ErrorForm(exc);
                                    }
                                    

                                    Thread.Sleep(1);
                                }


                            });
                            wmThread.Start();
                            darkSectionPanel1.Controls.Add(box);
                            boxes.Add(box);
                        }
                        darkButton1.Visible = true;
                    }
                    else
                    {
                        unlockList();
                        
                        MessageBox.Show(cheat.Name + " Process not found!");
                    }


            }

        }

        private void lockList()
        {
            listBox1.Enabled = false;
        }

        private void unlockList()
        {
            listBox1.Enabled = true;
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            darkButton1.Visible = false;
            cheatLoaded = false;
            foreach (DarkCheckBox box in boxes)
            {
                darkSectionPanel1.Controls.Remove(box);
                box.Dispose();
            }
            boxes.Clear();
            GC.Collect();
            darkLabel1.Text = "";
            y = 25;
            x = 25;
            num = 0;
            unlockList();
        }
    }
}
