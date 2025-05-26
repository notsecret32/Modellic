using Modellic.App.SolidWorks.Core;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;

namespace Modellic.App.SolidWorks.Managers
{
    /// <summary>
    /// Представляет менеджер выбранных элементов.
    /// </summary>
    public class SwSelectionManager : SwObject<SelectionMgr>
    {
        #region Constructor

        public SwSelectionManager(SelectionMgr model) : base(model)
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Метод для получения выбранных элементов.
        /// </summary>
        /// <param name="action">Лямбда, принимающая массив выбранных элементов.</param>
        public void GetSelectedObjects(Action<List<SwSelectedObject>> action)
        {
            var list = new List<SwSelectedObject>();

            try
            {
                // Получаем кол-во выбранных элементов
                var count = BaseObject.GetSelectedObjectCount2(-1);

                // Если ничего нет, выходим
                if (count <= 0)
                {
                    action(new List<SwSelectedObject>());
                    return;
                }

                // Иначе проходимся по каждому выбранному объекту
                for (var i = 0; i < count; i++)
                {
                    // Получаем сам объект
                    var selected = new SwSelectedObject(BaseObject.GetSelectedObject6(i + 1, -1))
                    {
                        // Получаем тип объекта
                        ObjectType = (swSelectType_e)BaseObject.GetSelectedObjectType3(i + 1, -1)
                    };

                    // Добавляем в список выбранных элементов
                    list.Add(selected);
                }

                // Вызываем фукнция
                action(list);
            }
            finally
            {
                // Освобождаем ресурсы
                list.ForEach(f => f.Dispose());
            }
        }

        #endregion
    }
}
