using System;

namespace DailyProgrammer349
{
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
}
