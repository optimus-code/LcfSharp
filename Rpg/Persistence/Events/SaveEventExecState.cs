using System.Collections.Generic;

namespace LcfSharp.Rpg.Persistence.Events
{
    public class SaveEventExecState
    {
        public List<SaveEventExecFrame> Stack
        {
            get;
            set;
        } = new List<SaveEventExecFrame>();

        public bool ShowMessage
        {
            get;
            set;
        }

        public bool AbortOnEscape
        {
            get;
            set;
        }

        public bool WaitMovement
        {
            get;
            set;
        }

        public bool KeyinputWait
        {
            get;
            set;
        }

        public byte KeyinputVariable
        {
            get;
            set;
        }

        public bool KeyinputAllDirections
        {
            get;
            set;
        }

        public int KeyinputDecision
        {
            get;
            set;
        }

        public int KeyinputCancel
        {
            get;
            set;
        }

        public int Keyinput2kShift2k3Numbers
        {
            get;
            set;
        }

        public int Keyinput2kDown2k3Operators
        {
            get;
            set;
        }

        public int Keyinput2kLeft2k3Shift
        {
            get;
            set;
        }

        public int Keyinput2kRight
        {
            get;
            set;
        }

        public int Keyinput2kUp
        {
            get;
            set;
        }

        public int WaitTime
        {
            get;
            set;
        }

        public int KeyinputTimeVariable
        {
            get;
            set;
        }

        public int Keyinput2k3Down
        {
            get;
            set;
        }

        public int Keyinput2k3Left
        {
            get;
            set;
        }

        public int Keyinput2k3Right
        {
            get;
            set;
        }

        public int Keyinput2k3Up
        {
            get;
            set;
        }

        public bool KeyinputTimed
        {
            get;
            set;
        }

        public bool WaitKeyEnter
        {
            get;
            set;
        }
    }
}
