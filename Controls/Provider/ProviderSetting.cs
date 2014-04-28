using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpMap.Data.Providers;

namespace SharpMap.Forms.Controls.Provider
{
    public partial class ProviderSetting : UserControl
    {
        private IProvider _provider;

        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        public ProviderSetting()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event raised when the <see cref="Provider"/> has changed
        /// </summary>
        public event EventHandler ProviderChanged;

        /// <summary>
        /// Event invoker for the <see cref="ProviderChanged"/> event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnProviderChanged(EventArgs e)
        {
            if (ProviderChanged != null)
            {
                ProviderChanged(this, e);
            }
        }

        public IProvider Provider
        {
            get { return _provider; }
            set
            {
                if(ReferenceEquals(_provider, value))
                    return;

                _provider = value;
                OnProviderChanged(EventArgs.Empty);
            }
        }
    }


}
