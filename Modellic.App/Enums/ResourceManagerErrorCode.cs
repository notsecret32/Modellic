using Modellic.App.Core.Services;

namespace Modellic.App.Enums
{
    /// <summary>
    /// Список ошибок возникающий при работе с <see cref="ResourceManager"/>.
    /// </summary>
    public enum ResourceManagerErrorCode
    {
        /// <summary>
        /// Папка не найдена.
        /// </summary>
        DirectoryNotFound,

        /// <summary>
        /// Такого тега примера детали не существует либо не обработан.
        /// </summary>
        InvalidPartTag,

        /// <summary>
        /// Такого примера детали не существует.
        /// </summary>
        InvalidPartExample,

        /// <summary>
        /// Такого тега примера сборки не существует либо не обработан.
        /// </summary>
        InvalidAssemblyTag,

        /// <summary>
        /// Такого примера сборки не существует.
        /// </summary>
        InvalidAssemblyExample,

        /// <summary>
        /// Неправильное название шаблона документа.
        /// </summary>
        InvalidTemplateName
    }
}
