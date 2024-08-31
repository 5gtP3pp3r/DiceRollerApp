using DiceRollerApp.Class;

namespace DiceRollerApp;

public partial class MainPage : ContentPage
{
    private const string UnionJack = "Resources/Images/union_jack_20_11.png";
    private const string France = "Resources/Images/france_20_11.png";

    private readonly DiceController controller;
    public MainPage()
    {
        InitializeComponent();
        controller = new();
    }

    private void OnClickRollDices(object sender, EventArgs e)
    {
        int faces = GetDiceFaces();
        int nbDices = GetDiceNumber();
        int modifier = GetModifier();
        (int rollResult, List<string> imagePaths) = controller.GetResultAndPaths(faces, nbDices, modifier);

        outputTextBox.Text = rollResult.ToString();
        DisplayImages(imagePaths);
    }
    private void OnClickTranslate(object sender, EventArgs e)
    {
        var button = sender as Button;
        var currentImageSource = (button.ImageSource as FileImageSource)?.File;
        if (currentImageSource == UnionJack)
        {
            AppTitle.Text = "Dice Roller";

            NbFaces.Text = "Dice type:";
            FourFaces.Content = "Dice 4";
            SixFaces.Content = "Dice 6";
            EightFaces.Content = "Dice 8";
            TenFaces.Content = "Dice 10";
            TwentyFaces.Content = "Dice 20";

            NbDices.Text = "Dices Number:";
            Modifier.Text = "Modifier:";
            Result.Text = "Result";
            Roll.Text = "Roll";
            Signature.Text = "  My first app!                   by WC";

            button.ImageSource = France;
        }
        else
        {
            AppTitle.Text = "Lanceur de Dés";

            NbFaces.Text = "Type de dé:";
            FourFaces.Content = "Dé 4";
            SixFaces.Content = "Dé 6";
            EightFaces.Content = "Dé 8";
            TenFaces.Content = "Dé 10";
            TwentyFaces.Content = "Dé 20";

            NbDices.Text = "Nombre de dés:";
            Modifier.Text = "Modificateur:";
            Result.Text = "Résultat";
            Roll.Text = "Lancer";
            Signature.Text = "Mon premier app!                 par WC";

            button.ImageSource = UnionJack;
        }
    }
    private void DisplayImages(List<string> imagePaths)
    {
        DiceImagesRow.Children.Clear();
        foreach (string path in imagePaths)
        {
            Image diceImage = new()
            {
                Source = ImageSource.FromFile(path),
                Margin = new Thickness(5)
            };
            DiceImagesRow.Children.Add(diceImage);
        }
    }
    private int GetDiceFaces()
    {
        if (FourFaces.IsChecked == true) return 4;
        if (SixFaces.IsChecked == true) return 6;
        if (EightFaces.IsChecked == true) return 8;
        if (TenFaces.IsChecked == true) return 10;
        if (TwentyFaces.IsChecked == true) return 20;
        return 0;
    }
    private int GetDiceNumber()
    {
        if (OneDice.IsChecked == true) return 1;
        if (TwoDices.IsChecked == true) return 2;
        if (ThreeDices.IsChecked == true) return 3;
        if (FourDices.IsChecked == true) return 4;
        if (FiveDices.IsChecked == true) return 5;
        return 0;
    }
    private int GetModifier()
    {
        if (Zero.IsChecked == true) return 0;
        if (One.IsChecked == true) return 1;
        if (Two.IsChecked == true) return 2;
        if (Three.IsChecked == true) return 3;
        if (Four.IsChecked == true) return 4;
        return 0;
    }
}

