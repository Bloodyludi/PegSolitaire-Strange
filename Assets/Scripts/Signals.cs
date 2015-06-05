using strange.extensions.signal.impl;

public class StartSignal : Signal{};
public class FieldClickedSignal : Signal<int>{};
public class SelectedChipSignal : Signal<int>{};
public class DeselectedChipSignal : Signal<int>{};
public class MoveChipSignal : Signal<int>{};
public class DestroyChipViewSignal : Signal<int>{};
public class MoveChipViewSignal : Signal<int, int>{};


//public class ValidateChipSelectionSignal : Signal<ChipView>{};
//public class ChipSelectionValidationResultSignal : Signal<bool>{};
