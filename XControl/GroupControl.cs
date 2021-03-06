﻿/*
 *some control operations 
 * 
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary>
/// 对protControl进行高层封装，直接控制8块数模转换器
/// 实现升降温，温度获取以及信号获取
/// </summary>
namespace XControl
{
    class GroupControl
    {
        private PortControl Board;
        private bool isIn;
        string DeviceDescript;


        /// <summary>
        /// the parametes which convert voltage to temperature
        /// </summary>
        private double p1_1, p2_1;
        private double p1_2, p2_2;
        private double p1_3, p2_3;
        private double p1_4, p2_4;
        private double p1_5, p2_5;
        private double p1_6, p2_6;
        private double p1_7, p2_7;
        private double p1_8, p2_8;






        public void SetTConvertParam(double P1_1, double P2_1, double P1_2, double P2_2,
            double P1_3, double P2_3, double P1_4, double P2_4, double P1_5, double P2_5, double P1_6, double P2_6, double P1_7, double P2_7, double P1_8, double P2_8)

        {
            this.p1_1 = P1_1;
            this.p2_1 = P2_1;

            this.p1_2 = P1_2;
            this.p2_2 = P2_2;

            this.p1_3 = P1_3;
            this.p2_3 = P2_3;

            this.p1_4 = P1_4;
            this.p2_4 = P2_4;

            this.p1_5 = P1_5;
            this.p2_5 = P2_5;

            this.p1_6 = P1_6;
            this.p2_6 = P2_6;

            this.p1_7 = P1_7;
            this.p2_7 = P2_7;

            this.p1_8 = P1_8;
            this.p2_8 = P2_8;


        }





        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="boardNum"></param>
        /// <param name="isIn">true means digital input
        /// false means digital output</param>
        public GroupControl(int boardNum,bool isIn)
        {
            Board = new PortControl(boardNum);
            DeviceDescript = Board.IsCorrectCreate;
            if (isIn)
            {
                Board.DigitalConfigurationIn();
            }
            else
            {
                Board.DigitalConfigurationOut();
            }

            Board.AnalogPortConfiguration();
        }

        /// <summary>
        /// 控制温度升降
        /// </summary>
        /// <param name="groupNumber">from 1 to 8</param>
        public void TUp(int groupNumber)
        {
            switch (groupNumber)
                {
                    case 1:
                        Board.DigitOutput(1, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(0, MccDaq.DigitalLogicState.High);
                        break;
                    case 2:
                        Board.DigitOutput(3, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(2, MccDaq.DigitalLogicState.High);
                        break;
                    case 3:
                        Board.DigitOutput(5, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(4, MccDaq.DigitalLogicState.High);
                        break;
                    case 4:
                        Board.DigitOutput(7, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(6, MccDaq.DigitalLogicState.High);
                        break;
                    case 5:
                        Board.DigitOutput(9, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(8, MccDaq.DigitalLogicState.High);
                        break;
                    case 6:
                        Board.DigitOutput(11, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(10, MccDaq.DigitalLogicState.High);
                        break;
                    case 7:
                        Board.DigitOutput(13, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(12, MccDaq.DigitalLogicState.High);
                        break;
                    case 8:
                        Board.DigitOutput(15, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(14, MccDaq.DigitalLogicState.High);
                        break;
                }
          
        }


        /// <summary>
        /// 控制温度下降 
        /// </summary>
        /// <param name="groupNumber">protNumber form 1 to 8</param>
        public void TDown(int groupNumber)
        {
           
                switch (groupNumber)
                {
                    case 1:
                        Board.DigitOutput(1, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(0, MccDaq.DigitalLogicState.Low);
                        break;
                    case 2:
                        Board.DigitOutput(3, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(2, MccDaq.DigitalLogicState.Low);
                        break;
                    case 3:
                        Board.DigitOutput(5, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(4, MccDaq.DigitalLogicState.Low);
                        break;
                    case 4:
                        Board.DigitOutput(7, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(6, MccDaq.DigitalLogicState.Low);
                        break;
                    case 5:
                        Board.DigitOutput(9, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(8, MccDaq.DigitalLogicState.Low);
                        break;
                    case 6:
                        Board.DigitOutput(11, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(10, MccDaq.DigitalLogicState.Low);
                        break;
                    case 7:
                        Board.DigitOutput(13, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(12, MccDaq.DigitalLogicState.Low);
                        break;
                    case 8:
                        Board.DigitOutput(15, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(14, MccDaq.DigitalLogicState.Low);
                        break;

                }
            
        }

        /// <summary>
        /// 将端口清0，不控制温度升降，让其处于自然状态
        /// when PortINH form 9 to 23 is low
        /// the temperature will not control by computer
        /// </summary>
        /// <param name="groupNumber">port number</param>
        public void TNature(int groupNumber)
        {
            
                switch (groupNumber)
                {
                    case 1:
                        Board.DigitOutput(1, MccDaq.DigitalLogicState.High);

                        break;
                    case 2:
                        Board.DigitOutput(3, MccDaq.DigitalLogicState.High);

                        break;
                    case 3:
                        Board.DigitOutput(5, MccDaq.DigitalLogicState.High);

                        break;
                    case 4:
                        Board.DigitOutput(7, MccDaq.DigitalLogicState.High);

                        break;
                    case 5:
                        Board.DigitOutput(9, MccDaq.DigitalLogicState.High);

                        break;
                    case 6:
                        Board.DigitOutput(11, MccDaq.DigitalLogicState.High);

                        break;
                    case 7:
                        Board.DigitOutput(13, MccDaq.DigitalLogicState.High);

                        break;
                    case 8:
                        Board.DigitOutput(15, MccDaq.DigitalLogicState.High);

                        break;

                }
          
        }

        /// <summary>
        /// 获取相应端口号的温度输入参数为board号和相应端口号
        /// </summary>
        /// <param name="groupNumber">the port number</param>
        /// <returns>float type of temperature</returns>
        public double getT(int groupNumber,out int RawValue)
        {
            switch (groupNumber)
            {
                case 1:
                    RawValue = int.Parse(Board.AnalogInput(0));
                    return RawValue * p1_1 - p2_1;
                   
                case 2:
                    RawValue = int.Parse(Board.AnalogInput(1));
                    return RawValue * p1_2 - p2_2;
                case 3:
                    RawValue = int.Parse(Board.AnalogInput(2));
                    return RawValue * p1_3 - p2_3;
                case 4:
                    RawValue = int.Parse(Board.AnalogInput(3));
                    return RawValue * p1_4 - p2_4;
                case 5:
                    RawValue = int.Parse(Board.AnalogInput(0));
                    return RawValue * p1_5 - p2_5;
                case 6:
                    RawValue = int.Parse(Board.AnalogInput(1));
                    return RawValue * p1_6 - p2_6;
                case 7:
                    RawValue = int.Parse(Board.AnalogInput(2));
                    return RawValue * p1_7 - p2_7;
                case 8:
                    RawValue = int.Parse(Board.AnalogInput(3));
                    return RawValue * p1_8 - p2_8;
                default:
                    RawValue = -1;
                    return -1;
            }
            
        }

        


        /// <summary>
        /// 获取升降温的控制信号
        /// </summary>
        /// <param name="groupNumber"></param>
        /// <param name="isIn">you can get input only isIn is true</param>
        /// <returns>0 expresss low and 1 express high</returns>
        public int getSingal(int groupNumber)
        {
            
                switch (groupNumber)
                {
                    case 1:
                        return Board.DigitInput(0);
                    case 2:
                        return Board.DigitInput(1);
                    case 3:
                        return Board.DigitInput(2);
                    case 4:
                        return Board.DigitInput(3);
                    case 5:
                        return Board.DigitInput(4);
                    case 6:
                        return Board.DigitInput(5);
                    case 7:
                        return Board.DigitInput(6);
                    case 8:
                        return Board.DigitInput(7);
                    default:
                        return -1;
                }
          

        }

        /// <summary>
        /// 将所有端口置为高电平，清空控制信号
        /// </summary>
        public void clearALL()
        {
                Board.DigitOutput(1, MccDaq.DigitalLogicState.High);


                Board.DigitOutput(3, MccDaq.DigitalLogicState.High);


                Board.DigitOutput(5, MccDaq.DigitalLogicState.High);

                Board.DigitOutput(7, MccDaq.DigitalLogicState.High);


                Board.DigitOutput(9, MccDaq.DigitalLogicState.High);


                Board.DigitOutput(11, MccDaq.DigitalLogicState.High);


                Board.DigitOutput(13, MccDaq.DigitalLogicState.High);


                Board.DigitOutput(15, MccDaq.DigitalLogicState.High);

          
        }





    }
}
