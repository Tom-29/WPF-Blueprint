using System.Windows.Controls;

namespace DefaultWPFBlueprint.Services;

public class NavigationService
{
    public static Action<Type, object?>? Navigate;

    public static void NavigateTo<T>(object? parameter = null) where T :
        UserControl
    {
        Navigate?.Invoke(typeof(T), parameter);
    }
}