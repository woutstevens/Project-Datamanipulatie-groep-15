using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_Monopoly
{
    /// <summary>
    /// Interaction logic for Spelbord.xaml
    /// </summary>
    public partial class Spelbord : Window
    {
        private const int V = 70;
        private const int BottomRight = 875;
        private const int BottomLeft = 45;
        private const int BottomTop = 92;
        private const int BottomBottom = 924;

        public Spelbord()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            initializeSpelbord();
        }

        private void initializeSpelbord()
        {
            SetCardText("Nieuwstraat\nBrussel", "€ 400", 142, 0);
            SetCardText("Extra\nBelasting", "€ 100", 210, 0);
            SetCardText("Meir\nAntwerpen", "€ 350", 280, 0);
            SetCardText("Kans", null, 360, 0);
            SetCardText("Zuid\nStation", "€ 200", 440, 0);
            SetCardText("Boulevard\nD'Avroy\nLiège", "€ 320", 505, 0);
            SetCardText("Algemeen\nFonds", null, 570, 0);
            SetCardText("Boulevard\nTirou\nCharleroi", "€ 300", 650, 0);
            SetCardText("Veldstraat\nGent", "€ 300", 720, 0);


            SetCardText("Rue\nGrande\nDinant", "€ 60", 765, 90);
            SetCardText("Algemeen\nFonds", null, 695, 90);
            SetCardText("Diestse-\nstraat\nLeuven", "€ 60", 615, 90);
            SetCardText("Inkomsten\nBelasting", "€ 200", 550, 90);
            SetCardText("Noord\nStation", "€ 200", 480, 90);
            SetCardText("Steenstraat\nBrugge", "€ 100", 400, 90);
            SetCardText("Kans", null, 335, 90);
            SetCardText("Place du\nMonument\nSpa", "€ 100", 260, 90);
            SetCardText("Kapelle-\nstraat\nOostende", "€ 120", 190, 90);



            SetCardText("Rue de\nDiekirch\nArlon", "€ 140", 210, 180);
            SetCardText("Elektriciteits-\ncentrale", "€ 150", 280, 180);
            SetCardText("Bruul\nMechelen", "€ 140", 350, 180);
            SetCardText("Place Verte\nVerviers", "€ 160", 420, 180);
            SetCardText("Centraal\nStation", "€ 200", 490, 180);
            SetCardText("Lippenslaan\nKnokke", "€ 180", 563, 180);
            SetCardText("Algemeen\nFonds", null, 630, 180);
            SetCardText("Rue Royale\nTournai", "€ 180", 705, 180);
            SetCardText("Groenplaats\nAntwerpen", "€ 200", 780, 180);


            SetCardText("Hoogstraat\nBrussel", "€ 280", 820, 270);
            SetCardText("Water-\nMaatschappij", "€ 150", 755, 270);
            SetCardText("Place\nDe l'ange\nNamur", "€ 260", 680, 270);
            SetCardText("Grote Markt\nHasselt", "€ 260", 610, 270);
            SetCardText("Buurt\nSpoorwegen", "€ 200", 540, 270);
            SetCardText("Grand Place\nMons", "€ 240", 470, 270);
            SetCardText("Lange\nSteenstraat\nKortrijk", "€ 220", 395, 270);
            SetCardText("Kans", null, 320, 270);
            SetCardText("Rue\nSt.Léonard\nLiège", "€ 220", 250, 270);

            SetCardText("Parking", null, 180, 225);

            SetCardText("Op bezoek", null, 160, 176);
        }

        private void SetCardText(string name, string price, int position, int degrees)
        {
            Label nameLabel = new Label();
            Label priceLabel = new Label();
            Image afbeelding = new Image();
            RotateTransform rotateTransform = new RotateTransform(degrees);
            nameLabel.RenderTransform = rotateTransform;

            int left = position;
            int top = position;

            int nameLeft = left;
            int nameTop = top;
            int imgCrdLeft = left;
            int imgCrdTop = top;
            int imgCanBuyLeft = left;
            int imgCanBuyTop = top;
            int imgCornerLeft = left;
            int imgCornerTop = top;

            if (degrees == 0)
            {
                top = BottomBottom;
                nameTop = top - V;
                imgCrdLeft = nameLeft;
                imgCrdTop = nameTop + 20;
                imgCanBuyLeft = nameLeft - 10;
                imgCanBuyTop = nameTop + 20;
                if (isSpecialCard(name))
                {
                    nameTop -= 20;
                }
            }

            else if (degrees == 90)
            {
                left = BottomLeft;
                nameLeft = left + V;
                imgCrdLeft = nameLeft - 20;
                imgCrdTop = nameTop - 4;
                imgCanBuyLeft = nameLeft - 20;
                imgCanBuyTop = nameTop - 4;
                if (isSpecialCard(name))
                {
                    nameLeft += 20;
                }
            }

            else if (degrees == 180)
            {
                top = BottomTop;
                nameTop = top + V;
                imgCrdTop = nameTop;
                imgCrdLeft = nameLeft;
                imgCanBuyTop = nameTop - 20;
                imgCanBuyLeft = nameLeft;
                if (isSpecialCard(name))
                {
                    nameTop += 20;
                }
            }

            else if (degrees == 270)
            {
                left = BottomRight;
                nameLeft = left - V;
                imgCrdLeft = nameLeft + 20;
                imgCrdTop = nameTop + 2;
                imgCanBuyLeft = nameLeft + 20;
                imgCanBuyTop = nameTop - 3;
                if (isSpecialCard(name))
                {
                    nameLeft -= 20;
                }
            }

            else if (degrees == 225)
            {
                left = BottomRight;
                imgCornerLeft = BottomRight - 20;
                imgCornerTop = top - 15;
                nameLeft = left - V + 20;
            }

            else if(degrees == 176)
            {
                nameLeft = left - 110;
                nameTop = top - 95;
                RotateTransform rotate90 = new RotateTransform(90);
                nameLabel.RenderTransform = rotate90;
                nameLabel.FontSize = 35;
                
                
                imgCornerLeft = 70;
                imgCornerTop = 120;
                
            }

            else if(degrees == 45)
            {

            }



            priceLabel.Width = 69;
            priceLabel.Content = price;
            priceLabel.Margin = new Thickness(left, top, 0, 0);
            priceLabel.HorizontalAlignment = HorizontalAlignment.Left;
            priceLabel.VerticalAlignment = VerticalAlignment.Top;
            priceLabel.FontSize = 16;
            priceLabel.RenderTransform = rotateTransform;
            testgrid.Children.Add(priceLabel);

            nameLabel.Width = 70;
            nameLabel.Content = name;
            nameLabel.Margin = new Thickness(nameLeft, nameTop, 0, 0);
            nameLabel.HorizontalAlignment = HorizontalAlignment.Left;
            nameLabel.VerticalAlignment = VerticalAlignment.Top;
            nameLabel.FontSize = 11;

            afbeelding.Width = 60;

            afbeelding.HorizontalAlignment = HorizontalAlignment.Left;
            afbeelding.VerticalAlignment = VerticalAlignment.Top;
            afbeelding.RenderTransform = rotateTransform;
            if (name == "Kans")
            {
                nameLabel.FontSize = 20;

                afbeelding.Margin = new Thickness(imgCrdLeft, imgCrdTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/vraagteken.JPG", UriKind.Relative));

            }

            else if (name == "Algemeen\nFonds")
            {
                afbeelding.Margin = new Thickness(imgCrdLeft + 4, imgCrdTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/proxy.JPG", UriKind.Relative));

            }

            else if (name.Contains("centrale"))
            {
                afbeelding.Margin = new Thickness(imgCanBuyLeft - 5, imgCanBuyTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/elektriciteit.JPG", UriKind.Relative));
            }

            else if (name.Contains("Station") || name.Contains("Spoorwegen"))
            {
                
                afbeelding.Margin = new Thickness(imgCanBuyLeft, imgCanBuyTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/trein.JPG", UriKind.Relative));
            }

            else if (name.Contains("Maatschappij"))
            {
                nameLabel.FontSize = 10;
                afbeelding.Margin = new Thickness(imgCanBuyLeft - 5, imgCanBuyTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/Kraan.JPG", UriKind.Relative));
            }

            else if (name == "Parking")
            {
                nameLabel.FontSize = 10;
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/parking.gif", UriKind.Relative));
                afbeelding.Margin = new Thickness(imgCornerLeft, imgCornerTop, 0, 0);
                
            }

            else if (name.Contains("bezoek"))
            {
                afbeelding.Margin = new Thickness(imgCornerLeft, imgCornerTop, 0, 0);
                afbeelding.Source = new BitmapImage(new Uri("/afbeeldingen/gevangenis.png", UriKind.Relative));
                RotateTransform rotate0 = new RotateTransform(0);
                afbeelding.RenderTransform = rotate0;
                nameLabel.FontSize = 20;
                nameLabel.Width = 120;
            }

            

            
            testgrid.Children.Add(nameLabel);
            testgrid.Children.Add(afbeelding);



        }

        private static bool isSpecialCard(string name)
        {
            return name == "Kans" || name.Contains("Station") || name == "Algemeen\nFonds" || name.Contains("Belasting") || name.Contains("centrale") || name.Contains("Spoorwegen") || name.Contains("Maatschappij");
        }
    }
}
