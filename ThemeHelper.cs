using System;
using System.Linq;
using System.Windows;
using WpfApp_DataBinding_Ver2.Properties;

namespace WpfApp_DataBinding_Ver2
{
    public static class ThemeHelper
    {
        private static readonly string[] _themePaths = {
            "/Styles/Colors/DefaultColors.xaml",
            "/Styles/Colors/DarkTheme.xaml"
        };

        public static string CurrentTheme
        {
            get
            {
                if (string.IsNullOrEmpty(Settings.Default.ThemePath))
                {
                    Settings.Default.ThemePath = _themePaths[0];
                    Settings.Default.Save();
                }
                return Settings.Default.ThemePath;
            }
            set
            {
                Settings.Default.ThemePath = value;
                Settings.Default.Save();
            }
        }

        public static void ApplyTheme(string themePath)
        {
            try
            {
                var newTheme = new ResourceDictionary { Source = new Uri(themePath, UriKind.Relative) };

                var app = Application.Current;
                if (app == null) return;

                // Ищем текущую тему среди словарей цветов
                var oldTheme = app.Resources.MergedDictionaries
                    .FirstOrDefault(d => d.Source != null &&
                                        _themePaths.Any(path =>
                                            d.Source.OriginalString.EndsWith(path)));

                if (oldTheme != null)
                {
                    // Заменяем существующую тему
                    int index = app.Resources.MergedDictionaries.IndexOf(oldTheme);
                    app.Resources.MergedDictionaries[index] = newTheme;
                }
                else
                {
                    // Добавляем новую тему если не найдена
                    app.Resources.MergedDictionaries.Add(newTheme);
                }

                CurrentTheme = themePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при применении темы: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void ApplySavedTheme()
        {
            ApplyTheme(CurrentTheme);
        }

        public static void ToggleTheme()
        {
            var newTheme = CurrentTheme == _themePaths[0] ? _themePaths[1] : _themePaths[0];
            ApplyTheme(newTheme);
        }

        public static void InitializeTheme()
        {
            // Применяем сохраненную тему при запуске приложения
            ApplySavedTheme();
        }
    }
}