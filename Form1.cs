using ADZFlash.ADB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADZFlash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Logger.print = new Logger.PrintLog(writeLog);
                ckbFlashROM.Checked = Properties.Settings.Default.FLASH_ROM;
                ckbFlashMagisk.Checked = Properties.Settings.Default.FLASH_MAGISK;
                ckbFlashGApps.Checked = Properties.Settings.Default.FLASH_GAPPS;
                ckbRestoreData.Checked = Properties.Settings.Default.RESTORE_DATA;
            }
            catch
            {

            }
        }

        void writeLog(string log)
        {
            Invoke((MethodInvoker)delegate
            {
                txbLog.AppendText($"[{DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")}] {log}{Environment.NewLine}");
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cbbDevices.Items.Clear();
            var devices = ADBManager.GetListDevices();
            if (devices != null && devices.Count > 0)
            {
                cbbDevices.Items.AddRange(devices.ToArray());
            }

        }

        private void ckbFlashROM_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FLASH_ROM = ckbFlashROM.Checked;
            Properties.Settings.Default.Save();
        }

        private void ckbFlashMagisk_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FLASH_MAGISK = ckbFlashMagisk.Checked;
            Properties.Settings.Default.Save();

        }

        private void ckbFlashGApps_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FLASH_GAPPS = ckbFlashGApps.Checked;
            Properties.Settings.Default.Save();

        }
        private void txbLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                this.Text = cbbDevices.SelectedItem.ToString();
            });
        }

        private void btnFlash_Click(object sender, EventArgs e)
        {
            if (cbbDevices.SelectedItem == null)
                return;

            Task.Factory.StartNew(() =>
            {
                string devices = "";
                Invoke((MethodInvoker)delegate
                {
                    devices = cbbDevices.SelectedItem.ToString();
                    btnFlash.Enabled = cbbDevices.Enabled = btnGetDevices.Enabled = ckbFlashROM.Enabled = ckbFlashGApps.Enabled = ckbFlashMagisk.Enabled = ckbRestoreData.Enabled = false;
                });

                ExcuteCommand(devices);

                Invoke((MethodInvoker)delegate
                {
                    btnFlash.Enabled = cbbDevices.Enabled = btnGetDevices.Enabled = ckbFlashROM.Enabled = ckbFlashGApps.Enabled = ckbFlashMagisk.Enabled = ckbRestoreData.Enabled = true;
                });
            });
        }

        void ExcuteCommand(string devices)
        {
            Logger.print("[Fastboot] Go to TWRP...");
            //ADBManager.ExcuteCommand($"fastboot -s {devices} -w");
            ADBManager.ExcuteCommand($"fastboot -s {devices} set_active b");
            ADBManager.ExcuteCommand($"fastboot -s {devices} boot {AppDomain.CurrentDomain.BaseDirectory + @"tools\recovery.img"}");
            ADBManager.ExcuteCommand($"adb -s {devices} wait-for-recovery");

            Logger.print("[TWRP] Wiping data...");
            ADBManager.ExcuteCommand($"adb -s {devices} shell twrp wipe cache");
            ADBManager.ExcuteCommand($"adb -s {devices} shell twrp wipe system");
            ADBManager.ExcuteCommand($"adb -s {devices} shell twrp wipe dalvik");
            ADBManager.ExcuteCommand($"adb -s {devices} shell twrp wipe data");
            ADBManager.ExcuteCommand($"ping -n 6 127.0.0.1 > nul");

            Logger.print("[TWRP] Pushing data...");
            ADBManager.ExcuteCommand($"adb -s {devices} push {AppDomain.CurrentDomain.BaseDirectory + @"tools\TWRP.zip"} /sdcard/TWRP.zip");
            if (ckbFlashROM.Checked)
            {
                ADBManager.ExcuteCommand($"adb -s {devices} push {AppDomain.CurrentDomain.BaseDirectory + @"tools\flash"} /sdcard/");
                Logger.print("[TWRP] Flashing ROM...");
                ADBManager.ExcuteCommand($"adb -s {devices} shell twrp install /sdcard/flash/ROM.zip");
                ADBManager.ExcuteCommand($"ping -n 6 127.0.0.1 > nul");
                ADBManager.ExcuteCommand($"ping -n 6 127.0.0.1 > nul");
                ADBManager.ExcuteCommand($"adb -s {devices} shell twrp install /sdcard/flash/V10.0.9.0.PDHMIXM.zip");
                ADBManager.ExcuteCommand($"ping -n 6 127.0.0.1 > nul");
            }

            if (ckbRestoreData.Checked)
            {
                Logger.print("[TWRP] Rebooting...");
                ADBManager.ExcuteCommand($"adb -s {devices} reboot");
                ADBManager.ExcuteCommand($"adb -s {devices} wait-for-device");

                ADBManager.ExcuteCommand($"adb -s {devices} reboot bootloader");
                while (true)
                {
                    try
                    {
                        var listDevice = ADBManager.GetListDevices();
                        if(listDevice != null && listDevice.Count > 0)
                        {
                            if (listDevice.Find(x => x == devices) != null)
                            {
                                ADBManager.ExcuteCommand($"fastboot -s {devices} set_active b");
                                break;
                            }
                        }

                        Thread.Sleep(3000);
                    }
                    catch
                    {

                    }
                }

                ADBManager.ExcuteCommand($"fastboot -s {devices} boot {AppDomain.CurrentDomain.BaseDirectory + @"tools\recovery.img"}");
                ADBManager.ExcuteCommand($"adb -s {devices} wait-for-recovery");
                ADBManager.ExcuteCommand($"ping -n 6 127.0.0.1 > nul");

                Logger.print("[TWRP] Pushing ADZROM...");
                ADBManager.ExcuteCommand($"adb -s {devices} push {AppDomain.CurrentDomain.BaseDirectory + @"tools\restore"} /sdcard/");
                ADBManager.ExcuteCommand($"ping -n 6 127.0.0.1 > nul");

                Logger.print("[TWRP] Restoring ADZROM...");
                ADBManager.ExcuteCommand($"adb -s {devices} shell twrp restore /sdcard/restore");
                Logger.print("[TWRP] Rebooting...");
                ADBManager.ExcuteCommand($"adb -s {devices} reboot");
                Logger.print("[Flash] Done!");
                return;
            }

            if (ckbFlashGApps.Checked)
            {
                Logger.print("[TWRP] Flashing GApps...");
                ADBManager.ExcuteCommand($"adb -s {devices} push {AppDomain.CurrentDomain.BaseDirectory + @"tools\gapps"} /sdcard/");
                ADBManager.ExcuteCommand($"adb -s {devices} shell twrp install /sdcard/gapps/GAPPS.zip");
                if (!ckbFlashMagisk.Checked)
                {
                    Logger.print("[TWRP] Rebooting...");
                    ADBManager.ExcuteCommand($"adb -s {devices} reboot");
                    Logger.print("[Flash] Done!");
                    return;
                }

                ADBManager.ExcuteCommand($"adb -s {devices} reboot recovery");
                ADBManager.ExcuteCommand($"adb -s {devices} wait-for-recovery");
                ADBManager.ExcuteCommand($"ping -n 6 127.0.0.1 > nul");
            }

            if (ckbFlashMagisk.Checked)
            {
                Logger.print("[TWRP] Flashing Magisk...");
                ADBManager.ExcuteCommand($"adb -s {devices} push {AppDomain.CurrentDomain.BaseDirectory + @"tools\root"} /sdcard/");
                ADBManager.ExcuteCommand($"adb -s {devices} shell twrp install /sdcard/root/Magisk-v21.2.zip");
                ADBManager.ExcuteCommand($"ping -n 6 127.0.0.1 > nul");
                ADBManager.ExcuteCommand($"adb -s {devices} shell twrp install /sdcard/root/riru-v23.1.zip");
            }

            Logger.print("[Flash] Rebooting...");
            ADBManager.ExcuteCommand($"adb -s {devices} reboot");

            Logger.print("[Flash] Done!...");
            //Environment.Exit(0);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch
            {

            }
        }

        private void ckbRestoreData_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RESTORE_DATA = ckbRestoreData.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
