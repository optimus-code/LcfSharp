namespace LcfSharp.Rpg.Persistence
{
    public class SavePictureFlags
    {
        public bool EraseOnMapChange
        {
            get;
            set;
        } = true;

        public bool EraseOnBattleEnd
        {
            get;
            set;
        }

        public bool UnusedBit
        {
            get;
            set;
        }

        public bool UnusedBit2
        {
            get;
            set;
        }

        public bool AffectedByTint
        {
            get;
            set;
        }

        public bool AffectedByFlash
        {
            get;
            set;
        } = true;

        public bool AffectedByShake
        {
            get;
            set;
        } = true;
    }
}
