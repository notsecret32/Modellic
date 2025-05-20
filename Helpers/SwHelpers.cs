using Modellic.Enums;
using Modellic.Extensions;
using Modellic.Services;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Modellic.Helpers
{
    public static class SwHelpers
    {
        private static readonly SwService _swService = SwService.GetInstance();

        #region Public Methods

        /// <summary>
        /// Создает операцию выдавливания (экструзии) из текущего эскиза.
        /// </summary>
        /// <param name="featureManager">Менеджер элементов.</param>
        /// <param name="isSingleEnded">True - одностороннее выдавливание, False - двустороннее.</param>
        /// <param name="flipCutSide">True - инвертировать сторону вырезания (для операций вычитания).</param>
        /// <param name="reverseDirection">True - изменить направление выдавливания на противоположное.</param>
        /// <param name="endCondition1">Тип завершения первой стороны (из перечисления swEndConditions_e).</param>
        /// <param name="endCondition2">Тип завершения второй стороны (из перечисления swEndConditions_e).</param>
        /// <param name="depth1">Глубина выдавливания первой стороны (в метрах).</param>
        /// <param name="depth2">Глубина выдавливания второй стороны (в метрах).</param>
        /// <param name="enableDraft1">True - включить уклон для первой стороны.</param>
        /// <param name="enableDraft2">True - включить уклон для второй стороны.</param>
        /// <param name="draftInward1">True - уклон внутрь для первой стороны.</param>
        /// <param name="draftInward2">True - уклон внутрь для второй стороны.</param>
        /// <param name="draftAngle1">Угол уклона первой стороны (в радианах).</param>
        /// <param name="draftAngle2">Угол уклона второй стороны (в радианах).</param>
        /// <param name="reverseOffset1">True - обратное направление смещения для первой стороны.</param>
        /// <param name="reverseOffset2">True - обратное направление смещения для второй стороны.</param>
        /// <param name="translateSurface1">True - трансляция поверхности для первой стороны.</param>
        /// <param name="translateSurface2">True - трансляция поверхности для второй стороны.</param>
        /// <param name="mergeResult">True - объединить результат с существующими телами.</param>
        /// <param name="useFeatureScope">True - ограничить область действия выбранными телами.</param>
        /// <param name="autoSelectBodies">True - автоматически выбирать затрагиваемые тела.</param>
        /// <param name="startCondition">Условие начала выдавливания (из перечисления swStartConditions_e).</param>
        /// <param name="startOffset">Смещение от плоскости эскиза для начала выдавливания.</param>
        /// <param name="reverseStartOffset">True - инвертировать направление начального смещения.</param>
        /// <returns>Созданный объект операции выдавливания.</returns>
        public static Feature CreateExtrusion(
            FeatureManager featureManager,
            bool isSingleEnded,
            bool flipCutSide,
            bool reverseDirection,
            swEndConditions_e endCondition1,
            swEndConditions_e endCondition2,
            double depth1,
            double depth2,
            bool enableDraft1,
            bool enableDraft2,
            bool draftInward1,
            bool draftInward2,
            double draftAngle1,
            double draftAngle2,
            bool reverseOffset1,
            bool reverseOffset2,
            bool translateSurface1,
            bool translateSurface2,
            bool mergeResult,
            bool useFeatureScope,
            bool autoSelectBodies,
            swStartConditions_e startCondition,
            double startOffset,
            bool reverseStartOffset)
        {
            return featureManager.FeatureExtrusion3(
                isSingleEnded,
                flipCutSide,
                reverseDirection,
                (int)endCondition1,
                (int)endCondition2,
                depth1,
                depth2,
                enableDraft1,
                enableDraft2,
                draftInward1,
                draftInward2,
                draftAngle1,
                draftAngle2,
                reverseOffset1,
                reverseOffset2,
                translateSurface1,
                translateSurface2,
                mergeResult,
                useFeatureScope,
                autoSelectBodies,
                (int)startCondition,
                startOffset,
                reverseStartOffset);
        }

        public static string GetActiveSketchName(ModelDoc2 modelDoc)
        {
            Feature activeSketch = (Feature)modelDoc.GetActiveSketch2();
            return activeSketch.Name;
        }

        /// <summary>
        /// Переименовывает элемент в дереве на переданное значение.
        /// </summary>
        /// <param name="feature">Элемент, который надо передать.</param>
        /// <param name="newName">Новое название элемента.</param>
        /// <exception cref="ArgumentNullException">Если переданный элемент пустой.</exception>
        /// <exception cref="Exception">Если при переименовании произошла ошибка.</exception>
        public static void RenameFeature(Feature feature, string newName)
        {
            if (feature == null)
                throw new ArgumentNullException("Невозможно переименовать пустой элемент.", nameof(feature));

            try
            {
                feature.Name = newName;
            }
            catch (Exception ex)
            {
                throw new Exception($"Не удалось переименовать {nameof(feature)}.\nПодробности: {ex.Message}");
            }
        }

        public static bool RenameActiveSketch(ModelDoc2 modelDoc, string newName)
        {
            try
            {
                Feature activeSketch = (Feature)modelDoc.GetActiveSketch2();
                activeSketch.Name = newName;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Выбирает объект по имени и типу с возможностью указания координат выбора.
        /// </summary>
        /// <param name="extension">Расширение документа модели.</param>
        /// <param name="name">Имя объекта для выбора.</param>
        /// <param name="type">Тип объекта для выбора.</param>
        /// <param name="x">X-координата точки выбора.</param>
        /// <param name="y">Y-координата точки выбора.</param>
        /// <param name="z">Z-координата точки выбора.</param>
        /// <param name="append">Добавить к текущему выделению.</param>
        /// <param name="mark">Метка выбора.</param>
        /// <param name="callout">Выноска.</param>
        /// <param name="selectOption">Опции выбора.</param>
        /// <returns>True, если выбор выполнен успешно.</returns>
        public static bool SelectByID2(ModelDocExtension extension, string name, string type, double x = 0, double y = 0, double z = 0, bool append = false, int mark = 0, Callout callout = null, int selectOption = 0)
        {
            return extension.SelectByID2(name, type, x, y, z, append, mark, callout, selectOption);
        }

        /// <summary>
        /// Выбирает стандартную плоскость по перечислению с локализацией имени.
        /// </summary>
        /// <param name="extension">Расширение документа модели.</param>
        /// <param name="plane">Плоскость из перечисления SwPlanes.</param>
        /// <param name="type">Тип объекта для выбора.</param>
        /// <param name="x">X-координата точки выбора.</param>
        /// <param name="y">Y-координата точки выбора.</param>
        /// <param name="z">Z-координата точки выбора.</param>
        /// <param name="append">Добавить к текущему выделению.</param>
        /// <param name="mark">Метка выбора.</param>
        /// <param name="callout">Выноска.</param>
        /// <param name="selectOption">Опции выбора.</param>
        /// <returns>True, если выбор выполнен успешно.</returns>
        public static bool SelectByID2(ModelDocExtension extension, SwPlanes plane, string type, double x = 0, double y = 0, double z = 0, bool append = false, int mark = 0, Callout callout = null, int selectOption = 0)
        {
            var localizedPlane = SwLocalizationHelper.GetLocalizedPlaneName(_swService.Language, plane);
            return extension.SelectByID2(localizedPlane, type, x, y, z, append, mark, callout, selectOption);
        }

        /// <summary>
        /// Обрезает выбранные объекты эскиза.
        /// </summary>
        /// <param name="sketchManager">Ссылка на действующий менеджер эскизов.</param>
        /// <param name="option">Опция обрезки эскиза из перечисления swSketchTrimChoice_e.</param>
        /// <param name="x">X координата места выбора.</param>
        /// <param name="y">Y координата места выбора.</param>
        /// <param name="z">Z координата места выбора.</param>
        /// <returns>True, если обрезание прошло успешно.</returns>
        /// <exception cref="ArgumentNullException">Если был передан пустой менеджер эскизов.</exception>
        /// <exception cref="NullReferenceException">Если нет активного эскиза.</exception>
        public static bool SketchTrim(SketchManager sketchManager, swSketchTrimChoice_e option, double x = 0, double y = 0, double z = 0)
        {
            if (sketchManager == null)
                throw new ArgumentNullException(nameof(sketchManager), "Не удалось получить менеджер эскизов.");

            if (sketchManager.ActiveSketch == null)
                throw new NullReferenceException("Этот метод можно использовать только при создании либо редактировании эскиза.");

            return sketchManager.SketchTrim((int)option, x, y, z);
        }

        #endregion
    }
}