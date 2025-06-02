using Microsoft.Extensions.Logging;
using Modellic.App.Enums;
using Modellic.App.Errors;
using Modellic.App.Exceptions;
using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;
using System;
using static Modellic.App.Logging.LoggerService;
using static System.Windows.Forms.AxHost;

namespace Modellic.App.SolidWorks.Managers
{
    /// <summary>
    /// Предоставляет доступ к менеджеру создания эскизов.
    /// </summary>
    public class SwSketchManager : SwObject<SketchManager>
    {
        #region Private Members

        private bool _hasActiveSketch = false;

        #endregion

        #region Constructors

        public SwSketchManager(SketchManager sketchManager) : base(sketchManager)
        {
            
        }

        #endregion

        #region Public Methods

        public SketchSegment CreateCircle(double startX, double startY, double startZ, double endX, double endY, double endZ)
        {
            Logger.LogInformation($"[ЭСКИЗ] Создаем окружность ([x={startX}, y={startY}, z={startZ}] => [x={endX}, y={endY}, z={endZ}])");

            return BaseObject.CreateCircle(
                startX, startY, startZ,
                endX, endY, endZ
            );
        }
        
        public SketchSegment CreateCircleByRadius(double x, double y, double z, double radius)
        {
            Logger.LogInformation($"[ЭСКИЗ] Создаем окружность по радиусу ([x={x}, y={y}, z={z}, radius: {radius}]");

            return BaseObject.CreateCircleByRadius(x, y, z, radius);
        }

        public SketchSegment CreateLine(double startX, double startY, double startZ, double endX, double endY, double endZ)
        {
            Logger.LogInformation($"[ЭСКИЗ] Создаем линию ([x={startX}, y={startY}, z={startZ}] => [x={endX}, y={endY}, z={endZ}])");

            return BaseObject.CreateLine(
                startX, startY, startZ,
                endX, endY, endZ
            );
        }

        public void CreateSketch(Action<string> action, string sketchName = null, bool updateEditRebuild = true)
        {
            Logger.LogInformation("[ЭСКИЗ] Создаем новый эскиз");

            if (_hasActiveSketch)
            {
                Logger.LogWarning("[ЭСКИЗ] Предудущий эскиз не закрыт");

                throw new InvalidOperationException("Предудущий эскиз не закрыт.");
            }

            try
            {
                _hasActiveSketch = true;

                BaseObject.InsertSketch(updateEditRebuild);

                var name = GetActiveSketchName();

                action(name);

                if (!string.IsNullOrEmpty(sketchName))
                {
                    RenameSketch(sketchName);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"[ЭСКИЗ] Что-то пошло не так при работе с эскизом. Подробности: {ex.Message}.");

                throw new SolidWorksException(
                    SwObjectErrorManager.CreateError(
                        "Что-то пошло не так при работе с эскизом.", 
                        SwObjectErrorCode.SketchCreationFailed
                    ),
                    ex
                );
            }
            finally
            {
                Logger.LogInformation("[ЭСКИЗ] Сохраняем эскиз");

                BaseObject.InsertSketch(updateEditRebuild);

                _hasActiveSketch = false;
            }
        }

        public string GetActiveSketchName()
        {
            Feature sketchAsFeature = (Feature)BaseObject.ActiveSketch;

            Logger.LogInformation($"[SketchManager] Name: {sketchAsFeature.Name}");

            return sketchAsFeature.Name;
        }

        public void RenameSketch(string newName)
        {
            SwObjectErrorManager.Wrap(() =>
            {
                // Преобразуем эскиз
                Feature sketchAsFeature = (Feature)BaseObject.ActiveSketch;

                // Получаем предыдущее название эскиза
                string previousName = sketchAsFeature.Name;

                Logger.LogInformation($"[ЭСКИЗ] Переименовываем \"{previousName}\" в \"{newName}\"");

                // Меняем название эскиза на новое
                sketchAsFeature.Name = newName;
            },
            "$[ЭСКИЗ] Не удалось переименовать эскиз в \"{previousName}\"",
            SwObjectErrorCode.SketchRenameFailed);
        }

        #endregion
    }
}
