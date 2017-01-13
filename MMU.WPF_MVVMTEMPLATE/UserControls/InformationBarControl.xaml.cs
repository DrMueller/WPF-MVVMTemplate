using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using $safeprojectname$.Models.Shell.Enumerations;
using PropertyChanged;

namespace $safeprojectname$.UserControls
{
    [ImplementPropertyChanged]
    public partial class InformationBarControl : UserControl
    {
        public static readonly DependencyProperty SelectedInformationTypeProperty =
            DependencyProperty.Register("SelectedInformationType", typeof(InformationType),
                typeof(InformationBarControl), new PropertyMetadata(InformationType.None, SelectedInformationTypeChangedCallback));
        public static readonly DependencyProperty InformationTextProperty =
            DependencyProperty.Register("InformationText", typeof(string),
                typeof(InformationBarControl), new PropertyMetadata(InformationTextChangedCallback));

        public InformationBarControl()
        {
            InitializeComponent();
        }

        public string ConcatedInformationText { get; private set; }

        public string InformationText
        {
            get
            {
                return (string)GetValue(InformationTextProperty);
            }
            set
            {
                SetValue(InformationTextProperty, value);
            }
        }

        public InformationType SelectedInformationType
        {
            get
            {
                return (InformationType)GetValue(SelectedInformationTypeProperty);
            }
            set
            {
                SetValue(SelectedInformationTypeProperty, value);
                CalculateConcatedInformationText();
            }
        }

        private void CalculateConcatedInformationText()
        {
            var prefix = GetInformationPrefixBySelectedInformationType();


            var info = (string)GetValue(InformationTextProperty);
            var concatedMessage = prefix + info;
            ConcatedInformationText = concatedMessage;
        }

        private string GetInformationPrefixBySelectedInformationType()
        {
            string result = null;

            switch (SelectedInformationType)
            {
                case InformationType.None:
                    {
                        result = string.Empty;
                        break;
                    }
                case InformationType.Information:
                    {
                        result = "Info: ";
                        break;
                    }
                case InformationType.Warning:
                    {
                        result = "Warning: ";
                        break;
                    }
                case InformationType.Error:
                    {
                        result = "Error: ";
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException(SelectedInformationType.ToString());
                    }
            }

            return result;
        }

        private static void InformationTextChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (InformationBarControl)d;
            obj.CalculateConcatedInformationText();
        }

        private static void SelectedInformationTypeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (InformationBarControl)d;
            obj.CalculateConcatedInformationText();
        }
    }
}