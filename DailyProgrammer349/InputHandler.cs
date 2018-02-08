using System;
using System.Collections.Generic;

namespace DailyProgrammer349
{
    public class InputHandler : IInputHandler
    {
        // fields
        private string _input = null;
        private int _stacksOfBoxes;
        private List<int> _listOfBoxes = new List<int>();

        // ctor
        public InputHandler(string input)
        {
            if (input != null)
            {
                _input = input;
                SplitInput();
                SortList();
            }
            else
            {
                throw new ArgumentNullException(input);
            }
        }

        // private methods
        private void SplitInput()
        {
            string[] splitInput = _input.Split(' ');
            string boxList = splitInput[1];

            if (int.TryParse(splitInput[0], out int stack))
            {
                _stacksOfBoxes = stack;
            }

            else
            {
                throw new InvalidCastException("First input is not a integer");
            }

            for (int i = 0; i < boxList.Length; i++)
            {
                try
                {
                    var val = (int)Char.GetNumericValue(boxList[i]);

                    if (val == -1)     // means it was not a number
                    {
                        throw new ArrayTypeMismatchException("Value was not a number.");
                    }

                    else
                    {
                        _listOfBoxes.Add(val);
                    }
                    
                }

                catch (Exception e)
                {
                    var takeaway = e.TargetSite;
                    Console.WriteLine(e.Message);
                }
            }
        }
        private void SortList()
        {
            _listOfBoxes.Sort();
        }

        // interface methods
        public List<int> GetBoxList()
        {
            return _listOfBoxes;
        }
        public int GetStackSize()
        {
            return _stacksOfBoxes;
        }
    }

}
