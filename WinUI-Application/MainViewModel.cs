using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WinUI_Application;

//relates to MVVM toolkit
public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    public partial int Count { get; set; }

    [RelayCommand]
    public void IncrementCount()
    {
        Count++; 
    }
}
