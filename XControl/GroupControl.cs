/*
 *some control operations 
 * 
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XControl
{
    class GroupControl
    {
        private PortControl Board;
        private bool isIn;
        string DeviceDescript;
        /// <summary>
        /// initial a board
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
        /// group number
        /// </summary>
        /// <param name="groupNumber">from 1 to 8</param>
        public void TUp(int groupNumber,bool isIn)
        {
            if (!isIn)
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
            else
            {
                MessageBox.Show("you Cant output in this board");
            }
        }


        /// <summary>
        /// temperature down 
        /// </summary>
        /// <param name="groupNumber">protNumber form 1 to 8</param>
        public void TDown(int groupNumber,bool isIn)
        {
            if (!isIn)
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
                        Board.DigitOutput(12, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(11, MccDaq.DigitalLogicState.Low);
                        break;
                    case 7:
                        Board.DigitOutput(14, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(13, MccDaq.DigitalLogicState.Low);
                        break;
                    case 8:
                        Board.DigitOutput(16, MccDaq.DigitalLogicState.Low);
                        Board.DigitOutput(15, MccDaq.DigitalLogicState.Low);
                        break;

                }
            }
            else
            {
                MessageBox.Show("you can't out put in this Board");
            }
        }

        /// <summary>
        /// when PortINH form 9 to 23 is low
        /// the temperature will not control by computer
        /// </summary>
        /// <param name="groupNumber">port number</param>
        public void TNature(int groupNumber ,bool isIn)
        {
            if (!isIn)
            {
                switch (groupNumber)
                {
                    case 1:
                        Board.DigitOutput(1, MccDaq.DigitalLogicState.High);

                        break;
                    case 2:
                        Board.DigitOutput(2, MccDaq.DigitalLogicState.High);

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
            else { MessageBox.Show("you can't output in this board"); }
        }

        /// <summary>
        /// get teh Temperature
        /// </summary>
        /// <param name="groupNumber">the port number</param>
        /// <returns>float type of temperature</returns>
        public float getT(int groupNumber)
        {
            switch (groupNumber)
            {
                case 1:
                    return Board.ReadTemperature(0);                    
                case 2:
                    return Board.ReadTemperature(1);
                case 3:
                    return Board.ReadTemperature(2);
                case 4:
                    return Board.ReadTemperature(3);
                case 5:
                    return Board.ReadTemperature(4);
                case 6:
                    return Board.ReadTemperature(5);
                case 7:
                    return Board.ReadTemperature(6);
                case 8:
                    return Board.ReadTemperature(7);
            }

            return -1;


        }

        /// <summary>
        /// get the sinnal from the digital port from 0 to 7
        /// </summary>
        /// <param name="groupNumber"></param>
        /// <param name="isIn">you can get input only isIn is true</param>
        /// <returns>0 expresss low and 1 express high</returns>
        public int getSingal(int groupNumber,bool isIn)
        {
            if (isIn)
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
            else
            {
                return -1;
            }

        }

        /// <summary>
        /// make all of temperature sensor to a nature state
        /// </summary>
        public void clearALL(bool isIn)
        {
            if (!isIn)
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
            else { MessageBox.Show("you can't clear all the board in this board"); }
        }





    }
}
