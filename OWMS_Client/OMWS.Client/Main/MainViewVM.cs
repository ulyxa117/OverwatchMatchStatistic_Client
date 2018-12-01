using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OWMS.Model;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Prism.Commands;

namespace OWMS.Client.Main
{
    public class MainViewVM : BindableBase
    {
        private ReadOnlyObservableCollection<Match> matches_;
        public ObservableCollection<MatchVM> Matches { get; }
        public DelegateCommand GetChange { get; }

        public MainViewVM()
        {
            matches_ = new ReadOnlyObservableCollection<Match>(new ObservableCollection<Match>() { new Match(), new Match(), new Match() });
            Matches = new ObservableCollection<MatchVM>(matches_.Select(x => new MatchVM(x)));
        }
    }

    public class MatchVM : BindableBase
    {
        public string Header => Match.Header;
        public Match Match { get; }

        public MatchVM(Match match)
        {
            Match = match;
            match.PropertyChanged += (s, a) => { RaisePropertyChanged(nameof(Match)); };
        }
    }
}
