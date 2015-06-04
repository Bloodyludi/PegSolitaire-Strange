using strange.extensions.signal.impl;

public class StartSignal : Signal{};
public class FieldClickedSignal : Signal<int>{};
public class SelectChipSignal : Signal<int>{};
public class DeselectChipSignal : Signal<int>{};
public class MoveChipSignal : Signal<int>{};


//public class ValidateChipSelectionSignal : Signal<ChipView>{};
//public class ChipSelectionValidationResultSignal : Signal<bool>{};