﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MccDaq;
using ErrorDefs;
using System.Windows.Forms;
using DigitalIO;
using AnalogIO;


/// <summary>
/// 端口控制函数，对底层的数模转换其控制函数
/// 进行了封装
/// </summary>
namespace XControl
{

    /// <summary>
    /// provide the port config and port I/O control
    /// </summary>
    class PortControl
    {
        private string _isCorrectCreate=null;
        private MccDaq.MccBoard DaqBoard;
        private int PortType, ProgAbility,NumPort, NumBits, FirstBit;
        private MccDaq.DigitalPortType PortNum;
        private MccDaq.DigitalPortType BitPort = MccDaq.DigitalPortType.FirstPortA;
        private MccDaq.DigitalLogicState BitValueLow = MccDaq.DigitalLogicState.Low;
        private MccDaq.DigitalLogicState BitValueHigh = MccDaq.DigitalLogicState.High;
        private AnalogIO.clsAnalogIO AIOProps = new AnalogIO.clsAnalogIO();
        private int ADResolution;
        private int NumAIChans;
        private int LowChan;
        private MccDaq.TriggerType DefaultTrig;
        private MccDaq.Range Range;
        private MccDaq.Range _acutalRange;
        private MccDaq.ErrorInfo ULStat;
        private System.UInt32 DataValue32 = 0;
        private System.UInt16 DataValue = 0;
        private int Options = 0;


        /// <summary>
        /// the Acutal Range we used in the AnalogInput()
        /// </summary>
        public MccDaq.Range AcutalRange
        {
            set { _acutalRange = value; }
            private get { return _acutalRange; }
        }
        /// <summary>
        /// check if the board is correctly created.
        /// </summary>
        public string IsCorrectCreate
        {
            private set
            {
                _isCorrectCreate = value;
            }
            get
            {
                return _isCorrectCreate;
            }
        }





        public PortControl(int boardNum)
        {
           
            InitUL();
            AcutalRange = Range.Bip2Volts;
            DaqBoard = new MccDaq.MccBoard(boardNum);
            IsCorrectCreate = DaqBoard.BoardNum.ToString();


        }


        /// <summary>
        /// Config the port to the Output
        /// </summary>
        public void DigitalConfigurationOut()
        {
            DigitalIO.clsDigitalIO DioProps = new DigitalIO.clsDigitalIO();
            PortType = clsDigitalIO.PORTOUT;
            NumPort = DioProps.FindPortsOfType(DaqBoard, PortType, out ProgAbility,
               out PortNum, out NumBits, out FirstBit);
            MccDaq.DigitalPortDirection Direction = MccDaq.DigitalPortDirection.DigitalOut;
            ULStat = DaqBoard.DConfigPort(PortNum, Direction);
        }

        /// <summary>
        /// config the port to the input
        /// </summary>
        public void DigitalConfigurationIn()
        {
            DigitalIO.clsDigitalIO DioProps = new DigitalIO.clsDigitalIO();
            PortType = clsDigitalIO.PORTIN;
            NumPort = DioProps.FindPortsOfType(DaqBoard, PortType, out ProgAbility,
               out PortNum, out NumBits, out FirstBit);
            MccDaq.DigitalPortDirection Direction = MccDaq.DigitalPortDirection.DigitalIn;
            ULStat = DaqBoard.DConfigPort(PortNum, Direction);
        }

        /// <summary>
        /// portNumber from 8-23
        /// </summary>
        /// <param name="portNumber">Port number</param>
        /// <param name="BitValue">DigitalLogicState</param>
        public void DigitOutput(int portNumber,MccDaq.DigitalLogicState BitValue)
        {
            DaqBoard.DBitOut(BitPort, portNumber, BitValue);
        }


        /// <summary>
        /// portNumber from 0-7
        /// </summary>
        /// <param name="portNumber">port number</param>
        /// <returns>return int type which 1 express High and 0 express Low</returns>
        public int DigitInput(int portNumber)
        {
            MccDaq.DigitalLogicState bitValue;
            MccDaq.ErrorInfo ULStat = DaqBoard.DBitIn(BitPort, portNumber, out bitValue);
            if (bitValue == DigitalLogicState.High)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }



        /// <summary>
        /// 配置模拟端口为输入模式
        /// </summary>
        public void AnalogPortConfiguration()
        {
            int ChannelType = clsAnalogIO.ANALOGINPUT;

            NumAIChans = AIOProps.FindAnalogChansOfType(DaqBoard, ChannelType,
                out ADResolution, out Range, out LowChan, out DefaultTrig);
        }


        /// <summary>
        /// 获取模拟端口的输入，端口号(差分模式)从0-4对应数模转换器0 2 4 8
        /// 返回一个string类型，实际是数字
        /// </summary>
        /// <param name="portNumber"></param>
        /// <returns></returns>
        public string AnalogInput(int portNumber)
        {
            if (ADResolution > 16)
            {
                ULStat = DaqBoard.AIn32(portNumber, AcutalRange, out DataValue32, Options);
                return DataValue32.ToString();             
            }
            else
            {
                ULStat = DaqBoard.AIn(portNumber, AcutalRange, out DataValue);
                return DataValue.ToString();
                
            }
        }

        /// <summary>
        /// 直接读取温度，小数模转换器不可以使用
        /// </summary>
        /// <param name="Chan"></param>
        /// <returns></returns>
        public float ReadTemperature(int Chan)
        {
            MccDaq.TempScale MccScale = MccDaq.TempScale.Celsius;
            float TempValue = 0.0f;
            MccDaq.ThermocoupleOptions Options = MccDaq.ThermocoupleOptions.WaitForNewData;
            MccDaq.ErrorInfo ULStat = DaqBoard.TIn(Chan, MccScale, out TempValue, Options);

            return  TempValue;

        }

        /// <summary>
        /// 对数模转换其进行初始化
        /// </summary>
        private void InitUL()
        {

            MccDaq.ErrorInfo ULStat;

            //  Initiate error handling
            //  activating error handling will trap errors like
            //  bad channel numbers and non-configured conditions.
            //  Parameters:
            //  MccDaq.ErrorReporting.PrintAll :all warnings and errors encountered will be printed
            //  MccDaq.ErrorHandling.StopAll   :if an error is encountered, the program will stop

            clsErrorDefs.ReportError = MccDaq.ErrorReporting.PrintAll;
            clsErrorDefs.HandleError = MccDaq.ErrorHandling.StopAll;
            ULStat = MccDaq.MccService.ErrHandling
                (ErrorReporting.PrintAll, ErrorHandling.StopAll);

        }

    }
}
