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
                deselectChipSignal.Dispatch(selectedField.Index);

            selectedField = value;

            if (!IsEmpty())
            {
                Debug.Log(selectedField.Index);
                selectChipSignal.Dispatch(selectedField.Index);
            }
        }
    }
    IFieldModel selectedField;

    public bool IsEmpty()
    {
        return selectedField == null;
    }
}

