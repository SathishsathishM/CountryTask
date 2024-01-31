using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DirectCmbouse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string splrootpath;
        string rootpath;
        DirectoryClass ofile;
        public MainWindow()
        {
            InitializeComponent();
            ////Load Country
            //rootpath = System.Environment.CurrentDirectory;
            //int binindex = rootpath.IndexOf("bin");
            //rootpath = rootpath.Remove(binindex);
            ////rootpath=roorpath+"Data";
            //rootpath = System.IO.Path.Join(rootpath, "Data");
            ofile = new DirectoryClass();
            rootpath = ofile.RootFilepath("Data");
            //Country Path
            string countrypath = System.IO.Path.Join(rootpath, "Country.txt");
            string[] listofcountry=ofile.ReadLines(countrypath);
            cmbcountry.ItemsSource=listofcountry;
            cmbcountry.SelectedIndex = 3;
        }

        private void cmbcountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbstate.Items != null)
            {
                cmbstate.Items.Clear();
            }
            string statepath = System.IO.Path.Join(rootpath, "State.txt");
            string[] listofstate=ofile.ReadLines(statepath);
            foreach(string value  in listofstate)
            {
                if(value.Contains(cmbcountry.SelectedItem.ToString()))
                {
                    int splchar=value.IndexOf('|');
                    string statevalue=value.Substring(splchar+1);
                    cmbstate.Items.Add(statevalue);
                }
            }
           
        }

        private void cmbstate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbcity.Items != null)
            {
                cmbcity.Items.Clear();
            }
            string citypath = System.IO.Path.Join(rootpath, "City.txt");
            string[] listofcity = ofile.ReadLines(citypath);
            foreach (string value in listofcity)
            {
                if(cmbstate.Items.Count > 1)
                { 
                if (value.Contains(cmbstate.SelectedItem.ToString()))
                {
                    int splchar1 = value.LastIndexOf('|');
                    string cityvalue = value.Substring(splchar1 + 1);
                    cmbcity.Items.Add(cityvalue);
                }
            }
            }

        }

        private void cmbcity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbvillage.Items != null)
            {
                cmbvillage.Items.Clear();
            }
            string villagepath = System.IO.Path.Join(rootpath, "Village.txt");
            string[] listofvillage = ofile.ReadLines(villagepath);
            foreach (string value in listofvillage)
            {
                if (cmbcity.Items.Count > 1)
                {
                    if (value.Contains(cmbcity.SelectedItem.ToString()))
                    {
                        int splchar = value.LastIndexOf('|');
                        string villagevalue = value.Substring(splchar + 1);
                        cmbvillage.Items.Add(villagevalue);
                    }
                }
            }
        }

       
    }
}
