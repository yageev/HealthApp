using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace MonWpfApp.Controls.Spares
{
    /// <summary>
    /// Interaction logic for AdvancedButton.xaml
    /// </summary>
    public partial class AdvancedButton 
    {
        public AdvancedButton()
        {
            InitializeComponent();
        }

        #region private

        private void BtnWand_Click(object sender, RoutedEventArgs e)
        {
            SiteMap.SelectNextPageAction();
        }
       
        #endregion

        #region public

        /// <summary>
        /// Init styles
        /// </summary>
        /// <param name="data">collection of elements</param>
        public void Init(List<String> data)
        {
            SiteMap.InitData(data);

            switch (SiteMap.Pages.Count)
            {
                case 2:
                    BtnWand.Style = res["roundButtonTemplate2Elements"] as Style; 
                    break;
                case 3:
                    BtnWand.Style = res["roundButtonTemplate3Elements"] as Style; 
                    break;
                case 4:
                    BtnWand.Style = res["roundButtonTemplate4Elements"] as Style; 
                    break;
                case 5:
                    BtnWand.Style = res["roundButtonTemplate5Elements"] as Style; 
                    break;
            }
          
        }

        #endregion

        private void V5_Initialized(object sender, EventArgs e)
        {
            var s = sender as Canvas;
            if(s == null) return;
            SiteMap.Pases.Clear();

            for (int i = 1; i < s.Children.Count; i++)
            {
                SiteMap.Pases.Add(s.Children[i] as Path);
            }
           
            SiteMap.SetColor();
        }
    }
}
