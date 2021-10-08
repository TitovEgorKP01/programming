using System;

namespace Lab_2
{
    class FillArgumentsException : Exception
    {
        private FillingEventArgs fArgs;

        public FillArgumentsException(FillingEventArgs fArgs)
        {
            this.fArgs = fArgs;
        }

        public override string Message => $"Incorrect filling values entered. Only positive arguments allowed";
    }
}
