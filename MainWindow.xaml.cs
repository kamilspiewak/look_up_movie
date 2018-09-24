using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Movie{
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public Uri Poster { get; set; }
         /*public partial class Ratings
          {
               public string Source { get; set; }
               public string Value { get; set; }
          } 
        */
        public string imdbRating { get; set; }
        public string Type { get; set; }
        public string DVD { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
        public bool Response { get; set; }
    }
    public partial class MainWindow : Window
    {
        public System.DateTime date;
        public static string user = Environment.UserName;
        public string url = "http://www.omdbapi.com/?apikey=";
        public string apikey = "770b25c4";                          //personal apikey -> user's in future, to get during first lunch
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e) //send request button
        {
           
            string adress = url + apikey + "&t=" + request.Text.Trim() +"&y="+request_year.Text.Trim()+ "&r=json";
            using (WebClient client = new WebClient())
            {
                var json=client.DownloadString(adress);
                Movie m = JsonConvert.DeserializeObject<Movie>(json);
             //  Movie.Ratings rat = JsonConvert.DeserializeObject<Movie.Ratings>(json);
                title.Text = m.Title;
                year.Text = m.Year;
                country.Text = m.Country;
                age.Text = m.Rated;
                desc.Text = m.Plot;
                genre.Text = m.Genre;
                runtime.Text = m.Runtime;
                released.Text = m.Released;
                imdbRating.Text = m.imdbRating;
                //  if (rat.Source == "Rotten Tomatoes") { rtRating.Text = rat.Value; }

                if (m.Poster == null)
                {
                    MessageBox.Show("Poster not found");
                }
                else
                {
                    string newTitle = m.Title.Replace(" ", string.Empty).Replace(":",string.Empty)+".jpg";
                    client.DownloadFile(m.Poster, newTitle);
                    string path = Directory.GetCurrentDirectory();
                    poster.Source = new BitmapImage(new Uri(path + "/"+newTitle));
                }

            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void request_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            request.Text = "";
        }

        private void request_year_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            request_year.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //clear button
        {
            request.Text = "";
            request_year.Text = "";
            title.Text = "";
            year.Text = "";
            country.Text = "";
            age.Text = "";
            desc.Text = "";
            genre.Text = "";
            runtime.Text = "";
            released.Text = "";
            rtRating.Text = "";
            imdbRating.Text = "";
            poster.Source = null;
        }

  

        private void lookup_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void load_Click(object sender, RoutedEventArgs e)
        {

        }

        private void locations_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", @Directory.GetCurrentDirectory());
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
