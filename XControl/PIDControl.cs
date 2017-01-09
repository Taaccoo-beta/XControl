using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PID_WinForm
{
    /// <summary>
    /// PID控制算法模块，内置了两种PID算法
    /// 这里主要采取累加是算法
    /// PIDCalcDirect and PIDCalc
    /// </summary>
    class PIDControl
    {
        private double Kp;
        private double Ki;
        private double Kd;

        private double AccumuError;


        private double DesT;
        private double LastError;
        private double PreError;


        public PIDControl(double kp, double ki, double kd,double desT)
        {
            this.Kp = kp;
            this.Ki = ki;
            this.Kd = kd;
            this.DesT = desT;
            this.LastError = 0;
            this.PreError = 0;
            this.AccumuError = 0;
        }


       
        public void resetValue()
        {
            this.Kp = 0;
            this.Ki = 0;
            this.Kd = 0;
        }


        public double PIDCalcDirect(double nextValue)
        {
            double Error;
            Error = DesT - nextValue;
            AccumuError += Error;
            double PID_OUT = Kp * Error + Ki * AccumuError + Kd * (Error - LastError);
            LastError = Error;



            return PID_OUT;
        }

        public double PIDCalc(double nextValue)
        {
            double Error;
            Error = DesT - nextValue;
            double PID_OUT = Kp * (Error - LastError) + Ki * Error + Kd * (Error - 2 * LastError + PreError);
            PreError = LastError;
            LastError = Error;

            return PID_OUT;
        }

        public int ConvertAccordToPropotation(int num,int circle,int FirstProportion)
        {
            try
            {
                num = num * circle / FirstProportion;
            }
            catch
            {
                num = num * circle / 1;
               
            }


            if (num > circle || num < -circle)
            {
                num = circle;
                return num;
            }
            else if (num < 0)
            {
                return -num;
            }
            else return num;

        }

    }
}
