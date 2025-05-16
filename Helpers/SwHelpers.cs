using Modellic.Enums;
using Modellic.Services;
using SolidWorks.Interop.sldworks;
using System;

namespace Modellic.Helpers
{
    public static class SwHelpers
    {
        private static readonly SwService _swService = SwService.GetInstance();

        public static bool SelectByID2(
            ModelDocExtension extension,
            SwPlanes plane,
            string type,
            double x = 0,
            double y = 0,
            double z = 0,
            bool append = false,
            int mark = 0,
            Callout callout = null,
            int selectOption = 0
        )
        {
            var localizedPlane = SwLocalizationHelper.GetLocalizedPlaneName(_swService.Language, plane);
            return extension.SelectByID2(localizedPlane, type, x, y, z, append, mark, callout, selectOption);
        }

        public static bool SelectByID2(
            ModelDocExtension extension,
            string name,
            string type,
            double x = 0,
            double y = 0,
            double z = 0,
            bool append = false,
            int mark = 0,
            Callout callout = null,
            int selectOption = 0
        )
        {
            return extension.SelectByID2(name, type, x, y, z, append, mark, callout, selectOption);
        }

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
        /// <remarks>
        /// Для простого выдавливания используйте isSingleEnded=true, укажите endCondition1 и depth1.
        /// Для двустороннего выдавливания установите isSingleEnded=false и задайте параметры для обеих сторон.
        /// </remarks>
        public static Feature CreateExtrusion(
            FeatureManager featureManager,
            bool isSingleEnded,
            bool flipCutSide,
            bool reverseDirection,
            int endCondition1,
            int endCondition2,
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
            int startCondition,
            double startOffset,
            bool reverseStartOffset
        )
        {
            return featureManager.FeatureExtrusion3(
                isSingleEnded,
                flipCutSide,
                reverseDirection,
                endCondition1,
                endCondition2,
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
                startCondition,
                startOffset,
                reverseStartOffset
            );
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

        /// <summary>
        /// Переименовывает грань в детали SolidWorks.
        /// </summary>
        /// <param name="modelDoc">Документ, в котором нужно переименовать грань.</param>
        /// <param name="face">Грань для переименования.</param>
        /// <param name="newName">Новое имя грани.</param>
        /// <exception cref="ArgumentNullException">Если грань не указана.</exception>
        /// <exception cref="ArgumentException">Если переданная строка пустая либо содержиит пустые или запрещенные символы.</exception>
        /// <exception cref="InvalidOperationException">Если операция не удалась.</exception>
        public static void RenameFace(ModelDoc2 modelDoc, Face2 face, string newName)
        {
            if (face == null)
            {
                throw new ArgumentNullException(nameof(face), "Грань не может быть null");
            }

            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Имя грани не может быть пустым", nameof(newName));
            }

            try
            {
                if (modelDoc == null)
                {
                    throw new InvalidOperationException("Нет активного документа");
                }

                var partDoc = (PartDoc)modelDoc ?? throw new InvalidOperationException("Активный документ не является деталью");

                bool success = partDoc.SetEntityName((Entity)face, newName);

                if (!success)
                {
                    throw new InvalidOperationException($"Не удалось установить имя '{newName}' для грани");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ошибка при переименовании грани", ex);
            }
        }

        /// <summary>
        /// Переименовывает ребро в детали SolidWorks.
        /// </summary>
        /// <param name="modelDoc">Документ, в котором нужно переименовать ребро.</param>
        /// <param name="edge">Ребро для переименования.</param>
        /// <param name="newName">Новое имя ребра.</param>
        /// <exception cref="ArgumentNullException">Если ребро не указано.</exception>
        /// <exception cref="ArgumentException">Если переданная строка пустая либо содержиит пустые или запрещенные символы.</exception>
        /// <exception cref="InvalidOperationException">Если операция не удалась.</exception>
        public static void RenameEdge(ModelDoc2 modelDoc, Edge edge, string newName)
        {
            if (edge == null)
            {
                throw new ArgumentNullException(nameof(edge), "Ребро не может быть null");
            }

            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Имя ребра не может быть пустым", nameof(newName));
            }

            try
            {
                if (modelDoc == null)
                    throw new InvalidOperationException("Нет активного документа");

                var partDoc = (PartDoc)modelDoc ?? throw new InvalidOperationException("Активный документ не является деталью");

                bool success = partDoc.SetEntityName((Entity)edge, newName);
                if (!success)
                    throw new InvalidOperationException($"Не удалось установить имя '{newName}' для ребра");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ошибка при переименовании ребра", ex);
            }
        }
    }
}
