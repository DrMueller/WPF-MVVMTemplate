using System.Windows;
using System.Windows.Input;

namespace $safeprojectname$.Infrastructure.XamlFunctionalities
{
    public static class MouseMoveCommandBinding
    {
        public static readonly DependencyProperty MouseMoveCommandProperty =
            DependencyProperty.RegisterAttached("MouseMoveCommand",
                typeof(ICommand),
                typeof(MouseMoveCommandBinding),
                new PropertyMetadata(null, MouseMoveCommandPropertyChangedCallback));
        public static readonly DependencyProperty MouseMoveCommandParameterProperty =
            DependencyProperty.RegisterAttached(
                "MouseMoveCommandParameter",
                typeof(object),
                typeof(MouseMoveCommandBinding),
                new PropertyMetadata(null, null));

        #region Public/Internal Methods

        public static ICommand GetMouseMoveCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(MouseMoveCommandProperty);
        }

        public static object GetMouseMoveCommandParameter(DependencyObject obj)
        {
            return obj.GetValue(MouseMoveCommandParameterProperty);
        }

        public static void SetMouseMoveCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(MouseMoveCommandProperty, value);
        }

        public static void SetMouseMoveCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(MouseMoveCommandParameterProperty, value);
        }

        #endregion

        #region Private Methods

        private static void MouseMoveCommandPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uiElement = d as UIElement;

            if (uiElement != null)
            {
                if (e.OldValue != null)
                {
                    uiElement.RemoveHandler(UIElement.MouseMoveEvent, new MouseEventHandler(OnMouseMove));
                }
                if (e.NewValue != null)
                {
                    uiElement.AddHandler(UIElement.MouseMoveEvent, new MouseEventHandler(OnMouseMove), true);
                }
            }
        }

        private static void OnMouseMove(object sender, MouseEventArgs e)
        {
            var uiElement = sender as UIElement;
            ICommand cmd = uiElement?.GetValue(MouseMoveCommandProperty) as ICommand;

            if (cmd != null)
            {
                var parameter = uiElement.GetValue(MouseMoveCommandParameterProperty);

                if (cmd.CanExecute(parameter))
                {
                    cmd.Execute(parameter);
                }
            }
        }

        #endregion
    }
}
