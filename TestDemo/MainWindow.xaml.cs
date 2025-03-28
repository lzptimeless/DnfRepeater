using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int keyDownCount = 0;
        private int keyUpCount = 0;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 监听本窗口的键盘事件，统计按键按下次数到KeyDownCountRun.Text，按键抬起次数到KeyUpCountRun.Text
            KeyDown += (s, e) =>
            {
                keyDownCount++;
                KeyDownCountRun.Text = keyDownCount.ToString();
            };
            KeyUp += (s, e) =>
            {
                keyUpCount++;
                KeyUpCountRun.Text = keyUpCount.ToString();
            };
        }
    }
}