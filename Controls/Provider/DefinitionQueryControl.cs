using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SharpMap.Data.Providers;

namespace SharpMap.Forms.Controls.Provider
{
    public partial class DefinitionQueryControl : UserControl
    {
        private IProvider _provider;

        public event EventHandler ProviderChanged;

        protected virtual void OnProviderChanged(EventArgs e)
        {
            if (_provider is FilterProvider)
            {
                var dq = string.Empty;// ((FilterProvider)_provider).DefinitionQuery;
                txtDefinitionQuery.Text = dq;
                Enabled = !string.IsNullOrEmpty(dq);
            }
            else if (HasDefinitionQuery(_provider))
            {
                txtDefinitionQuery.Text = GetDefinitionQuery(_provider);
                Enabled = true;
            }
            else
            {
                txtDefinitionQuery.Text = string.Empty;
                Enabled = false;
            }

            if (ProviderChanged != null)
            {
                ProviderChanged(this, e);
            }
        }

        /// <summary>
        /// Creates an instance of this class
        /// </summary>
        public DefinitionQueryControl()
        {
            InitializeComponent();
            tlpSampleData.SetColumnSpan(lbSampleData, 2);
            tlpSampleData.SetColumnSpan(chkIgnoreFilter, 2);
        }

        /// <summary>
        /// Gets or sets the provider for which to define the constraint
        /// </summary>
        public IProvider Provider
        {
            get { return _provider; }
            set
            {
                if (value == _provider)
                    return;

                _provider = value;
                OnProviderChanged(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Method to Check if a
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        private static bool HasDefinitionQuery(IProvider provider)
        {
            if (provider == null)
                return false;

            var pd = provider.GetType().GetProperties(
                BindingFlags.Public | BindingFlags.IgnoreCase);

            return pd.FirstOrDefault(p => p.Name.Equals("DefinitionQuery", 
                StringComparison.InvariantCultureIgnoreCase)) != null;
        }

        /// <summary>
        /// Method to return the value of the definition query
        /// </summary>
        /// <param name="provider">The provider instance</param>
        /// <returns>The definition query if set</returns>
        private static string GetDefinitionQuery(IProvider provider)
        {
            if (provider == null)
                return null;

            var pi = provider.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            var pd = pi.FirstOrDefault(p => p.Name.Equals("DefinitionQuery",
                StringComparison.InvariantCultureIgnoreCase));

            if (pd == null)
                return null;

            return (string) pd.GetValue(provider, null);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            gbColumns.Enabled = Enabled;
            gbDefinitionQuery.Enabled = Enabled;
            gbSampleData.Enabled = Enabled;
            gbOperators.Enabled = Enabled;
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            tlpSampleData.RowStyles[0].Height = tlpSampleData.Height -
                                              (tlpSampleData.RowStyles[1].Height + tlpSampleData.RowStyles[2].Height);
        }
    }
}
