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

        private GroupControl Board_1;
        private GroupControl Board_2;


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
        double temperatureValue_1;
        double temperatureValue_2;
        double temperatureValue_3;
        double temperatureValue_4;
        double temperatureValue_5;
        double temperatureValue_6;
        double temperatureValue_7;
        double temperatureValue_8;


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


        /*
         * if the is tested by hand
         */
        bool isTestByHand_1;
        bool isTestByHand_2;
        bool isTestByHand_3;
        bool isTestByHand_4;
        bool isTestByHand_5;
        bool isTestByHand_6;
        bool isTestByHand_7;
        bool isTestByHand_8;

        /*
         * if execute the control moduel
         */

        bool isExecuteControlModel_1;
        bool isExecuteControlModel_2;
        bool isExecuteControlModel_3;
        bool isExecuteControlModel_4;
        bool isExecuteControlModel_5;
        bool isExecuteControlModel_6;
        bool isExecuteControlModel_7;
        bool isExecuteControlModel_8;


        bool isFirstChangeUp_1;
        bool isFirstChangeDown_1;
        bool isFirstChangeUp_2;
        bool isFirstChangeDown_2;
        bool isFirstChangeUp_3;
        bool isFirstChangeDown_3;
        bool isFirstChangeUp_4;
        bool isFirstChangeDown_4;
        bool isFirstChangeUp_5;
        bool isFirstChangeDown_5;
        bool isFirstChangeUp_6;
        bool isFirstChangeDown_6;
        bool isFirstChangeUp_7;
        bool isFirstChangeDown_7;
        bool isFirstChangeUp_8;
        bool isFirstChangeDown_8;
        /*
         * if the isTestByHand button is clicked
         */
        bool isTestByHandClick_1;
        bool isTestByHandClick_2;
        bool isTestByHandClick_3;
        bool isTestByHandClick_4;
        bool isTestByHandClick_5;
        bool isTestByHandClick_6;
        bool isTestByHandClick_7;
        bool isTestByHandClick_8;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //board_1 use to output
            Board_1 = new GroupControl(0,false);
           
            //board_2 use to input
            Board_2 = new GroupControl(1, true);


           
            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
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
            btnSimInput_2 = true;
            btnSimInput_3 = true;
            btnSimInput_4 = true;
            btnSimInput_5 = true;
            btnSimInput_6 = true;
            btnSimInput_7 = true;
            btnSimInput_8 = true;


            Board_1.SetTConvertParam(0.26, 480, 0.26, 480, 0.2, 700, 0.2, 700, 0.2, 700, 0.2, 700, 0.2, 700, 0.2, 700);

            isTestByHandClick_1 = true;
            isTestByHandClick_2 = true;
            isTestByHandClick_3 = true;
            isTestByHandClick_4 = true;
            isTestByHandClick_5 = true;
            isTestByHandClick_6 = true;
            isTestByHandClick_7 = true;
            isTestByHandClick_8 = true;

        }

        private void timer_1_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            temperatureValue_1 = Board_1.getT(1);
            lblTValue_1.Text = temperatureValue_1.ToString("00.00");

            if (isTestByHand_1 == false)
            {
                digitalControlSingal_1 = Board_2.getSingal(1);
            }



            if (isExecuteControlModel_1 == true)
            {
                if (digitalControlSingal_1 == 1 && isFirstChangeUp_1 == true)
                {
                    
                   
                    btnSimInput_1 = false;
                    lblTState_1.Text = "On";

                    isFirstChangeUp_1 = false;
                    isFirstChangeDown_1 = true;
                    isUp_1 = true;
                    isDown_1 = false;

                    isStartPID_1 = true;
                    PID_Count_1 = 0;

                    //isFirstPor = true;
                    Board_1.TUp(1);
                    startPID_1 = false;
                    circle = 10;
                    PID_1 = new PIDControl(3, 0.1, 0.5, punishmentT);
                    //  System.IO.File.AppendAllText("e:\\result_1.txt", "惩罚：" + "Kp:" + tbKp.Text + "  Ki" + tbKi.Text + "  Kd" + tbKd.Text + "\r\n");
                }
                else if (digitalControlSingal_1 == 0 && isFirstChangeDown_1 == true)
                {
                   
                    btnSimInput_1 = true;
                    isDown_1 = true;
                    isStartPID_1 = true;

                    isFirstChangeDown_1 = false;
                    isFirstChangeUp_1 = true;

                    startPID_1 = false;
                    isUp_1 = false;
                    PID_Count_1 = 0;
                    lblTState_1.Text = "Off";
                    Board_1.TDown(1);
                    circle = 10;
                    PID_1 = new PIDControl(7, 0.1, 0.5, confortableT);
                    //   System.IO.File.AppendAllText("e:\\result_1.txt", "舒适：" + "Kp:" + tbDownKp.Text + "  Ki" + tbDownKi.Text + "  Kd" + tbDownKd.Text + "\r\n");
                }
                else
                {
                    ;
                }
            }



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
                    Board_1.TUp(1);
                    lblDebug.Text = "up-";

                }





                if (PID_Count_1 == proportion_1 && startPID_1 == true)
                {
                    Board_1.TNature(1);
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

                        Board_1.TUp(1);

                    }
                    else
                    {
                        Board_1.TDown(1);
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
                    Board_1.TDown(1);
                    lblDebug.Text = "down-";
                }





                if (PID_Count_1 == proportion_1 && startPID_1 == true)
                {
                    Board_1.TNature(1);
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
                        Board_1.TUp(1);
                    }
                    else
                    {
                        Board_1.TDown(1);
                    }

                    proportion_1 = PID_1.ConvertAccordToPropotation(proportion_1,circle,FirstProportion_1);


                }
                
                System.IO.File.AppendAllText("e:\\result_1.txt", temperatureValue_1.ToString("00.00") + "\r\n");
            }
        }

        private void btnTestByHand_1_Click(object sender, EventArgs e)
        {

            //digitalControlSingal_1 = Board_2.getSingal(1);
            

            isTestByHand_1 = true;
            if (isTestByHandClick_1 == true)
            {
                isTestByHandClick_1 = false;
                digitalControlSingal_1 = 1;
            }
            else
            {
                isTestByHandClick_1 = true;
                digitalControlSingal_1 = 0;
            }
            isExecuteControlModel_1 = true;
            isFirstChangeUp_1 = true;
            isFirstChangeDown_1 = true;
            timer_1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isTestByHand_2 = true;
            if (isTestByHandClick_2 == true)
            {
                isTestByHandClick_2 = false;
                digitalControlSingal_2 = 1;
            }
            else
            {
                isTestByHandClick_2 = true;
                digitalControlSingal_2 = 0;
            }
            isExecuteControlModel_2 = true;
            isFirstChangeUp_2 = true;
            isFirstChangeDown_2 = true;
            





            timer_2.Start();
        }

        private void btnTestByHand_3_Click(object sender, EventArgs e)
        {
            isTestByHand_3 = true;
            if (isTestByHandClick_3 == true)
            {
                isTestByHandClick_3 = false;
                digitalControlSingal_3 = 1;
            }
            else
            {
                isTestByHandClick_3 = true;
                digitalControlSingal_3 = 0;
            }
            isExecuteControlModel_3 = true;
            isFirstChangeUp_3 = true;
            isFirstChangeDown_3 = true;






            timer_3.Start();
        }

        private void btnTestByHand_4_Click(object sender, EventArgs e)
        {
            isTestByHand_4 = true;
            if (isTestByHandClick_4 == true)
            {
                isTestByHandClick_4 = false;
                digitalControlSingal_4 = 1;
            }
            else
            {
                isTestByHandClick_4 = true;
                digitalControlSingal_4 = 0;
            }
            isExecuteControlModel_4 = true;
            isFirstChangeUp_4 = true;
            isFirstChangeDown_4 = true;





            timer_4.Start();
        }

        private void btnTestByHand_5_Click(object sender, EventArgs e)
        {
            isTestByHand_5 = true;
            if (isTestByHandClick_5 == true)
            {
                isTestByHandClick_5 = false;
                digitalControlSingal_5 = 1;
            }
            else
            {
                isTestByHandClick_5 = true;
                digitalControlSingal_5 = 0;
            }
            isExecuteControlModel_5 = true;
            isFirstChangeUp_5 = true;
            isFirstChangeDown_5 = true;





            timer_5.Start();
        }

        private void btnTestByHand_6_Click(object sender, EventArgs e)
        {
            isTestByHand_6 = true;
            if (isTestByHandClick_6 == true)
            {
                isTestByHandClick_6 = false;
                digitalControlSingal_6 = 1;
            }
            else
            {
                isTestByHandClick_6 = true;
                digitalControlSingal_6 = 0;
            }
            isExecuteControlModel_6 = true;
            isFirstChangeUp_6 = true;
            isFirstChangeDown_6 = true;


            timer_6.Start();
        }

        private void btnTestByHand_7_Click(object sender, EventArgs e)
        {
            isTestByHand_7 = true;
            if (isTestByHandClick_7 == true)
            {
                isTestByHandClick_7 = false;
                digitalControlSingal_7 = 1;
            }
            else
            {
                isTestByHandClick_7 = true;
                digitalControlSingal_7 = 0;
            }
            isExecuteControlModel_7 = true;
            isFirstChangeUp_7 = true;
            isFirstChangeDown_7 = true;



            timer_7.Start();
        }

        private void btnTestByHand_8_Click(object sender, EventArgs e)
        {
            isTestByHand_8 = true;
            if (isTestByHandClick_8 == true)
            {
                isTestByHandClick_8 = false;
                digitalControlSingal_8 = 1;
            }
            else
            {
                isTestByHandClick_8 = true;
                digitalControlSingal_8 = 0;
            }
            isExecuteControlModel_8 = true;
            isFirstChangeUp_8 = true;
            isFirstChangeDown_8 = true;
            
            timer_8.Start();
        }

        private void timer_2_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            temperatureValue_2 = Board_1.getT(2);
            lblTValue_2.Text = temperatureValue_2.ToString("00.00");

            if (isTestByHand_2 == false)
            {
                digitalControlSingal_2 = Board_2.getSingal(2);
            }

            if (isExecuteControlModel_2 == true)
            {
                if (digitalControlSingal_2 == 1 && isFirstChangeUp_2 == true)
                {
                    
                    btnSimInput_2 = false;
                    lblTState_2.Text = "On";

                    isFirstChangeUp_2 = false;
                    isFirstChangeDown_2 = true;

                    isUp_2 = true;
                    isDown_2 = false;

                    isStartPID_2 = true;
                    PID_Count_2 = 0;

                    //isFirstPor = true;
                    Board_1.TUp(2);
                    startPID_2 = false;
                    circle = 10;
                    PID_2 = new PIDControl(3, 0.1, 0.5, punishmentT);
                    //  System.IO.File.AppendAllText("e:\\result_1.txt", "惩罚：" + "Kp:" + tbKp.Text + "  Ki" + tbKi.Text + "  Kd" + tbKd.Text + "\r\n");
                }
                else if (digitalControlSingal_2 == 0 && isFirstChangeDown_2 == true)
                {
                   
                 
                    btnSimInput_2 = true;
                    isDown_2 = true;
                    isStartPID_2 = true;

                    isFirstChangeDown_2 = false;
                    isFirstChangeUp_2 = true;

                    startPID_2 = false;
                    isUp_2 = false;
                    PID_Count_2 = 0;
                    lblTState_2.Text = "Off";
                    Board_1.TDown(2);
                    circle = 10;
                    PID_2 = new PIDControl(7, 0.1, 0.5, confortableT);
                    //   System.IO.File.AppendAllText("e:\\result_2.txt", "舒适：" + "Kp:" + tbDownKp.Text + "  Ki" + tbDownKi.Text + "  Kd" + tbDownKd.Text + "\r\n");
                }
                else
                {
                    ;
                }
            }



            if (isUp_2 == true)
            {
                if ((punishmentT - temperatureValue_2) < 5 && isStartPID_2 == true)
                {
                    startPID_2 = true;
                    isStartPID_2 = false;

                    result_2 = PID_2.PIDCalcDirect(temperatureValue_2);
                    FirstProportion_2 = Convert.ToInt32(result_2);
                    proportion_2 = Convert.ToInt32(result_2);
                    proportion_2 = PID_2.ConvertAccordToPropotation(proportion_2, circle, FirstProportion_2);

                    PID_Count_2 = 0;
                    Board_1.TUp(2);
                    lblDebug.Text = "up-";

                }





                if (PID_Count_2 == proportion_2 && startPID_2 == true)
                {
                    Board_1.TNature(2);
                }


                if (startPID_2 == true)
                {
                    PID_Count_2++;

                }


                if (startPID_2 == true && PID_Count_2 == circle)
                {
                    result_2 = PID_2.PIDCalcDirect(temperatureValue_2);

                    proportion_2 = Convert.ToInt32(result_2);
                    PID_Count_2 = 0;



                    if (result_2 > 0)
                    {

                        Board_1.TUp(2);

                    }
                    else
                    {
                        Board_1.TDown(2);
                    }

                    proportion_2 = PID_2.ConvertAccordToPropotation(proportion_2, circle, FirstProportion_2);

                }

                System.IO.File.AppendAllText("e:\\result_2.txt", temperatureValue_2.ToString("00.00") + "\r\n");
            }


            if (isDown_2 == true)
            {
                if ((temperatureValue_2 - confortableT) < 5 && isStartPID_2 == true)
                {
                    startPID_2 = true;
                    isStartPID_2 = false;

                    result_2 = PID_2.PIDCalcDirect(temperatureValue_2);
                    FirstProportion_2 = Convert.ToInt32(result_2);
                    proportion_2 = Convert.ToInt32(result_2);
                    proportion_2 = PID_2.ConvertAccordToPropotation(proportion_2, circle, FirstProportion_2);
                    PID_Count_2 = 0;
                    Board_1.TDown(2);
                    lblDebug.Text = "down-";
                }





                if (PID_Count_2 == proportion_2 && startPID_2 == true)
                {
                    Board_1.TNature(2);
                }

                if (startPID_2 == true)
                {
                    PID_Count_2++;

                }

                if (startPID_2 == true && PID_Count_2 == circle)
                {
                    double result_2 = PID_2.PIDCalcDirect(temperatureValue_2);
                    proportion_2 = Convert.ToInt32(result_2);
                    PID_Count_2 = 0;
                    if (result_2 > 0)
                    {
                        Board_1.TUp(2);
                    }
                    else
                    {
                        Board_1.TDown(2);
                    }

                    proportion_2 = PID_2.ConvertAccordToPropotation(proportion_2, circle, FirstProportion_2);


                }

                System.IO.File.AppendAllText("e:\\result_2.txt", temperatureValue_2.ToString("00.00") + "\r\n");
            }
        }

        private void timer_3_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            temperatureValue_3 = Board_1.getT(3);
            lblTValue_3.Text = temperatureValue_3.ToString("00.00");

            if (isTestByHand_3 == false)
            {
                digitalControlSingal_3 = Board_2.getSingal(3);
            }


            if (isExecuteControlModel_3 == true)
            {
                if (digitalControlSingal_3 == 1 && isFirstChangeUp_3 == true)
                {
                    
                    btnSimInput_3 = false;
                    lblTState_3.Text = "On";

                    isFirstChangeUp_3 = false;
                    isFirstChangeDown_3 = true;
                    isUp_3 = true;
                    isDown_3 = false;

                    isStartPID_3 = true;
                    PID_Count_3 = 0;

                    //isFirstPor = true;
                    Board_1.TUp(3);
                    startPID_3 = false;
                    circle = 10;
                    PID_3 = new PIDControl(3, 0.1, 0.5, punishmentT);
                    //  System.IO.File.AppendAllText("e:\\result_3.txt", "惩罚：" + "Kp:" + tbKp.Text + "  Ki" + tbKi.Text + "  Kd" + tbKd.Text + "\r\n");
                }
                else if (digitalControlSingal_3 == 0 && isFirstChangeDown_3 == true)
                {
                   
                    btnSimInput_3 = true;
                    isDown_3 = true;
                    isStartPID_3 = true;

                    isFirstChangeDown_3 = false;
                    isFirstChangeUp_3 = true;

                    startPID_3 = false;
                    isUp_3 = false;
                    PID_Count_3 = 0;
                    lblTState_3.Text = "Off";
                    Board_1.TDown(3);
                    circle = 10;
                    PID_3 = new PIDControl(7, 0.1, 0.5, confortableT);
                    //   System.IO.File.AppendAllText("e:\\result_3.txt", "舒适：" + "Kp:" + tbDownKp.Text + "  Ki" + tbDownKi.Text + "  Kd" + tbDownKd.Text + "\r\n");
                }
                else
                {
                    ;
                }
            }



            if (isUp_3 == true)
            {
                if ((punishmentT - temperatureValue_3) < 5 && isStartPID_3 == true)
                {
                    startPID_3 = true;
                    isStartPID_3 = false;

                    result_3 = PID_3.PIDCalcDirect(temperatureValue_3);
                    FirstProportion_3 = Convert.ToInt32(result_3);
                    proportion_3 = Convert.ToInt32(result_3);
                    proportion_3 = PID_3.ConvertAccordToPropotation(proportion_3, circle, FirstProportion_3);

                    PID_Count_3 = 0;
                    Board_1.TUp(3);
                    lblDebug.Text = "up-";

                }





                if (PID_Count_3 == proportion_3 && startPID_3 == true)
                {
                    Board_1.TNature(3);
                }


                if (startPID_3 == true)
                {
                    PID_Count_3++;

                }


                if (startPID_3 == true && PID_Count_3 == circle)
                {
                    result_3 = PID_3.PIDCalcDirect(temperatureValue_3);

                    proportion_3 = Convert.ToInt32(result_3);
                    PID_Count_3 = 0;



                    if (result_3 > 0)
                    {

                        Board_1.TUp(3);

                    }
                    else
                    {
                        Board_1.TDown(3);
                    }

                    proportion_3 = PID_3.ConvertAccordToPropotation(proportion_3, circle, FirstProportion_3);

                }

                System.IO.File.AppendAllText("e:\\result_3.txt", temperatureValue_3.ToString("00.00") + "\r\n");
            }


            if (isDown_3 == true)
            {
                if ((temperatureValue_3 - confortableT) < 5 && isStartPID_3 == true)
                {
                    startPID_3 = true;
                    isStartPID_3 = false;

                    result_3 = PID_3.PIDCalcDirect(temperatureValue_3);
                    FirstProportion_3 = Convert.ToInt32(result_3);
                    proportion_3 = Convert.ToInt32(result_3);
                    proportion_3 = PID_3.ConvertAccordToPropotation(proportion_3, circle, FirstProportion_3);
                    PID_Count_3 = 0;
                    Board_1.TDown(3);
                    lblDebug.Text = "down-";
                }





                if (PID_Count_3 == proportion_3 && startPID_3 == true)
                {
                    Board_1.TNature(3);
                }

                if (startPID_3 == true)
                {
                    PID_Count_3++;

                }

                if (startPID_3 == true && PID_Count_3 == circle)
                {
                    double result_3 = PID_3.PIDCalcDirect(temperatureValue_3);
                    proportion_3 = Convert.ToInt32(result_3);
                    PID_Count_3 = 0;
                    if (result_3 > 0)
                    {
                        Board_1.TUp(3);
                    }
                    else
                    {
                        Board_1.TDown(3);
                    }

                    proportion_3 = PID_3.ConvertAccordToPropotation(proportion_3, circle, FirstProportion_3);


                }

                System.IO.File.AppendAllText("e:\\result_3.txt", temperatureValue_3.ToString("00.00") + "\r\n");
            }
        }

        private void timer_4_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            temperatureValue_4 = Board_1.getT(4);
            lblTValue_4.Text = temperatureValue_4.ToString("00.00");

            if (isTestByHand_4 == false)
            {
                digitalControlSingal_4 = Board_2.getSingal(4);
            }

            if (isExecuteControlModel_4 == true)
            {
                if (digitalControlSingal_4 == 1 && isFirstChangeUp_4 == true)
                {
                   
                    btnSimInput_4 = false;
                    lblTState_4.Text = "On";

                    isUp_4 = true;
                    isDown_4 = false;
                    isFirstChangeUp_4 = false;
                    isFirstChangeDown_4 = true;
                    isStartPID_4 = true;
                    PID_Count_4 = 0;

                    //isFirstPor = true;
                    Board_1.TUp(4);
                    startPID_4 = false;
                    circle = 10;
                    PID_4 = new PIDControl(3, 0.1, 0.5, punishmentT);
                    //  System.IO.File.AppendAllText("e:\\result_4.txt", "惩罚：" + "Kp:" + tbKp.Text + "  Ki" + tbKi.Text + "  Kd" + tbKd.Text + "\r\n");
                }
                else if (digitalControlSingal_4 == 0 && isFirstChangeDown_4 == true)
                {
                   
                    btnSimInput_4 = true;
                    isDown_4 = true;
                    isStartPID_4 = true;
                    isFirstChangeDown_4 = false;
                    isFirstChangeUp_4 = true;
                    startPID_4 = false;
                    isUp_4 = false;
                    PID_Count_4 = 0;
                    lblTState_4.Text = "Off";
                    Board_1.TDown(4);
                    circle = 10;
                    PID_4 = new PIDControl(7, 0.1, 0.5, confortableT);
                    //   System.IO.File.AppendAllText("e:\\result_4.txt", "舒适：" + "Kp:" + tbDownKp.Text + "  Ki" + tbDownKi.Text + "  Kd" + tbDownKd.Text + "\r\n");
                }
                else
                {
                    ;
                }
            }



            if (isUp_4 == true)
            {
                if ((punishmentT - temperatureValue_4) < 5 && isStartPID_4 == true)
                {
                    startPID_4 = true;
                    isStartPID_4 = false;

                    result_4 = PID_4.PIDCalcDirect(temperatureValue_4);
                    FirstProportion_4 = Convert.ToInt32(result_4);
                    proportion_4 = Convert.ToInt32(result_4);
                    proportion_4 = PID_4.ConvertAccordToPropotation(proportion_4, circle, FirstProportion_4);

                    PID_Count_4 = 0;
                    Board_1.TUp(4);
                    lblDebug.Text = "up-";

                }





                if (PID_Count_4 == proportion_4 && startPID_4 == true)
                {
                    Board_1.TNature(4);
                }


                if (startPID_4 == true)
                {
                    PID_Count_4++;

                }


                if (startPID_4 == true && PID_Count_4 == circle)
                {
                    result_4 = PID_4.PIDCalcDirect(temperatureValue_4);

                    proportion_4 = Convert.ToInt32(result_4);
                    PID_Count_4 = 0;



                    if (result_4 > 0)
                    {

                        Board_1.TUp(4);

                    }
                    else
                    {
                        Board_1.TDown(4);
                    }

                    proportion_4 = PID_4.ConvertAccordToPropotation(proportion_4, circle, FirstProportion_4);

                }

                System.IO.File.AppendAllText("e:\\result_4.txt", temperatureValue_4.ToString("00.00") + "\r\n");
            }


            if (isDown_4 == true)
            {
                if ((temperatureValue_4 - confortableT) < 5 && isStartPID_4 == true)
                {
                    startPID_4 = true;
                    isStartPID_4 = false;

                    result_4 = PID_4.PIDCalcDirect(temperatureValue_4);
                    FirstProportion_4 = Convert.ToInt32(result_4);
                    proportion_4 = Convert.ToInt32(result_4);
                    proportion_4 = PID_4.ConvertAccordToPropotation(proportion_4, circle, FirstProportion_4);
                    PID_Count_4 = 0;
                    Board_1.TDown(4);
                    lblDebug.Text = "down-";
                }





                if (PID_Count_4 == proportion_4 && startPID_4 == true)
                {
                    Board_1.TNature(4);
                }

                if (startPID_4 == true)
                {
                    PID_Count_4++;

                }

                if (startPID_4 == true && PID_Count_4 == circle)
                {
                    double result_4 = PID_4.PIDCalcDirect(temperatureValue_4);
                    proportion_4 = Convert.ToInt32(result_4);
                    PID_Count_4 = 0;
                    if (result_4 > 0)
                    {
                        Board_1.TUp(4);
                    }
                    else
                    {
                        Board_1.TDown(4);
                    }

                    proportion_4 = PID_4.ConvertAccordToPropotation(proportion_4, circle, FirstProportion_4);


                }

                System.IO.File.AppendAllText("e:\\result_4.txt", temperatureValue_4.ToString("00.00") + "\r\n");
            }
        }

        private void timer_5_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            temperatureValue_5 = Board_2.getT(5);
            lblTValue_5.Text = temperatureValue_5.ToString("00.00");

            if (isTestByHand_5 == false)
            {
                digitalControlSingal_5 = Board_2.getSingal(5);
            }

            if (isExecuteControlModel_5 == true)
            {
                if (digitalControlSingal_5 == 1 && isFirstChangeUp_5 == true)
                {
                   
                    btnSimInput_5 = false;
                    lblTState_5.Text = "On";

                    isUp_5 = true;
                    isDown_5 = false;

                    isStartPID_5 = true;
                    PID_Count_5 = 0;
                    isFirstChangeUp_5 = false;
                    isFirstChangeDown_5 = true;
                    //isFirstPor = true;
                    Board_1.TUp(5);
                    startPID_5 = false;
                    circle = 10;
                    PID_5 = new PIDControl(3, 0.1, 0.5, punishmentT);
                    //  System.IO.File.AppendAllText("e:\\result_5.txt", "惩罚：" + "Kp:" + tbKp.Text + "  Ki" + tbKi.Text + "  Kd" + tbKd.Text + "\r\n");
                }
                else if (digitalControlSingal_5 == 0 && isFirstChangeDown_5 == true)
                {
                   
                    btnSimInput_5 = true;
                    isDown_5 = true;
                    isStartPID_5 = true;
                    isFirstChangeDown_5 = false;
                    isFirstChangeUp_5 = true;
                    startPID_5 = false;
                    isUp_5 = false;
                    PID_Count_5 = 0;
                    lblTState_5.Text = "Off";
                    Board_1.TDown(5);
                    circle = 10;
                    PID_5 = new PIDControl(7, 0.1, 0.5, confortableT);
                    //   System.IO.File.AppendAllText("e:\\result_5.txt", "舒适：" + "Kp:" + tbDownKp.Text + "  Ki" + tbDownKi.Text + "  Kd" + tbDownKd.Text + "\r\n");
                }
                else
                {
                    ;
                }
            }



            if (isUp_5 == true)
            {
                if ((punishmentT - temperatureValue_5) < 5 && isStartPID_5 == true)
                {
                    startPID_5 = true;
                    isStartPID_5 = false;

                    result_5 = PID_5.PIDCalcDirect(temperatureValue_5);
                    FirstProportion_5 = Convert.ToInt32(result_5);
                    proportion_5 = Convert.ToInt32(result_5);
                    proportion_5 = PID_5.ConvertAccordToPropotation(proportion_5, circle, FirstProportion_5);

                    PID_Count_5 = 0;
                    Board_1.TUp(5);
                    lblDebug.Text = "up-";

                }





                if (PID_Count_5 == proportion_5 && startPID_5 == true)
                {
                    Board_1.TNature(5);
                }


                if (startPID_5 == true)
                {
                    PID_Count_5++;

                }


                if (startPID_5 == true && PID_Count_5 == circle)
                {
                    result_5 = PID_5.PIDCalcDirect(temperatureValue_5);

                    proportion_5 = Convert.ToInt32(result_5);
                    PID_Count_5 = 0;



                    if (result_5 > 0)
                    {

                        Board_1.TUp(5);

                    }
                    else
                    {
                        Board_1.TDown(5);
                    }

                    proportion_5 = PID_5.ConvertAccordToPropotation(proportion_5, circle, FirstProportion_5);

                }

                System.IO.File.AppendAllText("e:\\result_5.txt", temperatureValue_5.ToString("00.00") + "\r\n");
            }


            if (isDown_5 == true)
            {
                if ((temperatureValue_5 - confortableT) < 5 && isStartPID_5 == true)
                {
                    startPID_5 = true;
                    isStartPID_5 = false;

                    result_5 = PID_5.PIDCalcDirect(temperatureValue_5);
                    FirstProportion_5 = Convert.ToInt32(result_5);
                    proportion_5 = Convert.ToInt32(result_5);
                    proportion_5 = PID_5.ConvertAccordToPropotation(proportion_5, circle, FirstProportion_5);
                    PID_Count_5 = 0;
                    Board_1.TDown(5);
                    lblDebug.Text = "down-";
                }





                if (PID_Count_5 == proportion_5 && startPID_5 == true)
                {
                    Board_1.TNature(5);
                }

                if (startPID_5 == true)
                {
                    PID_Count_5++;

                }

                if (startPID_5 == true && PID_Count_5 == circle)
                {
                    double result_5 = PID_5.PIDCalcDirect(temperatureValue_5);
                    proportion_5 = Convert.ToInt32(result_5);
                    PID_Count_5 = 0;
                    if (result_5 > 0)
                    {
                        Board_1.TUp(5);
                    }
                    else
                    {
                        Board_1.TDown(5);
                    }

                    proportion_5 = PID_5.ConvertAccordToPropotation(proportion_5, circle, FirstProportion_5);


                }

                System.IO.File.AppendAllText("e:\\result_5.txt", temperatureValue_5.ToString("00.00") + "\r\n");
            }
        }

        private void timer_6_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            temperatureValue_6 = Board_2.getT(6);
            lblTValue_6.Text = temperatureValue_6.ToString("00.00");


            if (isTestByHand_6 == false)
            {
                digitalControlSingal_6 = Board_2.getSingal(6);
            }

            if (isExecuteControlModel_6 == true)
            {
                if (digitalControlSingal_6 == 1 && isFirstChangeUp_6 == true)
                {
                   
                    btnSimInput_6 = false;
                    lblTState_6.Text = "On";

                    isUp_6 = true;
                    isDown_6 = false;
                    isFirstChangeUp_6 = false;
                    isFirstChangeDown_6 = true;
                    isStartPID_6 = true;
                    PID_Count_6 = 0;

                    //isFirstPor = true;
                    Board_1.TUp(6);
                    startPID_6 = false;
                    circle = 10;
                    PID_6 = new PIDControl(3, 0.1, 0.5, punishmentT);
                    //  System.IO.File.AppendAllText("e:\\result_6.txt", "惩罚：" + "Kp:" + tbKp.Text + "  Ki" + tbKi.Text + "  Kd" + tbKd.Text + "\r\n");
                }
                else if (digitalControlSingal_6 == 0 && isFirstChangeDown_6 == true)
                {
                   
                    btnSimInput_6 = true;
                    isDown_6 = true;
                    isStartPID_6 = true;
                    isFirstChangeDown_6 = false;
                    isFirstChangeUp_6 = true;
                    startPID_6 = false;
                    isUp_6 = false;
                    PID_Count_6 = 0;
                    lblTState_6.Text = "Off";
                    Board_1.TDown(6);
                    circle = 10;
                    PID_6 = new PIDControl(7, 0.1, 0.5, confortableT);
                    //   System.IO.File.AppendAllText("e:\\result_6.txt", "舒适：" + "Kp:" + tbDownKp.Text + "  Ki" + tbDownKi.Text + "  Kd" + tbDownKd.Text + "\r\n");
                }
                else
                {
                    ;
                }
            }



            if (isUp_6 == true)
            {
                if ((punishmentT - temperatureValue_6) < 5 && isStartPID_6 == true)
                {
                    startPID_6 = true;
                    isStartPID_6 = false;

                    result_6 = PID_6.PIDCalcDirect(temperatureValue_6);
                    FirstProportion_6 = Convert.ToInt32(result_6);
                    proportion_6 = Convert.ToInt32(result_6);
                    proportion_6 = PID_6.ConvertAccordToPropotation(proportion_6, circle, FirstProportion_6);

                    PID_Count_6 = 0;
                    Board_1.TUp(6);
                    lblDebug.Text = "up-";

                }





                if (PID_Count_6 == proportion_6 && startPID_6 == true)
                {
                    Board_1.TNature(6);
                }


                if (startPID_6 == true)
                {
                    PID_Count_6++;

                }


                if (startPID_6 == true && PID_Count_6 == circle)
                {
                    result_6 = PID_6.PIDCalcDirect(temperatureValue_6);

                    proportion_6 = Convert.ToInt32(result_6);
                    PID_Count_6 = 0;



                    if (result_6 > 0)
                    {

                        Board_1.TUp(6);

                    }
                    else
                    {
                        Board_1.TDown(6);
                    }

                    proportion_6 = PID_6.ConvertAccordToPropotation(proportion_6, circle, FirstProportion_6);

                }

                System.IO.File.AppendAllText("e:\\result_6.txt", temperatureValue_6.ToString("00.00") + "\r\n");
            }


            if (isDown_6 == true)
            {
                if ((temperatureValue_6 - confortableT) < 5 && isStartPID_6 == true)
                {
                    startPID_6 = true;
                    isStartPID_6 = false;

                    result_6 = PID_6.PIDCalcDirect(temperatureValue_6);
                    FirstProportion_6 = Convert.ToInt32(result_6);
                    proportion_6 = Convert.ToInt32(result_6);
                    proportion_6 = PID_6.ConvertAccordToPropotation(proportion_6, circle, FirstProportion_6);
                    PID_Count_6 = 0;
                    Board_1.TDown(6);
                    lblDebug.Text = "down-";
                }





                if (PID_Count_6 == proportion_6 && startPID_6 == true)
                {
                    Board_1.TNature(6);
                }

                if (startPID_6 == true)
                {
                    PID_Count_6++;

                }

                if (startPID_6 == true && PID_Count_6 == circle)
                {
                    double result_6 = PID_6.PIDCalcDirect(temperatureValue_6);
                    proportion_6 = Convert.ToInt32(result_6);
                    PID_Count_6 = 0;
                    if (result_6 > 0)
                    {
                        Board_1.TUp(6);
                    }
                    else
                    {
                        Board_1.TDown(6);
                    }

                    proportion_6 = PID_6.ConvertAccordToPropotation(proportion_6, circle, FirstProportion_6);


                }

                System.IO.File.AppendAllText("e:\\result_6.txt", temperatureValue_6.ToString("00.00") + "\r\n");
            }
        }

        private void timer_7_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_7 = GC.getSingal(7);
            //lblTState_7.Text = digitalControlSingal_7 == 7 ? "On" : "OFF";

            temperatureValue_7 = Board_2.getT(7);
            lblTValue_7.Text = temperatureValue_7.ToString("00.00");

            if (isTestByHand_7 == false)
            {
                digitalControlSingal_7 = Board_2.getSingal(7);
            }


            if (isExecuteControlModel_7 == true)
            {
                if (digitalControlSingal_7 == 1 && isFirstChangeUp_7 == true)
                {
                   
                    btnSimInput_7 = false;
                    lblTState_7.Text = "On";

                    isUp_7 = true;
                    isDown_7 = false;
                    isFirstChangeUp_7 = false;
                    isFirstChangeDown_7 = true;
                    isStartPID_7 = true;
                    PID_Count_7 = 0;
                    isFirstChangeDown_7 = false;
                    isFirstChangeUp_7 = true;
                    //isFirstPor = true;
                    Board_1.TUp(7);
                    startPID_7 = false;
                    circle = 10;
                    PID_7 = new PIDControl(3, 0.1, 0.5, punishmentT);
                    //  System.IO.File.AppendAllText("e:\\result_7.txt", "惩罚：" + "Kp:" + tbKp.Text + "  Ki" + tbKi.Text + "  Kd" + tbKd.Text + "\r\n");
                }
                else if (digitalControlSingal_7 == 0 && isFirstChangeDown_7 == true)
                {
                   
                    btnSimInput_7 = true;
                    isDown_7 = true;
                    isStartPID_7 = true;

                    startPID_7 = false;
                    isUp_7 = false;
                    PID_Count_7 = 0;
                    lblTState_7.Text = "Off";
                    Board_1.TDown(7);
                    circle = 10;
                    PID_7 = new PIDControl(7, 0.1, 0.5, confortableT);
                    //   System.IO.File.AppendAllText("e:\\result_7.txt", "舒适：" + "Kp:" + tbDownKp.Text + "  Ki" + tbDownKi.Text + "  Kd" + tbDownKd.Text + "\r\n");
                }
                else
                {
                    ;
                }
            }

            if (isUp_7 == true)
            {
                if ((punishmentT - temperatureValue_7) < 5 && isStartPID_7 == true)
                {
                    startPID_7 = true;
                    isStartPID_7 = false;

                    result_7 = PID_7.PIDCalcDirect(temperatureValue_7);
                    FirstProportion_7 = Convert.ToInt32(result_7);
                    proportion_7 = Convert.ToInt32(result_7);
                    proportion_7 = PID_7.ConvertAccordToPropotation(proportion_7, circle, FirstProportion_7);

                    PID_Count_7 = 0;
                    Board_1.TUp(7);
                    lblDebug.Text = "up-";

                }





                if (PID_Count_7 == proportion_7 && startPID_7 == true)
                {
                    Board_1.TNature(7);
                }


                if (startPID_7 == true)
                {
                    PID_Count_7++;

                }


                if (startPID_7 == true && PID_Count_7 == circle)
                {
                    result_7 = PID_7.PIDCalcDirect(temperatureValue_7);

                    proportion_7 = Convert.ToInt32(result_7);
                    PID_Count_7 = 0;



                    if (result_7 > 0)
                    {

                        Board_1.TUp(7);

                    }
                    else
                    {
                        Board_1.TDown(7);
                    }

                    proportion_7 = PID_7.ConvertAccordToPropotation(proportion_7, circle, FirstProportion_7);

                }

                System.IO.File.AppendAllText("e:\\result_7.txt", temperatureValue_7.ToString("00.00") + "\r\n");
            }


            if (isDown_7 == true)
            {
                if ((temperatureValue_7 - confortableT) < 5 && isStartPID_7 == true)
                {
                    startPID_7 = true;
                    isStartPID_7 = false;

                    result_7 = PID_7.PIDCalcDirect(temperatureValue_7);
                    FirstProportion_7 = Convert.ToInt32(result_7);
                    proportion_7 = Convert.ToInt32(result_7);
                    proportion_7 = PID_7.ConvertAccordToPropotation(proportion_7, circle, FirstProportion_7);
                    PID_Count_7 = 0;
                    Board_1.TDown(7);
                    lblDebug.Text = "down-";
                }





                if (PID_Count_7 == proportion_7 && startPID_7 == true)
                {
                    Board_1.TNature(7);
                }

                if (startPID_7 == true)
                {
                    PID_Count_7++;

                }

                if (startPID_7 == true && PID_Count_7 == circle)
                {
                    double result_7 = PID_7.PIDCalcDirect(temperatureValue_7);
                    proportion_7 = Convert.ToInt32(result_7);
                    PID_Count_7 = 0;
                    if (result_7 > 0)
                    {
                        Board_1.TUp(7);
                    }
                    else
                    {
                        Board_1.TDown(7);
                    }

                    proportion_7 = PID_7.ConvertAccordToPropotation(proportion_7, circle, FirstProportion_7);


                }

                System.IO.File.AppendAllText("e:\\result_7.txt", temperatureValue_7.ToString("00.00") + "\r\n");
            }
        }

        private void timer_8_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            temperatureValue_8 = Board_2.getT(8);
            lblTValue_8.Text = temperatureValue_8.ToString("00.00");


            if (isTestByHand_8 == false)
            {
                digitalControlSingal_8 = Board_2.getSingal(8);
            }

            if (isExecuteControlModel_8 == true)
            {
                if (digitalControlSingal_8 == 1 && isFirstChangeUp_8 == true)
                {
                  
                    btnSimInput_8 = false;
                    lblTState_8.Text = "On";

                    isUp_8 = true;
                    isDown_8 = false;

                    isStartPID_8 = true;
                    PID_Count_8 = 0;
                    isFirstChangeUp_8 = false;
                    isFirstChangeDown_8 = true;
                    //isFirstPor = true;
                    Board_1.TUp(8);
                    startPID_8 = false;
                    circle = 10;
                    PID_8 = new PIDControl(3, 0.1, 0.5, punishmentT);
                    //  System.IO.File.AppendAllText("e:\\result_8.txt", "惩罚：" + "Kp:" + tbKp.Text + "  Ki" + tbKi.Text + "  Kd" + tbKd.Text + "\r\n");
                }
                else if (digitalControlSingal_8 == 0 && isFirstChangeDown_8 == true)
                {
                   
                    btnSimInput_8 = true;
                    isDown_8 = true;
                    isStartPID_8 = true;
                    isFirstChangeDown_8 = false;
                    isFirstChangeUp_8 = true;
                    startPID_8 = false;
                    isUp_8 = false;
                    PID_Count_8 = 0;
                    lblTState_8.Text = "Off";
                    Board_1.TDown(8);
                    circle = 10;
                    PID_8 = new PIDControl(7, 0.1, 0.5, confortableT);
                    //   System.IO.File.AppendAllText("e:\\result_8.txt", "舒适：" + "Kp:" + tbDownKp.Text + "  Ki" + tbDownKi.Text + "  Kd" + tbDownKd.Text + "\r\n");
                }
                else
                {
                    ;
                }
            }



            if (isUp_8 == true)
            {
                if ((punishmentT - temperatureValue_8) < 5 && isStartPID_8 == true)
                {
                    startPID_8 = true;
                    isStartPID_8 = false;

                    result_8 = PID_8.PIDCalcDirect(temperatureValue_8);
                    FirstProportion_8 = Convert.ToInt32(result_8);
                    proportion_8 = Convert.ToInt32(result_8);
                    proportion_8 = PID_8.ConvertAccordToPropotation(proportion_8, circle, FirstProportion_8);

                    PID_Count_8 = 0;
                    Board_1.TUp(8);
                    lblDebug.Text = "up-";

                }





                if (PID_Count_8 == proportion_8 && startPID_8 == true)
                {
                    Board_1.TNature(8);
                }


                if (startPID_8 == true)
                {
                    PID_Count_8++;

                }


                if (startPID_8 == true && PID_Count_8 == circle)
                {
                    result_8 = PID_8.PIDCalcDirect(temperatureValue_8);

                    proportion_8 = Convert.ToInt32(result_8);
                    PID_Count_8 = 0;



                    if (result_8 > 0)
                    {

                        Board_1.TUp(8);

                    }
                    else
                    {
                        Board_1.TDown(8);
                    }

                    proportion_8 = PID_8.ConvertAccordToPropotation(proportion_8, circle, FirstProportion_8);

                }

                System.IO.File.AppendAllText("e:\\result_8.txt", temperatureValue_8.ToString("00.00") + "\r\n");
            }


            if (isDown_8 == true)
            {
                if ((temperatureValue_8 - confortableT) < 5 && isStartPID_8 == true)
                {
                    startPID_8 = true;
                    isStartPID_8 = false;

                    result_8 = PID_8.PIDCalcDirect(temperatureValue_8);
                    FirstProportion_8 = Convert.ToInt32(result_8);
                    proportion_8 = Convert.ToInt32(result_8);
                    proportion_8 = PID_8.ConvertAccordToPropotation(proportion_8, circle, FirstProportion_8);
                    PID_Count_8 = 0;
                    Board_1.TDown(8);
                    lblDebug.Text = "down-";
                }





                if (PID_Count_8 == proportion_8 && startPID_8 == true)
                {
                    Board_1.TNature(8);
                }

                if (startPID_8 == true)
                {
                    PID_Count_8++;

                }

                if (startPID_8 == true && PID_Count_8 == circle)
                {
                    double result_8 = PID_8.PIDCalcDirect(temperatureValue_8);
                    proportion_8 = Convert.ToInt32(result_8);
                    PID_Count_8 = 0;
                    if (result_8 > 0)
                    {
                        Board_1.TUp(8);
                    }
                    else
                    {
                        Board_1.TDown(8);
                    }

                    proportion_8 = PID_8.ConvertAccordToPropotation(proportion_8, circle, FirstProportion_8);


                }

                System.IO.File.AppendAllText("e:\\result_8.txt", temperatureValue_8.ToString("00.00") + "\r\n");
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            Board_1.clearALL();
            timer_1.Stop();
            timer_2.Stop();
            timer_3.Stop();
            timer_4.Stop();
            timer_5.Stop();
            timer_6.Stop();
            timer_7.Stop();
            timer_8.Stop();
        }
    }
}
