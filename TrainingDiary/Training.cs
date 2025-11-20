using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TrainingDiary
{
    public partial class Training:ObservableObject
    {
        [ObservableProperty]
        [property: PrimaryKey]
        [property: AutoIncrement]
        int id;

        [ObservableProperty]
        string type;

        [ObservableProperty]
        TimeSpan duration;

        [ObservableProperty]
        DateTime date;

        [ObservableProperty]
        string notes;

        [ObservableProperty]
        string photopath;
        [ObservableProperty]
        string location;

    }
}
