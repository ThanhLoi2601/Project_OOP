using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    public static class Vehicle_List
    {
        
        public static List<Vehicle> Docfile(string path)
        {
            List<Vehicle> ls = new List<Vehicle>();
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] a = line.Split(';');

                    if (a.Length == 8)
                    {
                        Vehicle pt;
                        if (a[4] != "null")
                        {
                            if (a[0][0] == '1')
                                pt = new Vehicle_Electric(a[0], a[1], a[2], DateTime.Parse(a[3]), DateTime.Parse(a[4]), int.Parse(a[5]), double.Parse(a[6]));
                            else if (a[0][0] == '2')
                                pt = new Vehicle_Car(a[0], a[1], a[2], DateTime.Parse(a[3]), DateTime.Parse(a[4]), int.Parse(a[5]));
                            else if (a[0][0] == '3')
                                pt = new Vehicle_Motobike(a[0], a[1], a[2], DateTime.Parse(a[3]), DateTime.Parse(a[4]), int.Parse(a[5]));
                            else if (a[0][0] == '4')
                                pt = new Vehicle_Scooter(a[0], a[1], a[2], DateTime.Parse(a[3]), DateTime.Parse(a[4]), int.Parse(a[5]));
                            else if (a[0][0] == '5')
                                pt = new Vehicle_Bike(a[0], a[1], a[2], DateTime.Parse(a[3]), DateTime.Parse(a[4]));
                            else if (a[0][0] == '6')
                                pt = new Vehicle_Truck(a[0], a[1], a[2], DateTime.Parse(a[3]), DateTime.Parse(a[4]), int.Parse(a[5]));
                            else
                                throw new Exception("ERROR");
                        }
                        else
                        {
                            if (a[0][0] == '1')
                                pt = new Vehicle_Electric(a[0], a[1], a[2], DateTime.Parse(a[3]), int.Parse(a[5]), double.Parse(a[6]));
                            else if (a[0][0] == '2')
                                pt = new Vehicle_Car(a[0], a[1], a[2], DateTime.Parse(a[3]), int.Parse(a[5]));
                            else if (a[0][0] == '3')
                                pt = new Vehicle_Motobike(a[0], a[1], a[2], DateTime.Parse(a[3]), int.Parse(a[5]));
                            else if (a[0][0] == '4')
                                pt = new Vehicle_Scooter(a[0], a[1], a[2], DateTime.Parse(a[3]), int.Parse(a[5]));
                            else if (a[0][0] == '5')
                                pt = new Vehicle_Bike(a[0], a[1], a[2], DateTime.Parse(a[3]));
                            else if (a[0][0] == '6')
                                pt = new Vehicle_Truck(a[0], a[1], a[2], DateTime.Parse(a[3]), int.Parse(a[5]));
                            else
                                throw new Exception("ERROR");
                        }

                        pt.Veh_Input_Other_services(int.Parse(a[7]));

                        ls.Add(pt);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ls;
        }
        public static void OutList(List<Vehicle> ls)
        {
            
            Console.WriteLine("|{0,23}|{1,10}|{2,10}|{3,22}|{4,22}|{5,15}|{6,10}|", "ID", "Type", "Locate", "In Time", "Out Time", "Other Services", "Vehicle");
            //Console.WriteLine("|         ID               |  Type   |    Locate     |       In Time        |      Out Time     |   Other Services   |    Vehicle   |");
            foreach (Vehicle veh in ls)
            {
                Console.WriteLine("");
                veh.Veh_Output();
                Console.WriteLine("");
            }
            Console.WriteLine("OTHER SERVICE LIST FOR EACH VEHICLE");
            Console.WriteLine("I. ELECTRIC VEHICLE");
            Console.WriteLine("1.Charge");
            Console.WriteLine("2.No charging");
            Console.WriteLine("II. CAR VEHICLE:");
            Console.WriteLine("1.Refuel");
            Console.WriteLine("2.Car wash");
            Console.WriteLine("3.Both");
            Console.WriteLine("4.No service");
            Console.WriteLine("III. MOTORBIKE VEHICLE");
            Console.WriteLine("1.Refuel");
            Console.WriteLine("2.No service");
            Console.WriteLine("IV. SCOOTER VEHICLE");
            Console.WriteLine("1.Refuel");
            Console.WriteLine("2.No service");
            Console.WriteLine("V. BIKE VEHICLE");
            Console.WriteLine("1.Bike wash");
            Console.WriteLine("2.No service");
            Console.WriteLine("VI. TRUCK VEHICLE");
            Console.WriteLine("1.Refuel");
            Console.WriteLine("2.Truck wash");
            Console.WriteLine("3.Both");
            Console.WriteLine("4.No service");
        }

        //Ghi file 
        public static void GhiFile(List<Vehicle> ls, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            foreach (Vehicle veh in ls)
            {
                sw.WriteLine(veh.toString());
                sw.Flush();
            }

            fs.Close();
            Console.WriteLine("File: "+path+" da duoc chinh sua thanh cong!!");
        }

    }
}
