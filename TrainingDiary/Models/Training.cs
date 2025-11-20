using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace TrainingDiary.Models
{
    public partial class Training : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

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
