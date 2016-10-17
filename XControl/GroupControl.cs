/*
 *some control operations 
 * 
*/ 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XControl
{
    class GroupControl
    {
        private PortControl Board;
        
        public GroupControl()
        {
            Board = new PortControl();
            Board.DigitConfiguration();
            Board.AnalogPortConfiguration();
        }

        /// <summary>
        /// group number
        /// </summary>
        /// <param name="groupNumber">from 1 to 8</param>
        public void TUp(int groupNumber)
        {
           
            switch (groupNumber)
            {
                case 1:
                    Board.DigitOutput(9, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(8, MccDaq.DigitalLogicState.High);
                    break;
                case 2:
                    Board.DigitOutput(11, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(10, MccDaq.DigitalLogicState.High);
                    break;
                case 3:
                    Board.DigitOutput(13, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(12, MccDaq.DigitalLogicState.High);
                    break;
                case 4:
                    Board.DigitOutput(15, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(14, MccDaq.DigitalLogicState.High);
                    break;
                case 5:
                    Board.DigitOutput(17, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(16, MccDaq.DigitalLogicState.High);
                    break;
                case 6:
                    Board.DigitOutput(19, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(18, MccDaq.DigitalLogicState.High);
                    break;
                case 7:
                    Board.DigitOutput(21, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(20, MccDaq.DigitalLogicState.High);
                    break;
                case 8:
                    Board.DigitOutput(23, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(22, MccDaq.DigitalLogicState.High);
                    break;
              
            }
        }


        /// <summary>
        /// temperature down 
        /// </summary>
        /// <param name="groupNumber">protNumber form 1 to 8</param>
        public void TDown(int groupNumber)
        {
            
            switch (groupNumber)
            {
                case 1:
                    Board.DigitOutput(9, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(8, MccDaq.DigitalLogicState.Low);
                    break;
                case 2:
                    Board.DigitOutput(11, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(10, MccDaq.DigitalLogicState.Low);
                    break;
                case 3:
                    Board.DigitOutput(13, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(12, MccDaq.DigitalLogicState.Low);
                    break;
                case 4:
                    Board.DigitOutput(15, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(14, MccDaq.DigitalLogicState.Low);
                    break;
                case 5:
                    Board.DigitOutput(17, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(16, MccDaq.DigitalLogicState.Low);
                    break;
                case 6:
                    Board.DigitOutput(19, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(18, MccDaq.DigitalLogicState.Low);
                    break;
                case 7:
                    Board.DigitOutput(21, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(20, MccDaq.DigitalLogicState.Low);
                    break;
                case 8:
                    Board.DigitOutput(23, MccDaq.DigitalLogicState.Low);
                    Board.DigitOutput(22, MccDaq.DigitalLogicState.Low);
                    break;

            }
        }

        /// <summary>
        /// when PortINH form 9 to 23 is low
        /// the temperature will not control by computer
        /// </summary>
        /// <param name="groupNumber">port number</param>
        public void TNature(int groupNumber)
        {
            
            switch (groupNumber)
            {
                case 1:
                    Board.DigitOutput(9, MccDaq.DigitalLogicState.High);
                  
                    break;
                case 2:
                    Board.DigitOutput(11, MccDaq.DigitalLogicState.High);
                    
                    break;
                case 3:
                    Board.DigitOutput(13, MccDaq.DigitalLogicState.High);
                   
                    break;
                case 4:
                    Board.DigitOutput(15, MccDaq.DigitalLogicState.High);
                    
                    break;
                case 5:
                    Board.DigitOutput(17, MccDaq.DigitalLogicState.High);
                   
                    break;
                case 6:
                    Board.DigitOutput(19, MccDaq.DigitalLogicState.High);
                   
                    break;
                case 7:
                    Board.DigitOutput(21, MccDaq.DigitalLogicState.High);
                   
                    break;
                case 8:
                    Board.DigitOutput(23, MccDaq.DigitalLogicState.High);
                    
                    break;

            }
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
        /// make all of temperature sensor to a nature state
        /// </summary>
        public void clearALL()
        {
            
                    Board.DigitOutput(9, MccDaq.DigitalLogicState.High);

           
                    Board.DigitOutput(11, MccDaq.DigitalLogicState.High);

            
                    Board.DigitOutput(13, MccDaq.DigitalLogicState.High);

                    Board.DigitOutput(15, MccDaq.DigitalLogicState.High);

            
                    Board.DigitOutput(17, MccDaq.DigitalLogicState.High);

         
                    Board.DigitOutput(19, MccDaq.DigitalLogicState.High);

          
                    Board.DigitOutput(21, MccDaq.DigitalLogicState.High);

            
                    Board.DigitOutput(23, MccDaq.DigitalLogicState.High);

           
        }





    }
}
