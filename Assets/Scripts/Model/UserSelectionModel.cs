using UnityEngine;


public class UserSelectionModel : IUserSelectionModel
{
    [Inject]
    public SelectedChipSignal selectChipSignal { get; set; }

    [Inject]
    public DeselectedChipSignal deselectChipSignal { get; set; }

    public IFieldModel SelectedField
    {
        get
        {
            return selectedField;
        }
        set
        {
            if (!IsEmpty())
                deselectChipSignal.Dispatch(selectedField.ViewID);

            selectedField = value;

            if (!IsEmpty())
            {
                Debug.Log("Selected: " + selectedField.Index + " " + selectedField.ViewID);
                selectChipSignal.Dispatch(selectedField.ViewID);
            }
        }
    }
    IFieldModel selectedField;

    public bool IsEmpty()
    {
        return selectedField == null;
    }
}

