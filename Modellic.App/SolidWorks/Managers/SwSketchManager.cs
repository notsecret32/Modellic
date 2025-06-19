using Microsoft.Extensions.Logging;
using Modellic.App.Enums;
using Modellic.App.Errors;
using Modellic.App.Exceptions;
using Modellic.App.SolidWorks.Core;
using Modellic.App.SolidWorks.Models;
using SolidWorks.Interop.sldworks;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.SolidWorks.Managers
{
    /// <summary>
    /// Предоставляет доступ к менеджеру создания эскизов.
    /// </summary>
    public class SwSketchManager : SwObject<SketchManager>
    {
        #region Public Properties

        public Sketch ActiveSketch => BaseObject.ActiveSketch;

        public bool HasActiveSketch => BaseObject.ActiveSketch != null;

        #endregion

        #region Constructors

        public SwSketchManager(SketchManager sketchManager) : base(sketchManager)
        {

        }

        #endregion

        #region Public Sketch Elements Methods

        public SketchSegment CreateArc(
            double circleCenterX,
            double circleCenterY,
            double circleCenterZ,
            double circleStartX,
            double circleStartY,
            double circleStartZ,
            double circleEndX,
            double circleEndY,
            double circleEndZ,
            short direction)
        {
            return BaseObject.CreateArc(
                circleCenterX,
                circleCenterY,
                circleCenterZ,
                circleStartX,
                circleStartY,
                circleStartZ,
                circleEndX,
                circleEndY,
                circleEndZ,
                direction
            );
        }
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

        public SketchSegment CreateCenterLine(double startX, double startY, double startZ, double endX, double endY, double endZ)
        {
            Logger.LogInformation($"[ЭСКИЗ] Создаем вспомогательную линию ([x={startX}, y={startY}, z={startZ}] => [x={endX}, y={endY}, z={endZ}])");

            return BaseObject.CreateCenterLine(
                startX, startY, startZ,
                endX, endY, endZ
            );
        }

        #endregion

        #region Public Sketch Methods

        public SwSketch CreateSketch(Action action, string sketchName = null, bool updateEditRebuild = true)
        {
            Logger.LogInformation("[ЭСКИЗ] Создаем новый эскиз");

            SwSketch activeSketch;

            if (HasActiveSketch)
            {
                Logger.LogWarning("[ЭСКИЗ] Предудущий эскиз не закрыт");

                throw new InvalidOperationException("Предудущий эскиз не закрыт.");
            }

            try
            {
                BaseObject.InsertSketch(updateEditRebuild);

                action();

                RenameActiveSketch(sketchName);
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

                activeSketch = HasActiveSketch ? new SwSketch(ActiveSketch) : null;

                BaseObject.InsertSketch(updateEditRebuild);

            }

            return activeSketch;
        }

        public string GetActiveSketchName()
        {
            if (!HasActiveSketch)
            {
                throw new InvalidOperationException("Нет активного эскиза");
            }

            Feature sketchAsFeature = (Feature)BaseObject.ActiveSketch;

            Logger.LogInformation($"[SketchManager] Name: {sketchAsFeature.Name}");

            return sketchAsFeature.Name;
        }

        public bool RenameActiveSketch(string newName)
        {
            if (!HasActiveSketch)
            {
                throw new InvalidOperationException("Нет активного эскиза");
            }

            if (string.IsNullOrEmpty(newName))
            {
                throw new ArgumentException($"Указано неправильное название эскиза: \"{newName}\"");
            }

            try
            {
                Feature sketchAsFeature = (Feature)BaseObject.ActiveSketch;

                string previousName = sketchAsFeature.Name;

                Logger.LogInformation($"[ЭСКИЗ] Переименовываем \"{previousName}\" в \"{newName}\"");

                sketchAsFeature.Name = newName;

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Произошла ошибка при попытке переименовать эскиз. Подробнее: \n{ex.Message}");

                return false;
            }
        }

        #endregion

        #region Public Selection Methods

        public bool SelectPointByIndex(int index, bool append = true, SelectData selectData = default)
        {
            if (!HasActiveSketch)
            {
                throw new InvalidOperationException("Нет активного эскиза");
            }

            var points = (dynamic[])ActiveSketch.GetSketchPoints2();

            if (index < 0 || index >= points.Length)
                return false;

            var point = points[index] as SketchPoint;

            if (point == null)
            {
                Logger.LogWarning($"Не удалось выбрать точку по индексу {index}");

                return false;
            }

            point.Select4(append, selectData);

            Logger.LogInformation($"Выбрана точка эскиза \"{GetActiveSketchName()}\" => [x: {point.X}; y: {point.Y}; z: {point.Z}]");

            return true;
        }

        #endregion
    }
}
