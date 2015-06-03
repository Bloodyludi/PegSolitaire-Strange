using strange.extensions.signal.impl;

public class StartSignal : Signal{};
public class ValidateChipSelectionSignal : Signal<ChipView>{};
public class ChipSelectionValidationResultSignal : Signal<bool>{};