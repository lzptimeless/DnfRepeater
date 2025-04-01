using DnfRepeater.Events;
using DnfRepeater.Hotkeys;
using DnfRepeater.Modules;
using Serilog;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnfRepeater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static SolidColorBrush RepeatingBackground = new SolidColorBrush(Color.FromRgb(0xE3, 0x70, 0x41));
        private readonly CoreModule _coreModule = new CoreModule();
        private HwndSource? _hwndSource;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            _coreModule.IsOnChanged += CoreModule_IsOnChanged;
            _coreModule.IsRepeatingChanged += CoreModule_IsRepeatingChanged;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // 初始化热键相关功能
                Log.Information("Initializing hotkey manager.");
                var hWnd = new WindowInteropHelper(this).Handle;
                _hwndSource = HwndSource.FromHwnd(hWnd);
                _hwndSource.AddHook(WndProc);

                HotkeyManager.Default.Initialize(hWnd);

                Log.Information("Applying user config.");
                _coreModule.ApplyUserConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            ResetForm();
            SetIsEnableEdit(false);
        }

        private nint WndProc(nint hwnd, int msg, nint wParam, nint lParam, ref bool handled)
        {
            handled = HotkeyManager.Default.ProcessHotkeyMessage(msg, wParam, lParam);
            return IntPtr.Zero;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _hwndSource?.RemoveHook(WndProc);
            _coreModule.Dispose();
            base.OnClosing(e);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            SetIsEnableEdit(true);
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetIsEnableEdit(false);
                Log.Information("Applying form config.");
                ReadForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ResetForm();
            }
        }

        private void CoreModule_IsOnChanged(object? sender, IsOnChangedEventArgs e)
        {
            Dispatcher.InvokeAsync(() =>
            {
                if (!string.IsNullOrEmpty(e.TargetWindowTitle))
                {
                    TargetWindowRun.Text = e.TargetWindowTitle;
                }
                else
                {
                    TargetWindowRun.Text = "无";
                }
            });
        }

        private void CoreModule_IsRepeatingChanged(object? sender, IsRepeatingChangedEventArgs e)
        {
            Dispatcher.InvokeAsync(() =>
            {
                if (e.IsRepeating)
                {
                    RepeatStatusRun.Text = "连发中";
                    Background = RepeatingBackground;
                }
                else
                {
                    RepeatStatusRun.Text = "未连发";
                    Background = Brushes.White;
                }
            });
        }

        private void ReadForm()
        {
            _coreModule.SetOnOffHotkey(OnOffHotkeyTextBox.Text);
            _coreModule.SetRepeatKey(RepeatKeyTextBox.Text);
            _coreModule.SetTriggerKey(TriggerKeyTextBox.Text);
            if (int.TryParse(RepeatFrequencyTextBox.Text, out int frequency))
            {
                _coreModule.SetRepeatFrequency(frequency);
            }
            else
            {
                throw new ApplicationException("The value of Repeat Frequency is not a valid number.");
            }
        }

        private void ResetForm()
        {
            OnOffHotkeyTextBox.Text = _coreModule.OnOffHotkey;
            RepeatKeyTextBox.Text = _coreModule.RepeatKey;
            TriggerKeyTextBox.Text = _coreModule.TriggerKey;
            RepeatFrequencyTextBox.Text = _coreModule.RepeatFrequency.ToString();
        }

        private void SetIsEnableEdit(bool isEnable)
        {
            OnOffHotkeyTextBox.IsEnabled = isEnable;
            RepeatKeyTextBox.IsEnabled = isEnable;
            TriggerKeyTextBox.IsEnabled = isEnable;
            RepeatFrequencyTextBox.IsEnabled = isEnable;
        }
    }
}