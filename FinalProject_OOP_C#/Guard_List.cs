using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    public class Guard_List:Guard_Management_Interface
    {
        public void OuputListWorker()
        {
            Console.WriteLine("_______Thong tin chi tiet danh sach bao ve_____");
            Guard_List.OuputList(SystemPark.List_Guard_Main);
        }
        // Tra cuu danh sach chinh thuc
        public void OuputInformation()
        {
            Console.WriteLine("Information of Manager:");
            Console.WriteLine("         ID           |        Name         |Shifts|  Salary/1day  | Overtime |        Address        |       Call Number     |");
            SystemPark.Manager.Gua_OutPut();
        }
        public static Guard DocFile_(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            string line = sr.ReadLine();
            string[] a = line.Split(';');
            return new Guard(a[0], a[1], int.Parse(a[2]), long.Parse(a[3]), TimeSpan.Parse(a[4]), a[5], a[6]);
        }
        public static List<Guard> Docfile(string path)
        {
            List<Guard> list = new List<Guard>();
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] a = line.Split(';');
                    if (a.Length == 7)
                    {
                        Guard bv = new Guard(a[0], a[1], int.Parse(a[2]), long.Parse(a[3]), TimeSpan.Parse(a[4]), a[5], a[6]);
                        list.Add(bv);
                    }
                    else throw new Exception("ERORR");
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return list;
        }
        public static void OuputList(List<Guard> list)
        {
            Console.WriteLine("         ID           |        Name         |Shifts|  Salary/1day  | Overtime |        Address        |       Call Number     |");
            foreach(Guard guard in list) 
            {
                guard.Gua_OutPut();
            }
        }
    }
}
