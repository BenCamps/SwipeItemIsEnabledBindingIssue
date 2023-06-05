using System.Diagnostics;
using System.Windows.Input;

namespace SwipeItemIsEnabledBindingIssue;

public class MainPageViewModel : BindableObject
{
    private bool _isEnabled;
    private ICommand _command;
    private string _itemText = "Counter: 0";
    private Color _background;
    private bool _isVisable;

    public MainPageViewModel()
    {
        Command = new Command(() => IncrementCounter());
    }

    public int Counter { get; set; }

    public string ItemText
    {
        get => _itemText;
        set
        {
            _itemText = value;
            OnPropertyChanged();
        }
    }

    public bool IsEnabled
    {
        get => _isEnabled;
        set
        {
            _isEnabled = value;
            OnPropertyChanged();
            IncrementCounter();
        }
    }

    public bool IsVisable
    {
        get => _isVisable;
        set
        {
            _isVisable = value;
            OnPropertyChanged();
        }
    }

    public ICommand Command
    {
        get => _command;
        set
        {
            _command = value;
            OnPropertyChanged();
        }
    }

    public Color Background
    {
        get => _background;
        set
        {
            _background = value;
            OnPropertyChanged();
        }
    }

    protected void IncrementCounter()
    {
        Counter++;
        ItemText = "Counter: " + Counter.ToString();
    }
}

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        var viewModel = new MainPageViewModel()
        {
            IsEnabled = false,
        };
        BindingContext = viewModel;

        Debug.Assert(viewModel.IsEnabled == false);
    }
}

