using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MccDaq;
using PID_WinForm;
namespace XControl
{
    public partial class MainForm : Form
    {

        private GroupControl GC;



        //PID period
        int circle;
        
        
        /*
         * receive control singal from digital port 
         * from port 0 to port 7
         */ 
        int digitalControlSingal_1;
        int digitalControlSingal_2;
        int digitalControlSingal_3;
        int digitalControlSingal_4;
        int digitalControlSingal_5;
        int digitalControlSingal_6;
        int digitalControlSingal_7;
        int digitalControlSingal_8;


        /*
         * variable which store the Temperature
         */
        float temperatureValue_1;
        float temperatureValue_2;
        float temperatureValue_3;
        float temperatureValue_4;
        float temperatureValue_5;
        float temperatureValue_6;
        float temperatureValue_7;
        float temperatureValue_8;


        /*
         * high T and low T
         */
        float punishmentT;
        float confortableT;


        /*
         * PID control model
         */
        PIDControl PID_1;
        PIDControl PID_2;
        PIDControl PID_3;
        PIDControl PID_4;
        PIDControl PID_5;
        PIDControl PID_6;
        PIDControl PID_7;
        PIDControl PID_8;



        /*
         * temperature control variable in up or down 
         * of the temperature
         * 
         */

        bool isUp_1 ;
        bool isUp_2 ;
        bool isUp_3 ;
        bool isUp_4 ;
        bool isUp_5 ;
        bool isUp_6 ;
        bool isUp_7 ;
        bool isUp_8 ;

        bool isDown_1;
        bool isDown_2;
        bool isDown_3;
        bool isDown_4;
        bool isDown_5;
        bool isDown_6;
        bool isDown_7;
        bool isDown_8;

        bool isStartPID_1;
        bool isStartPID_2;
        bool isStartPID_3;
        bool isStartPID_4;
        bool isStartPID_5;
        bool isStartPID_6;
        bool isStartPID_7;
        bool isStartPID_8;

        bool startPID_1;
        bool startPID_2;
        bool startPID_3;
        bool startPID_4;
        bool startPID_5;
        bool startPID_6;
        bool startPID_7;
        bool startPID_8;

        double result_1;
        double result_2;
        double result_3;
        double result_4;
        double result_5;
        double result_6;
        double result_7;
        double result_8;

        int FirstProportion_1;
        int FirstProportion_2;
        int FirstProportion_3;
        int FirstProportion_4;
        int FirstProportion_5;
        int FirstProportion_6;
        int FirstProportion_7;
        int FirstProportion_8;

        int proportion_1;
        int proportion_2;
        int proportion_3;
        int proportion_4;
        int proportion_5;
        int proportion_6;
        int proportion_7;
        int proportion_8;

        int PID_Count_1;
        int PID_Count_2;
        int PID_Count_3;
        int PID_Count_4;
        int PID_Count_5;
        int PID_Count_6;
        int PID_Count_7;
        int PID_Count_8;


        bool btnSimInput_1;
        bool btnSimInput_2;
        bool btnSimInput_3;
        bool btnSimInput_4;
        bool btnSimInput_5;
        bool btnSimInput_6;
        bool btnSimInput_7;
        bool btnSimInput_8;




        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GC = new GroupControl();
            

            /*
             * set the sampling rate to 10ms 
            */
            timer_1.Interval = 10;
            timer_2.Interval = 10;
            timer_3.Interval = 10;
            timer_4.Interval = 10;
            timer_5.Interval = 10;
            timer_6.Interval = 10;
            timer_7.Interval = 10;
            timer_8.Interval = 10;

            btnSimInput_1 = true;

        }

        private void timer_1_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            temperatureValue_1 = GC.getT(1);
            lblTValue_1.Text = temperatureValue_1.ToString("00.00");



