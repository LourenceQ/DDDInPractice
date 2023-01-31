using System.ComponentModel;

namespace DDDInPractice.UI.Common;

public abstract class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
}