using System;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Globalization;

namespace PatientDetails.Converters
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    class ImagePathToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = GetImageFromPath(value as string);

            if (image == null)
            {
                return App.Current.TryFindResource("UserAccountDrawingImage");
            }
            else return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }

        public BitmapImage GetImageFromPath(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath)) return null;
            else return new BitmapImage(new Uri(imagePath, UriKind.Absolute));
        }
    }
}
