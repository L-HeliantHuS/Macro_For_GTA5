﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Macro
{
    public partial class Main_MacroForm : Form
    {
        public CrosshairForm Crosshair = new CrosshairForm();

        private static bool MacroSwitch = false;
        private static bool ChatSwitch = false;
        private static bool CrossHairSwitch = false;
        private static bool CEO_MODE = false;
        private static List<Keyboard.ScanCodeShort> CUSTOM_CHAT = new List<Keyboard.ScanCodeShort>()
        {
            Keyboard.ScanCodeShort.KEY_T
        };

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private KeyEventHandler myKeyEventHandeler = null;//按键钩子
        private KeyboardHook k_hook = new KeyboardHook();

        private MouseEventHandler myMouseHandeler = null;//按键钩子
        private MouseHook m_hook = new MouseHook();

        private Dictionary<string, Keyboard.ScanCodeShort[]> MacroChat = new Dictionary<string, Keyboard.ScanCodeShort[]>();

        public Main_MacroForm()
        {
            InitializeComponent();
            fk_u_mother();
        }

        public void stopListen()
        {
            if (myKeyEventHandeler != null)
            {
                k_hook.KeyDownEvent -= myKeyEventHandeler;//取消按键事件
                myKeyEventHandeler = null;
                k_hook.Stop();//关闭键盘钩子
            }

            if (myMouseHandeler != null)
            {
                m_hook.OnMouseActivity -= myMouseHandeler;//取消按键事件
                myMouseHandeler = null;
                m_hook.Stop();//关闭鼠标钩子
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (MacroSwitch)
            {
                if (myKeyEventHandeler != null)
                {
                    k_hook.KeyDownEvent -= myKeyEventHandeler;//取消按键事件
                    myKeyEventHandeler = null;
                    k_hook.Stop();//关闭键盘钩子
                }

                if (myMouseHandeler != null)
                {
                    m_hook.OnMouseActivity -= myMouseHandeler;//取消按键事件
                    myMouseHandeler = null;
                    m_hook.Stop();//关闭鼠标钩子
                }
            }
            else
            {
                myKeyEventHandeler = new KeyEventHandler(hook_KeyDown);
                k_hook.KeyDownEvent += myKeyEventHandeler;//钩住键按下
                k_hook.Start();//安装键盘钩子

                myMouseHandeler = new MouseEventHandler(hook_MouseButtonDown);
                m_hook.OnMouseActivity += myMouseHandeler;//钩住键按下
                m_hook.Start();//安装鼠标钩子
            }

            MacroSwitch = !MacroSwitch;
            button1.BackgroundImage = MacroSwitch ? Properties.Resources.switch_on : Properties.Resources.switch_off;
        }

        private void fk_u_mother()
        {
            MacroChat.Add("CRY", new Keyboard.ScanCodeShort[] {
                Keyboard.ScanCodeShort.KEY_C,
                Keyboard.ScanCodeShort.KEY_R,
                Keyboard.ScanCodeShort.KEY_Y
            });

            MacroChat.Add("RIP", new Keyboard.ScanCodeShort[] {
                Keyboard.ScanCodeShort.KEY_R,
                Keyboard.ScanCodeShort.KEY_I,
                Keyboard.ScanCodeShort.KEY_P
            });

            MacroChat.Add("NOOB", new Keyboard.ScanCodeShort[] {
                Keyboard.ScanCodeShort.KEY_N,
                Keyboard.ScanCodeShort.KEY_O,
                Keyboard.ScanCodeShort.KEY_O,
                Keyboard.ScanCodeShort.KEY_B
            });

            MacroChat.Add("NICE HACK", new Keyboard.ScanCodeShort[] {
                Keyboard.ScanCodeShort.KEY_N,
                Keyboard.ScanCodeShort.KEY_I,
                Keyboard.ScanCodeShort.KEY_C,
                Keyboard.ScanCodeShort.KEY_E,
                Keyboard.ScanCodeShort.SPACE,
                Keyboard.ScanCodeShort.KEY_H,
                Keyboard.ScanCodeShort.KEY_A,
                Keyboard.ScanCodeShort.KEY_C,
                Keyboard.ScanCodeShort.KEY_K
            });

            MacroChat.Add(".", new Keyboard.ScanCodeShort[] {
                Keyboard.ScanCodeShort.OEM_COMMA
            });

            MacroChat.Add("CUSTOM_CHAT", new Keyboard.ScanCodeShort[] { });

            foreach (string chat in MacroChat.Keys)
            {
                listBox1.Items.Add(chat);
            }
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 192)
            {
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                Keyboard.KeyDown(Keyboard.ScanCodeShort.KEY_C, false);
                Thread.Sleep(40);
                Keyboard.KeyDown(Keyboard.ScanCodeShort.CAPITAL, false);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                Keyboard.KeyUP(Keyboard.ScanCodeShort.CAPITAL, false);
                Keyboard.KeyUP(Keyboard.ScanCodeShort.KEY_C, false);
                //Keyboard.KeyDown(Keyboard.ScanCodeShort.KEY_W, false);
                /*Keyboard.KeyDown(Keyboard.ScanCodeShort.CONTROL, false);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_T);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_V);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);*/

            }

            if ((int)ModifierKeys == (int)Keys.Control)
            {
                switch (e.KeyValue)
                {
                    // Kill Self
                    case (int)Keys.NumPad1:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.KeyDown(Keyboard.ScanCodeShort.KEY_C, false);
                        Keyboard.KeyDown(Keyboard.ScanCodeShort.CAPITAL, false);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.KeyUP(Keyboard.ScanCodeShort.CAPITAL, false);
                        Keyboard.KeyUP(Keyboard.ScanCodeShort.KEY_C, false);
                        break;
                    // CEO BST
                    case (int)Keys.NumPad2:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        break;
                    // CEO 护甲
                    case (int)Keys.NumPad3:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        break;

                    // 开关战机热感
                    case (int)Keys.NumPad7:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        if (CEO_MODE) Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.SPACE);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        break;

                    // 吃零食 (3个
                    case (int)Keys.NumPad4:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        if (CEO_MODE) Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        break;

                    // 吃护甲 (1个
                    case (int)Keys.NumPad5:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        if (CEO_MODE) Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        break;

                    // 买弹药
                    case (int)Keys.NumPad6:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        if (CEO_MODE) Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Thread.Sleep(50);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RIGHT, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        break;

                    // 开关普通热感
                    case (int)Keys.NumPad8:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        if (CEO_MODE) Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.SPACE);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        break;
                    default:
                        return;
                }

            }

        }

        private static Keyboard.ScanCodeShort GetRIGHT()
        {
            return Keyboard.ScanCodeShort.RIGHT;
        }

        private void hook_MouseButtonDown(object sender, MouseEventArgs e)
        {

            if (e.Button.Equals(MouseButtons.Middle))
            {
                if (ChatSwitch)
                {
                    if (listBox1.SelectedItem == null) return;

                    Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_T);

                    List<Keyboard.ScanCodeShort> forScancodeDic =
                        listBox1.SelectedItem.ToString().Equals("CUSTOM_CHAT") ? CUSTOM_CHAT : MacroChat[listBox1.SelectedItem.ToString()].ToList();

                    foreach (Keyboard.ScanCodeShort key in forScancodeDic)
                    {
                        Keyboard.FuckingPressKey(key);
                    }

                    Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);

                    return;
                }
            }
        }

        private void Main_MacroForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopListen();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ChatSwitch = !ChatSwitch;
            button2.BackgroundImage = ChatSwitch ? Properties.Resources.switch_on : Properties.Resources.switch_off;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            CrossHairSwitch = !CrossHairSwitch;
            button3.BackgroundImage = CrossHairSwitch ? Properties.Resources.switch_on : Properties.Resources.switch_off;

            if (CrossHairSwitch)
            {
                Crosshair.Location = (Point)new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                Crosshair.Show();
            }
            else
            {
                Crosshair.Hide();
            }
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Crosshair.Location = (Point)new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Crosshair.Location = (Point)new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            CEO_MODE = !CEO_MODE;
            button4.BackgroundImage = CEO_MODE ? Properties.Resources.switch_on : Properties.Resources.switch_off;

        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            CUSTOM_CHAT.Clear();

            foreach (char c in textBox1.Text)
            {
                CUSTOM_CHAT.Add(Keyboard.Key2ScanCodeMap[c.ToString().ToUpper()]);
            }

            textBox1.ForeColor = Color.Green;
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.DeepPink;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("魔改自https://github.com/H4rry217/My_Macro, 感谢H4rry217前辈\n" +
                "Ctrl + 1 秒自杀\n" +
                "Ctrl + 2 ceo牛鲨\n" +
                "Ctrl + 3 ceo护甲\n" +
                "Ctrl + 4 吃零食(3个\n" +
                "Ctrl + 5 吃护甲(1个\n" +
                "Ctrl + 6 买弹药(2次\n" +
                "Ctrl + 7 开关战机热感\n" +
                "Ctrl + 8 开关普通热感\n" +
                "鼠标中键 刷屏 \n" +
                "魔改来自 HeliantHuS :D");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 将按钮置为不可点击. 等相应完毕后恢复
            button6.Enabled = false;
            // 吃大亏, c# GetProcessesByName 不能加  .exe,  习惯性的找了GTA5.exe, 耽误事.            
            Process[] process = Process.GetProcessesByName("GTA5");
            if (process.Length != 0) {
                int processID = process[0].Id;

                ProcessMgr.SuspendProcess(processID);

                // 大约7秒就可以卡好单人战局
                Thread.Sleep(7000);

                ProcessMgr.ResumeProcess(processID);
                button6.Enabled = true;
            } else
            {
                MessageBox.Show("没找到GTA5游戏进程, 请检查GTA5是否启动.");
                this.button6.Enabled = true;
            }
        }
    }
}
