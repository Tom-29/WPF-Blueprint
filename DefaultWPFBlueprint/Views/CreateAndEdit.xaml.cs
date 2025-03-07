using System.Windows.Controls;
using DefaultWPFBlueprint.ViewModels;

namespace DefaultWPFBlueprint.Views;

public partial class CreateAndEdit : UserControl
{
    public CreateAndEdit(ItemFormViewModel model)
    {
        InitializeComponent();
        DataContext = model;
    }
}