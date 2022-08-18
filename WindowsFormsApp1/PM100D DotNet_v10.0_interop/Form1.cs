using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Thorlabs.PM100D_64.Interop;

namespace DotNetSample_64
{
    public partial class Form1 : Form
    {
        private int counter;

        //private Thorlabs.PM100D.PM100D pm100d;
        private Thorlabs.PM100D_64.Interop.PM100D pm100d;


        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        double powerValue;
          

        public Form1()
        {
            InitializeComponent();          
            try
            {
             
                //PM100D
                  pm100d = new Thorlabs.PM100D_64.Interop.PM100D("USB0::0x1313::0x8078::PM002766::0::INSTR", false, false);
                //  For valid Ressource_Name see NI-Visa documentation.


                //PM16-130
               // pm100d = new Thorlabs.PM100D_64.Interop.PM100D("USB0::0x1313::0x807B::17020914::INSTR", false, false);
                //  For valid Ressource_Name see NI-Visa documentation.


                //PM400
               //  pm100d = new Thorlabs.PM100D_64.Interop.PM100D("USB0::0x1313::0x8075::P5000116::0::INSTR", false, false);
                //  For valid Ressource_Name see NI-Visa documentation.





            }

            catch (BadImageFormatException bie)
            {
                labelPower.Text = bie.Message;
            }
            catch (NullReferenceException nre)
            {
                labelPower.Text = nre.Message;
            }
            catch (ExternalException ex)
            {
                labelPower.Text = ex.Message;
            }
            finally
            {
                if (pm100d != null)
                    pm100d.Dispose();
            }
        }



        public void Timer1_Tick(object sender, EventArgs e)
        {

            pm100d.setWavelength(1000);
            pm100d.setAvgTime(0.1);


            pm100d.measPower(out powerValue);
                labelPower.Text = powerValue.ToString();

                label_Time.Text = DateTime.Now.ToString();
        }

        public void button1_Click(object sender, EventArgs e)
        {

            //PM100D
             pm100d = new Thorlabs.PM100D_64.Interop.PM100D("USB0::0x1313::0x8078::PM002766::0::INSTR", false, false);
            //  For valid Ressource_Name see NI-Visa documentation.


            //PM16-130
            //pm100d = new Thorlabs.PM100D_64.Interop.PM100D("USB0::0x1313::0x807B::17020914::INSTR", false, false);
            //  For valid Ressource_Name see NI-Visa documentation.


            //PM400
            //pm100d = new Thorlabs.PM100D_64.Interop.PM100D("USB0::0x1313::0x8075::P5000116::0::INSTR", false, false);
            //  For valid Ressource_Name see NI-Visa documentation.


            if (button1.Text == "STOP")
            {
                button1.Text = "START";
                timer1.Enabled = false;
            }
            else
            {
                button1.Text = "STOP";                
                timer1.Enabled = true;

            }
        }
      }
    }


