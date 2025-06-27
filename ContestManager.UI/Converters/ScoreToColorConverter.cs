using System.Globalization;

namespace ContestManager.UI.Converters
{
    public class ScoreToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int score)
            {
                return score switch
                {
                    < 5 => Colors.Red,
                    >= 5 and < 7 => Colors.Orange,
                    >= 7 and < 9 => Colors.Green,
                    >= 9 => Colors.DarkGreen
                };
            }
            return Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}