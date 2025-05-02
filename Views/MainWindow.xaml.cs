using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using TechGear_WpfApp_Test1.Models;
using TechGear_WpfApp_Test1.ViewModel;

namespace TechGear_WpfApp_Test1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TechGearTest1GordeychikDbContext context = new TechGearTest1GordeychikDbContext();

        public MainWindow()
        {
            InitializeComponent();
            LoadPartners();
        }

        private void LoadPartners()
        {
            var partners = context.Partners
                .Include(p => p.PartnerType)
                .Include(p => p.PartnerProducts).ThenInclude(pp => pp.Product);

            var viewModels = new List<PartnersViewModel>();

            foreach (var p in partners)
            {
                string typeName = p.PartnerType.PartnerTypeName;

                int totalSale = 0;
                foreach (var pp in p.PartnerProducts)
                {
                    totalSale += pp.ProductCount.Value;
                }

                int percentValue = PercentCalculator.GetPercent(totalSale);
                

                viewModels.Add(new PartnersViewModel
                {
                    PartnerId = p.PartnerId,
                    PartnerTypeAndName = typeName + " | " + p.PartnerName,
                    PartnerCeo = p.PartnerCeo,
                    PartnerPhone = "+7 " + p.PartnerPhone,
                    PartnerRating = "Рейтинг: " + p.Rating.ToString(),
                    Percent = percentValue + "%"
                });
            }

            Partners_ListView.ItemsSource = viewModels;
        }


        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }
    }
}