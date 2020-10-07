using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Black_Ops___Zombies
{
    public partial class BlackOpsZombies : DevExpress.XtraEditors.XtraForm
    {
        public static Memory Mem = new Memory();
        public BlackOpsZombies()
        {
            InitializeComponent();
        }

        public class Structs
        {
            public static void CBuf_AddText(string str)
            {
                Mem.WriteBytes(0x98000, new byte[] {
                    0xb8, 0x30, 0xb9, 0x49, 0, 0x68, 0x98, 0x80, 9, 0, 0x6a, 0, 0xff, 0xd0, 0x83, 0xc4,
                    8, 0xc3
                }, false);
                Mem.WriteString(0x98098, str + "\0", false);
                Mem.ExecThread((IntPtr)0x98000);
            }
        }

        public class Functions
        {
            
            public static void God()
            {
                Structs.CBuf_AddText("god");
            }

            public static void Noclip()
            {
                Structs.CBuf_AddText("noclip");
            }

            public static void NoTarget()
            {
                Structs.CBuf_AddText("notarget");
            }

            public static void GiveWeapon(string str)
            {
                Structs.CBuf_AddText("give " + str);
            }

            public static void DropWeapon()
            {
                Structs.CBuf_AddText("dropweapon");
            }
        }

        public class Weapons
        {
            public static string AK7u = "ak74u_zm";
            public static string AUG = "aug_acog_zm";
            public static string China_Lake = "china_lake_zm";
            public static string Claymore = "claymore_zm";
            public static string Commando = "commando_zm";
            public static string Crossbow = "crossbow_explosive_zm";
            public static string Cz75 = "cz75_zm";
            public static string cz75dw = "cz75dw_zm";
            public static string Dragonov = "dragunov_zm";
            public static string Famas = "famas_zm";
            public static string FnFal = "fnfal_zm";
            public static string Frag = "frag_grenade_zm";
            public static string FreezeGun = "freezegun_zm";
            public static string G11 = "g11_lps_zm";
            public static string Galil = "galil_zm";
            public static string Hk21 = "hk21_zm";
            public static string Hs10 = "hs10_zm";
            public static string Ithica = "ithaca_zm";
            public static string BallisticKnife = "knife_ballistic_zm";
            public static string A1 = "l96a1_zm";
            public static string m14 = "m14_zm";
            public static string m16 = "m16_zm";
            public static string m1911 = "m1911_zm";
            public static string m72 = "m72_law_zm";
            public static string Mp5k = "mp5k_zm";
            public static string Vmpl = "vmpl_zm";
            public static string Pm63 = "pm63_zm";
            public static string Python = "python_zm";
            public static string Raygun = "ray_gun_zm";
            public static string Rotweil72 = "rottweil72_zm";
            public static string RPK = "rpk_zm";
            public static string SPAS = "spas_zm";
            public static string Spectre = "spectre_zm";
        }
        private void BlackOpsZombies_Load(object sender, EventArgs e)
        {
            if(Mem.Open_pHandel("BlackOps"))
            {
                GameStatusLabel.Text = "Game Status - Hooked!";
            }
            else
            {
                GameStatusLabel.Text = "Game Status - Failed to hook!";
            }
        }

        public class Memory
        {
            private Process attachedProcess;
            private byte[] buffer;
            private IntPtr pHandel = IntPtr.Zero;

            public void ExecThread(IntPtr offset)
            {
                Win32.x86.CreateRemoteThread(this.pHandel, IntPtr.Zero, 0, offset, IntPtr.Zero, 0, IntPtr.Zero);
            }

            public bool Open_pHandel(string processName)
            {
                Process[] processesByName = Process.GetProcessesByName(processName);
                if (processesByName.Length == 0)
                {
                    return false;
                }
                if (processesByName.Length > 1)
                {
                    throw new Exception("More then one process found.");
                }
                this.attachedProcess = processesByName[0];
                this.pHandel = processesByName[0].Handle;
                return true;
            }

            public int PatternScan(string pattern)
            {
                char[] separator = new char[] { ' ' };
                string[] strArray = pattern.Split(separator);
                bool[] flagArray = new bool[strArray.Length];
                byte[] buffer = new byte[strArray.Length];
                byte result = 0;
                for (int i = 0; i < strArray.Length; i++)
                {
                    flagArray[i] = (strArray[i] != "??") && (strArray[i] != "?");
                    if (byte.TryParse(strArray[i], out result))
                    {
                        buffer[i] = result;
                    }
                    else
                    {
                        flagArray[i] = false;
                    }
                }
                int moduleMemorySize = this.attachedProcess.MainModule.ModuleMemorySize;
                for (int j = this.attachedProcess.MainModule.BaseAddress.ToInt32(); j < moduleMemorySize; j++)
                {
                    bool flag = false;
                    for (int k = 0; k < strArray.Length; k++)
                    {
                        if (flagArray[k])
                        {
                            if (this.ReadByte(j + k) != buffer[k])
                            {
                                break;
                            }
                            if (k == (strArray.Length - 1))
                            {
                                flag = true;
                            }
                            if (flag)
                            {
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        return j;
                    }
                }
                throw new Exception("Pattern not found!");
            }

            public byte ReadByte(int address) =>
                this.ReadBytes(address, 1)[0];

            public byte[] ReadBytes(int address, int length)
            {
                byte[] buffer = new byte[length];
                int lpNumberOfBytesWritten = 0;
                Win32.x86.ReadProcessMemory(this.pHandel, address, buffer, (uint)length, out lpNumberOfBytesWritten);
                return buffer;
            }

            public float ReadFloat(int address) =>
                BitConverter.ToSingle(this.ReadBytes(address, 4), 0);

            public int ReadInt(int address) =>
                BitConverter.ToInt32(this.ReadBytes(address, 4), 0);

            public string ReadString(int offset)
            {
                int length = 40;
                int num2 = 0;
                string source = string.Empty;
                while (!source.Contains<char>('\0'))
                {
                    byte[] bytes = this.ReadBytes(offset + num2, length);
                    source = source + Encoding.UTF8.GetString(bytes);
                    num2 += length;
                }
                return source.Substring(0, source.IndexOf('\0'));
            }

            public string ReadString(int address, int length) =>
                Encoding.ASCII.GetString(this.ReadBytes(address, length));

            public string ReadStringAdvanced(int address, int maxStringLength = 0x3e8)
            {
                string str = null;
                byte num = 0;
                for (int i = 0; i < maxStringLength; i++)
                {
                    num = this.ReadByte(address + i);
                    if (num == 0)
                    {
                        return str;
                    }
                    str = str + ((char)num).ToString();
                }
                return str;
            }

            public bool WriteByte(int address, byte value, bool virtualProtect = false)
            {
                this.buffer = new byte[] { value };
                return this.WriteBytes(address, this.buffer, virtualProtect);
            }

            public bool WriteBytes(int address, byte[] value, bool virtualProtect = false)
            {
                int lpNumberOfBytesWritten = 0;
                uint lpflOldProtect = 0;
                if (virtualProtect)
                {
                    Win32.x86.VirtualProtectEx(this.pHandel, address, (uint)value.Length, 0x40, out lpflOldProtect);
                }
                if (virtualProtect)
                {
                    Win32.x86.VirtualProtectEx(this.pHandel, address, (uint)value.Length, lpflOldProtect, out lpflOldProtect);
                }
                return Win32.x86.WriteProcessMemory(this.pHandel, address, value, (uint)value.Length, out lpNumberOfBytesWritten);
            }

            public bool WriteFloat(int address, float value, bool virtualProtect = false)
            {
                this.buffer = BitConverter.GetBytes(value);
                return this.WriteBytes(address, this.buffer, virtualProtect);
            }

            public void WriteFloatArray(int address, float[] value)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    this.WriteFloat(address + (i * 4), value[i], true);
                }
            }

            public bool WriteInt(int address, int value, bool virtualProtect = false)
            {
                this.buffer = BitConverter.GetBytes(value);
                return this.WriteBytes(address, this.buffer, virtualProtect);
            }

            public bool WriteString(int address, string value, bool virtualProtect = false)
            {
                this.buffer = Encoding.ASCII.GetBytes(value + "\0");
                return this.WriteBytes(address, this.buffer, virtualProtect);
            }

            private static class Win32
            {
                public static class NativeMethods
                {
                    public static bool IsWow64Process(IntPtr handel)
                    {
                        bool flag = false;
                        IsWow64Process(handel, out flag);
                        return flag;
                    }

                    [return: MarshalAs(UnmanagedType.Bool)]
                    [DllImport("kernel32.dll", SetLastError = true)]
                    private static extern bool IsWow64Process([In] IntPtr process, out bool wow64Process);
                }

                public static class x64
                {
                    [DllImport("kernel32.dll")]
                    public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
                    [DllImport("kernel32.dll")]
                    public static extern bool ReadProcessMemory(IntPtr hProcess, long lpBaseAddress, [In, Out] byte[] buffer, uint size, out int lpNumberOfBytesWritten);
                    [DllImport("kernel32.dll", SetLastError = true)]
                    public static extern bool VirtualProtectEx(IntPtr hProcess, long lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);
                    [DllImport("kernel32.dll")]
                    public static extern bool WriteProcessMemory(IntPtr hProcess, long lpBaseAddress, [In, Out] byte[] buffer, uint size, out int lpNumberOfBytesWritten);
                }

                public static class x86
                {
                    [DllImport("kernel32.dll")]
                    public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
                    [DllImport("kernel32.dll")]
                    public static extern bool ReadProcessMemory(IntPtr hProcess, int lpBaseAddress, [In, Out] byte[] buffer, uint size, out int lpNumberOfBytesWritten);
                    [DllImport("kernel32.dll", SetLastError = true)]
                    public static extern bool VirtualProtectEx(IntPtr hProcess, int lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);
                    [DllImport("kernel32.dll")]
                    public static extern bool WriteProcessMemory(IntPtr hProcess, int lpBaseAddress, [In, Out] byte[] buffer, uint size, out int lpNumberOfBytesWritten);
                }
            }
        }

        private void GrabClients_Click(object sender, EventArgs e)
        {
            ClientList.Items.Clear();
            string ClientName = ASCIIEncoding.ASCII.GetString(Mem.ReadBytes(0x01C0A678, 15));  ///Not yet done as i didn't have anyone else in my game to get the next addresses.
            ClientList.Items.Add(ClientName);
        }

        private void GiveHostPoints_Click(object sender, EventArgs e)
        {
            //int SelectedClient = Convert.ToInt32(ClientList.SelectedItems);
            Mem.WriteBytes(0x01C0A6C8, new byte[] { 0xFF, 0xFF });
        }

        private void GodModeSwitch_Toggled(object sender, EventArgs e)
        {
            if(GodModeSwitch.IsOn)
            {
                Functions.God();
            }
            else
            {
                Functions.God();
            }
        }

        private void NoclipSwitch_Toggled(object sender, EventArgs e)
        {
            if (NoclipSwitch.IsOn)
            {
                Functions.Noclip();
            }
            else
            {
                Functions.Noclip();
            }
        }

        private void NoTargetSwitch_Toggled(object sender, EventArgs e)
        {
            if (NoTargetSwitch.IsOn)
            {
                Functions.NoTarget();
            }
            else
            {
                Functions.NoTarget();
            }
        }
     

        private void GiveSelfWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(GiveSelfWeapons.SelectedText == "AK7u")
            {
                Functions.GiveWeapon(Weapons.AK7u);
            }
            else if (GiveSelfWeapons.SelectedText == "AUG ")
            {
                Functions.GiveWeapon(Weapons.AUG);
            }
            else if (GiveSelfWeapons.SelectedText == "China_Lake")
            {
                Functions.GiveWeapon(Weapons.China_Lake);
            }
            else if (GiveSelfWeapons.SelectedText == "Claymore")
            {
                Functions.GiveWeapon(Weapons.Claymore);
            }
            else if (GiveSelfWeapons.SelectedText == "Commando")
            {
                Functions.GiveWeapon(Weapons.Commando);
            }
            else if (GiveSelfWeapons.SelectedText == "Crossbow")
            {
                Functions.GiveWeapon(Weapons.Crossbow);
            }
            else if (GiveSelfWeapons.SelectedText == "Cz75")
            {
                Functions.GiveWeapon(Weapons.Cz75);
            }
            else if (GiveSelfWeapons.SelectedText == "cz75dw")
            {
                Functions.GiveWeapon(Weapons.cz75dw);
            }
            else if (GiveSelfWeapons.SelectedText == "Dragonov")
            {
                Functions.GiveWeapon(Weapons.Dragonov);
            }
            else if (GiveSelfWeapons.SelectedText == "Famas")
            {
                Functions.GiveWeapon(Weapons.Famas);
            }
            else if (GiveSelfWeapons.SelectedText == "FnFal")
            {
                Functions.GiveWeapon(Weapons.FnFal);
            }
            else if (GiveSelfWeapons.SelectedText == "Frag")
            {
                Functions.GiveWeapon(Weapons.Frag);
            }
            else if (GiveSelfWeapons.SelectedText == "FreezeGun")
            {
                Functions.GiveWeapon(Weapons.FreezeGun);
            }
            else if (GiveSelfWeapons.SelectedText == "G11")
            {
                Functions.GiveWeapon(Weapons.G11);
            }
            else if (GiveSelfWeapons.SelectedText == "Galil")
            {
                Functions.GiveWeapon(Weapons.Galil);
            }
            else if (GiveSelfWeapons.SelectedText == "Hk21")
            {
                Functions.GiveWeapon(Weapons.Hk21);
            }
            else if (GiveSelfWeapons.SelectedText == "Hs10")
            {
                Functions.GiveWeapon(Weapons.Hs10);
            }
            else if (GiveSelfWeapons.SelectedText == "Ithica")
            {
                Functions.GiveWeapon(Weapons.Ithica);
            }
            else if (GiveSelfWeapons.SelectedText == "BallisticKnife")
            {
                Functions.GiveWeapon(Weapons.BallisticKnife);
            }
            else if (GiveSelfWeapons.SelectedText == "A1")
            {
                Functions.GiveWeapon(Weapons.A1);
            }
            else if (GiveSelfWeapons.SelectedText == "m14")
            {
                Functions.GiveWeapon(Weapons.m14);
            }
            else if (GiveSelfWeapons.SelectedText == "m16")
            {
                Functions.GiveWeapon(Weapons.m16);
            }
            else if (GiveSelfWeapons.SelectedText == "m1911")
            {
                Functions.GiveWeapon(Weapons.m1911);
            }
            else if (GiveSelfWeapons.SelectedText == "m72")
            {
                Functions.GiveWeapon(Weapons.m72);
            }
            else if (GiveSelfWeapons.SelectedText == "Mp5k")
            {
                Functions.GiveWeapon(Weapons.Mp5k);
            }
            else if (GiveSelfWeapons.SelectedText == "Vmpl")
            {
                Functions.GiveWeapon(Weapons.Vmpl);
            }
            else if (GiveSelfWeapons.SelectedText == "Pm63")
            {
                Functions.GiveWeapon(Weapons.Pm63);
            }
            else if (GiveSelfWeapons.SelectedText == "Python")
            {
                Functions.GiveWeapon(Weapons.Python);
            }
            else if (GiveSelfWeapons.SelectedText == "Raygun")
            {
                Functions.GiveWeapon(Weapons.Raygun);
            }
            else if (GiveSelfWeapons.SelectedText == "Rotweil72")
            {
                Functions.GiveWeapon(Weapons.Rotweil72);
            }
            else if (GiveSelfWeapons.SelectedText == "RPK")
            {
                Functions.GiveWeapon(Weapons.RPK);
            }
            else if (GiveSelfWeapons.SelectedText == "SPAS")
            {
                Functions.GiveWeapon(Weapons.SPAS);
            }
            else if (GiveSelfWeapons.SelectedText == "Spectre")
            {
                Functions.GiveWeapon(Weapons.Spectre);
            }
        }

        private void DropWeaponButton_Click(object sender, EventArgs e)
        {
            Functions.DropWeapon();//
        }
    }
}
