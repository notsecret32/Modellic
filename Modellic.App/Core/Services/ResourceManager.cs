using Microsoft.Extensions.Logging;
using Modellic.App.Enums;
using Modellic.App.Exceptions;
using System;
using System.IO;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Services
{
    public static class ResourceManager
    {
        #region Public Statis Properties

        /// <summary>
        /// Путь до места, откуда было запущено приложение.
        /// </summary>
        public static string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Путь до папки с ресурсами приложения.
        /// </summary>
        public static string ResourceDirectory => IsDirectoryExists(Path.Combine(BaseDirectory, "Resources"));

        /// <summary>
        /// Путь до папки с примерами моделей и сборок.
        /// </summary>
        public static string ExamplesDirectory => IsDirectoryExists(Path.Combine(ResourceDirectory, "Examples"));

        /// <summary>
        /// Путь до папки с примерами моделей.
        /// </summary>
        public static string PartExamplesDirectory => IsDirectoryExists(Path.Combine(ExamplesDirectory, "Parts"));

        /// <summary>
        /// Путь до папки с примерами сборки.
        /// </summary>
        public static string AssemblyExamplesDirectory => IsDirectoryExists(Path.Combine(ExamplesDirectory, "Assemblies"));

        /// <summary>
        /// Путь до папки с шаблонами файлов.
        /// </summary>
        public static string TemplatesDirectory => IsDirectoryExists(Path.Combine(ResourceDirectory, "Templates"));

        /// <summary>
        /// Путь до папки с данными пользователя.
        /// </summary>
        public static string UserDataDirectory => GetOrCreateDirectory(Path.Combine(ResourceDirectory, "UserData"));

        /// <summary>
        /// Путь до папки с созданными пользователем приспособлениями.
        /// </summary>
        public static string UserDataFixturesDirectory => GetOrCreateDirectory(Path.Combine(UserDataDirectory, "Fixtures"));

        /// <summary>
        /// Путь до папки с созданными сборками от пользователя.
        /// </summary>
        public static string UserDataAssembliesDirectory => GetOrCreateDirectory(Path.Combine(UserDataDirectory, "Assemblies"));

        /// <summary>
        /// Путь до папки с картинками.
        /// </summary>
        public static string ImagesDirectory => IsDirectoryExists(Path.Combine(ResourceDirectory, "Images"));

        #endregion

        #region Constructor

        static ResourceManager()
        {
            Logger.LogInformation(
                "\n========== Resource Manager ==========" +
                $"\n* BaseDirectory: {BaseDirectory}" +
                $"\n* ResourceDirectory: {ResourceDirectory}" +
                $"\n* ExamplesDirectory: {ExamplesDirectory}" +
                $"\n* PartExamplesDirectory: {PartExamplesDirectory}" +
                $"\n* AssemblyExamplesDirectiry: {AssemblyExamplesDirectory}" +
                $"\n* UserDataDirectory: {UserDataDirectory}" +
                $"\n* UserDataFixturesDirectory: {UserDataFixturesDirectory}" +
                $"\n* UserDataAssembliesDirectory: {UserDataAssembliesDirectory}" +
                $"\n* ImagesDirectory: {ImagesDirectory}" +
                "\n======================================"
            );
        }

        #endregion

        #region Public Statuc Methods

        public static string GetPartExampleFileName(PartExampleType partExample)
        {
            return partExample switch
            {
                PartExampleType.Part => "PartExample.SLDPRT",
                PartExampleType.Fixture => "FixtureExample.SLDPRT",
                PartExampleType.Platform => "PlatformExample.SLDPRT",
                _ => throw new ResourceManagerException("Такого примера не существует.", ResourceManagerErrorCode.InvalidPartExample)
            };
        }

        public static string GetPartExampleFullPath(PartExampleType partExample)
        {
            string partExampleFileName = GetPartExampleFileName(partExample);
            return Path.Combine(PartExamplesDirectory, partExampleFileName);
        }

        public static string GetAssemblyExampleFileName(AssemblyExampleType assemblyExample)
        {
            return assemblyExample switch
            {
                AssemblyExampleType.Stop => "StopExample.SLDASM",
                AssemblyExampleType.Assembly => "AssemblyExample.SLDASM",
                _ => throw new ResourceManagerException("Такого примера не существует.", ResourceManagerErrorCode.InvalidAssemblyExample)
            };
        }

        public static string GetAssemblyExampleFullPath(AssemblyExampleType assemblyExample)
        {
            string assemblyExampleFileName = GetAssemblyExampleFileName(assemblyExample);
            return Path.Combine(AssemblyExamplesDirectory, assemblyExampleFileName);
        }

        public static string GetTemplateFileName(DocumentTemplate template)
        {
            return template switch
            {
                DocumentTemplate.EmptyPart => "EmptyPart.prtdot",
                DocumentTemplate.EmptyAssembly => "EmptyAssembly.asmdot",
                _ => throw new ResourceManagerException($"Шаблона {template} не существует.", ResourceManagerErrorCode.InvalidTemplateName)
            };
        }

        public static string GetTemplateFullPath(DocumentTemplate template) 
            => Path.Combine(TemplatesDirectory, GetTemplateFileName(template));

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Проверяет наличие папки, если есть, то возвращает полный путь до нее, иначе выбрасывает ошибку.
        /// </summary>
        /// <param name="path">Путь до папки, который будет проверяться.</param>
        /// <returns>Путь до папки, если она существует.</returns>
        /// <exception cref="DirectoryNotFoundException">Если путь указывает на несуществующую папку.</exception>
        private static string IsDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Logger.LogWarning("Папка не найдена");

                throw new ResourceManagerException($"Папки по пути {path} не существует.", ResourceManagerErrorCode.DirectoryNotFound);
            }

            return path;
        }

        /// <summary>
        /// Возвращает путь до папки либо создает новую и возвращает путь до нее.
        /// </summary>
        /// <param name="path">Путь, который надо проверить.</param>
        /// <returns>Путь до созданной либо уже существующей папки.</returns>
        private static string GetOrCreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Logger.LogWarning("Папка не найдена, создаем");

                Directory.CreateDirectory(path);
                return Path.GetFullPath(path);
            }

            return path;
        }

        #endregion
    }
}
