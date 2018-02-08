using System;

namespace DailyProgrammer349
{
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
}
