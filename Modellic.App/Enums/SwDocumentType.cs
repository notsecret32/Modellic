using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;

namespace Modellic.App.Enums
{
    /// <summary>
    /// Типы документов SolidWorks, которым может быть <see cref="ModelDoc2"/> из <see cref="swDocumentTypes_e"/>.
    /// </summary>
    public enum SwDocumentType
    {
        /// <summary>
        /// Неопределенный тип документа (например, когда документ не открыт или не создан).
        /// </summary>
        None = 0,

        /// <summary>
        /// Файл, содержащий 3D-модель отдельной детали.
        /// </summary>
        Part = 1,

        /// <summary>
        /// Сборка, содержащая компоновку нескольких деталей и подсборок.
        /// </summary>
        Assembly = 2,

        /// <summary>
        /// Чертеж, содержащий 2D-виды моделей (детали или сборки) с размерами и аннотациями.
        /// </summary>
        Drawing = 3,

        /// <summary>
        /// Использовался в ранних версиях для управления проектами (аналог PDM).
        /// </summary>
        [Obsolete("Тип документа SDM больше не поддерживается в SolidWorks")]
        SmartDesignManager = 4,

        /// <summary>
        /// Файл компоновки. Позволяет создавать схематичные эскизы сборок без детального моделирования.
        /// </summary>
        Layout = 5,

        /// <summary>
        /// Деталь, импортированная из других CAD-систем.
        /// </summary>
        ImportedPart = 6,

        /// <summary>
        /// Сборка, импортированная из других CAD-форматов.
        /// </summary>
        ImportedAssembly = 7
    }
}
