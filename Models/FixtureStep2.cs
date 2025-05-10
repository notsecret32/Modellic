using System.ComponentModel;
using Modellic.Interfaces;

namespace Modellic.Models
{
    [DefaultProperty("Name")]
    public class FixtureStep2 : IFixtureStep
    {
        #region Private Members

        private readonly string _name = "Шаг 2";

        #endregion

        #region Parameters

        [Category("Общий"), Description("Имя шага")]
        [DisplayName("Название")]
        public string Title => _name;

        #endregion
    }
}