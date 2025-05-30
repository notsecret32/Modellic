using Microsoft.Extensions.Logging;
using Modellic.App.Enums;
using Modellic.App.Exceptions;
using Modellic.App.Extensions;
using Modellic.App.SolidWorks.Documents;
using SolidWorks.Interop.swconst;
using System.Threading.Tasks;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Services
{
    public class AssemblyManager
    {
        #region Public Properties

        public bool HasDocument => Document != null;

        public SwAssemblyDoc Document { get; set; } = null;

        #endregion

        #region Constructors

        public AssemblyManager()
        {

        }

        #endregion

        #region Public Async Methods

        public async Task BuildAsync()
        {
            if (Document == null)
            {
                throw new AssemblyManagerException("Нет рабочего документа", AssemblyManagerErrorCode.NoWorkingDocument);
            }

            // Загружаем платформу
            await LoadComponent(PartExampleType.Platform);

            // Загружаем приспособление
            await LoadComponent(PartExampleType.Fixture, 0.0.ToMeters(), 150.0.ToMeters(), 500.0.ToMeters());

            // Загружаем деталь
            await LoadComponent(PartExampleType.Part, 0.0.ToMeters(), 35.0.ToMeters(), 250.0.ToMeters());

            // Загружаем упор
            await LoadComponent(AssemblyExampleType.Stop, 0.0.ToMeters(), 50.0.ToMeters(), -100.0.ToMeters());

            //int mateError = 0;

            //// Добавляем сопряжение
            //Document.Extension.UnsafeObject.SelectByID2("Грань<1>@FixtureExample<1>", "FACE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            //Document.Extension.UnsafeObject.SelectByID2("Грань<2>@PartExample<1>", "FACE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            //Document.ComObject.AddMate5((int)swMateType_e.swMateCONCENTRIC, (int)swMateAlign_e.swMateAlignALIGNED, false, 0, 0, 0, 0, 0, 0, 0, 0, false, false, 0, out mateError);
            //Logger.LogInformation($"[СОПРЯЖЕНИЕ 1]: {(swAddMateError_e)mateError}");

            //Document.Extension.UnsafeObject.SelectByID2("Грань<1>@FixtureExample<1>", "FACE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            //Document.Extension.UnsafeObject.SelectByID2("Грань<2>@PartExample<1>", "FACE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            //Document.ComObject.AddMate5((int)swMateType_e.swMateCOINCIDENT, (int)swMateAlign_e.swMateAlignALIGNED, false, 0, 0, 0, 0, 0, 0, 0, 0, false, false, 0, out mateError);
            //Logger.LogInformation($"[СОПРЯЖЕНИЕ 2]: {(swAddMateError_e)mateError}");

            //Document.Extension.UnsafeObject.SelectByID2("Грань<1>@PlatformExample<1>", "FACE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            //Document.Extension.UnsafeObject.SelectByID2("Грань<2>@PartExample<1>", "FACE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            //Document.ComObject.AddMate5((int)swMateType_e.swMateCOINCIDENT, (int)swMateAlign_e.swMateAlignALIGNED, false, 0, 0, 0, 0, 0, 0, 0, 0, false, false, 0, out mateError);
            //Logger.LogInformation($"[СОПРЯЖЕНИЕ 3]: {(swAddMateError_e)mateError}");

            //Document.Extension.UnsafeObject.SelectByID2("Грань<1>@PlatformExample<1>", "FACE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            //Document.Extension.UnsafeObject.SelectByID2("Грань<2>@FixtureExample<1>", "FACE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            //Document.ComObject.AddMate5((int)swMateType_e.swMateTANGENT, (int)swMateAlign_e.swMateAlignALIGNED, false, 0, 0, 0, 0, 0, 0, 0, 0, false, false, 0, out mateError);
            //Logger.LogInformation($"[СОПРЯЖЕНИЕ 4]: {(swAddMateError_e)mateError}");

            //Document.Extension.UnsafeObject.SelectByID2("Грань<1>@PlatformExample<1>", "FACE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            //Document.Extension.UnsafeObject.SelectByID2("Грань<2>@FixtureExample<1>", "FACE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            //Document.ComObject.AddMate5((int)swMateType_e.swMateTANGENT, (int)swMateAlign_e.swMateAlignALIGNED, false, 0, 0, 0, 0, 0, 0, 0, 0, false, false, 0, out mateError);
            //Logger.LogInformation($"[СОПРЯЖЕНИЕ 5]: {(swAddMateError_e)mateError}");

            //Document.Extension.UnsafeObject.SelectByID2("Грань<1>@PlatformExample<1>", "FACE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            //Document.Extension.UnsafeObject.SelectByID2("Грань<2>@StopExample<1>", "FACE", 0, 0, 0, true, 1, null, (int)swSelectOption_e.swSelectOptionDefault);
            //Document.ComObject.AddMate5((int)swMateType_e.swMateCOINCIDENT, (int)swMateAlign_e.swMateAlignALIGNED, false, 0, 0, 0, 0, 0, 0, 0, 0, false, false, 0, out mateError);
            //Logger.LogInformation($"[СОПРЯЖЕНИЕ 6]: {(swAddMateError_e)mateError}");
        }

        #endregion

        #region Private Async Methods

        private async Task LoadComponent(PartExampleType part, double x = 0, double y = 0, double z = 0)
        {
            string fullPath = ResourceManager.GetPartExampleFullPath(part);
            await ModellicEnv.Application.OpenDocumentAsync(fullPath, SwDocumentType.Part);

            string fileName = ResourceManager.GetPartExampleFileName(part);
            Document.ComObject.AddComponent5(
                fileName,
                (int)swAddComponentConfigOptions_e.swAddComponentConfigOptions_CurrentSelectedConfig,
                "",
                false,
                "",
                x,
                y,
                z
            );
        }

        private async Task LoadComponent(AssemblyExampleType part, double x = 0, double y = 0, double z = 0)
        {
            string fullPath = ResourceManager.GetAssemblyExampleFullPath(part);
            await ModellicEnv.Application.OpenDocumentAsync(fullPath, SwDocumentType.Assembly);

            string fileName = ResourceManager.GetAssemblyExampleFileName(part);
            Document.ComObject.AddComponent5(
                fileName,
                (int)swAddComponentConfigOptions_e.swAddComponentConfigOptions_CurrentSelectedConfig,
                "",
                false,
                "",
                x,
                y,
                z
            );
        }

        #endregion
    }
}
