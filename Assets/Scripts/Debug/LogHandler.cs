// Дефайны логов, необходимо закоменнтировать те, что не нужны

#define ENABLE_ITEMS_LOGS

// Особые дефайны, мутят почти все остальные логи

//#define DISABLE_ALL_NON_WARNINGS_LOGS // Отключает все логи кроме Предупреждений и Ошибок
//#define DISABLE_ALL_NON_ERRORS_LOGS   // Отключает все логи кроме Ошибок
//#define DISABLE_ALL_LOGS              // Отключает все логи

/*
    Также рекомендуется включить отображение логов в одну строку в настройках консоли Unity

    [TODO: Попробовать упростить процесс добавления типов логов]

    Для добавления новой категории логов нужно сделать ей:
    - Свой дефайн
    - Новый тип в LogHandler
    - Сделать обработку логов этого типа в хендлере
*/

using UnityEngine;

// Кастомная прослойка перед Debug.Log чтобы иметь возможность отключать логи и категоризировать их 
public static class LogHandler
{
    public enum LogCategories
    {
        ITEMS,
    }

    public static void Message(LogCategories category, string format, params object[] args)
    {
        // Проверяем, что пришедший лог нужно обработать и добавляем префикс его типа
        // используется #if для попытки оптимизации логов в билде

#if (!DISABLE_ALL_NON_WARNINGS_LOGS && !DISABLE_ALL_NON_ERRORS_LOGS && !DISABLE_ALL_LOGS) // Проверка особых дефайнов

        switch (category) // Распознаем категорию и проверяем нужно ли нам обрабатывать этот лог
        {
            case LogCategories.ITEMS:
#if ENABLE_ITEMS_LOGS
                Debug.LogFormat("[" + category.ToString() + "] " + format, args);
#endif
                break;

            default:
                break;
        }

#endif
    }
    public static void Message(LogCategories category, Object context, string format, params object[] args)
    {
        // Проверяем, что пришедший лог нужно обработать и добавляем префикс его типа
        // используется #if для попытки оптимизации логов в билде

#if (!DISABLE_ALL_NON_WARNINGS_LOGS && !DISABLE_ALL_NON_ERRORS_LOGS && !DISABLE_ALL_LOGS) // Проверка особых дефайнов

        switch (category) // Распознаем категорию и проверяем нужно ли нам обрабатывать этот лог
        {
            case LogCategories.ITEMS:
#if ENABLE_ITEMS_LOGS
                Debug.LogFormat(context, "[" + category.ToString() + "] " + format, args);
#endif
                break;

            default:
                break;
        }

#endif
    }

    public static void Warning(LogCategories category, string format, params object[] args)
    {
        // Проверяем, что пришедший лог нужно обработать и добавляем префикс его типа
        // используется #if для попытки оптимизации логов в билде

#if (!DISABLE_ALL_NON_ERRORS_LOGS && !DISABLE_ALL_LOGS) // Проверка особых дефайнов

        switch (category) // Распознаем категорию и проверяем нужно ли нам обрабатывать этот лог
        {
            case LogCategories.ITEMS:
#if ENABLE_ITEMS_LOGS
                Debug.LogWarningFormat("[" + category.ToString() + "] " + format, args);
#endif
                break;

            default:
                break;
        }

#endif
    }
    public static void Warning(LogCategories category, Object context, string format, params object[] args)
    {
        // Проверяем, что пришедший лог нужно обработать и добавляем префикс его типа
        // используется #if для попытки оптимизации логов в билде

#if (!DISABLE_ALL_NON_ERRORS_LOGS && !DISABLE_ALL_LOGS) // Проверка особых дефайнов

        switch (category) // Распознаем категорию и проверяем нужно ли нам обрабатывать этот лог
        {
            case LogCategories.ITEMS:
#if ENABLE_ITEMS_LOGS
                Debug.LogWarningFormat(context, "[" + category.ToString() + "] " + format, args);
#endif
                break;

            default:
                break;
        }

#endif
    }

    public static void Error(LogCategories category, string format, params object[] args)
    {
        // Проверяем, что пришедший лог нужно обработать и добавляем префикс его типа
        // используется #if для попытки оптимизации логов в билде

#if !DISABLE_ALL_LOGS // Проверка особых дефайнов

        switch (category) // Распознаем категорию и проверяем нужно ли нам обрабатывать этот лог
        {
            case LogCategories.ITEMS:
#if ENABLE_ITEMS_LOGS
                Debug.LogErrorFormat("[" + category.ToString() + "] " + format, args);
#endif
                break;

            default:
                break;
        }

#endif
    }
    public static void Error(LogCategories category, Object context, string format, params object[] args)
    {
        // Проверяем, что пришедший лог нужно обработать и добавляем префикс его типа
        // используется #if для попытки оптимизации логов в билде

#if !DISABLE_ALL_LOGS // Проверка особых дефайнов

        switch (category) // Распознаем категорию и проверяем нужно ли нам обрабатывать этот лог
        {
            case LogCategories.ITEMS:
#if ENABLE_ITEMS_LOGS
                Debug.LogErrorFormat(context, "[" + category.ToString() + "] " + format, args);
#endif
                break;

            default:
                break;
        }

#endif
    }
}
