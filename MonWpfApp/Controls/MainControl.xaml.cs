using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MonWpfApp.Controls.DataSource;

namespace MonWpfApp.Controls
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl
    {
        public MainControl()
        {
            InitializeComponent();
            InitConfig();
        }

        private void InitConfig()
        {

            AdvancedButton1.Init(new List<string> { "ONE OF A KIND", "SMALL BATCH", "LARGE BATCH", "MASS MARKET" });
            AdvancedButton2.Init(new List<string> { "SAVORY", "SWEET", "UMAMI" });
            AdvancedButton3.Init(new List<string> { "SPICY", "MILD" });
            AdvancedButton4.Init(new List<string> { "CRUNCHY", "MUSHY", "SMOOTH" });
            AdvancedButton5.Init(new List<string> { "A LITTLE", "A LOT" });
            AdvancedButton6.Init(new List<string> { "BREAKFAST", "BRUNCH", "LUNCH", "SNACK", "DINNER" });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdvancedButton1.SiteMap.SelectRandomPage();
            AdvancedButton2.SiteMap.SelectRandomPage();
            AdvancedButton3.SiteMap.SelectRandomPage();
            AdvancedButton4.SiteMap.SelectRandomPage();
            AdvancedButton5.SiteMap.SelectRandomPage();
            AdvancedButton6.SiteMap.SelectRandomPage();

        }
    }
}
