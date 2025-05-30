using Modellic.App.Core.Services;
using Modellic.App.SolidWorks.Documents;
using System;
using System.Windows.Forms;

namespace Modellic.App.UI.Forms
{
    public partial class AssemblyManagerForm : Form
    {
        #region Private Members

        private AssemblyManager _assemblyManager;

        #endregion

        #region Constructors

        public AssemblyManagerForm()
        {
            InitializeComponent();

            _assemblyManager = new AssemblyManager();
        }

        #endregion

        #region Private Form Handlers

        private async void BtnAssembly_Click(object sender, EventArgs e)
        {
            if (!_assemblyManager.HasDocument)
            {
                SwAssemblyDoc createdDocument = await ModellicEnv.Application.CreateAssemblyDocumentAsync();

                _assemblyManager.Document = createdDocument;
            }

            await _assemblyManager.BuildAsync();
        }

        #endregion
    }
}
