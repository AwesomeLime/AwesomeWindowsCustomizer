﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Linq.Expressions;
using System.Media;
using System.Globalization;

namespace AWC
{
    public partial class Form1 : Form
    {
        private SoundPlayer sp = new SoundPlayer();
        public Form1()
        {
            InitializeComponent();
            Version osVersion = Environment.OSVersion.Version;
            if (Properties.Settings.Default.FirstRun == true)
            {
                comboBox1.SelectedIndex = 0;
                CultureInfo currentCulture = CultureInfo.CurrentCulture;

                if (currentCulture.Name.StartsWith("en"))
                {
                    Properties.Settings.Default.Lang = 2;
                    Properties.Settings.Default.Save();
                }
                else if (currentCulture.Name.StartsWith("ru"))
                {
                    Properties.Settings.Default.Lang = 1;
                    Properties.Settings.Default.Save();
                }
                else if (currentCulture.Name.StartsWith("uz"))
                {
                    Properties.Settings.Default.Lang = 1;
                    Properties.Settings.Default.Save(); ;
                }
                else if (currentCulture.Name.StartsWith("kk"))
                {
                    Properties.Settings.Default.Lang = 1;
                    Properties.Settings.Default.Save();
                }
                else if (currentCulture.Name.StartsWith("be"))
                {
                    Properties.Settings.Default.Lang = 1;
                    Properties.Settings.Default.Save();
                }
                else if (currentCulture.Name.StartsWith("lv"))
                {
                    Properties.Settings.Default.Lang = 1;
                    Properties.Settings.Default.Save();
                }
                else if (currentCulture.Name.StartsWith("uk"))
                {
                    Properties.Settings.Default.Lang = 1;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Lang = 2;
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                if (Properties.Settings.Default.Theme == 1)
                {
                    comboBox1.SelectedIndex = 0;
                }
                else if (Properties.Settings.Default.Theme == 2)
                {
                    comboBox1.SelectedIndex = 1;
                }

                else if (Properties.Settings.Default.Theme == 3)
                {
                    comboBox1.SelectedIndex = 2;
                }
                else if (Properties.Settings.Default.Theme == 4)
                {
                    comboBox1.SelectedIndex = 3;
                }
                else if (Properties.Settings.Default.Theme == 5)
                {
                    comboBox1.SelectedIndex = 4;
                }
                else if (Properties.Settings.Default.Theme == 6)
                {
                    comboBox1.SelectedIndex = 5;
                }
                else if (Properties.Settings.Default.Theme == 7)
                {
                    comboBox1.SelectedIndex = 6;
                }
                else if (Properties.Settings.Default.Theme == 8)
                {
                    comboBox1.SelectedIndex = 7;
                }
            }
            Properties.Settings.Default.NeedExpReboot = false;
            Properties.Settings.Default.NeedReboot = false;
            button12.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            if (Properties.Settings.Default.Lang == 1)
            {
                comboBox2.SelectedIndex = 0;
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                comboBox2.SelectedIndex = 1;
            }
            label9.Visible = false;
            label10.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            try
            {
                string pcname = Environment.GetEnvironmentVariable("computername");
                string logname = Environment.GetEnvironmentVariable("username");
                string windir = Environment.GetEnvironmentVariable("windir");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectCollection information = searcher.Get();

                foreach (ManagementObject obj in information)
                {
                    string osarch = obj["OSArchitecture"].ToString();
                    string osname = obj["Caption"].ToString();
                    string build = obj["BuildNumber"].ToString();
                    {

                    }
                    if (int.TryParse(build, out int buildNumber) && buildNumber < 14393)
                    {
                        if (Properties.Settings.Default.Lang == 1)
                        {
                            MessageBox.Show("Ваша версия Windows не поддерживается. Для использования Awesome Windows Customizer, необходима Windows 10 1607 или новее.", "AWC - Неподдерживаемая система", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (Properties.Settings.Default.Lang == 2)
                        {
                            MessageBox.Show("Your version of Windows is not supported. To use Awesome Windows Customizer, you need Windows 10 1607 or later.", "AWC - Unsupported system", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Environment.Exit(0);
                    }
                    if (Properties.Settings.Default.Lang == 1)
                    {
                        label2.Text = $"ОС - {osname}\r\nНомер сборки - {build}\r\nРазрядность системы - {osarch}\r\nПапка установки - {windir}\r\nИмя компьютера - {pcname}\r\nИмя пользователя - {logname}\r\n\r\n\n\n\n\nСовет: чтобы посмотреть информацию о настройке, \nнажмите по ней правой кнопкой мыши.";
                    }
                    else if (Properties.Settings.Default.Lang == 2)
                    {
                        label2.Text = $"OS - {osname}\r\nBuild number - {build}\r\nSystem architecture - {osarch}\r\nWindows folder - {windir}\r\nComputer name - {pcname}\r\nUsername - {logname}\r\n\r\n\n\n\n\n\nTip: to view information about setting, right-click on it.";
                    }
                }


            }
            catch
            {
                MessageBox.Show("Не удалось получить данные о системе.", "Awesome Windows Customizer - Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label2.Text = "Не удалось загрузить данные.";
            }
            Properties.Settings.Default.CatAboutPC = true;
            Properties.Settings.Default.CatExp = false;
            Properties.Settings.Default.CatAct = false;
            Properties.Settings.Default.CatContext = false;
            Properties.Settings.Default.CatEtc = false;
            Properties.Settings.Default.CatSec = false;
            Properties.Settings.Default.CatWork = false;
            if (Properties.Settings.Default.Theme == 1)
            {
                comboBox1.SelectedIndex = 0;
            }
            else if (Properties.Settings.Default.Theme == 2)
            {
                comboBox1.SelectedIndex = 1;
            }
            button1.Enabled = true;
            if (Properties.Settings.Default.CatAboutPC == true)
            {
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox7.Visible = false;
                checkBox6.Visible = false;
                checkBox5.Visible = false;
                checkBox10.Visible = false;
                checkBox9.Visible = false;
                checkBox8.Visible = false;
                checkBox1.Visible = false;
                checkBox12.Visible = false;
                checkBox11.Visible = false;
                label2.Visible = true;
                button13.Visible = false;
                button14.Visible = false;
                button15.Visible = false;
                button16.Visible = false;
                button17.Visible = false;
                button18.Visible = false;
                pictureBox4.Visible = false;
            }
            if (Properties.Settings.Default.Lang == 1)
            {
                // Создаем объект Random
                Random random = new Random();
                // Генерируем случайное число
                int randomNumber = random.Next(0, 11);
                Properties.Settings.Default.SplashRandom = randomNumber;
                Properties.Settings.Default.Save();
                if (Properties.Settings.Default.SplashRandom == 0)
                {
                    label1.Text = "Привет! Чем займёмся?";
                }
                else if (Properties.Settings.Default.SplashRandom == 1)
                {
                    label1.Text = "Windows 11 или Windows 10?";
                }
                else if (Properties.Settings.Default.SplashRandom == 2)
                {
                    label1.Text = "Made by AwesomeLime!";
                }
                else if (Properties.Settings.Default.SplashRandom == 3)
                {
                    label1.Text = "Что это за кнопки справа?";
                }
                else if (Properties.Settings.Default.SplashRandom == 4)
                {
                    label1.Text = "Что это за буквы снизу?";
                }
                else if (Properties.Settings.Default.SplashRandom == 5)
                {
                    label1.Text = "Awesome customizer for You!";
                }
                else if (Properties.Settings.Default.SplashRandom == 6)
                {
                    label1.Text = "label1.Text = 'Привет, MrBaska!'";
                }
                else if (Properties.Settings.Default.SplashRandom == 7)
                {
                    label1.Text = "АФКП!";
                }
                else if (Properties.Settings.Default.SplashRandom == 8)
                {
                    label1.Text = "#IHateHistory!";
                }
                else if (Properties.Settings.Default.SplashRandom == 9)
                {
                    label1.Text = "А что если полазать в коде?";
                }
                else if (Properties.Settings.Default.SplashRandom == 10)
                {
                    label1.Text = "Спасибо за использование! :)";
                }
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                label1.Text = "Thank you for using! :)";
            }


            Properties.Settings.Default.FirstRun = false;

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                label1.Text = "Об устройстве";
                try
                {
                    string pcname = Environment.GetEnvironmentVariable("computername");
                    string logname = Environment.GetEnvironmentVariable("username");
                    string windir = Environment.GetEnvironmentVariable("windir");
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                    ManagementObjectCollection information = searcher.Get();

                    foreach (ManagementObject obj in information)
                    {
                        string osarch = obj["OSArchitecture"].ToString();
                        string osname = obj["Caption"].ToString();
                        string build = obj["BuildNumber"].ToString();
                        {
                            label2.Text = $"ОС - {osname}\r\nНомер сборки - {build}\r\nРазрядность системы - {osarch}\r\nПапка установки - {windir}\r\nИмя компьютера - {pcname}\r\nИмя пользователя - {logname}\r\n\r\n\n\n\n\nСовет: чтобы посмотреть информацию о настройке, \nнажмите по ней правой кнопкой мыши.";
                        }


                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось получить данные о системе.", "Awesome Windows Customizer - Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label2.Text = "Не удалось загрузить данные.";
                }
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                label1.Text = "About device";
                try
                {
                    string pcname = Environment.GetEnvironmentVariable("computername");
                    string logname = Environment.GetEnvironmentVariable("username");
                    string windir = Environment.GetEnvironmentVariable("windir");
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                    ManagementObjectCollection information = searcher.Get();

                    foreach (ManagementObject obj in information)
                    {
                        string osarch = obj["OSArchitecture"].ToString();
                        string osname = obj["Caption"].ToString();
                        string build = obj["BuildNumber"].ToString();
                        {
                            label2.Text = $"OS - {osname}\r\nBuild number - {build}\r\nSystem architecture - {osarch}\r\nWindows folder - {windir}\r\nComputer name - {pcname}\r\nUsername - {logname}\r\n\r\n\n\n\n\n\nTip: to view information about setting, right-click on it.";
                        }


                    }
                }
                catch
                {
                    MessageBox.Show("Не удалось получить данные о системе.", "Awesome Windows Customizer - Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label2.Text = "Не удалось загрузить данные.";
                }
            }
            Properties.Settings.Default.CatAboutPC = true;
            Properties.Settings.Default.CatExp = false;
            Properties.Settings.Default.CatWork = false;
            Properties.Settings.Default.CatSec = false;
            Properties.Settings.Default.CatEtc = false;
            Properties.Settings.Default.CatAct = false;
            Properties.Settings.Default.CatContext = false;
            Properties.Settings.Default.CatSet = false;
            Properties.Settings.Default.CatAbout = false;
            Properties.Settings.Default.CatRec = false;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            label2.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button20.Enabled = true;
            comboBox1.Visible = false;
            label9.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                label1.Text = "Рабочее окружение";
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                label1.Text = "Enviroment";
            }
            Properties.Settings.Default.CatAboutPC = false;
            Properties.Settings.Default.CatExp = false;
            Properties.Settings.Default.CatWork = true;
            Properties.Settings.Default.CatSec = false;
            Properties.Settings.Default.CatEtc = false;
            Properties.Settings.Default.CatAct = false;
            Properties.Settings.Default.CatContext = false;
            Properties.Settings.Default.CatSet = false;
            Properties.Settings.Default.CatAbout = false;
            Properties.Settings.Default.CatRec = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button19.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button20.Enabled = true;
            comboBox1.Visible = false;
            label9.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            if (Properties.Settings.Default.CBR1 == true)
            {
                checkBox1.Checked = true;

            }
            else if (Properties.Settings.Default.CBR1 == false)
            {
                checkBox1.Checked = false;
            }
            if (Properties.Settings.Default.CBR2 == true)
            {
                checkBox2.Checked = true;

            }
            else if (Properties.Settings.Default.CBR2 == false)
            {
                checkBox2.Checked = false;
            }
            if (Properties.Settings.Default.CBR3 == true)
            {
                checkBox3.Checked = true;

            }
            else if (Properties.Settings.Default.CBR3 == false)
            {
                checkBox3.Checked = false;
            }
            if (Properties.Settings.Default.CBR4 == true)
            {
                checkBox4.Checked = true;

            }
            else if (Properties.Settings.Default.CBR4 == false)
            {
                checkBox4.Checked = false;
            }
            if (Properties.Settings.Default.CBR5 == true)
            {
                checkBox5.Checked = true;

            }
            else if (Properties.Settings.Default.CBR5 == false)
            {
                checkBox5.Checked = false;
            }
            if (Properties.Settings.Default.CBR6 == true)
            {
                checkBox6.Checked = true;

            }
            else if (Properties.Settings.Default.CBR6 == false)
            {
                checkBox6.Checked = false;
            }
            if (Properties.Settings.Default.CBR7 == true)
            {
                checkBox7.Checked = true;

            }
            else if (Properties.Settings.Default.CBR7 == false)
            {
                checkBox7.Checked = false;
            }
            if (Properties.Settings.Default.CBR8 == true)
            {
                checkBox8.Checked = true;

            }
            else if (Properties.Settings.Default.CBR8 == false)
            {
                checkBox8.Checked = false;
            }
            if (Properties.Settings.Default.CBR9 == true)
            {
                checkBox9.Checked = true;

            }
            else if (Properties.Settings.Default.CBR9 == false)
            {
                checkBox9.Checked = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                label1.Text = "Проводник";
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                label1.Text = "Explorer";
            }
            Properties.Settings.Default.CatAboutPC = false;
            Properties.Settings.Default.CatExp = true;
            Properties.Settings.Default.CatWork = false;
            Properties.Settings.Default.CatSec = false;
            Properties.Settings.Default.CatEtc = false;
            Properties.Settings.Default.CatAct = false;
            Properties.Settings.Default.CatContext = false;
            Properties.Settings.Default.CatSet = false;
            Properties.Settings.Default.CatAbout = false;
            Properties.Settings.Default.CatRec = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button19.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button20.Enabled = true;
            comboBox1.Visible = false;
            label9.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            if (Properties.Settings.Default.CBE1 == true)
            {
                checkBox1.Checked = true;

            }
            else if (Properties.Settings.Default.CBE1 == false)
            {
                checkBox1.Checked = false;
            }
            if (Properties.Settings.Default.CBE2 == true)
            {
                checkBox2.Checked = true;

            }
            else if (Properties.Settings.Default.CBE2 == false)
            {
                checkBox2.Checked = false;
            }
            if (Properties.Settings.Default.CBE3 == true)
            {
                checkBox3.Checked = true;

            }
            else if (Properties.Settings.Default.CBE3 == false)
            {
                checkBox3.Checked = false;
            }
            if (Properties.Settings.Default.CBE4 == true)
            {
                checkBox4.Checked = true;

            }
            else if (Properties.Settings.Default.CBE4 == false)
            {
                checkBox4.Checked = false;
            }
            if (Properties.Settings.Default.CBE5 == true)
            {
                checkBox5.Checked = true;

            }
            else if (Properties.Settings.Default.CBE5 == false)
            {
                checkBox5.Checked = false;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                label1.Text = "Безопасность и обновление";
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                label1.Text = "Security and update";
            }
            Properties.Settings.Default.CatAboutPC = false;
            Properties.Settings.Default.CatExp = false;
            Properties.Settings.Default.CatWork = false;
            Properties.Settings.Default.CatSec = true;
            Properties.Settings.Default.CatEtc = false;
            Properties.Settings.Default.CatAct = false;
            Properties.Settings.Default.CatContext = false;
            Properties.Settings.Default.CatSet = false;
            Properties.Settings.Default.CatAbout = false;
            Properties.Settings.Default.CatRec = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button19.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button20.Enabled = true;
            comboBox1.Visible = false;
            label9.Visible = false;
            pictureBox2.Visible = false;
            pictureBox4.Visible = false;
            pictureBox3.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            if (Properties.Settings.Default.CBU1 == true)
            {
                checkBox1.Checked = true;

            }
            else if (Properties.Settings.Default.CBU1 == false)
            {
                checkBox1.Checked = false;
            }
            if (Properties.Settings.Default.CBU2 == true)
            {
                checkBox2.Checked = true;

            }
            else if (Properties.Settings.Default.CBU2 == false)
            {
                checkBox2.Checked = false;
            }
            if (Properties.Settings.Default.CBU3 == true)
            {
                checkBox3.Checked = true;

            }
            else if (Properties.Settings.Default.CBU3 == false)
            {
                checkBox3.Checked = false;
            }
            if (Properties.Settings.Default.CBU4 == true)
            {
                checkBox4.Checked = true;

            }
            else if (Properties.Settings.Default.CBU4 == false)
            {
                checkBox4.Checked = false;
            }
            if (Properties.Settings.Default.CBU5 == true)
            {
                checkBox5.Checked = true;

            }
            else if (Properties.Settings.Default.CBU5 == false)
            {
                checkBox5.Checked = false;
            }
            if (Properties.Settings.Default.CBU6 == true)
            {
                checkBox6.Checked = true;

            }
            else if (Properties.Settings.Default.CBU6 == false)
            {
                checkBox6.Checked = false;
            }
            if (Properties.Settings.Default.CBU7 == true)
            {
                checkBox7.Checked = true;

            }
            else if (Properties.Settings.Default.CBU7 == false)
            {
                checkBox7.Checked = false;
            }
            if (Properties.Settings.Default.CBU8 == true)
            {
                checkBox8.Checked = true;

            }
            else if (Properties.Settings.Default.CBU8 == false)
            {
                checkBox8.Checked = false;
            }
            if (Properties.Settings.Default.CBU9 == true)
            {
                checkBox9.Checked = true;

            }
            else if (Properties.Settings.Default.CBU9 == false)
            {
                checkBox9.Checked = false;
            }
            if (Properties.Settings.Default.CBU10 == true)
            {
                checkBox10.Checked = true;
                checkBox10.Enabled = false;

            }
            else if (Properties.Settings.Default.CBU10 == false)
            {
                checkBox10.Checked = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                label1.Text = "Прочее";
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                label1.Text = "Other";
            }
            Properties.Settings.Default.CatAboutPC = false;
            Properties.Settings.Default.CatExp = false;
            Properties.Settings.Default.CatWork = false;
            Properties.Settings.Default.CatSec = false;
            Properties.Settings.Default.CatEtc = true;
            Properties.Settings.Default.CatAct = false;
            Properties.Settings.Default.CatContext = false;
            Properties.Settings.Default.CatSet = false;
            Properties.Settings.Default.CatAbout = false;
            Properties.Settings.Default.CatRec = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button19.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button20.Enabled = true;
            comboBox1.Visible = false;
            label9.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            if (Properties.Settings.Default.CBET1 == true)
            {
                checkBox1.Checked = true;

            }
            else if (Properties.Settings.Default.CBET1 == false)
            {
                checkBox1.Checked = false;
            }
            if (Properties.Settings.Default.CBET2 == true)
            {
                checkBox2.Checked = true;

            }
            else if (Properties.Settings.Default.CBET2 == false)
            {
                checkBox2.Checked = false;
            }
            if (Properties.Settings.Default.CBET3 == true)
            {
                checkBox3.Checked = true;

            }
            else if (Properties.Settings.Default.CBET3 == false)
            {
                checkBox3.Checked = false;
            }
            if (Properties.Settings.Default.CBET4 == true)
            {
                checkBox4.Checked = true;

            }
            else if (Properties.Settings.Default.CBET4 == false)
            {
                checkBox4.Checked = false;
            }
            if (Properties.Settings.Default.CBET5 == true)
            {
                checkBox5.Checked = true;

            }
            else if (Properties.Settings.Default.CBET5 == false)
            {
                checkBox5.Checked = false;
            }
            if (Properties.Settings.Default.CBET6 == true)
            {
                checkBox6.Checked = true;

            }
            else if (Properties.Settings.Default.CBET6 == false)
            {
                checkBox6.Checked = false;
            }
            if (Properties.Settings.Default.CBET7 == true)
            {
                checkBox7.Checked = true;

            }
            else if (Properties.Settings.Default.CBET7 == false)
            {
                checkBox7.Checked = false;
            }
            if (Properties.Settings.Default.CBET8 == true)
            {
                checkBox8.Checked = true;

            }
            else if (Properties.Settings.Default.CBET8 == false)
            {
                checkBox8.Checked = false;
            }
            if (Properties.Settings.Default.CBET9 == true)
            {
                checkBox9.Checked = true;

            }
            else if (Properties.Settings.Default.CBET9 == false)
            {
                checkBox9.Checked = false;
            }
            if (Properties.Settings.Default.CBET10 == true)
            {
                checkBox10.Checked = true;

            }
            else if (Properties.Settings.Default.CBET10 == false)
            {
                checkBox10.Checked = false;
            }
            if (Properties.Settings.Default.CBET11 == true)
            {
                checkBox11.Checked = true;

            }
            else if (Properties.Settings.Default.CBET11 == false)
            {
                checkBox11.Checked = false;
            }
            if (Properties.Settings.Default.CBET12 == true)
            {
                checkBox12.Checked = true;

            }
            else if (Properties.Settings.Default.CBET12 == false)
            {
                checkBox12.Checked = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                label1.Text = "Контекстное меню";
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                label1.Text = "Context menu";
            }
            Properties.Settings.Default.CatAboutPC = false;
            Properties.Settings.Default.CatExp = false;
            Properties.Settings.Default.CatWork = false;
            Properties.Settings.Default.CatSec = false;
            Properties.Settings.Default.CatEtc = false;
            Properties.Settings.Default.CatAct = false;
            Properties.Settings.Default.CatContext = true;
            Properties.Settings.Default.CatSet = false;
            Properties.Settings.Default.CatAbout = false;
            Properties.Settings.Default.CatRec = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button19.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button20.Enabled = true;
            comboBox1.Visible = false;
            label9.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            if (Properties.Settings.Default.CB1 == true)
            {
                checkBox1.Checked = true;

            }
            else if (Properties.Settings.Default.CB1 == false)
            {
                checkBox1.Checked = false;
            }
            if (Properties.Settings.Default.CB2 == true)
            {
                checkBox2.Checked = true;

            }
            else if (Properties.Settings.Default.CB2 == false)
            {
                checkBox2.Checked = false;
            }
            if (Properties.Settings.Default.CB3 == true)
            {
                checkBox3.Checked = true;

            }
            else if (Properties.Settings.Default.CB3 == false)
            {
                checkBox3.Checked = false;
            }
            if (Properties.Settings.Default.CB4 == true)
            {
                checkBox4.Checked = true;

            }
            else if (Properties.Settings.Default.CB4 == false)
            {
                checkBox4.Checked = false;
            }
            if (Properties.Settings.Default.CB5 == true)
            {
                checkBox5.Checked = true;

            }
            else if (Properties.Settings.Default.CB5 == false)
            {
                checkBox5.Checked = false;
            }
            if (Properties.Settings.Default.CB6 == true)
            {
                checkBox6.Checked = true;

            }
            else if (Properties.Settings.Default.CB6 == false)
            {
                checkBox6.Checked = false;
            }
            if (Properties.Settings.Default.CB7 == true)
            {
                checkBox7.Checked = true;

            }
            else if (Properties.Settings.Default.CB7 == false)
            {
                checkBox7.Checked = false;
            }
            if (Properties.Settings.Default.CB8 == true)
            {
                checkBox8.Checked = true;

            }
            else if (Properties.Settings.Default.CB8 == false)
            {
                checkBox8.Checked = false;
            }
            if (Properties.Settings.Default.CB9 == true)
            {
                checkBox9.Checked = true;

            }
            else if (Properties.Settings.Default.CB9 == false)
            {
                checkBox9.Checked = false;
            }
            if (Properties.Settings.Default.CB10 == true)
            {
                checkBox10.Checked = true;

            }
            else if (Properties.Settings.Default.CB10 == false)
            {
                checkBox10.Checked = false;
            }
            if (Properties.Settings.Default.CB11 == true)
            {
                checkBox11.Checked = true;

            }
            else if (Properties.Settings.Default.CB11 == false)
            {
                checkBox11.Checked = false;
            }
            if (Properties.Settings.Default.CB12 == true)
            {
                checkBox12.Checked = true;
                checkBox12.Enabled = false;

            }
            else if (Properties.Settings.Default.CB12 == false)
            {
                checkBox12.Checked = false;
            }
            if (Properties.Settings.Default.CB13 == true)
            {
                checkBox13.Checked = true;

            }
            else if (Properties.Settings.Default.CB13 == false)
            {
                checkBox13.Checked = false;
            }
            if (Properties.Settings.Default.CB14 == true)
            {
                checkBox14.Checked = true;

            }
            else if (Properties.Settings.Default.CB14 == false)
            {
                checkBox14.Checked = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                label1.Text = "Активация";
                button13.Text = "Активировать";
                button14.Text = "Активировать";
                button15.Text = "Активировать";
                button16.Text = "Активировать";
                button17.Text = "Активировать";
                button18.Text = "Активировать";
                label3.Text = "Windows 10/11 Pro";
                label4.Text = "Windows 10/11 Home";
                label5.Text = "Windws 10/11 Enterprise";
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                label1.Text = "Activation";
                button13.Text = "Activate      ";
                button14.Text = "Activate      ";
                button15.Text = "Activate      ";
                button16.Text = "Activate      ";
                button17.Text = "Activate      ";
                button18.Text = "Activate      ";
                label3.Text = "Windows 10/11 Pro";
                label4.Text = "Windows 10/11 Home";
                label5.Text = "Windws 10/11 Enterprise";
            }
            Properties.Settings.Default.CatAboutPC = false;
            Properties.Settings.Default.CatExp = false;
            Properties.Settings.Default.CatWork = false;
            Properties.Settings.Default.CatSec = false;
            Properties.Settings.Default.CatEtc = false;
            Properties.Settings.Default.CatAct = true;
            Properties.Settings.Default.CatContext = false;
            Properties.Settings.Default.CatSet = false;
            Properties.Settings.Default.CatAbout = false;
            Properties.Settings.Default.CatRec = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button19.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = false;
            button8.Enabled = true;
            button9.Enabled = true;
            label2.Visible = false;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
            button17.Visible = true;
            button18.Visible = true;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button20.Enabled = true;
            comboBox1.Visible = false;
            label9.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            if (Properties.Settings.Default.ActFirstTime == true)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    MessageBox.Show("По какой то причине, иногда не получается активировать Windows с первой попытки.\nЕсли это произойдёт, нажимайте кнопку 'Активировать' до тех пор, пока не появится окно 'Активация выполнена успешно'.", "AWC - Обратите внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    MessageBox.Show("For some reason, sometimes it is not possible to activate Windows on the first try.\nIf this happens, click the 'Activate' button until the 'Activation completed successfully' window appears.", "AWC - Pay attention!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Properties.Settings.Default.ActFirstTime = false;
                Properties.Settings.Default.Save();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                label1.Text = "Настройки программы";
                label9.Text = "Тема";
                label10.Text = "Язык // Language";
                button19.Text = "Сбросить все настройки";
                checkBox7.Text = "Скрыть напоминание о необходимости перезагрузки";
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                label1.Text = "App settings";
                label9.Text = "Theme";
                label10.Text = "Language // Язык";
                checkBox7.Text = "Hide the reminder to reboot";
            }
            Properties.Settings.Default.CatAboutPC = false;
            Properties.Settings.Default.CatExp = false;
            Properties.Settings.Default.CatWork = false;
            Properties.Settings.Default.CatSec = false;
            Properties.Settings.Default.CatEtc = false;
            Properties.Settings.Default.CatAct = false;
            Properties.Settings.Default.CatContext = false;
            Properties.Settings.Default.CatSet = true;
            Properties.Settings.Default.CatRec = false;
            Properties.Settings.Default.CatAbout = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button20.Enabled = true;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox7.Visible = true;
            checkBox6.Visible = false;
            checkBox5.Visible = false;
            checkBox10.Visible = false;
            checkBox9.Visible = false;
            checkBox8.Visible = false;
            checkBox1.Visible = false;
            checkBox12.Visible = false;
            checkBox11.Visible = false;
            checkBox13.Visible = false;
            checkBox14.Visible = false;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            button19.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            if(Properties.Settings.Default.CBS == true)
            {
                checkBox7.Checked = true;
            }
            else if (Properties.Settings.Default.CBS == false)
            {
                checkBox7.Checked = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                label1.Text = "О программе";
                label11.Text = "Небольшая программа с открытым исходным кодом, \r\nкоторая позволяет настроить Windows под себя\r\nеё же стандартными средствами!\r\n";
                label13.Text = "Версия 1.2.1 Release\nAwesomeLime // 2024";

            }
            if (Properties.Settings.Default.Lang == 2)
            {
                label1.Text = "About";
                label11.Text = "A small open source program, which allows you to \ncustomize Windows for yourself its standard tools!";
                label13.Text = "Version 1.2.1 Release\nAwesomeLime // 2024";

            }
            Point newLocation = new Point(326, 365);
            Properties.Settings.Default.CatAboutPC = false; ;
            Properties.Settings.Default.CatExp = false;
            Properties.Settings.Default.CatWork = false;
            Properties.Settings.Default.CatSec = false;
            Properties.Settings.Default.CatEtc = false;
            Properties.Settings.Default.CatAct = false;
            Properties.Settings.Default.CatContext = false;
            Properties.Settings.Default.CatSet = false;
            Properties.Settings.Default.CatRec = false;
            Properties.Settings.Default.CatAbout = true;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button19.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = false;
            button9.Enabled = true;
            button12.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button20.Enabled = true;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox7.Visible = false;
            checkBox6.Visible = false;
            checkBox5.Visible = false;
            checkBox10.Visible = false;
            checkBox9.Visible = false;
            checkBox8.Visible = false;
            checkBox1.Visible = false;
            checkBox12.Visible = false;
            checkBox11.Visible = false;
            checkBox13.Visible = false;
            checkBox14.Visible = false;
            comboBox1.Visible = false;
            label9.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            label11.Visible = true;
            label13.Visible = true;
            label13.Location = newLocation;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatAboutPC == true)
            {
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                checkBox7.Visible = false;
                checkBox8.Visible = false;
                checkBox9.Visible = false;
                checkBox10.Visible = false;
                checkBox11.Visible = false;
                checkBox12.Visible = false;
                checkBox13.Visible = false;
                checkBox14.Visible = false;
                button12.Visible = false;
                comboBox2.Visible = false;
                button19.Visible = false;
                label10.Visible = false;
            }
            if (Properties.Settings.Default.CatExp == true)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
                checkBox6.Visible = false;
                checkBox7.Visible = false;
                checkBox8.Visible = false;
                checkBox9.Visible = false;
                checkBox10.Visible = false;
                checkBox11.Visible = false;
                checkBox12.Visible = false;
                checkBox13.Visible = false;
                checkBox14.Visible = false;
                if (Properties.Settings.Default.Lang == 1)
                {
                    checkBox1.Text = "Скрыть неудаляемые папки библиотек";
                    checkBox2.Text = "Показать скрытые файлы и папки";
                    checkBox3.Text = "Показать скрытые 'системные' файлы";
                    checkBox4.Text = "Показывать 'Этот компьютер' вместо 'Главной' при запуске Проводника";
                    checkBox5.Text = "Включить расширенный Буфер Обмена (Win+V)";
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    checkBox1.Text = "Hide non-deletable library folders";
                    checkBox2.Text = "Show hidden files and folders";
                    checkBox3.Text = "Show hidden system files";
                    checkBox4.Text = "Show 'This PC' instead of 'Home' at Explorer start";
                    checkBox5.Text = "Turn on advanced clipboard (Win+V)";
                }
                button12.Visible = false;
                checkBox2.Enabled = true;
                checkBox5.Enabled = true;
                checkBox7.Enabled = true;
                checkBox10.Enabled = true;
                checkBox12.Enabled = true;
            }
            if (Properties.Settings.Default.CatWork == true)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
                checkBox6.Visible = true;
                checkBox7.Visible = true;
                checkBox8.Visible = true;
                checkBox9.Visible = true;
                checkBox10.Visible = false;
                checkBox11.Visible = false;
                checkBox12.Visible = false;
                checkBox13.Visible = false;
                checkBox14.Visible = false;
                if (Properties.Settings.Default.Lang == 1)
                {
                    checkBox1.Text = "Минимальное кол-во рекомендаций в Пуске";
                    checkBox2.Text = "Отключить живые плитки в Пуске";
                    checkBox3.Text = "Показывать 'Этот компьютер' на рабочем столе";
                    checkBox4.Text = "Убрать окончание '- Ярлык' у новых ярлыков";
                    checkBox5.Text = "Показывать секунды на панели задач";
                    checkBox6.Text = "Скрыть кнопки Просмотра задач, Виджетов и Чата на панели задач";
                    checkBox7.Text = "Огромные миниатюры программ на панели задач";
                    checkBox8.Text = "Уменьшить время появления миниатюр";
                    checkBox9.Text = "Отключить новое контекстное меню из Windows 11";
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    checkBox1.Text = "Minimum number of recommendations in Start";
                    checkBox2.Text = "Disable live tiles in Start";
                    checkBox3.Text = "Show 'This PC' on the desktop";
                    checkBox4.Text = "Remove ending '- Shortcut' from new shortcuts";
                    checkBox5.Text = "Show seconds on the taskbar";
                    checkBox6.Text = "Hide the Task View, Widgets and Chat buttons from the taskbar";
                    checkBox7.Text = "Huge program thumbnails on the taskbar";
                    checkBox8.Text = "Reduce thumbnail appearance time";
                    checkBox9.Text = "Disable the new Windows 11 context menu";
                }
                button12.Visible = false;
                checkBox2.Enabled = true;
                checkBox5.Enabled = true;
                checkBox7.Enabled = true;
                checkBox10.Enabled = true;
                checkBox12.Enabled = true;
            }
            if (Properties.Settings.Default.CatSec == true)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
                checkBox6.Visible = true;
                checkBox7.Visible = true;
                checkBox8.Visible = true;
                checkBox9.Visible = true;
                checkBox10.Visible = true;
                checkBox11.Visible = false;
                checkBox12.Visible = false;
                checkBox13.Visible = false;
                checkBox14.Visible = false;
                if (Properties.Settings.Default.Lang == 1)
                {
                    checkBox1.Text = "Отключить Центр обновления Windows";
                    checkBox2.Text = "Отключить обновление до новой версии Windows";
                    checkBox3.Text = "Отключить установку драйверов через центр обновления";
                    checkBox4.Text = "Отключить телеметрию";
                    checkBox5.Text = "Отключить SmartScreen";
                    checkBox6.Text = "Отключить UAC";
                    checkBox7.Text = "Отключить Windows Defender";
                    checkBox8.Text = "Отключить анонимное удаление вредоносных программ";
                    checkBox9.Text = "Отключить Брандмауэр";
                    checkBox10.Text = "Отключить автоустановку рекламных приложений";
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    checkBox1.Text = "Disable Windows Update";
                    checkBox2.Text = "Disable updating to a new version of Windows";
                    checkBox3.Text = "Disable driver installation via Windows Update";
                    checkBox4.Text = "Disable telemetry";
                    checkBox5.Text = "Disable SmartScreen";
                    checkBox6.Text = "Disable UAC";
                    checkBox7.Text = "Disable Windows Defender";
                    checkBox8.Text = "Disable anonymous malware removal";
                    checkBox9.Text = "Disable Firewall";
                    checkBox10.Text = "Disable auto-installation of advertising applications";
                }
                button12.Visible = false;
                checkBox2.Enabled = true;
                checkBox5.Enabled = true;
                checkBox7.Enabled = true;
                checkBox12.Enabled = true;
            }
            if (Properties.Settings.Default.CatEtc == true)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
                checkBox6.Visible = true;
                checkBox7.Visible = true;
                checkBox8.Visible = true;
                checkBox9.Visible = true;
                checkBox10.Visible = true;
                checkBox11.Visible = true;
                checkBox12.Visible = true;
                checkBox13.Visible = false;
                checkBox14.Visible = false;
                if (Properties.Settings.Default.Lang == 1)
                {
                    checkBox1.Text = "Подробные сведения при выключении";
                    checkBox2.Text = "Отключить размытие фона на экране блокировки";
                    checkBox3.Text = "Включить Alt+Tab из Windows XP";
                    checkBox4.Text = "Отключить уведомление о неизвестном издателе EXE файлов";
                    checkBox5.Text = "Ускорить завершение работы";
                    checkBox6.Text = "Скрыть уведомление о нехватке места на диске";
                    checkBox7.Text = "Скрыть Snap Layout при наведении на кнопку 'Развернуть'";
                    checkBox8.Text = "Выключить залипание клавиш";
                    checkBox9.Text = "Включить старый загрузчик системы";
                    checkBox10.Text = "Сделать Alt+Tab на 70% непрозрачным";
                    checkBox11.Text = "Включить максимальную производительность";
                    checkBox12.Text = "Выключить затухание экрана при бездействии";
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    checkBox1.Text = "Show shutdown details";
                    checkBox2.Text = "Disable background blur on the lock screen";
                    checkBox3.Text = "Enable Alt+Tab from Windows XP";
                    checkBox4.Text = "Disable notification about unknown publisher of EXE files";
                    checkBox5.Text = "Speed up shutdown";
                    checkBox6.Text = "Hide the low disk space notification";
                    checkBox7.Text = "Hide Snap Layout when hovering over the 'Expand' button";
                    checkBox8.Text = "Disable Sticky Keys";
                    checkBox9.Text = "Enable old Windows Boot Manager";
                    checkBox10.Text = "Make Alt+Tab 70% opaque";
                    checkBox11.Text = "Enable max performance";
                    checkBox12.Text = "Disable screen fading when inactive";
                }
                button12.Visible = false;
                checkBox2.Enabled = true;
                checkBox5.Enabled = true;
                checkBox7.Enabled = true;
                checkBox10.Enabled = true;
                checkBox12.Enabled = true;
            }
            if (Properties.Settings.Default.CatContext == true)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
                checkBox6.Visible = true;
                checkBox7.Visible = true;
                checkBox8.Visible = true;
                checkBox9.Visible = true;
                checkBox10.Visible = true;
                checkBox11.Visible = true;
                checkBox12.Visible = true;
                checkBox13.Visible = true;
                checkBox14.Visible = true;
                if (Properties.Settings.Default.Lang == 1)
                {
                    checkBox1.Text = "Печать";
                    checkBox2.Text = "Открыть в Терминале";
                    checkBox3.Text = "Проверить с помощью Microsoft Defender";
                    checkBox4.Text = "Добавить в Избранные";
                    checkBox5.Text = "Восстановить прежнюю версию";
                    checkBox6.Text = "Добавить в библиотеку";
                    checkBox7.Text = "Предоставить доступ к";
                    checkBox8.Text = "Закрепить на начальном экране";
                    checkBox9.Text = "Копировать как путь";
                    checkBox10.Text = "Закрепить на панели задач";
                    checkBox11.Text = "Открыть в новой вкладке";
                    checkBox12.Text = "Включить BitLocker (для дисков)";
                    checkBox13.Text = "Отправить...";
                    checkBox14.Text = "Отправить (UWP)";
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    checkBox1.Text = "Print";
                    checkBox2.Text = "Open in Terminal";
                    checkBox3.Text = "Check with Microsoft Defender";
                    checkBox4.Text = "Add to Favorites";
                    checkBox5.Text = "Restore previous version";
                    checkBox6.Text = "Add to library";
                    checkBox7.Text = "Give access to";
                    checkBox8.Text = "Pin to Home Screen";
                    checkBox9.Text = "Copy as path";
                    checkBox10.Text = "Pin to taskbar";
                    checkBox11.Text = "Open in new tab";
                    checkBox12.Text = "Enable BitLocker (for drives)";
                    checkBox13.Text = "Send to...";
                    checkBox14.Text = "Send to (UWP)";
                }
                button12.Visible = true;
                checkBox10.Enabled = true;


            }
            if (Properties.Settings.Default.CatAct == true)
            {
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                checkBox7.Visible = false;
                checkBox8.Visible = false;
                checkBox9.Visible = false;
                checkBox10.Visible = false;
                checkBox11.Visible = false;
                checkBox12.Visible = false;
                checkBox13.Visible = false;
                checkBox14.Visible = false;
                button12.Visible = true;
            }
            if (Properties.Settings.Default.CatRec == true)
            {
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                checkBox7.Visible = false;
                checkBox8.Visible = false;
                checkBox9.Visible = false;
                checkBox10.Visible = false;
                checkBox11.Visible = false;
                checkBox12.Visible = false;
                checkBox13.Visible = false;
                checkBox14.Visible = false;
                button12.Visible = true;
            }
            if(Properties.Settings.Default.RebootEnabled == true && Properties.Settings.Default.CBS == false)
            {
                Reboot.Enabled = true;
                Reboot.Start();
            }
            if (Properties.Settings.Default.RebootEnabled == false && Properties.Settings.Default.CBS == true)
            {
                Reboot.Stop();
                Reboot.Enabled = false;
                Properties.Settings.Default.NeedExpReboot = false;
                Properties.Settings.Default.NeedReboot = false;
            }

        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                toolTip1.SetToolTip(button1, "Об устройстве");
                toolTip1.SetToolTip(button2, "Проводник");
                toolTip1.SetToolTip(button3, "Рабочее окружение");
                toolTip1.SetToolTip(button4, "Прочее");
                toolTip1.SetToolTip(button5, "Безопасность и обновления");
                toolTip1.SetToolTip(button5, "Безопасность и обновления");
                toolTip1.SetToolTip(button6, "Контекстное меню");
                toolTip1.SetToolTip(button7, "Активация");
                toolTip1.SetToolTip(button8, "О программе");
                toolTip1.SetToolTip(button9, "Настройки программы");
                toolTip1.SetToolTip(button10, "Перезапустить проводник");
                toolTip1.SetToolTip(button11, "Перезагрузить систему");
                toolTip1.SetToolTip(explorerReq, "Требуется перезагрузка Проводника!");
                toolTip1.SetToolTip(restartReq, "Требуется перезагрузка!");
                toolTip1.SetToolTip(button12, "Информация о категории");
                toolTip1.SetToolTip(button20, "Очистка и восстановление");
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                toolTip1.SetToolTip(button1, "About device");
                toolTip1.SetToolTip(button2, "Explorer");
                toolTip1.SetToolTip(button3, "Enviroment");
                toolTip1.SetToolTip(button4, "Other");
                toolTip1.SetToolTip(button5, "Security and Updates");
                toolTip1.SetToolTip(button5, "Security and Updates");
                toolTip1.SetToolTip(button6, "Context menu");
                toolTip1.SetToolTip(button7, "Activation");
                toolTip1.SetToolTip(button8, "About");
                toolTip1.SetToolTip(button9, "App settings");
                toolTip1.SetToolTip(button10, "Restart Explorer");
                toolTip1.SetToolTip(button11, "Reboot system");
                toolTip1.SetToolTip(explorerReq, "Explorer restart required!");
                toolTip1.SetToolTip(restartReq, "Reboot required!");
                toolTip1.SetToolTip(button12, "Category information");
                toolTip1.SetToolTip(button20, "System refresh");
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox14.Checked == true)
                {
                    Properties.Settings.Default.CB14 = true;
                    Properties.Settings.Default.Save();
                    Registry.ClassesRoot.DeleteSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\ModernSharing");
                }
                else if (checkBox14.Checked == false)
                {
                    Properties.Settings.Default.CB14 = false;
                    Properties.Settings.Default.Save();
                    Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\ModernSharing").SetValue("", "{e2bf9676-5f8f-435c-97eb-11607a5bedf7}");
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatExp == true)
            {
                if (checkBox2.Checked == true)
                {
                    Properties.Settings.Default.CBE2 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("Hidden", 1);

                }
                else if (checkBox2.Checked == false)
                {
                    Properties.Settings.Default.CBE2 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("Hidden", 0);
                }
            }
            else if (Properties.Settings.Default.CatWork == true)
            {
                if (checkBox2.Checked == true)
                {
                    Properties.Settings.Default.CBR2 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\PushNotifications").SetValue("NoTileApplicationNotification", 1);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Explorer").SetValue("ClearTilesOnExit", 1);
                }
                else if (checkBox2.Checked == false)
                {
                    Properties.Settings.Default.CBR1 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\PushNotifications").SetValue("NoTileApplicationNotification", 0);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Explorer").SetValue("ClearTilesOnExit", 0);

                }
            }
            else if (Properties.Settings.Default.CatSec == true)
            {
                if (checkBox2.Checked == true)
                {
                    Properties.Settings.Default.CBU2 = true;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate").SetValue("DisableOSUpgrade", 1);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\WindowsStore").SetValue("DisableOSUpgrade", 1);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\WindowsUpdate\OSUpgrade").SetValue("AllowOSUpgrade", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\WindowsUpdate\OSUpgrade").SetValue("ReservationsAllowed", 0);
                }
                else if (checkBox2.Checked == false)
                {
                    Properties.Settings.Default.CBU2 = false;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate").SetValue("DisableOSUpgrade", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\WindowsStore").SetValue("DisableOSUpgrade", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\WindowsUpdate\OSUpgrade").SetValue("AllowOSUpgrade", 1);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\WindowsUpdate\OSUpgrade").SetValue("ReservationsAllowed", 1);
                }
            }
            else if (Properties.Settings.Default.CatEtc == true)
            {
                if (checkBox2.Checked == true)
                {
                    Properties.Settings.Default.CBET2 = true;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System").SetValue("DisableAcrylicBackgroundOnLogon", 1);
                }
                else if (checkBox2.Checked == false)
                {
                    Properties.Settings.Default.CBET2 = false;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System").SetValue("DisableAcrylicBackgroundOnLogon", 0);
                }
            }
            else if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox2.Checked == true)
                {
                    Properties.Settings.Default.CB2 = true;
                    Properties.Settings.Default.Save();
                    checkBox5.Enabled = false;
                    checkBox7.Enabled = false;
                    checkBox5.Checked = false;
                    checkBox7.Checked = false;
                    try
                    {
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked").SetValue("{9F156763-7844-4DC4-B2B1-901F640F5155}", "");
                    }
                    catch
                    {

                    }
                }
                else if (checkBox2.Checked == false)
                {
                    Properties.Settings.Default.CB2 = false;
                    Properties.Settings.Default.Save();
                    checkBox5.Enabled = true;
                    checkBox7.Enabled = true;
                    try
                    {
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked");
                    }
                    catch
                    {

                    }
                }
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatExp == true)
            {
                if (checkBox3.Checked == true)
                {
                    Properties.Settings.Default.CBE3 = true;
                    Properties.Settings.Default.Save();
                    if (Properties.Settings.Default.Lang == 1)
                    {
                        DialogResult shResult = MessageBox.Show("Не рекомендуется включать данный параметр, так как из-за него вы можете повредить важные для системы файлы.\nЕсли вы хотите, чтобы у вас отображались такие папки как 'AppData' и т. п., вам необходимо включить параметр 'Показать скрытые файлы и папки'.\n\nВы точно хотите применить данный параметр? Применяйте данный параметр на свой страх и риск.", "Awesome Windows Customizer - Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (shResult == DialogResult.Yes)
                        {
                            Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowSuperHidden", 1);
                        }
                        else
                        {
                            checkBox3.Checked = false;
                            Properties.Settings.Default.CBE3 = false;
                            Properties.Settings.Default.Save();
                        }
                    }
                    else if (Properties.Settings.Default.Lang == 2)
                    {
                        DialogResult shResult = MessageBox.Show("It is not recommended to enable this option because of it you can damage important system files.\nIf you want to display folders like 'AppData' etc., you need to enable the 'Show hidden files and folders' setting.\n\nAre you sure you want to apply this setting? Use this setting at your own risk.", "Awesome Windows Customizer - Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (shResult == DialogResult.Yes)
                        {
                            Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowSuperHidden", 1);
                        }
                        else
                        {
                            checkBox3.Checked = false;
                            Properties.Settings.Default.CBE3 = false;
                            Properties.Settings.Default.Save();
                        }
                    }
                }
                else if (checkBox3.Checked == false)
                {
                    Properties.Settings.Default.CBE3 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowSuperHidden", 0);
                }
            }
            else if (Properties.Settings.Default.CatWork == true)
            {
                if (checkBox3.Checked == true)
                {
                    Properties.Settings.Default.CBR3 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel").SetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}", 0);
                }
                else if (checkBox3.Checked == false)
                {
                    Properties.Settings.Default.CBR1 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel").SetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}", 1);
                }
            }
            else if (Properties.Settings.Default.CatSec == true)
            {
                if (checkBox3.Checked == true)
                {
                    Properties.Settings.Default.CBU3 = true;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate").SetValue("ExcludeWUDriversInQualityUpdate", 1);
                }
                else if (checkBox3.Checked == false)
                {
                    Properties.Settings.Default.CBU3 = false;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate").SetValue("ExcludeWUDriversInQualityUpdate", 0);
                }
            }
            else if (Properties.Settings.Default.CatEtc == true)
            {
                if (checkBox3.Checked == true)
                {
                    Properties.Settings.Default.CBET3 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer").SetValue("AltTabSettings", 1);
                }
                else if (checkBox3.Checked == false)
                {
                    Properties.Settings.Default.CBET3 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer").SetValue("AltTabSettings", 0);
                }
            }
            else if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox3.Checked == true)
                {
                    Properties.Settings.Default.CB3 = true;
                    Properties.Settings.Default.Save();
                    try
                    {
                        Registry.ClassesRoot.DeleteSubKey(@"CLSID\{09A47860-11B0-4DA5-AFA5-26D86198A780}\InprocServer32");
                        Registry.ClassesRoot.DeleteSubKey(@"CLSID\{09A47860-11B0-4DA5-AFA5-26D86198A780}\Version");
                    }
                    catch
                    {

                    }

                }
                else if (checkBox3.Checked == false)
                {
                    Properties.Settings.Default.CB3 = false;
                    Properties.Settings.Default.Save();
                    try
                    {
                        Registry.ClassesRoot.CreateSubKey(@"CLSID\{09A47860-11B0-4DA5-AFA5-26D86198A780}\InprocServer32").SetValue("", @"C:\Program Files\Windows Defender\shellext.dll");
                        Registry.ClassesRoot.CreateSubKey(@"CLSID\{09A47860-11B0-4DA5-AFA5-26D86198A780}\InprocServer32").SetValue("ThreadingModel", "Apartment");
                        Registry.ClassesRoot.CreateSubKey(@"CLSID\{09A47860-11B0-4DA5-AFA5-26D86198A780}\Version").SetValue("", "10.0.22621.1");
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatExp == true)
            {
                if (checkBox4.Checked == true)
                {
                    Properties.Settings.Default.CBE4 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("LaunchTo", 1);

                }
                else if (checkBox4.Checked == false)
                {
                    Properties.Settings.Default.CBE4 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("LaunchTo", 2);
                }
            }
            else if (Properties.Settings.Default.CatWork == true)
            {
                if (checkBox4.Checked == true)
                {
                    Properties.Settings.Default.CBR4 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\NamingTemplates").SetValue("ShortcutNameTemplate", "%s.lnk");
                }
                else if (checkBox4.Checked == false)
                {
                    Properties.Settings.Default.CBR4 = false;
                    Properties.Settings.Default.Save();
                    try
                    {
                        Registry.CurrentUser.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\NamingTemplates");
                    }
                    catch
                    {

                    }
                }
            }
            else if (Properties.Settings.Default.CatSec == true)
            {
                if (checkBox4.Checked == true)
                {
                    Properties.Settings.Default.CBU4 = true;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection").SetValue("AllowTelemetry ", 0);
                }
                else if (checkBox4.Checked == false)
                {
                    Properties.Settings.Default.CBU4 = false;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection").SetValue("AllowTelemetry ", 1);
                }
            }
            else if (Properties.Settings.Default.CatEtc == true)
            {
                if (checkBox4.Checked == true)
                {
                    Properties.Settings.Default.CBET4 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Associations").SetValue("LowRiskFileTypes", ".exe;.msi;");
                }
                else if (checkBox4.Checked == false)
                {
                    Properties.Settings.Default.CBET4 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Associations").SetValue("LowRiskFileTypes", "");
                }
            }
            else if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox4.Checked == true)
                {
                    Properties.Settings.Default.CB4 = true;
                    Properties.Settings.Default.Save();
                    try
                    {
                        Registry.ClassesRoot.CreateSubKey(@"*\shell\pintohomefile").SetValue("ProgrammaticAccessOnly", "");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohomefile").SetValue("ProgrammaticAccessOnly", "");
                        Registry.ClassesRoot.CreateSubKey(@"Folder\shell\pintohomefile").SetValue("ProgrammaticAccessOnly", "");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohomefile").SetValue("ProgrammaticAccessOnly", "");
                        Registry.ClassesRoot.DeleteSubKeyTree(@"Drive\shell\pintohome");
                        Registry.ClassesRoot.DeleteSubKeyTree(@"Folder\shell\pintohome");
                        Registry.ClassesRoot.DeleteSubKeyTree(@"Network\shell\pintohome");
                    }
                    catch
                    {

                    }
                }
                else if (checkBox4.Checked == false)
                {
                    Properties.Settings.Default.CB4 = false;
                    Properties.Settings.Default.Save();
                    try
                    {
                        Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shell\pintohome").SetValue("CommandStateHandler", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shell\pintohome").SetValue("CommandStateSync", "");
                        Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shell\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
                        Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shell\pintohome\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome").SetValue("CommandStateHandler", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome").SetValue("CommandStateSync", "");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome").SetValue("NeverDefault", "");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Folder\shell\pintohome").SetValue("AppliesTo", "System.ParsingName:<>\"::{679f85cb-0220-4080-b29b-5540cc05aab6}\" AND System.ParsingName:<>\"::{645FF040-5081-101B-9F08-00AA002F954E}\" AND System.IsFolder:=System.StructuredQueryType.Boolean#True");
                        Registry.ClassesRoot.CreateSubKey(@"Folder\shell\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
                        Registry.ClassesRoot.CreateSubKey(@"Folder\shell\pintohome\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome").SetValue("CommandStateHandler", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome").SetValue("CommandStateSync", "");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome").SetValue("NeverDefault", "");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");

                    }
                    catch
                    {

                    }
                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatExp == true)
            {
                if (checkBox5.Checked == true)
                {
                    Properties.Settings.Default.CBE5 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Clipboard").SetValue("EnableClipboardHistory", 1);

                }
                else if (checkBox5.Checked == false)
                {
                    Properties.Settings.Default.CBE5 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Clipboard").SetValue("EnableClipboardHistory", 0);
                }
            }
            else if (Properties.Settings.Default.CatWork == true)
            {
                if (checkBox5.Checked == true)
                {
                    Properties.Settings.Default.CBR5 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowSecondsInSystemClock", 1);
                }
                else if (checkBox5.Checked == false)
                {
                    Properties.Settings.Default.CBR1 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowSecondsInSystemClock", 0);
                }
            }
            else if (Properties.Settings.Default.CatSec == true)
            {
                if (checkBox5.Checked == true)
                {
                    Properties.Settings.Default.CBU5 = true;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System").SetValue("EnableSmartScreen", 0);
                }
                else if (checkBox5.Checked == false)
                {
                    Properties.Settings.Default.CBU5 = false;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System").SetValue("EnableSmartScreen", 1);
                }
            }
            else if (Properties.Settings.Default.CatEtc == true)
            {
                if (checkBox5.Checked == true)
                {
                    Properties.Settings.Default.CBET5 = true;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control").SetValue("WaitToKillServiceTimeout", 0x1388);
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop").SetValue("WaitToKillAppTimeout", 0x1388);
                }
                else if (checkBox5.Checked == false)
                {
                    Properties.Settings.Default.CBET5 = false;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control").SetValue("WaitToKillServiceTimeout", 0x7d0);
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop").SetValue("WaitToKillAppTimeout", 0x7d0);
                }
            }
            else if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox5.Checked == true)
                {
                    Properties.Settings.Default.CB5 = true;
                    Properties.Settings.Default.Save();
                    checkBox2.Enabled = false;
                    checkBox7.Enabled = false;
                    checkBox2.Checked = false;
                    checkBox7.Checked = false;
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked").SetValue("{596AB062-B4D2-4215-9F74-E9109B0A8153}", "");
                }
                else if (checkBox5.Checked == false)
                {
                    Properties.Settings.Default.CB5 = false;
                    Properties.Settings.Default.Save();
                    checkBox2.Enabled = true;
                    checkBox7.Enabled = true;
                    try
                    {
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked");
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatWork == true)
            {
                if (checkBox6.Checked == true)
                {
                    Properties.Settings.Default.CBR6 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowTaskViewButton", 0);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("TaskbarDa", 0);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("TaskbarMn", 0);
                }
                else if (checkBox6.Checked == false)
                {
                    Properties.Settings.Default.CBR1 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowTaskViewButton", 1);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("TaskbarDa", 1);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("TaskbarMn", 1);
                }
            }
            else if (Properties.Settings.Default.CatSec == true)
            {
                if (checkBox6.Checked == true)
                {
                    Properties.Settings.Default.CBU6 = true;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System").SetValue("EnableLUA", 0);

                }
                else if (checkBox6.Checked == false)
                {
                    Properties.Settings.Default.CBU6 = false;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System").SetValue("EnableLUA", 1);

                }
            }
            else if (Properties.Settings.Default.CatEtc == true)
            {
                if (checkBox6.Checked == true)
                {
                    Properties.Settings.Default.CBET6 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion").SetValue("NoLowDiskSpaceChecks", 1);
                }
                else if (checkBox6.Checked == false)
                {
                    Properties.Settings.Default.CBET6 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion").SetValue("NoLowDiskSpaceChecks", 0);
                }
            }
            else if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox6.Checked == true)
                {
                    Properties.Settings.Default.CB6 = true;
                    Properties.Settings.Default.Save();
                    try
                    {
                        Registry.ClassesRoot.DeleteSubKey(@"Folder\ShellEx\ContextMenuHandlers\Library Location");
                    }
                    catch
                    {

                    }
                }
                else if (checkBox6.Checked == false)
                {
                    Properties.Settings.Default.CB6 = false;
                    Properties.Settings.Default.Save();
                    Registry.ClassesRoot.CreateSubKey(@"Folder\ShellEx\ContextMenuHandlers\Library Location").SetValue("", "{3dad6c5d-2167-4cae-9914-f99e41c12cfa}");
                }
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatWork == true)
            {
                if (checkBox7.Checked == true)
                {
                    Properties.Settings.Default.CBR7 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Taskband").SetValue("MinThumbSizePX", 500);
                }
                else if (checkBox7.Checked == false)
                {
                    Properties.Settings.Default.CBR7 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Taskband").SetValue("MinThumbSizePX", 300);
                }
            }
            else if (Properties.Settings.Default.CatSec == true)
            {
                if (checkBox7.Checked == true)
                {
                    Properties.Settings.Default.CBU7 = true;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender").SetValue("DisableAntiSpyware ", 1);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableBehaviorMonitoring ", 1);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableOnAccessProtection ", 1);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableScanOnRealtimeEnable ", 1);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableIOAVProtection ", 1);
                }
                else if (checkBox7.Checked == false)
                {
                    Properties.Settings.Default.CBU7 = false;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender").SetValue("DisableAntiSpyware ", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableBehaviorMonitoring ", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableOnAccessProtection ", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableScanOnRealtimeEnable ", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableIOAVProtection ", 0);

                }
            }
            else if (Properties.Settings.Default.CatEtc == true)
            {
                if (checkBox7.Checked == true)
                {
                    Properties.Settings.Default.CBET7 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("EnableSnapAssistFlyout", 0);
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop").SetValue("WindowArrangementActive", 0);
                }
                else if (checkBox7.Checked == false)
                {
                    Properties.Settings.Default.CBET7 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("EnableSnapAssistFlyout", 1);
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop").SetValue("WindowArrangementActive", 1);
                }
            }
            else if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox7.Checked == true)
                {
                    Properties.Settings.Default.CB7 = true;
                    Properties.Settings.Default.Save();
                    checkBox5.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox5.Checked = false;
                    checkBox2.Checked = false;
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked").SetValue("{f81e9010-6ea4-11ce-a7ff-00aa003ca9f6}", "");
                }
                else if (checkBox7.Checked == false)
                {
                    Properties.Settings.Default.CB7 = false;
                    Properties.Settings.Default.Save();
                    checkBox5.Enabled = true;
                    checkBox2.Enabled = true;
                    try
                    {
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked");
                    }
                    catch
                    {

                    }
                    

                }
            }
            if (Properties.Settings.Default.CatSet == true)
            {
                if (checkBox7.Checked == true)
                {
                    Properties.Settings.Default.CBS = true;
                    Properties.Settings.Default.RebootEnabled = false;
                    Reboot.Stop();
                    Reboot.Enabled = false;
                    restartReq.Visible = false;
                    explorerReq.Visible = false;
                    Properties.Settings.Default.Save();
                }
                else if (checkBox7.Checked == false)
                {
                    Properties.Settings.Default.CBS = false;
                    Properties.Settings.Default.RebootEnabled = true;
                    Properties.Settings.Default.Save();
                }
            }

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatWork == true)
            {
                if (checkBox8.Checked == true)
                {
                    Properties.Settings.Default.CBR8 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ExtendedUIHoverTime", (int)10);
                }
                else if (checkBox8.Checked == false)
                {
                    Properties.Settings.Default.CBR1 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ExtendedUIHoverTime", 0x3e8);
                }
            }
            else if (Properties.Settings.Default.CatSec == true)
            {
                if (checkBox8.Checked == true)
                {
                    Properties.Settings.Default.CBU8 = true;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\MRT").SetValue("DontReportInfectionInformation", 1);
                }
                else if (checkBox8.Checked == false)
                {
                    Properties.Settings.Default.CBU8 = false;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\MRT").SetValue("DontReportInfectionInformation", 0);
                }
            }
            else if (Properties.Settings.Default.CatEtc == true)
            {
                if (checkBox8.Checked == true)
                {
                    Properties.Settings.Default.CBET8 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Accessibility\StickyKeys").SetValue("Flags", "510");
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Accessibility\Keyboard Response").SetValue("Flags", "126");
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Accessibility\ToggleKeys").SetValue("Flags", "62");
                }
                else if (checkBox8.Checked == false)
                {
                    Properties.Settings.Default.CBET8 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Accessibility\StickyKeys").SetValue("Flags", "506");
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Accessibility\Keyboard Response").SetValue("Flags", "122");
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Accessibility\ToggleKeys").SetValue("Flags", "58");
                }
            }
            else if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox8.Checked == true)
                {
                    Properties.Settings.Default.CB8 = true;
                    Properties.Settings.Default.Save();
                    try
                    {
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Classes\Folder\shellex\ContextMenuHandlers\PintoStartScreen");
                        Registry.ClassesRoot.CreateSubKey(@"exefile\shellex\ContextMenuHandlers\PintoStartScreen").SetValue("", "");
                    }
                    catch
                    {

                    }
                }
                else if (checkBox8.Checked == false)
                {
                    Properties.Settings.Default.CB8 = false;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\Folder\shellex\ContextMenuHandlers\PintoStartScreen").SetValue("", "{470C0EBD-5D73-4d58-9CED-E91E22E23282}");
                    Registry.ClassesRoot.CreateSubKey(@"exefile\shellex\ContextMenuHandlers\PintoStartScreen").SetValue("", "{470C0EBD-5D73-4d58-9CED-E91E22E23282}");
                }
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatWork == true)
            {
                if (checkBox9.Checked == true)
                {
                    Properties.Settings.Default.CBR9 = true;
                    Properties.Settings.Default.Save();
                    Process.Start("cmd.exe", "/c \"reg.exe add \"HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32\" /f /ve\"");
                }
                else if (checkBox9.Checked == false)
                {
                    Properties.Settings.Default.CBR9 = false;
                    Properties.Settings.Default.Save();
                    Process.Start("cmd.exe", "/c \"reg delete \"HKCU\\Software\\Classes\\CLSID{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32\" /f\"");
                }
            }
            else if (Properties.Settings.Default.CatSec == true)
            {
                if (checkBox9.Checked == true)
                {
                    Properties.Settings.Default.CBU9 = true;
                    Properties.Settings.Default.Save();
                    Process.Start("cmd.exe", "/c \"netsh advfirewall set allprofiles state off\"");
                }
                else if (checkBox9.Checked == false)
                {
                    Properties.Settings.Default.CBU9 = false;
                    Properties.Settings.Default.Save();
                    Process.Start("cmd.exe", "/c \"netsh advfirewall set allprofiles state on\"");
                }
            }
            else if (Properties.Settings.Default.CatEtc == true)
            {
                if (checkBox9.Checked == true)
                {
                    Properties.Settings.Default.CBET9 = true;
                    Properties.Settings.Default.Save();
                    Process.Start("cmd.exe", "/c \"bcdedit /set \"{current}\" bootmenupolicy legacy\"");
                }
                else if (checkBox9.Checked == false)
                {
                    Properties.Settings.Default.CBET9 = false;
                    Properties.Settings.Default.Save();
                    Process.Start("cmd.exe", "/c \"bcdedit /set \"{current}\" bootmenupolicy standard\"");
                }
            }
            else if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox9.Checked == true)
                {
                    Properties.Settings.Default.CB9 = true;
                    Properties.Settings.Default.Save();
                    try
                    {
                        Registry.ClassesRoot.DeleteSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\CopyAsPathMenu");
                    }
                    catch
                    {

                    }

                }
                else if (checkBox9.Checked == false)
                {
                    Properties.Settings.Default.CB9 = false;
                    Properties.Settings.Default.Save();
                    Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\CopyAsPathMenu").SetValue("", "{f3d06e7c-1e45-4a26-847e-f9fcdee59be0}");
                }
            }
        }

        private void checkBox10_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatSec == true)
            {
                if (checkBox10.Checked == true)
                {
                    Properties.Settings.Default.CBU10 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager").SetValue("ContentDeliveryAllowed", 0);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager").SetValue("DesktopSpotlightOemEnabled", 0);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager").SetValue("FeatureManagementEnabled", 0);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager").SetValue("PreInstalledAppsEnabled", 0);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager").SetValue("PreInstalledAppsEverEnabled", 0);
                    checkBox10.Enabled = false;
                }
                else if (checkBox10.Checked == false)
                {
                    Properties.Settings.Default.CBU10 = false;
                    Properties.Settings.Default.Save();
                }
            }
            else if (Properties.Settings.Default.CatEtc == true)
            {
                if (checkBox10.Checked == true)
                {
                    Properties.Settings.Default.CBET10 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MultitaskingView\AltTabViewHost").SetValue("BackgroundDimmingLayer_percent", (int)70);

                }
                else if (checkBox10.Checked == false)
                {
                    Properties.Settings.Default.CBET10 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MultitaskingView\AltTabViewHost").SetValue("BackgroundDimmingLayer_percent", 0);
                }
            }
            else if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox10.Checked == true)
                {
                    Properties.Settings.Default.CB10 = true;
                    Properties.Settings.Default.Save();
                    try
                    {
                        Registry.ClassesRoot.DeleteSubKey(@"*\shellex\ContextMenuHandlers\{90AA3A4E-1CBA-4233-B8BB-535773D48449}");
                    }
                    catch
                    {

                    }
                }
                else if (checkBox10.Checked == false)
                {
                    Properties.Settings.Default.CB10 = false;
                    Properties.Settings.Default.Save();
                    Registry.ClassesRoot.CreateSubKey(@"*\shellex\ContextMenuHandlers\{90AA3A4E-1CBA-4233-B8BB-535773D48449}").SetValue("", "Taskband Pin");

                }
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatEtc == true)
            {
                if (checkBox11.Checked == true)
                {
                    Properties.Settings.Default.CBET11 = true;
                    Properties.Settings.Default.Save();
                    Process.Start("powercfg.exe", "/setactive 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c");
                }
                else if (checkBox11.Checked == false)
                {
                    Properties.Settings.Default.CBET11 = false;
                    Properties.Settings.Default.Save();
                    Process.Start("powercfg.exe", "/setactive 381b4222-f694-41f0-9685-ff5bb260df2e");
                }
            }
            else if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox11.Checked == true)
                {
                    Properties.Settings.Default.CB11 = true;
                    Properties.Settings.Default.Save();
                    try
                    {
                        Registry.ClassesRoot.DeleteSubKeyTree(@"Folder\shell\opennewtab");
                    }
                    catch
                    {

                    }
                }
                else if (checkBox11.Checked == false)
                {
                    Properties.Settings.Default.CB11 = false;
                    Properties.Settings.Default.Save();
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("CommandStateHandler", "{11dbb47c-a525-400b-9e80-a54615a090c0}");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("CommandStateSync", "");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("LaunchExplorerFlags", (int)0x20);
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("MUIVerb", "@windows.storage.dll,-8519");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("MultiSelectModel", "Document");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("OnlyInBrowserWindow", "");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab\command").SetValue("DelegateExecute", "{11dbb47c-a525-400b-9e80-a54615a090c0}");
                }
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatEtc == true)
            {
                if (checkBox12.Checked == true)
                {
                    Properties.Settings.Default.CBET12 = true;
                    Properties.Settings.Default.Save();
                    Process.Start("cmd.exe", "/c \"powercfg /SETACVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 0\"");
                }
                else if (checkBox12.Checked == false)
                {
                    Properties.Settings.Default.CBET12 = false;
                    Properties.Settings.Default.Save();
                    Process.Start("cmd.exe", "/c \"powercfg /SETACVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 600\"");
                }
            }
            if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox12.Checked == true)
                {
                    Properties.Settings.Default.CB12 = true;
                    Properties.Settings.Default.Save();
                    Registry.ClassesRoot.CreateSubKey(@"Drive\shell\encrypt-bde").SetValue("LegacyDisable", "");
                    Registry.ClassesRoot.CreateSubKey(@"Drive\shell\encrypt-bde-elev").SetValue("LegacyDisable", "");
                    checkBox12.Enabled = false;
                }
                else if (checkBox12.Checked == false)
                {
                    Properties.Settings.Default.CB12 = false;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                DialogResult ExpReboot = MessageBox.Show("Вы точно хотите перезапустить компьютер?", "Awesome Windows Customizer - Уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ExpReboot == DialogResult.Yes)
                {
                    Process.Start("cmd.exe", "/c shutdown /r /t 0");
                }
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                DialogResult ExpReboot = MessageBox.Show("Are you sure you want to reboot system?", "Awesome Windows Customizer - Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ExpReboot == DialogResult.Yes)
                {
                    Process.Start("cmd.exe", "/c shutdown /r /t 0");
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatExp == true)
            {
                if (checkBox1.Checked == true)
                {
                    Properties.Settings.Default.CBE1 = true;
                    Properties.Settings.Default.Save();
                    try
                    {
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{d3162b92-9365-467a-956b-92703aca08af}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{d3162b92-9365-467a-956b-92703aca08af}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{374DE290-123F-4565-9164-39C4925E467B}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{088e3905-0323-4b02-9826-5d99428e115f}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{374DE290-123F-4565-9164-39C4925E467B}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{088e3905-0323-4b02-9826-5d99428e115f}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
                    }
                    catch
                    {

                    }



                }
                else if (checkBox1.Checked == false)
                {
                    Properties.Settings.Default.CBE1 = false;
                    Properties.Settings.Default.Save();
                    try
                    {
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{d3162b92-9365-467a-956b-92703aca08af}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{d3162b92-9365-467a-956b-92703aca08af}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{374DE290-123F-4565-9164-39C4925E467B}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{088e3905-0323-4b02-9826-5d99428e115f}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{374DE290-123F-4565-9164-39C4925E467B}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{088e3905-0323-4b02-9826-5d99428e115f}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
                        Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
                    }
                    catch
                    {

                    }

                }
            }
            else if (Properties.Settings.Default.CatWork == true)
            {
                if (checkBox1.Checked == true)
                {
                    Properties.Settings.Default.CBR1 = true;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("Start_Layout", 1);

                }
                else if (checkBox1.Checked == false)
                {
                    Properties.Settings.Default.CBR1 = false;
                    Properties.Settings.Default.Save();
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("Start_Layout", 3);
                }
            }
            else if (Properties.Settings.Default.CatSec == true)
            {
                if (checkBox1.Checked == true)
                {
                    Properties.Settings.Default.CBU1 = true;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU").SetValue("NoAutoUpdate", 1);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate").SetValue("DoNotConnectToWindowsUpdateInternetLocations", 1);
                }
                else if (checkBox1.Checked == false)
                {
                    Properties.Settings.Default.CBU1 = false;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU").SetValue("NoAutoUpdate", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate").SetValue("DoNotConnectToWindowsUpdateInternetLocations", 0);
                }
            }
            else if (Properties.Settings.Default.CatEtc == true)
            {
                if (checkBox1.Checked == true)
                {
                    Properties.Settings.Default.CBET1 = true;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System").SetValue("verbosestatus", 1);
                }
                else if (checkBox1.Checked == false)
                {
                    Properties.Settings.Default.CBET1 = false;
                    Properties.Settings.Default.Save();
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System").SetValue("verbosestatus", 0);
                }
            }
            else if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox1.Checked == true)
                {
                    Properties.Settings.Default.CB1 = true;
                    Properties.Settings.Default.Save();
                    Registry.ClassesRoot.CreateSubKey(@"SystemFileAssociations\image\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"batfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"cmdfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"docxfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"htmlfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"inffile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"inifile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"regfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"txtfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"VBSFile\shell\print").SetValue("ProgrammaticAccessOnly", "");


                }
                else if (checkBox1.Checked == false)
                {
                    Properties.Settings.Default.CB1 = false;
                    Properties.Settings.Default.Save();
                    Registry.ClassesRoot.CreateSubKey(@"SystemFileAssociations\image\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"batfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"cmdfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"docxfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"htmlfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"inffile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"inifile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"regfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"txtfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"VBSFile\shell\print").SetValue("ProgrammaticAccessOnly", '-');
                }
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true)
            {
                if (checkBox13.Checked == true)
                {
                    Properties.Settings.Default.CB13 = true;
                    Properties.Settings.Default.Save();
                    Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\SendTo").SetValue("", "");

                }
                else if (checkBox13.Checked == false)
                {
                    Properties.Settings.Default.CB13 = false;
                    Properties.Settings.Default.Save();
                    Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\SendTo").SetValue("", "{7BA4C740-9E81-11CF-99D3-00AA004AE837}");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                MessageBox.Show("Awesome Windows Customizer\nДата сборки: 19.05.2024 15:15\nНомер сборки: 775.awcrelease\nВерсия AWC: 1.2.1 Release", "Awesome Windows Customizer - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (Properties.Settings.Default.Lang == 2)
            {
                MessageBox.Show("Awesome Windows Customizer\nBuild date: 19.05.2024 15:15\nBuild number: 775.awcrelease\nVersion of AWC: 1.2.1 Release", "Awesome Windows Customizer - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                DialogResult ExpReboot = MessageBox.Show("Вы точно хотите перезапустить проводник?", "Awesome Windows Customizer - Уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ExpReboot == DialogResult.Yes)
                {
                    Properties.Settings.Default.NeedExpReboot = false;
                    Process.Start("powershell.exe", "-WindowStyle hidden Stop-Process -processname explorer");
                }
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                DialogResult ExpReboot = MessageBox.Show("Are you sure you want to restart Explorer?", "Awesome Windows Customizer - Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ExpReboot == DialogResult.Yes)
                {
                    Properties.Settings.Default.NeedExpReboot = false;
                    Process.Start("powershell.exe", "-WindowStyle hidden Stop-Process -processname explorer");
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Process.Start("explorer.exe");
            this.Explorer.Stop();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                MessageBox.Show("Вы изменили одну или несколько настроек, которые требуют перезагрузки системы для применения. С помощью кнопки выше, вы можете перезагрузить систему.\n\nВы можете отключить данное напоминание в настройках.", "Awesome Windows Customizer - Требуется перезагрузка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                MessageBox.Show("You have changed one or more settings that require a system reboot to take effect. Using the button above, you can reboot the system.\n\nYou can disable this reminder in the settings.", "Awesome Windows Customizer - Reboot required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                MessageBox.Show("Вы изменили одну или несколько настроек, которые требуют перезагрузки Проводника для применения. С помощью кнопки выше, вы можете перезагрузить Проводник.\n\nВы можете отключить данное напоминание в настройках.", "Awesome Windows Customizer - Требуется перезагрузка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                MessageBox.Show("You have changed one or more settings that require a restart of Explorer to take effect. Using the button above, you can restart Explorer.\n\nYou can disable this reminder in the settings.", "Awesome Windows Customizer - Explorer restart required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB1 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB1 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB1 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB2 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB2 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB2 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB3 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB3 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB3 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB4 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB4 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB4 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
        }

        private void checkBox5_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB5 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB5 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB5 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
            if (Properties.Settings.Default.CatWork == true && Properties.Settings.Default.CBR5 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatWork == true && Properties.Settings.Default.CBR5 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatWork == false && Properties.Settings.Default.CBR5 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
        }

        private void checkBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB6 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB6 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB6 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
            if (Properties.Settings.Default.CatWork == true && Properties.Settings.Default.CBR6 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatWork == true && Properties.Settings.Default.CBR6 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatWork == false && Properties.Settings.Default.CBR6 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
            if (Properties.Settings.Default.CatSec == true && Properties.Settings.Default.CBU6 == true)
            {
                Properties.Settings.Default.NeedReboot = true;
            }
            else if (Properties.Settings.Default.CatSec == true && Properties.Settings.Default.CBU6 == false)
            {
                Properties.Settings.Default.NeedReboot = true;
            }
            else if (Properties.Settings.Default.CatSec == false && Properties.Settings.Default.CBU6 == false)
            {
                Properties.Settings.Default.NeedReboot = false;
            }
        }

        private void checkBox7_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB7 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB7 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB7 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
            if (Properties.Settings.Default.CatWork == true && Properties.Settings.Default.CBR7 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatWork == true && Properties.Settings.Default.CBR7 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatWork == false && Properties.Settings.Default.CBR7 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
            if (Properties.Settings.Default.CatEtc == true && Properties.Settings.Default.CBET7 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatEtc == true && Properties.Settings.Default.CBET7 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatEtc == false && Properties.Settings.Default.CBET7 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
        }

        private void checkBox8_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB8 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB8 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB8 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
            if (Properties.Settings.Default.CatWork == true && Properties.Settings.Default.CBR8 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatWork == true && Properties.Settings.Default.CBR8 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatWork == false && Properties.Settings.Default.CBR8 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
        }

        private void checkBox9_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB9 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB9 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB9 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
            if (Properties.Settings.Default.CatWork == true && Properties.Settings.Default.CBR9 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatWork == true && Properties.Settings.Default.CBR9 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatWork == false && Properties.Settings.Default.CBR9 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
            if (Properties.Settings.Default.CatSec == true && Properties.Settings.Default.CBU9 == true)
            {
                Properties.Settings.Default.NeedReboot = true;
            }
            else if (Properties.Settings.Default.CatSec == true && Properties.Settings.Default.CBU9 == false)
            {
                Properties.Settings.Default.NeedReboot = true;
            }
            else if (Properties.Settings.Default.CatSec == false && Properties.Settings.Default.CBU9 == false)
            {
                Properties.Settings.Default.NeedReboot = false;
            }

        }

        private void checkBox10_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB10 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB10 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB10 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
            if (Properties.Settings.Default.CatEtc == true && Properties.Settings.Default.CBET10 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatEtc == true && Properties.Settings.Default.CBET10 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatEtc == false && Properties.Settings.Default.CBET10 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }

        }

        private void checkBox11_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB11 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB11 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB11 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
        }

        private void checkBox12_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB12 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB12 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB12 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
        }

        private void checkBox13_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB13 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB13 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB13 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
        }

        private void checkBox14_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB14 == true)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == true && Properties.Settings.Default.CB14 == false)
            {
                Properties.Settings.Default.NeedExpReboot = true;
            }
            else if (Properties.Settings.Default.CatContext == false && Properties.Settings.Default.CB14 == false)
            {
                Properties.Settings.Default.NeedExpReboot = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /ipk W269N-WFGWX-YVC9B-4J6C9-T83GX\"");
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /skms kms.loli.best\"");
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /ato\"");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.CatAct == true)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    MessageBox.Show("По какой то причине, иногда не получается активировать Windows с первой попытки.\nЕсли это произойдёт, нажимайте кнопку 'Активировать' до тех пор, пока не появится окно 'Активация выполнена успешно'.", "AWC - Обратите внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    MessageBox.Show("For some reason, sometimes it is not possible to activate Windows on the first try.\nIf this happens, click the 'Activate' button until the 'Activation completed successfully' window appears.", "AWC - Please note!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else if (Properties.Settings.Default.CatContext == true)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    MessageBox.Show("В этой вкладке вы можете скрыть ненужные параметры контекстного меню.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    MessageBox.Show("In this tab you can hide unnecessary context menu options.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else if (Properties.Settings.Default.CatRec == true)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    MessageBox.Show("В этой вкладке вы можете 'освежить' свою систему, воспользовавшись встроенными в Windows утилитами DISM и SFC, а также очистив временные файлы.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    MessageBox.Show("In this tab, you can 'refresh' your system by using the DISM and SFC utilities built into Windows, as well as by clearing temporary files.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /ipk TX9XD-98N7V-6WMQ6-BX7FG-H8Q99\"");
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /skms kms.loli.best\"");
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /ato\"");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /ipk NPPR9-FWDCX-D2C8J-H872K-2YT43\"");
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /skms kms.loli.best\"");
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /ato\"");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /ipk DCPHK-NFMTC-H88MJ-PFHPY-QJ4BJ\"");
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /skms kms.loli.best\"");
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /ato\"");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /ipk M7XTQ-FN8P6-TTKYV-9D4CC-J462D\"");
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /skms kms.loli.best\"");
            Process.Start("cmd.exe", "/wait /c \"slmgr.vbs /ato\"");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/wait /c \"cscript \"C:\\Program Files (x86)\\Microsoft Office\\Office16\\OSPP.VBS\" /inpkey:FXYTK-NJJ8C-GB6DW-3DYQT-6F7TH\"");
            Process.Start("cmd.exe", "/wait /c \"cscript \"C:\\Program Files (x86)\\Microsoft Office\\Office16\\OSPP.VBS\" /sethst:kms.loli.best\"");
            Process.Start("cmd.exe", "/wait /c \"cscript \"C:\\Program Files (x86)\\Microsoft Office\\Office16\\OSPP.VBS\" /act\"");
            Process.Start("cmd.exe", "/wait /c \"cscript \"C:\\Program Files\\Microsoft Office\\Office16\\OSPP.VBS\" /inpkey:FXYTK-NJJ8C-GB6DW-3DYQT-6F7TH\"");
            Process.Start("cmd.exe", "/wait /c \"cscript \"C:\\Program Files\\Microsoft Office\\Office16\\OSPP.VBS\" /sethst:kms.loli.best\"");
            Process.Start("cmd.exe", "/wait /c \"cscript \"C:\\Program Files\\Microsoft Office\\Office16\\OSPP.VBS\" /act\"");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                this.BackgroundImage = Properties.Resources.Fram2e_1;
                Properties.Settings.Default.Theme = 1;
                Properties.Settings.Default.Save();
                label1.ForeColor = Color.FromArgb(0xFFFFFF);
                label2.ForeColor = Color.FromArgb(0xFFFFFF);
                label3.ForeColor = Color.FromArgb(0xFFFFFF);
                label4.ForeColor = Color.FromArgb(0xFFFFFF);
                label5.ForeColor = Color.FromArgb(0xFFFFFF);
                label6.ForeColor = Color.FromArgb(0xFFFFFF);
                label7.ForeColor = Color.FromArgb(0xFFFFFF);
                label8.ForeColor = Color.FromArgb(0xFFFFFF);
                label9.ForeColor = Color.FromArgb(0xFFFFFF);
                label10.ForeColor = Color.FromArgb(0xFFFFFF);
                label11.ForeColor = Color.FromArgb(0xFFFFFF);
                label13.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox1.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox2.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox3.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox4.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox5.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox6.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox7.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox8.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox9.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox10.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox11.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox12.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox13.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox14.ForeColor = Color.FromArgb(0xFFFFFF);
                pictureBox1.BackgroundImage = Properties.Resources.awcrainbow;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                this.BackgroundImage = Properties.Resources.BW;
                Properties.Settings.Default.Theme = 2;
                Properties.Settings.Default.Save();
                label1.ForeColor = Color.FromArgb(0xFFFFFF);
                label2.ForeColor = Color.FromArgb(0xFFFFFF);
                label3.ForeColor = Color.FromArgb(0xFFFFFF);
                label4.ForeColor = Color.FromArgb(0xFFFFFF);
                label5.ForeColor = Color.FromArgb(0xFFFFFF);
                label6.ForeColor = Color.FromArgb(0xFFFFFF);
                label7.ForeColor = Color.FromArgb(0xFFFFFF);
                label8.ForeColor = Color.FromArgb(0xFFFFFF);
                label9.ForeColor = Color.FromArgb(0xFFFFFF);
                label10.ForeColor = Color.FromArgb(0xFFFFFF);
                label11.ForeColor = Color.FromArgb(0xFFFFFF);
                label13.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox1.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox2.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox3.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox4.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox5.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox6.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox7.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox8.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox9.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox10.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox11.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox12.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox13.ForeColor = Color.FromArgb(0xFFFFFF);
                checkBox14.ForeColor = Color.FromArgb(0xFFFFFF);
                pictureBox1.BackgroundImage = Properties.Resources.awcBLACK;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                this.BackgroundImage = Properties.Resources.red;
                Properties.Settings.Default.Theme = 3;
                Properties.Settings.Default.Save();
                label1.ForeColor = Color.FromArgb(0xFFABAB);
                label2.ForeColor = Color.FromArgb(0xFFABAB);
                label3.ForeColor = Color.FromArgb(0xFFABAB);
                label4.ForeColor = Color.FromArgb(0xFFABAB);
                label5.ForeColor = Color.FromArgb(0xFFABAB);
                label6.ForeColor = Color.FromArgb(0xFFABAB);
                label7.ForeColor = Color.FromArgb(0xFFABAB);
                label8.ForeColor = Color.FromArgb(0xFFABAB);
                label9.ForeColor = Color.FromArgb(0xFFABAB);
                label10.ForeColor = Color.FromArgb(0xFFABAB);
                label11.ForeColor = Color.FromArgb(0xFFABAB);
                label13.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox1.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox2.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox3.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox4.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox5.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox6.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox7.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox8.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox9.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox10.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox11.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox12.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox13.ForeColor = Color.FromArgb(0xFFABAB);
                checkBox14.ForeColor = Color.FromArgb(0xFFABAB);
                pictureBox1.BackgroundImage = Properties.Resources.Union;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                this.BackgroundImage = Properties.Resources.orange;
                Properties.Settings.Default.Theme = 4;
                Properties.Settings.Default.Save();
                label1.ForeColor = Color.FromArgb(0xFFD8AB);
                label2.ForeColor = Color.FromArgb(0xFFD8AB);
                label3.ForeColor = Color.FromArgb(0xFFD8AB);
                label4.ForeColor = Color.FromArgb(0xFFD8AB);
                label5.ForeColor = Color.FromArgb(0xFFD8AB);
                label6.ForeColor = Color.FromArgb(0xFFD8AB);
                label7.ForeColor = Color.FromArgb(0xFFD8AB);
                label8.ForeColor = Color.FromArgb(0xFFD8AB);
                label9.ForeColor = Color.FromArgb(0xFFD8AB);
                label10.ForeColor = Color.FromArgb(0xFFD8AB);
                label11.ForeColor = Color.FromArgb(0xFFD8AB);
                label13.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox1.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox2.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox3.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox4.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox5.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox6.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox7.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox8.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox9.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox10.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox11.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox12.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox13.ForeColor = Color.FromArgb(0xFFD8AB);
                checkBox14.ForeColor = Color.FromArgb(0xFFD8AB);
                pictureBox1.BackgroundImage = Properties.Resources.Union_1;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                this.BackgroundImage = Properties.Resources.yellow;
                Properties.Settings.Default.Theme = 5;
                Properties.Settings.Default.Save();
                label1.ForeColor = Color.FromArgb(0xFFFCAB);
                label2.ForeColor = Color.FromArgb(0xFFFCAB);
                label3.ForeColor = Color.FromArgb(0xFFFCAB);
                label4.ForeColor = Color.FromArgb(0xFFFCAB);
                label5.ForeColor = Color.FromArgb(0xFFFCAB);
                label6.ForeColor = Color.FromArgb(0xFFFCAB);
                label7.ForeColor = Color.FromArgb(0xFFFCAB);
                label8.ForeColor = Color.FromArgb(0xFFFCAB);
                label9.ForeColor = Color.FromArgb(0xFFFCAB);
                label10.ForeColor = Color.FromArgb(0xFFFCAB);
                label11.ForeColor = Color.FromArgb(0xFFFCAB);
                label13.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox1.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox2.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox3.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox4.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox5.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox6.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox7.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox8.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox9.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox10.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox11.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox12.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox13.ForeColor = Color.FromArgb(0xFFFCAB);
                checkBox14.ForeColor = Color.FromArgb(0xFFFCAB);
                pictureBox1.BackgroundImage = Properties.Resources.Union_2;
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                this.BackgroundImage = Properties.Resources.green;
                Properties.Settings.Default.Theme = 6;
                Properties.Settings.Default.Save();
                label1.ForeColor = Color.FromArgb(0xCBFFAB);
                label2.ForeColor = Color.FromArgb(0xCBFFAB);
                label3.ForeColor = Color.FromArgb(0xCBFFAB);
                label4.ForeColor = Color.FromArgb(0xCBFFAB);
                label5.ForeColor = Color.FromArgb(0xCBFFAB);
                label6.ForeColor = Color.FromArgb(0xCBFFAB);
                label7.ForeColor = Color.FromArgb(0xCBFFAB);
                label8.ForeColor = Color.FromArgb(0xCBFFAB);
                label9.ForeColor = Color.FromArgb(0xCBFFAB);
                label10.ForeColor = Color.FromArgb(0xCBFFAB);
                label11.ForeColor = Color.FromArgb(0xCBFFAB);
                label13.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox1.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox2.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox3.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox4.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox5.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox6.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox7.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox8.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox9.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox10.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox11.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox12.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox13.ForeColor = Color.FromArgb(0xCBFFAB);
                checkBox14.ForeColor = Color.FromArgb(0xCBFFAB);
                pictureBox1.BackgroundImage = Properties.Resources.Union_3;
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                this.BackgroundImage = Properties.Resources.blue;
                Properties.Settings.Default.Theme = 7;
                Properties.Settings.Default.Save();
                label1.ForeColor = Color.FromArgb(0xBACEFF);
                label2.ForeColor = Color.FromArgb(0xBACEFF);
                label3.ForeColor = Color.FromArgb(0xBACEFF);
                label4.ForeColor = Color.FromArgb(0xBACEFF);
                label5.ForeColor = Color.FromArgb(0xBACEFF);
                label6.ForeColor = Color.FromArgb(0xBACEFF);
                label7.ForeColor = Color.FromArgb(0xBACEFF);
                label8.ForeColor = Color.FromArgb(0xBACEFF);
                label9.ForeColor = Color.FromArgb(0xBACEFF);
                label10.ForeColor = Color.FromArgb(0xBACEFF);
                label11.ForeColor = Color.FromArgb(0xBACEFF);
                label13.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox1.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox2.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox3.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox4.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox5.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox6.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox7.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox8.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox9.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox10.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox11.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox12.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox13.ForeColor = Color.FromArgb(0xBACEFF);
                checkBox14.ForeColor = Color.FromArgb(0xBACEFF);
                pictureBox1.BackgroundImage = Properties.Resources.Union_5;
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                this.BackgroundImage = Properties.Resources.violet;
                Properties.Settings.Default.Theme = 8;
                Properties.Settings.Default.Save();
                label1.ForeColor = Color.FromArgb(0xCBABFF);
                label2.ForeColor = Color.FromArgb(0xCBABFF);
                label3.ForeColor = Color.FromArgb(0xCBABFF);
                label4.ForeColor = Color.FromArgb(0xCBABFF);
                label5.ForeColor = Color.FromArgb(0xCBABFF);
                label6.ForeColor = Color.FromArgb(0xCBABFF);
                label7.ForeColor = Color.FromArgb(0xCBABFF);
                label8.ForeColor = Color.FromArgb(0xCBABFF);
                label9.ForeColor = Color.FromArgb(0xCBABFF);
                label10.ForeColor = Color.FromArgb(0xCBABFF);
                label11.ForeColor = Color.FromArgb(0xCBABFF);
                label13.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox1.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox2.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox3.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox4.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox5.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox6.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox7.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox8.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox9.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox10.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox11.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox12.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox13.ForeColor = Color.FromArgb(0xCBABFF);
                checkBox14.ForeColor = Color.FromArgb(0xCBABFF);
                pictureBox1.BackgroundImage = Properties.Resources.Union_4;
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                Properties.Settings.Default.Lang = 1;
                Properties.Settings.Default.Save();
                comboBox1.Items[0] = "Rainbow (по умолчанию)";
                comboBox1.Items[1] = "Черно-белая";
                comboBox1.Items[2] = "Красная";
                comboBox1.Items[3] = "Оранжевая";
                comboBox1.Items[4] = "Жёлтая";
                comboBox1.Items[5] = "Зелёная";
                comboBox1.Items[6] = "Голубая";
                comboBox1.Items[7] = "Фиолетовая";
                label1.Text = "Настройки программы";
                label9.Text = "Тема";
                button19.Text = "Сбросить все настройки";
                checkBox7.Text = "Скрыть напоминание о необходимости перезагрузки";
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                Properties.Settings.Default.Lang = 2;
                Properties.Settings.Default.Save();
                comboBox1.Items[0] = "Rainbow (default)";
                comboBox1.Items[1] = "Monochrome";
                comboBox1.Items[2] = "Red";
                comboBox1.Items[3] = "Orange";
                comboBox1.Items[4] = "Yellow";
                comboBox1.Items[5] = "Green";
                comboBox1.Items[6] = "Blue";
                comboBox1.Items[7] = "Purple";
                label1.Text = "App settings";
                label9.Text = "Theme";
                button19.Text = "Reset all settings";
                checkBox7.Text = "Hide the reminder to reboot";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                DialogResult eraseall = MessageBox.Show("Вы уверены что хотите сбросить все настройки Awesome Windows Tweaker?\nНекоторые настройки не будут сброшены.", "AWC - Уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (eraseall == DialogResult.Yes)
                {
                    Properties.Settings.Default.CB1 = false;
                    Properties.Settings.Default.CB2 = false;
                    Properties.Settings.Default.CB3 = false;
                    Properties.Settings.Default.CB4 = false;
                    Properties.Settings.Default.CB5 = false;
                    Properties.Settings.Default.CB6 = false;
                    Properties.Settings.Default.CB7 = false;
                    Properties.Settings.Default.CB8 = false;
                    Properties.Settings.Default.CB9 = false;
                    Properties.Settings.Default.CB10 = false;
                    Properties.Settings.Default.CB11 = false;
                    Properties.Settings.Default.CB13 = false;
                    Properties.Settings.Default.CB14 = false;

                    Properties.Settings.Default.CBE1 = false;
                    Properties.Settings.Default.CBE2 = false;
                    Properties.Settings.Default.CBE3 = false;
                    Properties.Settings.Default.CBE4 = false;
                    Properties.Settings.Default.CBE5 = false;

                    Properties.Settings.Default.CBR1 = false;
                    Properties.Settings.Default.CBR2 = false;
                    Properties.Settings.Default.CBR3 = false;
                    Properties.Settings.Default.CBR4 = false;
                    Properties.Settings.Default.CBR5 = false;
                    Properties.Settings.Default.CBR6 = false;
                    Properties.Settings.Default.CBR7 = false;
                    Properties.Settings.Default.CBR8 = false;
                    Properties.Settings.Default.CBR9 = false;

                    Properties.Settings.Default.CBU1 = false;
                    Properties.Settings.Default.CBU2 = false;
                    Properties.Settings.Default.CBU3 = false;
                    Properties.Settings.Default.CBU4 = false;
                    Properties.Settings.Default.CBU5 = false;
                    Properties.Settings.Default.CBU6 = false;
                    Properties.Settings.Default.CBU7 = false;
                    Properties.Settings.Default.CBU8 = false;
                    Properties.Settings.Default.CBU9 = false;

                    Properties.Settings.Default.CBET1 = false;
                    Properties.Settings.Default.CBET2 = false;
                    Properties.Settings.Default.CBET3 = false;
                    Properties.Settings.Default.CBET4 = false;
                    Properties.Settings.Default.CBET5 = false;
                    Properties.Settings.Default.CBET6 = false;
                    Properties.Settings.Default.CBET7 = false;
                    Properties.Settings.Default.CBET8 = false;
                    Properties.Settings.Default.CBET9 = false;
                    Properties.Settings.Default.CBET10 = false;
                    Properties.Settings.Default.CBET11 = false;
                    Properties.Settings.Default.CBET12 = false;
                    Properties.Settings.Default.Save();

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{d3162b92-9365-467a-956b-92703aca08af}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{d3162b92-9365-467a-956b-92703aca08af}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{374DE290-123F-4565-9164-39C4925E467B}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{088e3905-0323-4b02-9826-5d99428e115f}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{374DE290-123F-4565-9164-39C4925E467B}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{088e3905-0323-4b02-9826-5d99428e115f}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("Start_Layout", 3);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU").SetValue("NoAutoUpdate", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate").SetValue("DoNotConnectToWindowsUpdateInternetLocations", 0);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System").SetValue("verbosestatus", 0);

                    Registry.ClassesRoot.CreateSubKey(@"SystemFileAssociations\image\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"batfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"cmdfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"docxfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"htmlfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"inffile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"inifile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"regfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"txtfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"VBSFile\shell\print").SetValue("ProgrammaticAccessOnly", '-');


                    Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\SendTo").SetValue("", "{7BA4C740-9E81-11CF-99D3-00AA004AE837}");

                    Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\ModernSharing").SetValue("", "{e2bf9676-5f8f-435c-97eb-11607a5bedf7}");

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("Hidden", 0);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\PushNotifications").SetValue("NoTileApplicationNotification", 0);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Explorer").SetValue("ClearTilesOnExit", 0);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate").SetValue("DisableOSUpgrade", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\WindowsStore").SetValue("DisableOSUpgrade", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\WindowsUpdate\OSUpgrade").SetValue("AllowOSUpgrade", 1);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\WindowsUpdate\OSUpgrade").SetValue("ReservationsAllowed", 1);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System").SetValue("DisableAcrylicBackgroundOnLogon", 0);

                    try
                    {
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked");
                    }
                    catch
                    {

                    }

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowSuperHidden", 0);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel").SetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}", 1);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate").SetValue("ExcludeWUDriversInQualityUpdate", 0);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer").SetValue("AltTabSettings", 0);

                    try
                    {
                        Registry.ClassesRoot.CreateSubKey(@"CLSID\{09A47860-11B0-4DA5-AFA5-26D86198A780}\InprocServer32").SetValue("", @"C:\Program Files\Windows Defender\shellext.dll");
                        Registry.ClassesRoot.CreateSubKey(@"CLSID\{09A47860-11B0-4DA5-AFA5-26D86198A780}\InprocServer32").SetValue("ThreadingModel", "Apartment");
                        Registry.ClassesRoot.CreateSubKey(@"CLSID\{09A47860-11B0-4DA5-AFA5-26D86198A780}\Version").SetValue("", "10.0.22621.1");
                    }
                    catch
                    {

                    }


                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("LaunchTo", 2);

                    try
                    {
                        Registry.CurrentUser.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\NamingTemplates");
                    }
                    catch
                    {

                    }


                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection").SetValue("AllowTelemetry ", 1);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Associations").SetValue("LowRiskFileTypes", "");

                    try
                    {
                        Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shell\pintohome").SetValue("CommandStateHandler", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shell\pintohome").SetValue("CommandStateSync", "");
                        Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shell\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
                        Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shell\pintohome\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome").SetValue("CommandStateHandler", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome").SetValue("CommandStateSync", "");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome").SetValue("NeverDefault", "");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Folder\shell\pintohome").SetValue("AppliesTo", "System.ParsingName:<>\"::{679f85cb-0220-4080-b29b-5540cc05aab6}\" AND System.ParsingName:<>\"::{645FF040-5081-101B-9F08-00AA002F954E}\" AND System.IsFolder:=System.StructuredQueryType.Boolean#True");
                        Registry.ClassesRoot.CreateSubKey(@"Folder\shell\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
                        Registry.ClassesRoot.CreateSubKey(@"Folder\shell\pintohome\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome").SetValue("CommandStateHandler", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome").SetValue("CommandStateSync", "");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome").SetValue("NeverDefault", "");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");

                    }
                    catch
                    {

                    }

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Clipboard").SetValue("EnableClipboardHistory", 0);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowSecondsInSystemClock", 0);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System").SetValue("EnableSmartScreen", 1);

                    Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control").SetValue("WaitToKillServiceTimeout", 0x7d0);
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop").SetValue("WaitToKillAppTimeout", 0x7d0);

                    try
                    {
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked");
                    }
                    catch
                    {

                    }

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowTaskViewButton", 1);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("TaskbarDa", 1);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("TaskbarMn", 1);


                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System").SetValue("EnableLUA", 1);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion").SetValue("NoLowDiskSpaceChecks", 0);


                    Registry.ClassesRoot.CreateSubKey(@"Folder\ShellEx\ContextMenuHandlers\Library Location").SetValue("", "{3dad6c5d-2167-4cae-9914-f99e41c12cfa}");

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Taskband").SetValue("MinThumbSizePX", 300);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender").SetValue("DisableAntiSpyware ", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableBehaviorMonitoring ", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableOnAccessProtection ", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableScanOnRealtimeEnable ", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableIOAVProtection ", 0);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("EnableSnapAssistFlyout", 1);
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop").SetValue("WindowArrangementActive", 1);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ExtendedUIHoverTime", 0x3e8);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\MRT").SetValue("DontReportInfectionInformation", 0);


                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Accessibility\StickyKeys").SetValue("Flags", "506");
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Accessibility\Keyboard Response").SetValue("Flags", "122");
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Accessibility\ToggleKeys").SetValue("Flags", "58");

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\Folder\shellex\ContextMenuHandlers\PintoStartScreen").SetValue("", "{470C0EBD-5D73-4d58-9CED-E91E22E23282}");
                    Registry.ClassesRoot.CreateSubKey(@"exefile\shellex\ContextMenuHandlers\PintoStartScreen").SetValue("", "{470C0EBD-5D73-4d58-9CED-E91E22E23282}");

                    Process.Start("cmd.exe", "/c \"reg delete \"HKCU\\Software\\Classes\\CLSID{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32\" /f\"");

                    Process.Start("cmd.exe", "/c \"netsh advfirewall set allprofiles state on\"");

                    Process.Start("cmd.exe", "/c \"bcdedit /set \"{current}\" bootmenupolicy standard\"");

                    Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\CopyAsPathMenu").SetValue("", "{f3d06e7c-1e45-4a26-847e-f9fcdee59be0}");

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MultitaskingView\AltTabViewHost").SetValue("BackgroundDimmingLayer_percent", 0);

                    Registry.ClassesRoot.CreateSubKey(@"*\shellex\ContextMenuHandlers\{90AA3A4E-1CBA-4233-B8BB-535773D48449}").SetValue("", "Taskband Pin");

                    Process.Start("powercfg.exe", "/setactive 381b4222-f694-41f0-9685-ff5bb260df2e");

                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("CommandStateHandler", "{11dbb47c-a525-400b-9e80-a54615a090c0}");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("CommandStateSync", "");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("LaunchExplorerFlags", (int)0x20);
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("MUIVerb", "@windows.storage.dll,-8519");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("MultiSelectModel", "Document");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("OnlyInBrowserWindow", "");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab\command").SetValue("DelegateExecute", "{11dbb47c-a525-400b-9e80-a54615a090c0}");

                    Process.Start("cmd.exe", "/c \"powercfg /SETACVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 600\"");

                    Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\ModernSharing").SetValue("", "{e2bf9676-5f8f-435c-97eb-11607a5bedf7}");

                    DialogResult rest = MessageBox.Show("Для применения изменений необходимо перезагрузить компьютер. Хотите перезагрузиться сейчас?", "AWC - Нужна перезагрузка!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rest == DialogResult.Yes)
                    {
                        Process.Start("cmd.exe", "/c shutdown /r /t 0");
                    }
                }
                restartReq.Show();
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                DialogResult eraseall = MessageBox.Show("Are you sure you want to reset all Awesome Windows Tweaker settings?\nSome settings will not be reset.", "AWC - Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (eraseall == DialogResult.Yes)
                {
                    Properties.Settings.Default.CB1 = false;
                    Properties.Settings.Default.CB2 = false;
                    Properties.Settings.Default.CB3 = false;
                    Properties.Settings.Default.CB4 = false;
                    Properties.Settings.Default.CB5 = false;
                    Properties.Settings.Default.CB6 = false;
                    Properties.Settings.Default.CB7 = false;
                    Properties.Settings.Default.CB8 = false;
                    Properties.Settings.Default.CB9 = false;
                    Properties.Settings.Default.CB10 = false;
                    Properties.Settings.Default.CB11 = false;
                    Properties.Settings.Default.CB13 = false;
                    Properties.Settings.Default.CB14 = false;

                    Properties.Settings.Default.CBE1 = false;
                    Properties.Settings.Default.CBE2 = false;
                    Properties.Settings.Default.CBE3 = false;
                    Properties.Settings.Default.CBE4 = false;
                    Properties.Settings.Default.CBE5 = false;

                    Properties.Settings.Default.CBR1 = false;
                    Properties.Settings.Default.CBR2 = false;
                    Properties.Settings.Default.CBR3 = false;
                    Properties.Settings.Default.CBR4 = false;
                    Properties.Settings.Default.CBR5 = false;
                    Properties.Settings.Default.CBR6 = false;
                    Properties.Settings.Default.CBR7 = false;
                    Properties.Settings.Default.CBR8 = false;
                    Properties.Settings.Default.CBR9 = false;

                    Properties.Settings.Default.CBU1 = false;
                    Properties.Settings.Default.CBU2 = false;
                    Properties.Settings.Default.CBU3 = false;
                    Properties.Settings.Default.CBU4 = false;
                    Properties.Settings.Default.CBU5 = false;
                    Properties.Settings.Default.CBU6 = false;
                    Properties.Settings.Default.CBU7 = false;
                    Properties.Settings.Default.CBU8 = false;
                    Properties.Settings.Default.CBU9 = false;

                    Properties.Settings.Default.CBET1 = false;
                    Properties.Settings.Default.CBET2 = false;
                    Properties.Settings.Default.CBET3 = false;
                    Properties.Settings.Default.CBET4 = false;
                    Properties.Settings.Default.CBET5 = false;
                    Properties.Settings.Default.CBET6 = false;
                    Properties.Settings.Default.CBET7 = false;
                    Properties.Settings.Default.CBET8 = false;
                    Properties.Settings.Default.CBET9 = false;
                    Properties.Settings.Default.CBET10 = false;
                    Properties.Settings.Default.CBET11 = false;
                    Properties.Settings.Default.CBET12 = false;
                    Properties.Settings.Default.Save();

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{d3162b92-9365-467a-956b-92703aca08af}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{d3162b92-9365-467a-956b-92703aca08af}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{374DE290-123F-4565-9164-39C4925E467B}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{088e3905-0323-4b02-9826-5d99428e115f}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{374DE290-123F-4565-9164-39C4925E467B}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{088e3905-0323-4b02-9826-5d99428e115f}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("Start_Layout", 3);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU").SetValue("NoAutoUpdate", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate").SetValue("DoNotConnectToWindowsUpdateInternetLocations", 0);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System").SetValue("verbosestatus", 0);

                    Registry.ClassesRoot.CreateSubKey(@"SystemFileAssociations\image\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"batfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"cmdfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"docxfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"htmlfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"inffile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"inifile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"regfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"txtfile\shell\print").SetValue("ProgrammaticAccessOnly", "");
                    Registry.ClassesRoot.CreateSubKey(@"VBSFile\shell\print").SetValue("ProgrammaticAccessOnly", '-');


                    Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\SendTo").SetValue("", "{7BA4C740-9E81-11CF-99D3-00AA004AE837}");

                    Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\ModernSharing").SetValue("", "{e2bf9676-5f8f-435c-97eb-11607a5bedf7}");

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("Hidden", 0);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\PushNotifications").SetValue("NoTileApplicationNotification", 0);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\Explorer").SetValue("ClearTilesOnExit", 0);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate").SetValue("DisableOSUpgrade", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\WindowsStore").SetValue("DisableOSUpgrade", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\WindowsUpdate\OSUpgrade").SetValue("AllowOSUpgrade", 1);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\CurrentVersion\WindowsUpdate\OSUpgrade").SetValue("ReservationsAllowed", 1);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\System").SetValue("DisableAcrylicBackgroundOnLogon", 0);

                    try
                    {
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked");
                    }
                    catch
                    {

                    }

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowSuperHidden", 0);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel").SetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}", 1);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate").SetValue("ExcludeWUDriversInQualityUpdate", 0);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer").SetValue("AltTabSettings", 0);

                    try
                    {
                        Registry.ClassesRoot.CreateSubKey(@"CLSID\{09A47860-11B0-4DA5-AFA5-26D86198A780}\InprocServer32").SetValue("", @"C:\Program Files\Windows Defender\shellext.dll");
                        Registry.ClassesRoot.CreateSubKey(@"CLSID\{09A47860-11B0-4DA5-AFA5-26D86198A780}\InprocServer32").SetValue("ThreadingModel", "Apartment");
                        Registry.ClassesRoot.CreateSubKey(@"CLSID\{09A47860-11B0-4DA5-AFA5-26D86198A780}\Version").SetValue("", "10.0.22621.1");
                    }
                    catch
                    {

                    }


                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("LaunchTo", 2);

                    try
                    {
                        Registry.CurrentUser.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\NamingTemplates");
                    }
                    catch
                    {

                    }


                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection").SetValue("AllowTelemetry ", 1);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Associations").SetValue("LowRiskFileTypes", "");

                    try
                    {
                        Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shell\pintohome").SetValue("CommandStateHandler", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shell\pintohome").SetValue("CommandStateSync", "");
                        Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shell\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
                        Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shell\pintohome\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome").SetValue("CommandStateHandler", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome").SetValue("CommandStateSync", "");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome").SetValue("NeverDefault", "");
                        Registry.ClassesRoot.CreateSubKey(@"Drive\shell\pintohome\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Folder\shell\pintohome").SetValue("AppliesTo", "System.ParsingName:<>\"::{679f85cb-0220-4080-b29b-5540cc05aab6}\" AND System.ParsingName:<>\"::{645FF040-5081-101B-9F08-00AA002F954E}\" AND System.IsFolder:=System.StructuredQueryType.Boolean#True");
                        Registry.ClassesRoot.CreateSubKey(@"Folder\shell\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
                        Registry.ClassesRoot.CreateSubKey(@"Folder\shell\pintohome\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome").SetValue("CommandStateHandler", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome").SetValue("CommandStateSync", "");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome").SetValue("NeverDefault", "");
                        Registry.ClassesRoot.CreateSubKey(@"Network\shell\pintohome\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");

                    }
                    catch
                    {

                    }

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Clipboard").SetValue("EnableClipboardHistory", 0);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowSecondsInSystemClock", 0);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System").SetValue("EnableSmartScreen", 1);

                    Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control").SetValue("WaitToKillServiceTimeout", 0x7d0);
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop").SetValue("WaitToKillAppTimeout", 0x7d0);

                    try
                    {
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Blocked");
                    }
                    catch
                    {

                    }

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ShowTaskViewButton", 1);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("TaskbarDa", 1);
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("TaskbarMn", 1);


                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System").SetValue("EnableLUA", 1);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion").SetValue("NoLowDiskSpaceChecks", 0);


                    Registry.ClassesRoot.CreateSubKey(@"Folder\ShellEx\ContextMenuHandlers\Library Location").SetValue("", "{3dad6c5d-2167-4cae-9914-f99e41c12cfa}");

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Taskband").SetValue("MinThumbSizePX", 300);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender").SetValue("DisableAntiSpyware ", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableBehaviorMonitoring ", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableOnAccessProtection ", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableScanOnRealtimeEnable ", 0);
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection").SetValue("DisableIOAVProtection ", 0);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("EnableSnapAssistFlyout", 1);
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Desktop").SetValue("WindowArrangementActive", 1);

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced").SetValue("ExtendedUIHoverTime", 0x3e8);

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\MRT").SetValue("DontReportInfectionInformation", 0);


                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Accessibility\StickyKeys").SetValue("Flags", "506");
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Accessibility\Keyboard Response").SetValue("Flags", "122");
                    Registry.CurrentUser.CreateSubKey(@"Control Panel\Accessibility\ToggleKeys").SetValue("Flags", "58");

                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\Folder\shellex\ContextMenuHandlers\PintoStartScreen").SetValue("", "{470C0EBD-5D73-4d58-9CED-E91E22E23282}");
                    Registry.ClassesRoot.CreateSubKey(@"exefile\shellex\ContextMenuHandlers\PintoStartScreen").SetValue("", "{470C0EBD-5D73-4d58-9CED-E91E22E23282}");

                    Process.Start("cmd.exe", "/c \"reg delete \"HKCU\\Software\\Classes\\CLSID{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32\" /f\"");

                    Process.Start("cmd.exe", "/c \"netsh advfirewall set allprofiles state on\"");

                    Process.Start("cmd.exe", "/c \"bcdedit /set \"{current}\" bootmenupolicy standard\"");

                    Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\CopyAsPathMenu").SetValue("", "{f3d06e7c-1e45-4a26-847e-f9fcdee59be0}");

                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MultitaskingView\AltTabViewHost").SetValue("BackgroundDimmingLayer_percent", 0);

                    Registry.ClassesRoot.CreateSubKey(@"*\shellex\ContextMenuHandlers\{90AA3A4E-1CBA-4233-B8BB-535773D48449}").SetValue("", "Taskband Pin");

                    Process.Start("powercfg.exe", "/setactive 381b4222-f694-41f0-9685-ff5bb260df2e");

                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("CommandStateHandler", "{11dbb47c-a525-400b-9e80-a54615a090c0}");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("CommandStateSync", "");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("LaunchExplorerFlags", (int)0x20);
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("MUIVerb", "@windows.storage.dll,-8519");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("MultiSelectModel", "Document");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab").SetValue("OnlyInBrowserWindow", "");
                    Registry.ClassesRoot.CreateSubKey(@"Folder\shell\opennewtab\command").SetValue("DelegateExecute", "{11dbb47c-a525-400b-9e80-a54615a090c0}");

                    Process.Start("cmd.exe", "/c \"powercfg /SETACVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 600\"");

                    Registry.ClassesRoot.CreateSubKey(@"AllFilesystemObjects\shellex\ContextMenuHandlers\ModernSharing").SetValue("", "{e2bf9676-5f8f-435c-97eb-11607a5bedf7}");


                    if (Properties.Settings.Default.Lang == 1)
                    {
                        DialogResult rest = MessageBox.Show("Для применения изменений необходимо перезагрузить компьютер. Хотите перезагрузиться сейчас?", "AWC - Нужна перезагрузка!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (rest == DialogResult.Yes)
                        {
                            Process.Start("cmd.exe", "/c shutdown /r /t 0");
                        }
                    }
                    if (Properties.Settings.Default.Lang == 2)
                    {
                        DialogResult rest = MessageBox.Show("To apply the changes, you must restart your computer. Do you want to restart now?", "AWC - Reboot required!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (rest == DialogResult.Yes)
                        {
                            Process.Start("cmd.exe", "/c shutdown /r /t 0");
                        }
                    }

                }
                restartReq.Show();
            }


        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    MessageBox.Show("Интересный факт: изначально название программы звучало как 'Yet another Windows tweaker'. Об этом свидетельствуют название проекта в коде.\n\n :)", "YAWT - Интересный факт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    MessageBox.Show("Interesting fact: initially the name of the program sounded like 'Yet another Windows tweaker'. This is evidenced by the name of the project in the code.\n\n :)", "YAWT - Interesting fact", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            else if (e.Button == MouseButtons.Right)
            {
                sp.Stream = Properties.Resources.CoolSound;
                sp.Play();
                Sound.Start();
                new Form2().ShowDialog();
            }

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://github.com/AwesomeLime/AwesomeWindowsCustomizer/");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Sound_Tick(object sender, EventArgs e)
        {
            sp.Stop();
            Sound.Stop();
        }

        private void label13_Click(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.Lang == 1)
            {
                Point buildLoc = new Point(241, 365);
                label13.Location = buildLoc;
                label13.Text = "Номер сборки: 775.awcrelease\nAwesomeLime // 2024";
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                Point buildLoc = new Point(255, 365);
                label13.Location = buildLoc;
                label13.Text = "Build number: 775.awcrelease\nAwesomeLime // 2024";
            }

        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.CatExp == true)
                {
                    MessageBox.Show("", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void checkBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    if (Properties.Settings.Default.CatExp == true)
                    {
                        MessageBox.Show("В Windows 10 в Этом компьютере появилась секция ‘Папки’, в которой отображались пользовательские папки: Документы, Загрузки, Видео и другие. Эта функция позволяет их скрыть. \nВ Windows 11 22H2 и выше этой секции нет", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("Только для Windows 11. Уменьшает размер вкладки “Рекомендации” в Пуске до минимума.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("После включения этой настройки, вместо текста ‘Завершение работы’ или ‘Перезагрузка’ будет писаться, что конкретно происходит, например ‘Остановка служб’\r\n", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    if (Properties.Settings.Default.CatExp == true)
                    {
                        MessageBox.Show("In Windows 10, This PC now has a 'Folders' section, which displays user folders: Documents, Downloads, Videos and others. This function allows you to hide them.\nIn Windows 11 22H2 and later, this section is not present", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("Only for Windows 11. Reduces the size of the Recommendations tab in Start to a minimum.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("After enabling this setting, instead of the text 'Shutdown' or 'Reboot', it will be written what exactly is happening, for example 'Stopping services'\r\n", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }

            }
        }

        private void checkBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    if (Properties.Settings.Default.CatExp == true)
                    {
                        MessageBox.Show("Отображает скрытые несистемные папки и файлы, например папку AppData", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("Только для Windows 10.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("Данная функция отключает возможность до обновления до новой версии Windows (например, обновление с Windows 10 1809 до Windows 10 1903, или обновление с Windows 11 21H2 до Windows 11 22H2) через Центр обновления Windows.\r\n", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("Начиная с Windows 10 1903, обои экрана блокировки размываются при вводе пароля. Эта функция позволяет отключить это размытие.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    if (Properties.Settings.Default.CatExp == true)
                    {
                        MessageBox.Show("Displays hidden non-system folders and files, such as the AppData folder", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("Only for Windows 10.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("This feature disables the ability to upgrade to a new version of Windows (for example, upgrading from Windows 10 1809 to Windows 10 1903, or upgrading from Windows 11 21H2 to Windows 11 22H2) via Windows Update.\r\n", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("Starting with Windows 10 1903, the lock screen wallpaper blurs when you enter a password. This feature allows you to disable this blur.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }

            }
        }

        private void checkBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    if (Properties.Settings.Default.CatExp == true)
                    {
                        MessageBox.Show("Отображает скрытые системные папки, например папку с загрузчиком.\nВключайте этот параметр на свой страх и риск!", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatWork == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    if (Properties.Settings.Default.CatExp == true)
                    {
                        MessageBox.Show("Displays hidden system folders, such as the boot manager folder.\nEnable this option at your own risk!", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatWork == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }

            }
        }

        private void checkBox4_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    if (Properties.Settings.Default.CatExp == true)
                    {
                        MessageBox.Show("Когда вы открываете проводник, например через Win + E, по умолчанию отображается вкладка “Главная” или “Быстрый доступ”. Эта функция позволяет сменить вкладку по умолчанию на Этот компьютер", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("При создании ярлыка, по умолчанию всегда появляется ненужное окончание ‘- Ярлык’. Эта функция убирает данное окончание у всех новых ярлыков", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("Данная функция отключает сбор данных и слежку за пользователем", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("При запуске некоторых EXE файлов, может появится окно ‘Не удалось проверить издателя’. Эта функция отключает данное предупреждение.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    if (Properties.Settings.Default.CatExp == true)
                    {
                        MessageBox.Show("When you open File Explorer, for example via Win + E, the Home or Quick Access tab is displayed by default. This function allows you to change the default tab to This PC", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("When creating a shortcut, by default the unnecessary ending '- Shortcut' always appears. This function removes this ending from all new shortcuts", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("This function disables data collection and user tracking", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("When running some EXE files, the 'Failed to verify publisher' window may appear. This function disables this warning.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }

            }
        }

        private void checkBox5_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    if (Properties.Settings.Default.CatExp == true)
                    {
                        MessageBox.Show("В расширенном буфере обмена можно просматривать последние несколько скопированных элементов.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("После включения этой настройки, в часах на панели задач будут отображаться не только часы и минуты, а ещё и секунды.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("Видели когда-либо окно ‘Система Windows защитила ваш компьютер’? Так вот, эта функция отключает это окно.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("Данная галочка уменьшает параметр WaitToKill, за счёт чего ускоряется процесс завершения работы. Эта функция отключает данное предупреждение.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    if (Properties.Settings.Default.CatExp == true)
                    {
                        MessageBox.Show("You can view the last few copied items in the extended clipboard.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("After enabling this setting, the clock on the taskbar will display not only hours and minutes, but also seconds.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("Ever seen the 'Windows has protected your computer' window? Well, this function disables that window.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("This checkbox reduces the WaitToKill parameter, which speeds up the shutdown process. This function disables this warning.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }

            }
        }

        private void checkBox6_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    if (Properties.Settings.Default.CatWork == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("Данная функция отключает окно, которое появляется при запросе прав администратора пользователем (например, когда вы нажимаете кнопку “Запустить от имени администратора”", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    if (Properties.Settings.Default.CatWork == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("This function disables the window that appears when a user requests administrator rights (for example, when you click the “Run as administrator” button", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }

            }
        }

        private void checkBox7_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("При наведении на программу на панели задач, появляется миниатюра программы. Эта функция делает эти миниатюры больше.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("Данная функция отключает часто бесячий встроенный антивирус в Windows, который часто удаляет то, что не надо под предлогом ‘наличия вирусов’", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("В Windows 11, при наведении на кнопку ‘Развернуть’ появляется окошко с макетами для разворачивания. Данная функция скрывает это окошко.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatSet == true)
                    {
                        MessageBox.Show("Данная функция скрывает символ <!> под кнопками Перезагрузки и Перезагрузки проводника, который появляется при необходимости перезагрузки для применения определённого параметра.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("When you hover over a program in the taskbar, a thumbnail of the program appears. This function makes these thumbnails larger.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("This function disables the often annoying built-in antivirus in Windows, which often removes what is not needed under the pretext of 'the presence of viruses'", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("In Windows 11, when you hover over the 'Expand' button, a window with expand layouts appears. This function hides this window.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatSet == true)
                    {
                        MessageBox.Show("This function hides the <!> symbol under the Reboot and Reboot Explorer buttons, which appears when a reboot is required to apply a certain parameter.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }

            }
        }

        private void checkBox8_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("При наведении на программу на панели задач, через некоторое время появляется миниатюра программы. Эта функция убирает задержку между наведением на программу и появлением миниатюры.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("Эта галочка отключает окно ‘Включить залипание клавиш’ при нажатии Shift 5 раз подряд.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("When you hover over a program on the taskbar, after a while a thumbnail of the program appears. This function removes the delay between pointing at the program and the appearance of the thumbnail.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("This checkbox disables the 'Enable Sticky Keys' window when you press Shift 5 times in a row.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }

            }
        }

        private void checkBox9_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("Данная настройка отключает новое контекстное меню из Windows 11, и возвращает классическое контекстное меню из Windows 10.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("Данная функция отключает Брандмауэр Защитника Windows, который ограничивает доступ в интернет неизвестным приложениям.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("В Windows 8 был презентован новый загрузчик, который хоть и был красивый, но при этом был неудобным. Например, в нём нельзя нажать F8 для вызова ‘меню загрузки’, из которого быстро можно попасть в Безопасный режим.\nВсё это можно исправить включением старого загрузчика.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    if (Properties.Settings.Default.CatWork == true)
                    {
                        MessageBox.Show("This setting disables the new context menu from Windows 11, and returns the classic context menu from Windows 10.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("This function disables Windows Defender Firewall, which restricts Internet access to unknown applications.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("In Windows 8, a new bootloader was presented, which, although beautiful, was also inconvenient. For example, you can’t press F8 to bring up the 'boot menu', from which you can quickly get to Safe Mode.\nThat's it this can be fixed by enabling the old bootloader.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }

            }
        }

        private void checkBox10_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("Данная функция отключает автоматическую установку рекламных UWP-приложений, например Яндекс Музыка или Spotify.\nПосле включения, данную функцию нельзя будет отключить!", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("Только для Windows 10. Делает фон меню Alt+Tab на 70% непрозрачным.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    if (Properties.Settings.Default.CatSec == true)
                    {
                        MessageBox.Show("This function disables the automatic installation of advertising UWP applications, such as Yandex Music or Spotify.\nOnce enabled, this function cannot be disabled!", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("Only for Windows 10. Makes the background of the Alt+Tab menu 70% opaque.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }

            }
        }

        private void checkBox11_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("Данная функция включает режим ‘Максимальной производительности’ в настройках электропитания. Может быть полезно только на ноутбуках, на которых по умолчанию ограничивается мощность без подключения зарядки для энергосбережения.", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    if (Properties.Settings.Default.CatEtc == true)
                    {
                        MessageBox.Show("This feature enables the 'Maximum Performance' mode in the power settings. May only be useful on laptops that by default limit power without connecting a charger to save power.", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                }

            }
        }

        private void checkBox12_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.Lang == 1)
                {
                    if (Properties.Settings.Default.CatEtc == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        MessageBox.Show("После отключения, данный пункт нельзя будет включить обратно!", "AWC - Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else if (Properties.Settings.Default.Lang == 2)
                {
                    if (Properties.Settings.Default.CatEtc == true)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    else if (Properties.Settings.Default.CatContext == true)
                    {
                        MessageBox.Show("Once disabled, this item cannot be turned back on!", "AWC - Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }

            }
        }

        private void checkBox13_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.CatContext == true)
                {
                    SystemSounds.Asterisk.Play();
                }
            }
        }

        private void checkBox14_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Properties.Settings.Default.CatContext == true)
                {
                    SystemSounds.Asterisk.Play();
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                label1.Text = "Очистка и восстановление";
                button21.Text = "Начать";
                button22.Text = "Начать";
                button23.Text = "Начать";
                label3.Text = "Восстановление с помощью SFC";
                label4.Text = "Восстановление с помощью DISM";
                label5.Text = "Очистить временные файлы";
                button21.Location = new Point(339, 95);
                button22.Location = new Point(339, 64);
                button23.Location = new Point(339, 126);
            }
            else if (Properties.Settings.Default.Lang == 2)
            {
                label1.Text = "System refresh";
                button21.Text = "Begin  ";
                button22.Text = "Begin  ";
                button23.Text = "Begin  ";
                label3.Text = "Refresh via SFC";
                label4.Text = "Refresh via DISM";
                label5.Text = "Clean temporary files";
                button21.Location = new Point(263, 95);
                button22.Location = new Point(263, 64);
                button23.Location = new Point(263, 126);
            }
            Properties.Settings.Default.CatAboutPC = false;
            Properties.Settings.Default.CatExp = false;
            Properties.Settings.Default.CatWork = false;
            Properties.Settings.Default.CatSec = false;
            Properties.Settings.Default.CatEtc = false;
            Properties.Settings.Default.CatAct = false;
            Properties.Settings.Default.CatContext = false;
            Properties.Settings.Default.CatSet = false;
            Properties.Settings.Default.CatAbout = false;
            Properties.Settings.Default.CatRec = true;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            button19.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button20.Enabled = false;
            label2.Visible = false;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button21.Visible = true;
            button22.Visible = true;
            button23.Visible = true;
            comboBox1.Visible = false;
            label9.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            button12.Visible = true;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                string temp = Environment.GetEnvironmentVariable("temp");
                DialogResult restoreD = MessageBox.Show($"Данная кнопка удалит все временные файлы, находящиеся по пути '{temp}'. Вы хотите продолжить?", "AWC - Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (restoreD == DialogResult.Yes)
                {
                    Process.Start("cmd.exe", $"/c rd {temp} /s /q");
                }
            }
            if (Properties.Settings.Default.Lang == 2)
            {
                string temp = Environment.GetEnvironmentVariable("temp");
                DialogResult restoreD = MessageBox.Show($"This button will delete all temporary files located on the path '{temp}'. Do you want to continue?", "AWC - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (restoreD == DialogResult.Yes)
                {
                    Process.Start("cmd.exe", $"/c rd {temp} /s /q");
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                DialogResult restoreD = MessageBox.Show("Данная кнопка запустит восстановление системы с помощью SFC. Это может занять 5-10 минут. Вы хотите продолжить?\n\nДополнительная информация: https://bit.ly/AWCRefresh", "AWC - Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (restoreD == DialogResult.Yes)
                {
                    Process.Start("cmd.exe", "/c sfc /scannow");
                    Properties.Settings.Default.NeedReboot = true;
                }
            }
            if (Properties.Settings.Default.Lang == 2)
            {
                DialogResult restoreD = MessageBox.Show("This button will launch a system restore using SFC. This may take 5-10 minutes. Do you want to continue?\n\nAdditional information: https://bit.ly/AWCRefresh", "AWC - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (restoreD == DialogResult.Yes)
                {
                    Process.Start("cmd.exe", "/c sfc /scannow");
                    Properties.Settings.Default.NeedReboot = true;
                }

            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Lang == 1)
            {
                DialogResult restoreD = MessageBox.Show("Данная кнопка запустит восстановление системы с помощью DISM. Это может занять 10-20 минут. Вы хотите продолжить?\n\nДополнительная информация: https://bit.ly/AWCRefresh", "AWC - Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (restoreD == DialogResult.Yes)
                {
                    Process.Start("cmd.exe", "/c dism /Online /Cleanup-Image /RestoreHealth");
                    Properties.Settings.Default.NeedReboot = true;
                }
            }
            if (Properties.Settings.Default.Lang == 2)
            {
                DialogResult restoreD = MessageBox.Show("This button will launch a system restore using DISM. This may take 10-20 minutes. Do you want to continue?\n\nAdditional information: https://bit.ly/AWCRefresh", "AWC - Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (restoreD == DialogResult.Yes)
                {
                    Process.Start("cmd.exe", "/c dism /Online /Cleanup-Image /RestoreHealth");
                    Properties.Settings.Default.NeedReboot = true;
                }

            }
        }

        private void Reboot_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.NeedReboot == true)
            {
                restartReq.Visible = true;
            }
            if (Properties.Settings.Default.NeedExpReboot == true)
            {
                explorerReq.Visible = true;
            }
            if (Properties.Settings.Default.NeedExpReboot == false)
            {
                explorerReq.Visible = false;
            }
            if (Properties.Settings.Default.NeedReboot == false)
            {
                restartReq.Visible = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/awesome_lime");
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
