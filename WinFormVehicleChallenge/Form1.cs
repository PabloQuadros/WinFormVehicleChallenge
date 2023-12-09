using WinFormVehicleChallenge.Services;

namespace WinFormCarChallenge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var service = new BrandService();
            var b = await service.GetBandsByParallelum();
        }
    }
}