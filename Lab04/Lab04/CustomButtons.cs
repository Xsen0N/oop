using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Interactivity;
    using System;
    using System.Windows.Data;



        public class GradientButton : Button
        {
            public static readonly DependencyProperty GradientBrushProperty =
                DependencyProperty.Register("GradientBrush", typeof(GradientBrush), typeof(GradientButton));


            // Определяем DependencyProperty для ширины рамки кнопки
            public static readonly DependencyProperty BorderThicknessProperty =
                DependencyProperty.Register("BorderThickness", typeof(double), typeof(GradientButton),
                    new PropertyMetadata(1.0, OnBorderThicknessChanged, CoerceBorderThickness));


            private static bool ValidateBorderThickness(object value)
            {
                // Допустимы только положительные числа
                return (double)value >= 0;
            }

            private static bool ValidateText(object value)
            {
                // Допустимы только строки, длина которых больше 0
                return value.ToString().Length > 0;
            }


            private static object CoerceBorderThickness(DependencyObject obj, object value)
            {
                // Если толщина рамки не проходит валидацию, возвращаем значение по умолчанию
                if (!ValidateBorderThickness(value))
                {
                    return 1.0;
                }
                return value;
            }

            private static object CoerceText(DependencyObject obj, object value)
            {
                // Если текст не проходит валидацию, обрезаем его до 10 символов
                if (!ValidateText(value))
                {
                    return value.ToString().Substring(0, 5);
                }
                return value;
            }

            // Обработчики событий изменения значения DependencyProperty
            private static void OnBorderThicknessChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            {
            }

            private static void OnButtonTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            {
            }

            public GradientBrush GradientBrush
            {
                get { return (GradientBrush)GetValue(GradientBrushProperty); }
                set { SetValue(GradientBrushProperty, value); }
            }

            static GradientButton()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(GradientButton), new FrameworkPropertyMetadata(typeof(GradientButton)));
            }
        }

        public class CustomTextBox : TextBox
        {
            public static readonly DependencyProperty MaxLengthProperty =
                DependencyProperty.Register("MaxLength", typeof(int), typeof(CustomTextBox),
                    new PropertyMetadata(0, OnMaxLengthChanged));
            private static void OnMaxLengthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                CustomTextBox customTextBox = d as CustomTextBox;
                if (customTextBox != null)
                {
                    customTextBox.MaxLength = (int)e.NewValue;
                }
            }
            public int MaxLength
            {
                get { return (int)GetValue(MaxLengthProperty); }
                set { SetValue(MaxLengthProperty, value); }
            }
            protected override void OnTextChanged(TextChangedEventArgs e)
            {
                base.OnTextChanged(e);

                if (Text.Length > MaxLength)
                {
                    Text = Text.Substring(0, MaxLength);
                    CaretIndex = MaxLength;
                }
            }
        }



        public class GreenButton : Button
        {

            // Определяем DependencyProperty для цвета кнопки
            public static readonly DependencyProperty ButtonColorProperty =
                DependencyProperty.Register("ButtonColor", typeof(Color), typeof(GreenButton),
                    new PropertyMetadata(Colors.Green, OnButtonColorChanged, CoerceColor));

            // Определяем DependencyProperty для ширины рамки кнопки
            public static readonly DependencyProperty BorderThicknessProperty =
                DependencyProperty.Register("BorderThickness", typeof(double), typeof(GreenButton),
                    new PropertyMetadata(1.0, OnBorderThicknessChanged, CoerceBorderThickness));

            // Определяем DependencyProperty для текста на кнопке
            public static readonly DependencyProperty ButtonTextProperty =
                DependencyProperty.Register("ButtonText", typeof(string), typeof(GreenButton),
                    new PropertyMetadata(""));
            public string ButtonText
            {
                get { return (string)GetValue(ButtonTextProperty); }
                set { SetValue(ButtonTextProperty, value); }
            }
            private static bool ValidateColor(object value)
            {
                // Допустимы только цвета, которые можно представить в виде строки
                try
                {
                    ColorConverter.ConvertFromString(value.ToString());
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            private static bool ValidateBorderThickness(object value)
            {
                // Допустимы только положительные числа
                return (double)value >= 0;
            }

            private static bool ValidateText(object value)
            {
                // Допустимы только строки, длина которых не превышает 10 символов
                return value.ToString().Length <= 10;
            }

            private static object CoerceColor(DependencyObject obj, object value)
            {
                // Если цвет не проходит валидацию, возвращаем значение по умолчанию
                if (!ValidateColor(value))
                {
                    return Colors.Green;
                }
                return value;
            }

            private static object CoerceBorderThickness(DependencyObject obj, object value)
            {
                // Если толщина рамки не проходит валидацию, возвращаем значение по умолчанию
                if (!ValidateBorderThickness(value))
                {
                    return 1.0;
                }
                return value;
            }

            private static object CoerceText(DependencyObject obj, object value)
            {
                // Если текст не проходит валидацию, обрезаем его до 10 символов
                if (!ValidateText(value))
                {
                    return value.ToString().Substring(0, 10);
                }
                return value;
            }

            // Обработчики событий изменения значения DependencyProperty
            private static void OnButtonColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            {
            }

            private static void OnBorderThicknessChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            {
            }

            private static void OnButtonTextChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            {
            }
        }
        public class BubbleButton : Button
        {
            public static readonly RoutedEvent BubbleButtonEvent = EventManager.RegisterRoutedEvent(
                "BubbleButtonClick",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(BubbleButton));

            public event RoutedEventHandler BubbleButtonClick
            {

                add { AddHandler(BubbleButtonEvent, value); }
                remove { RemoveHandler(BubbleButtonEvent, value); }
            }

            protected override void OnClick()
            {
                base.OnClick();

                RoutedEventArgs args = new RoutedEventArgs(BubbleButton.BubbleButtonEvent, this);
                RaiseEvent(args);
            }
        }
        public class DirectButton : Button
        {
            public static readonly RoutedEvent DirectButtonEvent = EventManager.RegisterRoutedEvent(
                "DirectButtonClick",
                RoutingStrategy.Direct,
                typeof(RoutedEventHandler),
                typeof(DirectButton));

            public event RoutedEventHandler DirectButtonClick
            {
                add { AddHandler(DirectButtonEvent, value); }
                remove { RemoveHandler(DirectButtonEvent, value); }
            }

            protected override void OnClick()
            {
                base.OnClick();

                RoutedEventArgs args = new RoutedEventArgs(DirectButton.DirectButtonEvent, this);
                RaiseEvent(args);
            }
        }
        public class TunnelButton : Button
        {
            public static readonly RoutedEvent TunnelButtonEvent = EventManager.RegisterRoutedEvent(
                "MouseDown",
                RoutingStrategy.Tunnel,
                typeof(RoutedEventHandler),
                typeof(TunnelButton));

            public event RoutedEventHandler TunnelButtonClick
            {
                add { AddHandler(TunnelButtonEvent, value); }
                remove { RemoveHandler(TunnelButtonEvent, value); }
            }

            protected override void OnClick()
            {
                base.OnClick();

                RoutedEventArgs args = new RoutedEventArgs(TunnelButton.TunnelButtonEvent, this);
                RaiseEvent(args);
            }
        }
    }

