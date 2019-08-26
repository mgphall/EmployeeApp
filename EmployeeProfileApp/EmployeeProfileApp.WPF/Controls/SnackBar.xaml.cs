using Castle.Core.Internal;

namespace EmployeeProfileApp.WPF.Controls
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for SnackBar
    /// </summary>
    public partial class SnackBar : UserControl
    {
        /// <summary>
        /// The message property
        /// </summary>
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(SnackBar), new FrameworkPropertyMetadata(null, OnMessagePropertyChanged));

        /// <summary>
        /// Initializes a new instance of the <see cref="SnackBar"/> class.
        /// </summary>
        public SnackBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        /// <summary>
        /// Called when [message property changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnMessagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SnackBar c = d as SnackBar;
            c?.OnMessageChanged();
        }

        /// <summary>
        /// Called when [message changed].
        /// </summary>
        private void OnMessageChanged()
        {
            if (!Message.IsNullOrEmpty())
            {
                Snackbar.MessageQueue.Enqueue(Message);
            }
        }
    }
}