            if (isUp_1 == true)
            {
                if ((punishmentT - temperatureValue_1) < 5 && isStartPID_1 == true)
                {
                    startPID_1 = true;
                    isStartPID_1 = false;

                    result_1 = PID_1.PIDCalcDirect(temperatureValue_1);
                    FirstProportion_1 = Convert.ToInt32(result_1);
                    proportion_1 = Convert.ToInt32(result_1);
                    proportion_1 = PID_1.ConvertAccordToPropotation(proportion_1,circle,FirstProportion_1);
                    
                    PID_Count_1 = 0;
                    GC.TUp(1);

                }





                if (PID_Count_1 == proportion_1 && startPID_1 == true)
                {
                    GC.TNature(1);
                }


                if (startPID_1 == true)
                {
                    PID_Count_1++;

                }


                if (startPID_1 == true && PID_Count_1 == circle)
                {
                    result_1 = PID_1.PIDCalcDirect(temperatureValue_1);

                    proportion_1 = Convert.ToInt32(result_1);
                    PID_Count_1 = 0;



                    if (result_1 > 0)
                    {

                        GC.TUp(1);

                    }
                    else
                    {
                        GC.TDown(1);
                    }

                    proportion_1 = PID_1.ConvertAccordToPropotation(proportion_1, circle, FirstProportion_1);
                    
                }
               
                System.IO.File.AppendAllText("e:\\result_1.txt", temperatureValue_1.ToString("00.00") + "\r\n");
            }


            if (isDown_1 == true)
            {
                if ((temperatureValue_1 - confortableT) < 5 && isStartPID_1 == true)
                {
                    startPID_1 = true;
                    isStartPID_1 = false;

                    result_1 = PID_1.PIDCalcDirect(temperatureValue_1);
                    FirstProportion_1 = Convert.ToInt32(result_1);
                    proportion_1 = Convert.ToInt32(result_1);
                    proportion_1 = PID_1.ConvertAccordToPropotation(proportion_1,circle,FirstProportion_1);
                    PID_Count_1 = 0;
                    GC.TDown(1);
                }





                if (PID_Count_1 == proportion_1 && startPID_1 == true)
                {
                    GC.TNature(1);
                }

                if (startPID_1 == true)
                {
                    PID_Count_1++;

                }

                if (startPID_1 == true && PID_Count_1 == circle)
                {
                    double result_1 = PID_1.PIDCalcDirect(temperatureValue_1);
                    proportion_1 = Convert.ToInt32(result_1);
                    PID_Count_1 = 0;
                    if (result_1 > 0)
                    {
                        GC.TUp(1);
                    }
                    else
                    {
                        GC.TDown(1);
                    }

                    proportion_1 = PID_1.ConvertAccordToPropotation(proportion_1,circle,FirstProportion_1);


                }
                
                System.IO.File.AppendAllText("e:\\result_1.txt", temperatureValue_1.ToString("00.00") + "\r\n");
            }
        }

        private void btnTestByHand_1_Click(object sender, EventArgs e)
        {
            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
            



            if (btnSimInput_1 == true)
            {
                digitalControlSingal_1 = 1;
                btnTestByHand_1.Text = "Off";
                btnSimInput_1 = false;
                lblTState_1.Text = "On";

                isUp_1 = true;
                isDown_1 = false;
               
                isStartPID_1 = true;
                PID_Count_1 = 0;
                
                //isFirstPor = true;
                GC.TUp(1);
                startPID_1 = false;
                circle = 10;
                PID_1 = new PIDControl(3, 0.1, 0.5, punishmentT);
              //  System.IO.File.AppendAllText("e:\\result_1.txt", "惩罚：" + "Kp:" + tbKp.Text + "  Ki" + tbKi.Text + "  Kd" + tbKd.Text + "\r\n");
            }
            else
            {
                digitalControlSingal_1 = 0;
                btnTestByHand_1.Text = "ON";
                btnSimInput_1 = true;
                isDown_1 = true;
                isStartPID_1 = true;
               
                startPID_1 = false;
                isUp_1 = false;
                PID_Count_1 = 0;
                lblTState_1.Text = "Off";
                GC.TDown(1);
                circle = 10;
                PID_1 = new PIDControl(7, 0.1, 0.5, confortableT);
             //   System.IO.File.AppendAllText("e:\\result_1.txt", "舒适：" + "Kp:" + tbDownKp.Text + "  Ki" + tbDownKi.Text + "  Kd" + tbDownKd.Text + "\r\n");
            }

            timer_1.Start();
        }
    }
}
