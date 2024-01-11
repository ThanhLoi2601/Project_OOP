using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_OOP
{
    public class Device_List : InfixingDevice1Months,ImportingStopDevice
    {
        // list Device is beeing stopping work.
        public List<Device> List_Device_Stop() // interface 1
        {
            List<Device> list = new List<Device>();
            foreach(Device dev in SystemPark.List_Devices_Main)
            {
                if(dev.Device_Status=="stop") // interface 2
                    list.Add(dev);
            }
            return list;
        }
        // List DEvice should be refix in next month
        public List<Device> List_Device_1Month()
        {
            List<Device> list = new List<Device>();
            foreach(Device dev in SystemPark.List_Devices_Main)
            {
                if(dev.Device_OUT.Month!=12&& dev.Device_OUT.Year==DateTime.Now.Year)
                {
                    if(dev.Device_OUT.Month==DateTime.Now.Month)
                    {
                        list.Add(dev);
                    }
                }
                else
                {
                    if (dev.Device_OUT.Month==12 && DateTime.Now.Month==12 && DateTime.Now.Year==dev.Device_OUT.Year)    
                    {
                        list.Add(dev);
                    }
                }

            }    
            return list;    
        }
        
        public static List<Device> Readfile(string path1)
        {
            List<Device> List_Devices_Used = new List<Device>();
            try
            {
                StreamReader sr = new StreamReader(path1, Encoding.UTF8);
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] arr = line.Split(';');
                    if (arr.Length == 8)
                    {
                        if (arr[1].Trim() == "Camera")
                        {
                            Device camera = new Device_Camera();
                            camera.Device_ID = arr[0];
                            camera.Device_Name = arr[1];
                            camera.Device_Type = arr[2];
                            camera.Device_Locate = arr[3];
                            if (arr[4] == "w" || arr[4] == "W")
                            {
                                camera.Device_Status = "work";
                            }
                            else
                            {
                                camera.Device_Status = "stop";
                            }
                            camera.Device_IN = DateTime.Parse(arr[5]);
                            camera.Device_OUT = DateTime.Parse(arr[6]);
                            string[] arr_temp = arr[7].Split("#");
                            for (int i = 0; i < arr_temp.Length; i++)
                                camera.Device_Videos.Add(arr_temp[i]);
                            List_Devices_Used.Add(camera);
                        }
                        if (arr[1].Trim() == "Elevator")
                        {
                            Device elevator = new Device_Elevator();
                            elevator.Device_ID = arr[0];
                            elevator.Device_Name = arr[1];
                            elevator.Device_Type = arr[2];
                            elevator.Device_Locate = arr[3];
                            if (arr[4] == "w" || arr[4] == "W")
                            {
                                elevator.Device_Status = "work";
                            }
                            else
                            {
                                elevator.Device_Status = "stop";
                            }
                            elevator.Device_IN = DateTime.Parse(arr[5]);
                            elevator.Device_OUT = DateTime.Parse(arr[6]);
                            elevator.Device_ID_MainComp = arr[7];
                            List_Devices_Used.Add(elevator);
                        }
                        if (arr[1].Trim() == "ElectricGate")
                        {
                            Device electricGate = new Device_ElectricGate();
                            electricGate.Device_ID = arr[0];
                            electricGate.Device_Name = arr[1];
                            electricGate.Device_Type = arr[2];
                            electricGate.Device_Locate = arr[3];
                            if (arr[4] == "w" || arr[4] == "W")
                            {
                                electricGate.Device_Status = "work";
                            }
                            else
                            {
                                electricGate.Device_Status = "stop";
                            }
                            electricGate.Device_IN = DateTime.Parse(arr[5]);
                            electricGate.Device_OUT = DateTime.Parse(arr[6]);
                            string[] arr_temp = arr[7].Split("#");
                            for (int i = 0; i < arr_temp.Length; i++)
                            {
                                electricGate.Device_Works.Add(DateTime.Parse(arr_temp[i]));
                            }
                            List_Devices_Used.Add(electricGate);
                        }
                        if (arr[1].Trim() == "ElectricStation")
                        {
                            Device elctricsta = new Device_ElectricalStation();
                            elctricsta.Device_ID = arr[0];
                            elctricsta.Device_Name = arr[1];
                            elctricsta.Device_Type = arr[2];
                            elctricsta.Device_Locate = arr[3];
                            if (arr[4] == "w" || arr[4] == "W")
                            {
                                elctricsta.Device_Status = "work";
                            }
                            else
                            {
                                elctricsta.Device_Status = "stop";
                            }
                            elctricsta.Device_IN = DateTime.Parse(arr[5]);
                            elctricsta.Device_OUT = DateTime.Parse(arr[6]);
                            elctricsta.Device_PowerCapacity = double.Parse(arr[7]);
                            List_Devices_Used.Add(elctricsta);
                        }
                    }
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return List_Devices_Used;
        }
        public static void OuputList(List<Device> ds)
        {
            Console.WriteLine("|{0,20}|{1,15}|{2,25}|{3,20}|{4,10}|{5,23}|{6,23}|","Device_ID","Device_Name","Device_Type","Device_Location","Situation","Starting Up","Infixing");
            foreach ( Device dev in ds) 
            {
                    dev.Dev_Output();
            }
        }
        public static string Find_Device(string ID,List<Device> List_Devices_Used)
        {
            foreach( Device dv in List_Devices_Used) 
            {
                if (dv.Device_ID == ID)
                {
                    return dv.ToString(); 
                }
            }
            return "Errorr";
        }
        
    }
}
