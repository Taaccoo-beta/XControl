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
using System.Diagnostics;
using SerieslizeControlModule;


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




        double p1_1;
        double p2_1;
        double p1_2;
        double p2_2;
        double p1_3;
        double p2_3;
        double p1_4;
        double p2_4;
        double p1_5;
        double p2_5;
        double p1_6;
        double p2_6;
        double p1_7;
        double p2_7;
        double p1_8;
        double p2_8;

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
         * menu of test by hand 
         * checked or unchecked
         * and many turn of control variable
         */
        bool isMenuByHandChecked = false;
        bool isTotalStartBtnTrue = true;


        /*
         *  setting button turn off switch
         */
        bool isSettingTParam = true;
        bool isSettingPIDParam = true;

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

        bool isUp_1 = false ;
        bool isUp_2 = false;
        bool isUp_3 = false ;
        bool isUp_4 = false;
        bool isUp_5 = false;
        bool isUp_6 = false;
        bool isUp_7 = false;
        bool isUp_8 = false;

        bool isDown_1 = false;
        bool isDown_2 = false;
        bool isDown_3 = false;
        bool isDown_4 = false;
        bool isDown_5 = false;
        bool isDown_6 = false;
        bool isDown_7 = false;
        bool isDown_8 = false;

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

        /*
         * PID start button on/off control vairable
         */
        bool isPIDBtnStart_1 = true;
        bool isPIDBtnStart_2 = true;
        bool isPIDBtnStart_3 = true;
        bool isPIDBtnStart_4 = true;
        bool isPIDBtnStart_5 = true;
        bool isPIDBtnStart_6 = true;
        bool isPIDBtnStart_7 = true;
        bool isPIDBtnStart_8 = true;

        bool isPIDBtnStartDown_1 = true;
        bool isPIDBtnStartDown_2 = true;
        bool isPIDBtnStartDown_3 = true;
        bool isPIDBtnStartDown_4 = true;
        bool isPIDBtnStartDown_5 = true;
        bool isPIDBtnStartDown_6= true;
        bool isPIDBtnStartDown_7 = true;
        bool isPIDBtnStartDown_8 = true;




        /*
         * if the is tested by hand
         */
        bool isTestByHand_1 = true;
        bool isTestByHand_2 = true;
        bool isTestByHand_3 = true;
        bool isTestByHand_4 = true;
        bool isTestByHand_5 = true;
        bool isTestByHand_6 = true;
        bool isTestByHand_7 = true;
        bool isTestByHand_8 = true;

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



        /*
         * 
         * PID paramter test program
         *
         */

         //if start PID model
         
        bool isExecutePIDModel_1 = false;
        bool isExecutePIDModel_2 = false;
        bool isExecutePIDModel_3 = false;
        bool isExecutePIDModel_4 = false;
        bool isExecutePIDModel_5 = false;
        bool isExecutePIDModel_6 = false;
        bool isExecutePIDModel_7 = false;
        bool isExecutePIDModel_8 = false;

        bool isExecutePIDModelDown_1 = false;
        bool isExecutePIDModelDown_2 = false;
        bool isExecutePIDModelDown_3 = false;
        bool isExecutePIDModelDown_4 = false;
        bool isExecutePIDModelDown_5 = false;
        bool isExecutePIDModelDown_6 = false;
        bool isExecutePIDModelDown_7 = false;
        bool isExecutePIDModelDown_8 = false;

        int timerCount_1 = 0;
        int timerCount_2 = 0;
        int timerCount_3 = 0;
        int timerCount_4 = 0;
        int timerCount_5 = 0;
        int timerCount_6 = 0;
        int timerCount_7 = 0;
        int timerCount_8 = 0;

        int timeResult_1 = 0;
        int timeResult_2 = 0;
        int timeResult_3 = 0;
        int timeResult_4 = 0;
        int timeResult_5 = 0;
        int timeResult_6 = 0;
        int timeResult_7 = 0;
        int timeResult_8 = 0;


        bool highBalance_1 = false;
        bool highBalance_2 = false;
        bool highBalance_3 = false;
        bool highBalance_4 = false;
        bool highBalance_5 = false;
        bool highBalance_6 = false;
        bool highBalance_7 = false;
        bool highBalance_8 = false;

        bool lowBalance_1 = false;
        bool lowBalance_2 = false;
        bool lowBalance_3 = false;
        bool lowBalance_4 = false;
        bool lowBalance_5 = false;
        bool lowBalance_6 = false;
        bool lowBalance_7 = false;
        bool lowBalance_8 = false;

        bool downLine_1 = false;
        bool downLine_2 = false;
        bool downLine_3 = false;
        bool downLine_4 = false;
        bool downLine_5 = false;
        bool downLine_6 = false;
        bool downLine_7 = false;
        bool downLine_8 = false;

        bool upLine_1 = false;
        bool upLine_2 = false;
        bool upLine_3 = false;
        bool upLine_4 = false;
        bool upLine_5 = false;
        bool upLine_6 = false;
        bool upLine_7 = false;
        bool upLine_8 = false;

        bool isChangeParam_1 = false;
        bool isChangeParam_2 = false;
        bool isChangeParam_3 = false;
        bool isChangeParam_4 = false;
        bool isChangeParam_5 = false;
        bool isChangeParam_6 = false;
        bool isChangeParam_7 = false;
        bool isChangeParam_8 = false;

        bool timeNotAccept_1 = false;
        bool timeNotAccept_2 = false;
        bool timeNotAccept_3 = false;
        bool timeNotAccept_4 = false;
        bool timeNotAccept_5 = false;
        bool timeNotAccept_6 = false;
        bool timeNotAccept_7 = false;
        bool timeNotAccept_8 = false;

        int beyondNum_1 = 0;
        int beyondNum_2 = 0;
        int beyondNum_3 = 0;
        int beyondNum_4 = 0;
        int beyondNum_5 = 0;
        int beyondNum_6 = 0;
        int beyondNum_7 = 0;
        int beyondNum_8 = 0;

        bool longKeep_1 = false;
        bool longKeep_2 = false;
        bool longKeep_3 = false;
        bool longKeep_4 = false;
        bool longKeep_5 = false;
        bool longKeep_6 = false;
        bool longKeep_7 = false;
        bool longKeep_8 = false;


        //PID using to search a better PID
        double P_1 = 0.5, I_1 = 0.1, D_1 = 0.5;
        double P_2 = 0.5, I_2 = 0.1, D_2 = 0.5;
        double P_3 = 0.5, I_3 = 0.1, D_3 = 0.5;
        double P_4 = 0.5, I_4 = 0, D_4 = 0.5;
        double P_5 = 0.5, I_5 = 0.1, D_5 = 0.5;
        double P_6 = 0.5, I_6 = 0, D_6 = 0.5;
        double P_7 = 0.5, I_7 = 0, D_7 = 0.5;
        double P_8 = 0.5, I_8 = 0.1, D_8 = 0.5;


        //PID in temperature control module
        double Kp_up_1,Ki_up_1,Kd_up_1;
        double Kp_up_2, Ki_up_2, Kd_up_2;
        double Kp_up_3, Ki_up_3, Kd_up_3;
        double Kp_up_4, Ki_up_4, Kd_up_4;
        double Kp_up_5, Ki_up_5, Kd_up_5;
        double Kp_up_6, Ki_up_6, Kd_up_6;
        double Kp_up_7, Ki_up_7, Kd_up_7;
        double Kp_up_8, Ki_up_8, Kd_up_8;

        double Kp_down_1, Ki_down_1, Kd_down_1;
        double Kp_down_2, Ki_down_2, Kd_down_2;
        double Kp_down_3, Ki_down_3, Kd_down_3;
        double Kp_down_4, Ki_down_4, Kd_down_4;
        double Kp_down_5, Ki_down_5, Kd_down_5;
        double Kp_down_6, Ki_down_6, Kd_down_6;
        double Kp_down_7, Ki_down_7, Kd_down_7;
        double Kp_down_8, Ki_down_8, Kd_down_8;



        List<double> tempCollection_1 = new List<double>();
        List<double> tempCollection_2 = new List<double>();
        List<double> tempCollection_3 = new List<double>();
        List<double> tempCollection_4 = new List<double>();
        List<double> tempCollection_5 = new List<double>();
        List<double> tempCollection_6 = new List<double>();

        private void btnTparameterSet_Click(object sender, EventArgs e)
        {

            if (isSettingTParam)
            {
                isSettingTParam = false;
                btnTparameterSet.Text = "Finish";
                tbP1_1.Enabled = true;
                tbP2_1.Enabled = true;
                tbP1_2.Enabled = true;
                tbP2_2.Enabled = true;
                tbP1_3.Enabled = true;
                tbP2_3.Enabled = true;
                tbP1_4.Enabled = true;
                tbP2_4.Enabled = true;
                tbP1_5.Enabled = true;
                tbP2_5.Enabled = true;
                tbP1_6.Enabled = true;
                tbP2_6.Enabled = true;
                tbP1_7.Enabled = true;
                tbP2_7.Enabled = true;
                tbP1_8.Enabled = true;
                tbP2_8.Enabled = true;
            }
            else
            {
                isSettingTParam = true;
                btnTparameterSet.Text = "Set";
                tbP1_1.Enabled = false;
                tbP2_1.Enabled = false;
                tbP1_2.Enabled = false;
                tbP2_2.Enabled = false;
                tbP1_3.Enabled = false;
                tbP2_3.Enabled = false;
                tbP1_4.Enabled = false;
                tbP2_4.Enabled = false;
                tbP1_5.Enabled = false;
                tbP2_5.Enabled = false;
                tbP1_6.Enabled = false;
                tbP2_6.Enabled = false;
                tbP1_7.Enabled = false;
                tbP2_7.Enabled = false;
                tbP1_8.Enabled = false;
                tbP2_8.Enabled = false;

                CoreSerialize cs = new CoreSerialize();

                TParameters tp = new TParameters()
                {
                    p1_1 = double.Parse(tbP1_1.Text),
                    p1_2 = double.Parse(tbP1_2.Text),
                    p1_3 = double.Parse(tbP1_3.Text),
                    p1_4 = double.Parse(tbP1_4.Text),
                    p1_5 = double.Parse(tbP1_5.Text),
                    p1_6 = double.Parse(tbP1_6.Text),
                    p1_7 = double.Parse(tbP1_7.Text),
                    p1_8 = double.Parse(tbP1_8.Text),

                    p2_1 = double.Parse(tbP2_1.Text),
                    p2_2 = double.Parse(tbP2_2.Text),
                    p2_3 = double.Parse(tbP2_3.Text),
                    p2_4 = double.Parse(tbP2_4.Text),
                    p2_5 = double.Parse(tbP2_5.Text),
                    p2_6 = double.Parse(tbP2_6.Text),
                    p2_7 = double.Parse(tbP2_7.Text),
                    p2_8 = double.Parse(tbP2_8.Text)



                };
                cs.TParammSerializeNow(tp);

                p1_1 = double.Parse(tbP1_1.Text);
                p1_2 = double.Parse(tbP1_2.Text);
                p1_3 = double.Parse(tbP1_3.Text);
                p1_4 = double.Parse(tbP1_4.Text);
                p1_5 = double.Parse(tbP1_5.Text);
                p1_6 = double.Parse(tbP1_6.Text);
                p1_7 = double.Parse(tbP1_7.Text);
                p1_8 = double.Parse(tbP1_8.Text);

                p2_1 = double.Parse(tbP2_1.Text);
                p2_2 = double.Parse(tbP2_2.Text);
                p2_3 = double.Parse(tbP2_3.Text);
                p2_4 = double.Parse(tbP2_4.Text);
                p2_5 = double.Parse(tbP2_5.Text);
                p2_6 = double.Parse(tbP2_6.Text);
                p2_7 = double.Parse(tbP2_7.Text);
                p2_8 = double.Parse(tbP2_8.Text);

            }





        
        }

        private void btnSetPIDParam_Click(object sender, EventArgs e)
        {
            if (isSettingPIDParam)
            {
                isSettingPIDParam = false;
                btnSetPIDParam.Text = "Finish";

                tbPIDValuePUp_1.Enabled = true;
                tbPIDValueIUp_1.Enabled = true;
                tbPIDValueDUp_1.Enabled = true;
                tbPIDValuePUp_2.Enabled = true;
                tbPIDValueIUp_2.Enabled = true;
                tbPIDValueDUp_2.Enabled = true;
                tbPIDValuePUp_3.Enabled = true;
                tbPIDValueIUp_3.Enabled = true;
                tbPIDValueDUp_3.Enabled = true;
                tbPIDValuePUp_4.Enabled = true;
                tbPIDValueIUp_4.Enabled = true;
                tbPIDValueDUp_4.Enabled = true;
                tbPIDValuePUp_5.Enabled = true;
                tbPIDValueIUp_5.Enabled = true;
                tbPIDValueDUp_5.Enabled = true;
                tbPIDValuePUp_6.Enabled = true;
                tbPIDValueIUp_6.Enabled = true;
                tbPIDValueDUp_6.Enabled = true;
                tbPIDValuePUp_7.Enabled = true;
                tbPIDValueIUp_7.Enabled = true;
                tbPIDValueDUp_7.Enabled = true;
                tbPIDValuePUp_8.Enabled = true;
                tbPIDValueIUp_8.Enabled = true;
                tbPIDValueDUp_8.Enabled = true;

                tbPIDValuePDown_1.Enabled = true;
                tbPIDValueIDown_1.Enabled = true;
                tbPIDValueDDown_1.Enabled = true;
                tbPIDValuePDown_2.Enabled = true;
                tbPIDValueIDown_2.Enabled = true;
                tbPIDValueDDown_2.Enabled = true;
                tbPIDValuePDown_3.Enabled = true;
                tbPIDValueIDown_3.Enabled = true;
                tbPIDValueDDown_3.Enabled = true;
                tbPIDValuePDown_4.Enabled = true;
                tbPIDValueIDown_4.Enabled = true;
                tbPIDValueDDown_4.Enabled = true;
                tbPIDValuePDown_5.Enabled = true;
                tbPIDValueIDown_5.Enabled = true;
                tbPIDValueDDown_5.Enabled = true;
                tbPIDValuePDown_6.Enabled = true;
                tbPIDValueIDown_6.Enabled = true;
                tbPIDValueDDown_6.Enabled = true;
                tbPIDValuePDown_7.Enabled = true;
                tbPIDValueIDown_7.Enabled = true;
                tbPIDValueDDown_7.Enabled = true;
                tbPIDValuePDown_8.Enabled = true;
                tbPIDValueIDown_8.Enabled = true;
                tbPIDValueDDown_8.Enabled = true;



            }
            else
            {
                isSettingPIDParam = true;
                btnSetPIDParam.Text = "Set";

                tbPIDValuePUp_1.Enabled = false;
                tbPIDValueIUp_1.Enabled = false;
                tbPIDValueDUp_1.Enabled = false;
                tbPIDValuePUp_2.Enabled = false;
                tbPIDValueIUp_2.Enabled = false;
                tbPIDValueDUp_2.Enabled = false;
                tbPIDValuePUp_3.Enabled = false;
                tbPIDValueIUp_3.Enabled = false;
                tbPIDValueDUp_3.Enabled = false;
                tbPIDValuePUp_4.Enabled = false;
                tbPIDValueIUp_4.Enabled = false;
                tbPIDValueDUp_4.Enabled = false;
                tbPIDValuePUp_5.Enabled = false;
                tbPIDValueIUp_5.Enabled = false;
                tbPIDValueDUp_5.Enabled = false;
                tbPIDValuePUp_6.Enabled = false;
                tbPIDValueIUp_6.Enabled = false;
                tbPIDValueDUp_6.Enabled = false;
                tbPIDValuePUp_7.Enabled = false;
                tbPIDValueIUp_7.Enabled = false;
                tbPIDValueDUp_7.Enabled = false;
                tbPIDValuePUp_8.Enabled = false;
                tbPIDValueIUp_8.Enabled = false;
                tbPIDValueDUp_8.Enabled = false;

                tbPIDValuePDown_1.Enabled = false;
                tbPIDValueIDown_1.Enabled = false;
                tbPIDValueDDown_1.Enabled = false;
                tbPIDValuePDown_2.Enabled = false;
                tbPIDValueIDown_2.Enabled = false;
                tbPIDValueDDown_2.Enabled = false;
                tbPIDValuePDown_3.Enabled = false;
                tbPIDValueIDown_3.Enabled = false;
                tbPIDValueDDown_3.Enabled = false;
                tbPIDValuePDown_4.Enabled = false;
                tbPIDValueIDown_4.Enabled = false;
                tbPIDValueDDown_4.Enabled = false;
                tbPIDValuePDown_5.Enabled = false;
                tbPIDValueIDown_5.Enabled = false;
                tbPIDValueDDown_5.Enabled = false;
                tbPIDValuePDown_6.Enabled = false;
                tbPIDValueIDown_6.Enabled = false;
                tbPIDValueDDown_6.Enabled = false;
                tbPIDValuePDown_7.Enabled = false;
                tbPIDValueIDown_7.Enabled = false;
                tbPIDValueDDown_7.Enabled = false;
                tbPIDValuePDown_8.Enabled = false;
                tbPIDValueIDown_8.Enabled = false;
                tbPIDValueDDown_8.Enabled = false;


                CoreSerialize cs = new CoreSerialize();

                PIDParameters pp = new PIDParameters()
                {
                    kp_up_1 = double.Parse(tbPIDValuePUp_1.Text),
                    ki_up_1 = double.Parse(tbPIDValueIUp_1.Text),
                    kd_up_1 = double.Parse(tbPIDValueDUp_1.Text),
                    kp_up_2 = double.Parse(tbPIDValuePUp_2.Text),
                    ki_up_2 = double.Parse(tbPIDValueIUp_2.Text),
                    kd_up_2 = double.Parse(tbPIDValueDUp_2.Text),
                    kp_up_3 = double.Parse(tbPIDValuePUp_3.Text),
                    ki_up_3 = double.Parse(tbPIDValueIUp_3.Text),
                    kd_up_3 = double.Parse(tbPIDValueDUp_3.Text),
                    kp_up_4 = double.Parse(tbPIDValuePUp_4.Text),
                    ki_up_4 = double.Parse(tbPIDValueIUp_4.Text),
                    kd_up_4 = double.Parse(tbPIDValueDUp_4.Text),
                    kp_up_5 = double.Parse(tbPIDValuePUp_5.Text),
                    ki_up_5 = double.Parse(tbPIDValueIUp_5.Text),
                    kd_up_5 = double.Parse(tbPIDValueDUp_5.Text),
                    kp_up_6 = double.Parse(tbPIDValuePUp_6.Text),
                    ki_up_6 = double.Parse(tbPIDValueIUp_6.Text),
                    kd_up_6 = double.Parse(tbPIDValueDUp_6.Text),
                    kp_up_7 = double.Parse(tbPIDValuePUp_7.Text),
                    ki_up_7 = double.Parse(tbPIDValueIUp_7.Text),
                    kd_up_7 = double.Parse(tbPIDValueDUp_7.Text),
                    kp_up_8 = double.Parse(tbPIDValuePUp_8.Text),
                    ki_up_8 = double.Parse(tbPIDValueIUp_8.Text),
                    kd_up_8 = double.Parse(tbPIDValueDUp_8.Text),

                    kp_down_1 = double.Parse(tbPIDValuePDown_1.Text),
                    ki_down_1 = double.Parse(tbPIDValueIDown_1.Text),
                    kd_down_1 = double.Parse(tbPIDValueDDown_1.Text),
                    kp_down_2 = double.Parse(tbPIDValuePDown_2.Text),
                    ki_down_2 = double.Parse(tbPIDValueIDown_2.Text),
                    kd_down_2 = double.Parse(tbPIDValueDDown_2.Text),
                    kp_down_3 = double.Parse(tbPIDValuePDown_3.Text),
                    ki_down_3 = double.Parse(tbPIDValueIDown_3.Text),
                    kd_down_3 = double.Parse(tbPIDValueDDown_3.Text),
                    kp_down_4 = double.Parse(tbPIDValuePDown_4.Text),
                    ki_down_4 = double.Parse(tbPIDValueIDown_4.Text),
                    kd_down_4 = double.Parse(tbPIDValueDDown_4.Text),
                    kp_down_5 = double.Parse(tbPIDValuePDown_5.Text),
                    ki_down_5 = double.Parse(tbPIDValueIDown_5.Text),
                    kd_down_5 = double.Parse(tbPIDValueDDown_5.Text),
                    kp_down_6 = double.Parse(tbPIDValuePDown_6.Text),
                    ki_down_6 = double.Parse(tbPIDValueIDown_6.Text),
                    kd_down_6 = double.Parse(tbPIDValueDDown_6.Text),
                    kp_down_7 = double.Parse(tbPIDValuePDown_7.Text),
                    ki_down_7 = double.Parse(tbPIDValueIDown_7.Text),
                    kd_down_7 = double.Parse(tbPIDValueDDown_7.Text),
                    kp_down_8 = double.Parse(tbPIDValuePDown_8.Text),
                    ki_down_8 = double.Parse(tbPIDValueIDown_8.Text),
                    kd_down_8 = double.Parse(tbPIDValueDDown_8.Text),

                };


                cs.PIDSerializeNow(pp);






                Kp_up_1 = double.Parse(tbPIDValuePUp_1.Text);
                Kp_up_2 = double.Parse(tbPIDValuePUp_2.Text);
                Kp_up_3 = double.Parse(tbPIDValuePUp_3.Text);
                Kp_up_4 = double.Parse(tbPIDValuePUp_4.Text);
                Kp_up_5 = double.Parse(tbPIDValuePUp_5.Text);
                Kp_up_6 = double.Parse(tbPIDValuePUp_6.Text);
                Kp_up_7 = double.Parse(tbPIDValuePUp_7.Text);
                Kp_up_8 = double.Parse(tbPIDValuePUp_8.Text);

                Ki_up_1 = double.Parse(tbPIDValueIUp_1.Text);
                Ki_up_2 = double.Parse(tbPIDValueIUp_2.Text);
                Ki_up_3 = double.Parse(tbPIDValueIUp_3.Text);
                Ki_up_4 = double.Parse(tbPIDValueIUp_4.Text);
                Ki_up_5 = double.Parse(tbPIDValueIUp_5.Text);
                Ki_up_6 = double.Parse(tbPIDValueIUp_6.Text);
                Ki_up_7 = double.Parse(tbPIDValueIUp_7.Text);
                Ki_up_8 = double.Parse(tbPIDValueIUp_8.Text);

                Kd_up_1 = double.Parse(tbPIDValueDUp_1.Text);
                Kd_up_2 = double.Parse(tbPIDValueDUp_2.Text);
                Kd_up_3 = double.Parse(tbPIDValueDUp_3.Text);
                Kd_up_4 = double.Parse(tbPIDValueDUp_4.Text);
                Kd_up_5 = double.Parse(tbPIDValueDUp_5.Text);
                Kd_up_6 = double.Parse(tbPIDValueDUp_6.Text);
                Kd_up_7 = double.Parse(tbPIDValueDUp_7.Text);
                Kd_up_8 = double.Parse(tbPIDValueDUp_8.Text);




                Kp_down_1 = double.Parse(tbPIDValuePDown_1.Text);
                Kp_down_2 = double.Parse(tbPIDValuePDown_2.Text);
                Kp_down_3 = double.Parse(tbPIDValuePDown_3.Text);
                Kp_down_4 = double.Parse(tbPIDValuePDown_4.Text);
                Kp_down_5 = double.Parse(tbPIDValuePDown_5.Text);
                Kp_down_6 = double.Parse(tbPIDValuePDown_6.Text);
                Kp_down_7 = double.Parse(tbPIDValuePDown_7.Text);
                Kp_down_8 = double.Parse(tbPIDValuePDown_8.Text);

                Ki_down_1 = double.Parse(tbPIDValueIDown_1.Text);
                Ki_down_2 = double.Parse(tbPIDValueIDown_2.Text);
                Ki_down_3 = double.Parse(tbPIDValueIDown_3.Text);
                Ki_down_4 = double.Parse(tbPIDValueIDown_4.Text);
                Ki_down_5 = double.Parse(tbPIDValueIDown_5.Text);
                Ki_down_6 = double.Parse(tbPIDValueIDown_6.Text);
                Ki_down_7 = double.Parse(tbPIDValueIDown_7.Text);
                Ki_down_8 = double.Parse(tbPIDValueIDown_8.Text);

                Kd_down_1 = double.Parse(tbPIDValueDDown_1.Text);
                Kd_down_2 = double.Parse(tbPIDValueDDown_2.Text);
                Kd_down_3 = double.Parse(tbPIDValueDDown_3.Text);
                Kd_down_4 = double.Parse(tbPIDValueDDown_4.Text);
                Kd_down_5 = double.Parse(tbPIDValueDDown_5.Text);
                Kd_down_6 = double.Parse(tbPIDValueDDown_6.Text);
                Kd_down_7 = double.Parse(tbPIDValueDDown_7.Text);
                Kd_down_8 = double.Parse(tbPIDValueDDown_8.Text);




            }
        }

        private void tP_Main_Click(object sender, EventArgs e)
        {

        }

        List<double> tempCollection_7 = new List<double>();
        List<double> tempCollection_8 = new List<double>();

        
        private void resultAnalyse(List<double> list,double P,double I,double D,out string Result,int groupNum)
        {
           
            double MaxList = list.Max();
            double MinList = list.Min();
            double SumList = list.Sum();
            
            double average = list.Average();

            double descret = 0;
            foreach (double i in list)
            {
                descret += Math.Pow((i - average), 2);
            }

            descret = Math.Sqrt(descret);

            switch (groupNum)
            {
                case 1:
                    System.IO.File.AppendAllText("e:\\resultPID_1.txt", P + "   " + I + "   " + D + "   " + MaxList + "   " +
                MinList + "   " + average + "   " + descret + "   " +timeResult_1 +"\r\n");
                    break;
                case 2:
                    System.IO.File.AppendAllText("e:\\resultPID_2.txt", P + "   " + I + "   " + D + "   " + MaxList + "   " +
                MinList + "   " + average + "   " + descret + "   " + timeResult_2 + "\r\n");
                    break;
                case 3:
                    System.IO.File.AppendAllText("e:\\resultPID_3.txt", P + "   " + I + "   " + D + "   " + MaxList + "   " +
                MinList + "   " + average + "   " + descret + "   " + timeResult_3 + "\r\n");
                    break;
                case 4:
                    System.IO.File.AppendAllText("e:\\resultPID_4.txt", P + "   " + I + "   " + D + "   " + MaxList + "   " +
                MinList + "   " + average + "   " + descret + "   " + timeResult_4 + "\r\n");
                    break;
                case 5:
                    System.IO.File.AppendAllText("e:\\resultPID_5.txt", P + "   " + I + "   " + D + "   " + MaxList + "   " +
                MinList + "   " + average + "   " + descret + "   " + timeResult_5 + "\r\n");
                    break;
                case 6:
                    System.IO.File.AppendAllText("e:\\resultPID_6.txt", P + "   " + I + "   " + D + "   " + MaxList + "   " +
                MinList + "   " + average + "   " + descret + "   " + timeResult_6 + "\r\n");
                    break;
                case 7:
                    System.IO.File.AppendAllText("e:\\resultPID_7.txt", P + "   " + I + "   " + D + "   " + MaxList + "   " +
                MinList + "   " + average + "   " + descret + "   " + timeResult_7 + "\r\n");
                    break;
                case 8:
                    System.IO.File.AppendAllText("e:\\resultPID_8.txt", P + "   " + I + "   " + D + "   " + MaxList + "   " +
                MinList + "   " + average + "   " + descret + "   " + timeResult_8 + "\r\n");
                    break;

            }
           
            Result = string.Format("P:{0},I:{1},D:{2},正常输出", P, I, D);
        }




        public MainForm()
        {
            InitializeComponent();
        }






        private void MainForm_Load(object sender, EventArgs e)
        {
                //board_1 use to output
            Board_1 = new GroupControl(0,false);
            Board_1.clearALL();
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

            


            isFirstChangeUp_1 = true;
            isFirstChangeUp_2 = true;
            isFirstChangeUp_3 = true;
            isFirstChangeUp_4 = true;
            isFirstChangeUp_5 = true;
            isFirstChangeUp_6 = true;
            isFirstChangeUp_7 = true;
            isFirstChangeUp_8 = true;
            isFirstChangeDown_1 = true;
            isFirstChangeDown_2 = true;
            isFirstChangeDown_3 = true;
            isFirstChangeDown_4 = true;
            isFirstChangeDown_5 = true;
            isFirstChangeDown_6 = true;
            isFirstChangeDown_7 = true;
            isFirstChangeDown_8 = true;

            

          

            isTestByHandClick_1 = true;
            isTestByHandClick_2 = true;
            isTestByHandClick_3 = true;
            isTestByHandClick_4 = true;
            isTestByHandClick_5 = true;
            isTestByHandClick_6 = true;
            isTestByHandClick_7 = true;
            isTestByHandClick_8 = true;


            

            //p1_1 = double.Parse(tbP1_1.Text);
            //p1_2 = double.Parse(tbP1_2.Text);
            //p1_3 = double.Parse(tbP1_3.Text);
            //p1_4 = double.Parse(tbP1_4.Text);
            //p1_5 = double.Parse(tbP1_5.Text);
            //p1_6 = double.Parse(tbP1_6.Text);
            //p1_7 = double.Parse(tbP1_7.Text);
            //p1_8 = double.Parse(tbP1_8.Text);

            //p2_1 = double.Parse(tbP2_1.Text);
            //p2_2 = double.Parse(tbP2_2.Text);
            //p2_3 = double.Parse(tbP2_3.Text);
            //p2_4 = double.Parse(tbP2_4.Text);
            //p2_5 = double.Parse(tbP2_5.Text);
            //p2_6 = double.Parse(tbP2_6.Text);
            //p2_7 = double.Parse(tbP2_7.Text);
            //p2_8 = double.Parse(tbP2_8.Text);
          

            //Kp_up_1 = double.Parse(tbPIDValuePUp_1.Text);
            //Kp_up_2 = double.Parse(tbPIDValuePUp_2.Text);
            //Kp_up_3 = double.Parse(tbPIDValuePUp_3.Text);
            //Kp_up_4 = double.Parse(tbPIDValuePUp_4.Text);
            //Kp_up_5 = double.Parse(tbPIDValuePUp_5.Text);
            //Kp_up_6 = double.Parse(tbPIDValuePUp_6.Text);
            //Kp_up_7 = double.Parse(tbPIDValuePUp_7.Text);
            //Kp_up_8 = double.Parse(tbPIDValuePUp_8.Text);

            //Ki_up_1 = double.Parse(tbPIDValueIUp_1.Text);
            //Ki_up_2 = double.Parse(tbPIDValueIUp_2.Text);
            //Ki_up_3 = double.Parse(tbPIDValueIUp_3.Text);
            //Ki_up_4 = double.Parse(tbPIDValueIUp_4.Text);
            //Ki_up_5 = double.Parse(tbPIDValueIUp_5.Text);
            //Ki_up_6 = double.Parse(tbPIDValueIUp_6.Text);
            //Ki_up_7 = double.Parse(tbPIDValueIUp_7.Text);
            //Ki_up_8 = double.Parse(tbPIDValueIUp_8.Text);

            //Kd_up_1 = double.Parse(tbPIDValueDUp_1.Text);
            //Kd_up_2 = double.Parse(tbPIDValueDUp_2.Text);
            //Kd_up_3 = double.Parse(tbPIDValueDUp_3.Text);
            //Kd_up_4 = double.Parse(tbPIDValueDUp_4.Text);
            //Kd_up_5 = double.Parse(tbPIDValueDUp_5.Text);
            //Kd_up_6 = double.Parse(tbPIDValueDUp_6.Text);
            //Kd_up_7 = double.Parse(tbPIDValueDUp_7.Text);
            //Kd_up_8 = double.Parse(tbPIDValueDUp_8.Text);




            //Kp_down_1 = double.Parse(tbPIDValuePDown_1.Text);
            //Kp_down_2 = double.Parse(tbPIDValuePDown_2.Text);
            //Kp_down_3 = double.Parse(tbPIDValuePDown_3.Text);
            //Kp_down_4 = double.Parse(tbPIDValuePDown_4.Text);
            //Kp_down_5 = double.Parse(tbPIDValuePDown_5.Text);
            //Kp_down_6 = double.Parse(tbPIDValuePDown_6.Text);
            //Kp_down_7 = double.Parse(tbPIDValuePDown_7.Text);
            //Kp_down_8 = double.Parse(tbPIDValuePDown_8.Text);

            //Ki_down_1 = double.Parse(tbPIDValueIDown_1.Text);
            //Ki_down_2 = double.Parse(tbPIDValueIDown_2.Text);
            //Ki_down_3 = double.Parse(tbPIDValueIDown_3.Text);
            //Ki_down_4 = double.Parse(tbPIDValueIDown_4.Text);
            //Ki_down_5 = double.Parse(tbPIDValueIDown_5.Text);
            //Ki_down_6 = double.Parse(tbPIDValueIDown_6.Text);
            //Ki_down_7 = double.Parse(tbPIDValueIDown_7.Text);
            //Ki_down_8 = double.Parse(tbPIDValueIDown_8.Text);

            //Kd_down_1 = double.Parse(tbPIDValueDDown_1.Text);
            //Kd_down_2 = double.Parse(tbPIDValueDDown_2.Text);
            //Kd_down_3 = double.Parse(tbPIDValueDDown_3.Text);
            //Kd_down_4 = double.Parse(tbPIDValueDDown_4.Text);
            //Kd_down_5 = double.Parse(tbPIDValueDDown_5.Text);
            //Kd_down_6 = double.Parse(tbPIDValueDDown_6.Text);
            //Kd_down_7 = double.Parse(tbPIDValueDDown_7.Text);
            //Kd_down_8 = double.Parse(tbPIDValueDDown_8.Text);




            /*
             * data serialize
             */
            

            CoreSerialize cs = new CoreSerialize();
            PIDParameters dataPID = new PIDParameters();
            TParameters dataT = new TParameters();
            try
            {
                dataPID = cs.PIDDeSerializeNow();
                dataT = cs.TParamDeSerializeNow();
                p1_1 = dataT.p1_1;
                p2_1 = dataT.p2_1;
                p1_2 = dataT.p1_2;
                p2_2 = dataT.p2_2;
                p1_3 = dataT.p1_3;
                p2_3 = dataT.p2_3;
                p1_4 = dataT.p1_4;
                p2_4 = dataT.p2_4;
                p1_5 = dataT.p1_5;
                p2_5 = dataT.p2_5;
                p1_6 = dataT.p1_6;
                p2_6 = dataT.p2_6;
                p1_7 = dataT.p1_7;
                p2_7 = dataT.p2_7;
                p1_8 = dataT.p1_8;
                p2_8 = dataT.p2_8;

                Kp_up_1 = dataPID.kp_up_1;
                Ki_up_1 = dataPID.ki_up_1;
                Kd_up_1 = dataPID.kd_up_1;
                Kp_up_2 = dataPID.kp_up_2;
                Ki_up_2 = dataPID.ki_up_2;
                Kd_up_2 = dataPID.kd_up_2;
                Kp_up_3 = dataPID.kp_up_3;
                Ki_up_3 = dataPID.ki_up_3;
                Kd_up_3 = dataPID.kd_up_3;
                Kp_up_4 = dataPID.kp_up_4;
                Ki_up_4 = dataPID.ki_up_4;
                Kd_up_4 = dataPID.kd_up_4;
                Kp_up_5 = dataPID.kp_up_5;
                Ki_up_5 = dataPID.ki_up_5;
                Kd_up_5 = dataPID.kd_up_5;
                Kp_up_6 = dataPID.kp_up_6;
                Ki_up_6 = dataPID.ki_up_6;
                Kd_up_6 = dataPID.kd_up_6;
                Kp_up_7 = dataPID.kp_up_7;
                Ki_up_7 = dataPID.ki_up_7;
                Kd_up_7 = dataPID.kd_up_7;
                Kp_up_8 = dataPID.kp_up_8;
                Ki_up_8 = dataPID.ki_up_8;
                Kd_up_8 = dataPID.kd_up_8;

                Kp_down_1 = dataPID.kp_down_1;
                Ki_down_1 = dataPID.ki_down_1;
                Kd_down_1 = dataPID.kd_down_1;
                Kp_down_2 = dataPID.kp_down_2;
                Ki_down_2 = dataPID.ki_down_2;
                Kd_down_2 = dataPID.kd_down_2;
                Kp_down_3 = dataPID.kp_down_3;
                Ki_down_3 = dataPID.ki_down_3;
                Kd_down_3 = dataPID.kd_down_3;
                Kp_down_4 = dataPID.kp_down_4;
                Ki_down_4 = dataPID.ki_down_4;
                Kd_down_4 = dataPID.kd_down_4;
                Kp_down_5 = dataPID.kp_down_5;
                Ki_down_5 = dataPID.ki_down_5;
                Kd_down_5 = dataPID.kd_down_5;
                Kp_down_6 = dataPID.kp_down_6;
                Ki_down_6 = dataPID.ki_down_6;
                Kd_down_6 = dataPID.kd_down_6;
                Kp_down_7 = dataPID.kp_down_7;
                Ki_down_7 = dataPID.ki_down_7;
                Kd_down_7 = dataPID.kd_down_7;
                Kp_down_8 = dataPID.kp_down_8;
                Ki_down_8 = dataPID.ki_down_8;
                Kd_down_8 = dataPID.kd_down_8;



                tbP1_1.Text = p1_1.ToString();
                tbP2_1.Text = p2_1.ToString();
                tbP1_2.Text = p1_2.ToString();
                tbP2_2.Text = p2_2.ToString();
                tbP1_3.Text = p1_3.ToString();
                tbP2_3.Text = p2_3.ToString();
                tbP1_4.Text = p1_4.ToString();
                tbP2_4.Text = p2_4.ToString();
                tbP1_5.Text = p1_5.ToString();
                tbP2_5.Text = p2_5.ToString();
                tbP1_6.Text = p1_6.ToString();
                tbP2_6.Text = p2_6.ToString();
                tbP1_7.Text = p1_7.ToString();
                tbP2_7.Text = p2_7.ToString();
                tbP1_8.Text = p1_8.ToString();
                tbP2_8.Text = p2_8.ToString();

                tbPIDValuePUp_1.Text = Kp_up_1.ToString();
                tbPIDValueIUp_1.Text = Ki_up_1.ToString();
                tbPIDValueDUp_1.Text = Kd_up_1.ToString();
                tbPIDValuePUp_2.Text = Kp_up_2.ToString();
                tbPIDValueIUp_2.Text = Ki_up_2.ToString();
                tbPIDValueDUp_2.Text = Kd_up_2.ToString();
                tbPIDValuePUp_3.Text = Kp_up_3.ToString();
                tbPIDValueIUp_3.Text = Ki_up_3.ToString();
                tbPIDValueDUp_3.Text = Kd_up_3.ToString();
                tbPIDValuePUp_4.Text = Kp_up_4.ToString();
                tbPIDValueIUp_4.Text = Ki_up_4.ToString();
                tbPIDValueDUp_4.Text = Kd_up_4.ToString();
                tbPIDValuePUp_5.Text = Kp_up_5.ToString();
                tbPIDValueIUp_5.Text = Ki_up_5.ToString();
                tbPIDValueDUp_5.Text = Kd_up_5.ToString();
                tbPIDValuePUp_6.Text = Kp_up_6.ToString();
                tbPIDValueIUp_6.Text = Ki_up_6.ToString();
                tbPIDValueDUp_6.Text = Kd_up_6.ToString();
                tbPIDValuePUp_7.Text = Kp_up_7.ToString();
                tbPIDValueIUp_7.Text = Ki_up_7.ToString();
                tbPIDValueDUp_7.Text = Kd_up_7.ToString();
                tbPIDValuePUp_8.Text = Kp_up_8.ToString();
                tbPIDValueIUp_8.Text = Ki_up_8.ToString();
                tbPIDValueDUp_8.Text = Kd_up_8.ToString();

                tbPIDValuePDown_1.Text = Kp_down_1.ToString();
                tbPIDValueIDown_1.Text = Ki_down_1.ToString();
                tbPIDValueDDown_1.Text = Kd_down_1.ToString();
                tbPIDValuePDown_2.Text = Kp_down_2.ToString();
                tbPIDValueIDown_2.Text = Ki_down_2.ToString();
                tbPIDValueDDown_2.Text = Kd_down_2.ToString();
                tbPIDValuePDown_3.Text = Kp_down_3.ToString();
                tbPIDValueIDown_3.Text = Ki_down_3.ToString();
                tbPIDValueDDown_3.Text = Kd_down_3.ToString();
                tbPIDValuePDown_4.Text = Kp_down_4.ToString();
                tbPIDValueIDown_4.Text = Ki_down_4.ToString();
                tbPIDValueDDown_4.Text = Kd_down_4.ToString();
                tbPIDValuePDown_5.Text = Kp_down_5.ToString();
                tbPIDValueIDown_5.Text = Ki_down_5.ToString();
                tbPIDValueDDown_5.Text = Kd_down_5.ToString();
                tbPIDValuePDown_6.Text = Kp_down_6.ToString();
                tbPIDValueIDown_6.Text = Ki_down_6.ToString();
                tbPIDValueDDown_6.Text = Kd_down_6.ToString();
                tbPIDValuePDown_7.Text = Kp_down_7.ToString();
                tbPIDValueIDown_7.Text = Ki_down_7.ToString();
                tbPIDValueDDown_7.Text = Kd_down_7.ToString();
                tbPIDValuePDown_8.Text = Kp_down_8.ToString();
                tbPIDValueIDown_8.Text = Ki_down_8.ToString();
                tbPIDValueDDown_8.Text = Kd_down_8.ToString();

                Board_1.SetTConvertParam(p1_1,p2_1, p1_2, p2_2, p1_3, p2_3, p1_4, p2_4, p1_5, p2_5, p1_6, p2_6, p1_7, p2_7, p1_8, p2_8);
                Board_2.SetTConvertParam(p1_1, p2_1, p1_2, p2_2, p1_3, p2_3, p1_4, p2_4, p1_5, p2_5, p1_6, p2_6, p1_7, p2_7, p1_8, p2_8);


            }
            catch
            {
                TParameters tp = new TParameters()
                {
                    p1_1 = double.Parse(tbP1_1.Text),
                    p1_2 = double.Parse(tbP1_2.Text),
                    p1_3 = double.Parse(tbP1_3.Text),
                    p1_4 = double.Parse(tbP1_4.Text),
                    p1_5 = double.Parse(tbP1_5.Text),
                    p1_6 = double.Parse(tbP1_6.Text),
                    p1_7 = double.Parse(tbP1_7.Text),
                    p1_8 = double.Parse(tbP1_8.Text),

                    p2_1 = double.Parse(tbP2_1.Text),
                    p2_2 = double.Parse(tbP2_2.Text),
                    p2_3 = double.Parse(tbP2_3.Text),
                    p2_4 = double.Parse(tbP2_4.Text),
                    p2_5 = double.Parse(tbP2_5.Text),
                    p2_6 = double.Parse(tbP2_6.Text),
                    p2_7 = double.Parse(tbP2_7.Text),
                    p2_8 = double.Parse(tbP2_8.Text)



                };

                PIDParameters pp = new PIDParameters()
                {
                    kp_up_1 = double.Parse(tbPIDValuePUp_1.Text),
                    ki_up_1 = double.Parse(tbPIDValueIUp_1.Text),
                    kd_up_1 = double.Parse(tbPIDValueDUp_1.Text),
                    kp_up_2 = double.Parse(tbPIDValuePUp_2.Text),
                    ki_up_2 = double.Parse(tbPIDValueIUp_2.Text),
                    kd_up_2 = double.Parse(tbPIDValueDUp_2.Text),
                    kp_up_3 = double.Parse(tbPIDValuePUp_3.Text),
                    ki_up_3 = double.Parse(tbPIDValueIUp_3.Text),
                    kd_up_3 = double.Parse(tbPIDValueDUp_3.Text),
                    kp_up_4 = double.Parse(tbPIDValuePUp_4.Text),
                    ki_up_4 = double.Parse(tbPIDValueIUp_4.Text),
                    kd_up_4 = double.Parse(tbPIDValueDUp_4.Text),
                    kp_up_5 = double.Parse(tbPIDValuePUp_5.Text),
                    ki_up_5 = double.Parse(tbPIDValueIUp_5.Text),
                    kd_up_5 = double.Parse(tbPIDValueDUp_5.Text),
                    kp_up_6 = double.Parse(tbPIDValuePUp_6.Text),
                    ki_up_6 = double.Parse(tbPIDValueIUp_6.Text),
                    kd_up_6 = double.Parse(tbPIDValueDUp_6.Text),
                    kp_up_7 = double.Parse(tbPIDValuePUp_7.Text),
                    ki_up_7 = double.Parse(tbPIDValueIUp_7.Text),
                    kd_up_7 = double.Parse(tbPIDValueDUp_7.Text),
                    kp_up_8 = double.Parse(tbPIDValuePUp_8.Text),
                    ki_up_8 = double.Parse(tbPIDValueIUp_8.Text),
                    kd_up_8 = double.Parse(tbPIDValueDUp_8.Text),

                    kp_down_1 = double.Parse(tbPIDValuePDown_1.Text),
                    ki_down_1 = double.Parse(tbPIDValueIDown_1.Text),
                    kd_down_1 = double.Parse(tbPIDValueDDown_1.Text),
                    kp_down_2 = double.Parse(tbPIDValuePDown_2.Text),
                    ki_down_2 = double.Parse(tbPIDValueIDown_2.Text),
                    kd_down_2 = double.Parse(tbPIDValueDDown_2.Text),
                    kp_down_3 = double.Parse(tbPIDValuePDown_3.Text),
                    ki_down_3 = double.Parse(tbPIDValueIDown_3.Text),
                    kd_down_3 = double.Parse(tbPIDValueDDown_3.Text),
                    kp_down_4 = double.Parse(tbPIDValuePDown_4.Text),
                    ki_down_4 = double.Parse(tbPIDValueIDown_4.Text),
                    kd_down_4 = double.Parse(tbPIDValueDDown_4.Text),
                    kp_down_5 = double.Parse(tbPIDValuePDown_5.Text),
                    ki_down_5 = double.Parse(tbPIDValueIDown_5.Text),
                    kd_down_5 = double.Parse(tbPIDValueDDown_5.Text),
                    kp_down_6 = double.Parse(tbPIDValuePDown_6.Text),
                    ki_down_6 = double.Parse(tbPIDValueIDown_6.Text),
                    kd_down_6 = double.Parse(tbPIDValueDDown_6.Text),
                    kp_down_7 = double.Parse(tbPIDValuePDown_7.Text),
                    ki_down_7 = double.Parse(tbPIDValueIDown_7.Text),
                    kd_down_7 = double.Parse(tbPIDValueDDown_7.Text),
                    kp_down_8 = double.Parse(tbPIDValuePDown_8.Text),
                    ki_down_8 = double.Parse(tbPIDValueIDown_8.Text),
                    kd_down_8 = double.Parse(tbPIDValueDDown_8.Text),

                };


                cs.PIDSerializeNow(pp);
                cs.TParammSerializeNow(tp);




                dataPID = cs.PIDDeSerializeNow();
                dataT = cs.TParamDeSerializeNow();
                p1_1 = dataT.p1_1;
                p2_1 = dataT.p2_1;
                p1_2 = dataT.p1_2;
                p2_2 = dataT.p2_2;
                p1_3 = dataT.p1_3;
                p2_3 = dataT.p2_3;
                p1_4 = dataT.p1_4;
                p2_4 = dataT.p2_4;
                p1_5 = dataT.p1_5;
                p2_5 = dataT.p2_5;
                p1_6 = dataT.p1_6;
                p2_6 = dataT.p2_6;
                p1_7 = dataT.p1_7;
                p2_7 = dataT.p2_7;
                p1_8 = dataT.p1_8;
                p2_8 = dataT.p2_8;

                Kp_up_1 = dataPID.kp_up_1;
                Ki_up_1 = dataPID.ki_up_1;
                Kd_up_1 = dataPID.kd_up_1;
                Kp_up_2 = dataPID.kp_up_2;
                Ki_up_2 = dataPID.ki_up_2;
                Kd_up_2 = dataPID.kd_up_2;
                Kp_up_3 = dataPID.kp_up_3;
                Ki_up_3 = dataPID.ki_up_3;
                Kd_up_3 = dataPID.kd_up_3;
                Kp_up_4 = dataPID.kp_up_4;
                Ki_up_4 = dataPID.ki_up_4;
                Kd_up_4 = dataPID.kd_up_4;
                Kp_up_5 = dataPID.kp_up_5;
                Ki_up_5 = dataPID.ki_up_5;
                Kd_up_5 = dataPID.kd_up_5;
                Kp_up_6 = dataPID.kp_up_6;
                Ki_up_6 = dataPID.ki_up_6;
                Kd_up_6 = dataPID.kd_up_6;
                Kp_up_7 = dataPID.kp_up_7;
                Ki_up_7 = dataPID.ki_up_7;
                Kd_up_7 = dataPID.kd_up_7;
                Kp_up_8 = dataPID.kp_up_8;
                Ki_up_8 = dataPID.ki_up_8;
                Kd_up_8 = dataPID.kd_up_8;

                Kp_down_1 = dataPID.kp_down_1;
                Ki_down_1 = dataPID.ki_down_1;
                Kd_down_1 = dataPID.kd_down_1;
                Kp_down_2 = dataPID.kp_down_2;
                Ki_down_2 = dataPID.ki_down_2;
                Kd_down_2 = dataPID.kd_down_2;
                Kp_down_3 = dataPID.kp_down_3;
                Ki_down_3 = dataPID.ki_down_3;
                Kd_down_3 = dataPID.kd_down_3;
                Kp_down_4 = dataPID.kp_down_4;
                Ki_down_4 = dataPID.ki_down_4;
                Kd_down_4 = dataPID.kd_down_4;
                Kp_down_5 = dataPID.kp_down_5;
                Ki_down_5 = dataPID.ki_down_5;
                Kd_down_5 = dataPID.kd_down_5;
                Kp_down_6 = dataPID.kp_down_6;
                Ki_down_6 = dataPID.ki_down_6;
                Kd_down_6 = dataPID.kd_down_6;
                Kp_down_7 = dataPID.kp_down_7;
                Ki_down_7 = dataPID.ki_down_7;
                Kd_down_7 = dataPID.kd_down_7;
                Kp_down_8 = dataPID.kp_down_8;
                Ki_down_8 = dataPID.ki_down_8;
                Kd_down_8 = dataPID.kd_down_8;
            }




            timer_1.Start();
            timer_2.Start();
            timer_3.Start();
            timer_4.Start();
            timer_5.Start();
            timer_6.Start();
            timer_7.Start();
            timer_8.Start();


        }

        private void timer_1_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();      //  开始监视代码运行时间

            /*
             * time get module
             */

            int RawValue;
            temperatureValue_1 = Board_1.getT(1,out RawValue);
            lblRawData_1.Text = RawValue.ToString();
            lblTValue_1.Text = temperatureValue_1.ToString("00.00");

            if (isExecutePIDModel_1 == true || isExecutePIDModelDown_1==true)
            {
                lblPIDTValue_1.Text = temperatureValue_1.ToString("00.00");
            }
            
            /*
             * Test by hand module
             */
            if (isTestByHand_1 == false)
            {
                digitalControlSingal_1 = Board_2.getSingal(1);
                
            }

            if (temperatureValue_1 > 60 || temperatureValue_1 < 0)
            {
                Board_1.TNature(1);
                timer_1.Stop();
                lblTState_1.Text = "Error";                
            }

            /*
             *  Up and Down control module
             */
            if (isExecuteControlModel_1 == true)
            {

               
                if (digitalControlSingal_1 == 1 && isFirstChangeUp_1 == true)
                {
                    
                   
                   
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
                    if (isExecutePIDModelDown_1)
                    {
                        PID_1 = new PIDControl(P_1, D_1, I_1, punishmentT);
                       
                    }
                    else
                    {
                        PID_1 = new PIDControl(Kp_up_1, Ki_up_1, Kd_up_1, punishmentT);
                        
                    }
                    
                    
                    System.IO.File.AppendAllText("e:\\result_1.txt", "惩罚：" + "Kp:" + Kp_up_1.ToString() + "  Ki" + Ki_up_1.ToString() + "  Kd" + Kp_up_1.ToString() + "\r\n");
                }
                else if (digitalControlSingal_1 == 0 && isFirstChangeDown_1 == true)
                {
                   
                   
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
                    if (isExecutePIDModel_1)
                    {
                        PID_1 = new PIDControl(P_1, D_1, I_1, confortableT);
                       
                    }
                    else
                    {
                        PID_1 = new PIDControl(Kp_down_1, Ki_down_1, Kd_down_1, confortableT);
                        
                    }
                   
                    System.IO.File.AppendAllText("e:\\result_1.txt", "舒适：" + "Kp:" + Kp_down_1.ToString() + "  Ki" + Ki_down_1.ToString() + "  Kd" + Kp_down_1.ToString() + "\r\n");
                }
                else
                {
                    ;
                }
            }




            /*
             * PID paramete test module
             */

            if (isExecutePIDModel_1 == true)
            {
                timerCount_1++;

                if (timerCount_1 == 300 && highBalance_1 == true)
                {
                    timerCount_1 = 0;
                    digitalControlSingal_1 = 0;
                    highBalance_1 = false;
                    downLine_1 = true;
                   
                }

                if (timerCount_1 == 150 && downLine_1)
                {
                    //System.IO.File.AppendAllText("e:\\result_1.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_1 = true;
                    downLine_1 = false;
                    timeNotAccept_1 = true;
                   
                }

                if (temperatureValue_1 - confortableT <= 0.5 && downLine_1 == true)
                {
                    beyondNum_1++;
                    if (beyondNum_1 == 3)
                    {

                       
                        timeResult_1 = timerCount_1;
                        timerCount_1 = 0;
                        downLine_1 = false;
                        longKeep_1 = true;
                        beyondNum_1 = 0;

                    }
                }

                if (longKeep_1 == true)
                {
                    tempCollection_1.Add(temperatureValue_1);
                    if (timerCount_1 == 300)
                    {
                        isChangeParam_1 = true;
                        longKeep_1 = false;
                    }

                }






                if (isChangeParam_1)
                {

                  //  lblPIDDebug.Text = isExecutePIDModel_1.ToString();
                    if (timeNotAccept_1)
                    {
                        lblPIDTestStatus_1.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_1, I_1, D_1));
                        //System.IO.File.AppendAllText("e:\\result_1.txt", P_1 + "   " + I_1 + "   " + D_1 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                        
                    }
                    else
                    {
                        string PID_Result_1;
                        resultAnalyse(tempCollection_1,P_1,I_1,D_1, out PID_Result_1,1);
                        tempCollection_1.Clear();
                        lblPIDTestStatus_1.Text = PID_Result_1;
                        //执行计算，然后输出
                    }
                    if (D_1 == 3)
                    {
                        timer_1.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_1.Text = "finished!";
                    }

                    digitalControlSingal_1 = 1;
                    isChangeParam_1 = false;
                    P_1 += 0.5;
                  
                    if (P_1 == 10)
                    {
                        D_1 += 0.5;
                        P_1 = 0.5;
                    }


                    timerCount_1 = 0;
                    beyondNum_1 = 0;
                    highBalance_1 = true;
                }

            }





            /*
             * PID paramete test module
             */

            if (isExecutePIDModelDown_1 == true)
            {
                timerCount_1++;

                if (timerCount_1 == 300 && lowBalance_1 == true)
                {
                    timerCount_1 = 0;
                    digitalControlSingal_1 = 1;
                    lowBalance_1 = false;
                    upLine_1 = true;
                   
                }

                if (timerCount_1 == 100 && upLine_1)
                {
                    //System.IO.File.AppendAllText("e:\\result_1.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_1 = true;
                    upLine_1 = false;
                    timeNotAccept_1 = true;


                }

                if (punishmentT- temperatureValue_1 <= 0.5 && upLine_1 == true)
                {
                    beyondNum_1++;
                    if (beyondNum_1 == 3)
                    {
                        timeResult_1 = timerCount_1;
                        timerCount_1 = 0;
                        upLine_1 = false;
                        longKeep_1 = true;
                        beyondNum_1 = 0;

                    }
                }

                if (longKeep_1 == true)
                {
                    tempCollection_1.Add(temperatureValue_1);
                    if (timerCount_1 == 300)
                    {
                        isChangeParam_1 = true;
                        longKeep_1 = false;
                    }

                }






                if (isChangeParam_1)
                {

                    if (timeNotAccept_1)
                    {
                        lblPIDTestStatus_1.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_1, I_1, D_1));
                        //System.IO.File.AppendAllText("e:\\result_1.txt", P_1 + "   " + I_1 + "   " + D_1 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_1;
                        resultAnalyse(tempCollection_1, P_1, I_1, D_1, out PID_Result_1, 1);
                        tempCollection_1.Clear();
                        lblPIDTestStatus_1.Text = PID_Result_1;
                        //执行计算，然后输出
                    }
                    if (D_1 == 10)
                    {
                        timer_1.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_1.Text = "Finished!";
                    }

                    digitalControlSingal_1 = 0;
                    isChangeParam_1 = false;
                    P_1 += 0.5;
                    if (P_1 == 10)
                    {
                        D_1 += 0.5;
                        P_1 = 0.5;
                    }


                    timerCount_1 = 0;
                    beyondNum_1 = 0;
                    lowBalance_1 = true;
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
                    proportion_1 = PID_1.ConvertAccordToPropotation(proportion_1, circle, FirstProportion_1);

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

                if (!isExecuteControlModel_1 || !isExecutePIDModelDown_1)
                {
                    System.IO.File.AppendAllText("e:\\result_1.txt", temperatureValue_1.ToString("00.00") + "\r\n");
                }
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
                if (!isExecuteControlModel_1 || !isExecutePIDModelDown_1)
                {
                    System.IO.File.AppendAllText("e:\\result_1.txt", temperatureValue_1.ToString("00.00") + "\r\n");
                }
            }

            stopwatch.Stop(); //  停止监视

            TimeSpan timespan = stopwatch.Elapsed;

            lblExecuteTimeInPID.Text = timespan.TotalMilliseconds.ToString();  //  总毫秒数
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
            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);

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

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);




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


            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);



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



            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);

            timer_4.Start();
        }

        private void btnStarPIDSingle_1_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStart_1)
            {
                isExecuteControlModel_1 = true;
                isExecutePIDModel_1 = true;
                digitalControlSingal_1 = 1;
                highBalance_1 = true;
                this.btnStarPIDSingleDown_1.Text = "Stop";
                isFirstChangeUp_1 = true;
                isFirstChangeDown_1 = true;
                timerCount_1 = 0;
                beyondNum_1 = 0;
                longKeep_1 = false;
                isChangeParam_1 = false;
                downLine_1 = false;
                System.IO.File.AppendAllText("e:\\resultPID_1.txt", "降温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_1 = false;
                isExecutePIDModel_1 = false;
                this.btnStarPIDSingleDown_1.Text = "Start";
                lblPIDTestStatus_1.Text = "NULL";
                lblPIDTValue_1.Text = "NULL";
                isUp_1 = false;
                isDown_1 = false;
                
            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);

        }

        private void btnPIDStartAll_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStarPIDSingleDown_2_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStart_2)
            {
                isExecuteControlModel_2 = true;
                isExecutePIDModel_2 = true;
                digitalControlSingal_2 = 1;
                highBalance_2 = true;
                this.btnStarPIDSingleDown_2.Text = "Stop";
                isFirstChangeUp_2 = true;
                isFirstChangeDown_2 = true;
                timerCount_2 = 0;
                beyondNum_2 = 0;
                longKeep_2 = false;
                isChangeParam_2 = false;
                downLine_2 = false;
                System.IO.File.AppendAllText("e:\\resultPID_2.txt", "降温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_2 = false;
                isExecutePIDModel_2 = false;
                this.btnStarPIDSingleDown_2.Text = "Start";
                lblPIDTestStatus_2.Text = "NULL";
                lblPIDTValue_2.Text = "NULL";
                isUp_2 = false;
                isDown_2 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleDown_3_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStart_3)
            {
                isExecuteControlModel_3 = true;
                isExecutePIDModel_3 = true;
                digitalControlSingal_3 = 1;
                highBalance_3 = true;
                this.btnStarPIDSingleDown_3.Text = "Stop";
                isFirstChangeUp_3 = true;
                isFirstChangeDown_3 = true;
                timerCount_3 = 0;
                beyondNum_3 = 0;
                longKeep_3 = false;
                isChangeParam_3 = false;
                downLine_3 = false;
                System.IO.File.AppendAllText("e:\\resultPID_3.txt", "降温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_3 = false;
                isExecutePIDModel_3 = false;
                this.btnStarPIDSingleDown_3.Text = "Start";
                lblPIDTestStatus_3.Text = "NULL";
                lblPIDTValue_3.Text = "NULL";
                isUp_3 = false;
                isDown_3 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleDown_4_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStart_4)
            {
                isExecuteControlModel_4 = true;
                isExecutePIDModel_4 = true;
                digitalControlSingal_4 = 1;
                highBalance_4 = true;
                this.btnStarPIDSingleDown_4.Text = "Stop";
                isFirstChangeUp_4 = true;
                isFirstChangeDown_4 = true;
                timerCount_4 = 0;
                beyondNum_4 = 0;
                longKeep_4 = false;
                isChangeParam_4 = false;
                downLine_4 = false;

                System.IO.File.AppendAllText("e:\\resultPID_4.txt", "降温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_4 = false;
                isExecutePIDModel_4 = false;
                this.btnStarPIDSingleDown_4.Text = "Start";
                lblPIDTestStatus_4.Text = "NULL";
                lblPIDTValue_4.Text = "NULL";
                isUp_4 = false;
                isDown_4 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleDown_5_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStart_5)
            {
                isExecuteControlModel_5 = true;
                isExecutePIDModel_5 = true;
                digitalControlSingal_5 = 1;
                highBalance_5 = true;
                this.btnStarPIDSingleDown_5.Text = "Stop";
                isFirstChangeUp_5 = true;
                isFirstChangeDown_5 = true;
                timerCount_5 = 0;
                beyondNum_5 = 0;
                longKeep_5 = false;
                isChangeParam_5 = false;
                downLine_5 = false;
                System.IO.File.AppendAllText("e:\\resultPID_5.txt", "降温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_5 = false;
                isExecutePIDModel_5 = false;
                this.btnStarPIDSingleDown_5.Text = "Start";
                lblPIDTestStatus_5.Text = "NULL";
                lblPIDTValue_5.Text = "NULL";
                isUp_5 = false;
                isDown_5 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleDown_6_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStart_6)
            {
                isExecuteControlModel_6 = true;
                isExecutePIDModel_6 = true;
                digitalControlSingal_6 = 1;
                highBalance_6 = true;
                this.btnStarPIDSingleDown_6.Text = "Stop";
                isFirstChangeUp_6 = true;
                isFirstChangeDown_6 = true;
                timerCount_6 = 0;
                beyondNum_6 = 0;
                longKeep_6 = false;
                isChangeParam_6 = false;
                downLine_6 = false;
                System.IO.File.AppendAllText("e:\\resultPID_6.txt", "降温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_6 = false;
                isExecutePIDModel_6 = false;
                this.btnStarPIDSingleDown_6.Text = "Start";
                lblPIDTestStatus_6.Text = "NULL";
                lblPIDTValue_6.Text = "NULL";
                isUp_6 = false;
                isDown_6 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleDown_7_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStart_7)
            {
                isExecuteControlModel_7 = true;
                isExecutePIDModel_7 = true;
                digitalControlSingal_7 = 1;
                highBalance_7 = true;
                this.btnStarPIDSingleDown_7.Text = "Stop";
                isFirstChangeUp_7 = true;
                isFirstChangeDown_7 = true;
                timerCount_7 = 0;
                beyondNum_7 = 0;
                longKeep_7 = false;
                isChangeParam_7 = false;
                downLine_7 = false;
                System.IO.File.AppendAllText("e:\\resultPID_7.txt", "降温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_7 = false;
                isExecutePIDModel_7 = false;
                this.btnStarPIDSingleDown_7.Text = "Start";
                lblPIDTestStatus_7.Text = "NULL";
                lblPIDTValue_7.Text = "NULL";
                isUp_7 = false;
                isDown_7 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleDown_8_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStart_8)
            {
                isExecuteControlModel_8 = true;
                isExecutePIDModel_8 = true;
                digitalControlSingal_8 = 1;
                highBalance_8 = true;
                this.btnStarPIDSingleDown_8.Text = "Stop";
                isFirstChangeUp_8 = true;
                isFirstChangeDown_8 = true;
                timerCount_8 = 0;
                beyondNum_8 = 0;
                longKeep_8 = false;
                isChangeParam_8 = false;
                downLine_8 = false;

                System.IO.File.AppendAllText("e:\\resultPID_8.txt", "降温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_8 = false;
                isExecutePIDModel_8 = false;
                this.btnStarPIDSingleDown_8.Text = "Start";
                lblPIDTestStatus_8.Text = "NULL";
                lblPIDTValue_8.Text = "NULL";
                isUp_8 = false;
                isDown_8 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnPIDClearAll_Click(object sender, EventArgs e)
        {
            Board_1.clearALL();
            isTotalStartBtnTrue = true;
            btnTotalStart.Text = "Start";



            isExecuteControlModel_1 = false;
            isExecuteControlModel_2 = false;
            isExecuteControlModel_3 = false;
            isExecuteControlModel_4 = false;
            isExecuteControlModel_5 = false;
            isExecuteControlModel_6 = false;
            isExecuteControlModel_7 = false;
            isExecuteControlModel_8 = false;


            isExecutePIDModelDown_1 = false;
            isExecutePIDModel_1 = false;
            isExecutePIDModelDown_2 = false;
            isExecutePIDModel_2 = false;
            isExecutePIDModelDown_3 = false;
            isExecutePIDModel_3 = false;
            isExecutePIDModelDown_4 = false;
            isExecutePIDModel_4 = false;
            isExecutePIDModelDown_5 = false;
            isExecutePIDModel_5 = false;
            isExecutePIDModelDown_6 = false;
            isExecutePIDModel_6 = false;
            isExecutePIDModelDown_7 = false;
            isExecutePIDModel_7 = false;
            isExecutePIDModelDown_8 = false;
            isExecutePIDModel_8 = false;
          

            lblTState_1.Text = "NULL";
            lblTState_2.Text = "NULL";
            lblTState_3.Text = "NULL";
            lblTState_4.Text = "NULL";
            lblTState_5.Text = "NULL";
            lblTState_6.Text = "NULL";
            lblTState_7.Text = "NULL";
            lblTState_8.Text = "NULL";


            isUp_1 = false;
            isUp_2 = false;
            isUp_3 = false;
            isUp_4 = false;
            isUp_5 = false;
            isUp_6 = false;
            isUp_7 = false;
            isUp_8 = false;

            isDown_1 = false;
            isDown_2 = false;
            isDown_3 = false;
            isDown_4 = false;
            isDown_5 = false;
            isDown_6 = false;
            isDown_7 = false;
            isDown_8 = false;


        }

        private void btnStarPIDSingleUp_1_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStartDown_1)
            {
                isExecuteControlModel_1 = true;
                isExecutePIDModelDown_1 = true;
                digitalControlSingal_1 = 0;
                lowBalance_1 = true;
                this.btnStarPIDSingleUp_1.Text = "Stop";
                isFirstChangeUp_1 = true;
                isFirstChangeDown_1 = true;
                timerCount_1 = 0;
                beyondNum_1 = 0;
                longKeep_1 = false;
                isChangeParam_1 = false;
                upLine_1 = false;
                System.IO.File.AppendAllText("e:\\resultPID_1.txt", "升温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_1 = false;
                isExecutePIDModelDown_1 = false;
                this.btnStarPIDSingleUp_1.Text = "Start";
                lblPIDTestStatus_1.Text = "NULL";
                lblPIDTValue_1.Text = "NULL";
                isUp_1 = false;
                isDown_1 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleUp_2_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStartDown_2)
            {
                isExecuteControlModel_2 = true;
                isExecutePIDModelDown_2 = true;
                digitalControlSingal_2 = 0;
                lowBalance_2 = true;
                this.btnStarPIDSingleUp_2.Text = "Stop";
                isFirstChangeUp_2 = true;
                isFirstChangeDown_2 = true;
                timerCount_2 = 0;
                beyondNum_2 = 0;
                longKeep_2 = false;
                isChangeParam_2 = false;
                upLine_2 = false;
                System.IO.File.AppendAllText("e:\\resultPID_2.txt", "升温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_2 = false;
                isExecutePIDModelDown_2 = false;
                this.btnStarPIDSingleUp_2.Text = "Start";
                lblPIDTestStatus_2.Text = "NULL";
                lblPIDTValue_2.Text = "NULL";
                isUp_2 = false;
                isDown_2 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleUp_3_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStartDown_3)
            {
                isExecuteControlModel_3 = true;
                isExecutePIDModelDown_3 = true;
                digitalControlSingal_3 = 0;
                lowBalance_3 = true;
                this.btnStarPIDSingleUp_3.Text = "Stop";
                isFirstChangeUp_3 = true;
                isFirstChangeDown_3 = true;
                timerCount_3 = 0;
                beyondNum_3 = 0;
                longKeep_3 = false;
                isChangeParam_3 = false;
                upLine_3 = false;
                System.IO.File.AppendAllText("e:\\resultPID_3.txt", "升温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_3 = false;
                isExecutePIDModelDown_3 = false;
                this.btnStarPIDSingleUp_3.Text = "Start";
                lblPIDTestStatus_3.Text = "NULL";
                lblPIDTValue_3.Text = "NULL";
                isUp_3 = false;
                isDown_3 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleUp_4_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStartDown_4)
            {
                isExecuteControlModel_4 = true;
                isExecutePIDModelDown_4 = true;
                digitalControlSingal_4 = 0;
                lowBalance_4 = true;
                this.btnStarPIDSingleUp_4.Text = "Stop";
                isFirstChangeUp_4 = true;
                isFirstChangeDown_4 = true;
                timerCount_4 = 0;
                beyondNum_4 = 0;
                longKeep_4 = false;
                isChangeParam_4 = false;
                upLine_4 = false;

                System.IO.File.AppendAllText("e:\\resultPID_4.txt", "升温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_4 = false;
                isExecutePIDModelDown_4 = false;
                this.btnStarPIDSingleUp_4.Text = "Start";
                lblPIDTestStatus_4.Text = "NULL";
                lblPIDTValue_4.Text = "NULL";
                isUp_4 = false;
                isDown_4 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleUp_5_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStartDown_5)
            {
                isExecuteControlModel_5 = true;
                isExecutePIDModelDown_5 = true;
                digitalControlSingal_5 = 0;
                lowBalance_5 = true;
                this.btnStarPIDSingleUp_5.Text = "Stop";
                isFirstChangeUp_5 = true;
                isFirstChangeDown_5 = true;
                timerCount_5 = 0;
                beyondNum_5 = 0;
                longKeep_5 = false;
                isChangeParam_5 = false;
                upLine_5 = false;
                System.IO.File.AppendAllText("e:\\resultPID_5.txt", "升温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_5 = false;
                isExecutePIDModelDown_5 = false;
                this.btnStarPIDSingleUp_5.Text = "Start";
                lblPIDTestStatus_5.Text = "NULL";
                lblPIDTValue_5.Text = "NULL";
                isUp_5 = false;
                isDown_5 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleUp_6_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStartDown_6)
            {
                isExecuteControlModel_6 = true;
                isExecutePIDModelDown_6 = true;
                digitalControlSingal_6 = 0;
                lowBalance_6 = true;
                this.btnStarPIDSingleUp_6.Text = "Stop";
                isFirstChangeUp_6 = true;
                isFirstChangeDown_6 = true;
                timerCount_6 = 0;
                beyondNum_6 = 0;
                longKeep_6 = false;
                isChangeParam_6 = false;
                upLine_6 = false;
                System.IO.File.AppendAllText("e:\\resultPID_6.txt", "升温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_6 = false;
                isExecutePIDModelDown_6 = false;
                this.btnStarPIDSingleUp_6.Text = "Start";
                lblPIDTestStatus_6.Text = "NULL";
                lblPIDTValue_6.Text = "NULL";
                isUp_6 = false;
                isDown_6 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleUp_7_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStartDown_7)
            {
                isExecuteControlModel_7 = true;
                isExecutePIDModelDown_7 = true;
                digitalControlSingal_7 = 0;
                lowBalance_7 = true;
                this.btnStarPIDSingleUp_7.Text = "Stop";
                isFirstChangeUp_7 = true;
                isFirstChangeDown_7 = true;
                timerCount_7 = 0;
                beyondNum_7 = 0;
                longKeep_7 = false;
                isChangeParam_7 = false;
                upLine_7 = false;
                System.IO.File.AppendAllText("e:\\resultPID_7.txt", "升温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_7 = false;
                isExecutePIDModelDown_7 = false;
                this.btnStarPIDSingleUp_7.Text = "Start";
                lblPIDTestStatus_7.Text = "NULL";
                lblPIDTValue_7.Text = "NULL";
                isUp_7 = false;
                isDown_7 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void btnStarPIDSingleUp_8_Click(object sender, EventArgs e)
        {
            if (isPIDBtnStartDown_8)
            {
                isExecuteControlModel_8 = true;
                isExecutePIDModelDown_8 = true;
                digitalControlSingal_8 = 0;
                lowBalance_8 = true;
                this.btnStarPIDSingleUp_8.Text = "Stop";
                isFirstChangeUp_8 = true;
                isFirstChangeDown_8 = true;
                timerCount_8 = 0;
                beyondNum_8 = 0;
                longKeep_8 = false;
                isChangeParam_8 = false;
                upLine_8 = false;
                System.IO.File.AppendAllText("e:\\resultPID_8.txt", "升温PID测试+++++++++++++++++++++++++++++" + "\r\n");
            }
            else
            {
                Board_1.clearALL();
                isExecuteControlModel_8 = false;
                isExecutePIDModelDown_8 = false;
                this.btnStarPIDSingleUp_8.Text = "Start";
                lblPIDTestStatus_8.Text = "NULL";
                lblPIDTValue_8.Text = "NULL";
                isUp_8 = false;
                isDown_8 = false;

            }

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
        }

        private void tpPID_Click(object sender, EventArgs e)
        {

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



            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);

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

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);
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

            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);

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


            punishmentT = float.Parse(tbPunishTValue.Text);
            confortableT = float.Parse(tbConfortTValue.Text);


            isExecuteControlModel_8 = true;
            isFirstChangeUp_8 = true;
            isFirstChangeDown_8 = true;
            
            timer_8.Start();
        }

        private void timer_2_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            int RawValue;

            temperatureValue_2 = Board_1.getT(2, out RawValue);
            lblRawData_2.Text = RawValue.ToString();

            lblTValue_2.Text = temperatureValue_2.ToString("00.00");

            if (temperatureValue_2 > 60 || temperatureValue_2 < 0)
            {
                Board_1.TNature(2);
                timer_2.Stop();
                lblTState_2.Text = "Error";
            }


            if (isExecutePIDModel_2 == true || isExecutePIDModelDown_2 == true)
            {
                lblPIDTValue_2.Text = temperatureValue_2.ToString("00.00");
            }


            if (isTestByHand_2 == false)
            {
                digitalControlSingal_2 = Board_2.getSingal(2);
            }

            if (isExecuteControlModel_2 == true)
            {
                if (digitalControlSingal_2 == 1 && isFirstChangeUp_2 == true)
                {
                    
                   
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
                    if (isExecutePIDModelDown_2)
                    {
                        PID_2 = new PIDControl(P_2, D_2, I_2, punishmentT);
                    }
                    else
                    {
                        PID_2 = new PIDControl(Kp_up_2, Ki_up_2, Kd_up_2, punishmentT);
                    }

                    System.IO.File.AppendAllText("e:\\result_2.txt", "惩罚：" + "Kp:" + Kp_up_2.ToString() + "  Ki" + Ki_up_2.ToString() + "  Kd" + Kp_up_2.ToString() + "\r\n");
                }
                else if (digitalControlSingal_2 == 0 && isFirstChangeDown_2 == true)
                {
                   
                 
                   
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
                    if (isExecutePIDModel_2)
                    {
                        PID_2 = new PIDControl(P_2, D_2, I_2, confortableT);
                    }
                    else
                    {
                        PID_2 = new PIDControl(Kp_down_2, Ki_down_2, Kd_down_2, confortableT);
                    }

                    System.IO.File.AppendAllText("e:\\result_2.txt", "舒适：" + "Kp:" + Kp_down_2.ToString() + "  Ki" + Ki_down_2.ToString() + "  Kd" + Kp_down_2.ToString() + "\r\n");
                }
                else
                {
                    ;
                }
            }



            /*
            * PID paramete test module
            */

            if (isExecutePIDModel_2 == true)
            {
                timerCount_2++;

                if (timerCount_2 == 300 && highBalance_2 == true)
                {
                    timerCount_2 = 0;
                    digitalControlSingal_2 = 0;
                    highBalance_2 = false;
                    downLine_2 = true;
                  
                }

                if (timerCount_2 == 150 && downLine_2)
                {
                    //System.IO.File.AppendAllText("e:\\result_2.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_2 = true;
                    downLine_2 = false;
                    timeNotAccept_2 = true;


                }

                if (temperatureValue_2 - confortableT <= 0.5 && downLine_2 == true)
                {
                    beyondNum_2++;
                    if (beyondNum_2 == 3)
                    {
                        timeResult_2 = timerCount_2;
                        timerCount_2 = 0;
                        downLine_2 = false;
                        longKeep_2 = true;
                        beyondNum_2 = 0;

                    }
                }

                if (longKeep_2 == true)
                {
                    tempCollection_2.Add(temperatureValue_2);
                    if (timerCount_2 == 300)
                    {
                        isChangeParam_2 = true;
                        longKeep_2 = false;
                    }

                }






                if (isChangeParam_2)
                {

                    if (timeNotAccept_2)
                    {
                        lblPIDTestStatus_2.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_2, I_2, D_2));
                        //System.IO.File.AppendAllText("e:\\result_2.txt", P_2 + "   " + I_2 + "   " + D_2 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_2;
                        resultAnalyse(tempCollection_2, P_2, I_2, D_2, out PID_Result_2,2);
                        tempCollection_2.Clear();
                        lblPIDTestStatus_2.Text = PID_Result_2;
                        //执行计算，然后输出
                    }
                    if (D_2 == 3)
                    {
                        timer_2.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_2.Text = "finished!";
                    }

                    digitalControlSingal_2 = 1;
                    isChangeParam_2 = false;
                    P_2 += 0.5;
                    if (P_2 == 10)
                    {
                        D_2 += 0.5;
                        P_2 = 0.5;
                    }


                    timerCount_2 = 0;
                    beyondNum_2 = 0;
                    highBalance_2 = true;
                }

            }



            if (isExecutePIDModelDown_2 == true)
            {
                timerCount_2++;

                if (timerCount_2 == 300 && lowBalance_2 == true)
                {
                    timerCount_2 = 0;
                    digitalControlSingal_2 = 1;
                    lowBalance_2 = false;
                    upLine_2 = true;
                    
                }

                if (timerCount_2 == 100 && upLine_2)
                {
                    //System.IO.File.AppendAllText("e:\\result_2.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_2 = true;
                    upLine_2 = false;
                    timeNotAccept_2 = true;


                }

                if (punishmentT - temperatureValue_2 <= 0.5 && upLine_2 == true)
                {
                    beyondNum_2++;
                    if (beyondNum_2 == 3)
                    {
                        timeResult_2 = timerCount_2;
                        timerCount_2 = 0;
                        upLine_2 = false;
                        longKeep_2 = true;
                        beyondNum_2 = 0;

                    }
                }

                if (longKeep_2 == true)
                {
                    tempCollection_2.Add(temperatureValue_2);
                    if (timerCount_2 == 300)
                    {
                        isChangeParam_2 = true;
                        longKeep_2 = false;
                    }

                }






                if (isChangeParam_2)
                {

                    if (timeNotAccept_2)
                    {
                        lblPIDTestStatus_2.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_2, I_2, D_2));
                        //System.IO.File.AppendAllText("e:\\result_2.txt", P_2 + "   " + I_2 + "   " + D_2 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_2;
                        resultAnalyse(tempCollection_2, P_2, I_2, D_2, out PID_Result_2, 2);
                        tempCollection_2.Clear();
                        lblPIDTestStatus_2.Text = PID_Result_2;
                        //执行计算，然后输出
                    }
                    if (D_2 == 10)
                    {
                        timer_2.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_2.Text = "Finished!";
                    }

                    digitalControlSingal_2 = 0;
                    isChangeParam_2 = false;
                    P_2 += 0.5;
                    if (P_2 == 10)
                    {
                        D_2 += 0.5;
                        P_2 = 0.5;
                    }


                    timerCount_2 = 0;
                    beyondNum_2 = 0;
                    lowBalance_2 = true;
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
                if (!isExecuteControlModel_2 || !isExecutePIDModelDown_2)
                {
                    System.IO.File.AppendAllText("e:\\result_2.txt", temperatureValue_2.ToString("00.00") + "\r\n");
                }
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

                if (!isExecuteControlModel_2 || !isExecutePIDModelDown_2)
                {
                    System.IO.File.AppendAllText("e:\\result_2.txt", temperatureValue_2.ToString("00.00") + "\r\n");
                }
            }
        }

        private void timer_3_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            int RawValue;

            temperatureValue_3 = Board_1.getT(3, out RawValue);
            lblRawData_3.Text = RawValue.ToString();


            lblTValue_3.Text = temperatureValue_3.ToString("00.00");

            if (temperatureValue_3 > 60 || temperatureValue_3 < 0)
            {
                Board_1.TNature(3);
                timer_3.Stop();
                lblTState_3.Text = "Error";
            }

            if (isExecutePIDModel_3 == true || isExecutePIDModelDown_3 == true)
            {
                lblPIDTValue_3.Text = temperatureValue_3.ToString("00.00");
            }


            if (isTestByHand_3 == false)
            {
                digitalControlSingal_3 = Board_2.getSingal(3);
            }


            if (isExecuteControlModel_3 == true)
            {
                if (digitalControlSingal_3 == 1 && isFirstChangeUp_3 == true)
                {
                    
                    
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
                    if (isExecutePIDModelDown_3)
                    {
                        PID_3 = new PIDControl(P_3, D_3, I_3, punishmentT);
                    }
                    else
                    {
                        PID_3 = new PIDControl(Kp_up_3, Ki_up_3, Kd_up_3, punishmentT);
                    }

                    System.IO.File.AppendAllText("e:\\result_3.txt", "惩罚：" + "Kp:" + Kp_up_3.ToString() + "  Ki" + Ki_up_3.ToString() + "  Kd" + Kp_up_3.ToString() + "\r\n");
                }
                else if (digitalControlSingal_3 == 0 && isFirstChangeDown_3 == true)
                {
                   
                    
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
                    if (isExecutePIDModel_3)
                    {
                        PID_3 = new PIDControl(P_3, D_3, I_3, confortableT);
                    }
                    else
                    {
                        PID_3 = new PIDControl(Kp_down_3, Ki_down_3, Kd_down_3, confortableT);
                    }

                    System.IO.File.AppendAllText("e:\\result_3.txt", "舒适：" + "Kp:" + Kp_down_3.ToString() + "  Ki" + Ki_down_3.ToString() + "  Kd" + Kp_down_3.ToString() + "\r\n");
                }
                else
                {
                    ;
                }
            }



            /*
            * PID paramete test module
            */

            if (isExecutePIDModel_3 == true)
            {
                timerCount_3++;

                if (timerCount_3 == 300 && highBalance_3 == true)
                {
                    timerCount_3 = 0;
                    digitalControlSingal_3 = 0;
                    highBalance_3 = false;
                    downLine_3 = true;
                   
                }

                if (timerCount_3 == 150 && downLine_3)
                {
                    //System.IO.File.AppendAllText("e:\\result_3.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_3 = true;
                    downLine_3 = false;
                    timeNotAccept_3 = true;


                }

                if (temperatureValue_3 - confortableT <= 0.5 && downLine_3 == true)
                {
                    beyondNum_3++;
                    if (beyondNum_3 == 3)
                    {
                        timeResult_3 = timerCount_3;
                        timerCount_3 = 0;
                        downLine_3 = false;
                        longKeep_3 = true;
                        beyondNum_3 = 0;

                    }
                }

                if (longKeep_3 == true)
                {
                    tempCollection_3.Add(temperatureValue_3);
                    if (timerCount_3 == 300)
                    {
                        isChangeParam_3 = true;
                        longKeep_3 = false;
                    }

                }






                if (isChangeParam_3)
                {

                    if (timeNotAccept_3)
                    {
                        lblPIDTestStatus_3.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_3, I_3, D_3));
                       // System.IO.File.AppendAllText("e:\\result_3.txt", P_3 + "   " + I_3 + "   " + D_3 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_3;
                        resultAnalyse(tempCollection_3, P_3, I_3, D_3, out PID_Result_3,3);
                        tempCollection_3.Clear();
                        lblPIDTestStatus_3.Text = PID_Result_3;
                        //执行计算，然后输出
                    }
                    if (D_3 == 3)
                    {
                        timer_3.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_3.Text = "finished!";
                    }

                    digitalControlSingal_3 = 1;
                    isChangeParam_3 = false;
                    P_3 += 0.5;
                    if (P_3 == 10)
                    {
                        D_3 += 0.5;
                        P_3 = 0.5;
                    }


                    timerCount_3 = 0;
                    beyondNum_3 = 0;
                    highBalance_3 = true;
                }

            }


            if (isExecutePIDModelDown_3 == true)
            {
                timerCount_3++;

                if (timerCount_3 == 300 && lowBalance_3 == true)
                {
                    timerCount_3 = 0;
                    digitalControlSingal_3 = 1;
                    lowBalance_3 = false;
                    upLine_3 = true;
                   
                }

                if (timerCount_3 == 100 && upLine_3)
                {
                    //System.IO.File.AppendAllText("e:\\result_3.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_3 = true;
                    upLine_3 = false;
                    timeNotAccept_3 = true;


                }

                if (punishmentT - temperatureValue_3 <= 0.5 && upLine_3 == true)
                {
                    beyondNum_3++;
                    if (beyondNum_3 == 3)
                    {
                        timeResult_3 = timerCount_3;
                        timerCount_3 = 0;
                        upLine_3 = false;
                        longKeep_3 = true;
                        beyondNum_3 = 0;

                    }
                }

                if (longKeep_3 == true)
                {
                    tempCollection_3.Add(temperatureValue_3);
                    if (timerCount_3 == 300)
                    {
                        isChangeParam_3 = true;
                        longKeep_3 = false;
                    }

                }






                if (isChangeParam_3)
                {

                    if (timeNotAccept_3)
                    {
                        lblPIDTestStatus_3.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_3, I_3, D_3));
                        //System.IO.File.AppendAllText("e:\\result_3.txt", P_3 + "   " + I_3 + "   " + D_3 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_3;
                        resultAnalyse(tempCollection_3, P_3, I_3, D_3, out PID_Result_3, 3);
                        tempCollection_3.Clear();
                        lblPIDTestStatus_3.Text = PID_Result_3;
                        //执行计算，然后输出
                    }
                    if (D_3 == 10)
                    {
                        timer_3.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_3.Text = "Finished!";
                    }

                    digitalControlSingal_3 = 0;
                    isChangeParam_3 = false;
                    P_3 += 0.5;
                    if (P_3 == 10)
                    {
                        D_3 += 0.5;
                        P_3 = 0.5;
                    }


                    timerCount_3 = 0;
                    beyondNum_3 = 0;
                    lowBalance_3 = true;
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

                if (!isExecuteControlModel_3 || !isExecutePIDModelDown_3)
                {
                    System.IO.File.AppendAllText("e:\\result_3.txt", temperatureValue_3.ToString("00.00") + "\r\n");
                }
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

                if (!isExecuteControlModel_3 || !isExecutePIDModelDown_3)
                {
                    System.IO.File.AppendAllText("e:\\result_3.txt", temperatureValue_3.ToString("00.00") + "\r\n");
                }
            }
        }

        private void timer_4_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            int RawValue;

            temperatureValue_4 = Board_1.getT(4, out RawValue);
            lblRawData_4.Text = RawValue.ToString();


            lblTValue_4.Text = temperatureValue_4.ToString("00.00");
            if (temperatureValue_4 > 60 || temperatureValue_4 < 0)
            {
                Board_1.TNature(4);
                timer_4.Stop();
                lblTState_4.Text = "Error";
            }

            if (isExecutePIDModel_4 == true || isExecutePIDModelDown_4 == true)
            {
                lblPIDTValue_4.Text = temperatureValue_4.ToString("00.00");
            }


            if (isTestByHand_4 == false)
            {
                digitalControlSingal_4 = Board_2.getSingal(4);
            }

            if (isExecuteControlModel_4 == true)
            {
                if (digitalControlSingal_4 == 1 && isFirstChangeUp_4 == true)
                {
                   
                   
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
                    if (isExecutePIDModelDown_4)
                    {
                        PID_4 = new PIDControl(P_4, D_4, I_4, punishmentT);
                    }
                    else
                    {
                        PID_4 = new PIDControl(Kp_up_4, Ki_up_4, Kd_up_4, punishmentT);
                    }

                    System.IO.File.AppendAllText("e:\\result_4.txt", "惩罚：" + "Kp:" + Kp_up_4.ToString() + "  Ki" + Ki_up_4.ToString() + "  Kd" + Kp_up_4.ToString() + "\r\n");
                }
                else if (digitalControlSingal_4 == 0 && isFirstChangeDown_4 == true)
                {
                   
                   
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
                    if (isExecutePIDModel_4)
                    {
                        PID_4 = new PIDControl(P_4, D_4, I_4, confortableT);
                    }
                    else
                    {
                        PID_4 = new PIDControl(Kp_down_4, Ki_down_4, Kd_down_4, confortableT);
                    }

                    System.IO.File.AppendAllText("e:\\result_4.txt", "舒适：" + "Kp:" + Kp_down_4.ToString() + "  Ki" + Ki_down_4.ToString() + "  Kd" + Kp_down_4.ToString() + "\r\n");
                }
                else
                {
                    ;
                }
            }


            /*
            * PID paramete test module
            */

            if (isExecutePIDModel_4 == true)
            {
                timerCount_4++;

                if (timerCount_4 == 300 && highBalance_4 == true)
                {
                    timerCount_4 = 0;
                    digitalControlSingal_4 = 0;
                    highBalance_4 = false;
                    downLine_4 = true;
                   
                }

                if (timerCount_4 == 150 && downLine_4)
                {
                    //System.IO.File.AppendAllText("e:\\result_4.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_4 = true;
                    downLine_4 = false;
                    timeNotAccept_4 = true;


                }

                if (temperatureValue_4 - confortableT <= 0.5 && downLine_4 == true)
                {
                    beyondNum_4++;
                    if (beyondNum_4 == 3)
                    {
                        timeResult_4 = timerCount_4;
                        timerCount_4 = 0;
                        downLine_4 = false;
                        longKeep_4 = true;
                        beyondNum_4 = 0;

                    }
                }

                if (longKeep_4 == true)
                {
                    tempCollection_4.Add(temperatureValue_4);
                    if (timerCount_4 == 300)
                    {
                        isChangeParam_4 = true;
                        longKeep_4 = false;
                    }

                }






                if (isChangeParam_4)
                {

                    if (timeNotAccept_4)
                    {
                        lblPIDTestStatus_4.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_4, I_4, D_4));
                        //System.IO.File.AppendAllText("e:\\result_4.txt", P_4 + "   " + I_4 + "   " + D_4 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_4;
                        resultAnalyse(tempCollection_4, P_4, I_4, D_4, out PID_Result_4,4);
                        tempCollection_4.Clear();
                        lblPIDTestStatus_4.Text = PID_Result_4;
                        //执行计算，然后输出
                    }
                    if (D_4 == 3)
                    {
                        timer_4.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_4.Text = "finished!";
                    }

                    digitalControlSingal_4 = 1;
                    isChangeParam_4 = false;
                    P_4 += 0.5;
                    if (P_4 == 10)
                    {
                        D_4 += 0.5;
                        P_4 = 0.5;
                    }


                    timerCount_4 = 0;
                    beyondNum_4 = 0;
                    highBalance_4 = true;
                }

            }


            if (isExecutePIDModelDown_4 == true)
            {
                timerCount_4++;

                if (timerCount_4 == 300 && lowBalance_4 == true)
                {
                    timerCount_4 = 0;
                    digitalControlSingal_4 = 1;
                    lowBalance_4 = false;
                    upLine_4 = true;
                    
                }

                if (timerCount_4 == 100 && upLine_4)
                {
                    //System.IO.File.AppendAllText("e:\\result_4.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_4 = true;
                    upLine_4 = false;
                    timeNotAccept_4 = true;


                }

                if (punishmentT - temperatureValue_4 <= 0.5 && upLine_4 == true)
                {
                    beyondNum_4++;
                    if (beyondNum_4 == 3)
                    {
                        timeResult_4 = timerCount_4;
                        timerCount_4 = 0;
                        upLine_4 = false;
                        longKeep_4 = true;
                        beyondNum_4 = 0;

                    }
                }

                if (longKeep_4 == true)
                {
                    tempCollection_4.Add(temperatureValue_4);
                    if (timerCount_4 == 300)
                    {
                        isChangeParam_4 = true;
                        longKeep_4 = false;
                    }

                }






                if (isChangeParam_4)
                {

                    if (timeNotAccept_4)
                    {
                        lblPIDTestStatus_4.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_4, I_4, D_4));
                        //System.IO.File.AppendAllText("e:\\result_4.txt", P_4 + "   " + I_4 + "   " + D_4 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_4;
                        resultAnalyse(tempCollection_4, P_4, I_4, D_4, out PID_Result_4, 4);
                        tempCollection_4.Clear();
                        lblPIDTestStatus_4.Text = PID_Result_4;
                        //执行计算，然后输出
                    }
                    if (D_4 == 10)
                    {
                        timer_4.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_4.Text = "Finished!";
                    }

                    digitalControlSingal_4 = 0;
                    isChangeParam_4 = false;
                    P_4 += 0.5;
                    if (P_4 == 10)
                    {
                        D_4 += 0.5;
                        P_4 = 0.5;
                    }


                    timerCount_4 = 0;
                    beyondNum_4 = 0;
                    lowBalance_4 = true;
                }

            }



            if (isUp_4 == true)
            {
                if ((punishmentT - temperatureValue_4) < 10 && isStartPID_4 == true)
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

                if (!isExecuteControlModel_4 || !isExecutePIDModelDown_4)
                {
                    System.IO.File.AppendAllText("e:\\result_4.txt", temperatureValue_4.ToString("00.00") + "\r\n");
                }
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
                if (!isExecuteControlModel_4 || !isExecutePIDModelDown_4)
                {
                    System.IO.File.AppendAllText("e:\\result_4.txt", temperatureValue_4.ToString("00.00") + "\r\n");
                }
            }
        }

        private void timer_5_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            int RawValue;

            temperatureValue_5 = Board_2.getT(5, out RawValue);
            lblRawData_5.Text = RawValue.ToString();


            lblTValue_5.Text = temperatureValue_5.ToString("00.00");
            if (temperatureValue_5 > 60 || temperatureValue_5 < 0)
            {
                Board_1.TNature(5);
                timer_5.Stop();
                lblTState_5.Text = "Error";
            }

            if (isExecutePIDModel_5 == true || isExecutePIDModelDown_5 == true)
            {
                lblPIDTValue_5.Text = temperatureValue_5.ToString("00.00");
            }

            if (isTestByHand_5 == false)
            {
                digitalControlSingal_5 = Board_2.getSingal(5);
            }

            if (isExecuteControlModel_5 == true)
            {
                if (digitalControlSingal_5 == 1 && isFirstChangeUp_5 == true)
                {
                   
                    
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
                    if (isExecutePIDModelDown_5)
                    {
                        PID_5 = new PIDControl(P_5, D_5, I_5, punishmentT);
                    }
                    else
                    {
                        PID_5 = new PIDControl(Kp_up_5, Ki_up_5, Kd_up_5, punishmentT);
                    }

                    System.IO.File.AppendAllText("e:\\result_5.txt", "惩罚：" + "Kp:" + Kp_up_5.ToString() + "  Ki" + Ki_up_5.ToString() + "  Kd" + Kp_up_5.ToString() + "\r\n");
                }
                else if (digitalControlSingal_5 == 0 && isFirstChangeDown_5 == true)
                {
                   
                    
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
                    if (isExecutePIDModel_5)
                    {
                        PID_5 = new PIDControl(P_5, D_5, I_5, confortableT);
                    }
                    else
                    {
                        PID_5 = new PIDControl(Kp_down_5, Ki_down_5, Kd_down_5, confortableT);
                    }

                    System.IO.File.AppendAllText("e:\\result_5.txt", "舒适：" + "Kp:" + Kp_down_5.ToString() + "  Ki" + Ki_down_5.ToString() + "  Kd" + Kp_down_5.ToString() + "\r\n");
                }
                else
                {
                    ;
                }
            }




            /*
            * PID paramete test module
            */

            if (isExecutePIDModel_5 == true)
            {
                timerCount_5++;

                if (timerCount_5 == 300 && highBalance_5 == true)
                {
                    timerCount_5 = 0;
                    digitalControlSingal_5 = 0;
                    highBalance_5 = false;
                    downLine_5 = true;
                  
                }

                if (timerCount_5 ==150 && downLine_5)
                {
                    //System.IO.File.AppendAllText("e:\\result_5.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_5 = true;
                    downLine_5 = false;
                    timeNotAccept_5 = true;


                }

                if (temperatureValue_5 - confortableT <= 0.5 && downLine_5 == true)
                {
                    beyondNum_5++;
                    if (beyondNum_5 == 3)
                    {
                        timeResult_5 = timerCount_5;
                        timerCount_5 = 0;
                        downLine_5 = false;
                        longKeep_5 = true;
                        beyondNum_5 = 0;

                    }
                }

                if (longKeep_5 == true)
                {
                    tempCollection_5.Add(temperatureValue_5);
                    if (timerCount_5 == 300)
                    {
                        isChangeParam_5 = true;
                        longKeep_5 = false;
                    }

                }






                if (isChangeParam_5)
                {

                    if (timeNotAccept_5)
                    {
                        lblPIDTestStatus_5.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_5, I_5, D_5));
                        //System.IO.File.AppendAllText("e:\\result_5.txt", P_5 + "   " + I_5 + "   " + D_5 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_5;
                        resultAnalyse(tempCollection_5, P_5, I_5, D_5, out PID_Result_5,5);
                        tempCollection_5.Clear();
                        lblPIDTestStatus_5.Text = PID_Result_5;
                        //执行计算，然后输出
                    }
                    if (D_5 == 3)
                    {
                        timer_5.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_5.Text = "finished!";
                    }

                    digitalControlSingal_5 = 1;
                    isChangeParam_5 = false;
                    P_5 += 0.5;
                    if (P_5 == 10)
                    {
                        D_5 += 0.5;
                        P_5 = 0.5;
                    }


                    timerCount_5 = 0;
                    beyondNum_5 = 0;
                    highBalance_5 = true;
                }

            }



            if (isExecutePIDModelDown_5 == true)
            {
                timerCount_5++;

                if (timerCount_5 == 300 && lowBalance_5 == true)
                {
                    timerCount_5 = 0;
                    digitalControlSingal_5 = 1;
                    lowBalance_5 = false;
                    upLine_5 = true;
                   
                }

                if (timerCount_5 == 100 && upLine_5)
                {
                    //System.IO.File.AppendAllText("e:\\result_5.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_5 = true;
                    upLine_5 = false;
                    timeNotAccept_5 = true;


                }

                if (punishmentT - temperatureValue_5 <= 0.5 && upLine_5 == true)
                {
                    beyondNum_5++;
                    if (beyondNum_5 == 3)
                    {
                        timeResult_5 = timerCount_5;
                        timerCount_5 = 0;
                        upLine_5 = false;
                        longKeep_5 = true;
                        beyondNum_5 = 0;

                    }
                }

                if (longKeep_5 == true)
                {
                    tempCollection_5.Add(temperatureValue_5);
                    if (timerCount_5 == 300)
                    {
                        isChangeParam_5 = true;
                        longKeep_5 = false;
                    }

                }






                if (isChangeParam_5)
                {

                    if (timeNotAccept_5)
                    {
                        lblPIDTestStatus_5.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_5, I_5, D_5));
                        //System.IO.File.AppendAllText("e:\\result_5.txt", P_5 + "   " + I_5 + "   " + D_5 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_5;
                        resultAnalyse(tempCollection_5, P_5, I_5, D_5, out PID_Result_5, 5);
                        tempCollection_5.Clear();
                        lblPIDTestStatus_5.Text = PID_Result_5;
                        //执行计算，然后输出
                    }
                    if (D_5 == 10)
                    {
                        timer_5.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_5.Text = "Finished!";
                    }

                    digitalControlSingal_5 = 0;
                    isChangeParam_5 = false;
                    P_5 += 0.5;
                    if (P_5 == 10)
                    {
                        D_5 += 0.5;
                        P_5 = 0.5;
                    }


                    timerCount_5 = 0;
                    beyondNum_5 = 0;
                    lowBalance_5 = true;
                }

            }





            if (isUp_5 == true)
            {
                if ((punishmentT - temperatureValue_5) < 10 && isStartPID_5 == true)
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

                if (!isExecuteControlModel_5 || !isExecutePIDModelDown_5)
                {
                    System.IO.File.AppendAllText("e:\\result_5.txt", temperatureValue_5.ToString("00.00") + "\r\n");
                }
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

                if (!isExecuteControlModel_5 || !isExecutePIDModelDown_5)
                {
                    System.IO.File.AppendAllText("e:\\result_5.txt", temperatureValue_5.ToString("00.00") + "\r\n");
                }
            }
        }

        private void timer_6_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            int RawValue;

            temperatureValue_6 = Board_2.getT(6, out RawValue);
            lblRawData_6.Text = RawValue.ToString();

            lblTValue_6.Text = temperatureValue_6.ToString("00.00");

            if (temperatureValue_6 > 60 || temperatureValue_6 < 0)
            {
                Board_1.TNature(6);
                timer_6.Stop();
                lblTState_6.Text = "Error";
            }
            if (isExecutePIDModel_6 == true || isExecutePIDModelDown_6 == true)
            {
                lblPIDTValue_6.Text = temperatureValue_6.ToString("00.00");
            }


            if (isTestByHand_6 == false)
            {
                digitalControlSingal_6 = Board_2.getSingal(6);
            }

            if (isExecuteControlModel_6 == true)
            {
                if (digitalControlSingal_6 == 1 && isFirstChangeUp_6 == true)
                {
                   
                    
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
                    if (isExecutePIDModelDown_6)
                    {
                        PID_6 = new PIDControl(P_6, D_6, I_6, punishmentT);
                    }
                    else
                    {
                        PID_6 = new PIDControl(Kp_up_6, Ki_up_6, Kd_up_6, punishmentT);
                    }

                    System.IO.File.AppendAllText("e:\\result_6.txt", "惩罚：" + "Kp:" + Kp_up_6.ToString() + "  Ki" + Ki_up_6.ToString() + "  Kd" + Kp_up_6.ToString() + "\r\n");
                }
                else if (digitalControlSingal_6 == 0 && isFirstChangeDown_6 == true)
                {
                   
                   
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
                    if (isExecutePIDModel_6)
                    {
                        PID_6 = new PIDControl(P_6, D_6, I_6, confortableT);
                    }
                    else
                    {
                        PID_6 = new PIDControl(Kp_down_6, Ki_down_6, Kd_down_6, confortableT);
                    }

                    System.IO.File.AppendAllText("e:\\result_6.txt", "舒适：" + "Kp:" + Kp_down_6.ToString() + "  Ki" + Ki_down_6.ToString() + "  Kd" + Kp_down_6.ToString() + "\r\n");
                }
                else
                {
                    ;
                }
            }



            /*
            * PID paramete test module
            */

            if (isExecutePIDModel_6 == true)
            {
                timerCount_6++;

                if (timerCount_6 == 300 && highBalance_6 == true)
                {
                    timerCount_6 = 0;
                    digitalControlSingal_6 = 0;
                    highBalance_6 = false;
                    downLine_6 = true;
                   
                }

                if (timerCount_6 == 150 && downLine_6)
                {
                    //System.IO.File.AppendAllText("e:\\result_6.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_6 = true;
                    downLine_6 = false;
                    timeNotAccept_6 = true;


                }

                if (temperatureValue_6 - confortableT <= 0.5 && downLine_6 == true)
                {
                    beyondNum_6++;
                    if (beyondNum_6 == 3)
                    {
                        timeResult_6 = timerCount_6;
                        timerCount_6 = 0;
                        downLine_6 = false;
                        longKeep_6 = true;
                        beyondNum_6 = 0;

                    }
                }

                if (longKeep_6 == true)
                {
                    tempCollection_6.Add(temperatureValue_6);
                    if (timerCount_6 == 300)
                    {
                        isChangeParam_6 = true;
                        longKeep_6 = false;
                    }

                }






                if (isChangeParam_6)
                {

                    if (timeNotAccept_6)
                    {
                        lblPIDTestStatus_6.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_6, I_6, D_6));
                        //System.IO.File.AppendAllText("e:\\result_6.txt", P_6 + "   " + I_6 + "   " + D_6 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_6;
                        resultAnalyse(tempCollection_6, P_6, I_6, D_6, out PID_Result_6,6);
                        tempCollection_6.Clear();
                        lblPIDTestStatus_6.Text = PID_Result_6;
                        //执行计算，然后输出
                    }
                    if (D_6 == 3)
                    {
                        timer_6.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_6.Text = "finished!";
                    }

                    digitalControlSingal_6 = 1;
                    isChangeParam_6 = false;
                    P_6 += 0.5;
                    if (P_6 == 10)
                    {
                        D_6 += 0.5;
                        P_6 = 0.5;
                    }


                    timerCount_6 = 0;
                    beyondNum_6 = 0;
                    highBalance_6 = true;
                }

            }


            if (isExecutePIDModelDown_6 == true)
            {
                timerCount_6++;

                if (timerCount_6 == 300 && lowBalance_6 == true)
                {
                    timerCount_6 = 0;
                    digitalControlSingal_6 = 1;
                    lowBalance_6 = false;
                    upLine_6 = true;
                    
                }

                if (timerCount_6 == 100 && upLine_6)
                {
                    //System.IO.File.AppendAllText("e:\\result_6.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_6 = true;
                    upLine_6 = false;
                    timeNotAccept_6 = true;


                }

                if (punishmentT - temperatureValue_6 <= 0.5 && upLine_6 == true)
                {
                    beyondNum_6++;
                    if (beyondNum_6 == 3)
                    {
                        timeResult_6 = timerCount_6;
                        timerCount_6 = 0;
                        upLine_6 = false;
                        longKeep_6 = true;
                        beyondNum_6 = 0;

                    }
                }

                if (longKeep_6 == true)
                {
                    tempCollection_6.Add(temperatureValue_6);
                    if (timerCount_6 == 300)
                    {
                        isChangeParam_6 = true;
                        longKeep_6 = false;
                    }

                }






                if (isChangeParam_6)
                {

                    if (timeNotAccept_6)
                    {
                        lblPIDTestStatus_6.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_6, I_6, D_6));
                        //System.IO.File.AppendAllText("e:\\result_6.txt", P_6 + "   " + I_6 + "   " + D_6 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_6;
                        resultAnalyse(tempCollection_6, P_6, I_6, D_6, out PID_Result_6, 6);
                        tempCollection_6.Clear();
                        lblPIDTestStatus_6.Text = PID_Result_6;
                        //执行计算，然后输出
                    }
                    if (D_6 == 10)
                    {
                        timer_6.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_6.Text = "Finished!";
                    }

                    digitalControlSingal_6 = 0;
                    isChangeParam_6 = false;
                    P_6 += 0.5;
                    if (P_6 == 10)
                    {
                        D_6 += 0.5;
                        P_6 = 0.5;
                    }


                    timerCount_6 = 0;
                    beyondNum_6 = 0;
                    lowBalance_6 = true;
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

                if (!isExecuteControlModel_6 || !isExecutePIDModelDown_6)
                {
                    System.IO.File.AppendAllText("e:\\result_6.txt", temperatureValue_6.ToString("00.00") + "\r\n");
                }
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

                if (!isExecuteControlModel_6 || !isExecutePIDModelDown_6)
                {
                    System.IO.File.AppendAllText("e:\\result_6.txt", temperatureValue_6.ToString("00.00") + "\r\n");
                }
            }
        }

        private void timer_7_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            int RawValue;

            temperatureValue_7 = Board_2.getT(7, out RawValue);
            lblRawData_7.Text = RawValue.ToString();

            lblTValue_7.Text = temperatureValue_7.ToString("00.00");

            if (temperatureValue_7 > 60 || temperatureValue_7 < 0)
            {
                Board_1.TNature(7);
                timer_7.Stop();
                lblTState_7.Text = "Error";
            }
            if (isExecutePIDModel_7 == true || isExecutePIDModelDown_7 == true)
            {
                lblPIDTValue_7.Text = temperatureValue_7.ToString("00.00");
            }


            if (isTestByHand_7 == false)
            {
                digitalControlSingal_7 = Board_2.getSingal(7);
            }

            if (isExecuteControlModel_7 == true)
            {
                if (digitalControlSingal_7 == 1 && isFirstChangeUp_7 == true)
                {

                   
                    lblTState_7.Text = "On";

                    isUp_7 = true;
                    isDown_7 = false;

                    isStartPID_7 = true;
                    PID_Count_7 = 0;
                    isFirstChangeUp_7 = false;
                    isFirstChangeDown_7 = true;
                    //isFirstPor = true;
                    Board_1.TUp(7);
                    startPID_7 = false;
                    circle = 10;
                    if (isExecutePIDModelDown_7)
                    {
                        PID_7 = new PIDControl(P_7, D_7, I_7, punishmentT);
                    }
                    else
                    {
                        PID_7 = new PIDControl(Kp_up_7, Ki_up_7, Kd_up_7, punishmentT);
                    }

                    System.IO.File.AppendAllText("e:\\result_7.txt", "惩罚：" + "Kp:" + Kp_up_7.ToString() + "  Ki" + Ki_up_7.ToString() + "  Kd" + Kp_up_7.ToString() + "\r\n");
                }
                else if (digitalControlSingal_7 == 0 && isFirstChangeDown_7 == true)
                {

                    
                    isDown_7 = true;
                    isStartPID_7 = true;
                    isFirstChangeDown_7 = false;
                    isFirstChangeUp_7 = true;
                    startPID_7 = false;
                    isUp_7 = false;
                    PID_Count_7 = 0;
                    lblTState_7.Text = "Off";
                    Board_1.TDown(7);
                    circle = 10;
                    if (isExecutePIDModel_7)
                    {
                        PID_7 = new PIDControl(P_7, D_7, I_7, confortableT);
                    }
                    else
                    {
                        PID_7 = new PIDControl(Kp_down_7, Ki_down_7, Kd_down_7, confortableT);
                    }

                    System.IO.File.AppendAllText("e:\\result_7.txt", "舒适：" + "Kp:" + Kp_down_7.ToString() + "  Ki" + Ki_down_7.ToString() + "  Kd" + Kp_down_7.ToString() + "\r\n");
                }
                else
                {
                    ;
                }
            }




            /*
            * PID paramete test module
            */

            if (isExecutePIDModel_7 == true)
            {
                timerCount_7++;

                if (timerCount_7 == 300 && highBalance_7 == true)
                {
                    timerCount_7 = 0;
                    digitalControlSingal_7 = 0;
                    highBalance_7 = false;
                    downLine_7 = true;
                  
                }

                if (timerCount_7 == 150 && downLine_7)
                {
                    //System.IO.File.AppendAllText("e:\\result_7.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_7 = true;
                    downLine_7 = false;
                    timeNotAccept_7 = true;


                }

                if (temperatureValue_7 - confortableT <= 0.5 && downLine_7 == true)
                {
                    beyondNum_7++;
                    if (beyondNum_7 == 3)
                    {
                        timeResult_7 = timerCount_7;
                        timerCount_7 = 0;
                        downLine_7 = false;
                        longKeep_7 = true;
                        beyondNum_7 = 0;

                    }
                }

                if (longKeep_7 == true)
                {
                    tempCollection_7.Add(temperatureValue_7);
                    if (timerCount_7 == 300)
                    {
                        isChangeParam_7 = true;
                        longKeep_7 = false;
                    }

                }






                if (isChangeParam_7)
                {

                    if (timeNotAccept_7)
                    {
                        lblPIDTestStatus_7.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_7, I_7, D_7));
                        //System.IO.File.AppendAllText("e:\\result_7.txt", P_7 + "   " + I_7 + "   " + D_7 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_7;
                        resultAnalyse(tempCollection_7, P_7, I_7, D_7, out PID_Result_7,7);
                        tempCollection_7.Clear();
                        lblPIDTestStatus_7.Text = PID_Result_7;
                        //执行计算，然后输出
                    }
                    if (D_7 == 3)
                    {
                        timer_7.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_7.Text = "finished!";
                    }

                    digitalControlSingal_7 = 1;
                    isChangeParam_7 = false;
                    P_7 += 0.5;
                    if (P_7 == 10)
                    {
                        D_7 += 0.5;
                        P_7 = 0.5;
                    }


                    timerCount_7 = 0;
                    beyondNum_7 = 0;
                    highBalance_7 = true;
                }

            }


            if (isExecutePIDModelDown_7 == true)
            {
                timerCount_7++;

                if (timerCount_7 == 300 && lowBalance_7 == true)
                {
                    timerCount_7 = 0;
                    digitalControlSingal_7 = 1;
                    lowBalance_7 = false;
                    upLine_7 = true;
                   
                }

                if (timerCount_7 == 100 && upLine_7)
                {
                    //System.IO.File.AppendAllText("e:\\result_7.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_7 = true;
                    upLine_7 = false;
                    timeNotAccept_7 = true;


                }

                if (punishmentT - temperatureValue_7 <= 0.5 && upLine_7 == true)
                {
                    beyondNum_7++;
                    if (beyondNum_7 == 3)
                    {
                        timeResult_7 = timerCount_7;
                        timerCount_7 = 0;
                        upLine_7 = false;
                        longKeep_7 = true;
                        beyondNum_7 = 0;

                    }
                }

                if (longKeep_7 == true)
                {
                    tempCollection_7.Add(temperatureValue_7);
                    if (timerCount_7 == 300)
                    {
                        isChangeParam_7 = true;
                        longKeep_7 = false;
                    }

                }






                if (isChangeParam_7)
                {

                    if (timeNotAccept_7)
                    {
                        lblPIDTestStatus_7.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_7, I_7, D_7));
                        //System.IO.File.AppendAllText("e:\\result_7.txt", P_7 + "   " + I_7 + "   " + D_7 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_7;
                        resultAnalyse(tempCollection_7, P_7, I_7, D_7, out PID_Result_7, 7);
                        tempCollection_7.Clear();
                        lblPIDTestStatus_7.Text = PID_Result_7;
                        //执行计算，然后输出
                    }
                    if (D_7 == 10)
                    {
                        timer_7.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_7.Text = "Finished!";
                    }

                    digitalControlSingal_7 = 0;
                    isChangeParam_7 = false;
                    P_7 += 0.5;
                    if (P_7 == 10)
                    {
                        D_7 += 0.5;
                        P_7 = 0.5;
                    }


                    timerCount_7 = 0;
                    beyondNum_7 = 0;
                    lowBalance_7 = true;
                }

            }



            if (isUp_7 == true)
            {
                if ((punishmentT - temperatureValue_7) < 7 && isStartPID_7 == true)
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

                if (!isExecuteControlModel_7 || !isExecutePIDModelDown_7)
                {
                    System.IO.File.AppendAllText("e:\\result_7.txt", temperatureValue_7.ToString("00.00") + "\r\n");
                }
            }


            if (isDown_7 == true)
            {
                if ((temperatureValue_7 - confortableT) < 7 && isStartPID_7 == true)
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

                if (!isExecuteControlModel_7 || !isExecutePIDModelDown_7)
                {
                    System.IO.File.AppendAllText("e:\\result_7.txt", temperatureValue_7.ToString("00.00") + "\r\n");
                }
            }
        }

        private void timer_8_Tick(object sender, EventArgs e)
        {
            //digitalControlSingal_1 = GC.getSingal(1);
            //lblTState_1.Text = digitalControlSingal_1 == 1 ? "On" : "OFF";

            int RawValue;

            temperatureValue_8 = Board_2.getT(8, out RawValue);
            lblRawData_8.Text = RawValue.ToString();

            lblTValue_8.Text = temperatureValue_8.ToString("00.00");
            if (temperatureValue_8 > 60 || temperatureValue_8 < 0)
            {
                Board_1.TNature(8);
                timer_8.Stop();
                lblTState_8.Text = "Error";
            }

            if (isExecutePIDModel_8 == true || isExecutePIDModelDown_8 == true)
            {
                lblPIDTValue_8.Text = temperatureValue_8.ToString("00.00");
            }



            if (isTestByHand_8 == false)
            {
                digitalControlSingal_8 = Board_2.getSingal(8);
            }

            if (isExecuteControlModel_8 == true)
            {
                if (digitalControlSingal_8 == 1 && isFirstChangeUp_8 == true)
                {
                  
                    
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
                    if (isExecutePIDModelDown_8)
                    {
                        PID_8 = new PIDControl(P_8, D_8, I_8, punishmentT);
                    }
                    else
                    {
                        PID_8 = new PIDControl(Kp_up_8, Ki_up_8, Kd_up_8, punishmentT);
                    }

                    System.IO.File.AppendAllText("e:\\result_8.txt", "惩罚：" + "Kp:" + Kp_up_8.ToString() + "  Ki" + Ki_up_8.ToString() + "  Kd" + Kp_up_8.ToString() + "\r\n");
                }
                else if (digitalControlSingal_8 == 0 && isFirstChangeDown_8 == true)
                {
                   
                   
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
                    if (isExecutePIDModel_8)
                    {
                        PID_8 = new PIDControl(P_8, D_8, I_8, confortableT);
                    }
                    else
                    {
                        PID_8 = new PIDControl(Kp_down_8, Ki_down_8, Kd_down_8, confortableT);
                    }

                    System.IO.File.AppendAllText("e:\\result_8.txt", "舒适：" + "Kp:" + Kp_down_8.ToString() + "  Ki" + Ki_down_8.ToString() + "  Kd" + Kp_down_8.ToString() + "\r\n");
                }
                else
                {
                    ;
                }
            }



            /*
            * PID paramete test module
            */

            if (isExecutePIDModel_8 == true)
            {
                timerCount_8++;

                if (timerCount_8 == 300 && highBalance_8 == true)
                {
                    timerCount_8 = 0;
                    digitalControlSingal_8 = 0;
                    highBalance_8 = false;
                    downLine_8 = true;
                   
                }

                if (timerCount_8 == 150 && downLine_8)
                {
                    //System.IO.File.AppendAllText("e:\\result_8.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_8 = true;
                    downLine_8 = false;
                    timeNotAccept_8 = true;


                }

                if (temperatureValue_8 - confortableT <= 0.5 && downLine_8 == true)
                {
                    beyondNum_8++;
                    if (beyondNum_8 == 3)
                    {
                        timeResult_8 = timerCount_8;
                        timerCount_8 = 0;
                        downLine_8 = false;
                        longKeep_8 = true;
                        beyondNum_8 = 0;

                    }
                }

                if (longKeep_8 == true)
                {
                    tempCollection_8.Add(temperatureValue_8);
                    if (timerCount_8 == 300)
                    {
                        isChangeParam_8 = true;
                        longKeep_8 = false;
                    }

                }






                if (isChangeParam_8)
                {

                    if (timeNotAccept_8)
                    {
                        lblPIDTestStatus_8.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_8, I_8, D_8));
                        //System.IO.File.AppendAllText("e:\\result_8.txt", P_8 + "   " + I_8 + "   " + D_8 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_8;
                        resultAnalyse(tempCollection_8, P_8, I_8, D_8, out PID_Result_8,8);
                        tempCollection_8.Clear();
                        lblPIDTestStatus_8.Text = PID_Result_8;
                        //执行计算，然后输出
                    }
                    if (D_8 == 3)
                    {
                        timer_8.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_8.Text = "finished!";
                    }

                    digitalControlSingal_8 = 1;
                    isChangeParam_8 = false;
                    P_8 += 0.5;
                    if (P_8 == 10)
                    {
                        D_8 += 0.5;
                        P_8 = 0.5;
                    }


                    timerCount_8 = 0;
                    beyondNum_8 = 0;
                    highBalance_8 = true;
                }

            }




            if (isExecutePIDModelDown_8 == true)
            {
                timerCount_8++;

                if (timerCount_8 == 300 && lowBalance_8 == true)
                {
                    timerCount_8 = 0;
                    digitalControlSingal_8 = 1;
                    lowBalance_8 = false;
                    upLine_8 = true;
                   
                }

                if (timerCount_8 == 100 && upLine_8)
                {
                    //System.IO.File.AppendAllText("e:\\result_8.txt", "舒适：" + "Kp:" + 8 + "  Ki" + 0 + "  Kd" + 3 + "\r\n");
                    isChangeParam_8 = true;
                    upLine_8 = false;
                    timeNotAccept_8 = true;


                }

                if (punishmentT - temperatureValue_8 <= 0.5 && upLine_8 == true)
                {
                    beyondNum_8++;
                    if (beyondNum_8 == 3)
                    {
                        timeResult_8 = timerCount_8;
                        timerCount_8 = 0;
                        upLine_8 = false;
                        longKeep_8 = true;
                        beyondNum_8 = 0;

                    }
                }

                if (longKeep_8 == true)
                {
                    tempCollection_8.Add(temperatureValue_8);
                    if (timerCount_8 == 300)
                    {
                        isChangeParam_8 = true;
                        longKeep_8 = false;
                    }

                }






                if (isChangeParam_8)
                {

                    if (timeNotAccept_8)
                    {
                        lblPIDTestStatus_8.Text = (string.Format("P:{0},I:{1},D{2}--时间超出", P_8, I_8, D_8));
                        //System.IO.File.AppendAllText("e:\\result_8.txt", P_8 + "   " + I_8 + "   " + D_8 + "   " + "Tout" + "\r\n");
                        //输出PID 时间超出，舍弃参数
                    }
                    else
                    {
                        string PID_Result_8;
                        resultAnalyse(tempCollection_8, P_8, I_8, D_8, out PID_Result_8, 8);
                        tempCollection_8.Clear();
                        lblPIDTestStatus_8.Text = PID_Result_8;
                        //执行计算，然后输出
                    }
                    if (D_8 == 10)
                    {
                        timer_8.Stop();
                        Board_1.clearALL();
                        lblPIDTestStatus_8.Text = "Finished!";
                    }

                    digitalControlSingal_8 = 0;
                    isChangeParam_8 = false;
                    P_8 += 0.5;
                    if (P_8 == 10)
                    {
                        D_8 += 0.5;
                        P_8 = 0.5;
                    }


                    timerCount_8 = 0;
                    beyondNum_8 = 0;
                    lowBalance_8 = true;
                }

            }



            if (isUp_8 == true)
            {
                if ((punishmentT - temperatureValue_8) < 10 && isStartPID_8 == true)
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

                if (!isExecuteControlModel_8 || !isExecutePIDModelDown_8)
                {
                    System.IO.File.AppendAllText("e:\\result_8.txt", temperatureValue_8.ToString("00.00") + "\r\n");
                }
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

                if (!isExecuteControlModel_8 || !isExecutePIDModelDown_8)
                {
                    System.IO.File.AppendAllText("e:\\result_8.txt", temperatureValue_8.ToString("00.00") + "\r\n");
                }
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            Board_1.clearALL();
            isTotalStartBtnTrue = true;
            btnTotalStart.Text = "Start";

            

            isExecuteControlModel_1 = false;
            isExecuteControlModel_2 = false;
            isExecuteControlModel_3 = false;
            isExecuteControlModel_4 = false;
            isExecuteControlModel_5 = false;
            isExecuteControlModel_6 = false;
            isExecuteControlModel_7 = false;
            isExecuteControlModel_8 = false;

            lblTState_1.Text = "NULL";
            lblTState_2.Text = "NULL";
            lblTState_3.Text = "NULL";
            lblTState_4.Text = "NULL";
            lblTState_5.Text = "NULL";
            lblTState_6.Text = "NULL";
            lblTState_7.Text = "NULL";
            lblTState_8.Text = "NULL";


            isUp_1 = false;
            isUp_2 = false;
            isUp_3 = false;
            isUp_4 = false;
            isUp_5 = false;
            isUp_6 = false;
            isUp_7 = false;
            isUp_8 = false;

            isDown_1 = false;
            isDown_2 = false;
            isDown_3 = false;
            isDown_4 = false;
            isDown_5 = false;
            isDown_6 = false;
            isDown_7 = false;
            isDown_8 = false;

        }

        private void btnGetParam_8_Click(object sender, EventArgs e)
        {

        }

        private void isByHand_Click(object sender, EventArgs e)
        {
            if (isMenuByHandChecked == true)
            {
                menuIsByHand.Checked = false;
                isMenuByHandChecked = false;

                btnTotalStart.Enabled = true;

                btnTestByHand_1.Enabled = false;
                btnTestByHand_2.Enabled = false;
                btnTestByHand_3.Enabled = false;
                btnTestByHand_4.Enabled = false;
                btnTestByHand_5.Enabled = false;
                btnTestByHand_6.Enabled = false;
                btnTestByHand_7.Enabled = false;
                btnTestByHand_8.Enabled = false;

                

            }
            else
            {
                isMenuByHandChecked = true;
                menuIsByHand.Checked = true;

                btnTotalStart.Enabled = false;


                btnTestByHand_1.Enabled = true;
                btnTestByHand_2.Enabled = true;
                btnTestByHand_3.Enabled = true;
                btnTestByHand_4.Enabled = true;
                btnTestByHand_5.Enabled = true;
                btnTestByHand_6.Enabled = true;
                btnTestByHand_7.Enabled = true;
                btnTestByHand_8.Enabled = true;

                btnTestByHand_1.Enabled = true;
                btnTestByHand_2.Enabled = true;
                btnTestByHand_3.Enabled = true;
                btnTestByHand_4.Enabled = true;
                btnTestByHand_5.Enabled = true;
                btnTestByHand_6.Enabled = true;
                btnTestByHand_7.Enabled = true;
                btnTestByHand_8.Enabled = true;
            }
        }

        private void btnTotalStart_Click(object sender, EventArgs e)
        {
            if (isTotalStartBtnTrue == true)
            {
                isTotalStartBtnTrue = false;
                btnTotalStart.Text = "Stop";


                isTestByHand_1 = false;
                isTestByHand_2 = false;
                isTestByHand_3 = false;
                isTestByHand_4 = false;
                isTestByHand_5 = false;
                isTestByHand_6 = false;
                isTestByHand_7 = false;
                isTestByHand_8 = false;

                isExecuteControlModel_1 = true;
                isExecuteControlModel_2 = true;
                isExecuteControlModel_3 = true;
                isExecuteControlModel_4 = true;
                isExecuteControlModel_5 = true;
                isExecuteControlModel_6 = true;
                isExecuteControlModel_7 = true;
                isExecuteControlModel_8 = true;

                isFirstChangeUp_1 = true;
                isFirstChangeUp_2 = true;
                isFirstChangeUp_3 = true;
                isFirstChangeUp_4 = true;
                isFirstChangeUp_5 = true;
                isFirstChangeUp_6 = true;
                isFirstChangeUp_7 = true;
                isFirstChangeUp_8 = true;
                isFirstChangeDown_1 = true;
                isFirstChangeDown_2 = true;
                isFirstChangeDown_3 = true;
                isFirstChangeDown_4 = true;
                isFirstChangeDown_5 = true;
                isFirstChangeDown_6 = true;
                isFirstChangeDown_7 = true;
                isFirstChangeDown_8 = true;


            }
            else
            {
                isTotalStartBtnTrue = true;
                btnTotalStart.Text = "Start";

                Board_1.clearALL();

                isExecuteControlModel_1 = false;
                isExecuteControlModel_2 = false;
                isExecuteControlModel_3 = false;
                isExecuteControlModel_4 = false;
                isExecuteControlModel_5 = false;
                isExecuteControlModel_6 = false;
                isExecuteControlModel_7 = false;
                isExecuteControlModel_8 = false;

                lblTState_1.Text = "NULL";
                lblTState_2.Text = "NULL";
                lblTState_3.Text = "NULL";
                lblTState_4.Text = "NULL";
                lblTState_5.Text = "NULL";
                lblTState_6.Text = "NULL";
                lblTState_7.Text = "NULL";
                lblTState_8.Text = "NULL";


                isUp_1 = false;
                isUp_2 = false;
                isUp_3 = false;
                isUp_4 = false;
                isUp_5 = false;
                isUp_6 = false;
                isUp_7 = false;
                isUp_8 = false;

                isDown_1 = false;
                isDown_2 = false;
                isDown_3 = false;
                isDown_4 = false;
                isDown_5 = false;
                isDown_6 = false;
                isDown_7 = false;
                isDown_8 = false;
                


            }
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
