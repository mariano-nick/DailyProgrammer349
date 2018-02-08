using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyProgrammer349
{
    public interface IInputHandler
    {
        List<int> GetBoxList();
        int GetStackSize();
    }

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
    public class BoxStackingViabilityChecker
    {
        // fields
        private IInputHandler _inputHandler;
        private int _total = 0;
        private int _divisibility = 0;
        private bool _isPossible;

        // ctor
        public BoxStackingViabilityChecker(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;

            if (_inputHandler != null)
            {
                CalculateTotal();
                CheckForDivisibility();
                ProcessDivisibility();
            }
            else
            {
                throw new ArgumentNullException("inputHandler");
            }
        }

        // private methods
        private void CheckForDivisibility()
        {
            double divisibilityFinder = (double) _total / _inputHandler.GetStackSize();

            if (divisibilityFinder % 1 == 0)
            {
                _divisibility = (int)divisibilityFinder;
            }
        }
        private void CalculateTotal()
        {
            foreach (int box in _inputHandler.GetBoxList())
            {
                _total += box;
            }
        }
        private void ProcessDivisibility()
        {
            if (_divisibility != 0)
            {
                _isPossible = true;
            }
            else
            {
                _isPossible = false;
            }
        }

        // public methods
        public int GetDivisibility()
        {
            return _divisibility;
        }

        // interface methods
        public bool GetBoxStackingPossibility()
        {
            return _isPossible;
        }
    }
    public class BoxStacker
    {
        private IInputHandler _inputHandler;
        private int _divisibility;

        public BoxStacker(IInputHandler ih, int divisibility)
        {
            if (ih != null)
            {
                _inputHandler = ih;
            }
            else
            {
                throw new ArgumentNullException("ih (inputHandler)");
            }
            if (divisibility != 0)
            {
                _divisibility = divisibility;
            }
            else
            {
                throw new ArgumentNullException(divisibility.ToString());
            }
            //StackThemBoxes();
        }

        private void StackThemBoxes()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ih = new InputHandler("3 34312332");
            var bsvc = new BoxStackingViabilityChecker(ih);
            
            if (bsvc.GetBoxStackingPossibility() == true)
            {
                var bs = new BoxStacker(ih, bsvc.GetDivisibility());
                Console.WriteLine("Time to write some boxes.");

            }

            else
            {
                Console.WriteLine("Not the time to write boxes.");
            }

            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
