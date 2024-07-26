using CommunityToolkit.Mvvm.ComponentModel;
using LcfSharp.IO;
using LcfSharp.Rpg;
using LcfSharp.Rpg.Actors;
using System.Collections.ObjectModel;
using System.Linq;

namespace LcfSharp.Editor.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public Database Database
        {
            get;
            private set;
        }

        [ObservableProperty]
        public Actor currentActor;

        //[ObservableProperty]
        //public ObservableCollection<Actor> actors;

        public MainViewModel()
        {
            Database = DatabaseFile.Load("..\\..\\..\\..\\LcfSharp.Tests\\Data\\RPG_RT_rw.ldb");

            //actors = new ObservableCollection<Actor>(_database.Actors);
            currentActor = Database.Actors.FirstOrDefault();
        }
    }
}
