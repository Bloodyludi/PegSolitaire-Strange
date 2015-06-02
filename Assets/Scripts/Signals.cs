using strange.extensions.signal.impl;
using UnityEngine;

public class StartSignal : Signal{};
public class ValidateChipSelectionSignal : Signal<ChipView>{};
public class ChipSelectionValidationResultSignal : Signal<bool>{};