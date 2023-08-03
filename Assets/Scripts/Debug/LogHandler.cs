// ������� �����, ���������� ���������������� ��, ��� �� �����

#define ENABLE_ITEMS_LOGS

// ������ �������, ����� ����� ��� ��������� ����

//#define DISABLE_ALL_NON_WARNINGS_LOGS // ��������� ��� ���� ����� �������������� � ������
//#define DISABLE_ALL_NON_ERRORS_LOGS   // ��������� ��� ���� ����� ������
//#define DISABLE_ALL_LOGS              // ��������� ��� ����

/*
    ����� ������������� �������� ����������� ����� � ���� ������ � ���������� ������� Unity

    [TODO: ����������� ��������� ������� ���������� ����� �����]

    ��� ���������� ����� ��������� ����� ����� ������� ��:
    - ���� ������
    - ����� ��� � LogHandler
    - ������� ��������� ����� ����� ���� � ��������
*/

using UnityEngine;

// ��������� ��������� ����� Debug.Log ����� ����� ����������� ��������� ���� � ���������������� �� 
public static class LogHandler
{
    public enum LogCategories
    {
        ITEMS,
    }

    public static void Message(LogCategories category, string format, params object[] args)
    {
        // ���������, ��� ��������� ��� ����� ���������� � ��������� ������� ��� ����
        // ������������ #if ��� ������� ����������� ����� � �����

#if (!DISABLE_ALL_NON_WARNINGS_LOGS && !DISABLE_ALL_NON_ERRORS_LOGS && !DISABLE_ALL_LOGS) // �������� ������ ��������

        switch (category) // ���������� ��������� � ��������� ����� �� ��� ������������ ���� ���
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
        // ���������, ��� ��������� ��� ����� ���������� � ��������� ������� ��� ����
        // ������������ #if ��� ������� ����������� ����� � �����

#if (!DISABLE_ALL_NON_WARNINGS_LOGS && !DISABLE_ALL_NON_ERRORS_LOGS && !DISABLE_ALL_LOGS) // �������� ������ ��������

        switch (category) // ���������� ��������� � ��������� ����� �� ��� ������������ ���� ���
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
        // ���������, ��� ��������� ��� ����� ���������� � ��������� ������� ��� ����
        // ������������ #if ��� ������� ����������� ����� � �����

#if (!DISABLE_ALL_NON_ERRORS_LOGS && !DISABLE_ALL_LOGS) // �������� ������ ��������

        switch (category) // ���������� ��������� � ��������� ����� �� ��� ������������ ���� ���
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
        // ���������, ��� ��������� ��� ����� ���������� � ��������� ������� ��� ����
        // ������������ #if ��� ������� ����������� ����� � �����

#if (!DISABLE_ALL_NON_ERRORS_LOGS && !DISABLE_ALL_LOGS) // �������� ������ ��������

        switch (category) // ���������� ��������� � ��������� ����� �� ��� ������������ ���� ���
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
        // ���������, ��� ��������� ��� ����� ���������� � ��������� ������� ��� ����
        // ������������ #if ��� ������� ����������� ����� � �����

#if !DISABLE_ALL_LOGS // �������� ������ ��������

        switch (category) // ���������� ��������� � ��������� ����� �� ��� ������������ ���� ���
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
        // ���������, ��� ��������� ��� ����� ���������� � ��������� ������� ��� ����
        // ������������ #if ��� ������� ����������� ����� � �����

#if !DISABLE_ALL_LOGS // �������� ������ ��������

        switch (category) // ���������� ��������� � ��������� ����� �� ��� ������������ ���� ���
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
